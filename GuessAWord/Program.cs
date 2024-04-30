namespace MyApp
{
    internal static class Program
    {
        private static void Main()
        {
            var player = new Player(10);
            var board = new Board("Resources/top-1000-nouns.txt");
            var game = new Game(player, board);
            game.Start();
        }
    }
}