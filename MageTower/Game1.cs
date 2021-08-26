using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MageTower
{
    public class Game1 : Game
    {
        Texture2D mageTexture;
        Texture2D tileTexture;
        Vector2 magePosition;
        float mageSpeed;

        private Level level;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        private Player player;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            magePosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            mageSpeed = 120f;

            base.Initialize();

        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            mageTexture = Content.Load<Texture2D>("rogue like idle_Animation 1_0");
            //tileTexture = Content.Load<Texture2D>("Terrain_1");
            level = new Level(Content.ServiceProvider);

            // TODO: use this.Content to load your game content here

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            var kstate = Keyboard.GetState();
            var gstate = GamePad.GetState(PlayerIndex.One);

            if (kstate.IsKeyDown(Keys.W))
                magePosition.Y -= mageSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.S))
                magePosition.Y += mageSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.A))
                magePosition.X -= mageSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.D))
                magePosition.X += mageSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            spriteBatch.Begin();
            spriteBatch.Draw(
                mageTexture,
                magePosition,
                null,
                Color.White,
                0f,
                new Vector2(mageTexture.Width / 2, mageTexture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
            );
            level.Draw(gameTime, spriteBatch);
            /*spriteBatch.Draw(
                tileTexture,
                new Vector2(10, 10),
                null,
                Color.White,
                0f,
                new Vector2(tileTexture.Width / 2, tileTexture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
            );*/
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
