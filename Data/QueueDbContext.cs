using System.Collections.Generic;
using System.Diagnostics;
using Hospital_queue.Entities;
using Hospital_queue.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Hospital_queue.Data;

public class QueueDbContext : DbContext
{
    public DbSet<Queue> Queues { get; set; }

    public QueueDbContext(DbContextOptions<QueueDbContext> options)
        : base(options) { }
}