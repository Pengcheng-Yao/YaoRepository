using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WordTest.Models
{
    [Table("tb_rolepage")]

    public class RolePage:ModelBase
    {
        [Column("w_role")]
        [StringLength(64)]
        public string RoleId { get; set; }
        public Role Role { get; set; }
        [Column("w_apppage")]
        [StringLength(64)]
        public string AppPageId { get; set; }
        public AppPage AppPage { get; set; }
    }
}
