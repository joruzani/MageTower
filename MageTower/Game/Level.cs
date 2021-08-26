using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

namespace MageTower
{

    class Level
    {
        public ContentManager Content
        {
            get { return content; }
        }
        ContentManager content;

        Texture2D tileTexture;


        public Level(IServiceProvider serviceProvider)
        {
            content = new ContentManager(serviceProvider, "Content");

            content.RootDirectory = "Content";
            tileTexture = content.Load<Texture2D>("Terrain_1");


        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                tileTexture,
                new Vector2(80, 80),
                null,
                Color.White,
                0f,
                new Vector2(tileTexture.Width / 2, tileTexture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
            );
        }
    }
}