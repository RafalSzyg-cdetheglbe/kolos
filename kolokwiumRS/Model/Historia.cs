using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Model
{
    public class Historia
    {
        [Key]
        public int ID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public int? GroupID { get; set; }
        [ForeignKey("GroupID")]
        public Grupa Grupa { get; set; }

        public string TypAkcji { get; set; }
        public DateTime Data { get; set; }
    }
}
