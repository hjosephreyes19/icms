using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ICMS.Web.Attribute;
using ICMS.Web.Models.Account;
using ICMS.Entities.Main;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using ICMS.Service.Interface;
using AutoMapper;
using ICMS.Web.Extension;
using Microsoft.AspNetCore.Http;
using ICMS.Commons.Helper;

namespace ICMS.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly ILogger logger;
        private readonly IAccountService accountService;
        private readonly IMapper mapper;
        private readonly IQueryService queryService;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager,
            ILogger<AccountController> logger, IAccountService accountService, IQueryService queryService)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.logger = logger;
            this.accountService = accountService;
            this.queryService = queryService;
            this.mapper = this.GetMapper();
        }
        
        [HttpGet]
        [ServiceFilter(typeof(SharedDataAttribute))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ServiceFilter(typeof(SharedDataAttribute))]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AccountLoginViewModel model)
        {
            try
            {
                if (String.IsNullOrEmpty(model.userName) || String.IsNullOrEmpty(model.password))
                {
                    ModelState.AddModelError(string.Empty, "Invalid Credentials");
                    return View(model);
                }

                if (ModelState.IsValid)
                {
                    var user = await userManager.FindByNameAsync(model.userName);
                    if (user != null)
                    {
                        ViewBag.userName = user.UserName;
                        var user2 = await userManager.GetUserAsync(User);
                        if (!await userManager.IsEmailConfirmedAsync(user))
                        {
                            // TODO: create a separate action for resending the confirmation token
                            // string callbackUrl = await SendEmailConfirmationTokenAsync(user.Id, "Confirm your account-Resend");

                            // Uncomment to debug locally  
                            // ViewBag.Link = callbackUrl;
                            // ViewBag.errorMessage = "You must have a confirmed email to log on. "
                            //                     + "The confirmation token has been resent to your email account.";

                            ModelState.AddModelError(string.Empty, "You must have a confirmed email to log on.");
                            return View();
                        }
                        else
                        {
                            bool isSucceeded = false;

                            // This doesn't count login failures towards account lockout
                            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                            var result = await signInManager.PasswordSignInAsync(model.userName, model.password, true, lockoutOnFailure: false);
                            isSucceeded = result.Succeeded;

                            if (isSucceeded)
                            {
                                var role = await userManager.GetRolesAsync(user);
                                var listOfModule = await queryService.ReadModule(role.First());

                                HttpContext.Session.SetString(UserSessionHelper.USER_NAME, user.UserName);
                                HttpContext.Session.SetObjectAsJson(UserSessionHelper.USER, user);
                                HttpContext.Session.SetString(UserSessionHelper.USER_NAME, user.UserName);
                                HttpContext.Session.SetString(UserSessionHelper.ROLE, role.First());
                                HttpContext.Session.SetObjectAsJson(UserSessionHelper.MODULES, listOfModule);

                                return RedirectToAction("index", "account");
                            }

                            // somethingi is wrong if code reach here
                            ModelState.AddModelError(string.Empty, "Invalid Credentials");
                            return View(model);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid Credentials");
                        return View(model);
                    }
                }
            }
            catch (Exception e)
            {

                throw;
            }
            

            // If we got this far, something failed, redisplay form
            return View();
        }

        [HttpGet]
        [ServiceFilter(typeof(SharedDataAttribute))]
        public IActionResult Register()
        {
            return View();
        }
    }
}