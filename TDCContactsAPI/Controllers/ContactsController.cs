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
        private ContactRepository _contactsRepository;

        public ContactsController()
        {
            _contactsRepository = new ContactRepository();
        }

        // GET api/values
        public IEnumerable<Contact> Get()
        {
            return _contactsRepository.Get();
        }

        // GET api/values/5
        public Contact Get(int id)
        {
            return _contactsRepository.Get().SingleOrDefault(y => y.Id == id);
        }

        // POST api/values
        public void Post([FromBody]Contact value)
        {
            _contactsRepository.Insert(value);
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, [FromBody]Contact value)
        {
            var contact = _contactsRepository.Get().SingleOrDefault(y => y.Id == id);
            if (contact != null)
            {
                contact.FirstName = value.FirstName;
                contact.LastName = value.LastName;
                contact.PhoneNumber = value.PhoneNumber;
                return Request.CreateResponse(HttpStatusCode.Accepted, contact);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            var contact = _contactsRepository.Get().SingleOrDefault(y => y.Id == id);
            if (contact != null)
            {
                _contactsRepository.Delete(id);
                return Request.CreateResponse(HttpStatusCode.Accepted);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }
}
