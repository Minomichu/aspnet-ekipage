using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ekipage.Models;

namespace ekipage.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Horse> Horse { get; set; }
        public DbSet<Rider> Rider { get; set; }
        public DbSet<DateForLesson> DateForLesson { get; set; }
        public DbSet<LessonContent> LessonContent { get; set; }
    }
}
