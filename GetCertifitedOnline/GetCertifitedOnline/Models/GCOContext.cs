using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetCertifitedOnline.Entities;
using GetCertifitedOnline.Repository;
using GetCertifitedOnline.DTO;
using GetCertifitedOnline.Models;

namespace GetCertifitedOnline.Models
{
    public partial class GCOContext : DbContext
    {
        public GCOContext(DbContextOptions<GCOContext> options) : base(options)
        {
        }
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CertificationExam> CertificationExams { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=AVIJIT;Initial Catalog=GCO;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

          //  OnModelCreatingPartial(modelBuilder);
        }

      //  partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

       
}

