﻿using System.ComponentModel.DataAnnotations;

namespace Dotnet_Project.Models.ViewModels
{
    public class JoinViewModel
    {
        [Required(ErrorMessage = "Please select at least one player.")]
        public List<string> SelectedPlayerIds { get; set; }
    }
}