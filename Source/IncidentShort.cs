﻿using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace RimStory
{
    class IncidentShort : IEvent
    {
        private Date date;
        private IncidentWorker incident;
        private String name;
     

        public IncidentShort()
        {

        }


        public IncidentShort(Date date, String name)
        {
            this.date = date;
            this.name = name;
            
        }

        public Date Date()
        {
            throw new NotImplementedException();
        }

        public void EndEvent()
        {
            throw new NotImplementedException();
        }

        public void ExposeData()
        {           
            Scribe_Values.Look(ref name, "RS_IncidentName");
            Scribe_Deep.Look(ref date, "RS_DateIncidentStart");
        }

        public bool GetIsAnniversary()
        {
            throw new NotImplementedException();
        }

        public bool IsStillEvent()
        {
            throw new NotImplementedException();
        }

        public string ShowInLog()
        {
            return (date.day + " " + date.quadrum + " " + date.year + " " + name.Translate());
            //return (date.day + " " + date.quadrum + " " + date.year + " " + "IncidentShort".Translate(name));
            //return null;
        }

        public bool TryStartEvent()
        {
            Log.Warning("Tried to start LogEvent (event added to wrong list?)"+ this);
            return false;
        }

        public bool TryStartEvent(Map map)
        {
            Log.Warning("Tried to start LogEvent (event added to wrong list?)" + this);
            return false;
        }
    }
}
