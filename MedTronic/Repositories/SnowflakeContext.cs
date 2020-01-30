using MedTronic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedTronic.Repositories
{
    public class SnowflakeContext : DbContext
    {
        public DbSet<StockPriceModel> Stocks { get; set; }

        public SnowflakeContext(DbContextOptions<SnowflakeContext> dc) : base(dc)
        {

        }

    }
}
