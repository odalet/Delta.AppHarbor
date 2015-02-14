using System.Data.Entity;
using System.Drawing;

namespace Siti.Data
{
    public class DataInitializer : 
        //DropCreateDatabaseAlways<DataContext>
        DropCreateDatabaseIfModelChanges<DataContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataInitializer"/> class.
        /// </summary>
        public DataInitializer() : base() { }

        protected override void Seed(DataContext context)
        {
            var signature1 = new Blob() { Data = Properties.Resources.Lucienne_Sign, MimeType = WellKnownMimeTypes.Jpeg2000 };
            var signature2 = new Blob() { Data = Properties.Resources.sign, MimeType = WellKnownMimeTypes.Jpeg2000 };
            var signature3 = new Blob() { Data = Properties.Resources.signJpeg, MimeType = WellKnownMimeTypes.Jpeg };

            var photo1 = new Blob() { Data = Properties.Resources.Lucienne, MimeType = WellKnownMimeTypes.Jpeg2000 };
            var photo2 = new Blob() { Data = Properties.Resources.jf3, MimeType = WellKnownMimeTypes.Jpeg2000 };
            var photo3 = new Blob() { Data = Properties.Resources.odaletJpeg, MimeType = WellKnownMimeTypes.Jpeg };

            var thumbnail1 = new Blob() { Data = Properties.Resources.LucienneThumb, MimeType = WellKnownMimeTypes.Jpeg };
            var thumbnail2 = new Blob() { Data = Properties.Resources.jf3Thumb, MimeType = WellKnownMimeTypes.Jpeg };
            var thumbnail3 = new Blob() { Data = Properties.Resources.odaletThumb, MimeType = WellKnownMimeTypes.Jpeg };

            var fp1 = new Fingerprint[]
            {
                new Fingerprint() { Finger = Finger.LeftThumb, Data = Properties.Resources.tbcThumbLeft1, MimeType = WellKnownMimeTypes.Wsq },
                new Fingerprint() { Finger = Finger.RightThumb, Data = Properties.Resources.tbcThumbRight1, MimeType = WellKnownMimeTypes.Wsq }
            };
            
            var fp2 = new Fingerprint[]
            {
                new Fingerprint() { Finger = Finger.LeftThumb, Data = Properties.Resources.tbcThumbLeft2, MimeType = WellKnownMimeTypes.Wsq },
                new Fingerprint() { Finger = Finger.RightThumb, Data = Properties.Resources.tbcThumbRight2, MimeType = WellKnownMimeTypes.Wsq }
            };

            var fp3 = new Fingerprint[]
            {
                new Fingerprint() { Finger = Finger.LeftThumb, Data = Properties.Resources.ODThumbLeft1, MimeType = WellKnownMimeTypes.Wsq },
                new Fingerprint() { Finger = Finger.RightThumb, Data = Properties.Resources.ODThumbRight1, MimeType = WellKnownMimeTypes.Wsq }
            };


            var lucienne = new Person()
            {
                FirstName = "Lucienne",
                LastName = "Specimen",
                Nationality = "FRA",
                EyesColor = Color.Blue.Name,
                Height = 165,
                BirthDate = "19800101",
                BirthPlace = "Paris (75001), France",
                Gender = Gender.Female,
                Address = @"1 Rue Ponce Pilate
06300 Nice
France",
                Photo = photo1,
                PhotoThumbnail = thumbnail1,
                Signature = signature1,
                Fingerprints = fp1
            };

            var john = new Person()
            {
                FirstName = "John",
                LastName = "Doe",
                Nationality = "USA",
                EyesColor = Color.Black.Name,
                Height = 183,
                BirthDate = "19530200",
                BirthPlace = "",
                Gender = Gender.Male,
                Address = null,
                Photo = photo2,
                PhotoThumbnail = thumbnail2,
                Signature = signature2,
                Fingerprints = fp2
            };

            var odalet = new Person()
            {
                FirstName = "Jean-Sébastien",
                LastName = "Bach",
                Nationality = "DEU",
                EyesColor = Color.Brown.Name,
                Height = 175,
                BirthDate = "16850000",
                BirthPlace = "Eisenach (Sachsen-Eisenach)",
                Address = @"Ritterstraße 26
04109 Leipzig
Deutschland",
                Gender = Gender.Male,
                Photo = photo3,
                PhotoThumbnail = thumbnail3,
                Signature = signature3,
                Fingerprints = fp3
            };

            context.Persons.AddRange(new[] { lucienne, john, odalet });
            context.SaveChanges();
        }
    }
}
