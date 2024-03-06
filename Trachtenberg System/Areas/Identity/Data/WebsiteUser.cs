using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Trachtenberg_System.Models;

namespace Trachtenberg_System.Areas.Identity.Data;

// Add profile data for application users by adding properties to the WebsiteUser class
// parent
public class WebsiteUser : IdentityUser
{
    public HighScoresModel? HighScoresRef { get; set; }
    public string? AccountName { get; set; } 
    
}

