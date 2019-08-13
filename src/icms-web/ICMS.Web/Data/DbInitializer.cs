using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using ICMS.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICMS.Entities.Base;
using ICMS.Entities.Main;
using ICMS.Service;
using static ICMS.Commons.Enum.ICMSEnum;
using System.IO;
using ICMS.DTO.Account;
using ICMS.DTO.Module;
using Newtonsoft.Json;
using ICMS.Service.Implementation;
using ICMS.Service.Interface;

namespace ICMS.Web.Data
{
    public static class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext context, RoleManager<IdentityRole<int>> roleManager,
            UserManager<User> userManager, IHostingEnvironment env, IAccountService userService, ISeedService seedService)
        {
            //to make sure that the database is created, if not, it will be created
            context.Database.EnsureCreated();

            string adminRole = nameof(Role.ADMINISTRATOR);
            string userRole = nameof(Role.USER);

            if (await roleManager.FindByNameAsync(adminRole) == null)
            {
                var ir = await roleManager.CreateAsync(new IdentityRole<int>(adminRole));
            }

            if (await roleManager.FindByNameAsync(userRole) == null)
            {
                var ir = await roleManager.CreateAsync(new IdentityRole<int>(userRole));
            }

            var admin = await userManager.GetUsersInRoleAsync(adminRole);
            var adminUser = string.Empty;

            var dataPath = Path.Combine(env.ContentRootPath, "Data", "seed");
            if (Directory.Exists(dataPath))
            {
                var adminSettings = Path.Combine(dataPath, "adminsettings.json");
                if (File.Exists(adminSettings))
                {
                    AddAccountDTO sa = JsonConvert.DeserializeObject<AddAccountDTO>(System.IO.File.ReadAllText(adminSettings));

                    if (admin.Count() == 0)
                    {
                        var addAdmin = new User { UserName = sa.userName, Email = sa.email, firstName = sa.firstName, lastName = sa.lastName, EmailConfirmed = true };
                        var result = await userManager.CreateAsync(addAdmin, sa.password);
                        if (result.Succeeded)
                        {
                            var addrole = await userManager.AddToRoleAsync(addAdmin, adminRole);
                            //File.Delete(adminSettings);
                        }
                        adminUser = sa.userName;
                    }
                    else
                    {
                        adminUser = admin.FirstOrDefault().UserName;
                    }
                }
            }

            //
            var module = Path.Combine(dataPath, "module.json");
            if (File.Exists(module))
            {
                List<AddModuleDTO> dto = JsonConvert.DeserializeObject<List<AddModuleDTO>>(System.IO.File.ReadAllText(module));
                var result = await seedService.AddModule(dto, adminUser);
                if (result.success)
                {
                    //File.Delete(modules);
                }
            }
        }
    }
}
