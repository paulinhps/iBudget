﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using getQuote.DAO;

#nullable disable

namespace getQuote.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("getQuote.Models.CompanyModel", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CompanyId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<byte[]>("ImageFile")
                        .HasColumnType("bytea");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.HasKey("CompanyId");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("getQuote.Models.ContactModel", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ContactId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("PersonId")
                        .HasColumnType("integer");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.HasKey("ContactId");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("getQuote.Models.DocumentModel", b =>
                {
                    b.Property<int>("DocumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DocumentId"));

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("DocumentType")
                        .HasColumnType("integer");

                    b.Property<int>("PersonId")
                        .HasColumnType("integer");

                    b.HasKey("DocumentId");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("Document");
                });

            modelBuilder.Entity("getQuote.Models.ItemImageModel", b =>
                {
                    b.Property<int>("ItemImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ItemImageId"));

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<byte[]>("ImageFile")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<int>("ItemId")
                        .HasColumnType("integer");

                    b.Property<bool>("Main")
                        .HasColumnType("boolean");

                    b.HasKey("ItemImageId");

                    b.HasIndex("ItemId");

                    b.ToTable("ItemImage");
                });

            modelBuilder.Entity("getQuote.Models.ItemModel", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ItemId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<double>("Value")
                        .HasPrecision(18, 2)
                        .HasColumnType("double precision");

                    b.HasKey("ItemId");

                    b.HasIndex("ItemName")
                        .IsUnique();

                    b.ToTable("Item");
                });

            modelBuilder.Entity("getQuote.Models.LoginLogModel", b =>
                {
                    b.Property<int>("LoginLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LoginLogId"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Hostname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RemoteIpAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasComment("0-None,1-Failed,2-Success");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginLogId");

                    b.ToTable("LoginLog");
                });

            modelBuilder.Entity("getQuote.Models.LoginModel", b =>
                {
                    b.Property<int>("LoginId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LoginId"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.HasKey("LoginId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Login");
                });

            modelBuilder.Entity("getQuote.Models.PersonModel", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PersonId"));

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("PersonId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("getQuote.Models.ProposalContentModel", b =>
                {
                    b.Property<int>("ProposalContentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProposalContentId"));

                    b.Property<int>("ItemId")
                        .HasColumnType("integer");

                    b.Property<int>("ProposalId")
                        .HasColumnType("integer");

                    b.Property<double>("Quantity")
                        .HasColumnType("double precision");

                    b.HasKey("ProposalContentId");

                    b.HasIndex("ItemId");

                    b.HasIndex("ProposalId");

                    b.ToTable("ProposalContent");
                });

            modelBuilder.Entity("getQuote.Models.ProposalHistoryModel", b =>
                {
                    b.Property<int>("ProposalHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProposalHistoryId"));

                    b.Property<decimal>("Discount")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PersonId")
                        .HasColumnType("integer");

                    b.Property<int>("ProposalId")
                        .HasColumnType("integer");

                    b.HasKey("ProposalHistoryId");

                    b.HasIndex("PersonId");

                    b.HasIndex("ProposalId");

                    b.ToTable("ProposalHistory");
                });

            modelBuilder.Entity("getQuote.Models.ProposalModel", b =>
                {
                    b.Property<int>("ProposalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProposalId"));

                    b.Property<double>("Discount")
                        .HasPrecision(18, 2)
                        .HasColumnType("double precision");

                    b.Property<Guid>("GUID")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ModificationDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("PersonId")
                        .HasColumnType("integer");

                    b.HasKey("ProposalId");

                    b.HasIndex("GUID")
                        .IsUnique();

                    b.HasIndex("PersonId");

                    b.ToTable("Proposal");
                });

            modelBuilder.Entity("getQuote.Models.ContactModel", b =>
                {
                    b.HasOne("getQuote.Models.PersonModel", "Person")
                        .WithOne("Contact")
                        .HasForeignKey("getQuote.Models.ContactModel", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("getQuote.Models.DocumentModel", b =>
                {
                    b.HasOne("getQuote.Models.PersonModel", "Person")
                        .WithOne("Document")
                        .HasForeignKey("getQuote.Models.DocumentModel", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("getQuote.Models.ItemImageModel", b =>
                {
                    b.HasOne("getQuote.Models.ItemModel", "Item")
                        .WithMany("ItemImageList")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("getQuote.Models.ProposalContentModel", b =>
                {
                    b.HasOne("getQuote.Models.ItemModel", "Item")
                        .WithMany("ProposalContent")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("getQuote.Models.ProposalModel", "Proposal")
                        .WithMany("ProposalContent")
                        .HasForeignKey("ProposalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Proposal");
                });

            modelBuilder.Entity("getQuote.Models.ProposalHistoryModel", b =>
                {
                    b.HasOne("getQuote.Models.PersonModel", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("getQuote.Models.ProposalModel", "Proposal")
                        .WithMany("ProposalHistory")
                        .HasForeignKey("ProposalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("getQuote.Models.ProposalContentJSON", "ProposalContentJSON", b1 =>
                        {
                            b1.Property<int>("ProposalHistoryModelProposalHistoryId")
                                .HasColumnType("integer");

                            b1.Property<string>("ProposalContentItems")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("ProposalHistoryModelProposalHistoryId");

                            b1.ToTable("ProposalHistory");

                            b1.WithOwner()
                                .HasForeignKey("ProposalHistoryModelProposalHistoryId");
                        });

                    b.Navigation("Person");

                    b.Navigation("Proposal");

                    b.Navigation("ProposalContentJSON")
                        .IsRequired();
                });

            modelBuilder.Entity("getQuote.Models.ProposalModel", b =>
                {
                    b.HasOne("getQuote.Models.PersonModel", "Person")
                        .WithMany("Proposal")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("getQuote.Models.ItemModel", b =>
                {
                    b.Navigation("ItemImageList");

                    b.Navigation("ProposalContent");
                });

            modelBuilder.Entity("getQuote.Models.PersonModel", b =>
                {
                    b.Navigation("Contact")
                        .IsRequired();

                    b.Navigation("Document")
                        .IsRequired();

                    b.Navigation("Proposal");
                });

            modelBuilder.Entity("getQuote.Models.ProposalModel", b =>
                {
                    b.Navigation("ProposalContent");

                    b.Navigation("ProposalHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
