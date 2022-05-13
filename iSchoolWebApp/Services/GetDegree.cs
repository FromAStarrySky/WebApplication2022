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
    public class GetDegree
    {
        public async Task<List<Degree.Undergraduate>> getAllUnderDegree()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync("degrees/undergraduate", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    //different/new code here...
                    //make json out of data
                    var rtnResults = JsonConvert.DeserializeObject<Dictionary<string, List<Degree.Undergraduate>>>(data);

                    //created dictionary, now create list
                    List<Degree.Undergraduate> degList = new List<Degree.Undergraduate>();

                    //iterate through the data in rtnResults
                    //how many times do i go through this loop? Once 
                    foreach (KeyValuePair<string, List<Degree.Undergraduate>> kvp in rtnResults)
                    {
                        //this goes through until it reaches the end of the faculty list (last faculty member)
                        foreach (var item in kvp.Value)
                        {
                            degList.Add(item);
                            //lets see some data
                            Console.WriteLine(item.title, item.description, item.concentrations);
                        }
                    }
                    return degList;
                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<Degree.Undergraduate> degList = new List<Degree.Undergraduate>();
                    return degList;
                    //return "HttpRequestException";
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<Degree.Undergraduate> degList = new List<Degree.Undergraduate>();
                    return degList;
                    //return "Exception"; ;
                }

            }
        }
        public async Task<List<Degree.Graduate>> getAllGradDegree()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync("degrees/graduate", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    //different/new code here...
                    //make json out of data
                    var rtnResults1 = JsonConvert.DeserializeObject<Dictionary<string, List<Degree.Graduate>>>(data);

                    //created dictionary, now create list
                    List<Degree.Graduate> degGradList = new List<Degree.Graduate>();

                    //iterate through the data in rtnResults
                    //how many times do i go through this loop? Once 
                    foreach (KeyValuePair<string, List<Degree.Graduate>> kvp1 in rtnResults1)
                    {
                        //this goes through until it reaches the end of the faculty list (last faculty member)
                        foreach (var item in kvp1.Value)
                        {
                            degGradList.Add(item);
                            //lets see some data
                            //Console.WriteLine(item.title, item.description, item.concentrations);
                        }
                    }
                    return degGradList;
                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<Degree.Graduate> degGradList = new List<Degree.Graduate>();
                    return degGradList;
                    //return "HttpRequestException";
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<Degree.Graduate> degGradList = new List<Degree.Graduate>();
                    return degGradList;
                    //return "Exception"; ;
                }

            }
        }
    }
}

