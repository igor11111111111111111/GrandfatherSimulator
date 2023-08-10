namespace GrandfatherSimulator
{
    public class PlayerData
    { 
        public Fatigue Fatigue;
        public Leisure Leisure;
        public Health Health;
        public Satiety Satiety;
        public int Money;
        public int Age;

        public PlayerData()
        {
            Fatigue = new Fatigue(100);
            Leisure = new Leisure(100);
            Health = new Health(100);
            Satiety = new Satiety(100);
            Money = 1520;
            Age = 70;
        }
    }
}
