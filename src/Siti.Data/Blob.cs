using System.ComponentModel.DataAnnotations;

namespace Siti.Data
{
    public class Blob
    {
        [Key]
        public long Id { get; set; }

        public string MimeType { get; set; }

        public byte[] Data { get; set; }        
    }
}
