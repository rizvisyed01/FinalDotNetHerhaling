using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalClient.Controllers
{
    [Route("")]
    [Route("[controller]")]
    public class StudentController : Controller
    {
        HttpClient client;

        public StudentController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:6060");
            client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json")
                );
        }

        // GET: /<controller>/
        [Route("")]
        [Route("[action]")]
        public IActionResult Index()
        {
            try
            {
                HttpResponseMessage response = client.GetAsync("/api/student").Result;
                string data = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<ICollection<StudentBasic>>(data)); 
            }
            catch (Exception)
            {

                return View("Error"); 
            }
            
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        public IActionResult Add(StudentBasic student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string data = JsonConvert.SerializeObject(student);
                    var contenData = new StringContent(
                        data, System.Text.Encoding.UTF8, "application/json"
                        );
                    HttpResponseMessage response = client.PostAsync("/api/student/", contenData).Result;
                    return Redirect("Index");
                }
                return View();
            }
            catch (Exception)
            {

                return View("Error");
            }
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult change(int id)
        {
            try
            {
                HttpResponseMessage response = client.GetAsync($"/api/student/{id}").Result;
                string data = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<StudentBasic>(data));
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        [Route("[action]/{id}")]
        public IActionResult change(int id, StudentBasic student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string data = JsonConvert.SerializeObject(student);
                    var contenData = new StringContent(
                        data, System.Text.Encoding.UTF8, "application/json"
                        );
                    HttpResponseMessage response = client.PutAsync($"/api/student/{id}", contenData).Result;
                    return RedirectToAction("Index");
                

                }
                return View("Error");
            }
            catch (Exception)
            {

                return View("Error");
            }
        }

        [Route("[action]/{delId}")]
        public IActionResult delete(int delId)
        {
            try
            {
                HttpResponseMessage message = client.DeleteAsync($"/api/student/{delId}").Result;
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View("Error");
            }
        }

    }
}
