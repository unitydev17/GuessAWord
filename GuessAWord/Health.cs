namespace MyApp
{
    public class Health
    {
        private readonly int _initValue;
        public int Value { get; set; }

        public float NormalizedValue => (float) Value / _initValue;

        public Health(int initValue)
        {
            _initValue = initValue;
            Value = _initValue;
        }

        public void Restore()
        {
            Value = _initValue;
        }
    }
}