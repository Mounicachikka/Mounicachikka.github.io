using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SaazApplication.Models
{
    public class SalaryModel
    {

        public string Employee { get; set; }

        [Display(Name = "Basic Salary")]
        public decimal BasicSalary { get; set; }


        [Display(Name = "HRA")]
        public decimal HRA { get; set; }

        [Display(Name = "Special Allowance")]
        public decimal SPL_ALW { get; set; }

        [Display(Name = "Conveyance Allowance")]
        public decimal Con_ALW { get; set; }

        [Display(Name = "Medical Payment")]
        public decimal MedicalReimbursement { get; set; }

        [Display(Name = "Anual Bonus")]
        public decimal AnualBonus { get; set; }

        [Display(Name = " Others")]
        public decimal Other { get; set; }

        [Display(Name = " Location Allowance")]
        public decimal Loc_ALW { get; set; }

        [Display(Name = "T.D.S")]
        public decimal TDS { get; set; }

        [Display(Name = "Professional Tax")]
        public decimal Prof_Tax { get; set; }


        public decimal PF { get; set; }

        public decimal Advances { get; set; }

        [Display(Name = "Re imbursement")]
        public decimal Reimbursement { get; set; }

        [Display(Name = "Adjustment Date")]
        [DataType(DataType.Date)]
        public string Adjustment_Date { get; set; }

        [Display(Name = "Payment Date")]
        [DataType(DataType.Date)]
        public string Payment_Date { get; set; }

        [Display(Name = " For Year")]
        public string Salary_for_yr { get; set; }

        [Display(Name = " For Month")]
        public string Salary_for_mnth { get; set; }

        [Display(Name = " Days Paid")]
        public int Days_Paid { get; set; }
    }
}