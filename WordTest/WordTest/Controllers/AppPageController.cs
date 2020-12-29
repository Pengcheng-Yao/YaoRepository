using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WordTest.Data;
using WordTest.Models;

namespace WordTest.Controllers
{
    public class AppPageController : Controller
    {
        WordTestDbContext _context;
        public AppPageController(WordTestDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View( _context.AppPage.ToList());
        }


        public async Task<JsonResult> GetPageById(string id)
        {
            if (string.IsNullOrEmpty(id) == false)
            {
                AppPage apppage = await _context.AppPage.FirstOrDefaultAsync(r => r.Id == id);
                if (apppage != null)
                {
                    return Json(apppage);
                }
            }
            return null;
        }

        [HttpPost]
        public async Task<ViewComponentResult> AddPage([Bind("Name,Type,Path")] AppPage apppage)
        {
            if (ModelState.IsValid == true)
            {
                _context.Add(apppage);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    e.ToString();
                }
            }
            return ViewComponent("AppPageComponent", new { page = 1, pagesize = 9 });
        }
        public async Task<ViewComponentResult> UpdatePage([Bind("Name,Type,Path,Id")] AppPage model)
        {
            string retJson = string.Empty;
            AppPage apppage = await _context.AppPage.FirstAsync(r => r.Id == model.Id);
            if (apppage != null)
            {
                apppage.Name = model.Name;
                apppage.Type = model.Type;
                apppage.Path = model.Path;
                if (ModelState.IsValid)
                {
                    _context.AppPage.Update(apppage);
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
            return ViewComponent("AppPageComponent", new { page = 1, pagesize = 9 });
        }



        public async Task<JsonResult> IsAppPageNameRepeat(string Value, string ExceptId)
        {
            bool result = string.IsNullOrEmpty(ExceptId) == true ? await _context.AppPage.AnyAsync(r => r.Name == Value) :
                await _context.AppPage.AnyAsync(r => r.Name == Value && r.Id != ExceptId);
            return Json(new { ret = result });
        }

        public async Task<JsonResult> IsAppPagePathRepeat(string Value, string ExceptId)
        {
            bool result = string.IsNullOrEmpty(ExceptId) == true ? await _context.AppPage.AnyAsync(r => r.Path == Value) :
                 await _context.AppPage.AnyAsync(r => r.Path == Value && r.Id != ExceptId);
            return Json(new { ret = result });
        }

        public async Task<ViewComponentResult> RemoveAppPage(string AppPageId)
        {
            if (string.IsNullOrEmpty(AppPageId) == false)
            {
                List<AppPage> apppagesList = new List<AppPage>();
                string[] ids = AppPageId.Split(',');
                if (ids != null && ids.Length > 0)
                {
                    foreach (var id in ids)
                    {
                        AppPage apppage = _context.AppPage.FirstOrDefault(r => r.Id == id);
                        if (apppage != null)
                        {
                            apppagesList.Add(apppage);
                        }
                    }
                    if (apppagesList.Count > 0)
                    {
                        _context.AppPage.RemoveRange(apppagesList);
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
            return ViewComponent("AppPageComponent", new { page = 1, pagesize = 9 });
        }

        public ViewComponentResult getPageData(int page, int pagesize)
        {
            return ViewComponent("AppPageComponent", new { page = page, pagesize = pagesize });
        }
    }
}
