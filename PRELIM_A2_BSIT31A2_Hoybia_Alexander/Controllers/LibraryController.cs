using Microsoft.AspNetCore.Mvc;
using PRELIM_A2_BSIT31A2_Hoybia_Alexander.Models;

namespace PRELIM_A2_BSIT31A2_Hoybia_Alexander.Controllers
{
    public class LibraryController : Controller
    {
        private static List<Author> Authors = new();
        private static List<Book> Books = new();
        private static List<User> Users = new();
        private static Library Library = new();
        private static bool DataBooks = false;

        public IActionResult Index()
        {
            if (!DataBooks)
            {
                SkibidiData();
                DataBooks = true;
            }

            if (Library == null)
                Library = new Library();

            Library.ListOfBooks = Books;

            return View("~/Views/Home/Index.cshtml", (Library, Users));
        }
        public IActionResult Privacy()
{
    if (!DataBooks)
    {
        SkibidiData();
        DataBooks = true;
    }

    if (Library == null)
        Library = new Library();

    Library.ListOfBooks = Books;

    return View("~/Views/Home/Index.cshtml", (Library, Users));
}


        public IActionResult AddBook(string title, string isbn, int authorId)
        {
            var author = Authors.FirstOrDefault(a => a.Id == authorId);
            if (author == null) return NotFound();

            var book = new Book
            {
                Id = Books.Count + 1,
                Title = title,
                ISBN = isbn,
                AuthorId = authorId,
                Author = author
            };

            Books.Add(book);
            author.Books.Add(book);

            return RedirectToAction("Index");
        }

        public IActionResult BorrowBook(int userId, int bookId)
        {
            var user = Users.FirstOrDefault(u => u.Id == userId);
            var book = Books.FirstOrDefault(b => b.Id == bookId);

            if (user == null || book == null || book.Status) return NotFound();

            book.Status = true;
            user.BorrowedBooks.Add(new BookBorrowed
            {
                Id = user.BorrowedBooks.Count + 1,
                Book = book,
                BorrowedDate = DateTime.Now
            });

            return RedirectToAction("Index");
        }

        public IActionResult ReturnBook(int userId, int bookId)
        {
            var user = Users.FirstOrDefault(u => u.Id == userId);
            var borrowed = user?.BorrowedBooks.FirstOrDefault(bb => bb.Book.Id == bookId && bb.ReturnedDate == null);

            if (borrowed == null) return NotFound();

            borrowed.ReturnedDate = DateTime.Now;
            borrowed.Book.Status = false;

            return RedirectToAction("Index");
        }

        private void SkibidiData()
        {
            // Authors
            Authors.AddRange(new List<Author>
    {
            new Author { Id = 1, Name = "George Orwell" },
            new Author { Id = 2, Name = "J.K. Rowling" },
            new Author { Id = 3, Name = "J.R.R. Tolkien" },
            new Author { Id = 4, Name = "Suzanne Collins", },
            new Author { Id = 5, Name = "Dan Brown", },
            new Author { Id = 6, Name = "Hajime Isayama", },
            new Author { Id = 7, Name = "Eiichiro Oda", },
            new Author { Id = 8, Name = "Koyoharu Gotouge", },
            new Author { Id = 9, Name = "Tite Kubo", },
            new Author { Id = 10, Name = "Masashi Kishimoto", },
            new Author { Id = 11, Name = "Gege Akutami", },
            new Author { Id = 12, Name = "Yuki Tabata", },
            new Author { Id = 13, Name = "J-R Nanilaw", }


    });

            // Books
            Books.AddRange(new List<Book>
    {
       
            new Book { Id = 1, Title = "1984", ISBN = "978-0-13-493582-0", AuthorId = 1, Author = Authors[0] },
            new Book { Id = 2, Title = "Animal Farm", ISBN = "978-1-61-729413-6", AuthorId = 1, Author = Authors[0] },
            new Book { Id = 3, Title = "Harry Potter and the Sorcerer's Stone", ISBN = "979-8-65-427902-2", AuthorId = 2, Author = Authors[1] },
            new Book { Id = 4, Title = "Harry Potter and the Chamber of Secrets", ISBN = "978-0-07-184155-5", AuthorId = 2, Author = Authors[1] },
            new Book { Id = 5, Title = "Skibidi The Madness of Nanilaw", ISBN = "978-0-07-184155-5", AuthorId = 13, Author = Authors[12] },
            new Book { Id = 6, Title = "The Fellowship of the Ring", ISBN = "979-1-12-784030-9", AuthorId = 13, Author = Authors[2] },
            new Book { Id = 7, Title = "The Hunger Games", ISBN = "978-0-19-953556-9", AuthorId = 4, Author = Authors[3] },
            new Book { Id = 8, Title = "Catching Fire", ISBN = "978-1-40-289462-1", AuthorId = 4, Author = Authors[3] },
            new Book { Id = 9, Title = "The Da Vinci Code", ISBN = "979-0-45-276893-7", AuthorId = 5, Author = Authors[4] },
            new Book { Id = 10, Title = "Angels & Demons", ISBN = "978-1-59-327599-0", AuthorId = 5, Author = Authors[4] },
            new Book { Id = 11, Title = "Attack on Titan Vol. 1", ISBN = "979-8-78-944331-3", AuthorId = 6, Author = Authors[5] },
            new Book { Id = 12, Title = "Attack on Titan Vol. 2", ISBN = "978-0-06-231609-7", AuthorId = 6, Author = Authors[5] },
            new Book { Id = 13, Title = "One Piece Vol. 1", ISBN = "978-1-25-078024-1", AuthorId = 7, Author = Authors[6] },
            new Book { Id = 14, Title = "One Piece Vol. 2", ISBN = "979-1-10-392450-6", AuthorId = 7, Author = Authors[6] },
            new Book { Id = 15, Title = "Demon Slayer Vol. 1", ISBN = "978-0-14-312774-1", AuthorId = 8, Author = Authors[7] },
            new Book { Id = 16, Title = "Demon Slayer Vol. 2", ISBN = "978-1-50-117321-9", AuthorId = 8, Author = Authors[7] },
            new Book { Id = 17, Title = "Bleach Vol. 1", ISBN = "979-8-90-123443-0", AuthorId = 9, Author = Authors[8] },
            new Book { Id = 18, Title = "Bleach Vol. 2", ISBN = "978-0-06-245773-8", AuthorId = 9, Author = Authors[8] },
            new Book { Id = 19, Title = "Naruto Vol. 1", ISBN = "978-1-26-045765-3", AuthorId = 10, Author = Authors[9] },
            new Book { Id = 20, Title = "Naruto Vol. 2", ISBN = "979-0-39-874540-2", AuthorId = 10, Author = Authors[9] },
            new Book { Id = 21, Title = "Jujutsu Kaisen Vol. 1", ISBN = "978-1-93-518204-4", AuthorId = 11, Author = Authors[10] },
            new Book { Id = 22, Title = "Jujutsu Kaisen Vol. 2", ISBN = "978-0-13-110362-7", AuthorId = 11, Author = Authors[10] },
            new Book { Id = 23, Title = "Black Clover Vol. 1", ISBN = "979-8-55-014255-5", AuthorId = 12, Author = Authors[11] },
            new Book { Id = 24, Title = "Black Clover Vol. 2", ISBN = "978-1-49-207800-5", AuthorId = 12, Author = Authors[11] },
            new Book { Id = 25, Title = "Attack on Titan: No Regrets", ISBN = "969-7-33-782100-4", AuthorId = 6, Author = Authors[5] }
    });
        

            foreach (var book in Books)
            {
                var author = Authors.First(a => a.Id == book.AuthorId);
                author.Books.Add(book);
            }

            // Users
            Users.AddRange(new List<User>
{
             new User { Id = 1, Username = "ErenNeager", Email = "eren@skibidi.com" },             
             new User { Id = 2, Username = "luffyGoma", Email = "luffy@gmail.com" },             
             new User { Id = 3, Username = "NezukoChan", Email = "nezuko@skibidi.com" },         
             new User { Id = 4, Username = "Itadori", Email = "itadori@gmail.com" },         
             new User { Id = 5, Username = "Naruto", Email = "naruto@skibidi.com" },         
             new User { Id = 6, Username = "lightYaga", Email = "light@gmail.com" },             
             new User { Id = 7, Username = "SuperGoku021", Email = "goku@skibidi.com" },             
             new User { Id = 8, Username = "Tanjori", Email = "tanjiro@gmail.com" }          
            });


            // Borrowing
            void Borrowed(User user, int bookId, int daysAgo, int? returnAfterDays = null)
            {
                var book = Books.First(b => b.Id == bookId);
                var borrowDate = DateTime.Now.AddDays(-daysAgo);
                var returnDate = returnAfterDays.HasValue ? borrowDate.AddDays(returnAfterDays.Value) : (DateTime?)null;
                book.Status = returnDate == null;
                user.BorrowedBooks.Add(new BookBorrowed
                {
                    Id = user.BorrowedBooks.Count + 1,
                    Book = book,
                    BorrowedDate = borrowDate,
                    ReturnedDate = returnDate
                });
            }

            // Borrowed books
            Borrowed(Users[0], 5, 10);
            Borrowed(Users[0], 3, 20, 15);
            Borrowed(Users[1], 10, 3); 
            Borrowed(Users[1], 8, 5, 2);
            Borrowed(Users[2], 12, 30);
            Borrowed(Users[2], 15, 18, 10);
            Borrowed(Users[3], 21, 2);
            Borrowed(Users[4], 9, 14, 5);
            Borrowed(Users[4], 13, 1);
            Borrowed(Users[5], 17, 6);
            Borrowed(Users[5], 18, 8, 4);
            Borrowed(Users[6], 25, 12);
            Borrowed(Users[6], 6, 15, 10);
            Borrowed(Users[7], 2, 20, 10);
            Borrowed(Users[7], 4, 4);

        }
    }
}
