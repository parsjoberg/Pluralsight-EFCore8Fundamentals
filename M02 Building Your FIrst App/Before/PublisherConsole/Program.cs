using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using PublisherData;
using PublisherDomain;

using (PubContext context = new())
{
    context.Database.EnsureCreated();
}

//GetAuthors();
//AddAuthor();
//GetAuthors();
AddAutorWithBooks();
GetAuthorsWithBooks();

void AddAutorWithBooks()
{
    var author = new Author
    {
        FirstName = "John",
        LastName = "Smith",
        Books = new List<Book>
        {
            new Book { Title = "C# Programming", PublishDate = new DateOnly(2020, 1, 1) },
            new Book { Title = "ASP.NET Core", PublishDate = new DateOnly(2021, 6, 15) }
        }
    };
    using PubContext context = new();
    context.Authors.Add(author);
    context.SaveChanges();

}

void GetAuthorsWithBooks()
{
    using PubContext context = new();
    
    var authors = context.Authors
        .Include(a => a.Books)
        .ToList();
    foreach (var author in authors)
    {
        Console.WriteLine($"{author.FirstName} {author.LastName}");
        foreach (var book in author.Books)
        {
            Console.WriteLine($"\t{book.Title} - {book.PublishDate}");
        }
    }
}

void AddAuthor()
{
    var author = new Author
    {
        FirstName = "Jane",
        LastName = "Doe"
    };
    using (PubContext context = new())
    {
        context.Authors.Add(author);
        context.SaveChanges();
    }
}
void GetAuthors()
{
    using (PubContext context = new())
    {
        var authors = context.Authors.ToList();
        foreach (var author in authors)
        {
            Console.WriteLine($"{author.FirstName} {author.LastName}");
        }
    }
}