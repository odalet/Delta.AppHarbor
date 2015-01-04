using System;
using System.Net;
using System.Net.Http;
using System.Linq;
using System.Web.Http;
using System.Collections.Generic;

using Siti.Data;
using Delta.AppHarbor.Models;

namespace Delta.AppHarbor.Areas.SitiApi.Controllers
{
    public class PersonsController : ApiController
    {
        private DataContext _db = new DataContext();

        // GET api/values
        public IEnumerable<SimplePerson> Get()
        {
            return Try(() => _db.Persons.Select(p => new SimplePerson()
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                BirthDate = p.BirthDate
            }).ToArray());
        }

        // GET api/values/5
        public Person Get(long id)
        {
            var found = Try(() => 
                _db.Persons
                .Include("Photo")
                .Include("Signature")
                .Include("Fingerprints")
                .SingleOrDefault(p => p.Id == id));
                        
            if (found == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return found;
        }

        /// <summary>
        /// Releases the unmanaged resources that are used by the object and, optionally, releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _db.Dispose();
            base.Dispose(disposing);
        }

        private T Try<T>(Func<T> function)
        {
            try
            {
                return function();
            }
            catch (Exception ex)
            {
                // http://www.asp.net/web-api/overview/error-handling/exception-handling
                // Note: do not do that (reveal internal failure cause) in real applications 
                throw new HttpResponseException(
                    new HttpResponseMessage(HttpStatusCode.InternalServerError)
                    {
                        ReasonPhrase = ex.Message
                    });
            }
        }
    }
}
