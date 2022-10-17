﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Storage;

#nullable disable

namespace Storage.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221017000709_AddNotesToStateEntry")]
    partial class AddNotesToStateEntry
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.8");

            modelBuilder.Entity("Domain.Entities.Activity", b =>
                {
                    b.Property<int>("ActivityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ActivityName")
                        .HasColumnType("TEXT");

                    b.HasKey("ActivityId");

                    b.ToTable("Activity");
                });

            modelBuilder.Entity("Domain.Entities.ActivityEntry", b =>
                {
                    b.Property<int>("ActivityEntryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ActivityId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .HasColumnType("TEXT");

                    b.Property<int?>("StateId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("ActivityEntryId");

                    b.HasIndex("ActivityId");

                    b.HasIndex("StateId");

                    b.ToTable("ActivityEntry");
                });

            modelBuilder.Entity("Domain.Entities.State", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ParentStateID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StateName")
                        .HasColumnType("TEXT");

                    b.HasKey("StateId");

                    b.ToTable("State");
                });

            modelBuilder.Entity("Domain.Entities.StateEntry", b =>
                {
                    b.Property<int>("StateEntryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .HasColumnType("TEXT");

                    b.Property<int>("StateId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("StateEntryId");

                    b.HasIndex("StateId");

                    b.ToTable("StateEntry");
                });

            modelBuilder.Entity("Domain.Entities.ActivityEntry", b =>
                {
                    b.HasOne("Domain.Entities.Activity", "Activity")
                        .WithMany()
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId");

                    b.Navigation("Activity");

                    b.Navigation("State");
                });

            modelBuilder.Entity("Domain.Entities.StateEntry", b =>
                {
                    b.HasOne("Domain.Entities.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });
#pragma warning restore 612, 618
        }
    }
}
