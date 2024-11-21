using OOP.LibraryManagementSystem.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.LibraryManagementSystem.Controllers
{
    internal class MagazineController : BaseController,IBaseController
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
                    table.AddColumn("[yellow]IssueNumber[/]");

                    //Filter for Magazine types
                    IEnumerable<Magazine>? magazines = MockDatabase.LibraryItems.OfType<Magazine>();

                    foreach (Magazine magazine in magazines)
                    {
                        table.AddRow(
                            magazine.Id.ToString(),
                            $"[cyan]{magazine.Name}[/]",
                            $"[cyan]{magazine.Publisher}[/]",
                            $"[cyan]{magazine.PublishDate:yyyy-MM-dd}[/]",
                            $"[cyan]{magazine.Location}[/]",
                            $"[cyan]{magazine.IssueNumber}[/]"
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
                string title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the magazine to add:");
                string publisher = AnsiConsole.Ask<string>("Enter the [green]publisher[/] of the magazine to add:");
                DateTime publishDate = AnsiConsole.Ask<DateTime>("Enter the [green]publish date[/] of the magazine (yyyy-MM-dd):");
                string location = AnsiConsole.Ask<string>("Enter the [green]location[/] of the magazine to add:");
                int issueNumber = AnsiConsole.Ask<int>("Enter the [green]issue number[/] of the magazine to add:");
                
                // checking if the magazine already exists to avoid duplication.
                if (MockDatabase.LibraryItems.OfType<Magazine>().Any(magazine => magazine.Name.Equals(title, StringComparison.OrdinalIgnoreCase)))
                {
                    DisplayMessage("This Magazine already exists.", "red");
                }
                else
                {
                    LibraryItem newMagazine = new Magazine(MockDatabase.LibraryItems.Count + 1, title, publisher, publishDate, location, issueNumber);
                    //if Magazine doesn't exist, add to the list of magazine.
                    MockDatabase.LibraryItems.Add(newMagazine);
                    DisplayMessage("Magazine added successfully!", "green");
                }

                DisplayMessage("Press Any Key to Continue.");
                Console.ReadKey();
            }
        }

        public void DeleteItem()
        {
            List<Magazine> magazines = MockDatabase.LibraryItems.OfType<Magazine>().ToList();

            if (magazines.Count == 0)
            {
                DisplayMessage("No Magazines available to delete.", "red");
                Console.ReadKey();
                return;
            }

            /* showing a list of magazines and letting the user choose with arrows 
                using SelectionPrompt, similarly to what we do with the menu */

            Magazine magazineToDelete = AnsiConsole.Prompt(
                new SelectionPrompt<Magazine>()
                .Title("Select a [red]magazine[/] to delete:")
                .UseConverter(magazine => $"{magazine.Name} by {magazine.Publisher})")
                .AddChoices(magazines)
                );


            /* Using the Remove method to delete a magazine. This method returns a boolean
                that we can use to present a message in case of success or failure.*/
            if (ConfirmDeletion(magazineToDelete.Name))
            {
                if (MockDatabase.LibraryItems.Remove(magazineToDelete))
                {
                    DisplayMessage("Magazine deleted successfully!", "red");
                }
                else
                {
                    DisplayMessage("Magazine not found.", "red'");
                }
            }

            DisplayMessage("Press Any Key to Continue.");
            Console.ReadKey();
        }
    }
}
