using PublisherData;
using PublisherDomain;

namespace PublisherConsole
{
    internal class HelperMethods
    {
        public static Author GetAuthor(PubContext context, int id)
        {
            var author = context.Authors.FirstOrDefault(x => x.Id == id);
            return author;
        }

        public static Author GetAuthor(PubContext context, string firstName, string lastName)
        {
            var author = context.Authors.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            return author;
        }

        public static void WriteAllAuthors(PubContext context)
        {
            var authors = context.Authors.ToList();
            foreach (var author in authors)
            {
                Console.WriteLine(author.FirstName + " " + author.LastName);
            }
        }

        public static void WriteAllAuthorsWithBooks(PubContext context)
        {
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

        public static void AddAuthor(PubContext context, string firstName, string lastName)
        {
            var author = new Author { FirstName = firstName, LastName = lastName };
            context.Authors.Add(author);
            context.SaveChanges();
        }

        public static void AddAuthorWithBooks(PubContext context, string firstName, string lastName, string title, DateTime publishDate)
        {
            var author = new Author { FirstName = firstName, LastName = lastName };
            author.Books.Add(new Book { Title = title, PublishDate = publishDate });
            context.Authors.Add(author);
            context.SaveChanges();
        }

        public static void AddBookToExistingAuthor(PubContext context, Author author, string title, DateTime publishDate)
        {
            var book = new Book { Title = title, PublishDate = publishDate };
            var auth = context.Authors.FirstOrDefault(x => x.Id == author.Id);
            if (auth != null)
            {
                auth.Books.Add(book);
            }
            context.SaveChanges();
        }

        public Author GetOrderedAuthors(PubContext context, string lastName)
        {
            var author = context.Authors.OrderByDescending(a => a.FirstName).FirstOrDefault(a => a.LastName == lastName);
            return author;
        }


    }
}
