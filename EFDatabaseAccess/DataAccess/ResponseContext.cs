using EFDatabaseAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDatabaseAccess.DataAccess
{
    public class ResponseContext : DbContext
    {
        public ResponseContext(DbContextOptions options) : base(options) { }
        public DbSet<GuestResponse> Responses { get; set; }

    }
}
