using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AmendoTest.Models
{
    public class BookDbInitializer : CreateDatabaseIfNotExists<AmendoBookDBContext>
    {
        protected override void Seed(AmendoBookDBContext db)
        {
            Author tolstoi = new Author { FirstName = "Лев", MiddleName = "Николаевич", LastName = "Толстой" };
            Author pushkin = new Author { FirstName = "Александр", MiddleName = "Сергеевич", LastName = "Пушкин" };
            db.Authors.Add(tolstoi);
            db.Authors.Add(pushkin);

            db.Books.Add(new Book() { BookName = "Война и Мир", Author = tolstoi });
            db.Books.Add(new Book() { BookName = "Анна Каренина", Author = tolstoi });
            db.Books.Add(new Book() { BookName = "Выстрел", Author = pushkin });
            db.Books.Add(new Book() { BookName = "Метель", Author = pushkin });
            base.Seed(db);
        }
    }
}