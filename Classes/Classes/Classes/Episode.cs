using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Episode
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string[] Director { get; set; }
        public string[] Author { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string Description { get; set; }
        public int NumberOfViews { get; set; }
        public int Season { get; set; }
        public string Duration { get; set; } 
        public string Status { get; set; }
        public Comment[] Comments { get; set; }
    }
}
