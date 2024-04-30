namespace MyApp
{
    public class Player
    {
        public Health HealthPlayer { get; }

        public Player(int health)
        {
            HealthPlayer = new Health(health);
        }

        public void TakeDamage()
        {
            HealthPlayer.Value--;
        }

        public bool Fails()
        {
            return HealthPlayer.Value == 0;
        }

        public void Restore()
        {
            HealthPlayer.Restore();
        }
    }
}