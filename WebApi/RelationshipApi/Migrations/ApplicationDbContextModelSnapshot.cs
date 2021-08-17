﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RelationshipApi.Models.Entities;

namespace RelationshipApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("RelationshipApi.Models.Entities.Family", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Families");
                });

            modelBuilder.Entity("RelationshipApi.Models.Entities.Invitation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("FamilyId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Used")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("UsedDateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FamilyId");

                    b.HasIndex("MemberId");

                    b.ToTable("Invitations");
                });

            modelBuilder.Entity("RelationshipApi.Models.Entities.Member", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("FamilyId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.HasIndex("FamilyId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("RelationshipApi.Models.Entities.Token", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("RelationshipApi.Models.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("TimeZone")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RelationshipApi.Models.Entities.Invitation", b =>
                {
                    b.HasOne("RelationshipApi.Models.Entities.Family", "Family")
                        .WithMany("Invitations")
                        .HasForeignKey("FamilyId")
                        .HasConstraintName("FK_Invitation_Family")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RelationshipApi.Models.Entities.Member", "Invitor")
                        .WithMany("Invitations")
                        .HasForeignKey("MemberId")
                        .HasConstraintName("FK_Invitation_Member")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Family");

                    b.Navigation("Invitor");
                });

            modelBuilder.Entity("RelationshipApi.Models.Entities.Member", b =>
                {
                    b.HasOne("RelationshipApi.Models.Entities.Family", "Family")
                        .WithMany("Members")
                        .HasForeignKey("FamilyId")
                        .HasConstraintName("FK_Member_Family")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("RelationshipApi.Models.Entities.User", "User")
                        .WithOne("Member")
                        .HasForeignKey("RelationshipApi.Models.Entities.Member", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Family");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RelationshipApi.Models.Entities.Token", b =>
                {
                    b.HasOne("RelationshipApi.Models.Entities.Member", "Member")
                        .WithMany("Tokens")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("RelationshipApi.Models.Entities.Family", b =>
                {
                    b.Navigation("Invitations");

                    b.Navigation("Members");
                });

            modelBuilder.Entity("RelationshipApi.Models.Entities.Member", b =>
                {
                    b.Navigation("Invitations");

                    b.Navigation("Tokens");
                });

            modelBuilder.Entity("RelationshipApi.Models.Entities.User", b =>
                {
                    b.Navigation("Member");
                });
#pragma warning restore 612, 618
        }
    }
}
