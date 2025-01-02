using Microsoft.EntityFrameworkCore;

namespace SelfAspNet.Models;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions<MyContext> options) : base(options)
    { }

    public DbSet<Book> Books { get; set; } = default!;

    public DbSet<Article> Articles { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Book>(e =>
        {
            e.HasData(
              new Book
              {
                  Id = 1,
                  Isbn = "978-4-7981-8094-6",
                  Title = "独習Java",
                  Price = 3960,
                  Publisher = "翔泳社",
                  Published = new DateTime(2024, 02, 15),
                  Sample = true
              },
              new Book
              {
                  Id = 2,
                  Isbn = "978-4-7981-7613-0",
                  Title = "Androidアプリ開発の教科書",
                  Price = 3135,
                  Publisher = "翔泳社",
                  Published = new DateTime(2023, 01, 24),
                  Sample = true
              },
              new Book
              {
                  Id = 3,
                  Isbn = "978-4-8156-1948-0",
                  Title = "これからはじめるReact実践入門",
                  Price = 4400,
                  Publisher = "SBクリエイティブ",
                  Published = new DateTime(2023, 09, 28),
                  Sample = true
              },
              new Book
              {
                  Id = 4,
                  Isbn = "978-4-296-07070-1",
                  Title = "作って学べるHTML＋JavaScriptの基本",
                  Price = 2420,
                  Publisher = "日経BP",
                  Published = new DateTime(2023, 07, 06),
                  Sample = false
              },
              new Book
              {
                  Id = 5,
                  Isbn = "978-4-297-13685-7",
                  Title = "Nuxt 3 フロントエンド開発の教科書",
                  Price = 3520,
                  Publisher = "技術評論社",
                  Published = new DateTime(2023, 09, 22),
                  Sample = false
              },
              new Book
              {
                  Id = 6,
                  Isbn = "978-4-297-13288-0",
                  Title = "JavaScript本格入門",
                  Price = 3520,
                  Publisher = "技術評論社",
                  Published = new DateTime(2023, 02, 13),
                  Sample = true
              },
              new Book
              {
                  Id = 7,
                  Isbn = "978-4-627-85711-7",
                  Title = "Pythonでできる! 株価データ分析",
                  Price = 2970,
                  Publisher = "森北出版",
                  Published = new DateTime(2023, 01, 21),
                  Sample = false
              },
              new Book
              {
                  Id = 8,
                  Isbn = "978-4-7981-7556-0",
                  Title = "独習C#",
                  Price = 4180,
                  Publisher = "翔泳社",
                  Published = new DateTime(2022, 07, 21),
                  Sample = true
              },
              new Book
              {
                  Id = 9,
                  Isbn = "978-4-8156-1336-5",
                  Title = "これからはじめるVue.js 3実践入門",
                  Price = 3740,
                  Publisher = "SBクリエイティブ",
                  Published = new DateTime(2022, 03, 19),
                  Sample = true
              },
              new Book
              {
                  Id = 10,
                  Isbn = "978-4-296-08014-4",
                  Title = "基礎からしっかり学ぶC#の教科書",
                  Price = 3190,
                  Publisher = "日経BP",
                  Published = new DateTime(2022, 03, 03),
                  Sample = false
              }
            );
        });

        builder.Entity<Article>(e =>
        {
            e.HasData(
                new Article
                {
                    Id = 1,
                    Title = "ますます便利になるTypeScript！",
                    Url = "https://codezine.jp/article/corner/992",
                    Category = "JavaScript",
                    CreatedAt = new DateTime(2023, 12, 21),
                    LastUpdatedAt = new DateTime(2023, 12, 22)
                },
                new Article
                {
                    Id = 2,
                    Title = "Remixを通じてWebを学ぶ",
                    Url = "https://codezine.jp/article/corner/942",
                    Category = "JavaScript",
                    CreatedAt = new DateTime(2023, 12, 23),
                    LastUpdatedAt = new DateTime(2023, 12, 24)
                },
                new Article
                {
                    Id = 3,
                    Title = "Web Componentsを基礎から学ぶ",
                    Url = "https://codezine.jp/article/corner/927",
                    Category = "JavaScript",
                    CreatedAt = new DateTime(2023, 12, 25),
                    LastUpdatedAt = new DateTime(2023, 12, 26)
                },
                new Article
                {
                    Id = 4,
                    Title = "Railsの新機能を知ろう！",
                    Url = "https://codezine.jp/article/corner/991",
                    Category = "Rails",
                    CreatedAt = new DateTime(2023, 12, 27),
                    LastUpdatedAt = new DateTime(2023, 12, 28)
                },
                new Article
                {
                    Id = 5,
                    Title = "Railsによるクライアントサイド開発入門",
                    Url = "https://codezine.jp/article/corner/919",
                    Category = "Rails",
                    CreatedAt = new DateTime(2023, 12, 29),
                    LastUpdatedAt = new DateTime(2023, 12, 30)
                },
                new Article
                {
                    Id = 6,
                    Title = "現場で役立つRust入門",
                    Url = "https://atmarkit.itmedia.co.jp/ait/series/36943/",
                    Category = "Rust",
                    CreatedAt = new DateTime(2023, 12, 31),
                    LastUpdatedAt = new DateTime(2024, 1, 1)
                },
                new Article
                {
                    Id = 7,
                    Title = "基本からしっかり学ぶRust入門",
                    Url = "https://atmarkit.itmedia.co.jp/ait/series/24844/",
                    Category = "Rust",
                    CreatedAt = new DateTime(2024, 1, 2),
                    LastUpdatedAt = new DateTime(2024, 1, 3)
                }
            );
        });
    }
}
