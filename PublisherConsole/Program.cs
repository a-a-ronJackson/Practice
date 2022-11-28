using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;

namespace PublisherConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (PubContext context = new PubContext())
            {
                context.Database.EnsureCreated();
            }
            
            //WriteAllAuthors();
            //AddAuthor("Aaron", "Jackson");
            //AddAuthorWithBooks("Aaron", "Jackson", "Learning EF Core", new DateTime(2022, 11, 25));
            var author = GetAuthor(3);
            AddBookToExistingAuthor(author, "Learning EF Core 2nd Edition", new DateTime(2022, 11, 28));
            WriteAllAuthorsWithBooks();

            void WriteAllAuthors()
            {
                using var context = new PubContext();
                var authors = context.Authors.ToList();
                foreach (var author in authors)
                {
                    Console.WriteLine(author.FirstName + " " + author.LastName);
                }
            }

            void WriteAllAuthorsWithBooks()
            {
                using var context = new PubContext();
                var authors = context.Authors.Include(x => x.Books).ToList();
                foreach (var author in authors)
                {
                    Console.WriteLine(author.FirstName + " " + author.LastName);
                    foreach (var book in author.Books)
                    {
                        Console.WriteLine("    *" + book.Title);
                    }
                }
            }

            void AddAuthor(string firstName, string lastName)
            {
                var author = new Author { FirstName = firstName, LastName = lastName };
                using var context = new PubContext();
                context.Authors.Add(author);
                context.SaveChanges();
            }

            void AddAuthorWithBooks(string firstName, string lastName, string title, DateTime publishDate)
            {
                var author = new Author { FirstName = firstName, LastName = lastName };
                author.Books.Add(new Book { Title = title, PublishDate = publishDate });
                using var context = new PubContext();
                context.Authors.Add(author);
                context.SaveChanges();
            }

            void AddBookToExistingAuthor(Author author, string title, DateTime publishDate)
            {
                var context = new PubContext();
                var book = new Book { Title = title, PublishDate = publishDate };
                var auth = context.Authors.FirstOrDefault(x => x.Id== author.Id);
                if(auth != null)
                {
                    auth.Books.Add(book);
                }
                context.SaveChanges();
            }
        }

        private static Author GetAuthor(int id)
        {
            using var context = new PubContext();
            var author = context.Authors.FirstOrDefault(x => x.Id == id);
            return author;
        }

        private static Author GetAuthor(string firstName, string lastName)
        {
            using var context = new PubContext();
            var author = context.Authors.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            return author; 
        }
    }   
}