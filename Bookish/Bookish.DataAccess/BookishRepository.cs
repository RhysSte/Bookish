using System.Collections.Generic;
using System.Data.SqlClient;
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
            return Connection.Query<Book>($"SELECT * FROM book WHERE Name CONTAINS {searchString}");
        }

        public int AddBook (string Name, int isbn, string Author)
        {
            return Connection.QuerySingle<int>($"INSERT INTO book(Title, Author, ISBN) VALUES({Name}, {Author}, {isbn}); SELECT SCOPE_IDENTITY()");
        }

        public int AddUser(string UserName)
        {
            return Connection.QuerySingle<int>($"INSERT INTO users(UserName) VALUES({UserName}); SELECT SCOPE_IDENTITY()");
        }

        public int getUserId(string userName)
        {
            //input method here
            var user = Connection.QuerySingle<User>($"SELECT * FROM users WHERE Name={userName}");
            return user.User_Id;
        }
    }
}
