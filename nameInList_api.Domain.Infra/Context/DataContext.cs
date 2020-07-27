using Microsoft.EntityFrameworkCore;
using nameInList_api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace nameInList_api.Domain.Infra.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserListaEntity>().HasKey(sc => new { sc.UserId, sc.ListaId });
            

            modelBuilder.Entity<UserListaEntity>()
            .HasOne<UserEntity>(sc => sc.User)
            .WithMany(s => s.UserList)
            .HasForeignKey(sc => sc.UserId);


            modelBuilder.Entity<UserListaEntity>()
                .HasOne<ListaEntity>(sc => sc.Lista)
                .WithMany(s => s.UserLists)
                .HasForeignKey(sc => sc.ListaId);



            //modelBuilder.Entity<ListaEntity>()
            //   .HasOne<UserEntity>(p => p.Criator)
            //   .WithMany(b => b.Listas)
            //   .HasForeignKey(p => p.CriatorId);



        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ListaEntity> Listas { get; set; }
        public DbSet<UserListaEntity> UserListas { get; set; }
    }
}
