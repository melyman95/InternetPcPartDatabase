using System.ComponentModel.DataAnnotations;

namespace InternetPcPartDatabase.Models
{
    public class Part
    {
        [Key]
        public int PartId {  get; set; }

        public string PartType {  get; set; }

        public string PartName {  get; set; }   

        public string Manufacturer {  get; set; }

        public string MSRP {  get; set; }

        public string ReleaseYear {  get; set; }
    }
}
