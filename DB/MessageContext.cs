using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kargil.DB
{
    public class MessageContext : DbContext
    {
        public MessageContext(DbContextOptions<MessageContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Message> UserMessage { get; set; }
    }
}
