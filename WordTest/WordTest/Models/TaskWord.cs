using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WordTest.Models
{
    [Table("tb_taskword")]
    public class TaskWord:ModelBase
    {
        [Column("w_word")]
        [StringLength(64)]
        public string WordId { get; set; }
        public UnitWord Word { get; set; }

        [Column("w_task")]
        [StringLength(64)]
        public string TaskId { get; set; }
        public Task Task { get; set; }
        [Column("w_status")]
        [StringLength(10)]
        public string Status { get; set; }

    }
}
