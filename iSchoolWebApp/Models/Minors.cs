using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iSchoolWebApp.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Minors
    {
        public string name { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public List<string> courses { get; set; }
        public string note { get; set; }
    }

    public class Courses
    {
        public string courseID { get; set; }
        public string title { get; set; }
        public string description { get; set; }

    }

    public class MinorsRootModel
    {
        public List<Minors> UgMinors { get; set; }
        public Courses Courses { get; set; }

        //add Title that will go into HTML title
        public string Title { get; set; }
    }

}


