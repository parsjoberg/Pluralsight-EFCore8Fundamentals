using PublisherData;

using (PubContext context = new())
{
       context.Database.EnsureCreated();
}

GetAuthors();

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