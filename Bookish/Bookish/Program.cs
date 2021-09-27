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

            foreach (var user in bookRepo.GetAllUsers())
            {
                Console.WriteLine(user.Name);
            }

            foreach (var copy in bookRepo.GetAllCopies())
            {
                Console.WriteLine(copy.Due_Date);
            }
            
            //borrow books
            //br
            //Console.WriteLine(Name of book, Author, who borrowed it ID, Copy ID);

            foreach (var userSendingData in bookRepo.GetMyBorrowedBooks(1))
            {
                Console.WriteLine(userSendingData);
            }
            
            Console.ReadLine();
        }
    }
}
