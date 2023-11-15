using Microsoft.EntityFrameworkCore;
using ProvaFinaleFaseB.Entities;
using System.Collections.Generic;

namespace ProvaFinaleFaseB.DataSource
{
    public class ApplicationLogContext : DbContext
    {
       
            public ApplicationLogContext()
            {
            }
            public ApplicationLogContext(DbContextOptions<ApplicationLogContext> options)
            : base(options)
            {
            }
            public DbSet<LogsEntity> loggers { get; set; }

        
    }
}
