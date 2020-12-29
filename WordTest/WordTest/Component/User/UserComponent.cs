using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WordTest.Data;
using WordTest.Models;

namespace WordTest.Component.User
{
    [ViewComponentAttribute(Name ="UserInfo")]
    public class UserInfoComponent:ViewComponent
    {
        WordTestDbContext _Context;
        public UserInfoComponent(WordTestDbContext Context)
        {
            _Context = Context;
        }

        public IViewComponentResult Invoke(int page, int pagesize)
        {
            List<WordTest.Models.User> userList =new List<Models.User>();
            int count = _Context.User.Count();//数据总量
            int takeCount = 0;
            if (count > 0)
            {
                if (page == 1)
                {
                    //第一页不使用skip
                    //判断剩下的条数是否够一页
                    takeCount = (count > pagesize) ? pagesize : count;
                    userList = _Context.User.Take(takeCount).ToList();
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
                        userList = _Context.User.Skip((page - 1) * pagesize).Take(takeCount).ToList();
                    }
                }
                ViewBag.Count = count;
                ViewBag.MaxPage = (count%pagesize ==0)? count / pagesize:((count / pagesize)+1);
                ViewBag.CurrentPage = page;
            }
            return View(userList);
        }
    }
}
