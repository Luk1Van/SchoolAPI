﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolAPI.Data;

#nullable disable

namespace SchoolAPI.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    [Migration("20230513001004_addedFinals")]
    partial class addedFinals
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.Property<int>("StudentsId")
                        .HasColumnType("int");

                    b.HasKey("CoursesId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("CourseStudent");
                });

            modelBuilder.Entity("SchoolAPI.Data.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfClasses")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Microsoft Web Services",
                            NumberOfClasses = 32
                        },
                        new
                        {
                            Id = 2,
                            Name = "ASP.NET Core MVC",
                            NumberOfClasses = 44
                        },
                        new
                        {
                            Id = 3,
                            Name = "Introduction To Web Development",
                            NumberOfClasses = 32
                        });
                });

            modelBuilder.Entity("SchoolAPI.Data.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Microsoft Web Development"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Microsoft Dekstop Development"
                        });
                });

            modelBuilder.Entity("SchoolAPI.Data.Entities.Final", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Mark")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("Finals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseId = 1,
                            Date = new DateTime(2023, 5, 13, 0, 0, 0, 0, DateTimeKind.Local),
                            Mark = 10,
                            Name = "Example",
                            StudentId = 1
                        },
                        new
                        {
                            Id = 2,
                            CourseId = 1,
                            Date = new DateTime(2023, 5, 13, 0, 0, 0, 0, DateTimeKind.Local),
                            Mark = 10,
                            Name = "Example",
                            StudentId = 2
                        },
                        new
                        {
                            Id = 3,
                            CourseId = 2,
                            Date = new DateTime(2023, 5, 13, 0, 0, 0, 0, DateTimeKind.Local),
                            Mark = 10,
                            Name = "Example",
                            StudentId = 1
                        });
                });

            modelBuilder.Entity("SchoolAPI.Data.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DepartmentId = 1,
                            FirstName = "John",
                            LastName = "Doe"
                        },
                        new
                        {
                            Id = 2,
                            DepartmentId = 1,
                            FirstName = "Mary",
                            LastName = "Doe"
                        });
                });

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.HasOne("SchoolAPI.Data.Entities.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolAPI.Data.Entities.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolAPI.Data.Entities.Final", b =>
                {
                    b.HasOne("SchoolAPI.Data.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolAPI.Data.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SchoolAPI.Data.Entities.Student", b =>
                {
                    b.HasOne("SchoolAPI.Data.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });
#pragma warning restore 612, 618
        }
    }
}
