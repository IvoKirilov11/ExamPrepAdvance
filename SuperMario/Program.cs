using System;

namespace SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());

            char[][] maze = new char[rows][];
            var currRow = 0;
            var currCol = 0;

            for (int row = 0; row < maze.GetLength(0); row++)
            {

                var mazeRow = Console.ReadLine();

                maze[row] = new char[mazeRow.Length];
                for (int col = 0; col < mazeRow.Length; col++)
                {
                    maze[row][col] = mazeRow[col];
                    if(maze[row][col] == 'M')
                    {
                        currRow = row;
                        currCol = col;
                    }
                }
            }
            bool missonAcomplished = false;

            while (true)
            {
                var moves = Console.ReadLine().Split();
                char direction = char.Parse(moves[0]);
                int spawRow = int.Parse(moves[1]);
                int spawCol = int.Parse(moves[2]);

                maze[spawRow][spawCol] = 'B';
                lives--;

                switch (direction)
                {
                    case 'W':

                        if(currRow - 1 < 0)
                        {
                            continue;
                        }
                        maze[currRow][currCol] = '-';
                        currRow--;
                        break;
                    case 'S':
                        if (currRow + 1 == rows)
                        {
                            continue;
                        }
                        maze[currRow][currCol] = '-';
                        currRow++;
                        break;
                    case 'A':
                        if (currCol - 1 < 0)
                        {
                            continue;
                        }
                        maze[currRow][currCol] = '-';
                        currCol--;
                        break;
                    case 'D':

                        if (currCol + 1 == maze[currRow].Length)
                        {
                            continue;
                        }
                        maze[currRow][currCol] = '-';
                        currCol++;
                        break;
                }
                if (lives <= 0)
                {
                    {
                        maze[currRow][currCol] = 'X';
                        break;
                    }
                }
                if(maze[currRow][currCol] == 'B')
                {
                    lives -= 2;
                    if(lives <= 0)
                    {
                        maze[currRow][currCol] = 'X';
                        break;
                    }
                }
                else if(maze[currRow][currCol] == 'P')
                {
                    missonAcomplished = true;
                    maze[currRow][currCol] = '-';
                    break;

                }
                maze[currRow][currCol] = 'M';

            }
            if(missonAcomplished)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
            }
            else
            {
                Console.WriteLine($"Mario died at {currRow};{currCol}.");
            }
            foreach (char[] row in maze)
            {
                Console.WriteLine(string.Join("",row));
            }
        }
    }
}
