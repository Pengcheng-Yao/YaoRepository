using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordTest.Data;

namespace WordTest.Component.Role
{
    [ViewComponent(Name ="RoleComponent")]
    public class RoleComponent:ViewComponent
    {
        WordTestDbContext _Context;
        public RoleComponent(WordTestDbContext context)
        {
            _Context = context;
        }

        public  IViewComponentResult Invoke(int page, int pagesize)
        {
            List<WordTest.Models.Role> roleList = new List<Models.Role>();
            int count = _Context.Role.Count();//数据总量
            int takeCount = 0;
            if (count > 0)
            {
                if (page == 1)
                {
                    //第一页不使用skip
                    //判断剩下的条数是否够一页
                    takeCount = (count > pagesize) ? pagesize : count;
                    roleList = _Context.Role.Take(takeCount).ToList();
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
                        roleList = _Context.Role.Skip((page - 1) * pagesize).Take(takeCount).ToList();
                    }
                }
                ViewBag.Count = count;
                ViewBag.MaxPage = (count % pagesize == 0) ? count / pagesize : ((count / pagesize) + 1);
                ViewBag.CurrentPage = page;
            }
            return View(roleList);
        }
    }
}
