using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WordTest.Models
{
    [Table("tb_role")]
    public class Role:ModelBase
    {
        [Display(Name ="角色名称")]
        [StringLength(20)]
        [Column("w_name")]
        public string Name { get; set; }
        [StringLength(10)]
        [Column("w_code")]
        [Display(Name = "角色代码")]

        public string Code { get; set; }

    }
}
