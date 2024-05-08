using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_2
{
    internal class Course
    {
        public int ID {  get; set; }
        public string title { get; set; }
        public DateTime startdate { get; set; }
        public Course() { }
        public Course(int ID, string title, DateTime startdate) {
            this.title = title;
            this.startdate = startdate;
            this.ID = ID;
        }
    }
}
