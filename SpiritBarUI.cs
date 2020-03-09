using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;

namespace SpiritBar
{
    class SpiritBarUI : UIState
    {
        private UIElement area;
        private UIImage barFrame;
        private UIFlatPanel bgfill;
        public float quotient = 0f;//The quotient is calculated and sent by the SpiritBarPlayerClass
        private UIFlatPanel fill;
        int height = 75;
        public override void OnInitialize()
        {
            area = new UIElement();
            area.Left.Set(0, 0f); 
            area.Top.Set(15, 0.5f); 
            area.Width.Set(60, 0f); 
            area.Height.Set(182, 0f);

            barFrame = new UIImage(GetTexture("SpiritBar/SpiritMeterInactive"));//This will be what to change, I guess, to animate the bar
            barFrame.Left.Set(-20, 0f);
            barFrame.Top.Set(0, 0f);
            barFrame.Width.Set(34, 0f);
            barFrame.Height.Set(138, 0f);

            fill = new UIFlatPanel();//Delete that and replace it with a gradient
            fill.Width.Set(17, 0f);
            fill.Height.Set(height, 0f);
            fill.Left.Set(22, 0f);
            fill.backgroundColor = Color.Cyan;
            fill.Top.Set(-height + 79, 0f);
            
            bgfill = new UIFlatPanel();//Dimensions should be the same as the fill at full size
            bgfill.Width.Set(17, 0f);
            bgfill.Height.Set(height, 0f);
            bgfill.Left.Set(22, 0f);
            bgfill.backgroundColor = Color.Black;
            bgfill.Top.Set(-height + 79, 0f);




            area.Append(bgfill);//Append the Background before the foreground
            area.Append(fill);
            
            area.Append(barFrame);

            

            Append(area);




        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            fill.Height.Set(quotient * height, 0f); //We set the height of the filling here
            fill.Top.Set(-(quotient * height) +79, 0f);//We add the (+79) offset, and make the filling go down by its height, to make it behave like it's filling from bottom to top
            Recalculate(); 
            base.Draw(spriteBatch);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);
            
        }




        //Here basically for the Plain color filling, and filling black background;
        class UIFlatPanel : UIElement 
        {
            public Color backgroundColor = Color.Gray;
            private static Texture2D _backgroundTexture;

            public UIFlatPanel()
            {
                if (_backgroundTexture == null)
                    _backgroundTexture = ModContent.GetTexture("SpiritBar/Blank");
            }

            protected override void DrawSelf(SpriteBatch spriteBatch)
            {
                CalculatedStyle dimensions = GetDimensions();
                Point point1 = new Point((int)dimensions.X, (int)dimensions.Y);
                int width = (int)Math.Ceiling(dimensions.Width);
                int height = (int)Math.Ceiling(dimensions.Height);
                spriteBatch.Draw(_backgroundTexture, new Rectangle(point1.X, point1.Y, width, height), backgroundColor);
            }



        }


    }
}
