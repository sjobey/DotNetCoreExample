using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeLosRiosCredit.Models
{
    public class Applicant
    {
        [Key]
        public int ApplicantId { get; set; }

        public  string FirstName { get; set; }
        public string LastName { get; set; }

        public int? FICO { get; set; }

        public string SSN { get; set; }

        public int IncomeAnnual { get; set; }

        public float DTI { get; set; }

        public DateTime DOB { get; set; }


        //--------------------------------------------------

        public ICollection<CreditApplication> CreditApplications { get; set; }
    }
}
