using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Cinema
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public string Rate { get; set; }
        public int NumberOfViews { get; set; }
        public byte[] Logo { get; set; }
        public string TrailerLink { get; set; }
        public string[] Author { get; set; }
        public string[] Genre { get; set; }
        public string[] Director { get; set; }
        public string[] Producer { get; set; }
        public string[] Written { get; set; }
        public string[] MainRole { get; set; }
        public string[] Operator { get; set; }
        public string[] Composer { get; set; }
        public string[] ProductionDesigner { get; set; }
        public string[] FilmCompany { get; set; }
        public string Distributor { get; set; }
        public int Duration { get; set; }
        public string CountryDevelop { get; set; }
        public string Year { get; set; }
        public string Status { get; set; }
        public Comment[] Comments { get; set; }
    }
}
