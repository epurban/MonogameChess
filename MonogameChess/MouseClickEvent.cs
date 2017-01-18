using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Nez.Systems;
using Nez;
using Nez.Sprites;

namespace MonogameChess
{
	public class MouseClickEvent : Component, IUpdatable
	{
		public MouseClickEvent()
		{
			
		}

		public void update()
		{
			if (Input.leftMouseButtonPressed)
			{
				var x = entity.position.X;
				var y = entity.position.Y;

				var lmbPos = Input.scaledMousePosition;

				var sprite = entity.getComponent<Sprite>();

				RectangleF area = new RectangleF(x, y, sprite.width, sprite.height);

				// is the left mouse button position on top of this sprite?
				if (area.contains(lmbPos))
				{
                    var chessPiece = entity.getComponent<chessPiece>();
                    
                    if (chessPiece.isSelected() == true)
                    {
                        chessPiece.setSelected(false);
                    }
                    else
                    {
                        chessPiece.setSelected(true);
                    }

				}

			}
		}
	    
	   
	}
}
