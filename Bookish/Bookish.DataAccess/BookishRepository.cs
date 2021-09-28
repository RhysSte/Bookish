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

        public IEnumerable<Copies> GetAllCopies(int Id)
        {
            return Connection.Query<Copies>($"SELECT * FROM copies WHERE Books_ID = {Id}");
        }

        public IEnumerable<Copies> GetMyBorrowedBooks(int userId)
        {
            return Connection.Query<Copies>($"SELECT * FROM copies WHERE Borrowed_By_ID = {userId}");
        }

        //make new method, get book
        //pass in id and it gives book

        public Book GetBook(int bookId)
        {
            return Connection.QuerySingle<Book>($"SELECT * FROM book WHERE Book_ID = {bookId}");
        }

        public IEnumerable<Book> SearchBooks(string searchString)
        {
            return Connection.Query<Book>($"SELECT * FROM copies WHERE UserID = {searchString}");
        }

        public int AddBook (string BookName, int ISBN, string Author)
        {
            return Connection.QuerySingle<int>($"INSERT INTO Books(Title, Author, ISBN) VALUES({BookName}, {Author}, {ISBN}); SELECT SCOPE_IDENTITY()");
        }
    }
}
