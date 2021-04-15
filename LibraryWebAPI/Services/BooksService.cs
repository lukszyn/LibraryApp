using LibraryWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryWebAPI.Services
{
    public interface IBooksService
    {
        int Add(Book book);
        void Delete(int id);
        Book Get(int id);
        List<Book> GetAll();
        int Update(int id, Book book);
    }

    public class BooksService : IBooksService
    {
        private Func<IAppDbContext> _dbContextFactoryMethod;

        public BooksService(Func<IAppDbContext> dbContextFactoryMethod)
        {
            _dbContextFactoryMethod = dbContextFactoryMethod;
        }

        public int Add(Book book)
        {
            using (var context = _dbContextFactoryMethod())
            {
                context.Books.Add(book);
                context.SaveChanges();

                return book.Id;
            }

        }

        public Book Get(int id)
        {
            using (var context = _dbContextFactoryMethod())
            {
                return context.Books.FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Book> GetAll()
        {
            using (var context = _dbContextFactoryMethod())
            {
                return context.Books.ToList();
            }
        }

        public int Update(int id, Book book)
        {
            using (var context = _dbContextFactoryMethod())
            {
                context.Books.Update(book);
                context.SaveChanges();
                return id;
            }
        }

        public void Delete(int id)
        {
            using (var context = _dbContextFactoryMethod())
            {
                var book = context.Books.FirstOrDefault(x => x.Id == id);
                context.Books.Remove(book);
                context.SaveChanges();
            }
        }
    }
}
