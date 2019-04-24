using attendance.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace attendance.Controllers
{
    public class UserAndRolesController : Controller
    {
        ApplicationDbContext dbCon = new ApplicationDbContext();
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: UserAndRolesConroller
       // public ActionResult Index()
       // {
         //   return View();
       // }
        public async Task<ActionResult> AddUserToRole()
        {
            ApplicationUserRoleViewModel vm = new ApplicationUserRoleViewModel();
            var Users = await dbCon.Users.ToListAsync();
            var roles = await dbCon.Roles.ToListAsync();
            ViewBag.UserId = new SelectList(Users, "Id", "UserName");
            ViewBag.RoleId = new SelectList(roles, "Id", "Name");
            return View(vm);
        }

        [HttpPost]
        public async Task<ActionResult> AddUserToRole(ApplicationUserRoleViewModel model)
        {
            var role = dbCon.Roles.Find(model.RoleId);
            if (role != null)
            {
                await UserManager.AddToRoleAsync(model.UserId, role.Name);
            }
            return RedirectToAction("AddUserToRole");

        }
    }
}