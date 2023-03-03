using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models {

    public static class SeedData {

        public static void EnsurePopulated(IApplicationBuilder app) {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            try
            {
                context.Database.Migrate();
            }
            catch(System.Exception) { }
            if (!context.Products.Any()) {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Байдарка",
                        Description = "Предназначена для одного человека",
                        Category = "Водный спорт",
                        Price = 9999
                    },
                    new Product
                    {
                        Name = "Спасательный жилет",
                        Description = "Защищает в воде и стильно выглядит",
                        Category = "Водный спорт",
                        Price = 3499
                    },
                    new Product
                    {
                        Name = "Футбольный мяч",
                        Description = "Такой же как в FIFA",
                        Category = "Футбол",
                        Price = 999
                    },
                    new Product
                    {
                        Name = "Угловые флаги",
                        Description = "Возьмите их с собой, чтобы сделать футбольное поле из обычного",
                        Category = "Футбол",
                        Price = 1999
                    },
                    new Product
                    {
                        Name = "Стадион",
                        Description = "Вмещает в себе около 35_000 человек",
                        Category = "Футбол",
                        Price = 5599000
                    },
                    new Product
                    {
                        Name = "Думающая кепка",
                        Description = "Повышает эффективность мозгового мышления на 75%",
                        Category = "Шахматы",
                        Price = 799
                    },
                    new Product
                    {
                        Name = "Шаткий стул",
                        Description = "Ваш козырь: помогает дезориентировать оппонента",
                        Category = "Шахматы",
                        Price = 2499
                    },
                    new Product
                    {
                        Name = "Шахматная доска",
                        Description = "Подарит Вам весёлую игру для всей семьи",
                        Category = "Шахматы",
                        Price = 3499
                    },
                    new Product
                    {
                        Name = "Королевские побрякушки",
                        Description = "Позолоченные и с бриллиантами. Поможет дополнить Ваш королевский образ",
                        Category = "Шахматы",
                        Price = 99999
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
