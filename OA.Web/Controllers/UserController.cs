using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OA.Data;
using OA.Repo;
using OA.Service;
using OA.Web.Models;

namespace OA.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IUserProfileService userProfileService;

        public UserController(IUserService userService, IUserProfileService userProfileService)
        {
            this.userService = userService;
            this.userProfileService = userProfileService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<UserViewModel> model = new List<UserViewModel>();
            if (userService != null)
            {
                userService.GetUsers().ToList().ForEach(u =>
                {
                    UserProfile userProfile = userProfileService.GetUserProfile(u.Id);
                    UserViewModel user = new UserViewModel
                    {
                        Id = u.Id,
                        Name = $"{userProfile.FirstName} {userProfile.LastName}",
                        Email = u.Email,
                        Address = userProfile.Address
                    };
                    model.Add(user);
                });
            }

            return View(model);
        }
    }
}