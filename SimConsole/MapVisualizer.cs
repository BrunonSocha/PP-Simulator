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
        internal List<IMappable> Creatures { get; set; }
        internal List<Point> Points { get; set; }
        internal SmallMap CurrentMap { get; }

        internal Simulation Simulation { get; set; }

        internal MapVisualizer(Simulation simulation)
        {
            Simulation = simulation;
            SizeX = simulation.CurrentMap.SizeX;
            SizeY = simulation.CurrentMap.SizeY;
            CurrentMap = simulation.CurrentMap;
            Creatures = simulation.Creatures;
            Points = simulation.Positions;
            Console.OutputEncoding = Encoding.UTF8;
        }

        // jesus christ

        private IMappable GetCreatureAtPosition(int x, int y)
        {
            foreach (var creature in Creatures)
            {
                var position = creature.Position;
                if (position.X == x+1 && position.Y == y+1)
                {
                    return creature;
                }
            }
            return null;
        }

        private char GetSymbolAtPosition(int x, int y)
        {
            List<IMappable> creaturesAtPosition = new();

            foreach (var creature in Creatures)
            {
                var position = creature.Position;
                if (position.X == x + 1 && position.Y == y + 1)
                {
                    creaturesAtPosition.Add(creature);
                }
            }

            if (creaturesAtPosition.Count > 1)
            {
                return 'X';
            }
            else if (creaturesAtPosition.Count == 1)
            {
                return creaturesAtPosition[0].Symbol;
            }

            return ' ';
        }


        public void Draw()
        {
            for (int y = SizeY - 1; y >= 0; y--)
            {
                if (y == SizeY - 1)
                {
                    DrawTopBorder();
                }

                DrawMiddleRow(y);

                if (y == 0)
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
                char symbol = GetSymbolAtPosition(col, row);
                Console.Write($" {symbol} ");
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

        public void VisualizeSimulation()
        {
            for (int x = 0; x <= Simulation.ParsedMoves.Count; x++)
            {
                this.Draw();
                Simulation.Turn();
            }
        }

    }
}