﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SaazApplication.Models
{
    public class Invoice
    {
        [Display(Name = "Id")]
        public Nullable<int> ID { get; set; }

        [Display(Name = "Invoice Number")]
        public string IV_Number { get; set; }

        //Address
        [Display(Name = "From Company")]
        public string From_Company { get; set; }

        [DataType(DataType.Date)]
        public string Date { get; set; }

        [Display(Name = "Mode Of Payment")]
        public string M_O_P { get; set; }

        [Display(Name = "Exporters RefNo")]
        public string Exp_Ref_No { get; set; }

        [Display(Name = "PO Number")]
        public string PONo { get; set; }

        [Display(Name = "PO Date")]
        [DataType(DataType.Date)]
        public string PO_Date { get; set; }

        [Display(Name = "Dispatch Through")]
        public string Disp_Through { get; set; }

        [Display(Name = "Destination")]
        public string Destination { get; set; }

        [Display(Name = "Terms Of-Delivery")]
        public string TermsOfDelivery { get; set; }

        [Display(Name = "Shipping Terms")]
        public string ShippingTerms { get; set; }

        [Display(Name = "ServiceTax Number")]
        public string ServiceTaxNumber { get; set; }

        [Display(Name = "To Address")]
        [DataType(DataType.MultilineText)]
        public string ToAddress { get; set; }

        [Display(Name = "Currency")]
        public string Currency { get; set; }

        [Display(Name = "Bank Name")]
        public string BankName { get; set; }
        [Display(Name = "Account Number")]
        public string AccountNumber { get; set; }
        [Display(Name = "Branch Name")]
        public string Branch { get; set; }
        [Display(Name = "SWIFT/IFSC code")]
        public string SWIFT_code { get; set; }


        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public Nullable<int> Quantity { get; set; }

        [Display(Name = "Rate")]
        public Nullable<decimal> Rate { get; set; }

        [Display(Name = "TotalAmount")]
        public Nullable<decimal> TotalAmount { get; set; }

        public string Per { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description1 { get; set; }
        public int Quantity1 { get; set; }
        public decimal Rate1 { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description2 { get; set; }
        public int Quantity2 { get; set; }
        public decimal Rate2 { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description3 { get; set; }
        public int Quantity3 { get; set; }
        public decimal Rate3 { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description4 { get; set; }
        public int Quantity4 { get; set; }
        public decimal Rate4 { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description5 { get; set; }
        public int Quantity5 { get; set; }
        public decimal Rate5 { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description6 { get; set; }
        public int Quantity6 { get; set; }
        public decimal Rate6 { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description7 { get; set; }
        public int Quantity7 { get; set; }
        public decimal Rate7 { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description8 { get; set; }
        public int Quantity8 { get; set; }
        public decimal Rate8 { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description9 { get; set; }
        public int Quantity9 { get; set; }
        public decimal Rate9 { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description10 { get; set; }
        public int Quantity10 { get; set; }
        public decimal Rate10 { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description11 { get; set; }
        public int Quantity11 { get; set; }
        public decimal Rate11 { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description12 { get; set; }
        public string Quantity12 { get; set; }
        public decimal Rate12 { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description13 { get; set; }
        public int Quantity13 { get; set; }
        public decimal Rate13 { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description14 { get; set; }
        public string Quantity14 { get; set; }
        public decimal Rate14 { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description15 { get; set; }
        public int Quantity15 { get; set; }
        public decimal Rate15 { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description16 { get; set; }
        public int Quantity16 { get; set; }
        public decimal Rate16 { get; set; }
    }
}