using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaazApplication.Models
{
    public partial class Country
    {
        public string CountryName { get; set; }
    }
    public partial class State
    {
        public string StateName { get; set; }
    }
    public partial class Company
    {
        public string CompanyName { get; set; }
    }

    public partial class Bank
    {
        public string BankName { get; set; }
    }
    public partial class IFSC
    {
        public string IFSCCodeName { get; set; }
    }


    public class CmpModel
    {//Company

        public int ID { get; set; }
        [DisplayName("Name")]
        public string Company { get; set; }
        [Display(Name = "Abbreviation")]
        public string Abbrevation { get; set; }
        [Display(Name = "House/Plot Number")]
        public string PlotNo { get; set; }
        public string Street { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "Pincode")]
        public string Pincode { get; set; }
        [Display(Name = "Country")]
        public string Country { get; set; }
        [Display(Name = "State")]
        public string State { get; set; }
        [DisplayName("ContactNo")]
        public string MobileNo { get; set; }
        [DisplayName("Mail ID")]
        public string EmailID { get; set; }
        [DisplayName("Website")]
        public string Website { get; set; }
        [DisplayName("Fax")]
        public string Fax { get; set; }
        [DisplayName("Logo")]
        public string Logo { get; set; }
    }
    public class CmpCftModel
    {

        // public int CftCompanyId { get; set; }
        //public IEnumerable<SelectListItem> Company { get; set; }
        [Display(Name = "Company")]
        public string Company { get; set; }
        [Display(Name = "Certificate Of incorporatiion(C.I.N)")]
        public string CIN { get; set; }
        [Display(Name = "Permanent Account Number(P.A.N)")]
        public string PAN { get; set; }
        [Display(Name = "Service Tax Registration Certificate(S.T.R.C)")]
        public string STRC { get; set; }
        [Display(Name = "Employee Provident Fund(E.P.F)")]
        public string EPF { get; set; }
        [Display(Name = "Articles Of association(A.O.A)")]
        public string AOA { get; set; }
        [Display(Name = "Tax Deduction Account Number(T.A.N)")]
        public string TAN { get; set; }
        [Display(Name = "Professional Tax")]
        public string PT { get; set; }
        [Display(Name = "Know Your Customer(K.Y.c)")]
        public string KYC { get; set; }
        [Display(Name = "Memorandum Of Association(M.O.A)")]
        public string MOA { get; set; }
        [Display(Name = "Taxpayer Identification Number(T.I.N)")]
        public string TIN { get; set; }
        [Display(Name = "Employement State Insurance(E.S.I)")]
        public string ESI { get; set; }
        [Display(Name = "Import and Export Certificate(I.E.C)")]
        public string IEC { get; set; }
        [Display(Name = "Udyog Aadhar(U.A.D)")]
        public string UAD { get; set; }


    }
    public class CmpCombine
    {
        public CmpModel CmpModels { get; set; }
        public CmpCftModel CmpCftModels { get; set; }
        public BnkDtl BnkDtls { get; set; }

        //public List<CmpModel> CompanyDetails { get; set; }
        //public List<BnkDtl> BankDetaile { get; set; }
        //public List<CmpCftModel> Certificates { get; set; }

        private CmpModel _CompanyDetails = new CmpModel();
        public CmpModel CompanyDetails { get { return _CompanyDetails; } set { _CompanyDetails = value; } }

        private BnkDtl _BankDetails = new BnkDtl();
        public BnkDtl BankDetails { get { return _BankDetails; } set { _BankDetails = value; } }

        private CmpCftModel _CertificateDetails = new CmpCftModel();
        public CmpCftModel CertificateDetails { get { return _CertificateDetails; } set { _CertificateDetails = value; } }



    }

    public class BnkDtl
    {
        public string ID { get; set; }
        [Display(Name = "Company")]
        public string Company { get; set; }
        [Display(Name = "Account Name")]
        public string AcHoldername { get; set; }
        [Display(Name = "Account Number")]
        public string Acnumber { get; set; }
        [Display(Name = "BankName")]
        public string BankName { get; set; }
        [Display(Name = "IFSC Code")]
        public string IFSC { get; set; }
    }

}