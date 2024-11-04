using System;
using Microsoft.EntityFrameworkCore;

namespace SelfAspNet.Models;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions<MyContext> options) : base(options) { }

    public DbSet<Book> Books { get; set; } = default!;
    public DbSet<Review> Reviews { get; set; } = default!;
    public DbSet<Author> Authors { get; set; } = default!;
    public DbSet<User> Users { get; set; } = default!;
    public DbSet<Article> Articles { get; set; } = default!;
    public DbSet<Meta> Metas { get; set; } = default!;
    public DbSet<Photo> Photos { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new TimestampInterceptor());
    }
}
