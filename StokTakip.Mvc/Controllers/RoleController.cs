using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StokTakip.Entities.Concrete;
using StokTakip.Entities.Dtos;
using StokTakip.Mvc.Models;
using StokTakip.Shared.Utilities.Extensions;
using StokTakip.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace StokTakip.Mvc.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;
        public RoleController(RoleManager<Role> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(new RoleListDto
            {
                Roles = roles,
                ResultStatus = ResultStatus.Success
            });
        }
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_RoleAddPArtial");
        }
        [HttpPost]
        public async Task<IActionResult> Add(RoleAddDto roleAddDto)
        {
            if (ModelState.IsValid)
            {
                var role = _mapper.Map<Role>(roleAddDto);
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    var roleAddAjaxModel = JsonSerializer.Serialize(new RoleAddAjaxViewModel
                    {
                        RoleDto = new RoleDto
                        {
                            ResultStatus = ResultStatus.Success,
                            Message = $"{roleAddDto.Name} adlı rol başarıyla eklenmiştir.",
                            Role = role
                        },
                        RoleAddPartial = await this.RenderViewToStringAsync("_RoleAddPartial", roleAddDto)
                    });
                    return Json(roleAddAjaxModel);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    var roleAddAjaxErrorModel = JsonSerializer.Serialize(new RoleAddAjaxViewModel
                    {
                        RoleAddDto = roleAddDto,
                        RoleAddPartial = await this.RenderViewToStringAsync("_RoleAddPartial", roleAddDto)
                    });
                    return Json(roleAddAjaxErrorModel);
                }
            }
            var roleAddAjaxModelStateErrorModel = JsonSerializer.Serialize(new RoleAddAjaxViewModel
            {
                RoleAddDto = roleAddDto,
                RoleAddPartial = await this.RenderViewToStringAsync("_RoleAddPartial", roleAddDto)
            });
            return Json(roleAddAjaxModelStateErrorModel);
        }
        [HttpGet]
        public async Task<PartialViewResult> Update(Guid roleId)
        {
            var role = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == roleId);
            var roleUpdateDto = _mapper.Map<RoleUpdateDto>(role);
            return PartialView("_RoleUpdatePartial", roleUpdateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(RoleUpdateDto roleUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var oldRole = await _roleManager.FindByIdAsync(roleUpdateDto.Id.ToString());
                var updatedRole = _mapper.Map<RoleUpdateDto, Role>(roleUpdateDto, oldRole);
                var result = await _roleManager.UpdateAsync(updatedRole);
                if (result.Succeeded)
                {
                    var roleUpdateViewModel = JsonSerializer.Serialize(new RoleUpdateAjaxViewModel
                    {
                        RoleDto = new RoleDto
                        {
                            ResultStatus = ResultStatus.Success,
                            Message = $"{updatedRole.Name} adlı rol başarıyla güncellenmiştir.",
                            Role = updatedRole
                        },
                        RoleUpdatePartial = await this.RenderViewToStringAsync("_RoleUpdatePartial", roleUpdateDto)
                    });
                    return Json(roleUpdateViewModel);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    var roleUpdateErrorViewModel = JsonSerializer.Serialize(new RoleUpdateAjaxViewModel
                    {
                        RoleUpdateDto = roleUpdateDto,
                        RoleUpdatePartial = await this.RenderViewToStringAsync("_RoleUpdatePartial", roleUpdateDto)
                    });
                    return Json(roleUpdateErrorViewModel);
                }
            }
            else
            {
                var roleUpdateErrorModelStateViewModel = JsonSerializer.Serialize(new RoleUpdateAjaxViewModel
                {
                    RoleUpdateDto = roleUpdateDto,
                    RoleUpdatePartial = await this.RenderViewToStringAsync("_RoleUpdatePartial", roleUpdateDto)
                });
                return Json(roleUpdateErrorModelStateViewModel);
            }
        }
        public async Task<IActionResult> Delete(Guid roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                var deletedRole = JsonSerializer.Serialize(new RoleDto
                {
                    ResultStatus = ResultStatus.Success,
                    Message = "Kullanıcı başarıyla silinmiştir.",
                    Role = role
                });
                return Json(deletedRole);
            }
            else
            {
                string errorMessages = String.Empty;
                foreach (var error in result.Errors)
                {
                    errorMessages = $"*{error.Description}\n";
                }
                var deletedRoleErrorModel = JsonSerializer.Serialize(new RoleDto
                {
                    ResultStatus = ResultStatus.Error,
                    Message = $"Silme işlemi gerçekleştirilirken hata oluştu. \n{errorMessages}",
                    Role = role
                });
                return Json(deletedRoleErrorModel);
            }
        }
    }
}
