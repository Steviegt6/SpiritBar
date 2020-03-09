using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace SpiritBar
{
    class SpiritBarPlayer : ModPlayer
    {
        public int spiritBarCurrent = 0;
        public int spiritBarMax2 = 10*60;
        public SpiritBarUI SpiritBarUI;
        public SpiritSlot SpiritSlot;
        public List<int> ShortSwordsIDS = ItemListings.ShortSwordList();

        public List<int> ScrollIDS = ItemListings.ScrollList();

        public override void PreUpdate()
        {
            base.PreUpdate();

            if(SpiritSlot?.itemslot?.item != null && SpiritSlot?.itemslot?.item != default)
            {
                if(SpiritSlot.itemslot.item.type == ModContent.ItemType<Items.BlankScroll>())
                {
                    spiritBarCurrent++;
                }
                else if(SpiritSlot.itemslot.item.type == ModContent.ItemType<Items.ShortSwordScroll>())
                {
                    if (ShortSwordsIDS.Contains(player.HeldItem.type))
                    {
                        spiritBarCurrent++;
                    }
                    else spiritBarCurrent = 0;
                }
                else spiritBarCurrent = 0;
            }
            else
            {
                spiritBarCurrent = 0;
            }
            if (spiritBarCurrent > spiritBarMax2) spiritBarCurrent = spiritBarMax2;

            if (Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.R) || Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.R))
            {
                spiritBarCurrent = 0;
            }

            float quot = (float)spiritBarCurrent / (float)spiritBarMax2;
            if (SpiritBarUI != null) SpiritBarUI.quotient = quot;
        }



        public override void OnEnterWorld(Player player)
        {
            base.OnEnterWorld(player);
            if (!Main.dedServ)
            {
                SpiritBarUI = SpiritBar.Instance.SpiritBarUI;
                SpiritSlot = SpiritBar.Instance.SlotUI;

            }
        }

        public override bool ShiftClickSlot(Item[] inventory, int context, int slot)
        {
            if (context == Terraria.UI.ItemSlot.Context.InventoryItem || context == Terraria.UI.ItemSlot.Context.InventoryCoin || context == Terraria.UI.ItemSlot.Context.InventoryAmmo)
            {
                if (ScrollIDS.Contains( inventory[slot].type)) //CHECK IF IT IS A SCROLL HERE !
                {
                    Main.PlaySound(7, -1, -1, 1, 1f, 0f);

                    Item ts = inventory[slot];
                    var kk = new Item();
                    kk.SetDefaults(ts.type);
                    var ss = SpiritSlot.itemslot.item;
                    if (ss != null && ss != default) player.QuickSpawnClonedItem(ss);
                    SpiritSlot.itemslot.SetItem(kk);

                    ts.TurnToAir();
                    return true;
                }

            }
            return false; // do default behavior.
        }



    }

}
