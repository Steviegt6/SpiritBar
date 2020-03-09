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
    class SpiritSlot : UIState
    {
        public ItemSlot itemslot;

        public override void OnInitialize()
        {
            base.OnInitialize();


            itemslot = new ItemSlot();
            this.Left.Set(100, 0);
            this.Top.Set(0, 0.5f);
            this.Append(itemslot);

        }
    }
}
