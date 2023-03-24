using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace APIconsumationPage.Controllers
{ 
    public class LottoController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult GetLottoTipsForm()
        {
            return View();
        }

        public async Task<IActionResult> GetLottoTipsProc(int cnt)
        {//get random numbers from api

            List<int> tipList = new List<int>();// { 1, 2, 3, 4, 5, 18 };

            string input = "http://localhost:5000/rng/getrandomnumbers?apikey=hallowelt&min=1&max=45&cnt=" + cnt * 6 + "&responseformat=json";

            using (var httpClient = new HttpClient())
            {
                using HttpResponseMessage response = await httpClient.GetAsync(input);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                //convert json
                tipList = JsonConvert.DeserializeObject<List<int>>(responseBody);


                return View(tipList);
            }
        }
    }
}
