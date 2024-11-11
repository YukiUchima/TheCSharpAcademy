
namespace MathGame.YukiUchima.Models;

internal class Difficulty
{
    public GameLevel Level { get; set; }
}

internal enum GameLevel
{
    Easy,
    Medium,
    Hard
}
