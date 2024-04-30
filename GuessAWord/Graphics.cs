using System;

namespace MyApp
{
    public class Graphics
    {
        private const int Distance = 100;

        private readonly string[] _bear =
        {
            "      _     _      ",
            "     ( \\---/ )    ",
            "      ) . . (      ",
            ",--._(___Y___)_,--.",
            "`--'           `--'"
        };


        private readonly string[] _bearFed =
        {
            " ,~~.,''\"'`'.~~.",
            ": {` .- _ -. '} ;",
            " `:   O(_)O   ;'",
            "  ';  ._|_,  ;`",
            "   '`-.\\_/,.'`     hjw",
        };

        private readonly string[] _cheese =
        {
            " // \"\"--.._      ",
            " ||  (_)  _ \"-._  ",
            "||    _ (_)    '-.",
            "||   (_)   __..-' ",
            " \\\\__..--\"\"   hjw"
        };


        public void Show(Health health)
        {
            var progress = (int) (Distance * (1f - health.NormalizedValue));

            if (health.Value == 0)
            {
                for (var i = 0; i < _bearFed.Length; i++)
                {
                    var line = _bearFed[i];
                    line = line.PadLeft(line.Length + Distance, i == 3 ? '_' : ' ');
                    Console.WriteLine(line);
                }
            }
            else
            {
                for (var i = 0; i < _bear.Length; i++)
                {
                    var line = _bear[i];

                    line = line.PadLeft(line.Length + progress, i == 3 ? '_' : ' ');
                    line = line.PadRight(line.Length + Distance - progress - _cheese[0].Length, i == 3 ? '_' : ' ');

                    line += _cheese[i];
                    Console.WriteLine(line);
                }
            }
        }
    }
}