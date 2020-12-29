using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WordTest.Models
{
    public class ModelBase
    {
        [Key]
        [Column("w_id")]
        [StringLength(64)]
        public string Id { get; set; }
        [Column("w_inserttime")]
        public DateTime Inserttime { get; set; }
        [Column("w_updatetime")]
        public DateTime UpdateTime { get; set; }
        [Column("w_creator")]
        [StringLength(32)]
        public string Creator { get; set; }
        [Column("w_operator")]
        [StringLength(32)]
        public string Operator { get; set; }
    }
}
