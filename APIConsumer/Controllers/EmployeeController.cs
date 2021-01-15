using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using APIConsumer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIConsumer.Controllers
{
    public class EmployeeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            IList<Employees> employees = new List<Employees>();
            var response = await GetEmployees();
            employees = JsonConvert.DeserializeObject<List<Employees>>(response);
            return View(employees);
        }
        public async Task<string> GetEmployees()
        {
            using(var data=new HttpClient())
            {
                var path = "http://localhost:9164/api/employees";
                using(var response =await data.GetAsync(path))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    return apiresponse;
                }
                
            }
        }
        public IActionResult Create()
        {
            return View(new Employees());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmpName,Salary,DeptNo")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                var jsonString = JsonConvert.SerializeObject(employees);
                var stringContent = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");

                var apiResponse = await PostAPIResponseAsync(stringContent);
                var response = apiResponse;
                return RedirectToAction(nameof(Index));
            }
            return View(employees);
        }

        private async Task<string> PostAPIResponseAsync(StringContent stringContent)
        {
            using (var client = new HttpClient())
            {
                var fullApiPath = "http://localhost:9164/api/employees";
                using (var response = await client.PostAsync(fullApiPath, stringContent))
                {
                    var res = await response.Content.ReadAsStringAsync();
                    return res;
                }
            }
        }


    }
}
