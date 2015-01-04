using System.Data.Entity;

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
                BirthDate = "19800101",
                Photo = photo1,
                Signature = signature1,
                Fingerprints = fp1
            };

            var john = new Person()
            {
                FirstName = "John",
                LastName = "Doe",
                BirthDate = "19530200",
                Photo = photo2,
                Signature = signature2,
                Fingerprints = fp2
            };

            var odalet = new Person()
            {
                FirstName = "Jean-Sébastien",
                LastName = "Bach",
                BirthDate = "16850000",
                Photo = photo3,
                Signature = signature3,
                Fingerprints = fp3
            };

            context.Persons.AddRange(new[] { lucienne, john, odalet });
            context.SaveChanges();
        }
    }
}
