using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Delta.AppHarbor.Models
{
    public class SimplePerson
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string BirthDate { get; set; }
    }
}