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
    public class GetResources
    {
        //get specific info

        //get StudyAbroad
        public async Task<List<Resources.StudyAbroad>> getStudyAbroad()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync("resources/studyAbroad", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    //different/new code here...
                    //make json out of data
                    var rtnResults = JsonConvert.DeserializeObject<Dictionary<string, List<Resources.StudyAbroad>>>(data);

                    //created dictionary, now creating list
                    List<Resources.StudyAbroad> contentSA = new List<Resources.StudyAbroad>();

                    foreach (KeyValuePair<string, List<Resources.StudyAbroad>> kvp in rtnResults)
                    {
                        //this goes through until it reaches the end of the faculty list (last faculty member)
                        foreach (var item in kvp.Value)
                        {
                            contentSA.Add(item);
                            //lets see some data
                        }
                    }
                    return contentSA;
                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<Resources.StudyAbroad> contentSA = new List<Resources.StudyAbroad>();
                    return contentSA;
                    //return "HttpRequestException";
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<Resources.StudyAbroad> contentSA = new List<Resources.StudyAbroad>();
                    return contentSA;
                    //return "Exception"; ;
                }

            }
        }


    }
}
