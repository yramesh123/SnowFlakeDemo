using MedTronic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedTronic.Repositories
{
    public class GenericDbContext : DbContext
    {
        public DbSet<StudentModel> Students { get; set; }

        public DbSet<TeacherModel> Teachers { get; set; }

        public DbSet<TeacherStudentLinkModel> TeacherStudents { get; set; }

        public GenericDbContext(DbContextOptions<GenericDbContext> dc) : base(dc)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}
