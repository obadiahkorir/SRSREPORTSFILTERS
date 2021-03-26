using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleDemoMVC.Models
{
    public class SystemCode
    {
            [Display(Name = "Parent Parameter Code")]
            //   [Required, StringLength(20), Index(IsUnique = true, IsClustered = false)]
            public string Code { get; set; }

            [Required, StringLength(100), DataType(DataType.MultilineText)]
            [Display(Name = "Parameter Description")]
            // [Index("IX_SystemCode_Description", IsClustered = false)]
            public string Description { get; set; }

            [Display(Name = "Parameter #")]
            public int Id { get; set; }

            [Display(Name = "Is User Maintained")]
            public bool IsUserMaintained { get; set; }
            public ICollection<SystemCodeDetail> SystemCodeDetails { get; set; }
        }
    
}