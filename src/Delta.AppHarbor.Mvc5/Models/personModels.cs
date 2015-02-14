using System;
using System.Collections.Generic;
using Siti.Data;

namespace Delta.AppHarbor.Models
{
    public class SimplePerson
    {
        public SimplePerson(Person person)
        {
            if (person == null) throw new ArgumentNullException("person");

            Id = person.Id;
            FirstName = person.FirstName;
            LastName = person.LastName;
            Nationality = person.Nationality;
            EyesColor = person.EyesColor;
            Height = person.Height;
            Gender = person.Gender;
            BirthDate = person.BirthDate;
            Thumbnail = person.PhotoThumbnail;
        }

        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Nationality { get; set; }

        public string EyesColor { get; set; }

        public int Height { get; set; }

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
            Nationality = person.Nationality;
            EyesColor = person.EyesColor;
            Height = person.Height;
            Gender = person.Gender;
            BirthDate = person.BirthDate;
            BirthPlace = person.BirthPlace;
            Address = person.Address;
            Photo = person.Photo ?? person.PhotoThumbnail;
            Signature = person.Signature;
            Fingerprints = person.Fingerprints;
        }

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

        public Blob Signature { get; set; }

        public ICollection<Fingerprint> Fingerprints { get; set; }
    }
}