namespace MyApp
{
    public class Game
    {
        private readonly Player _player;
        private readonly Board _board;


        public Game(Player player, Board board)
        {
            _player = player;
            _board = board;
        }

        public void Start()
        {
            GameLoop();
        }

        private void GameLoop()
        {
            while (CheckWantPlay())
            {
                PrepareWord();
                PlayMatch();
                RestoreGame();
            }
        }

        private static bool CheckWantPlay()
        {
            UI.ShowStartDialog();
            Input.GetUserSelection(new[] {1, 2}, out var selection);
            return selection == 1;
        }

        private void RestoreGame()
        {
            _player.Restore();
            _board.Restore();
        }

        private void PrepareWord()
        {
            _board.NextWord();
            UI.ShowStartWordInfo(_board.GetWord(), _player.HealthPlayer);
        }

        private void PlayMatch()
        {
            do
            {
                UI.ShowGuessDialog();
                Input.GetLetter(out var letter);

                if (_board.Check(letter, out var repeat))
                {
                    if (_board.Completed())
                    {
                        UI.ShowSuccess(_board.GetWord());
                        return;
                    }

                    if (repeat) UI.ShowRepeatLetter(letter, _board.GetWord(), _player.HealthPlayer);
                    else
                        UI.ShowWordInfo(_board.GetWord(), _player.HealthPlayer, true);
                }
                else
                {
                    _player.TakeDamage();
                    if (_player.Fails())
                    {
                        UI.ShowFail(_board.RevealWord, _player.HealthPlayer);
                        return;
                    }

                    UI.ShowWordInfo(_board.GetWord(), _player.HealthPlayer);
                }
            } while (true);
        }
    }
}