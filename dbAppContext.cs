using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using Prism.Mvvm;
using Prism.Commands;

namespace To_Do
{
    class dbAppContext : DbContext
    {
            public DbSet<Task> Task { get; set; }
            public string DbPath { get; }
            public dbAppContext()
            {
                DbPath = "C:\\Users\\Korisnik\\source\\repos\\To_Do\\tasks.db";
            }
            
            protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
