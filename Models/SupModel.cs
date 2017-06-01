using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SaazApplication.Models
{
    public class SupModel
    {//Supplier    @Html.DropDownList("CountryList", new SelectList(ViewBag.CountryList), "Select Country", new { @class = "form-control" })
        public string Name { get; set; }
        [Display(Name="Contact Person")]
        public string ContactPerson { get; set; }
        [Display(Name = "Nature Of Bussiness ")]
        public string NatureOfBussiness { get; set; }
        //contact Details
        [Display(Name = " Telephone No  ")]
        public string TelephoneNo { get; set; }
        [Display(Name = " Home/Personal No  ")]
        public string H_PNo { get; set; }
        [Display(Name = " Fax No  ")]
        public string FaxNo { get; set; }
        [Display(Name = " Email  ID ")]
        public string EmailId { get; set; }
        //address
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        //payment terms
        [Display(Name = " Payment Type ")]
        public string PaymentType { get; set; }
        public string Currency { get; set; }
        //shipping charges
        public string VAT { get; set; }

    }
    //Analysis report
    public  class SupAnaModel
    {
        public string CompanyName { get; set; }
        [Display(Name = " Supplier Representative /Title ")]
        public string Supplier_Representative { get; set; }
        [Display(Name = " Type of Materials /Service Supply ")]
        public string Type_of_materials { get; set; }

        public string Company_Address { get; set; }
        //address
        public string Street { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }
        //Contact Details
        public string TelephoneNo { get; set; }
        public string H_PNo { get; set; }
        public string FaxNo { get; set; }
         public string Type_of_Bussiness { get; set; }
        //checkboxes
        public bool Manufacturer { get; set; }
        public bool Distributor { get; set; }
        public bool Trader { get; set; }
        public bool other { get; set; }

        public string NatureOfBussiness { get; set; }
        public string No_of_employees { get; set; }
        public string No_of_QAEmployees { get; set; } // if yes specify
        //Fundamental Checking

            [Display(Name = "Has the Supplier been done with Analinear before?	")]
         public string Fun1 { get; set; }
        [Display(Name = "Has the Supplier being disqualified by Analinear before?	 ")]
        public string Fun2 { get; set; }
        [Display(Name = "Has the Supplier fill up the Supplier Application Form?	")]
        public string Fun3 { get; set; }

        //Criteria of potential supplier selection
      //category A
        public string Quality { get; set; }
        public string NetPriceandPaymentTerm { get; set; }
        public string ISOcertification { get; set; }
        public string Delivery { get; set; }
        public string PerformanceHistory_reputation_PositionintheIndustry { get; set; }
        public string Managementandorganization { get; set; }
        public string WarrantiesandclaimPolicies { get; set; }
        public string Licensedcompany { get; set; }


      //category b
         public string Productionfacilities { get; set; }
        public string TechnicalCapabillity { get; set; }
        public string RepairService { get; set; }
        public string Communicationsystem { get; set; }
        public string Packagingability_labelling { get; set; }

       // CateegoryC 
 
        public string DesiretodoBusiness{ get; set; }
        public string Attitude       { get; set; }
        public string Impression       { get; set; }
        public string GeographicalLocation	 { get; set; }

        //Summaryoftotalscoreforeachcategory(AQ to fill up)

    }
}