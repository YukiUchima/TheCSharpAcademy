using MathGame.YukiUchima.Models;
using Spectre.Console;
using static MathGame.YukiUchima.Enums;
using static MathGame.YukiUchima.RunGameMode;

namespace MathGame.YukiUchima;

internal class UserInteraction
{
    private static List<Game> _gameHistory = new List<Game>();
    
    public static void StartGame()
    {
        Console.WriteLine("This is the math game!");
        bool isGameOver = false;
        do
        {
            isGameOver = RoundOver(PickGameMode());
        }
        while (!isGameOver);
    }

    private static GameType PickGameMode()
    {
        GameType gameMode = AnsiConsole.Prompt(
            new SelectionPrompt<GameType>()
            .Title("Pick Game Mode: ")
            .AddChoices(Enum.GetValues<GameType>())
            );
        return gameMode;
    }

    private static DifficultyLevel PickDifficulty()
    {
        DifficultyLevel difficulty = AnsiConsole.Prompt(
            new SelectionPrompt<DifficultyLevel>()
            .Title("Choose Your Difficulty Level: ")
            .AddChoices(Enum.GetValues<DifficultyLevel>())
            );      
        
        Difficulty.Level = difficulty;
        return Difficulty.Level;
    }

    private static bool RoundOver(GameType type)
    {
        DifficultyLevel level;

        if (type.Equals(GameType.Exit))
        {
            AnsiConsole.Markup("[yellow]Game Over... Thank you for playing![/]");
            return true;
        }
        else if (type.Equals(GameType.GameHistory))
        {
            Helpers.PreviewHistory();
            return false;
        }
        else if (type.Equals(GameType.PickRandomly))
        {
            type = GetRandomGameType();
        }
        level = PickDifficulty();
        RunGameMode.RunMode(type, level);
        return false;
    }

    private static GameType GetRandomGameType()
    {
        var rand = new Random();
        int randomIndex = rand.Next(0, 4);
        return (GameType)randomIndex;
    }
}
