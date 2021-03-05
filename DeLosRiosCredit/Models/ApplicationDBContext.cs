using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeLosRiosCredit.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        //Add one DBSet per Class/Table here!!!
        //In packageManagerConsole use the Command: 'Add-Migration "WhateverName"' to create a migration
        //You can then use the command: 'Update-Database' to make a change. This can be done multiple times per migration.

        public DbSet<Applicant> Applicants { get; set; }

        public DbSet<CreditApplication> CreditApplications { get; set; }

        public DbSet<Status> Status { get; set; }

    }
}
