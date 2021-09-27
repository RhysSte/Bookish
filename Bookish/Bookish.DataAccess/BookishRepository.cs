using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Bookish.DataAccess
{
    public class BookishRepository
    {
        public string ConnectionString { get; set; }
        public SqlConnection Connection { get; set; }
        //string writeName = Console.ReadLine();

        public BookishRepository()
        {
            ConnectionString = @"server=localhost;Database=Bookish;Trusted_Connection=True;";
            Connection = new SqlConnection(ConnectionString);
            Connection.Open();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return Connection.Query<Book>("SELECT * FROM book");
        }

        public IEnumerable<User> GetAllUsers()
        {
            return Connection.Query<User>("SELECT * FROM users");
        }

        public IEnumerable<Copies> GetAllCopies(int ID)
        {
            return Connection.Query<Copies>($"SELECT * FROM copies WHERE Books_ID = {ID}");
        }

        public IEnumerable<Copies> GetMyBorrowedBooks(int userID)
        {
            return Connection.Query<Copies>($"SELECT * FROM copies WHERE Borrowed_By_ID = {userID}");
        }

        public IEnumerable<Book> SearchBooks(string searchString)
        {
            return Connection.Query<Book>($"SELECT * FROM copies WHERE UserID = {searchString}");
        }

        public Book GetBook(int Id)
        {
            //Get book
            //get copies
            //return book
        }

        public AddBook(Book book int numCopies)
        {
            // get all users
            // borrow book(int bookID, int userId, DateTime dueDate
        }
    }

}
