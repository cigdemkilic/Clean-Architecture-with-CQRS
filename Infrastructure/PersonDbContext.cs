﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Infrastructure
{
      public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
        {
        }

        public DbSet<Persons> Person { get; set; }

        // Diğer sınıf tanımlamaları...

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Bu metodda veritabanı tablolarının nasıl oluşturulacağı ve ilişkilendirileceği belirtilir.
            // Örneğin, tabloların isimlendirme kuralları, ilişkilerin tanımlanması vb. işlemler burada yapılabilir.
            
            modelBuilder.Entity<Persons>().ToTable("Person");
            modelBuilder.Entity<Persons>().HasKey(p => p.Id);

            // Eğer varsa diğer tablo ve ilişkilerin konfigürasyonları da burada yapılmalı.
        }
    }
}
