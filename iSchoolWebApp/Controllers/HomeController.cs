using iSchoolWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using iSchoolWebApp.Services;

namespace iSchoolWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly GetEmploymentReceived _receiveEmployment;
        //private readonly GetCoopReceived _receiveCoop;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        
        }
        /*public HomeController(GetEmploymentReceived getEmployment, GetCoopReceived getCoop)
        {
            _receiveCoop = getCoop;
            _receiveEmployment = getEmployment;
        }*/

        public IActionResult Index()
        {
            return View();
        }
        //get About page
        public async Task<IActionResult> About()
        {
            //load the data...
            var getAbout = new GetAbout();
            //tell the instance to go get the data...
            var loadedAbout = await getAbout.getAb();
            //take the loadedAbout and populate the model
            var aboutModel = new AboutRootModel()
            {
                Title = "About our iSchool",
                About = loadedAbout
            };
            //call the view
            return View(aboutModel);
        }
        //get Faculty page
        public async Task<IActionResult> Faculty()
        {
            //load the data
            var getAllFac = new GetFaculty();
            var getAllSta = new GetFaculty();
            //get data
            var loadedFac = await getAllFac.getAllFaculty();
            var loadedSta = await getAllSta.getAllStaff();
            //populate model
            var facultyModel = new FacultyRootModel()
            {
                Title = "iSchool Faculty",
                faculty = loadedFac.ToList(),
                staff = loadedSta.ToList()
            };
            //call/send the view
            return View(facultyModel);
        }
        //get Degree
        public async Task<IActionResult> Degree()
        {
            //load the data
            var getUnder = new GetDegree();
            var getGrad = new GetDegree();
            //get data
            var loadedUnder = await getUnder.getAllUnderDegree();
            var loadedGrad = await getGrad.getAllGradDegree();
            //populate model
            var degreeModel = new Degree.DegreeRootModel()
            {
                Title = "Degree Programs",
                undergraduate = loadedUnder.ToList(),
                graduate = loadedGrad.ToList()
            };
            //call/send the 
            return View(degreeModel);
        }
        //get Minors
        public async Task<IActionResult> Minors()
        {
            //load the data
            var getAllMin =new GetMinors();
            var getAllCourses = new GetMinors();
            //get data
            var loadedMinors = await getAllMin.GetAllMinors();
            var loadedCourses = await getAllCourses.GetEveryCourses();
            //populate model
            var minorsModel = new MinorsRootModel()
            {
                Title = "Minors",
                UgMinors = loadedMinors.ToList(),
                Courses = loadedCourses

            };
            //call/send the view
            return View(minorsModel);
        }
        //get Tables (Employment and Co-Op)
        public async Task<IActionResult> Employment()
        {
            var getEmploy = new GetEmployment();
            var getCoop = new GetEmployment();
            var getCont = new GetEmployment();
            //get data
            var loadedEmp = await getEmploy.getAllEmployers();
            var loadedCoo = await getCoop.getAllCoops();
            var loadedCon = await getCont.getContent();
            //populate model
            var tablesAll = new Employment.EmployRoot()
            {
                EmploymentTableInfo = loadedEmp.ToList(),
                CoopTableInfo = loadedCoo.ToList(),
                contentInfo = loadedCon.ToList()
            };
            //call/send the view
            return View(tablesAll);
        }
        public async Task<IActionResult> Resources()
        {
            var getStudyA = new GetResources();
            //get data
            var loadedStudyA = await getStudyA.getStudyAbroad();
            //populate model
            var everyResources = new Resources.ResourcesRoot()
            {
                studyAbroadThing = loadedStudyA.ToList()
            };
            return View(everyResources);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
