﻿
using Microsoft.EntityFrameworkCore;

namespace UserAcountManagement.Storage.Entities;

public class BankDBContext:DbContext
{
    public BankDBContext(DbContextOptions options):base(options)
    {
        Database.Migrate();
    }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Acount> Acounts { get; set; }
}
