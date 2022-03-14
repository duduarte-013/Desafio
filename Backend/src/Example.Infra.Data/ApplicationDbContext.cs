using Example.Domain.Persons;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Infra.Data;

public class ApplicationDbContext: DbContext
{
    public DbSet<Person> Persons { get; set; }  
    public DbSet<City> Cities { get; set;  }


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {

        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Ignore<Notification>();

        builder.Entity<Person>()
           .Property(p => p.Name)
           .IsRequired();
        builder.Entity<Person>()
          .Property(p => p.Name)
          .HasMaxLength(300);
        builder.Entity<Person>()
           .Property(p => p.Cpf)
           .IsRequired();
        builder.Entity<Person>()
          .Property(p => p.Cpf)
         .HasMaxLength(11);
        builder.Entity<Person>()
           .Property(p => p.Age)
           .IsRequired();

        builder.Entity<City>()
           .Property(p => p.Name)
           .IsRequired();
        builder.Entity<City>()
          .Property(p => p.Name)
         .HasMaxLength(200);
        builder.Entity<City>()
         .Property(p => p.Uf)
        .IsRequired();
        builder.Entity<City>()
        .Property(p => p.Uf)
       .HasMaxLength(2);

        builder.Entity<City>().HasData(new City {Id = 1, Name = "São Paulo", Uf="SP" }, 
                                       new City { Id = 2, Name = "Rio de Janeiro", Uf = "Rj" });
    }

}
