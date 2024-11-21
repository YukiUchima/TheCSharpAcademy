using OOP.LibraryManagementSystem.Models;
using Spectre.Console;

namespace OOP.LibraryManagementSystem.Controllers
{
    internal class NewsPaperController : BaseController,IBaseController
    {
        public void ViewItems()
        {
            {
                {
                    var table = new Table();
                    table.Border(TableBorder.Rounded);

                    table.AddColumn("[yellow]ID[/]");
                    table.AddColumn("[yellow]Title[/]");
                    table.AddColumn("[yellow]Publisher[/]");
                    table.AddColumn("[yellow]Publish Date[/]");
                    table.AddColumn("[yellow]Location[/]");

                    //Filter for Newspaper types
                    IEnumerable<Newspaper>? newspapers = MockDatabase.LibraryItems.OfType<Newspaper>();

                    foreach (Newspaper newspaper in newspapers)
                    {
                        table.AddRow(
                            newspaper.Id.ToString(),
                            $"[cyan]{newspaper.Name}[/]",
                            $"[cyan]{newspaper.Publisher}[/]",
                            $"[cyan]{newspaper.PublishDate:yyyy-MM-dd}[/]",
                            $"[cyan]{newspaper.Location}[/]"
                            );
                    }

                    AnsiConsole.Write(table);
                    DisplayMessage("Press Any Key to Continue");
                    Console.ReadKey();
                }
            }
        }

        public void AddItem()
        {
            {
                string title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the newspaper to add:");
                string publisher = AnsiConsole.Ask<string>("Enter the [green]publisher[/] of the newspaper to add:");
                DateTime publishDate = AnsiConsole.Ask<DateTime>("Enter the [green]publish date[/] of the newspaper (yyyy-MM-dd):");
                string location = AnsiConsole.Ask<string>("Enter the [green]location[/] of the newspaper to add:");
                
                // checking if the newspaper already exists to avoid duplication.
                if (MockDatabase.LibraryItems.OfType<Newspaper>().Any(np => np.Name.Equals(title, StringComparison.OrdinalIgnoreCase)))
                {
                    DisplayMessage("This Newspaper already exists", "red");
                }
                else
                {
                    LibraryItem newPaper = new Newspaper(MockDatabase.LibraryItems.Count + 1, title, publisher, publishDate, location);
                    //if Newspaper doesn't exist, add to the list of newspapers.
                    MockDatabase.LibraryItems.Add(newPaper);
                    DisplayMessage("Newspaper added successfully!", "green");
                }

                DisplayMessage("Press Any Key to Continue.");
                Console.ReadKey();
            }
        }

        public void DeleteItem()
        {
            List<Newspaper> newspapers = MockDatabase.LibraryItems.OfType<Newspaper>().ToList();

            if (newspapers.Count == 0)
            {
                DisplayMessage("No Newspaper available to delete.", "red");
                Console.ReadKey();
                return;
            }

            /* showing a list of Newspaper and letting the user choose with arrows 
                using SelectionPrompt, similarly to what we do with the menu */

            Newspaper npDelete = AnsiConsole.Prompt(
                new SelectionPrompt<Newspaper>()
                .Title("Select a [red]newspaper[/] to delete:")
                .UseConverter(np => $"{np.Name} by {np.Publisher})")
                .AddChoices(newspapers)
                );


            /* Using the Remove method to delete a book. This method returns a boolean
                that we can use to present a message in case of success or failure.*/
            if (ConfirmDeletion(npDelete.Name))
            {
                if (MockDatabase.LibraryItems.Remove(npDelete))
                {
                    DisplayMessage("Newspaper deleted successfully!", "red");
                }
                else
                {
                    DisplayMessage("Newspaper not found.", "red");
                }

                DisplayMessage("Press Any Key to Continue.");
                Console.ReadKey();
            }
        }
    }
}
