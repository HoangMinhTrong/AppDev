using AppDev.Data;
using AppDev.Models;
using AppDev.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDev.Controllers
{
    public class TrainerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public TrainerController(
            ApplicationDbContext context, 
            UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {

            var trainers = _context.Trainers
                .Include(x => x.ApplicationUser)
                .Select(x => new TrainerViewModel
                {
                    Address = x.Address,
                    Age = x.ApplicationUser.Age,
                    FullName = x.ApplicationUser.FullName,
            
                    Email = x.ApplicationUser.Email,

                }).ToList();
            

            return View(trainers);
        }

        public IActionResult Create()
        {
            var model = new TrainerViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(TrainerViewModel model)
        {
            
            /// Chuyển tạo role có sẵn vào phần data seeding
            var findRoleResult = _roleManager.FindByNameAsync("Trainer").GetAwaiter().GetResult();
            if(findRoleResult==null)
            {
                var trainerRole = new IdentityRole()
                {
                    Name = "Trainer",
                    NormalizedName = "TRAINER"
                };
                _roleManager.CreateAsync(trainerRole);
            }
            var user = new ApplicationUser()
            {
                UserName = model.Email,
                Email = model.Email,
                Age = model.Age,
                FullName = model.FullName
            };
            
            var createResult = _userManager.CreateAsync(user, model.Password).GetAwaiter().GetResult();
            if(createResult==IdentityResult.Success)
            {
                _userManager.AddToRoleAsync(user, "Trainer").GetAwaiter().GetResult();
            }
            var trainer = new Trainer()
            {
                ApplicationUserId = user.Id,
                Address = model.Address,
            };
            _context.Trainers.Add(trainer);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }
    }
}
