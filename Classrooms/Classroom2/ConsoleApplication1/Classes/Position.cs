
namespace Classes
{
    class Position
    {
        public int x { get; set; }
        public int y { get; set; }

        public Position(int w, int h)
        {
            x = w;
            y = h;
        }

        public override string ToString()
        {
            return $"({x}, {y})";
        }
    }
}
