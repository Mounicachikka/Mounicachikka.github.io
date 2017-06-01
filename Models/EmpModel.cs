using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaazApplication.Models
{

    public partial class Gender
    {
        public string GenderName { get; set; }
    }

    public class EmpBasic
    {
        public int Id { get; set; }
        /*dropdown*/
        public string EmployeeId { get; set; }
        /*dropdown*/
        public string CompanyMailId { get; set; }

        [Display(Name = "Profile Pic")]
        public string Employee_profile { get; set; }
        [Display(Name = "Employee_ID")]
        public string UniqueId { get; set; }

        public string Name { get; set; }
        [Display(Name = "First Name")]
        //[Required(ErrorMessage = "Please enter First Name")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Display(Name = "Last Name")]
        //[Required(ErrorMessage = "Please enter Last Name")]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Date of Birth"), Required(ErrorMessage = "Date of Birth is required")]
        public string Date_of_birth { get; set; }
        [Display(Name = "Place Of Birth")]
        //[Required(ErrorMessage = "Place of Birth is required")]
        public string BirthPlace { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date of Joining")]
        public string Date_of_join { get; set; }
        [Display(Name = "PAN Number")]
        //[Required(ErrorMessage = "Please enter PAN number")]
        public string PAN { get; set; }
        [Display(Name = "Passport")]
        //[Required(ErrorMessage = "Please enter Passport Id")]
        public string Passport { get; set; }
        public string Nationality { get; set; }
        [Display(Name = "Driving License #")]
        public string Driver_License { get; set; }
        [Display(Name = "Aadhaar/Unique ID")]
        //[Required(ErrorMessage = "Please enter Unique ID")]
        public string Unique_ID { get; set; }/*aadhar id*/
        /*dropdown*/
        public string Gender { get; set; }
        /*dropdown*/
        public string MaritalStatus { get; set; }
        /*dropdown*/
        public string Department { get; set; }
        /*dropdown*/
        public string Designation { get; set; }
        [Display(Name = "Employement Role")]
        /*dropdown*/
        public string EmployeeRole { get; set; }
        /*dropdown*/
        public string Employment_Type { get; set; }
        /*dropdown*/
        public string BloodType { get; set; }
        public string AddressType { get; set; }
        [Display(Name = "House/Plot Number")]
        public string plot { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        /*dropdown*/
        public string State { get; set; }
        /*dropdown*/
        public string Country { get; set; }

        public string PinCode { get; set; }
        public string ContactType { get; set; }
        /*contact no*/
        [Display(Name = "Contact Number")]
        public string CNumber { get; set; }

        public string EmailType { get; set; }
        [Display(Name = "Mail_ID")]
        //[Required(ErrorMessage = "Please enter  valid Mail_ID")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
      ErrorMessage = "Please enter valid email id.")]
        public string MailId { get; set; }

        public string Company { get; set; }

        public string PersonalmailId { get; set; }

    }

    public class EmpEmergency
    {
        /*dropdown*/
        [Display(Name = "Employee_ID")]
        public string Employee_EmgUniqueId { get; set; }

        [Display(Name = " Contact Name ")]
        //[Required(ErrorMessage = "Please enter Full Name ")]
        public string Contactname { get; set; }
        [Display(Name = "Relation")]
        //[Required(ErrorMessage = "Please enter Relationship status")]
        public string Relation { get; set; }
        [Display(Name = "House/Plot Number")]
        public string Plot { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        /*dropdown*/
        public string State { get; set; }

        /*dropdown*/
        public string Country { get; set; }

        public string PinCode { get; set; }
        //emergency address,phone,email
        /*Contact No*/
        [Display(Name = "Contact Number")]
        public string CNumber { get; set; }


        //Email
        [Display(Name = "Mail ID")]
        //[Required(ErrorMessage = "Please enter  valid Mail_ID")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
      ErrorMessage = "Please enter valid email id.")]
        public string Email { get; set; }


    }

    public class EmpInsurance
    {
        /*dropdown*/
        [Display(Name = "Emp_ID")]
        public string Employee_InsUniqueId { get; set; }

        [Display(Name = "I_Company Name")]
        public string Insurance_company { get; set; }

        [Display(Name = "Policy Number")]
        public string PolicyNumber { get; set; }
        [Display(Name = "Policy Name")]
        public string Policy_Name { get; set; }

    }

    public class EmpBank
    {
        /*dropdown*/
        [Display(Name = "Employee_ID")]
        public string Employee_UniqueId { get; set; }

        [Display(Name = "Account Name")]
        //[Required(ErrorMessage = "Please enter Name of person holding bank account")]
        public string AccountHoldername { get; set; }

        [Display(Name = "Account Number")]
        public string AccountNumber { get; set; }

        /*dropdown*/
        public string IFSCCode { get; set; }

        public string BankName { get; set; }

        public string MICR_Code { get; set; }
        public string Branch { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Country { get; set; }


    }
    /*doing*/
    public class EmpEducation
    {
        /*dropdown*/
        [Display(Name = "Employee_ID")]
        public string Employee_UniqueId { get; set; }
        public string Qualification { get; set; }
        public string Location { get; set; }
        [Display(Name = "Institution")]
        public string InstutionName { get; set; }
        [Display(Name = "Grade/ Percentage")]
        public string Grade { get; set; }
        [Display(Name = "From Year")]
        public string FromYear { get; set; }
        [Display(Name = "To Year")]
        public string ToYear { get; set; }
        [Display(Name = "Document Name")]
        public string DocumentName { get; set; }
        public string Document { get; set; }

        public string Qualification1 { get; set; }
        public string Location1 { get; set; }
        [Display(Name = "Institution")]
        public string InstutionName1 { get; set; }
        [Display(Name = "Grade/ Percentage")]
        public string Grade1 { get; set; }
        [Display(Name = "From Year")]
        public string FromYear1 { get; set; }
        [Display(Name = "To Year")]
        public string ToYear1 { get; set; }
        [Display(Name = "Document Name")]
        public string DocumentName1 { get; set; }
        public string Document1 { get; set; }

        public string Qualification2 { get; set; }
        public string Location2 { get; set; }
        [Display(Name = "Institution")]
        public string InstutionName2 { get; set; }
        [Display(Name = "Grade/ Percentage")]
        public string Grade2 { get; set; }
        [Display(Name = "From Year")]
        public string FromYear2 { get; set; }
        [Display(Name = "To Year")]
        public string ToYear2 { get; set; }
        [Display(Name = "Document Name")]
        public string DocumentName2 { get; set; }
        public string Document2 { get; set; }

        public string Qualification3 { get; set; }
        public string Location3 { get; set; }
        [Display(Name = "Institution")]
        public string InstutionName3 { get; set; }
        [Display(Name = "Grade/ Percentage")]
        public string Grade3 { get; set; }
        [Display(Name = "From Year")]
        public string FromYear3 { get; set; }
        [Display(Name = "To Year")]
        public string ToYear3 { get; set; }
        [Display(Name = "Document Name")]
        public string DocumentName3 { get; set; }
        public string Document3 { get; set; }

        public string Qualification4 { get; set; }
        public string Location4 { get; set; }
        [Display(Name = "Institution")]
        public string InstutionName4 { get; set; }
        [Display(Name = "Grade/ Percentage")]
        public string Grade4 { get; set; }
        [Display(Name = "From Year")]
        public string FromYear4 { get; set; }
        [Display(Name = "To Year")]
        public string ToYear4 { get; set; }
        [Display(Name = "Document Name")]
        public string DocumentName4 { get; set; }
        public string Document4 { get; set; }

        public List<EdList> EdLists { get; set; }

    }

    public class EdList
    {
        [Display(Name = "Employee_ID")]
        public string Employee_UniqueId { get; set; }
        public string Qualification { get; set; }
        public string Location { get; set; }
        [Display(Name = "Institution")]
        public string InstutionName { get; set; }
        [Display(Name = "From Year")]
        public string FromYear { get; set; }
        [Display(Name = "To Year")]
        public string ToYear { get; set; }
        [Display(Name = "Document Name")]
        public string DocumentName { get; set; }
        public string Document { get; set; }
    }

    public class EmpExperience
    {
        /*dropdown*/
        [Display(Name = "Employee_ID")]
        public string Employee_UniqueId { get; set; }

        public string Experience { get; set; }
        [Display(Name = "Company Name")]
        public string Cmp_Nm { get; set; }
        [Display(Name = "Company Location")]
        public string Cmp_Location { get; set; }
        public string Division { get; set; }
        public string Department { get; set; }
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public string FromDate { get; set; }/*from date*/
        [DataType(DataType.Date)]
        public string ToDate { get; set; }/*to date*/
        [Display(Name = "Other Information")]
        [DataType(DataType.MultilineText)]
        public string OtherInfo { get; set; }
        [Display(Name = "Doc_Name")]
        public string DocumentName { get; set; }
        public string Document { get; set; }



        public string Cmp_Nm1 { get; set; }
        public string Cmp_Location1 { get; set; }
        public string Division1 { get; set; }
        public string Department1 { get; set; }
        public string Title1 { get; set; }
        [DataType(DataType.Date)]
        public string FromDate1 { get; set; }
        [DataType(DataType.Date)]
        public string ToDate1 { get; set; }
        [DataType(DataType.MultilineText)]
        public string OtherInfo1 { get; set; }
        public string DocumentName1 { get; set; }
        public string Document1 { get; set; }


        public string Cmp_Nm2 { get; set; }
        public string Cmp_Location2 { get; set; }
        public string Division2 { get; set; }
        public string Department2 { get; set; }
        public string Title2 { get; set; }
        [DataType(DataType.Date)]
        public string FromDate2 { get; set; }
        [DataType(DataType.Date)]
        public string ToDate2 { get; set; }
        [DataType(DataType.MultilineText)]
        public string OtherInfo2 { get; set; }
        public string DocumentName2 { get; set; }
        public string Document2 { get; set; }


        public string Cmp_Nm3 { get; set; }
        public string Cmp_Location3 { get; set; }
        public string Division3 { get; set; }
        public string Department3 { get; set; }
        public string Title3 { get; set; }
        [DataType(DataType.Date)]
        public string FromDate3 { get; set; }
        [DataType(DataType.Date)]
        public string ToDate3 { get; set; }
        [DataType(DataType.MultilineText)]
        public string OtherInfo3 { get; set; }
        public string DocumentName3 { get; set; }
        public string Document3 { get; set; }


        public string Cmp_Nm4 { get; set; }
        public string Cmp_Location4 { get; set; }
        public string Division4 { get; set; }
        public string Department4 { get; set; }
        public string Title4 { get; set; }
        [DataType(DataType.Date)]
        public string FromDate4 { get; set; }
        [DataType(DataType.Date)]
        public string ToDate4 { get; set; }
        [DataType(DataType.MultilineText)]
        public string OtherInfo4 { get; set; }
        public string DocumentName4 { get; set; }
        public string Document4 { get; set; }

        public List<WkList> WkLists { get; set; }
    }

    public class WkList
    {
        /*dropdown*/
        [Display(Name = "Employee_ID")]
        public string Employee_UniqueId { get; set; }

        public string Experience { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Display(Name = "Company Location")]
        public string CompanyLocation { get; set; }
        public string Division { get; set; }
        public string Department { get; set; }
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public string FromDate { get; set; }/*from date*/
        [DataType(DataType.Date)]
        public string ToDate { get; set; }/*to date*/
        [Display(Name = "Other Information")]
        [DataType(DataType.MultilineText)]
        public string OtherInformation { get; set; }
        [Display(Name = "Doc_Name")]
        public string DocumentName { get; set; }
        public string Document { get; set; }
    }

    public class EmpCombine
    {
        public EmpBasic EmpBasics { get; set; }
        public EmpEmergency EmpEmergencys { get; set; }
        public EmpInsurance EmpInsurances { get; set; }
        public EmpBank EmpBanks { get; set; }
        public EmpEducation EmpEducations { get; set; }
        public EmpExperience EmpExperiences { get; set; }
        public EmpSalary EmpSalarys { get; set; }
        public EmpLeave EmpLeaves { get; set; }
        public EmpWorkMaiId EmpWorkMailId { get; set; }

        private EmpBasic _EmployeeBasicDetails = new EmpBasic();
        public EmpBasic EmployeeBasicDetails { get { return _EmployeeBasicDetails; } set { _EmployeeBasicDetails = value; } }

        private EmpEmergency _EmployeeEmergencyDetails = new EmpEmergency();
        public EmpEmergency EmployeeEmergencyDetails { get { return _EmployeeEmergencyDetails; } set { _EmployeeEmergencyDetails = value; } }

        private EmpInsurance _EmployeeInsuranceDetails = new EmpInsurance();
        public EmpInsurance EmployeeInsuranceDetails { get { return _EmployeeInsuranceDetails; } set { _EmployeeInsuranceDetails = value; } }


        private EmpBank _EmployeeBankDetails = new EmpBank();
        public EmpBank EmployeeBankDetails { get { return _EmployeeBankDetails; } set { _EmployeeBankDetails = value; } }

        private EmpEducation _EmployeeEducationDetails = new EmpEducation();
        public EmpEducation EmployeeEducationDetails { get { return _EmployeeEducationDetails; } set { _EmployeeEducationDetails = value; } }

        private EmpExperience _EmployeeExperienceDetails = new EmpExperience();
        public EmpExperience EmployeeExperienceDetails { get { return _EmployeeExperienceDetails; } set { _EmployeeExperienceDetails = value; } }



        private EmpSalary _EmployeeSalaryDetails = new EmpSalary();
        public EmpSalary EmployeeSalaryDetails { get { return _EmployeeSalaryDetails; } set { _EmployeeSalaryDetails = value; } }

        private EmpLeave _EmployeeLeaveDetails = new EmpLeave();
        public EmpLeave EmployeeLeaveDetails { get { return _EmployeeLeaveDetails; } set { _EmployeeLeaveDetails = value; } }
    }

    public class EmpSalary
    {
        // salary structure(Monthly Based)
        ////Earnings
        /*dropdown*/
        public string Employee { get; set; }

        [Display(Name = "Basic Salary")]
        public decimal BasicSalary { get; set; }

        [Display(Name = "Bonus")]
        public decimal Bonus { get; set; }

        [Display(Name = "Employee PF")]
        public decimal EmployeePF { get; set; }

        [Display(Name = " Onsite Bonus")]
        public decimal Onsite_Bonus { get; set; }

        [Display(Name = "T.D.S")]
        public decimal TDS { get; set; }

        [Display(Name = "Professional Tax")]
        public decimal Prof_Tax { get; set; }


        public decimal PF { get; set; }

        public decimal Advances { get; set; }

        [Display(Name = "Adjustment Date")]
        [DataType(DataType.Date)]
        public DateTime? Adjustment_Date { get; set; }

        [Display(Name = "Payment Date")]
        [DataType(DataType.Date)]
        public DateTime? Payment_Date { get; set; }

        [Display(Name = " Salary For Year")]
        public decimal Salary_for_yr { get; set; }

        [Display(Name = " Salary For Month")]
        public decimal Salary_for_mnth { get; set; }
    }

    public class EmpWorkMaiId
    {
        [Display(Name = "Employee_ID")]
        public string EmployeeId { get; set; }
        [Display(Name = "Email Id")]
        [DataType(DataType.EmailAddress)]
        public string MailId { get; set; }
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class EmpLeave
    {
        //Leave details (day based)
        ///leaves at hired date
        /*Employee dropdown*/
        public string Employee { get; set; }
        [Display(Name = "Total Paid leaves")]
        public int TotalPaidleaves { get; set; }
        [Display(Name = "Total Unpaid leaves")]
        public int TotalUnpaidleaves { get; set; }
        [Display(Name = "Total Allocation")]
        public int Totalallocation { get; set; }
    }
}