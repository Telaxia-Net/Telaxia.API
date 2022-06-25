using Microsoft.EntityFrameworkCore;
using texlaxia_backend.Shared.Extensions;
using texlaxia_backend.Telaxia.Domain.Models;

namespace texlaxia_backend.Telaxia.Persistence.Contexts;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Buyer>Buyers { get; set; }
    public DbSet<Collaborator>Collaborators { get; set; }
    public DbSet<Comment>Comments { get; set; }
    public DbSet<Design>Designs { get; set; }
    public DbSet<DesignCollaborator>DesignCollaborators { get; set; }
    public DbSet<Designer>Designers { get; set; }
    public DbSet<Plan>Plans { get; set; }
    public DbSet<Post>Posts { get; set; }
    public DbSet<PostDesign>PostDesigns { get; set; }
    public DbSet<Purchase>Purchases { get; set; }
    public DbSet<User>Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        /*-----------------------Properties and keys-----------------------*/
        
        //Buyer
        builder.Entity<Buyer>().ToTable("Buyers");
        builder.Entity<Buyer>().HasKey(p => p.UserId);
        builder.Entity<Buyer>().Property(p=>p.UserId).IsRequired();
        
        //Collaborator
        builder.Entity<Collaborator>().ToTable("Collaborators");
        builder.Entity<Collaborator>().HasKey(p => p.DesignerId);
        builder.Entity<Collaborator>().Property(p=>p.DesignerId).IsRequired();
        builder.Entity<Collaborator>().Property(p=>p.Type);
        
        //Comment
        builder.Entity<Comment>().ToTable("Comments");
        builder.Entity<Comment>().HasKey(p => p.Id);
        builder.Entity<Comment>().Property(p=>p.Id).IsRequired();
        builder.Entity<Comment>().Property(p=>p.date);
        builder.Entity<Comment>().Property(p=>p.body);
        
        //Design
        builder.Entity<Design>().ToTable("Designs");
        builder.Entity<Design>().HasKey(p => p.Id);
        builder.Entity<Design>().Property(p=>p.Id).IsRequired();
        builder.Entity<Design>().Property(p => p.DesignViewUrl).HasMaxLength(500);
        builder.Entity<Design>().Property(p => p.ImageDesign).HasMaxLength(500);
        builder.Entity<Design>().Property(p => p.Visibility);
        
        //Design Collaborator
        builder.Entity<DesignCollaborator>().ToTable("DesignCollaborators");
        builder.Entity<DesignCollaborator>().HasKey(p => p.DesignId);
        builder.Entity<DesignCollaborator>().HasKey(p => p.CollaboratorId);
        builder.Entity<DesignCollaborator>().Property(p=>p.DesignId).IsRequired();
        builder.Entity<DesignCollaborator>().Property(p=>p.CollaboratorId).IsRequired();
        builder.Entity<DesignCollaborator>().Property(p => p.Description).HasMaxLength(300);
        builder.Entity<DesignCollaborator>().Property(p => p.Name).HasMaxLength(300);
        
        //Designer
        builder.Entity<Designer>().ToTable("Designer");
        builder.Entity<Designer>().HasKey(p => p.UserId);
        builder.Entity<Designer>().Property(p=>p.UserId).IsRequired();
        
        //Plan
        builder.Entity<Plan>().ToTable("Plans");
        builder.Entity<Plan>().HasKey(p => p.Id);
        builder.Entity<Plan>().Property(p => p.Id).IsRequired();
        builder.Entity<Plan>().Property(p => p.Name).HasMaxLength(50);
        builder.Entity<Plan>().Property(p => p.Price);
        builder.Entity<Plan>().Property(p => p.Description).HasMaxLength(200);
        
        //Post
        builder.Entity<Post>().ToTable("Posts");
        builder.Entity<Post>().HasKey(p => p.Id);
        builder.Entity<Post>().Property(p=>p.Id).IsRequired();
        builder.Entity<Post>().Property(p=>p.PostLike);
        builder.Entity<Post>().Property(p=>p.Description).HasMaxLength(500);
        builder.Entity<Post>().Property(p=>p.Title).HasMaxLength(100);
        
        //PostDesign
        builder.Entity<PostDesign>().ToTable("PostDesigns");
        builder.Entity<PostDesign>().HasKey(p => p.PostId);
        builder.Entity<PostDesign>().HasKey(p => p.DesignId);
        builder.Entity<PostDesign>().Property(p=>p.PostId).IsRequired();
        builder.Entity<PostDesign>().Property(p=>p.DesignId).IsRequired();
        
        //Purchase
        builder.Entity<Purchase>().ToTable("Purchases");
        builder.Entity<Purchase>().HasKey(p => p.Id);
        builder.Entity<Purchase>().Property(p=>p.Id).IsRequired();
        builder.Entity<Purchase>().Property(p=>p.Amount);
        builder.Entity<Purchase>().Property(p=>p.PayMethod);
        
        //User
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p=>p.Id).IsRequired();
        builder.Entity<User>().Property(p=>p.FirstName).HasMaxLength(40);
        builder.Entity<User>().Property(p=>p.LastName).HasMaxLength(40);
        builder.Entity<User>().Property(p=>p.Phone).HasMaxLength(15);
        builder.Entity<User>().Property(p=>p.Mail).HasMaxLength(200);
        builder.Entity<User>().Property(p=>p.Rating);

        /*----------------------- Relationships and Foreignkeys -----------------------*/
        
        // --------------------------- USER -------------------------------- //
        
        //User with Plan
        builder.Entity<User>()
            .HasOne(p => p.Plan)
            .WithMany(p => p.Users)
            .HasForeignKey(p => p.PlanId);
        
        //Buyer with User
        builder.Entity<Buyer>()
            .HasOne(p => p.User)
            .WithOne(p => p.Buyer)
            .HasForeignKey<Buyer>(p => p.UserId)
            .IsRequired(false);
        
        //User with Comment
        builder.Entity<User>()
            .HasMany(p => p.Comments)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);
        
        // --------------------------- DESIGNER -------------------------------- //
        
        //Designer with User
        builder.Entity<Designer>()
            .HasOne(p => p.User)
            .WithOne(p => p.Designer)
            .HasForeignKey<Designer>(p => p.UserId)
            .IsRequired(false);
      
        //Design with Purchase
        builder.Entity<Design>()
            .HasMany(p => p.Purchases)
            .WithOne(p => p.Design)
            .HasForeignKey(p => p.DesignId);
        
        //Design with PostDesign
        builder.Entity<Design>()
            .HasMany(p => p.PostDesigns)
            .WithOne(p => p.Design)
            .HasForeignKey(p => p.DesignId)
            .IsRequired(false);
        
        //Design with Designer
        builder.Entity<Design>()
            .HasOne(p => p.Designer)
            .WithMany(p => p.Designs)
            .HasForeignKey(p => p.DesignerId);
        
        //Design with DesignCollaborator
        builder.Entity<Design>()
            .HasMany(p => p.DesignCollaborators)
            .WithOne(p => p.Design)
            .HasForeignKey(p => p.DesignId)
            .IsRequired(false);
        
        // ------------------------------ POST ------------------------------- //
        
        //Post with Comment
        builder.Entity<Post>()
            .HasMany(p => p.Comments)
            .WithOne(p => p.Post)
            .HasForeignKey(p => p.PostId);
        
        //Post with Designer
        builder.Entity<Post>()
            .HasOne(p => p.Designer)
            .WithMany(p => p.Posts)
            .HasForeignKey(p => p.DesignerId);
        
        //Post with PostDesign
        builder.Entity<Post>()
            .HasMany(p => p.PostDesigns)
            .WithOne(p => p.Post)
            .HasForeignKey(p => p.PostId)
            .IsRequired(false);
        
        // ------------------------------ PURCHASE ----------------------------- //

        //Purchase with Buyer
        builder.Entity<Purchase>()
            .HasOne(p => p.Buyer)
            .WithMany(p => p.Purchases)
            .HasForeignKey(p => p.BuyerId);
        
        // ------------------------------ COLLABORATOR ----------------------------- //
        
        //Collaborator with Designer
        builder.Entity<Collaborator>()
            .HasOne(p => p.Designer)
            .WithMany(p => p.Collaborators)
            .HasForeignKey(p => p.DesignerId)
            .IsRequired(false);
        
        //Collaborator with DesignCollaborator
        builder.Entity<Collaborator>()
            .HasMany(p => p.DesignCollaborators)
            .WithOne(p => p.Collaborator)
            .HasForeignKey(p => p.CollaboratorId)
            .IsRequired(false);

        //Apply Naming Conventions
        builder.UseSnakeCaseNamingConvention();
    }
}