using Bookish.DataAccess;
using System;

namespace Bookish
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookRepo = new BookishRepository();

            foreach (var book in bookRepo.GetAllBooks())
            {
                Console.WriteLine(book.Name.PadRight(54) + book.Author.PadRight(21) + book.Genre.PadRight(21));
            }

            Console.WriteLine("\n BookName".PadRight(20) + "Author".PadRight(20) + "Who Borrowed It".PadRight(20) + "Copy ID");

            foreach (var borrowed in bookRepo.GetMyBorrowedBooks(4))
            {
                // call get book method using borrowed.books_id
                var book = bookRepo.GetBook(borrowed.Books_ID);
                Console.WriteLine(book.Name.PadRight(20) + book.Author.PadRight(20) + borrowed.Borrowed_By_ID.ToString().PadRight(20) + borrowed.Copy_ID);
            }

            var bookSearch = Console.ReadLine();
            foreach (var search in bookRepo.SearchBooks(bookSearch))
            {
                Console.WriteLine(search.Name.PadRight(20), search.Author.PadRight(20), search.Author.PadRight(20));
            }
            Console.ReadLine();
        }
    }
}
