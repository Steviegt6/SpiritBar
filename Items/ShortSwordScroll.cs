using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;

namespace SpiritBar.Items
{
    public class ShortSwordScroll : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("ShortSword Scroll"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("It's not an empty scroll.\nSeems there is a ShortSword on it.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 1;
            item.value = 0;
            item.rare = 1;


        }




    }
}
