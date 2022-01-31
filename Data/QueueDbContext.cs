using System.Collections.Generic;
using System.Diagnostics;
using Hospital_queue.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Hospital_queue.Data;

public class QueueDbContext : DbContext 
{
    public QueueDbContext (DbContextOptions<QueueDbContext> options) : base (options) { }
    public DbSet<QueueModel> queues { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<QueueModel>().HasIndex(i => i.Phone).IsUnique();
    }

}