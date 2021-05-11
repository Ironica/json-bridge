using System;
using System.Linq;

namespace JsonBridge.models
{
    public class ResponseModel
    {
        public string status { get; set; }
        public PlaygroundModel[] payload { get; set; }
    }

    public class PlaygroundModel
    {
        public string consoleLog;
        public string special;
        
        public string[][] grid { get; set; }
        public string[][] layout { get; set; }
        public string[][] misc { get; set; }
        public Portal[] portals { get; set; }
        public Player[] players { get; set; }

        private void PrintObject(int x, int y)
        {
            if (players.Any(e => e.x == x && e.y == y))
                Console.Write($"{players.First(e => e.x == x && e.y == y).dir}  ");
            else
                Console.Write($"{grid[y][x]}  ");
        }

        public void PrintFrame()
        {
            for (int y = 0; y < grid.Length; y++)
            {
                for (int x = 0; x < grid[0].Length; x++)
                {
                    PrintObject(x, y);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}