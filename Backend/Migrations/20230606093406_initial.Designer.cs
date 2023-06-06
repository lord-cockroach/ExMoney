﻿// <auto-generated />
using System;
using ExMoney.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExMoney.Backend.Migrations
{
    [DbContext(typeof(BackendDbContext))]
    [Migration("20230606093406_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ExMoney.SharedLibs.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("varchar(1024)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("varchar(3)");

                    b.HasKey("Id");

                    b.ToTable("Currencies");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Name = "Naira",
                            Symbol = "NGN"
                        },
                        new
                        {
                            Id = 1,
                            Name = "FCFA",
                            Symbol = "XOF"
                        });
                });

            modelBuilder.Entity("ExMoney.SharedLibs.ExMoneySettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("CommissionPercentage")
                        .HasColumnType("double");

                    b.Property<bool>("EmailVerificationEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IdentityVerificationEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("PhoneVerificationEnabled")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("ExMoneySettings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CommissionPercentage = 0.050000000000000003,
                            EmailVerificationEnabled = false,
                            IdentityVerificationEnabled = false,
                            PhoneVerificationEnabled = false
                        });
                });

            modelBuilder.Entity("ExMoney.SharedLibs.KycVerification", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("DocumentType")
                        .HasColumnType("int");

                    b.Property<byte[]>("IdDocumentRectoPic")
                        .HasColumnType("longblob");

                    b.Property<byte[]>("IdDocumentVersoPic")
                        .HasColumnType("longblob");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte[]>("UserPic")
                        .HasColumnType("longblob");

                    b.Property<int>("VerificationResult")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("KycVerifications");
                });

            modelBuilder.Entity("ExMoney.SharedLibs.PaymentProcessor", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ApiKey")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SecretKey")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SupportedCurrencies")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("PaymentProcessors");

                    b.HasData(
                        new
                        {
                            Id = "8ce50226-1307-4de8-aff7-d839042dec53",
                            ApiKey = "k",
                            Name = "KkiaPay",
                            SecretKey = "",
                            SupportedCurrencies = "xof"
                        });
                });

            modelBuilder.Entity("ExMoney.SharedLibs.Transaction", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<double>("Amount")
                        .HasColumnType("double");

                    b.Property<int?>("BaseCurrencyId")
                        .HasColumnType("int");

                    b.Property<int?>("ChangeCurrencyId")
                        .HasColumnType("int");

                    b.Property<double>("Rate")
                        .HasColumnType("double");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("BaseCurrencyId");

                    b.HasIndex("ChangeCurrencyId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("ExMoney.SharedLibs.Wallet", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<double>("Balance")
                        .HasColumnType("double");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ExMoneyWallets");

                    b.HasData(
                        new
                        {
                            Id = "001066c3-457b-4b3c-a942-b4ebca1afeb2",
                            Balance = 26400.0,
                            CurrencyId = 2,
                            Name = "Réserve Naira"
                        },
                        new
                        {
                            Id = "bab8e547-7f6e-4955-976f-80b9c4a2298e",
                            Balance = 13674.0,
                            CurrencyId = 1,
                            Name = "Réserve CFA"
                        });
                });

            modelBuilder.Entity("ExMoney.SharedLibs.Transaction", b =>
                {
                    b.HasOne("ExMoney.SharedLibs.Currency", "BaseCurrency")
                        .WithMany()
                        .HasForeignKey("BaseCurrencyId");

                    b.HasOne("ExMoney.SharedLibs.Currency", "ChangeCurrency")
                        .WithMany()
                        .HasForeignKey("ChangeCurrencyId");

                    b.Navigation("BaseCurrency");

                    b.Navigation("ChangeCurrency");
                });
#pragma warning restore 612, 618
        }
    }
}
