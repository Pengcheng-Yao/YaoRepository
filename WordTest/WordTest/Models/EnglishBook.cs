using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WordTest.Models
{
    [Table("tb_englishbook")]

    public class EnglishBook:ModelBase
    {
        [StringLength(20)]
        [Column("w_name")]
        public string Name { get; set; }
    }
}
