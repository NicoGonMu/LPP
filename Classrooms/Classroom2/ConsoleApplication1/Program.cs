using System;
using Classes;
using Classroom2.Common;

namespace Classroom2
{
    class Program
    {
        static void Main(string[] args)
        {
            Terrain t = new Terrain(8, 8);
            Path p = new Path(new Position(0, 0), t);

            // 4 up
            p.Move(Direction.Up);
            p.Move(Direction.Up);
            p.Move(Direction.Up);
            p.Move(Direction.Up);
            // 4 Right
            p.Move(Direction.Right);
            p.Move(Direction.Right);
            p.Move(Direction.Right);
            p.Move(Direction.Right);
            // 2 Down
            p.Move(Direction.Down);
            p.Move(Direction.Down);
            // 2 Left
            p.Move(Direction.Left);
            p.Move(Direction.Left);
            // 2 Down
            p.Move(Direction.Down);
            p.Move(Direction.Down);

            //Final position has to be (2, 0)
            foreach (Position pos in p)
            {
                Console.WriteLine(pos.ToString());
            }

            Console.WriteLine("Type anything to exit");
            Console.Read();
        }
    }  
}
