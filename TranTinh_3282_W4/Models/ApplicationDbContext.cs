﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TranTinh_3282_W3.Models;
//public class ApplicationDbContext : DbContext
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>

{
    public
    ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
    base(options)
    { }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
}