using Lab_2.Models;
using Lab_2.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_2.Controllers
{
    public class AuthenticationController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public AuthenticationController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [Route("register")] // /api/autherization/register

        public async Task<ActionResult> RegisterUser(RegisterRequest registerRequest)
        {
            return Ok();
        }
    }
}
