using System;
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
            try
            {
                return _db.Persons.Select(p => new SimplePerson()
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    BirthDate = p.BirthDate
                }).ToArray();
            }
            catch (Exception ex)
            {
                var debugEx = ex;
                return null;
            }
        }

        // GET api/values/5
        public Person Get(long id)
        {
            return _db.Persons
                .Include("Photo")
                .Include("Signature")
                .Include("Fingerprints")
                .SingleOrDefault(p => p.Id == id);
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
    }
}
