using Spectre.Console;

namespace OOP.LibraryManagementSystem.Models;

internal class Newspaper:LibraryItem
{
    public string Publisher { get; set; }
    public DateTime PublishDate { get; set; }

    public Newspaper(int id, string name, string publisher, DateTime publishDate, string location):base(id, name, location)
    {
        Publisher = publisher;
        PublishDate = publishDate;
    }

    public override void DisplayDetails()
    {
        var panel = new Panel(new Markup($"[bold]Newspaper:[/] [cyan]{Name}[/] published by [cyan]{Publisher}[/]") +
                              $"\n[bold]Publish Date:[/] {PublishDate:yyyy-MM-dd}" +
                              $"\n[bold]Location:[/] [blue]{Location}[/]")
        {
            Border = BoxBorder.Rounded
        };

        AnsiConsole.Write(panel);
    }
}
