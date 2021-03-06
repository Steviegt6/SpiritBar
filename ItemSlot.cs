﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.UI;
using Terraria;
using ReLogic.Graphics;
using Terraria.ID;

namespace SpiritBar
{
    internal class ItemSlot : UIElement
    {
        public static Texture2D backgroundTexture = Main.inventoryBack9Texture;

        private Texture2D _texture;

        private float scale = 1f;
        internal int id;
        internal Item item;

        public ItemSlot()
        {

           
            this.Width.Set(backgroundTexture.Width * scale, 0f);
            this.Height.Set(backgroundTexture.Height * scale, 0f);
        }

        public void SetItem(Item _item)
        {
            this.item = _item;
            this._texture = Main.itemTexture[item.type];
        }

        public override int CompareTo(object obj)
        {
            ItemSlot other = obj as ItemSlot;
            return id.CompareTo(other.id);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            CalculatedStyle dimensions = base.GetDimensions();
            //spriteBatch.Draw(this._texture, dimensions.Position(), Color.White * (base.IsMouseHovering ? this._visibilityActive : this._visibilityInactive));

            spriteBatch.Draw(backgroundTexture, dimensions.Position(), null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            //Texture2D texture2D = Main.itemTexture[this.item.type];

            if (item == null)
            {
                item = new Item();
                this.SetItem(item);
               
            }
                Rectangle rectangle2;
                if (Main.itemAnimations[id] != null)
                {
                    rectangle2 = Main.itemAnimations[id].GetFrame(_texture);
                }
                else
                {
                    rectangle2 = _texture.Frame(1, 1, 0, 0);
                }
                float num = 1f;
                float num2 = (float)backgroundTexture.Width * scale;
                if ((float)rectangle2.Width > num2 || (float)rectangle2.Height > num2)
                {
                    if (rectangle2.Width > rectangle2.Height)
                    {
                        num = num2 / (float)rectangle2.Width;
                    }
                    else
                    {
                        num = num2 / (float)rectangle2.Height;
                    }
                }
                Vector2 drawPosition = dimensions.Position();
                drawPosition.X += (float)backgroundTexture.Width * scale / 2f - (float)rectangle2.Width * num / 2f;
                drawPosition.Y += (float)backgroundTexture.Height * scale / 2f - (float)rectangle2.Height * num / 2f;

                item.GetColor(Color.White);
                Color alphaColor = item.GetAlpha(Color.White);
                Color colorColor = item.GetColor(Color.White);
                //spriteBatch.Draw(_texture, drawPosition, new Rectangle?(rectangle2), this.item.GetAlpha(Color.White), 0f, Vector2.Zero, num, SpriteEffects.None, 0f);
                spriteBatch.Draw(_texture, drawPosition, new Rectangle?(rectangle2), alphaColor, 0f, Vector2.Zero, num, SpriteEffects.None, 0f);
                if (this.item.color != Color.Transparent)
                {
                    spriteBatch.Draw(_texture, drawPosition, new Rectangle?(rectangle2), colorColor, 0f, Vector2.Zero, num, SpriteEffects.None, 0f);
                }
                if (this.item.stack > 1)
                {
                    spriteBatch.DrawString(Main.fontItemStack, this.item.stack.ToString(), new Vector2(dimensions.Position().X + 10f * scale, dimensions.Position().Y + 26f * scale), Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
                }


                if (IsMouseHovering)
                {
                    //Main.toolTip = item.Clone();
                    Main.hoverItemName = item.Name;
                    //ItemChecklistUI.hoverText = item.name + (item.modItem != null ? " [" + item.modItem.mod.Name + "]" : "");
                }
            

        }

        public override void Click(UIMouseEvent evt)
        {
            if (Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftShift) || Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.RightShift))
            {
                if (item != null) Main.LocalPlayer.QuickSpawnClonedItem(item);
                this.item = null;
            }
        }

       
    }
}
