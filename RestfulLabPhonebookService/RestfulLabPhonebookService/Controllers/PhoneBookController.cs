using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using PhoneBookService.Models;

namespace PhoneBookService.Controllers
{

    [RoutePrefix("phonebook")]
    public class PhoneBookController : ApiController
    {

        private static List<PhoneBook> phonebook = new List<PhoneBook>()
                {
                    new PhoneBook { Name = "Jason", PhoneNumer = "a0851068162", Address = "1 Main Road" },
                    new PhoneBook { Name = "Karl", PhoneNumer = "2346732242", Address = "2 Main Road" },
                    new PhoneBook { Name = "Steve", PhoneNumer = "2576731290", Address = "3 Main Road" },
                    new PhoneBook { Name = "James", PhoneNumer = "6846612225", Address = "4 Main Road" },
                };

        // GET /phonebook/all (not api/PhoneBook)
        [Route("all")]                                                                 // on a controller action
        [HttpGet]
        public IHttpActionResult RetrieveAllPhoneBookInformation()
        {
            // return all in name order, force evaluation of query using ToList()
            return Ok(phonebook.OrderBy(w => w.Name).ToList());                                                     // 200 OK, phonebook serialized in response body
        }


        // GET /phonebook/number/xxxxxxxxxx
        [Route("number/{phoneNumber:alpha}")]                                            // {parameter:constraint}
        public IHttpActionResult GetInformationForNumber(String phoneNumber)
        {
            // LINQ query, find matching city (case-insensitive) or default value (null) if none matching
            PhoneBook numberInformation = phonebook.FirstOrDefault(p => p.PhoneNumer.ToUpper() == phoneNumber.ToUpper());
            if (numberInformation == null)
            {
                return NotFound();                                                  // 404
            }
            return Ok(numberInformation);                                                 // 200 OK, phoneNumber info serialized in response body
        }









    }
}
