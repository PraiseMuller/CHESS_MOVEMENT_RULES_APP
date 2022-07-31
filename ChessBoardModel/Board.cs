using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessCellModel;

namespace ChessBoardModel
{
    public class Board
    {
        public int Size { get; set; }
        public Cell[,] theGrid { get; set; }

        //COnstructor set size
        public Board(int s)
        {
            //initial size of board
            Size = s;
            //create new 2d array of type cell
            theGrid = new Cell[Size, Size];

            //fill 2d array with new cells, each w unique x, y coordinates
            for(int i = 0; i < Size; i++)
            {
                for(int j = 0; j < Size; j++)
                {
                    theGrid[i, j] = new Cell(i, j);
                }
            }
        }

        public void MarkNextMove(Cell CurrentCell, string chessPiece)
        {
            //step 1 - Clear all the previous legal moves
            for(int i =0; i<Size; i++)
            {
                for(int j =0; j<Size; j++)
                {
                    theGrid[i, j].LegalNextMove = false;
                    theGrid[i, j].CurrentlyOccupied = false;
                }
            }

            //step 2 - Find all legal next moves and mark as legal
            switch (chessPiece)
            {
                case "Knight":
                    if(isSafe(CurrentCell.RowNumber+2, CurrentCell.ColumnNumber+1))
                        theGrid[CurrentCell.RowNumber + 2, CurrentCell.ColumnNumber + 1].LegalNextMove = true;
                    if(isSafe(CurrentCell.RowNumber+2, CurrentCell.ColumnNumber-1))
                        theGrid[CurrentCell.RowNumber + 2, CurrentCell.ColumnNumber - 1].LegalNextMove = true;

                    if (isSafe(CurrentCell.RowNumber-2, CurrentCell.ColumnNumber+1))
                        theGrid[CurrentCell.RowNumber - 2, CurrentCell.ColumnNumber + 1].LegalNextMove = true;
                    if (isSafe(CurrentCell.RowNumber-2, CurrentCell.ColumnNumber-1))
                        theGrid[CurrentCell.RowNumber - 2, CurrentCell.ColumnNumber - 1].LegalNextMove = true;

                    if (isSafe(CurrentCell.RowNumber+1, CurrentCell.ColumnNumber+2))
                        theGrid[CurrentCell.RowNumber + 1, CurrentCell.ColumnNumber + 2].LegalNextMove = true;
                    if (isSafe(CurrentCell.RowNumber-1, CurrentCell.ColumnNumber+2))
                        theGrid[CurrentCell.RowNumber - 1, CurrentCell.ColumnNumber + 2].LegalNextMove = true;

                    if (isSafe(CurrentCell.RowNumber+1, CurrentCell.ColumnNumber-2))
                        theGrid[CurrentCell.RowNumber + 1, CurrentCell.ColumnNumber - 2].LegalNextMove = true;
                    if (isSafe(CurrentCell.RowNumber-1, CurrentCell.ColumnNumber-2))
                        theGrid[CurrentCell.RowNumber - 1, CurrentCell.ColumnNumber - 2].LegalNextMove = true;

                    break;

                case "King":
                    //vertical movement
                    if (isSafe(CurrentCell.RowNumber, CurrentCell.ColumnNumber + 1))
                        theGrid[CurrentCell.RowNumber, CurrentCell.ColumnNumber + 1].LegalNextMove = true;
                    if (isSafe(CurrentCell.RowNumber, CurrentCell.ColumnNumber - 1))
                        theGrid[CurrentCell.RowNumber, CurrentCell.ColumnNumber - 1].LegalNextMove = true;

                    //horizontal movement
                    if (isSafe(CurrentCell.RowNumber + 1, CurrentCell.ColumnNumber))
                        theGrid[CurrentCell.RowNumber + 1, CurrentCell.ColumnNumber].LegalNextMove = true;
                    if (isSafe(CurrentCell.RowNumber - 1, CurrentCell.ColumnNumber))
                        theGrid[CurrentCell.RowNumber - 1, CurrentCell.ColumnNumber].LegalNextMove = true;

                    //diagonal UP movement
                    if (isSafe(CurrentCell.RowNumber + 1, CurrentCell.ColumnNumber + 1))
                        theGrid[CurrentCell.RowNumber + 1, CurrentCell.ColumnNumber + 1].LegalNextMove = true;
                    if (isSafe(CurrentCell.RowNumber + 1, CurrentCell.ColumnNumber - 1))
                        theGrid[CurrentCell.RowNumber + 1, CurrentCell.ColumnNumber - 1].LegalNextMove = true;

                    //diagonal DOWN movement
                    if (isSafe(CurrentCell.RowNumber - 1, CurrentCell.ColumnNumber + 1))
                        theGrid[CurrentCell.RowNumber - 1, CurrentCell.ColumnNumber + 1].LegalNextMove = true;
                    if (isSafe(CurrentCell.RowNumber - 1, CurrentCell.ColumnNumber - 1))
                        theGrid[CurrentCell.RowNumber - 1, CurrentCell.ColumnNumber - 1].LegalNextMove = true;
                    break;
                case "Rook":
                    for(int i = 1; i <= Size - 1; i++)
                    {
                        //horizontal
                        if (isSafe(CurrentCell.RowNumber, CurrentCell.ColumnNumber + i))
                            theGrid[CurrentCell.RowNumber, CurrentCell.ColumnNumber + i].LegalNextMove = true;
                        if (isSafe(CurrentCell.RowNumber, CurrentCell.ColumnNumber - i))
                            theGrid[CurrentCell.RowNumber, CurrentCell.ColumnNumber - i].LegalNextMove = true;

                        //vertical
                        if (isSafe(CurrentCell.RowNumber + i, CurrentCell.ColumnNumber))
                            theGrid[CurrentCell.RowNumber + i, CurrentCell.ColumnNumber].LegalNextMove = true;
                        if (isSafe(CurrentCell.RowNumber - i, CurrentCell.ColumnNumber))
                            theGrid[CurrentCell.RowNumber - i, CurrentCell.ColumnNumber].LegalNextMove = true;
                    }
                    break;
                case "Bishop":
                    for (int i = 1; i <= Size - 1; i++)
                    {
                        //-ve Gradient
                        if (isSafe(CurrentCell.RowNumber + i, CurrentCell.ColumnNumber + i))
                            theGrid[CurrentCell.RowNumber + i, CurrentCell.ColumnNumber + i].LegalNextMove = true;
                        if (isSafe(CurrentCell.RowNumber - i, CurrentCell.ColumnNumber - i))
                            theGrid[CurrentCell.RowNumber - i, CurrentCell.ColumnNumber - i].LegalNextMove = true;

                        //+ve Gradient
                        if (isSafe(CurrentCell.RowNumber + i, CurrentCell.ColumnNumber - i))
                            theGrid[CurrentCell.RowNumber + i, CurrentCell.ColumnNumber - i].LegalNextMove = true;
                        if (isSafe(CurrentCell.RowNumber - i, CurrentCell.ColumnNumber + i))
                            theGrid[CurrentCell.RowNumber - i, CurrentCell.ColumnNumber + i].LegalNextMove = true;
                    }
                    break;
                case "Queen":
                    //COMNINATION ROOK & BISHOP
                    for (int i = 1; i <= Size - 1; i++)
                    {
                        //-ve Gradient
                        if (isSafe(CurrentCell.RowNumber + i, CurrentCell.ColumnNumber + i))
                            theGrid[CurrentCell.RowNumber + i, CurrentCell.ColumnNumber + i].LegalNextMove = true;
                        if (isSafe(CurrentCell.RowNumber - i, CurrentCell.ColumnNumber - i))
                            theGrid[CurrentCell.RowNumber - i, CurrentCell.ColumnNumber - i].LegalNextMove = true;

                        //+ve Gradient
                        if (isSafe(CurrentCell.RowNumber + i, CurrentCell.ColumnNumber - i))
                            theGrid[CurrentCell.RowNumber + i, CurrentCell.ColumnNumber - i].LegalNextMove = true;
                        if (isSafe(CurrentCell.RowNumber - i, CurrentCell.ColumnNumber + i))
                            theGrid[CurrentCell.RowNumber - i, CurrentCell.ColumnNumber + i].LegalNextMove = true;

                        //horizontal
                        if (isSafe(CurrentCell.RowNumber, CurrentCell.ColumnNumber + i))
                            theGrid[CurrentCell.RowNumber, CurrentCell.ColumnNumber + i].LegalNextMove = true;
                        if (isSafe(CurrentCell.RowNumber, CurrentCell.ColumnNumber - i))
                            theGrid[CurrentCell.RowNumber, CurrentCell.ColumnNumber - i].LegalNextMove = true;

                        //vertical
                        if (isSafe(CurrentCell.RowNumber + i, CurrentCell.ColumnNumber))
                            theGrid[CurrentCell.RowNumber + i, CurrentCell.ColumnNumber].LegalNextMove = true;
                        if (isSafe(CurrentCell.RowNumber - i, CurrentCell.ColumnNumber))
                            theGrid[CurrentCell.RowNumber - i, CurrentCell.ColumnNumber].LegalNextMove = true;
                    }
                    break;
                case "Pawn":
                    //vertical
                    if (isSafe(CurrentCell.RowNumber - 2, CurrentCell.ColumnNumber))
                        theGrid[CurrentCell.RowNumber - 2, CurrentCell.ColumnNumber].LegalNextMove = true;
                    if (isSafe(CurrentCell.RowNumber - 1, CurrentCell.ColumnNumber))
                        theGrid[CurrentCell.RowNumber - 1, CurrentCell.ColumnNumber].LegalNextMove = true;
                    break;
                default:
                    Console.WriteLine("\nINVALID PIECE. Setting Default, Knight.\n");
                    break;

            }
            theGrid[CurrentCell.RowNumber, CurrentCell.ColumnNumber].CurrentlyOccupied = true;
        }

        private bool isSafe(int rowNumber, int columnNumber)
        {
            return rowNumber < Size && rowNumber >= 0 && columnNumber < Size && columnNumber >= 0;
        }
    }
}
