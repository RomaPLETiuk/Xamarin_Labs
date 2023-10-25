using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Lab6
{
    public class DB : IDisposable
    {

        private readonly SQLiteConnection conn;

        public DB(string path)
        {
            conn = new SQLiteConnection(path);
            conn.CreateTable<Book>();
        }

        public List<Book> GetBooks()
        {
            return conn.Table<Book>().ToList();
        }

        public List<Book> GetBooksOlderThan10Years()
        {
            int currentYear = DateTime.Now.Year;
            int tenYearsAgo = currentYear - 10;

            return conn.Table<Book>().Where(book => book.Year < tenYearsAgo).ToList();
        }

        public int SavePersonAsync(Book person)
        {
            return conn.Insert(person);
        }

        public void UpdateBook(Book book)
        {
            conn.Update(book);
        }

        public void Dispose()
        {
            conn.Dispose();
        }


    }
}
