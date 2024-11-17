using Microsoft.EntityFrameworkCore;
using PortofolioBackend.Data.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<Project> Projects { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Admin> Admins { get; set; }
}