using Terraria.ModLoader;


using System;
using Terraria.UI;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
namespace SpiritBar
{
    public class SpiritBar : Mod
    {

        internal UserInterface SpiritInterface;
        internal UserInterface SpiritSlot;
        internal SpiritSlot SlotUI;
        internal SpiritBarUI SpiritBarUI;


        private GameTime _lastUpdateUiGameTime;

        public static SpiritBar Instance { get; private set; }

        public SpiritBar()
        {
            SpiritBar.Instance = this;



        }


        public override void UpdateUI(GameTime gameTime)
        {
            _lastUpdateUiGameTime = gameTime;
            if (SpiritInterface?.CurrentState != null)
            {
                SpiritInterface.Update(gameTime);
            }
            if (SpiritSlot?.CurrentState != null)
            {
                SpiritSlot.Update(gameTime);
            }

        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (mouseTextIndex != -1)
            {
                layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                    "MyMod: MyInterface",
                    delegate
                    {
                        if (_lastUpdateUiGameTime != null && SpiritInterface?.CurrentState != null)
                        {
                            SpiritInterface.Draw(Main.spriteBatch, _lastUpdateUiGameTime);
                        }
                        return true;
                    },
                       InterfaceScaleType.UI));



                layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                    "MyMod: MyInterface2",
                    delegate
                    {
                        if (_lastUpdateUiGameTime != null && SpiritSlot?.CurrentState != null)
                        {
                            SpiritSlot.Draw(Main.spriteBatch, _lastUpdateUiGameTime);
                        }
                        return true;
                    },
                       InterfaceScaleType.UI));

            }
        }

        public override void Load()
        {

           


            if (!Main.dedServ)
            {
                SpiritInterface = new UserInterface();
                SpiritSlot = new UserInterface();
                SpiritBarUI = new SpiritBarUI();
                SpiritBarUI.Activate(); // Activate calls Initialize() on the UIState if not initialized, then calls OnActivate and then calls Activate on every child element
                SlotUI = new SpiritSlot();
                SlotUI.Activate();
                Instance.SpiritInterface.SetState(SpiritBar.Instance.SpiritBarUI);
                Instance.SpiritSlot.SetState(SpiritBar.Instance.SlotUI);
            }

        }


        public override void Unload()
        {
            SpiritBar.Instance = null;

            SpiritBarUI = null;
            SpiritInterface = null;
            SlotUI = null;
            SpiritSlot = null;
        }






    }
}
