using System;
using ChessBoardModel;
using ChessCellModel;

namespace ChessBoardConsoleApp
{
    class Program
    {
        public static Board myBoard = new Board(8);
        static void Main(string[] args)
        {
            //show empty chessboard
            Console.WriteLine("INITIAL BOARD: \n");
            printBoard(myBoard);

            while (true)
            {
                //ask user for x and y coordinates where will place a piece
                Cell currentCell = setCurrentCell();
                currentCell.CurrentlyOccupied = true;

                //ask piece type
                string pieceType = setPieceType();

                //calculate all legal moves for piece
                myBoard.MarkNextMove(currentCell, pieceType);

                //print chess board. X - occupied sqr, + - legal move, . empty sqr
                Console.WriteLine("{0}'s Legal Moves Shown in o's.\n", pieceType);
                printBoard(myBoard);

                //wait for return key before ending
                //Console.ReadLine();
            }
        }

        private static string setPieceType()
        {
            //set Knight by default
            string piece;

            Console.Write("Enter Piece type: Rook, Knight, Bishop, Queen, King or Pawn: ");
            piece = Console.ReadLine();
            Console.WriteLine("You Entered: " + piece);

            return piece;
        }

        private static Cell setCurrentCell()
        {
            //Get x, y coordinates fromm user return a cell location
            int currentRow = 0;
            int currentColumn = 0;

            //..row
            try
            {
                Console.Write("ENTER Y POSITON: ");
                currentRow = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("\nWrong format. Only enter numbers between 0 - 7.\nDefault set to 0.\n");
            }

            //..column
            try
            {
                Console.Write("ENTER X POSITION: ");
                currentColumn = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("\nWrong format. Enter numbers between 0 - 7.\nDefault set to 0.\n");
            }

            return myBoard.theGrid[currentRow, currentColumn];
        }

        private static void printBoard(Board myBoard)
        {
            //print chess board.  X - occupied sqr, + - legal move, . empty sqr
            for(int i = 0; i < myBoard.Size; i++)
            {
                Console.WriteLine("+ - - + - - + - - + - - + - - + - - + - - + - - +");
                for (int j = 0; j < myBoard.Size; j++)
                {
                    Cell c = myBoard.theGrid[i, j];
                    if (c.CurrentlyOccupied == true)
                    {
                        Console.Write("|  X  ");
                    }
                    else if (c.LegalNextMove == true)
                    {
                        Console.Write("|  o  ");
                    }
                    else
                    {
                        Console.Write("|     ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("+ - - + - - + - - + - - + - - + - - + - - + - - +\n");
            Console.WriteLine("=============================================================IFN\n");
            
        }
    }
}