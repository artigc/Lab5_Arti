/* Name: Arti Chovatiya
 * Id: 100812472
 * Date: Dec 07, 2021
 * Description: Project that keeps the record of books and which student issued the books.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab5_Arti.Models;

namespace Lab5_Arti.Controllers
{
       public class BooksController : Controller
        {
            private readonly BookContext _context;

            public BooksController(BookContext context)
            {
                _context = context;
            }

            // GET: Books
            public async Task<IActionResult> Index()
            {
                return View(await _context.Books.ToListAsync());
            }

            // GET: book/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var book = await _context.Books
                    .FirstOrDefaultAsync(m => m.bookId == id);
                if (book == null)
                {
                    return NotFound();
                }

                return View(book);
            }


            // GET: Books/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: Books/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("bookId, bookName, authorName, totalBooks, publishDate")] Books book)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(book);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(book);
            }


            // GET: Books/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var car = await _context.Books.FindAsync(id);
                if (car == null)
                {
                    return NotFound();
                }
                return View(car);
            }

            // POST: Cars/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("bookId, bookName, authorName, totalBooks, publishDate")] Books book)
            {
                if (id != book.bookId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(book);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!BookExists(book.bookId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(book);
            }

            private bool BookExists(int id)
            {
                return _context.Books.Any(e => e.bookId == id);
            }


            // POST: Books/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var car = await _context.Books.FindAsync(id);
                _context.Books.Remove(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

        #region Students

        // GET: studentRecords
        public async Task<IActionResult> GetRecords()
        {
            return View(await _context.Students.ToListAsync());
        }

        #endregion
    }
}
