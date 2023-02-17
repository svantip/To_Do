using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Do
{
    class Task
    {
        public int TaskID { get; set; }
        public bool taskChecked { get; set; }   
        public string taskName { get; set; }
        public string? taskDescription { get; set; }
        public string taskCategory { get; set; }
    }
}
