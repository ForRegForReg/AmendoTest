using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AmendoTest.Models;

namespace AmendoTest.Controllers
{
    public class BooksController : Controller
    {
        private AmendoBookDBContext db = new AmendoBookDBContext();
        // GET: Books
        public async Task<ActionResult> Index()
        {
            // получить список книг
            var books = db.Books.Include(b => b.Author);
            return View(await books.ToListAsync());
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            // заполнить выпадающий список авторов
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "FullName");
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "BookID,BookName,AuthorID")] Book book)
        {
            // проверка корректности введенных данных
            if (ModelState.IsValid)
            {// добавить книгу
                db.Books.Add(book);
                await db.SaveChangesAsync(); // созранить в БД
                return RedirectToAction("Index");
            }
            // заполнить выпадающий список авторов
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "FullName", book.AuthorID);
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<ActionResult> Edit(int? id) // изменить данные о книге
        {
            if (id == null) // проверка на пустое значение
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = await db.Books.FindAsync(id); // книга для изменения
            if (book == null)
            {
                return HttpNotFound();
            }
            // заполнить выпадающий список авторов
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "FullName", book.AuthorID);
            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "BookID,BookName,AuthorID")] Book book)
        {// проверка корректности введенны данных
            if (ModelState.IsValid)
            {// изменение модели книги
                db.Entry(book).State = EntityState.Modified;
                await db.SaveChangesAsync(); // сохранение изменений
                return RedirectToAction("Index");
            }
            // заполнить выпадающий список авторов
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "FullName", book.AuthorID);
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null) // проверка на пустое значение
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = await db.Books.FindAsync(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {// книга для удаления
            Book book = await db.Books.FindAsync(id);
            db.Books.Remove(book); // удаление книги
            await db.SaveChangesAsync(); // сохранение изменений в БД
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {// завершение работы с БД
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
