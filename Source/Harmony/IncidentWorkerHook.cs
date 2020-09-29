﻿using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace RimStory.Harmony
{
    [HarmonyPatch(typeof(IncidentWorker))]
    [HarmonyPatch("TryExecute")]
    class IncidentWorkerHookShort
    {
        static void Postfix(IncidentWorker __instance, ref IncidentParms parms, bool __result)
        {
            if (__result)
            {
                //Log.Warning("name " + __instance.def.defName);
                //Log.Warning("duration " + __instance.def.durationDays);
                //Log.Warning("category " + __instance.def.category);
                //Log.Warning("letter label " + __instance.def.letterLabel);
                //Log.Warning("letter label " + __instance.def);
                //Resources.eventsLog.Add(new IncidentShort(Utils.CurrentDate(), __instance.def.letterText));
                // Log.Warning("letter label: " + __instance.def.letterText);
                //Log.Warning("letter label: " + __instance.def.label.Translate());
                // Log.Warning("letter label: " + __instance.ToString());

                if (__instance is IncidentWorker_AnimalInsanityMass)
                {
                    Resources.eventsLog.Add(new IncidentShort(Utils.CurrentDate(), "RS_" + __instance.def.defName));
                }


                if (__instance is IncidentWorker_ManhunterPack)
                {
                    Resources.eventsLog.Add(new IncidentShort(Utils.CurrentDate(), "RS_" + __instance.def.defName));
                }

                if (__instance is IncidentWorker_ColdSnap)
                {
                    Resources.eventsLog.Add(new IncidentShort(Utils.CurrentDate(), "RS_" + __instance.def.defName));
                }

                if (__instance is IncidentWorker_HeatWave)
                {
                    Resources.eventsLog.Add(new IncidentShort(Utils.CurrentDate(), "RS_" + __instance.def.defName));
                }

                if (__instance is IncidentWorker_FarmAnimalsWanderIn)
                {
                    Resources.eventsLog.Add(new IncidentShort(Utils.CurrentDate(), "RS_" + __instance.def.defName));
                }

                if (__instance is IncidentWorker_Infestation)
                {
                    Resources.eventsLog.Add(new IncidentShort(Utils.CurrentDate(), "RS_" + __instance.def.defName));
                }
                /*
                if (__instance is IncidentWorker_RefugeeChased)
                {
                    Resources.eventsLog.Add(new IncidentShort(Utils.CurrentDate(), "RS_" + __instance.def.defName));
                }
                */
                if (__instance is IncidentWorker_TransportPodCrash)
                {
                    Resources.eventsLog.Add(new IncidentShort(Utils.CurrentDate(), "RS_" + __instance.def.defName));
                }

                if (__instance is IncidentWorker_WandererJoin)
                {
                    Resources.eventsLog.Add(new IncidentShort(Utils.CurrentDate(), "RS_" + __instance.def.defName));
                }

                ////////////////////// DIRTY HACKS \\\\\\\\\\\\\\\\\\\\\\\\\\\\

                if(__instance.def.defName == "VolcanicWinter")
                {
                    Resources.eventsLog.Add(new IncidentShort(Utils.CurrentDate(), "RS_" + __instance.def.defName));
                }

                if (__instance.def.defName == "ToxicFallout")
                {
                    Resources.eventsLog.Add(new IncidentShort(Utils.CurrentDate(), "RS_" + __instance.def.defName));
                }

                Log.Warning(__instance.def.defName);

            }
           
        }
    }

    [HarmonyPatch(typeof(GameCondition))]
    [HarmonyPatch("Init")]
    class IncidentWorkerHookLong
    {
        static void Postfix(IncidentWorker __instance)
        {
            Log.Message("it works "+__instance.def.defName);
        }
    }
}
