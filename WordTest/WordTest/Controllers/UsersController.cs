using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WordTest.Data;
using WordTest.Models;

namespace WordTest.Controllers
{
    public class UsersController : Controller
    {
        private readonly WordTestDbContext _context;

        public UsersController(WordTestDbContext context)
        {
            _context = context;
        }

        // GET: Users
        public IActionResult Index()
        {
            return View();
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .Include(u => u.UserRole)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        public async Task<JsonResult> GetUserById(string id)
        {
            if (string.IsNullOrEmpty(id) == false)
            {
                User user = await _context.User.FirstOrDefaultAsync(r => r.Id == id);
                if (user != null)
                {
                    return Json(user);
                }
            }
            return null;
        }

        public async Task<ViewComponentResult> AddUser(UserViewModel model)
        {
            string retJson = string.Empty;
            User user = new User();
            user.Name = model.Name;
            user.Gender = (Gender)Enum.Parse(typeof(Gender), model.Gender);
            user.Acc = model.Acc;
            user.Pwd = model.Pwd;
            user.Age = model.Age;
            _context.User.Add(user);
            string errorMsg = string.Empty;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return ViewComponent("UserInfo", new { page = 1, pagesize = 9 });
        }

        public async Task<ViewComponentResult> UpdateUser([Bind("Name,Gender,Age,Acc,Pwd,Id")] User model)
        {
            string retJson = string.Empty;
            User user = await _context.User.FirstAsync(r => r.Id == model.Id);
            if (user != null)
            {
                user.Name = model.Name;
                user.Gender = model.Gender;
                user.Acc = model.Acc;
                user.Pwd = model.Pwd;
                user.Age = model.Age;
                if (ModelState.IsValid)
                {
                    _context.User.Update(user);
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
            return ViewComponent("UserInfo", new { page = 1, pagesize = 9 });
        }

        public async Task<ViewComponentResult> RemoveUser(string UserId)
        {
            List<User> userList = new List<User>();
            string[] ids = UserId.Split(',');
            if (ids != null && ids.Length > 0)
            {
                foreach (var id in ids)
                {
                    User user = _context.User.FirstOrDefault(r => r.Id == id);
                    if (user != null)
                    {
                        userList.Add(user);
                    }
                }
                if (userList.Count > 0)
                {
                    _context.User.RemoveRange(userList);
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
            return ViewComponent("UserInfo", new { page = 1, pagesize = 9 });
        }


        [HttpGet]
        public async Task<JsonResult> IsAccRepeat(string Value, string ExceptId)
        {
            var result = (string.IsNullOrEmpty(ExceptId)) ? await _context.User.AnyAsync(u => u.Acc == Value) :
               await _context.User.AnyAsync(u => u.Acc == Value && u.Id != ExceptId);
            return Json(new { ret = result });
        }

        [HttpGet]
        //检查用户名是否重复
        public async Task<JsonResult> IsNickRepeat(string Value, string ExceptId)
        {
            var result = (string.IsNullOrEmpty(ExceptId)) ? await _context.User.AnyAsync(u => u.Name == Value) :
               await _context.User.AnyAsync(u => u.Name == Value && u.Id != ExceptId);
            return Json(new { ret = result });
        }

        public ViewComponentResult getTable(int page, int pagesize)
        {
            return ViewComponent("UserInfo", new { page = page, pagesize = pagesize });
        }
    }
}
