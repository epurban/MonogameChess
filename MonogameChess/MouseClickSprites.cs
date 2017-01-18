using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Nez.Systems;
using Nez;
using Nez.Sprites;

namespace MonogameChess
{
	public class MouseClickSprites : Component, IUpdatable
	{
		public MouseClickSprites()
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
					bool temp;
					temp = true;
				}

			}
		}
	    
	   
	}
}
