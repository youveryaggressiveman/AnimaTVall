using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Serial
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Rate { get; set; }
        public string[] MainRole { get; set; }
        public string[] Composer { get; set; }
        public string[] Producer { get; set; }
        public string[] Operator { get; set; }
        public string LengthEpisodes { get; set; }
        public string[] Genre { get; set; }
        public string TrailerLink { get; set; }
        public string CountryDevelop { get; set; }
        public int CountEpisodes { get; set; }
        public int ActEpisodes { get; set; }
        public int NumberOfViews { get; set; }
        public byte[] Logo { get; set; }
        
        public string Year { get; set; }
        public string[] FilmCompany { get; set; }
        public string Distributor { get; set; }
        public Episode[] Episodes { get; set; }
        public string Status { get; set; }
        public Comment[] Comments { get; set; }
    }
}
