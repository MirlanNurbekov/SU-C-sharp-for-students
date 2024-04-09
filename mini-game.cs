using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        const int size = 10;
        char[,] map = new char[size, size];
        int treasureX = random.Next(0, size);
        int treasureY = random.Next(0, size);
        int playerX = random.Next(0, size);
        int playerY = random.Next(0, size);

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                map[i, j] = '~';
            }
        }

        map[treasureX, treasureY] = 'X';
        map[playerX, playerY] = '0';

        void PrintMap()
        {
            Console.Clear();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (map[i, j] == '0')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (map[i, j] == 'X')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        Console.ResetColor();
                    }
                    Console.Write(map[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }

        Console.WriteLine("Ahoy! Here be the map. Find the treasure 'X'. Ye are '0'.");
        PrintMap();
        Console.WriteLine("Move with 'l' (left), 'r' (right), 'u' (up), 'd' (down).");

        while (true)
        {
            if (playerX == treasureX && playerY == treasureY)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Shiver me timbers! Ye found the treasure!");
                Console.ResetColor();
                break;
            }

            switch (Console.ReadLine())
            {
                case "l":
                    if (playerY > 0)
                    {
                        map[playerX, playerY] = '~';
                        playerY--;
                    }
                    break;
                case "r":
                    if (playerY < size - 1)
                    {
                        map[playerX, playerY] = '~';
                        playerY++;
                    }
                    break;
                case "u":
                    if (playerX > 0)
                    {
                        map[playerX, playerY] = '~';
                        playerX--;
                    }
                    break;
                case "d":
                    if (playerX < size - 1)
                    {
                        map[playerX, playerY] = '~';
                        playerX++;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid direction. Use 'l', 'r', 'u', 'd'.");
                    continue;
            }
            map[playerX, playerY] = '0';
            PrintMap();
        }
    }
}


/*
Key Components of the Program
Variables and Initialization
Random random = new Random(); creates a Random object to generate random numbers.
const int size = 10; defines the size of the map as a 10x10 grid.
char[,] map = new char[size, size]; initializes a 2D array of characters to represent the map.
int treasureX = random.Next(0, size); and int treasureY = random.Next(0, size); randomly place the treasure on the map.
int playerX = random.Next(0, size); and int playerY = random.Next(0, size); randomly place the player on the map initially.
*/