using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http; //added
using System.Net.Http.Headers; //added
using System.Threading.Tasks;
using iSchoolWebApp.Models; //added
using Newtonsoft.Json; //added

namespace iSchoolWebApp.Services
{
    public class GetFaculty
    {
        public async Task<List<Faculty>> getAllFaculty()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync("people/faculty", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    //different/new code here...
                    //make json out of data
                    var rtnResults = JsonConvert.DeserializeObject<Dictionary<string, List<Faculty>>>(data);

                    //created dictionary, now create list
                    List<Faculty> facultyList = new List<Faculty>();

                    //iterate through the data in rtnResults
                    //how many times do i go through this loop? Once 
                    foreach (KeyValuePair<string, List<Faculty>> kvp in rtnResults)
                    {
                        //this goes through until it reaches the end of the faculty list (last faculty member)
                        foreach (var item in kvp.Value)
                        {
                            facultyList.Add(item);
                            //lets see some data
                            Console.WriteLine(item.username);
                        }
                    }
                    return facultyList;
                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<Faculty> facultyList = new List<Faculty>();
                    return facultyList;
                    //return "HttpRequestException";
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<Faculty> facultyList = new List<Faculty>();
                    return facultyList;
                    //return "Exception"; ;
                }

            }
        }
        public async Task<List<Staff>> getAllStaff()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync("people/staff", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    //different/new code here...
                    //make json out of data
                    var rtnResults = JsonConvert.DeserializeObject<Dictionary<string, List<Staff>>>(data);

                    //created dictionary, now create list
                    List<Staff> staffList = new List<Staff>();

                    //iterate through the data in rtnResults
                    //how many times do i go through this loop? Once 
                    foreach (KeyValuePair<string, List<Staff>> kvp in rtnResults)
                    {
                        //this goes through until it reaches the end of the staff list (last staff member)
                        foreach (var item in kvp.Value)
                        {
                            staffList.Add(item);
                            //lets see some data
                            Console.WriteLine(item.username);
                        }
                    }
                    return staffList;
                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<Staff> staffList = new List<Staff>();
                    return staffList;
                    //return "HttpRequestException";
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<Staff> staffList = new List<Staff>();
                    return staffList;
                    //return "Exception"; ;
                }

            }
        }
    }
}
