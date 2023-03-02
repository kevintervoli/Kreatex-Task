﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskKevin.ModelsLibrary.Data.Model;

namespace TaskKevin.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230202184542_minorChanges1")]
    partial class minorChanges1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectsUser", b =>
                {
                    b.Property<int>("ProjectLinkprojectId")
                        .HasColumnType("int");

                    b.Property<int>("Userid")
                        .HasColumnType("int");

                    b.HasKey("ProjectLinkprojectId", "Userid");

                    b.HasIndex("Userid");

                    b.ToTable("ProjectsUser");
                });

            modelBuilder.Entity("TaskKevin.Data.Model.Projects", b =>
                {
                    b.Property<int>("projectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("dateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("projectData")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("projectName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("projectId");

                    b.ToTable("projectsTable");
                });

            modelBuilder.Entity("TaskKevin.Data.Model.Roles", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RoleId");

                    b.ToTable("rolesTable");
                });

            modelBuilder.Entity("TaskKevin.Data.Model.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ProjectsprojectId")
                        .HasColumnType("int");

                    b.Property<bool>("completed")
                        .HasColumnType("bit");

                    b.Property<int>("taskName")
                        .HasMaxLength(256)
                        .HasColumnType("int");

                    b.Property<int>("taskProperties")
                        .HasMaxLength(512)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectsprojectId");

                    b.ToTable("taskTable");
                });

            modelBuilder.Entity("TaskKevin.Data.Model.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("rolesId")
                        .HasColumnType("int");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("id");

                    b.HasIndex("rolesId")
                        .IsUnique();

                    b.ToTable("userTable");
                });

            modelBuilder.Entity("TaskUser", b =>
                {
                    b.Property<int>("TaskLinkId")
                        .HasColumnType("int");

                    b.Property<int>("UserLinkid")
                        .HasColumnType("int");

                    b.HasKey("TaskLinkId", "UserLinkid");

                    b.HasIndex("UserLinkid");

                    b.ToTable("TaskUser");
                });

            modelBuilder.Entity("ProjectsUser", b =>
                {
                    b.HasOne("TaskKevin.Data.Model.Projects", null)
                        .WithMany()
                        .HasForeignKey("ProjectLinkprojectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskKevin.Data.Model.User", null)
                        .WithMany()
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TaskKevin.Data.Model.Task", b =>
                {
                    b.HasOne("TaskKevin.Data.Model.Projects", null)
                        .WithMany("Task")
                        .HasForeignKey("ProjectsprojectId");
                });

            modelBuilder.Entity("TaskKevin.Data.Model.User", b =>
                {
                    b.HasOne("TaskKevin.Data.Model.Roles", "roles")
                        .WithOne("userLink")
                        .HasForeignKey("TaskKevin.Data.Model.User", "rolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("roles");
                });

            modelBuilder.Entity("TaskUser", b =>
                {
                    b.HasOne("TaskKevin.Data.Model.Task", null)
                        .WithMany()
                        .HasForeignKey("TaskLinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskKevin.Data.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserLinkid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TaskKevin.Data.Model.Projects", b =>
                {
                    b.Navigation("Task");
                });

            modelBuilder.Entity("TaskKevin.Data.Model.Roles", b =>
                {
                    b.Navigation("userLink");
                });
#pragma warning restore 612, 618
        }
    }
}
