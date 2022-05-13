using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using iSchoolWebApp.Models;

namespace iSchoolWebApp.Services
{
    public class GetMinors
    {
        public async Task<List<Minors>> GetAllMinors()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync("minors/", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    //json out of data
                    var rtnResults = JsonConvert.DeserializeObject<Dictionary<string, List<Minors>>>(data);

                    //created dictionary, create list
                    List<Minors> minorsList = new List<Minors>();

                    foreach (KeyValuePair<string, List<Minors>> kvp in rtnResults)
                    {
                        foreach (var item in kvp.Value)
                        {
                            minorsList.Add(item);
                            //get data
                            Console.WriteLine(item.title, item.description,item.courses);
                        }
                    }
                    return minorsList;
                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<Minors> minorsList = new List<Minors>();
                    return minorsList;
                    //return "HttpRequestException";
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<Minors> minorsList = new List<Minors>();
                    return minorsList;
                    //return "Exception"; ;
                }
            }

        }
        public async Task<Courses> GetEveryCourses()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = new HttpResponseMessage();
                    response = await client.GetAsync(
                        "course/", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    //turn it into JSON and cast into <About>
                    var rtnResults = JsonConvert.DeserializeObject<Courses>(data);
                    //don't need - it is already an About object...
                    return rtnResults;

                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    Courses course = new Courses();
                    return course;
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    Courses course = new Courses();
                    return course;
                }
            }

        }

    }
}
