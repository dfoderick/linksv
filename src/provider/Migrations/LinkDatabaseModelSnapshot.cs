﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using provider.Domain;

#nullable disable

namespace provider.Migrations
{
    [DbContext(typeof(LinkDatabase))]
    partial class LinkDatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("LinkLocationLinkOwner", b =>
                {
                    b.Property<string>("OwnedLinksLocation")
                        .HasColumnType("TEXT");

                    b.Property<string>("OwnersOwnerAddress")
                        .HasColumnType("TEXT");

                    b.HasKey("OwnedLinksLocation", "OwnersOwnerAddress");

                    b.HasIndex("OwnersOwnerAddress");

                    b.ToTable("LinkLocationLinkOwner");
                });

            modelBuilder.Entity("provider.Domain.Models.LinkLocation", b =>
                {
                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.Property<uint>("Nonce")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Location");

                    b.HasIndex("Nonce");

                    b.HasIndex("Origin");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("provider.Domain.Models.LinkOrigin", b =>
                {
                    b.Property<string>("Origin")
                        .HasColumnType("TEXT");

                    b.HasKey("Origin");

                    b.ToTable("Origins");
                });

            modelBuilder.Entity("provider.Domain.Models.LinkOwner", b =>
                {
                    b.Property<string>("OwnerAddress")
                        .HasColumnType("TEXT");

                    b.HasKey("OwnerAddress");

                    b.ToTable("LinkOwner");
                });

            modelBuilder.Entity("LinkLocationLinkOwner", b =>
                {
                    b.HasOne("provider.Domain.Models.LinkLocation", null)
                        .WithMany()
                        .HasForeignKey("OwnedLinksLocation")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("provider.Domain.Models.LinkOwner", null)
                        .WithMany()
                        .HasForeignKey("OwnersOwnerAddress")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("provider.Domain.Models.LinkLocation", b =>
                {
                    b.HasOne("provider.Domain.Models.LinkOrigin", "LinkOrigin")
                        .WithMany("Locations")
                        .HasForeignKey("Origin")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LinkOrigin");
                });

            modelBuilder.Entity("provider.Domain.Models.LinkOrigin", b =>
                {
                    b.Navigation("Locations");
                });
#pragma warning restore 612, 618
        }
    }
}
