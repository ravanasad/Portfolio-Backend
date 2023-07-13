using Domain.Entities;
using Domain.Entities.Files;
using Domain.Entities.Identity;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class BaseContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public BaseContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<UserAbout> UserAbouts { get; set; }
        public DbSet<Domain.Entities.Files.File> Files { get; set; }
       

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppUser>().Ignore(i => i.UserName);

            builder.Entity<AppUser>()
                .HasOne(i => i.UserAbout)
                .WithOne(j => j.AppUser)
                .HasForeignKey<UserAbout>(j => j.AppUserId);

            //builder.Entity<UserAbout>().HasOne(i => i.ProfileImageFile).WithOne(j => j.UserAbout)
            //    .HasForeignKey<ProfileImageFile>(j=>j.UserAboutId);

            //builder.Entity<BlogImageFile>().HasOne(i=>i.Blog)
            //    .WithMany(i=>i.BlogImageFiles)
            //    .HasForeignKey(j=>j.BlogId)
            //    .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(builder);
        }
    }

}
