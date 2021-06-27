using System;

namespace Re_Volt
{
    class Program
    {

        public class Position
        {
            public Position(int row,int col)
            {
                Row = row;
                Col = col;
            }
            
            public int Row { get; set; }
            public int Col { get; set; }

            public bool isSafe(int rowCount,int colCount)
            {
                if(Row < 0 && Col< 0)
                {
                    return false;
                }
                if(Row >= rowCount || Col >= colCount)
                {
                    return false;
                }
                return true;
            }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int commands = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            Read(matrix);
            var plearPosition = GetPlayerPosition(matrix);
            if(commands > 0)
            {
                matrix[plearPosition.Row, plearPosition.Col] = '-';
            }
            

            for (int i = 0; i < commands; i++)
            {
                string command = Console.ReadLine();

                MovePlayer(plearPosition, command, n);
                while (matrix[plearPosition.Row, plearPosition.Col] == 'B')
                {
                    MovePlayer(plearPosition, command, n);
                }
                while (matrix[plearPosition.Row, plearPosition.Col] == 'T')
                {
                    Position direction = GetDirection(command);
                    plearPosition.Row += direction.Row * -1;
                    plearPosition.Col += direction.Col * -1;
                }
                if (matrix[plearPosition.Row, plearPosition.Col] == 'F')
                {
                    Console.WriteLine("Player won!");
                    matrix[plearPosition.Row, plearPosition.Col] = 'f';
                    Print(matrix);
                    return;
                }
            }
            Console.WriteLine("Player lost!");
            matrix[plearPosition.Row, plearPosition.Col] = 'f';
            Print(matrix);
        }

        static Position GetDirection(string command)
        {
            int row = 0;
            int col = 0;
            if(command == "left")
            {
                col = -1;
            }
            if (command == "right")
            {
                col = 1;
            }
            if (command == "up")
            {
                row = -1;
            }
            if (command == "down")
            {
                row = 1;
            }
            return new Position(row, col);

        }
        static Position MovePlayer(Position plearPosition, string command,int n)
        {
            
            if (command == "right")
            {
                plearPosition.Col++;
                if (!plearPosition.isSafe(n, n))
                {
                    plearPosition.Col = 0;
                }
            }
            if (command == "left")
            {
                plearPosition.Col--;
                if (!plearPosition.isSafe(n, n))
                {
                    plearPosition.Col = n - 1;
                }
            }
            if (command == "up")
            {
                plearPosition.Row--;
                if (!plearPosition.isSafe(n, n))
                {
                    plearPosition.Row = n - 1;
                }
            }
            if (command == "down")
            {
                plearPosition.Row++;
                if (!plearPosition.isSafe(n, n))
                {
                    plearPosition.Row = 0;
                }
            }
            return plearPosition;
        }

        static Position GetPlayerPosition(char[,] matrix)
        {
            Position position = null;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'f')
                    {
                        position = new Position(row, col);
                    }
                }

            }
            return position;
        }
        static void Print(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }


        private static void Read(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                string line = Console.ReadLine();
                for (int col = 0; col < line.Length; col++)
                {
                    matrix[row, col] = line[col];
                }
                
            }
        }
    }
}
