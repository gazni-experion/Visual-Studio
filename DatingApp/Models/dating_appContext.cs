using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DatingApp.Models
{
    public partial class dating_appContext : DbContext
    {
        public dating_appContext()
        {
        }

        public dating_appContext(DbContextOptions<dating_appContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Food> Food { get; set; }
        public virtual DbSet<Food2> Food2 { get; set; }
        public virtual DbSet<Hobbies> Hobbies { get; set; }
        public virtual DbSet<MovieGenres> MovieGenres { get; set; }
        public virtual DbSet<Occupation> Occupation { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source= MOHAMMEDGASNI; Initial Catalog= dating_app; Integrated security=True");
            }
        }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__Customer__CD65CB85EABE949D");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Food2Id).HasColumnName("food2_id");

                entity.Property(e => e.FoodId).HasColumnName("food_id");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnName("gender")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.Property(e => e.HobbyId).HasColumnName("hobby_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OccupationId).HasColumnName("occupation_id");

                entity.HasOne(d => d.Food2)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.Food2Id)
                    .HasConstraintName("FK__Customers__food2__4D94879B");

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.FoodId)
                    .HasConstraintName("FK__Customers__food___4CA06362");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK__Customers__genre__5070F446");

                entity.HasOne(d => d.Hobby)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.HobbyId)
                    .HasConstraintName("FK__Customers__hobby__4F7CD00D");

                entity.HasOne(d => d.Occupation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.OccupationId)
                    .HasConstraintName("FK__Customers__occup__4E88ABD4");
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.Property(e => e.FoodId).HasColumnName("food_id");

                entity.Property(e => e.FoodName)
                    .IsRequired()
                    .HasColumnName("food_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Food2>(entity =>
            {
                entity.HasKey(e => e.FoodId)
                    .HasName("PK__Food2__2F4C4DD8434EDBDB");

                entity.Property(e => e.FoodId).HasColumnName("food_id");

                entity.Property(e => e.FoodName)
                    .IsRequired()
                    .HasColumnName("food_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Hobbies>(entity =>
            {
                entity.HasKey(e => e.HobbyId)
                    .HasName("PK__Hobbies__ABCB3D347B7DDD48");

                entity.Property(e => e.HobbyId).HasColumnName("hobby_id");

                entity.Property(e => e.Hobby)
                    .IsRequired()
                    .HasColumnName("hobby")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MovieGenres>(entity =>
            {
                entity.HasKey(e => e.GenreId)
                    .HasName("PK__Movie_ge__18428D42B1D5C23B");

                entity.ToTable("Movie_genres");

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.Property(e => e.Genres)
                    .IsRequired()
                    .HasColumnName("genres")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Occupation>(entity =>
            {
                entity.Property(e => e.OccupationId).HasColumnName("occupation_id");

                entity.Property(e => e.Occupation1)
                    .IsRequired()
                    .HasColumnName("occupation")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
