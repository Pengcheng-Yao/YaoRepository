using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WordTest.Models
{
    public class UserViewModel {
        
       
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Acc { get; set; }
        public string Pwd { get; set; }
        public string RoleId { get; set; }
    }
}
