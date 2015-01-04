using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Siti.Data
{
    public class Person
    {
        [Key]
        public long Id { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string BirthDate { get; set; }

        public Blob Photo { get; set; }

        public Blob Signature { get; set; }

        public ICollection<Fingerprint> Fingerprints { get; set; }
    }
}
