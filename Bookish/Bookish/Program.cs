using Bookish.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            //foreach (var user in bookRepo.GetAllUsers())
            //{
            //    Console.WriteLine(user.Name);
            //}
            
            //borrow books
            //br
            //Console.WriteLine(Name of book, Author, who borrowed it ID, Copy ID);

            Console.WriteLine("\n BookName".PadRight(20) + "Author".PadRight(20) + "Who Borrowed It".PadRight(20) + "Copy ID");

            foreach (var borrowed in bookRepo.GetMyBorrowedBooks(4))
            {
                // call get book method using borrowed.books_id
                var book = bookRepo.GetBook(borrowed.Books_ID);
                Console.WriteLine(book.Name.PadRight(20) + book.Author.PadRight(20) + borrowed.Borrowed_By_ID.ToString().PadRight(20) + borrowed.Copy_ID);
            }
            Console.ReadLine();
        }
    }
}
