using Microsoft.EntityFrameworkCore;
using SQLJatko.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQLJatko.Data
{
    public class SQLJatkoDb: DbContext
    {
        public SQLJatkoDb(DbContextOptions<SQLJatkoDb> options) : base (options)
        {

        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
