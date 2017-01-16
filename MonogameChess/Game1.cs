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

        }


        const int MAIN_RENDER_LAYER = 0;

        protected override void Initialize()
        {

            base.Initialize();

            // SCENES
            var gameScene = new Scene();
            var menuScene = new Scene();

            gameScene.addRenderer<RenderLayerRenderer>(new RenderLayerRenderer(0, MAIN_RENDER_LAYER));

            /******************************
            |   TEXTURES                  |
            ******************************/
            var _texBoard = content.Load<Texture2D>("board");
            var _ssPieces = content.Load<Texture2D>("sheet_pieces");

            /******************************
            |   ENTITIES                  |
            ******************************/
            var entityBoard = gameScene.createEntity("board");

            // chess pieces. first number is team number, second number is piece number
            var entity_1Rook1 = gameScene.createEntity("1rook1");
            var entity_1Rook2 = gameScene.createEntity("1rook2");
            var entity_1Knight1 = gameScene.createEntity("1knight1");
            var entity_1Knight2 = gameScene.createEntity("1knight2");
            var entity_1Queen = gameScene.createEntity("1queen");
            var entity_1King = gameScene.createEntity("1king");
            var entity_1Bishop1 = gameScene.createEntity("1bishop1");
            var entity_1Bishop2 = gameScene.createEntity("1bishop2");
            var entityList_1Pawns = new List<Entity>();

            for (int i = 0; i < 8; i++)
            {
                var tempPawn = gameScene.createEntity("1pawn" + (i+1));
                entityList_1Pawns.Add(tempPawn);
            }

            var entity_2Rook1 = gameScene.createEntity("2rook1");
            var entity_2Rook2 = gameScene.createEntity("2rook2");
            var entity_2Knight1 = gameScene.createEntity("2knight1");
            var entity_2Knight2 = gameScene.createEntity("2knight2");
            var entity_2Queen = gameScene.createEntity("2queen");
            var entity_2King = gameScene.createEntity("2king");
            var entity_2Bishop1 = gameScene.createEntity("2bishop1");
            var entity_2Bishop2 = gameScene.createEntity("2bishop2");
            var entityList_2Pawns = new List<Entity>();

            for (int i = 0; i < 8; i++)
            {
                var tempPawn = gameScene.createEntity("2pawn" + (i+1));
                entityList_1Pawns.Add(tempPawn);
            }

            /******************************
           |  COMPONENTS                 |
           ******************************/

            entityBoard.addComponent<Sprite>(new Sprite(_texBoard));
            entityBoard.transform.setPosition(new Vector2(500, 500));

            Core.scene = gameScene;

        }

    }
}
