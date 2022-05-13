using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iSchoolWebApp.Models
{
    public class Degree
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Undergraduate
        {
            public string degreeName { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public List<string> concentrations { get; set; }
        }

        public class Graduate
        {
            public string degreeName { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public List<string> concentrations { get; set; }
            public List<string> availableCertificates { get; set; }
        }

        public class DegreeRootModel
        {
            public List<Undergraduate> undergraduate { get; set; }
            public List<Graduate> graduate { get; set; }
            //other stuff I might want to add - like the title of the page
            public string Title { get; set; }
        }

    }
}