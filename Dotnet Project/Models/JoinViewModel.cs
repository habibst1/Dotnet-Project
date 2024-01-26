﻿using System.ComponentModel.DataAnnotations;

namespace Dotnet_Project.Models
{
    public class JoinViewModel
    {
        [Required(ErrorMessage = "Please select at least one player.")]
        public List<int> SelectedPlayerIds { get; set; }
    }
}