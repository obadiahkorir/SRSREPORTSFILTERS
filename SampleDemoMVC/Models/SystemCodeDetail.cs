using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleDemoMVC.Models
{
    public class SystemCodeDetail
    {
        [Required, StringLength(20)]
        [Display(Name = "Parameter Code")]
        public string Code { get; set; }

        [Required, StringLength(100), DataType(DataType.MultilineText)]
        [Display(Name = "Parameter Valur")]
        public string Description { get; set; }

        [Display(Name = "Parameter")]
        public int Id { get; set; }

        [Display(Name = "Order Number"), DataType(DataType.Text)]
        public int OrderNo { get; set; }

        public SystemCode SystemCode { get; set; }

        [Display(Name = "General Parameter Id")]
        public int SystemCodeId { get; set; }

        public bool IsActive { get; set; }
    }
}
