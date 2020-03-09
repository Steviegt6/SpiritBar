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
    public static class ItemListings
    {
        public static List<int> ShortSwordList()
        {
            List<int> shortswordlist = new List<int>();
            shortswordlist.Add(ItemID.CopperShortsword);
            shortswordlist.Add(ItemID.GoldShortsword);
            shortswordlist.Add(ItemID.IronShortsword);
            shortswordlist.Add(ItemID.LeadShortsword);
            shortswordlist.Add(ItemID.PlatinumShortsword);
            shortswordlist.Add(ItemID.SilverShortsword);
            shortswordlist.Add(ItemID.TinShortsword);
            shortswordlist.Add(ItemID.TungstenShortsword);
            return shortswordlist;
        }

        public static List<int> ScrollList()
        {
            List<int> scrolls = new List<int>();
            scrolls.Add(ModContent.ItemType<Items.BlankScroll>());
            scrolls.Add(ModContent.ItemType<Items.ShortSwordScroll>());

            return scrolls;

        }

    }
}
