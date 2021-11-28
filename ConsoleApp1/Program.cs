// See https://aka.ms/new-console-template for more information

using System;
using System.Threading.Tasks;
using ConsoleApp1.DataAccess;
using ConsoleApp1.Model;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        InsertBook();
    }

    private static async Task InsertBook()
    {
        Authors Bente = new()
        {
            FristName = "Bente",
            LastName = "Larsen",
            Bio = "Likes bdsm porn"
        };

        Genres horror = new()
        {
            GenreName = "Horror"
        };
        
        Books book1 = new Books
        {
            Title = "d",
            TotalPages = 55,
            author = Bente,
            genre = horror,
            PublishDate = new DateTime(2000, 05, 21)
        };

        using ViaDBContext dbContext = new ViaDBContext();
        
        await dbContext.Books.AddAsync(book1);
        await dbContext.Genres.AddAsync(horror);
        await dbContext.Authors.AddAsync(Bente);

        await dbContext.SaveChangesAsync();
    }

    private async Task UpdateBook()
    {
        using ViaDBContext db = new();
        
    }
    
}

