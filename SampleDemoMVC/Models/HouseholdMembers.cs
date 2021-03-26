using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleDemoMVC.Models
{
    public class HouseholdMembers
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public int? StatusId { get; set; }
        public int? RelationshipId { get; set; }
        public int? MemberRoleId { get; set; }
        public int? SourceId { get; set; }
        public string Surname { get; set; }
        public int? NationalIdNo { get; set; }
        public int? MobileNo2 { get; set; }
        public DateTime Dob { get; set; }
        public int? BirthCertNo { get; set; }
        public int? HouseholdId { get; set; }
    }
}
