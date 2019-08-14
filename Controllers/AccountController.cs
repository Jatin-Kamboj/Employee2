using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> signIn;
        private readonly UserManager<IdentityUser> userManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signIn)
        {
            this.signIn = signIn;
            this.userManager = userManager;
        }

      [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel Model) // Creating the Action as Async
        {

        if(ModelState.IsValid)
            { 
                var user = new IdentityUser() { UserName = Model.Email, Email = Model.Email};// Used to store the New user details in the db by Passing the object of the user Class nad values fetched from the Form
         /*This Stored the Data in the Database Here*/     var result= await userManager.CreateAsync(user, Model.Password); // Using to Sign in the User in the Web Application Here

                if(result.Succeeded)
                {
                     await signIn.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Grid", "Home");
                }
                
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(String.Empty, error.Description); // Used to Store the Errors occured in the Applicayion During New registeration of the user
                }// Model state is used to store the Valiidation Error in it'S container Here
            }


            return View(Model);
        }

       
        [HttpPost]
        public async Task<IActionResult > LogOut()
        {
           await signIn.SignOutAsync();
            return RedirectToAction("Grid","Home");
        }

         
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel Model) // Creating the Action as Async                    
        {

            if (ModelState.IsValid)
            {

                var result = await signIn.PasswordSignInAsync(Model.Email, Model.Password, Model.RememberMe, false); // Using to Sign in the User in the Web Application Here

                if (result.Succeeded) // If Here Succeded Values is False then the Provided Passowrd by the user is Wrong Here 
                {
                    return RedirectToAction("Grid", "Home");
                }
               
                    ModelState.AddModelError(String.Empty, "Invalid Password or Email Id"); 
            

                    // Used to Store the Errors occured in the Applicayion During New registeration of the user
              // Model state is used to store the Valiidation Error in it'S container Here
            }

            return View(Model);// Here if the ModelState is not valid we RE-render the View to the User who is trying to LOgin in the Web application
        }
    }
   
}