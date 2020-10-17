﻿using System;
using Verse;

namespace RimStory
{
    class CustomEvent : IEvent
    {
        private Date date;
        private string text;

        private bool active = true;

        public CustomEvent() { }

        public CustomEvent(Date date, string text)
        {
            this.date = date;
            this.text = text;
        }

        Date IEvent.Date()
        {
            return date;
        }

        void IEvent.EndEvent()
        {
            active = false;
        }

        bool IEvent.IsStillEvent()
        {
            return active;
        }

        string IEvent.ShowInLog()
        {
            return "[" + date.day + " " + date.quadrum + " " + date.year + "] " + this.text;
        }

        void IExposable.ExposeData()
        {
            Scribe_Deep.Look(ref date, "RS_DateEvent");
            Scribe_Values.Look(ref text, "RS_TextEvent");
        }

        bool IEvent.TryStartEvent()
        {
            throw new NotImplementedException();
        }

        bool IEvent.TryStartEvent(Map map)
        {
            throw new NotImplementedException();
        }

        bool IEvent.GetIsAnniversary()
        {
            throw new NotImplementedException();
        }
    }
}
