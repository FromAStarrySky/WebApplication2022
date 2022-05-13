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
    public class GetEmployment
    {
        public async Task<List<Employment.ProfessionalEmploymentInformation>> getAllEmployers()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync("employment/employmentTable/professionalEmploymentInformation", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    //different/new code here...
                    //make json out of data
                    var rtnResults = JsonConvert.DeserializeObject<Dictionary<string, List<Employment.ProfessionalEmploymentInformation>>>(data);

                    //created dictionary, now create list
                    List<Employment.ProfessionalEmploymentInformation> empList = new List<Employment.ProfessionalEmploymentInformation>();

                    //iterate through the data in rtnResults
                    //how many times do i go through this loop? Once 
                    foreach (KeyValuePair<string, List<Employment.ProfessionalEmploymentInformation>> kvp in rtnResults)
                    {
                        //this goes through until it reaches the end of the faculty list (last faculty member)
                        foreach (var item in kvp.Value)
                        {
                            empList.Add(item);
                            //lets see some data
                            Console.WriteLine(item.employer);
                        }
                    }
                    return empList;
                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<Employment.ProfessionalEmploymentInformation> empList = new List<Employment.ProfessionalEmploymentInformation>();
                    return empList;
                    //return "HttpRequestException";
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<Employment.ProfessionalEmploymentInformation> empList = new List<Employment.ProfessionalEmploymentInformation>();
                    return empList;
                    //return "Exception"; ;
                }

            }
        }
        public async Task<List<Employment.CoopInformation>> getAllCoops()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync("employment/coopTable/coopInformation", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    //different/new code here...
                    //make json out of data
                    var rtnResults = JsonConvert.DeserializeObject<Dictionary<string, List<Employment.CoopInformation>>>(data);

                    //created dictionary, now create list
                    List<Employment.CoopInformation> cooList = new List<Employment.CoopInformation>();

                    //iterate through the data in rtnResults
                    //how many times do i go through this loop? Once 
                    foreach (KeyValuePair<string, List<Employment.CoopInformation>> kvp in rtnResults)
                    {
                        //this goes through until it reaches the end of the faculty list (last faculty member)
                        foreach (var item in kvp.Value)
                        {
                            cooList.Add(item);
                            //lets see some data
                            Console.WriteLine(item.employer);
                        }
                    }
                    return cooList;
                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<Employment.CoopInformation> cooList = new List<Employment.CoopInformation>();
                    return cooList;
                    //return "HttpRequestException";
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<Employment.CoopInformation> cooList = new List<Employment.CoopInformation>();
                    return cooList;
                    //return "Exception"; ;
                }

            }
        }
        public async Task<List<Employment.Content>> getContent()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync("employment/introduction/content", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    //different/new code here...
                    //make json out of data
                    var rtnResults = JsonConvert.DeserializeObject<Dictionary<string, List<Employment.Content>>>(data);

                    //created dictionary, now create list
                    List<Employment.Content> cont = new List<Employment.Content>();

                    //iterate through the data in rtnResults
                    //how many times do i go through this loop? Once 
                    foreach (KeyValuePair<string, List<Employment.Content>> kvp in rtnResults)
                    {
                        //this goes through until it reaches the end of the faculty list (last faculty member)
                        foreach (var item in kvp.Value)
                        {
                            cont.Add(item);
                            //lets see some data
                        }
                    }
                    return cont;
                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<Employment.Content> cont = new List<Employment.Content>();
                    return cont;
                    //return "HttpRequestException";
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<Employment.Content> cont = new List<Employment.Content>();
                    return cont;
                    //return "Exception"; ;
                }

            }
        }
    }
}
