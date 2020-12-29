using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WordTest.Models
{
    [Table("tb_task")]
    public class Task:ModelBase
    {
        [Column("w_name")]
        [StringLength(20)]
        public string Name { get; set; }
        [Column("w_taskcreator")]
        [StringLength(64)]
        public string TaskCreatorId { get; set; }
        public User TaskCreator { get; set; }
        [Column("w_aswer")]
        [StringLength(64)]
        public string AswerId { get; set; }
        public User Aswer { get; set; }
        [Column("w_grade")]
        public int Grade { get; set; }
        [Column("w_status")]
        [StringLength(10)]
        public TaskStatus Status { get; set; }
        [Column("w_rightcount")]
        public int rightCount { get; set; }
        [Column("w_errorcount")]
        public int ErrorCount { get; set; }
        [Column("w_rate")]
        public float Rate { get; set; }
    }
}
