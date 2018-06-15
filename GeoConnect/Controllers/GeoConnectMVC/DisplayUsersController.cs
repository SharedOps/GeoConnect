using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using GeoConnect.Models.GeoConnect;
using Newtonsoft.Json;

namespace GeoConnect.Controllers.GeoConnectMVC
{
    public class DisplayUsersController : Controller
    {
        public async Task<ActionResult> Index()
        {
            List<User> userInfo = new List<User>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Models.Constants.GeoConnectConstants.baseURL);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/UserRegistration");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    userInfo = JsonConvert.DeserializeObject<List<User>>(EmpResponse);

                    foreach (var item in userInfo)
                    {
                        item.imagestrem = item.Avatar.ToString();
                    }

                   
                }
                //returning the employee list to view  
                return View(userInfo);
            }
        }
    }
}
