using Simulator.Maps;
using Simulator;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimConsole
{
    public class MapVisualizer
    {
        internal int SizeX { get; set; }
        internal int SizeY { get; set; }
        internal List<Creature> Creatures { get; set; }
        internal List<Point> Points { get; set; }
        internal SmallMap CurrentMap { get; }

        internal MapVisualizer(SmallMap map, List<Creature> creatures, List<Point> points)
        {
            SizeX = map.SizeX;
            SizeY = map.SizeY;
            CurrentMap = map;
            Creatures = creatures;
            Points = points;
            Console.OutputEncoding = Encoding.UTF8;
        }

        private Creature GetCreatureAtPosition(int x, int y)
        {
            for (int i = 0; i < Creatures.Count; i++)
            {
                if (Points[i].X == x+1 && Points[i].Y == y)
                {
                    return Creatures[i];
                }
            }
            return null;
        }

        public void Draw()
        {
            for (int y = 0; y < SizeY; y++)
            {
                if (y == 0)
                {
                    DrawTopBorder();
                }

                DrawMiddleRow(y);

                if (y == SizeY - 1)
                {
                    DrawBottomBorder();
                }
                else
                {
                    DrawHorizontalFix();
                }
            }
        }

        private void DrawTopBorder()
        {
            Console.Write(Box.TopLeft);
            for (int x = 0; x < SizeX; x++)
            {
                Console.Write(new string(Box.Horizontal, 3));
                if (x < SizeX - 1)
                {
                    Console.Write(Box.TopMid);
                }
            }
            Console.WriteLine(Box.TopRight);
        }

        private void DrawBottomBorder()
        {
            Console.Write(Box.BottomLeft);
            for (int x = 0; x < SizeX; x++)
            {
                Console.Write(new string(Box.Horizontal, 3));
                if (x < SizeX - 1)
                {
                    Console.Write(Box.BottomMid);
                }
            }
            Console.WriteLine(Box.BottomRight);
        }

        private void DrawMiddleRow(int row)
        {
            Console.Write(Box.Vertical);
            for (int col = 0; col < SizeX; col++)
            {
                var creature = GetCreatureAtPosition(col, row);
                if (creature != null)
                {
                    Console.Write($" {creature.Symbol} ");
                }
                else
                {
                    Console.Write("   ");
                }
                Console.Write(Box.Vertical);
            }
            Console.WriteLine();
        }

        private void DrawHorizontalFix()
        {
            Console.Write(Box.MidLeft);
            for (int x = 0; x < SizeX; x++)
            {
                Console.Write(new string(Box.Horizontal, 3));
                if (x < SizeX - 1)
                {
                    Console.Write(Box.Cross);
                }
            }
            Console.WriteLine(Box.MidRight);
        }

    }
}