using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPNETMVCApplication.Models;

namespace ASPNETMVCApplication.Controllers
{
    public class BookController : Controller
    {
        BookDBContext _db = new BookDBContext();

       

        public ActionResult Index()
        {
            var books = from book in _db.Books
                        select book;

            return View(books.ToList());
        }

     

        public ActionResult Details(int id)
        {
            Book book = _db.Books.Find(id);

            if (book == null)
                return RedirectToAction("Index");

            return View("Details", book);
        }

     

        public ActionResult Create()
        {
            return View();
        }

      

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Book book = new Book();
                if (ModelState.IsValid)
                {
                    book.Title = collection["Title"].ToString();
                    book.ISBN = collection["ISBN"].ToString();
                    book.Price = Convert.ToDecimal(collection["Price"]);

                    _db.Books.Add(book);
                    _db.SaveChanges();
                  

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(book);
                }
            }
            catch
            {
                return View();
            }
        }

   

        public ActionResult Edit(int id)
        {
            Book book = _db.Books.Find(id);
            if (book == null)
                return RedirectToAction("Index");

            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var book = _db.Books.Find(id);

                UpdateModel(book);
                _db.SaveChanges();
               
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Edit Failure, see inner exception");
                return View();
            }
        }

   
        public ActionResult Delete(int id)
        {
            Book book = _db.Books.Find(id);
            if (book == null)
                return RedirectToAction("Index");

            return View(book);
        }



        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            Book book = _db.Books.Find(id);
            _db.Books.Remove(book);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}