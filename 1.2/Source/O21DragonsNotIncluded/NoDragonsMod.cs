using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using RimWorld;
using Verse;

using HarmonyLib;

using O21Toolbox;

namespace O21DragonsNotIncluded
{
    public class NoDragonsMod : Mod
    {
        public static NoDragonsSettings settings;
        public static NoDragonsMod mod;

        public ForgottenRealmsSettingsPage currentSettingsPage;

        public NoDragonsMod(ModContentPack content) : base(content)
        {
            settings = GetSettings<NoDragonsSettings>();
            mod = this;
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            float secondStageHeight;
            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);
            listingStandard.ValueLabeled("Settings Page", "Cycle this setting to change page. Changing settings requires a restart to take effect. You should NEVER disable any of these mid-save, it's the same as uninstalling that part of the mod and can have severe consequences, no support will be provided if you do this because there is nothing I can do, and yes I will know.", ref currentSettingsPage);
            listingStandard.GapLine();
            listingStandard.Gap(48);
            secondStageHeight = listingStandard.CurHeight;
            listingStandard.End();

            listingStandard = new Listing_Standard
            {
                ColumnWidth = (inRect.width - 30f) / 2f - 2f
            };
            inRect.yMin = secondStageHeight;
            listingStandard.Begin(inRect);

            if (currentSettingsPage == ForgottenRealmsSettingsPage.General)
            {
                DoGeneralSettingsPage(listingStandard);
            }
            if (currentSettingsPage == ForgottenRealmsSettingsPage.Integrations)
            {
                DoIntegrationsSettingsPage(listingStandard);
            }

            listingStandard.End();
            base.DoSettingsWindowContents(inRect);
        }

        public void DoGeneralSettingsPage(Listing_Standard listingStandard)
        {
            listingStandard.CheckboxEnhanced("Tribal Content", "Covers all standard tribal styled content.", ref settings.contentToggle_Tribal);
            listingStandard.CheckboxEnhanced("Medieval Content", "Covers all standard medieval styled content.", ref settings.contentToggle_Medieval);
            listingStandard.CheckboxEnhanced("Fantasy Content", "Covers all content that is magical in nature.", ref settings.contentToggle_Fantasy);
            listingStandard.CheckboxEnhanced("Tropical Content", "Covers all the tropical content, mostly weapons.", ref settings.contentToggle_Tropical);
            listingStandard.CheckboxEnhanced("Sengoku Content", "Covers all the content mostly based on Japanese culture from around the Sengoku period.", ref settings.contentToggle_Sengoku);

            listingStandard.NewColumn();

        }

        public void DoIntegrationsSettingsPage(Listing_Standard listingStandard)
        {
            //listingStandard.CheckboxLabeled("Dwarves", ref settings.raceToggle_dwarf, "Enables/Disables Dwarves.");

            listingStandard.NewColumn();

            //if (settings.raceToggle_dwarf) { listingStandard.CheckboxLabeled("Dwarves Faction", ref settings.factionToggle_dwarf, "Controls spawning of the NPC Dwarf Faction"); }
        }

        public override string SettingsCategory()
        {
            return "Dragons Not Included";
        }
    }

    public enum ForgottenRealmsSettingsPage
    {
        General,
        Integrations
    }
}
