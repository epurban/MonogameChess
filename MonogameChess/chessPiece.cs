using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;

namespace MonogameChess
{


    enum pieceTypes
    {
        Pawn = 0,
        King,
        Queen,
        Bishop,
        Rook,
        Knight
    }
    

    class chessPiece : Component
    {
        private bool Selected = false; // determines whether or not this chess piece is selected by the player
        private pieceTypes pieceType;

        public chessPiece(pieceTypes type)
        {
            pieceType = type;
        }

        public bool isSelected() // is selected or not?
        {
            if (Selected)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void setSelected(bool selected) // method which sets the piece selected or not
        {
            Selected = selected;
        }

    }
}
