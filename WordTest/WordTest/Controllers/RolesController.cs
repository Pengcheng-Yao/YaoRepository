using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WordTest.Component.Role;
using WordTest.Data;
using WordTest.Models;

namespace WordTest.Controllers
{
    public class RolesController : Controller
    {
        private readonly WordTestDbContext _context;

        public RolesController(WordTestDbContext context)
        {
            _context = context;
        }

        // GET: Roles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Role.ToListAsync());
        }

        public async Task<JsonResult> GetRoleById(string id)
        {
            if (string.IsNullOrEmpty(id) == false)
            {
                Role role = await _context.Role.FirstOrDefaultAsync(r => r.Id == id);
                if (role != null)
                {
                    return Json(role);
                }
            }
            return null;
        }

        [HttpPost]
        public async Task<ViewComponentResult> AddRole([Bind("Code,Name")] Role role)
        {
            if (ModelState.IsValid == true)
            {
                _context.Add(role);
                try
                {
                  await  _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    e.ToString();
                }
            }
            return  ViewComponent("RoleComponent", new { page = 1, pagesize = 9 });
        }

        public async Task<ViewComponentResult> UpdateRole([Bind("Code,Name,Id")] Role model)
        {
            string retJson = string.Empty;
            Role role = await _context.Role.FirstAsync(r => r.Id == model.Id);
            if (role != null)
            {
                role.Name = model.Name;
                role.Code = model.Code;
                if (ModelState.IsValid)
                {
                    _context.Role.Update(role);
                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception e)
                    {
                        e.ToString();
                    }
                }
            }
            return ViewComponent("RoleComponent", new { page = 1, pagesize = 9 });
        }

        public  async Task<JsonResult> IsRoleCodeRepeat(string Value, string ExceptId)
        {
            bool result = string.IsNullOrEmpty(ExceptId) == true ? await _context.Role.AnyAsync(r => r.Code == Value) :
                await _context.Role.AnyAsync(r=>r.Code == Value && r.Id != ExceptId) ;
            return Json(new {ret = result });
        }

        public async Task<JsonResult> IsRoleNameRepeat(string Value, string ExceptId)
        {
            bool result = string.IsNullOrEmpty(ExceptId) == true ? await _context.Role.AnyAsync(r => r.Name == Value) :
                 await _context.Role.AnyAsync(r => r.Name == Value && r.Id != ExceptId);
            return Json(new { ret = result });
        }

        public async Task<ViewComponentResult> RemoveRole(string RoleId)
        {
            if (string.IsNullOrEmpty(RoleId) == false)
            {
                List<Role> rolesList = new List<Role>();
                string[] ids = RoleId.Split(',');
                if (ids != null && ids.Length > 0)
                {
                    foreach (var id in ids)
                    {
                        Role role = _context.Role.FirstOrDefault(r => r.Id == id);
                        if (role != null)
                        {
                            rolesList.Add(role);
                        }
                    }
                    if (rolesList.Count > 0)
                    {
                        _context.Role.RemoveRange(rolesList);
                        try
                        {
                            await _context.SaveChangesAsync();
                        }
                        catch (Exception e)
                        {
                            e.ToString();
                        }
                    }
                }
            }
            return ViewComponent("RoleComponent", new { page = 1, pagesize = 9 });
        }

        public  ViewComponentResult getPageData(int page,int pagesize)
        {
            return  ViewComponent("RoleComponent",new {page =page ,pagesize= pagesize });
        }
    }
}
