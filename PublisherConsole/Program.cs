using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;
//check if the database exist.

using (PubContext context = new PubContext())
{
    context.Database.EnsureCreated();
}

AddAuthor();
AddAuthorWithBook();
GetAuthorsWithBooks();
QueryFilters();
QuerySort();
RetrieveAndUpdateAuthor();
RetrieveAndUpdateMultipleAuthors();
DeleteAuthor();
ParamQueryFilters();
GetAuthors();


//parameterized query
void ParamQueryFilters()
{
    using var context = new PubContext();
    var name = "Phidelist";
    var authors = context.Authors.Where(s => s.FirstName == name).ToList();
    foreach (var author in authors)
    {
        Console.WriteLine(author.LastName);
    }
}

//query filtering
void QueryFilters()
{
    using var context = new PubContext();
    var filter = "O%";
    var authors = context.Authors.Where(a => EF.Functions.Like(a.LastName,filter )).ToList();
    foreach( var author in authors){
        Console.WriteLine(author.LastName);
    }
}

//query filtering and sorting 
void QuerySort()
{
    using var context = new PubContext();
    var filter = "O%";
    var author = context.Authors.Where(a => EF.Functions.Like(a.LastName, filter)).FirstOrDefault();

    Console.WriteLine(author.LastName);
}
void AddAuthorWithBook()
{
    var author = new Author { FirstName = "Otonglo", LastName = "Ombulu" };
    author.Books.Add(new Book { Title = "Programing Entity FrameWork", PublishDate = new DateTime(2009, 1, 1) });
    author.Books.Add(new Book { Title = " C-sharp", PublishDate = new DateTime(2010, 8, 1) });
    using var context = new PubContext();
    context.Authors.Add(author);
    context.SaveChanges();
}

void GetAuthorsWithBooks()
{
    using var context = new PubContext();
    var authors = context.Authors.Include(a => a.Books).ToList();
    foreach (var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
        foreach (var book in author.Books)
        {
            Console.WriteLine("*" + book.Title);
        }
    }

}
void GetAuthors()
{
    using var context = new PubContext();
    var authors = context.Authors.ToList();
    foreach (var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
    }
}
void AddAuthor()
{
    var author = new Author { FirstName = "Phidelist", LastName = "Otiya" };
    using var context = new PubContext();
    context.Authors.Add(author);
    context.SaveChanges();
}
//updating data in the database
void RetrieveAndUpdateAuthor()
{
    using var context = new PubContext();
    var author = context.Authors.FirstOrDefault(a => a.FirstName == "Phidelist" && a.LastName == "Oluoch");
    if (author != null)
    {
        author.FirstName = "Delphit";
        context.SaveChanges();
    }
}
void RetrieveAndUpdateMultipleAuthors()
{
    using var context = new PubContext();
    var PhidelistAuthors = context.Authors.Where(a => a.LastName == "Oluoch").ToList();
    foreach (var ph in PhidelistAuthors)
    {
        ph.LastName = "Jakoti";
    }
    context.SaveChanges();
}
//deleting  Simplee object
void DeleteAuthor()
{
    using var context = new PubContext();
    var extraJL = context.Authors.Find(-1);
    if(extraJL != null)
    {
        context.Authors.Remove(extraJL);
        context.SaveChanges();
    }
}