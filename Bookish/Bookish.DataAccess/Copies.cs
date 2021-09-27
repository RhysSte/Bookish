using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookish.DataAccess
{
    public class Copies
    {
        public int Copy_ID { get; set; }
        public string Who_Borrowed_What { get; set; }
        public int Borrowed_By { get; set; }
        public DateTime Due_Date { get; set; }
    }
}
