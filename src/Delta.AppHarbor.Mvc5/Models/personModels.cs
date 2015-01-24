using System;
using System.Collections.Generic;
using Siti.Data;

namespace Delta.AppHarbor.Models
{
    public class SimplePerson
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public string BirthDate { get; set; }

        public Blob Thumbnail { get; set; }
    }

    public class FullPerson
    {
        public FullPerson(Person person)
        {
            if (person == null) throw new ArgumentNullException("person");

            Id = person.Id;
            FirstName = person.FirstName;
            LastName = person.LastName;
            Gender = person.Gender;
            BirthDate = person.BirthDate;
            Address = person.Address;
            Photo = person.Photo ?? person.PhotoThumbnail;
            Signature = person.Signature;
            Fingerprints = person.Fingerprints;
        }

        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public string BirthDate { get; set; }

        public string Address { get; set; }

        public Blob Photo { get; set; }

        public Blob Signature { get; set; }

        public ICollection<Fingerprint> Fingerprints { get; set; }
    }
}