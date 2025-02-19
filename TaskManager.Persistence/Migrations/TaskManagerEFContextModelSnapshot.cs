﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManager.Persistence.Contexts;

#nullable disable

namespace TaskManager.Persistence.Migrations
{
    [DbContext(typeof(TaskManagerEFContext))]
    partial class TaskManagerEFContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("TaskManager.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TaskManager.Models.Labor", b =>
                {
                    b.Property<int>("LaborId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateExpiration")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("TEXT");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LaborId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Labor");

                    b.HasDiscriminator().HasValue("Labor");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("TaskManager.Models.RecurringLabor", b =>
                {
                    b.HasBaseType("TaskManager.Models.Labor");

                    b.Property<DateTime>("NextExecution")
                        .HasColumnType("TEXT");

                    b.Property<int>("Recurence")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RecurringLaborId")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("RecurringLabor");
                });

            modelBuilder.Entity("TaskManager.Models.SimpleLabor", b =>
                {
                    b.HasBaseType("TaskManager.Models.Labor");

                    b.Property<int?>("SimpleLaborId")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("SimpleLabor");
                });

            modelBuilder.Entity("TaskManager.Models.Labor", b =>
                {
                    b.HasOne("TaskManager.Models.Category", "Category")
                        .WithMany("Labors")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("TaskManager.Models.Category", b =>
                {
                    b.Navigation("Labors");
                });
#pragma warning restore 612, 618
        }
    }
}
