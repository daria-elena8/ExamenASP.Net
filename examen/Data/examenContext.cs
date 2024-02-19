﻿using examen.Models.Many_to_Many;
using examen.Models.One_to_Many;
using examen.Models.One_to_One;
using examen.Models;
using Microsoft.EntityFrameworkCore;

namespace examen.Data
{
    public class examenContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }

        // One to Many
        public DbSet<Model1> Models1 { get; set; }
        public DbSet<Model2> Models2 { get; set; }


        // One to One
        public DbSet<Model5> Models5 { get; set; }
        public DbSet<Model6> Models6 { get; set; }

        // Many to Many

        public DbSet<Model3> Models3 { get; set; }
        public DbSet<Model4> Models4 { get; set; }
        public DbSet<ModelsRelation> ModelsRelations { get; set; }


        public DbSet<User> Users { get; set; }
        public examenContext(DbContextOptions<examenContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One to Many
            modelBuilder.Entity<Model1>()
                        .HasMany(m1 => m1.Models2)
                        .WithOne(m2 => m2.Model1);


            // One to One
            modelBuilder.Entity<Model5>()
                .HasOne(m5 => m5.Model6)
                .WithOne(m6 => m6.Model5)
                .HasForeignKey<Model6>(m6 => m6.Model5Id);


            // Many to Many
            modelBuilder.Entity<ModelsRelation>().HasKey(mr => new { mr.Model3Id, mr.Model4Id });

            // One to many for m-m
            modelBuilder.Entity<ModelsRelation>()
                        .HasOne(mr => mr.Model3)
                        .WithMany(m3 => m3.ModelsRelations)
                        .HasForeignKey(mr => mr.Model3Id);

            modelBuilder.Entity<ModelsRelation>()
                        .HasOne(mr => mr.Model4)
                        .WithMany(m4 => m4.ModelsRelations)
                        .HasForeignKey(mr => mr.Model4Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
