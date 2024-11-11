
namespace MathGame.YukiUchima.Models;

internal class Game
{
    public int Score { get; set; }
    public int PossibleScore { get; set; }
    public string? Time { get; set; }
    public GameType Type { get; set; }

    public string? ElapsedTime { get; set; }
}

internal enum GameType
{
    Addition,
    Subtract,
    Multiply,
    Divide
}

