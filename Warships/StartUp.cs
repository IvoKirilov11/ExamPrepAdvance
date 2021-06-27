using System;
using System.Linq;

namespace Warships
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            string[] attackCommands = Console.ReadLine()
                                   .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                   //.Select(int.Parse)
                                   .ToArray();
            char[,] field = ReadMatrix(fieldSize, fieldSize);

            int shipsOfTheFisrt = field.Cast<char>().Count(x => x == '<');
            int shipsOfTheSecond = field.Cast<char>().Count(x => x == '>');

            int totalCountShipsDestroyed = 0;

            //•   * – a regular position on the field
            //•   < – ship of the first player.
            //•   > – ship of the second player
            //•   # – a sea mine that explodes when attacked

            bool isWon = false;

            for (int i = 0; i < attackCommands.Length; i++)
            {
                string[] attacks = attackCommands[i]
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            //.Select(int.Parse)
                            .ToArray();

                int row = int.Parse(attacks[0]);
                int col = int.Parse(attacks[1]);

                if (Inside(field, row, col))
                {
                    if (field[row, col] == '<')
                    {
                        shipsOfTheFisrt--;
                        totalCountShipsDestroyed++;
                        field[row, col] = 'X';
                        if (shipsOfTheFisrt == 0)
                        {
                            break;
                        }
                    }

                    else if (field[row, col] == '>')
                    {
                        shipsOfTheSecond--;
                        totalCountShipsDestroyed++;
                        field[row, col] = 'X';
                        if (shipsOfTheSecond == 0)
                        {
                            break;
                        }
                    }

                    else if (field[row, col] == '#')
                    {
                        //field[row, col] = 'X';

                        for (int r = row - 1; r <= row + 1; r++)
                        {
                            for (int c = col - 1; c <= col + 1; c++)
                            {
                                if (Inside(field, r, c))
                                {
                                    if (field[r, c] == '<')
                                    {
                                        shipsOfTheFisrt--;
                                        totalCountShipsDestroyed++;
                                        //field[row, col] = 'X';

                                        if (shipsOfTheFisrt <= 0)
                                        {
                                            isWon = true;
                                            //break;
                                        }
                                    }
                                    else if (field[r, c] == '>')
                                    {
                                        shipsOfTheSecond--;
                                        totalCountShipsDestroyed++;

                                        if (shipsOfTheSecond <= 0)
                                        {
                                            isWon = true;
                                            //break;
                                        }
                                    }

                                    field[row, col] = 'X';

                                }
                            }

                            if (isWon)
                            {
                                break;
                            }
                        }
                    }

                    else if (field[row, col] == '*')
                    {
                        continue;
                    }

                    else if (field[row, col] == 'X')
                    {
                        continue;
                    }

                }

                if (isWon)
                {
                    break;
                }

            }

            if (shipsOfTheFisrt <= 0)
            {
                Console.WriteLine($"Player Two has won the game! {totalCountShipsDestroyed} ships have been sunk in the battle.");
            }
            else if (shipsOfTheSecond <= 0)
            {
                Console.WriteLine($"Player One has won the game! {totalCountShipsDestroyed} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {shipsOfTheFisrt} ships left. Player Two has {shipsOfTheSecond} ships left.");
            }
        }

        private static bool Inside(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                   col >= 0 && col < matrix.GetLength(1);
        }

        static char[,] ReadMatrix(int rows, int cols)
        {
            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowValues = Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(char.Parse)
                                .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }

            return matrix;
        }
    }
}
