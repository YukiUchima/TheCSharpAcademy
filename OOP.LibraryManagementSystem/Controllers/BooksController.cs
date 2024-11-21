using OOP.LibraryManagementSystem.Models;
using Spectre.Console;

namespace OOP.LibraryManagementSystem.Controllers;

internal class BooksController : BaseController,IBaseController
{
    public void ViewItems()
    {
        {
            {
                var table = new Table();
                table.Border(TableBorder.Rounded);

                table.AddColumn("[yellow]ID[/]");
                table.AddColumn("[yellow]Title[/]");
                table.AddColumn("[yellow]Author[/]");
                table.AddColumn("[yellow]Category[/]");
                table.AddColumn("[yellow]Location[/]");
                table.AddColumn("[yellow]Pages[/]");

                //Filter for book types
                var books = MockDatabase.LibraryItems.OfType<Book>();

                foreach (Book book in books)
                {
                    table.AddRow(
                        book.Id.ToString(),
                        $"[cyan]{book.Name}[/]",
                        $"[cyan]{book.Author}[/]",
                        $"[cyan]{book.Category}[/]",
                        $"[cyan]{book.Location}[/]",
                        //$"[cyan]{book.Pages}[/]",
                        book.Pages.ToString()
                        );
                }

                AnsiConsole.Write(table);
                AnsiConsole.MarkupLine("Press Any Key to Continue");
                Console.ReadKey();
            }
        }
    }
    
    public void AddItem()
    {
        {
            string title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the book to add:");
            string author = AnsiConsole.Ask<string>("Enter the [green]author[/] of the book to add:");
            string category = AnsiConsole.Ask<string>("Enter the [green]category[/] of the book to add:");
            string location = AnsiConsole.Ask<string>("Enter the [green]location[/] of the book to add:");
            int pages = AnsiConsole.Ask<int>("Enter the [green]number of pages[/] in the book");

            // checking if the book already exists to avoid duplication.
            if (MockDatabase.LibraryItems.OfType<Book>().Any(book => book.Name.Equals(title, StringComparison.OrdinalIgnoreCase)))
            {
                DisplayMessage("This book already exists.", "red");
            }
            else
            {
                LibraryItem newBook = new Book(MockDatabase.LibraryItems.Count + 1, title, location, author, category, pages);
                //if book doesn't exist, add to the list of books.
                MockDatabase.LibraryItems.Add(newBook);
                DisplayMessage("Book added successfully!", "green");
            }

            DisplayMessage("Press Any Key to Continue.");
            Console.ReadKey();
        }
    }

    public void DeleteItem()
    {
        List<Book> books = MockDatabase.LibraryItems.OfType<Book>().ToList();

        if (books.Count == 0)
        {
            DisplayMessage("No books available to delete.", "red");
            Console.ReadKey();
            return;
        }

        /* showing a list of books and letting the user choose with arrows 
            using SelectionPrompt, similarly to what we do with the menu */

        Book bookToDelete = AnsiConsole.Prompt(
            new SelectionPrompt<Book>()
            .Title("Select a [red]book[/] to delete:")
            .UseConverter(bk => $"{bk.Name} by {bk.Author} (pages: {bk.Pages})")
            .AddChoices(books)
            );


        /* Using the Remove method to delete a book. This method returns a boolean
            that we can use to present a message in case of success or failure.*/
        if (ConfirmDeletion(bookToDelete.Name))
        {
            if (MockDatabase.LibraryItems.Remove(bookToDelete))
            {
                DisplayMessage("Book deleted successfully!", "red");
            }
            else
            {
                DisplayMessage("Book not found.", "red");
            }
        }

        DisplayMessage("Press Any Key to Continue.");
        Console.ReadKey();
    }
}
