﻿using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using Book.Authorization.Roles;
using Book.Authorization.Users;
using Book.Books.BookInfos;
using Book.Books.BorrowBooks;
using Book.Books.Students;
using Book.MultiTenancy;

namespace Book.EntityFramework
{
    public class BookDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
         public DbSet<BookInfo> BookInfos { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<BorrowBook> BorrowBooks { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student", "BK");
            modelBuilder.Entity<BookInfo>().ToTable("BookInfo", "BK");
            modelBuilder.Entity<BorrowBook>().ToTable("BorrowBook", "BK");
            base.OnModelCreating(modelBuilder);
        }

        public BookDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in BookDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of BookDbContext since ABP automatically handles it.
         */
        public BookDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public BookDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public BookDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }

   
    }
}
