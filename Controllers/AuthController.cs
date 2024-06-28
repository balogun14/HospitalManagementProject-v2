using AspNetCoreHero.ToastNotification.Abstractions;
using HospitalManagementProject.Models;
using HospitalManagementProject.ViewModels.AuthViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementProject.Controllers
{
    public class AuthController(SignInManager<User> signInManager, UserManager<User> userManager, INotyfService notyf,ILogger<AuthController> logger
) : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user.Email!, model.Password, false, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        notyf.Success("Login successful");
                        return RedirectToAction("Index", "home");
                    }
                }

                ModelState.AddModelError("", "Invalid login attempt");
                notyf.Error("Invalid login attempt");
                return View(model);
            }


            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await userManager.Users.SingleOrDefaultAsync(u => u.Email == model.Email);

                if (existingUser != null)
                {
                    notyf.Warning("User already exist!");
                    return View();
                }

                var user = new User
                {
                    Email = model.Email,
                    UserName = model.Email
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    notyf.Error("An error occured while registering user!" );
                    var message =  string.Join(", ", result.Errors.Select(x => "Code " + x.Code + " Description" + x.Description));
                    logger.LogCritical(message);
                    return View();
                }

                notyf.Success("Registration was successful");
                await signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "home");
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Edit(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditView model){
            if(ModelState.IsValid){
                var user = await userManager.FindByIdAsync(model.Id.ToString());
                if(user == null){
                    notyf.Error("User not found!");
                    return View();
                }

                user.Email = model.Email;
                user.PhoneNumber = model.Phone;

                var result = await userManager.UpdateAsync(user);

                if(!result.Succeeded){
                    notyf.Error("An error occured while updating user!");
                    return View();
                }

                notyf.Success("User updated successfully!");
                return RedirectToAction("Index", "home");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout(){
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "home");
        }
    }
}