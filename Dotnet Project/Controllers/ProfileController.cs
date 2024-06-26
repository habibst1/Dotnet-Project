﻿using Dotnet_Project.Models;
using Dotnet_Project.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Security.Claims;
using Dotnet_Project.Models.ViewModels;

namespace Dotnet_Project.Controllers
{
    public class ProfileController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppDbContext _context;
        private readonly ImageHelper _imageHelper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProfileController(AppDbContext context, UserManager<IdentityUser> userManager, IWebHostEnvironment webHostEnvironment, ImageHelper imageHelper)
        {
            _context = context;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
            _imageHelper = imageHelper;
        }


        public async Task<IActionResult> Index()
        {
            // Retrieve the logged-in player
            var loggedInPlayerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (loggedInPlayerId == null)
            {
                // Handle the case where the user is not logged in
                return RedirectToAction("Welcome", "Home"); // Redirect to login or handle it accordingly
            }

            var loggedInPlayer = await _userManager.FindByIdAsync(loggedInPlayerId);

            if (loggedInPlayer == null)
            {
                // Handle the case where the user is not found
                return NotFound();
            }

            // Check if the logged-in player has the role "Player"
            var isPlayer = await _userManager.IsInRoleAsync(loggedInPlayer, "Player");

            if (isPlayer)
            {
                // Perform actions specific to the "Player" role
                // For example, redirect to a player dashboard
                return RedirectToAction("MyProfile");
            }
            else
            {
                return RedirectToAction("MyStadium");
            }
        }



        [Authorize(Roles = SD.Role_Player)]
        public IActionResult MyProfile()
        {

            // Retrieve the logged-in player 
            var loggedInPlayerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (loggedInPlayerId == null)
            {
                // Handle the case where the user is not logged in
                return RedirectToAction("Welcome", "Home"); // Redirect to login or handle it accordingly
            }


            var loggedInPlayer = _context.Users.Include(a => a.LinkedLobby)
                                                    .ThenInclude(t => t.TimeSlot).
                                                            ThenInclude(s => s.stadium)
                                               .Include(a => a.LinkedLobby)
                                                    .ThenInclude(l => l.Team1)
                                               .Include(a => a.LinkedLobby)
                                                    .ThenInclude(l => l.Team2)
                                               .FirstOrDefault(p => p.Id == loggedInPlayerId);

            if (loggedInPlayer.Notification)
            {
                TempData["error2"] = "Your lobby was removed";
                loggedInPlayer.Notification = false;
                _context.SaveChanges();
            }

            var lobbieshistory = _context.Lobbies
                                  .Include(l => l.TimeSlot)
                                  .ThenInclude(s => s.stadium)
                                  .Include(l => l.Team1)
                                  .Include(l => l.Team2)
                                  .AsEnumerable()
                                  .Where(l => (l.team1ids != null && l.team1ids.Contains(loggedInPlayerId)) || (l.team2ids != null && l.team2ids.Contains(loggedInPlayerId)) && l.IsFinished)
                                  .ToList();

            // Retrieve player names using _context.Users
            var team1IdsInLobbies = lobbieshistory
                .SelectMany(lobby => lobby.team1ids)
                .Distinct();

            var team1Names = _context.Users
                .Where(user => team1IdsInLobbies.Contains(user.Id))
                .ToDictionary(user => user.Id, user => user.Name)
                .ToDictionary(pair => pair.Key, pair => pair.Value);

            // Retrieve player names using _context.Users
            var team2IdsInLobbies = lobbieshistory
                .SelectMany(lobby => lobby.team2ids)
                .Distinct();

            var team2Names = _context.Users
                .Where(user => team2IdsInLobbies.Contains(user.Id))
                .ToDictionary(user => user.Id, user => user.Name)
                .ToDictionary(pair => pair.Key, pair => pair.Value);

            ProfileViewModel profile = new ProfileViewModel(lobbieshistory, loggedInPlayer, team1Names, team2Names);

            return View(profile);
        }


        [Authorize(Roles = SD.Role_Stade_Owner)]
        public IActionResult MyStadium()
        {
            // Retrieve the logged-in player 
            var loggedInPlayerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (loggedInPlayerId == null)
            {
                // Handle the case where the user is not logged in
                return RedirectToAction("Welcome", "Home"); // Redirect to login or handle it accordingly
            }

            var loggedInPlayer = _context.Users.Include(s => s.stade).ThenInclude(t => t.Times).FirstOrDefault(p => p.Id == loggedInPlayerId);



            return View(loggedInPlayer);
        }


        [Authorize(Roles = SD.Role_Stade_Owner)]
        [HttpPost]
        public IActionResult Create(Stadium stadium)
        {

            // Retrieve the logged-in player 
            var loggedInPlayerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (loggedInPlayerId == null)
            {
                // Handle the case where the user is not logged in
                return RedirectToAction("Welcome", "Home"); // Redirect to login or handle it accordingly
            }

            var loggedInPlayer = _context.Users.Include(s => s.stade).ThenInclude(s => s.Times).FirstOrDefault(p => p.Id == loggedInPlayerId);


            string photoFileName = _imageHelper.SaveStadiumPhoto(stadium.PhotoStade);
            string photoFileName2 = _imageHelper.SaveStadiumPhoto(stadium.PhotoStade2);

            stadium.PhotoPath = photoFileName;
            stadium.PhotoPath2 = photoFileName2;

            Stadium stade = loggedInPlayer.createStadium(stadium.Name, stadium.Description, stadium.Localisation, stadium.exactLocalisation, stadium.PhotoPath, stadium.PhotoPath2, stadium.prix, stadium.nbminutes);

            _context.Stadiums.Add(stade);
            _context.SaveChanges();

            return RedirectToAction("MyStadium");
        }



        [Authorize(Roles = SD.Role_Stade_Owner)]
        [HttpPost]
        public IActionResult AddTimeSlot(DateTime date, string starttime, string endtime)
        {
            // Retrieve the logged-in player 
            var loggedInPlayerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (loggedInPlayerId == null)
            {
                // Handle the case where the user is not logged in
                return RedirectToAction("Welcome", "Home"); // Redirect to login or handle it accordingly
            }

            var loggedInPlayer = _context.Users.Include(s => s.stade).ThenInclude(s => s.Times).FirstOrDefault(p => p.Id == loggedInPlayerId);

            // Parse the input strings to DateTime
            DateTime startDateTime = DateTime.Parse($"{date.ToShortDateString()} {starttime}");
            DateTime endDateTime = DateTime.Parse($"{date.ToShortDateString()} {endtime}");

            if (startDateTime <= DateTime.Now)
            {
                TempData["error"] = "Please choose a future time";
                return RedirectToAction("MyStadium");
            }

            // Check if endDateTime is before startDateTime, which means it's past midnight
            if (endDateTime < startDateTime)
            {
                // Adjust the date for endDateTime
                endDateTime = endDateTime.AddDays(1);
            }

            var timeSlot = new Time_Slot(loggedInPlayer.stade, startDateTime, endDateTime);
            loggedInPlayer.add_time_slot(timeSlot);

            _context.TimeSlots.Add(timeSlot);
            _context.SaveChanges();

            return RedirectToAction("MyStadium");
        }

        [Authorize(Roles = SD.Role_Stade_Owner)]
        [HttpPost]
        public IActionResult ReserveTimeSlot(int id)
        {
            // Retrieve the logged-in player 
            var loggedInPlayerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (loggedInPlayerId == null)
            {
                // Handle the case where the user is not logged in
                return RedirectToAction("Welcome", "Home"); // Redirect to login or handle it accordingly
            }

            var loggedInPlayer = _context.Users.Include(s => s.stade).ThenInclude(s => s.Times).FirstOrDefault(p => p.Id == loggedInPlayerId);

            var timeSlot = _context.TimeSlots.Include(s => s.stadium).FirstOrDefault(t => t.Id == id);

            timeSlot.occupancy = true;



            _context.SaveChanges();

            return RedirectToAction("MyStadium");
        }


        [Authorize(Roles = SD.Role_Player)]
        [HttpPost]
        public IActionResult AddScore(int team1_score, int team2_score, int lobbyId)
        {
            // Retrieve the logged-in player 
            var loggedInPlayerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (loggedInPlayerId == null)
            {
                // Handle the case where the user is not logged in
                return RedirectToAction("Welcome", "Home"); // Redirect to login or handle it accordingly
            }



            var lobby = _context.Lobbies.FirstOrDefault(l => l.Id == lobbyId);

            if (lobby.adminId == loggedInPlayerId)
            {
                lobby.team1_score = team1_score;
                lobby.team2_score = team2_score;
            }

            if (team1_score > team2_score)
            {
                for (int i = 0; i < 6; i++)
                {
                    var player1 = _context.Users.FirstOrDefault(p => p.Id == lobby.team1ids[i]);
                    var player2 = _context.Users.FirstOrDefault(p => p.Id == lobby.team2ids[i]);
                    player1.number_wins++;
                    player2.number_losses++;
                }
            }
            else if (team1_score < team2_score)
            {
                for (int i = 0; i < 6; i++)
                {
                    var player1 = _context.Users.FirstOrDefault(p => p.Id == lobby.team1ids[i]);
                    var player2 = _context.Users.FirstOrDefault(p => p.Id == lobby.team2ids[i]);
                    player1.number_losses++;
                    player2.number_wins++;
                }
            }
            else
            {
                for (int i = 0; i < 6; i++)
                {
                    var player1 = _context.Users.FirstOrDefault(p => p.Id == lobby.team1ids[i]);
                    var player2 = _context.Users.FirstOrDefault(p => p.Id == lobby.team2ids[i]);
                    player1.number_draws++;
                    player2.number_draws++;
                }
            }


            _context.SaveChanges();

            return RedirectToAction("MyProfile");
        }

        [Authorize(Roles = SD.Role_Player)]
        [HttpPost]
        public IActionResult RemoveLobby(int lobbyId)
        {
            // Retrieve the logged-in player 
            var loggedInPlayerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (loggedInPlayerId == null)
            {
                // Handle the case where the user is not logged in
                return RedirectToAction("Welcome", "Home"); // Redirect to login or handle it accordingly
            }

            var loggedInPlayer = _context.Users.Include(l => l.LinkedLobby).FirstOrDefault(p => p.Id == loggedInPlayerId);

            var lobby = _context.Lobbies.Include(p => p.Players).Include(t => t.TimeSlot).ThenInclude(li => li.LinkedLobbies).FirstOrDefault(l => l.Id == lobbyId);

            if (lobby.adminId == loggedInPlayerId)
            {
                var linkedPlayers = _context.Users.Where(p => p.LinkedLobbyId == lobby.Id).ToList();

                foreach (var player in linkedPlayers)
                {
                    player.LinkedLobbyId = null;
                    player.notify();
                }
                lobby.admin = null;
                lobby.TimeSlot.LinkedLobbies.Remove(lobby);

                _context.Lobbies.Remove(lobby);
                _context.SaveChanges();
            }


            return RedirectToAction("MyProfile");
        }

        [Authorize(Roles = SD.Role_Player)]
        [HttpPost]
        public IActionResult LeaveLobby(int lobbyId)
        {
            // Retrieve the logged-in player 
            var loggedInPlayerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (loggedInPlayerId == null)
            {
                // Handle the case where the user is not logged in
                return RedirectToAction("Welcome", "Home"); // Redirect to login or handle it accordingly
            }

            var loggedInPlayer = _context.Users.Include(l => l.LinkedLobby).FirstOrDefault(p => p.Id == loggedInPlayerId);

            var lobby = _context.Lobbies.Include(p => p.Players).FirstOrDefault(l => l.Id == lobbyId);

            lobby.Players.Remove(loggedInPlayer);
            
            loggedInPlayer.LinkedLobby = null;

            TempData["error2"] = "You have left your lobby";

            _context.SaveChanges();

            return RedirectToAction("MyProfile");
        }
    }
}
