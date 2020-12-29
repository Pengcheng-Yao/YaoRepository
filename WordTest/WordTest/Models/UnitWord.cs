using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WordTest.Models
{
    [Table("tb_unitword")]
    public class UnitWord : ModelBase
    {
        public EnglishBookUnit Unit { get; set; }
        [StringLength(64)]
        [Column("w_unit")]
        public string UnitId { get; set; }
        [StringLength(20)]
        [Column("w_name")]
        public string Name { get; set; }
        [StringLength(20)]
        [Column("w_Soundname")]
        public string SoundName { get; set; }
        [StringLength(20)]
        [Column("w_soundpath")]
        public string SoundPath { get; set; }
    }
}
