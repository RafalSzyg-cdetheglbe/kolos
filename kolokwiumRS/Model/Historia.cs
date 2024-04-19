using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Model
{
    public class Historia
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? GroupID { get; set; }
        public Group Group { get; set; }
        public string ActionType { get; set; }
        public DateTime Date { get; set; }
    }
}
