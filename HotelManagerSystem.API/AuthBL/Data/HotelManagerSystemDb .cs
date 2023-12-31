﻿using HotelManagerSystem.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelManagerSystem.API.AuthBL.Data;

public class HotelManagerSystemDb : IdentityDbContext<User>
{
    private readonly IServiceProvider _serviceProvider;
    public HotelManagerSystemDb(DbContextOptions<HotelManagerSystemDb> options, IServiceProvider serviceProvider)
        : base(options)
    {
        _serviceProvider = serviceProvider;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        var connectionString = config.GetConnectionString("DbConnection")
                               ?? throw new InvalidOperationException(
                                   "Connection string 'DbConnection' not found.");

        optionsBuilder.UseNpgsql(connectionString, builder =>
        {
            builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
        });
    }
}

