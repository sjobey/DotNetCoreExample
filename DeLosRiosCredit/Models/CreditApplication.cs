using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeLosRiosCredit.Models
{
    public class CreditApplication
    {
        [Key]
        public int CreditApplicationId { get; set; }

        [Required]
        public float LoanAmount { get; set; }

        public float APR { get; set; }

        public int TermMonths { get; set; }

        public string Product { get; set; }

        //------------------------------------------------

        public int? ApplicantId { get; set; }

        public Applicant Applicant { get; set; }

        public int? StatusId { get; set; }

        public Status Status { get; set; }


    }
}
