using System.Linq;

namespace Classes
{
    class Terrain
    {
        private Cell[][] terr;

        public Terrain(int w, int h)
        {
            terr = new Cell[w][];
            for (int i = 0; i < w; i++)
            {
                terr[i] = new Cell[h];
            }
        }

        public Cell getCell(int w, int h)
        {
            return terr[w][h];
        }

        public void setCell(Cell c, int w, int h)
        {
            terr[w][h] = c;
        }

        public int getSize()
        {
            return terr.Count();
        }
    }
}
