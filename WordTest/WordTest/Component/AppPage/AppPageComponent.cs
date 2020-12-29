using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordTest.Data;

namespace WordTest.Component.AppPage
{
    [ViewComponent(Name ="AppPageComponent")]
    public class AppPageComponent:ViewComponent
    {
        WordTestDbContext _context;
        public AppPageComponent(WordTestDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke(int page,int pagesize)
        {
            List<WordTest.Models.AppPage> pageList = new List<Models.AppPage>();
            int count = _context.AppPage.Count();//数据总量
            int takeCount = 0;
            if (count > 0)
            {
                if (page == 1)
                {
                    //第一页不使用skip
                    //判断剩下的条数是否够一页
                    takeCount = (count > pagesize) ? pagesize : count;
                    pageList = _context.AppPage.Take(takeCount).ToList();
                }
                else
                {
                    //其它页使用skip
                    int skipCount = (page - 1) * pagesize;//要跳过的数量
                    int afterSkipedCount = (count - ((page - 1) * pagesize));//跳过后可以take的数据数量
                    //判断跳过的条数是否超过总数量
                    if (afterSkipedCount > 0)
                    {//跳过的条数没有超过总数量
                        takeCount = (afterSkipedCount >= pagesize) ? pagesize : afterSkipedCount;
                        pageList = _context.AppPage.Skip((page - 1) * pagesize).Take(takeCount).ToList();
                    }
                }
                ViewBag.Count = count;
                ViewBag.MaxPage = (count % pagesize == 0) ? count / pagesize : ((count / pagesize) + 1);
                ViewBag.CurrentPage = page;
            }
            return  View(pageList);
        }

    }
}
