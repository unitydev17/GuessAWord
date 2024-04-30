using System;
using System.Linq;

namespace MyApp
{
    public static class Input
    {
        public static void GetUserSelection(int[] values, out int selection)
        {
            do
            {
                var readLine = Console.ReadLine();
                if (!int.TryParse(readLine, out selection)) continue;

                if (values.Contains(selection)) return;
            } while (true);
        }

        public static void GetLetter(out char letter)
        {
            do
            {
                var readLine = Console.ReadLine();
                if (!char.TryParse(readLine, out letter)) continue;

                if (char.IsLetter(letter)) return;
            } while (true);
        }
    }
}