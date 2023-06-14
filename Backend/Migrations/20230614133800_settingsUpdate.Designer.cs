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
    [Migration("20230614133800_settingsUpdate")]
    partial class settingsUpdate
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

                    b.Property<string>("CurrencyEcxhangeBaseUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CurrencyExchangeApiKey")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("EmailVerificationEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IdentityVerificationEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<double>("LatestF2NRate")
                        .HasColumnType("double");

                    b.Property<double>("LatestN2FRate")
                        .HasColumnType("double");

                    b.Property<bool>("PhoneVerificationEnabled")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("ExMoneySettings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CommissionPercentage = 0.050000000000000003,
                            CurrencyEcxhangeBaseUrl = "http://currencyapi.com",
                            CurrencyExchangeApiKey = "STNcvlsyq6QpULgJhQYKqKqym6YI5MjrdPBalf5x",
                            EmailVerificationEnabled = false,
                            IdentityVerificationEnabled = false,
                            LatestF2NRate = 1.3200000000000001,
                            LatestN2FRate = 0.84999999999999998,
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
                        .HasColumnType("varchar(255)");

                    b.Property<byte[]>("UserPic")
                        .HasColumnType("longblob");

                    b.Property<int>("VerificationResult")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("KycVerifications");
                });

            modelBuilder.Entity("ExMoney.SharedLibs.PaymentOperation", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Hash")
                        .HasColumnType("longtext");

                    b.Property<string>("ParentTransactionId")
                        .HasColumnType("longtext");

                    b.Property<string>("PaymentId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PaymentOperations");
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

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PayInId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PayOutId")
                        .HasColumnType("varchar(255)");

                    b.Property<double>("Rate")
                        .HasColumnType("double");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("BaseCurrencyId");

                    b.HasIndex("ChangeCurrencyId");

                    b.HasIndex("PayInId");

                    b.HasIndex("PayOutId");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("ExMoney.SharedLibs.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<double>("Balance")
                        .HasColumnType("double");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Country")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("EmailVerified")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneVerified")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("User");
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

                    b.Property<string>("OwnerId")
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
                            Name = "Réserve Naira",
                            OwnerId = "exmoney-system"
                        },
                        new
                        {
                            Id = "bab8e547-7f6e-4955-976f-80b9c4a2298e",
                            Balance = 13674.0,
                            CurrencyId = 1,
                            Name = "Réserve CFA",
                            OwnerId = "exmoney-system"
                        });
                });

            modelBuilder.Entity("ExMoney.SharedLibs.KycVerification", b =>
                {
                    b.HasOne("ExMoney.SharedLibs.User", null)
                        .WithOne("KycVerification")
                        .HasForeignKey("ExMoney.SharedLibs.KycVerification", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ExMoney.SharedLibs.Transaction", b =>
                {
                    b.HasOne("ExMoney.SharedLibs.Currency", "BaseCurrency")
                        .WithMany()
                        .HasForeignKey("BaseCurrencyId");

                    b.HasOne("ExMoney.SharedLibs.Currency", "ChangeCurrency")
                        .WithMany()
                        .HasForeignKey("ChangeCurrencyId");

                    b.HasOne("ExMoney.SharedLibs.PaymentOperation", "PayIn")
                        .WithMany()
                        .HasForeignKey("PayInId");

                    b.HasOne("ExMoney.SharedLibs.PaymentOperation", "PayOut")
                        .WithMany()
                        .HasForeignKey("PayOutId");

                    b.HasOne("ExMoney.SharedLibs.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BaseCurrency");

                    b.Navigation("ChangeCurrency");

                    b.Navigation("PayIn");

                    b.Navigation("PayOut");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ExMoney.SharedLibs.User", b =>
                {
                    b.Navigation("KycVerification");
                });
#pragma warning restore 612, 618
        }
    }
}
