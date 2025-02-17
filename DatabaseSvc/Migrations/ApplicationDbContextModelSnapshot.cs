﻿// <auto-generated />
using DatabaseSvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DatabaseSvc.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.19");

            modelBuilder.Entity("DatabaseSvc.Model.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("website")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DatabaseSvc.Model.User", b =>
                {
                    b.OwnsOne("DatabaseSvc.Model.Address", "address", b1 =>
                        {
                            b1.Property<int>("Userid")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("city")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("street")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("suite")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("zipcode")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("Userid");

                            b1.ToTable("Addresses");

                            b1.WithOwner()
                                .HasForeignKey("Userid");

                            b1.OwnsOne("DatabaseSvc.Model.Geo", "geo", b2 =>
                                {
                                    b2.Property<int>("AddressUserid")
                                        .HasColumnType("INTEGER");

                                    b2.Property<string>("lat")
                                        .IsRequired()
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("lng")
                                        .IsRequired()
                                        .HasColumnType("TEXT");

                                    b2.HasKey("AddressUserid");

                                    b2.ToTable("Geos");

                                    b2.WithOwner()
                                        .HasForeignKey("AddressUserid");
                                });

                            b1.Navigation("geo")
                                .IsRequired();
                        });

                    b.OwnsOne("DatabaseSvc.Model.Company", "company", b1 =>
                        {
                            b1.Property<int>("Userid")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("bs")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("catchPhrase")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("name")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("Userid");

                            b1.ToTable("Companies");

                            b1.WithOwner()
                                .HasForeignKey("Userid");
                        });

                    b.Navigation("address")
                        .IsRequired();

                    b.Navigation("company")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
