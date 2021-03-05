using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeLosRiosCredit.Models
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Abbreviation { get; set; }

        public int Rank { get; set; }

        //-----------------------------------------------------------------

        public ICollection<CreditApplication> CreditApplications { get; set; }

    }
}
