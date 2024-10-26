using System;
using Microsoft.EntityFrameworkCore;

namespace SelfAspNet.Models;

public static class Seed
{
    public static async Task Initialize(IServiceProvider provider)
    {
        using var db = new MyContext(provider.GetRequiredService<DbContextOptions<MyContext>>());
        if (await db.Articles.AnyAsync()) { return; }
        db.Articles.AddRange(
            new Article
            {
                Title = "ますます便利になるTypeScript！100",
                Url = "https://codezine.jp/article/corner/992",
                Category = "JavaScript"
            },
            new Article
            {
                Title = "Remixを通じてWebを学ぶ",
                Url = "https://codezine.jp/article/corner/942",
                Category = "JavaScript"
            },
            new Article
            {
                Title = "Web Componentsを基礎から学ぶ",
                Url = "https://codezine.jp/article/corner/927",
                Category = "JavaScript"
            },
            new Article
            {
                Title = "Railsの新機能を知ろう！",
                Url = "https://codezine.jp/article/corner/991",
                Category = "Rails"
            },
            new Article
            {
                Title = "Railsによるクライアントサイド開発入門",
                Url = "https://codezine.jp/article/corner/919",
                Category = "Rails"
            }
        );
        await db.SaveChangesAsync();
    }
}
