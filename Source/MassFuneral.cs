﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using Verse.AI;
using RimWorld;
using RimWorld.Planet;
using Verse.AI.Group;

namespace RimStory
{
    public static class MassFuneral
    {
        private static String deadPawnsNames = "";

        static MassFuneral()
        {
            
        }
       
        public static bool TryStartMassFuneral(Map map)
        {
            if (Utils.CurrentDay() == 7 || Utils.CurrentDay() == 14)
            {
                //Pawn pawn = PartyUtility.FindRandomPartyOrganizer(Faction.OfPlayer, map);
                Pawn pawn = GatheringsUtility.FindRandomGatheringOrganizer(Faction.OfPlayer, map, GatheringDefOf.Party);

                if (pawn == null)
                {
                    return false;
                }               
                IntVec3 intVec;
                //if (!RCellFinder.TryFindPartySpot(pawn, out intVec))
                if (!RCellFinder.TryFindGatheringSpot(pawn, GatheringDefOf.Party, out intVec))
                {
                    return false;
                }
                foreach (Pawn deadPawn in Resources.deadPawnsForMassFuneralBuried)
                {
                    if (deadPawn != null)
                    {
                        deadPawnsNames = deadPawnsNames + deadPawn.Label + "\n";
                    }
                }
                Lord lord = LordMaker.MakeNewLord(pawn.Faction, new LordJob_RimStory(Resources.lastGrave.Position, pawn), map, null);
                Find.LetterStack.ReceiveLetter("FuneralLetter".Translate(), "FuneralDesc".Translate() + deadPawnsNames, LetterDefOf.NeutralEvent, Resources.lastGrave);               

                deadPawnsNames = "";
                return true;
            }
            return false;
        }

    }
}
