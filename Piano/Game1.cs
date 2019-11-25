using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace Piano
{ 
    public static class PianoNotes
    {
        public static SoundEffect C4;
        public static SoundEffect D4;
        public static SoundEffect E4;
        public static SoundEffect F4;
        public static SoundEffect G4;
        public static SoundEffect A4; 
    }
    public class Game1 : Game
    {
        //Piano tones from the University of Iowa 
        //Electronic Music Studios
        //http://theremin.music.uiowa.edu/MISpiano.html

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        MouseState mState;
        KeyboardState kState;

        // Booleans for keeping track of the button and mouse presses
        bool leftReleased = true;
        bool rightReleased = true;
        bool upReleased = true;
        bool downReleased = true;
        bool spaceReleased = true; 
        bool mReleased = true;

        bool leftPressed = false;
        bool rightPressed = false;
        bool upPressed = false;
        bool downPressed = false;
        bool spacePressed = false;
        bool mousePressed = false; 

        //Piano textures
        Texture2D pianoBase;
        Texture2D leftClicked;
        Texture2D upClicked;
        Texture2D rightClicked;
        Texture2D downClicked;
        Texture2D spaceClicked;
        Texture2D mouseClicked; 

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            this.IsMouseVisible = true; 
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            pianoBase = Content.Load<Texture2D>("Piano");
            leftClicked = Content.Load<Texture2D>("Left Clicked");
            upClicked = Content.Load<Texture2D>("Up Clicked");
            rightClicked = Content.Load<Texture2D>("Right Clicked");
            downClicked = Content.Load<Texture2D>("Down Clicked");
            spaceClicked = Content.Load<Texture2D>("Space Clicked");
            mouseClicked = Content.Load<Texture2D>("Click Clicked");

            PianoNotes.C4 = Content.Load<SoundEffect>("Sounds/C4");
            PianoNotes.D4 = Content.Load<SoundEffect>("Sounds/D4");
            PianoNotes.E4 = Content.Load<SoundEffect>("Sounds/E4");
            PianoNotes.F4 = Content.Load<SoundEffect>("Sounds/F4");
            PianoNotes.G4 = Content.Load<SoundEffect>("Sounds/G4");
            PianoNotes.A4 = Content.Load<SoundEffect>("Sounds/A4");

        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Get what is happening to the keyboard and mouse at every frame. 
            kState = Keyboard.GetState();
            mState = Mouse.GetState();

            if (mState.LeftButton == ButtonState.Pressed && mReleased == true)
            {
                mousePressed = true; 
                mReleased = false;
                PianoNotes.A4.Play();
            }
            if (mState.LeftButton == ButtonState.Released)
            {
                mousePressed = false; 
                mReleased = true;
            }

            if (kState.IsKeyDown(Keys.Left) && leftReleased)
            {
                leftPressed = true;
                leftReleased = false; 
                PianoNotes.C4.Play();
            }
            if (kState.IsKeyUp(Keys.Left))
            {
                leftPressed = false;
                leftReleased = true; 
            }

            if (kState.IsKeyDown(Keys.Right) && rightReleased)
            {
                rightPressed = true;
                rightReleased = false;
                PianoNotes.E4.Play(); 
            }
            if (kState.IsKeyUp(Keys.Right))
            {
                rightPressed = false;
                rightReleased = true; 
            }

            if (kState.IsKeyDown(Keys.Up) && upReleased)
            {
                upPressed = true;
                upReleased = false;
                PianoNotes.D4.Play();
            }
            if (kState.IsKeyUp(Keys.Up))
            {
                upPressed = false;
                upReleased = true; 
            }

            if (kState.IsKeyDown(Keys.Down) && downReleased)
            {
                downPressed = true;
                downReleased = false;
                PianoNotes.F4.Play(); 
            }
            if (kState.IsKeyUp(Keys.Down))
            {
                downPressed = false;
                downReleased = true; 
            }

            if (kState.IsKeyDown(Keys.Space) && spaceReleased)
            {
                spacePressed = true;
                spaceReleased = false;
                PianoNotes.G4.Play();
            }
            if (kState.IsKeyUp(Keys.Space))
            {
                spacePressed = false;
                spaceReleased = true; 
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();

            spriteBatch.Draw(pianoBase, new Vector2(0, 0), Color.White);

            if (leftPressed)
            {
                spriteBatch.Draw(leftClicked, new Vector2(15, 22), Color.White);
            }
            if (rightPressed)
            {
                spriteBatch.Draw(rightClicked, new Vector2(326, 15), Color.White);
            }
            if (upPressed)
            {
                spriteBatch.Draw(upClicked, new Vector2(181, 16), Color.White);
            }
            if (downPressed)
            {
                spriteBatch.Draw(downClicked, new Vector2(483, 16), Color.White);
            }
            if (spacePressed)
            {
                spriteBatch.Draw(spaceClicked, new Vector2(650, 16), Color.White);
            }
            if (mousePressed)
            {
                spriteBatch.Draw(mouseClicked, new Vector2(825, 23), Color.White);
            }

            spriteBatch.End(); 

            base.Draw(gameTime);
        }
    }
}
