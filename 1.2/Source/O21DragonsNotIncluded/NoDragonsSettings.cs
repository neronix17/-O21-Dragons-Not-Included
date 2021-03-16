using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using RimWorld;
using Verse;

using HarmonyLib;

namespace O21DragonsNotIncluded
{
    public class NoDragonsSettings : ModSettings
    {
        // Content Toggles
        public bool contentToggle_Tribal = true;
        public bool contentToggle_Medieval = true;
        public bool contentToggle_Fantasy = true;
        public bool contentToggle_Tropical = true;
        public bool contentToggle_Sengoku = true;

        public override void ExposeData()
        {
            base.ExposeData();

            // Content Toggles
            Scribe_Values.Look(ref contentToggle_Tribal, "contentToggle_Tribal", true);
            Scribe_Values.Look(ref contentToggle_Medieval, "contentToggle_Medieval", true);
            Scribe_Values.Look(ref contentToggle_Fantasy, "contentToggle_Fantasy", true);
            Scribe_Values.Look(ref contentToggle_Tropical, "contentToggle_Tropical", true);
            Scribe_Values.Look(ref contentToggle_Sengoku, "contentToggle_Sengoku", true);
        }

        public IEnumerable<string> GetEnabledSettings
        {
            get
            {
                return GetType().GetFields().Where(p => p.FieldType == typeof(bool) && (bool)p.GetValue(this)).Select(p => p.Name);
            }
        }
    }
}
