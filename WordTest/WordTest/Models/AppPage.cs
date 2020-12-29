using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WordTest.Models
{
    [Table("tb_apppage")]
    public class AppPage:ModelBase
    {
        [Display(Name="页面名称")]
        [StringLength(20)]
        [Column("w_name")]
        public string Name { get; set; }
        [Column("w_type")]
        [StringLength(20)]
        [Display(Name ="页面类型")]
        public string Type { get; set; }
        [Column("w_path")]
        [StringLength(100)]
        [Display(Name="页面路径")]
        public string Path { get; set; }
    }
}
