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
            
            WriteAllAuthors();
            AddAuthor("Aaron", "Jackson");
            AddAuthorWithBooks("Aaron", "Jackson", "Learning EF Core", new DateTime(2022, 11, 25));
            var author = GetAuthor(3);
            AddBookToExistingAuthor(author, "Learning EF Core 2nd Edition", new DateTime(2022, 11, 28));
            WriteAllAuthorsWithBooks();

            
        }

        
    }   
}