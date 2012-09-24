using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TDCContactsAPI.Models;

namespace TDCContactsAPI.Controllers
{
    public class ContactsController : ApiController
    {
        // GET api/values
        public IEnumerable<Contact> Get()
        {
            return new[] { Contact.CreateContact(1, firstName: "John"), Contact.CreateContact(2, firstName: "Tomas") };
        }

        // GET api/values/5
        public Contact Get(int id)
        {
            return Contact.CreateContact(1, firstName: "John");
        }

        // POST api/values
        public void Post([FromBody]Contact value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Contact value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
