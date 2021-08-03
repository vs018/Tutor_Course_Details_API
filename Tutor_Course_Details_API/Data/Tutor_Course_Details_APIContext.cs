using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tutor_Course_Details_API.Models;

namespace Tutor_Course_Details_API.Data
{
    public class Tutor_Course_Details_APIContext : DbContext
    {
        public Tutor_Course_Details_APIContext (DbContextOptions<Tutor_Course_Details_APIContext> options)
            : base(options)
        {
        }

        public DbSet<Tutor_Course_Details_API.Models.TutorDetails> TutorDetails { get; set; }
    }
}
