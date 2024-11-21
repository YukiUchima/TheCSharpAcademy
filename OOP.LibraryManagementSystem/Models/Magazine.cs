using Spectre.Console;

namespace OOP.LibraryManagementSystem.Models;

internal class Magazine:LibraryItem
{
    public string Publisher {  get; set; }
    public DateTime PublishDate { get; set; }
    public int IssueNumber {  get; set; }

    public Magazine(int id, string name, string publisher,  DateTime publishDate, string location, int issueNumber):base(id, name, location)
    {
        Publisher = publisher;
        PublishDate = publishDate;
        IssueNumber = issueNumber;
    }

    public override void DisplayDetails()
    {
        var panel = new Panel(new Markup($"[bold]Magazine:[/] [cyan]{Name}[/] published by [cyan]{Publisher}[/]") +
            $"[bold]Publish Date:[/] {PublishDate:yyyy-MM-dd}" +
            $"[bold]Issue Number:[/] {IssueNumber}" +
            $"[bold]Loction:[/] [blue]{Location}[/]"
            )
        {
            Border = BoxBorder.Rounded
        };

        AnsiConsole.Write(panel);
    }
}
