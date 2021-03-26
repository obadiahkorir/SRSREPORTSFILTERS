using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleDemoMVC.Models
{
    public class Programme
    {
        public int Id { get; set; }

        [Display(Name = "Beneficiary Type")]
        public int BeneficiaryTypeId { get; set; }

        [StringLength(10), Required]
        //[Index(IsUnique = true)]
        [Display(Name = "Beneficiary Programme Number Prefix")]
        public string BeneProgNoPrefix { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Programme Code")]
        [RegularExpression("^[A-Za-z0-9-]*$", ErrorMessage = "Invalid!")]
        public string Code { get; set; }
    }
}
