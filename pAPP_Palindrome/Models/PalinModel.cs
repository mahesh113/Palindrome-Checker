using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Helpers;

namespace pAPP_Palindrome.Models
{
    public class PalinModel
    {

        public static List<string>  GetAllPalindromes()
        {
            IEnumerable<string> data;
            using (MyDBContext db = new MyDBContext())
            {
                 data = from b in db.PalindromeStrings
                               //where b.Id == 2
                           select b.Name;
                //foreach (var i in data)
                //       Console.WriteLine(i.Name);
                var re = data.ToList();
                //var ret = new Json { Data = data.ToList(), JsonRequestBehavior = System.Web.Mvc.JsonRequestBehavior.AllowGet };
                return re;
            }
            
            
        }
        public static void InsertPalindrome(string str)
        {
            //string value = str;
            //string mydocpath = Environment.CurrentDirectory.ToString();
            using (MyDBContext db = new MyDBContext())
            {
                var val = new PString() { Name = str };
                db.PalindromeStrings.Add(val);
                db.SaveChanges();
                //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, user);
                //response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = user.Id }));
                //return response;
                //var data = from b in db.PalindromeStrings
                //           //where b.Id == 2
                //           select b;

                //var data = db.PalindromeStrings.Find(1);
                //foreach (var i in data)
                //    Console.WriteLine(i.Name);


            }
        }


        [Obsolete("Palindrome cehck is now being done from javascrit side", true)]
        private static bool isPalindrome(string str)
        {
            bool ret = true;
            char[] ch = str.ToCharArray();
            Array.Reverse(ch);
            string rstr = new string(ch);
            if (str != rstr)
                ret = false;
            return ret;
        }
    }


    public class PString
    {
        public string Name { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }

    public class MyDBContext : DbContext
    {
        public DbSet<PString> PalindromeStrings { get; set; }
        public MyDBContext() : base("DefaultConnection")
        {


        }
    }
}