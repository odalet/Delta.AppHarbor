using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Siti.Data
{
    public class Person
    {
        [Key]
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Nationality { get; set; }

        public string EyesColor { get; set; }

        public int Height { get; set; }

        public Gender Gender { get; set; }

        public string BirthDate { get; set; }

        public string BirthPlace { get; set; }

        public string Address { get; set; }

        public Blob Photo { get; set; }

        public Blob PhotoThumbnail { get; set; }

        public Blob Signature { get; set; }

        public ICollection<Fingerprint> Fingerprints { get; set; }
    }
}
