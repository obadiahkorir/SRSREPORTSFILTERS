using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SampleDemoMVC.Models
{
    public class Locations
    {
        [Display(Name = "Location Code")]
        [Required]
        [StringLength(20)]
        public string Code { get; set; }


        [Display(Name = "Division")]
        public int DivisionId { get; set; }

        [Display(Name = "Location")]
        public int Id { get; set; }

        [Display(Name = "Location Name")]
        [Required]
        [StringLength(30)]
        public string Name { get; set; }


        [Display(Name = "Payment Zone")]
        public int? PaymentZoneId { get; set; }

        [JsonIgnore]
        public ICollection<SubLocation> SubLocations { get; set; }


        // public string Constituency => $"{Division.CountyDistrict.County.Constituencies}";
    }
}
