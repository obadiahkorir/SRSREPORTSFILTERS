using Microsoft.VisualStudio.Services.WebApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SampleDemoMVC.Models
{
    public class ListedHouseholdsViewModel
    {
        [DisplayName("National Id No.")]
        public string NationalIdNo { get; set; }
        [DisplayName("Phone")]
        public string PhoneNumber { get; set; }

        [DisplayName("Status")]
        public int StatusId { get; set; }


        [DisplayName("Programme")]
        public int? ProgrammeId { get; set; }
        [DisplayName("Programme No.")]
        public string NSNPHouseholdNo { get; set; }

        [DisplayName("County")]
        public int? CountyId { get; set; }
        [DisplayName("Sub County")]
        public int? ConstituencyId { get; set; }
        [DisplayName("Location")]
        public int? LocationId { get; set; }
        [DisplayName("Sub Location")]
        public int? SubLocationId { get; set; }
        public string Option { get; set; }
        public int? PageSize { get; set; }
        public int? Page { get; set; }

        public int? SexId { get; set; }

        public string SexIDValue { get; set; }

        public int RelationshipId { get; set; }

        public int MemberRoleId { get; set; }

        public int SourceId { get; set; }
        public string SexIDParameter { get; set; }

        public NicheListingHousehold ListingHousehold { get; set; }

        public Constituency Constituency { get; set; }

        public SystemCodeDetail SystemCodeDetails { get; set; }

        public IPagedList<NicheListingHousehold> ListingHouseholds { get; set; }
    }

}
