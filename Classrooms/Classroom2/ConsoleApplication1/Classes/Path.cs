using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Classroom2.Common;

namespace Classes
{    
    class Path : IEnumerator
    {
        private List<Position> movements;
        private Terrain map;
        private int pathStep;

        public Path(Position p, Terrain t)
        {
            movements = new List<Position>();
            movements.Add(p);
            map = t;
            pathStep = 0;
        }


        public void Move(Direction d)
        {
            Position p = new Position(movements.Last().x, movements.Last().y);
            switch (d)
            {
                case Direction.Left:
                    p.x -= 1;
                    break;
                case Direction.Right:
                    p.x += 1;
                    break;
                case Direction.Up:
                    p.y += 1;
                    break;
                case Direction.Down:
                    p.y -= 1;
                    break;
            }

            movements.Add(p);
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            pathStep++;
            return (pathStep < movements.Count);
        }

        public void Reset()
        { pathStep = 0; }

        public object Current
        {
            get { return movements.ElementAt(pathStep); }
        }


        public int GetCost()
        {
            int cost = 0;
            foreach (Position p in movements)
            {
                cost += map.getCell(p.x, p.y).MovementCost;
            }

            // Reduce first cell cost to the half
            cost -= (map.getCell(movements.First().x, movements.First().y).MovementCost / 2);

            // Reduce last cell cost to the half
            cost -= (map.getCell(movements.Last().x, movements.Last().y).MovementCost / 2);

            return cost;
        }
    }
}
