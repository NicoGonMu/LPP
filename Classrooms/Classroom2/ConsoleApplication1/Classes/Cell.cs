using Classroom2;

namespace Classes
{
    class Cell : lDangerous
    {
        public int MovementCost { get; set; }
        private float probabilityCost;

        public float GetProbabilityDamage
        {
            get { return probabilityCost; }
            set { probabilityCost = value; }
        }
    }
}
