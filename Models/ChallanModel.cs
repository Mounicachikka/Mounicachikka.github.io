using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SaazApplication.Models
{
    public class ChallanModel
    {
        [Display(Name = "DC Number")]
        public string DC_Number { get; set; }

        public int ID { get; set; }
        //public string CompanyName { get; set; }
        //Address
        [Display(Name = "From Company")]
        public string From_Company { get; set; }
        [DataType(DataType.Date)]
        public string Date { get; set; }

        [Display(Name = "To Address")]
        [DataType(DataType.MultilineText)]
        public string ToAddress { get; set; }

        [DataType(DataType.MultilineText)]
        public string Subject { get; set; }

        [DataType(DataType.MultilineText)]
        public string Matter { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string Quantity { get; set; }

        [Display(Name = "Returnable/Non-Returnable")]
        public string Returnable { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description1 { get; set; }
        public string Quantity1 { get; set; }
        public string Returnable1 { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description2 { get; set; }
        public string Quantity2 { get; set; }
        public string Returnable2 { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description3 { get; set; }
        public string Quantity3 { get; set; }
        public string Returnable3 { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description4 { get; set; }
        public string Quantity4 { get; set; }
        public string Returnable4 { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description5 { get; set; }
        public string Quantity5 { get; set; }
        public string Returnable5 { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description6 { get; set; }
        public string Quantity6 { get; set; }
        public string Returnable6 { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description7 { get; set; }
        public string Quantity7 { get; set; }
        public string Returnable7 { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description8 { get; set; }
        public string Quantity8 { get; set; }
        public string Returnable8 { get; set; }

    }


}