using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
