using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StokTakip.Data.Concrete.EntityFramework.Context;
using StokTakip.Entities.Concrete;
using StokTakip.Entities.Dtos;
using StokTakip.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakip.Mvc.Controllers
{
    public class UserRoleController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;
        private readonly StokTakipContext _context;
        public UserRoleController(UserManager<User> userManager, RoleManager<Role> roleManager, IMapper mapper, StokTakipContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var userRoleList = new List<UserRoleListDto>();
            var users = await _userManager.Users.ToListAsync();
            foreach (var item in users)
            {
                var roles = await _userManager.GetRolesAsync(item);
                if (roles.Count != 0)
                {
                    var stringRole = string.Join(",", roles);
                    var newUserRolelist = new UserRoleListDto
                    {
                        Id = item.Id,
                        UserName = item.UserName,
                        RoleName = stringRole
                    };
                    userRoleList.Add(newUserRolelist);
                }
            }
            return View(new UserRoleListDto
            {
                UserRoleList = userRoleList,
                ResultStatus = ResultStatus.Success
            });
        }
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_UserRoleAddPartial");
        }
        [HttpPost]
        public async Task<IActionResult> Add(UserRoleAddDto userRoleAddDto)
        {
            var userRole = new UserRole();
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.FindByNameAsync(userRoleAddDto.UserName);
                    var role = _roleManager.Roles.Where(x => x.Name == userRoleAddDto.RoleName).FirstOrDefault();
                    userRole.UserId = user.Id;
                    userRole.RoleId = role.Id;
                    var result = await _context.UserRoles.AddAsync(userRole);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return Json(userRole) ;
        }
    }
}
