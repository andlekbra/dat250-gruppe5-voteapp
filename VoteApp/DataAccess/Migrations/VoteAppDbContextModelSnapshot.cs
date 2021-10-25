﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VoteApp.DataAccess;

namespace VoteApp.DataAccess.Migrations
{
    [DbContext(typeof(VoteAppDbContext))]
    partial class VoteAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("VoteApp.DataAccess.Entities.IoTDevice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Identifier")
                        .HasColumnType("text");

                    b.Property<int?>("PollId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PollId");

                    b.ToTable("IoTDevices");
                });

            modelBuilder.Entity("VoteApp.DataAccess.Entities.Poll", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("JoinCode")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("PollTemplateId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("StopTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("VoteCountId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PollTemplateId");

                    b.HasIndex("VoteCountId");

                    b.ToTable("Polls");
                });

            modelBuilder.Entity("VoteApp.DataAccess.Entities.PollTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("CreatorId")
                        .HasColumnType("integer");

                    b.Property<string>("GreenAnswer")
                        .HasColumnType("text");

                    b.Property<string>("Question")
                        .HasColumnType("text");

                    b.Property<string>("RedAnswer")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("PollTemplates");
                });

            modelBuilder.Entity("VoteApp.DataAccess.Entities.VoteCount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("GreenVotes")
                        .HasColumnType("integer");

                    b.Property<int>("RedVotes")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("VoteCounts");
                });

            modelBuilder.Entity("VoteApp.DataAccess.Entities.VoterProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("VoterProfiles");
                });

            modelBuilder.Entity("VoteApp.DataAccess.Entities.IoTDevice", b =>
                {
                    b.HasOne("VoteApp.DataAccess.Entities.Poll", null)
                        .WithMany("IoTDevices")
                        .HasForeignKey("PollId");
                });

            modelBuilder.Entity("VoteApp.DataAccess.Entities.Poll", b =>
                {
                    b.HasOne("VoteApp.DataAccess.Entities.PollTemplate", "Template")
                        .WithMany("Polls")
                        .HasForeignKey("PollTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VoteApp.DataAccess.Entities.VoteCount", "VoteCount")
                        .WithMany()
                        .HasForeignKey("VoteCountId");

                    b.Navigation("Template");

                    b.Navigation("VoteCount");
                });

            modelBuilder.Entity("VoteApp.DataAccess.Entities.PollTemplate", b =>
                {
                    b.HasOne("VoteApp.DataAccess.Entities.VoterProfile", "Creator")
                        .WithMany("PollTemplates")
                        .HasForeignKey("CreatorId");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("VoteApp.DataAccess.Entities.Poll", b =>
                {
                    b.Navigation("IoTDevices");
                });

            modelBuilder.Entity("VoteApp.DataAccess.Entities.PollTemplate", b =>
                {
                    b.Navigation("Polls");
                });

            modelBuilder.Entity("VoteApp.DataAccess.Entities.VoterProfile", b =>
                {
                    b.Navigation("PollTemplates");
                });
#pragma warning restore 612, 618
        }
    }
}
