global using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;
using static PublisherConsole.HelperMethods;

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

            var _context = new PubContext();
            
            WriteAllAuthors(_context);
            AddAuthor(_context,"Aaron", "Jackson");
            AddAuthorWithBooks(_context, "Aaron", "Jackson", "Learning EF Core", new DateTime(2022, 11, 25));
            var author = GetAuthor(_context,3);
            AddBookToExistingAuthor(_context,author, "Learning EF Core 2nd Edition", new DateTime(2022, 11, 28));
            WriteAllAuthorsWithBooks(_context);

            
        }

        
    }   
}