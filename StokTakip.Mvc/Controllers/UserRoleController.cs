using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public UserRoleController(UserManager<User> userManager, RoleManager<Role> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
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
        //[HttpPost]
        //public async Task<IActionResult> Add(UserRoleAddDto userRoleAddDto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = _mapper.Map<UserRole>(userRoleAddDto);
        //        var result = await .CreateAsync(user, userAddDto.Password);
        //        if (result.Succeeded)
        //        {
        //            var userAddAjaxModel = JsonSerializer.Serialize(new UserAddAjaxViewModel
        //            {
        //                UserDto = new UserDto
        //                {
        //                    ResultStatus = ResultStatus.Success,
        //                    Message = $"{user.UserName} adlı kullanıcı başarıyla eklenmiştir.",
        //                    User = user
        //                },
        //                UserAddPartial = await this.RenderViewToStringAsync("_UserAddPartial", userAddDto)
        //            });
        //            return Json(userAddAjaxModel);
        //        }
        //        else
        //        {
        //            foreach (var error in result.Errors)
        //            {
        //                ModelState.AddModelError("", error.Description);
        //            }
        //            var userAddAjaxErrorModel = JsonSerializer.Serialize(new UserAddAjaxViewModel
        //            {
        //                UserAddDto = userAddDto,
        //                UserAddPartial = await this.RenderViewToStringAsync("_UserAddPartial", userAddDto)
        //            });
        //            return Json(userAddAjaxErrorModel);
        //        }
        //    }
        //    var userAddAjaxModelStateModel = JsonSerializer.Serialize(new UserAddAjaxViewModel
        //    {
        //        UserAddDto = userAddDto,
        //        UserAddPartial = await this.RenderViewToStringAsync("_UserAddPartial", userAddDto)
        //    });
        //    return Json(userAddAjaxModelStateModel);
        //}
    }
}
