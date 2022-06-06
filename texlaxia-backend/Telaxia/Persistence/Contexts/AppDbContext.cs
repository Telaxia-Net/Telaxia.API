using Microsoft.EntityFrameworkCore;
using Telaxia_Backend.Telaxia.Domain.Models;

namespace Telaxia_Backend.Telaxia.Persistence.Contexts;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Cooperative>Cooperatives { get; set; }
    public DbSet<Date>Dates { get; set; }
    public DbSet<Design>Designs { get; set; }
    public DbSet<Information>Informations { get; set; }
    public DbSet<Plan>Plans { get; set; }
    public DbSet<Post>Posts { get; set; }
    public DbSet<Profile>Profiles { get; set; }
    public DbSet<User>Users { get; set; }
    public DbSet<UserType>UserTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        /*-----------------------Properties and keys-----------------------*/
        //User
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p=>p.Name).IsRequired().HasMaxLength(20);
        builder.Entity<User>().Property(p=>p.LastName).IsRequired().HasMaxLength(20);
        builder.Entity<User>().Property(p=>p.Phone).HasMaxLength(15);
        builder.Entity<User>().Property(p=>p.Mail).IsRequired().HasMaxLength(20);
        //Plan
        builder.Entity<Plan>().ToTable("Plans");
        builder.Entity<Plan>().HasKey(p => p.Id);
        builder.Entity<Plan>().Property(p => p.Id).IsRequired();
        builder.Entity<Plan>().Property(p => p.Name);
        builder.Entity<Plan>().Property(p => p.Price);
        //Design
        builder.Entity<Design>().ToTable("Designs");
        builder.Entity<Design>().HasKey(p => p.Id);
        builder.Entity<Design>().Property(p=>p.Id).IsRequired();
        //Information
        builder.Entity<Information>().ToTable("Informations");
        builder.Entity<Information>().HasKey(p => p.Id);
        builder.Entity<Information>().Property(p=>p.Id).IsRequired();
        builder.Entity<Information>().Property(p=>p.Views);
        //Post
        builder.Entity<Post>().ToTable("Posts");
        builder.Entity<Post>().HasKey(p => p.Id);
        builder.Entity<Post>().Property(p=>p.Id).IsRequired();
        builder.Entity<Post>().Property(p=>p.PostLike);
        //Profile
        builder.Entity<Profile>().ToTable("Profiles");
        builder.Entity<Profile>().Property(p=>p.Id).IsRequired();
        builder.Entity<Profile>().Property(p=>p.Description);
        builder.Entity<Profile>().Property(p=>p.Rating);
        //UserType
        builder.Entity<UserType>().ToTable("UserTypes");
        builder.Entity<UserType>().Property(p=>p.Id).IsRequired();
        builder.Entity<UserType>().Property(p=>p.Type);
        //Cooperative
        builder.Entity<Cooperative>().ToTable("Cooperatives");
        builder.Entity<Cooperative>().HasKey(p=>p.Id);
        builder.Entity<Cooperative>().Property(p=>p.Id);
        builder.Entity<Cooperative>().Property(p => p.Host).IsRequired().HasMaxLength(30);
        builder.Entity<Cooperative>().Property(p => p.Editor).IsRequired().HasMaxLength(30);
        
        /*-----------------------Relationships and Foreignkeys-----------------------*/
        //User
        builder.Entity<User>()
            .HasOne(p => p.Plan)
            .WithOne(p => p.User)
            .HasForeignKey<User>(p => p.PlanId);
        builder.Entity<User>()
            .HasOne(p => p.UserType)
            .WithOne(p => p.User)
            .HasForeignKey<User>(p => p.UserTypeId);
        builder.Entity<User>()
            .HasMany(p => p.Profiles)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);
        //Design
        builder.Entity<Design>()
            .HasOne(p => p.DateCreated)
            .WithMany(p => p.Designs_DateCreated)
            .HasForeignKey(p => p.DateCreatedId)
            .HasForeignKey(p => p.DateCreatedId);
        builder.Entity<Design>()
            .HasOne(p => p.DateEdited)
            .WithMany(p => p.Designs_DateEdited)
            .HasForeignKey(p => p.DateEditedId);
        builder.Entity<Design>()
            .HasOne(p => p.User)
            .WithMany(p => p.Designs)
            .HasForeignKey(p => p.UserId);
        builder.Entity<Design>()
            .HasOne(p => p.Post)
            .WithOne(p => p.Design)
            .HasForeignKey<Post>(p => p.DesignId);
        //Information
        builder.Entity<Information>()
            .HasOne(p => p.PostLikes)
            .WithOne(p => p.Information)
            .HasForeignKey<Information>(p => p.PostLikesId);
        //Post
        builder.Entity<Post>()
            .HasOne(p => p.DatePosted)
            .WithMany(p => p.Posts)
            .HasForeignKey(p => p.DatePostedId);
        builder.Entity<Post>()
            .HasOne(p => p.Profile)
            .WithMany(p => p.Posts)
            .HasForeignKey(p => p.ProfileId);
        //Cooperative 
        builder.Entity<Cooperative>()
            .HasOne(p => p.User)
            .WithMany(p => p.Cooperatives)
            .HasForeignKey(p => p.UserId);
        builder.Entity<Cooperative>()
            .HasOne(p => p.Design)
            .WithOne(p => p.Cooperative)
            .HasForeignKey<Cooperative>(p => p.DesignId);
        
        //Apply Naming Conventions
        //builder.UseSnakeCaseNamingConvention();
    }
}