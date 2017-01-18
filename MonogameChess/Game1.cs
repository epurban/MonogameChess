using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using System.Collections.Generic;
using Nez.Sprites;

namespace MonogameChess
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Core
    {

        public Game1() : base(1920, 1080, false, false, "Trippy Chess", "Content")
        {
			Scene.setDefaultDesignResolution(1920, 1080, Scene.SceneResolutionPolicy.BestFit);
			Window.AllowUserResizing = true;
        }


        const int MAIN_RENDER_LAYER = 0;

        protected override void Initialize()
        {

            base.Initialize();

            // SCENES
            var gameScene = new Scene();
            var menuScene = new Scene();

            gameScene.addRenderer<RenderLayerRenderer>(new RenderLayerRenderer(0, MAIN_RENDER_LAYER));
			gameScene.clearColor = Color.Black;

            /******************************
            |   TEXTURES                  |
            ******************************/
            var _texBoard = content.Load<Texture2D>("board");

			var _texQueenBlack = content.Load<Texture2D>("Black/queen");
			var _texKingBlack = content.Load<Texture2D>("Black/king");
			var _texRookBlack = content.Load<Texture2D>("Black/rook");
			var _texBishopBlack = content.Load<Texture2D>("Black/bishop");
			var _texKnightBlack = content.Load<Texture2D>("Black/knight");
			var _texPawnBlack = content.Load<Texture2D>("Black/pawn");

			var _texQueenRed = content.Load<Texture2D>("Red/queen");
			var _texKingRed = content.Load<Texture2D>("Red/king");
			var _texRookRed = content.Load<Texture2D>("Red/rook");
			var _texBishopRed = content.Load<Texture2D>("Red/bishop");
			var _texKnightRed = content.Load<Texture2D>("Red/knight");
			var _texPawnRed = content.Load<Texture2D>("Red/pawn");

			//var _texQueenRed = content.Load<Texture2D>("Red/queen");


            /******************************
            |   ENTITIES                  |
            ******************************/
            var entityBoard = gameScene.createEntity("board");

            // chess pieces. first number is team number, second number is piece number
			// TEAM 1
            var entity_1Rook1 = gameScene.createEntity("1rook1");
            var entity_1Rook2 = gameScene.createEntity("1rook2");
            var entity_1Knight1 = gameScene.createEntity("1knight1");
            var entity_1Knight2 = gameScene.createEntity("1knight2");
            var entity_1Queen = gameScene.createEntity("1queen");
            var entity_1King = gameScene.createEntity("1king");
            var entity_1Bishop1 = gameScene.createEntity("1bishop1");
			var entity_1Bishop2 = gameScene.createEntity("1bishop2");

			// PAWNS 1
			var entity_1Pawn1 = gameScene.createEntity("1pawn1");
			var entity_1Pawn2 = gameScene.createEntity("1pawn2");
			var entity_1Pawn3 = gameScene.createEntity("1pawn3");
			var entity_1Pawn4 = gameScene.createEntity("1pawn4");
			var entity_1Pawn5 = gameScene.createEntity("1pawn5");
			var entity_1Pawn6 = gameScene.createEntity("1pawn6");
			var entity_1Pawn7 = gameScene.createEntity("1pawn7");
			var entity_1Pawn8 = gameScene.createEntity("1pawn8");

			// TEAM 2
            var entity_2Rook1 = gameScene.createEntity("2rook1");
            var entity_2Rook2 = gameScene.createEntity("2rook2");
            var entity_2Knight1 = gameScene.createEntity("2knight1");
            var entity_2Knight2 = gameScene.createEntity("2knight2");
            var entity_2Queen = gameScene.createEntity("2queen");
            var entity_2King = gameScene.createEntity("2king");
            var entity_2Bishop1 = gameScene.createEntity("2bishop1");
			var entity_2Bishop2 = gameScene.createEntity("2bishop2");

			// PAWNS 2
            var entity_2Pawn1 = gameScene.createEntity("2pawn1");
			var entity_2Pawn2 = gameScene.createEntity("2pawn2");
			var entity_2Pawn3 = gameScene.createEntity("2pawn3");
			var entity_2Pawn4 = gameScene.createEntity("2pawn4");
			var entity_2Pawn5 = gameScene.createEntity("2pawn5");
			var entity_2Pawn6 = gameScene.createEntity("2pawn6");
			var entity_2Pawn7 = gameScene.createEntity("2pawn7");
			var entity_2Pawn8 = gameScene.createEntity("2pawn8");

			/******************************
           |  COMPONENTS                 |
           *******************************/

			// gameboard
			var boardSprite = new Sprite(_texBoard);
			boardSprite.setLayerDepth(1);
			boardSprite.setOrigin(new Vector2(0, 0));
			entityBoard.addComponent<Sprite>(boardSprite);

			var gameBoard = entityBoard.addComponent<gameBoard>(new gameBoard());

			// king team 1
			entity_1King.addComponent<Sprite>(new Sprite(_texKingBlack).setOrigin(new Vector2(0, 0)));
			entity_1King.addComponent<MouseClickEvent>(new MouseClickEvent());
            entity_1King.addComponent<chessPiece>(new chessPiece(pieceTypes.King));

            // king team 2
			entity_2King.addComponent<Sprite>(new Sprite(_texKingRed).setOrigin(new Vector2(0, 0)));

			// queens
			entity_1Queen.addComponent<Sprite>(new Sprite(_texQueenBlack).setOrigin(new Vector2(0, 0)));
			entity_2Queen.addComponent<Sprite>(new Sprite(_texQueenRed).setOrigin(new Vector2(0, 0)));

			// bishops
			entity_1Bishop1.addComponent<Sprite>(new Sprite(_texBishopBlack).setOrigin(new Vector2(0, 0)));
			entity_1Bishop2.addComponent<Sprite>(new Sprite(_texBishopBlack).setOrigin(new Vector2(0, 0)));
			entity_2Bishop1.addComponent<Sprite>(new Sprite(_texBishopRed).setOrigin(new Vector2(0, 0)));
			entity_2Bishop2.addComponent<Sprite>(new Sprite(_texBishopRed).setOrigin(new Vector2(0, 0)));


			// rooks
			entity_1Rook1.addComponent<Sprite>(new Sprite(_texRookBlack).setOrigin(new Vector2(0, 0)));
			entity_1Rook2.addComponent<Sprite>(new Sprite(_texRookBlack).setOrigin(new Vector2(0, 0)));
			entity_2Rook1.addComponent<Sprite>(new Sprite(_texRookRed).setOrigin(new Vector2(0, 0)));
			entity_2Rook2.addComponent<Sprite>(new Sprite(_texRookRed).setOrigin(new Vector2(0, 0)));

			// knights
			entity_1Knight1.addComponent<Sprite>(new Sprite(_texKnightBlack).setOrigin(new Vector2(0, 0)));
			entity_1Knight2.addComponent<Sprite>(new Sprite(_texKnightBlack).setOrigin(new Vector2(0, 0)));
			entity_2Knight1.addComponent<Sprite>(new Sprite(_texKnightRed).setOrigin(new Vector2(0, 0)));
			entity_2Knight2.addComponent<Sprite>(new Sprite(_texKnightRed).setOrigin(new Vector2(0, 0)));

			entity_1Pawn1.addComponent<Sprite>(new Sprite(_texPawnBlack).setOrigin(new Vector2(0, 0)));
			entity_1Pawn2.addComponent<Sprite>(new Sprite(_texPawnBlack).setOrigin(new Vector2(0, 0)));
			entity_1Pawn3.addComponent<Sprite>(new Sprite(_texPawnBlack).setOrigin(new Vector2(0, 0)));
			entity_1Pawn4.addComponent<Sprite>(new Sprite(_texPawnBlack).setOrigin(new Vector2(0, 0)));
			entity_1Pawn5.addComponent<Sprite>(new Sprite(_texPawnBlack).setOrigin(new Vector2(0, 0)));
			entity_1Pawn6.addComponent<Sprite>(new Sprite(_texPawnBlack).setOrigin(new Vector2(0, 0)));
			entity_1Pawn7.addComponent<Sprite>(new Sprite(_texPawnBlack).setOrigin(new Vector2(0, 0)));
			entity_1Pawn8.addComponent<Sprite>(new Sprite(_texPawnBlack).setOrigin(new Vector2(0, 0)));

			entity_2Pawn1.addComponent<Sprite>(new Sprite(_texPawnRed).setOrigin(new Vector2(0, 0)));
			entity_2Pawn2.addComponent<Sprite>(new Sprite(_texPawnRed).setOrigin(new Vector2(0, 0)));
			entity_2Pawn3.addComponent<Sprite>(new Sprite(_texPawnRed).setOrigin(new Vector2(0, 0)));
			entity_2Pawn4.addComponent<Sprite>(new Sprite(_texPawnRed).setOrigin(new Vector2(0, 0)));
			entity_2Pawn5.addComponent<Sprite>(new Sprite(_texPawnRed).setOrigin(new Vector2(0, 0)));
			entity_2Pawn6.addComponent<Sprite>(new Sprite(_texPawnRed).setOrigin(new Vector2(0, 0)));
			entity_2Pawn7.addComponent<Sprite>(new Sprite(_texPawnRed).setOrigin(new Vector2(0, 0)));
			entity_2Pawn8.addComponent<Sprite>(new Sprite(_texPawnRed).setOrigin(new Vector2(0, 0)));

			// pawns

			//var Pawn = new Sprite(_texPawnBlack);

			// Positioning

			var boardHeight = _texBoard.Height * 2;
			var boardWidth = _texBoard.Width * 2;

			entityBoard.transform.scale = new Vector2(2f);
			entityBoard.transform.setPosition(new Vector2((graphicsDevice.Viewport.Width / 2) - _texBoard.Width, 
			                                              (graphicsDevice.Viewport.Height / 2) - _texBoard.Width));

			// team 1
			entity_1Queen.transform.position = new Vector2(entityBoard.position.X + (3 * 128), entityBoard.position.Y);
			entity_1King.transform.position = new Vector2(entityBoard.position.X + (4 * 128), entityBoard.position.Y);
			entity_1Rook1.transform.position = new Vector2(entityBoard.position.X, entityBoard.position.Y);
			entity_1Rook2.transform.position = new Vector2(entityBoard.position.X + (7 * 128), entityBoard.position.Y);
			entity_1Knight1.transform.position = new Vector2(entityBoard.position.X + 128, entityBoard.position.Y);
			entity_1Knight2.transform.position = new Vector2(entityBoard.position.X + (6 * 128), entityBoard.position.Y);
			entity_1Bishop1.transform.position = new Vector2(entityBoard.position.X + 256, entityBoard.position.Y);
			entity_1Bishop2.transform.position = new Vector2(entityBoard.position.X + (5 * 128), entityBoard.position.Y);

			// pawns 1
			entity_1Pawn1.transform.position = new Vector2(entityBoard.position.X, entityBoard.position.Y + 128);
			entity_1Pawn2.transform.position = new Vector2(entityBoard.position.X + 128, entityBoard.position.Y + 128);
			entity_1Pawn3.transform.position = new Vector2(entityBoard.position.X + 256, entityBoard.position.Y + 128);
			entity_1Pawn4.transform.position = new Vector2(entityBoard.position.X + 384, entityBoard.position.Y + 128);
			entity_1Pawn5.transform.position = new Vector2(entityBoard.position.X + 512, entityBoard.position.Y + 128);
			entity_1Pawn6.transform.position = new Vector2(entityBoard.position.X + 640, entityBoard.position.Y + 128);
			entity_1Pawn7.transform.position = new Vector2(entityBoard.position.X + 768, entityBoard.position.Y + 128);
			entity_1Pawn8.transform.position = new Vector2(entityBoard.position.X + 896, entityBoard.position.Y + 128);

			//team 2
			entity_2Queen.transform.position = new Vector2(entityBoard.position.X + (4 * 128), entityBoard.position.Y + 896);
			entity_2King.transform.position = new Vector2(entityBoard.position.X + (3 * 128), entityBoard.position.Y + 896);
			entity_2Rook1.transform.position = new Vector2(entityBoard.position.X, entityBoard.position.Y + 896);
			entity_2Rook2.transform.position = new Vector2(entityBoard.position.X + (7 * 128), entityBoard.position.Y + 896);
			entity_2Knight1.transform.position = new Vector2(entityBoard.position.X + 128, entityBoard.position.Y + 896);
			entity_2Knight2.transform.position = new Vector2(entityBoard.position.X + (6 * 128), entityBoard.position.Y + 896);
			entity_2Bishop1.transform.position = new Vector2(entityBoard.position.X + 256, entityBoard.position.Y + 896);
			entity_2Bishop2.transform.position = new Vector2(entityBoard.position.X + (5 * 128), entityBoard.position.Y + 896);

			// pawns 2
			entity_2Pawn1.transform.position = new Vector2(entityBoard.position.X, entityBoard.position.Y + 768);
			entity_2Pawn2.transform.position = new Vector2(entityBoard.position.X + 128, entityBoard.position.Y + 768);
			entity_2Pawn3.transform.position = new Vector2(entityBoard.position.X + 256, entityBoard.position.Y + 768);
			entity_2Pawn4.transform.position = new Vector2(entityBoard.position.X + 384, entityBoard.position.Y + 768);
			entity_2Pawn5.transform.position = new Vector2(entityBoard.position.X + 512, entityBoard.position.Y + 768);
			entity_2Pawn6.transform.position = new Vector2(entityBoard.position.X + 640, entityBoard.position.Y + 768);
			entity_2Pawn7.transform.position = new Vector2(entityBoard.position.X + 768, entityBoard.position.Y + 768);
			entity_2Pawn8.transform.position = new Vector2(entityBoard.position.X + 896, entityBoard.position.Y + 768);

            Core.scene = gameScene;

        }

    }
}
