using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SampleDemoMVC.Models
{
    public class Constituency
    {
        [StringLength(20)]
        [Required]
        [Display(Name = "Constituency Code")]
        public string Code { get; set; }

        //[JsonIgnore]
        //public County County { get; set; }

        [Display(Name = "County")]
        public int CountyId { get; set; }

        [Display(Name = "Constituency ID")]
        public int Id { get; set; }

        [StringLength(30)]
        [Required]
        [Display(Name = "Constituency Name")]
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Ward> Wards { get; set; }
    }
}