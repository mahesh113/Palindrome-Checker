using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using pAPP_Palindrome.Models;
using System.Net;

namespace pAPP_Palindrome.Controllers
{
    public class PalindromeStringsController : ApiController
    {
        // GET: api/GetAll
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var data= PalinModel.GetAllPalindromes();
            if(data == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found for the Given ID");
            }
            else
            {
                foreach (var i in data)
                    Console.WriteLine(i);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            // return new string[] { "value1", "value2" };
        }

        // GET: api/PalindromeStrings/5
        public string GetAll(int id)
        {
            return "value";
        }

        // POST: api/PalindromeStrings
        [HttpPost]
        public void Post([FromBody]dynamic val)
        {
            string data = val.value;
            PalinModel.InsertPalindrome(data);
        }

        // PUT: api/PalindromeStrings/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PalindromeStrings/5
        public void Delete(int id)
        {
        }
    }
}
