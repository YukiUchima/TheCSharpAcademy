using OOP.LibraryManagementSystem.Controllers;
using Spectre.Console;
using static OOP.LibraryManagementSystem.Enums;

namespace OOP.LibraryManagementSystem;

internal class UserInterface
{
    private readonly BooksController _booksController = new ();
    private readonly MagazineController _magazineController = new ();
    private readonly NewsPaperController _newspaperController = new ();
    internal void MainMenu()
    {
        bool endSession = false;
        ItemType itemTypeChoice;
        while (!endSession)
        {
            Console.Clear();
            var actionChoice = AnsiConsole.Prompt(
                    new SelectionPrompt<MenuOption>()
                    .Title("What do you want to do next?")
                    .AddChoices(Enum.GetValues<MenuOption>()));

            if (actionChoice.Equals(MenuOption.Exit))
            {
                endSession = true;
                break;
            }

            itemTypeChoice = AnsiConsole.Prompt(
                new SelectionPrompt<ItemType>()
                .Title("Select the type of item: ")
                .AddChoices(Enum.GetValues<ItemType>()));
            
            switch (actionChoice)
            {
                case MenuOption.ViewItems:
                    ViewItems(itemTypeChoice);
                    break;
                case MenuOption.AddItem:
                    AddItem(itemTypeChoice);
                    break;
                case MenuOption.DeleteItem:
                    DeleteItem(itemTypeChoice);
                    break;
            }
        }

        AnsiConsole.Clear();
        AnsiConsole.WriteLine("");
    }

    private void DeleteItem(ItemType itemType)
    {
        switch (itemType) {
            case ItemType.Book:
                _booksController.DeleteItem();
                break;
            case ItemType.Magazine:
                _magazineController.DeleteItem();
                break;
            case ItemType.Newspaper:
                _newspaperController.DeleteItem();
                break;
        }
    }

    private void AddItem(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Book:
                _booksController.AddItem();
                break;
            case ItemType.Magazine:
                _magazineController.AddItem();
                break;
            case ItemType.Newspaper:
                _newspaperController.AddItem();
                break;
        }
    }

    private void ViewItems(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Book:
                _booksController.ViewItems();
                break;
            case ItemType.Magazine:
                _magazineController.ViewItems();
                break;
            case ItemType.Newspaper:
                _newspaperController.ViewItems();
                break;
        }
    }
}
