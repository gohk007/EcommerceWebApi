using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsyncController : ControllerBase
    {


        [HttpGet]
        [Route("api/Async/GetParameter/{id}")]
        public async Task<IActionResult> GetParameter(int id)
        {

            await WaitAndApologizeAsync();

            await OnButtonClicked2Async();

            string result = ReturnString();

            Task<string> asyncResult = AsyncReturn();


            return Ok(asyncResult);

        }

        static async Task WaitAndApologizeAsync()
        {
            await Task.Delay(2000);

            Console.WriteLine("Sorry for the delay...\n");
        }


        private static async Task OnButtonClicked2Async()
        {
            Console.WriteLine("   Handler 2 is starting...");
            Task.Delay(100).Wait();

        }

        private string ReturnString()
        {

            Task.Delay(100).Wait();
            return "Hai";

        }


        private async Task<string> AsyncReturn()
        {

            return await Task.FromResult(string.Empty);

        }
    }
}
