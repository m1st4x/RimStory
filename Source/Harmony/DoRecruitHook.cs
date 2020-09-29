using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace RimStory.Harmony
{
    [HarmonyPatch(typeof(InteractionWorker_RecruitAttempt))]
    [HarmonyPatch("DoRecruit")]
    [HarmonyPatch(new Type[] { typeof(Pawn), typeof(Pawn), typeof(float), typeof(bool) })]

    class DoRecruitHook
    {
        static void Postfix(Pawn recruiter, Pawn recruitee)
        {
            Resources.eventsLog.Add(new ARecruitment(Utils.CurrentDate(), recruiter, recruitee));
        }
    }
}
