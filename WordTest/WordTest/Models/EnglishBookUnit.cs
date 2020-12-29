using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WordTest.Models
{
    [Table("tb_englishbookunit")]
    public class EnglishBookUnit:ModelBase
    {
        public EnglishBook Book { get; set; }
        [StringLength(20)]
        [Column("w_name")]
        public string Name { get; set; }
        [Column("w_book")]
        public string BookId { get; set; }
    }
}
