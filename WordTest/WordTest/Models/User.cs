using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WordTest.Models
{
    [Table("tb_user")]
    public class User:ModelBase
    {
        [StringLength(20)]
        [Column("w_name")]
        [DisplayName("姓名")]
        public string Name { get; set; }
        [Column("w_gender")]
        [DisplayName("性别")]

        public Gender Gender { get; set; }
        [Column("w_age")]
        [DisplayName("年龄")]
        public int Age { get; set; }
        [Column("w_acc")]
        [DisplayName("账号")]

        public string Acc { get; set; }
        [Column("w_pwd")]
        [DisplayName("密码")]

        public string Pwd { get; set; }
        [Column("w_userrole")]
        [StringLength(64)]
        public string RoleId { get; set; }
        [DisplayName("角色")]
        public virtual Role UserRole { get; set; }

    }
}
