using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MessageBook.Database.DatabaseModel;
namespace MessageBook.Database
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options) : base(options)
        {
        }
            public DbSet<Messages> MESSAGES { get; set; }
            public DbSet<Users> USERS { get; set; }
    }
}


