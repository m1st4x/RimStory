using System.Linq;
using RimWorld;
using UnityEngine;
using Verse;

namespace RimStory
{
    class Window_Story : MainTabWindow
    {
        public static int sie = 0;
        public static Vector2 vect = new Vector2(sie, sie);
        public static Vector2 logSize = new Vector2();
        Listing_Standard listing_Standard = new Listing_Standard();
        Rect inner = new Rect();
        Rect outter = new Rect();
        Rect bigRect = new Rect();
        Rect filterRect = new Rect();

        Texture2D texDelete = ContentFinder<Texture2D>.Get("Delete.tex", true);
        string customText = "";

        private static int defaultLogSize = 200;

        public override bool CausesMessageBackground()
        {          
            return base.CausesMessageBackground();
        }

        public override void Close(bool doCloseSound = true)
        {
            base.Close(doCloseSound);
        }

        public override void DoWindowContents(Rect rect)
        {
            base.DoWindowContents(rect);

            if (!RimStoryMod.settings.enableLogging) return;

            if (Resources.eventsLog != null)
            {
                Text.Font = GameFont.Small;

                outter = new Rect(rect.position, new Vector2(rect.width - 200, rect.height));
                float txtWidth = outter.width - 120;
                float yoff = 20f;
                float logHeight = 0;
                foreach (IEvent e in Resources.eventsLog)
                {
                    logHeight += Text.CalcHeight(e.ShowInLog(), txtWidth);
                }
                logHeight += Resources.eventsLog.Count * 10;

                bigRect = new Rect(rect.position, new Vector2(rect.width, defaultLogSize + logHeight));
                logSize = new Vector2(rect.x, defaultLogSize + logHeight);
                inner = new Rect(rect.position, logSize);

                Widgets.BeginScrollView(outter, ref vect, inner, true);

                foreach (IEvent e in Resources.eventsLog)
                {
                    if (e != null && e.ShowInLog() != null)
                    {
                        if (!Resources.showRaidsInLog && e is ABigThreat) { }
                        else if (!Resources.showDeadColonistsInLog && e is AMemorialDay) { }
                        else if (!Resources.showIncidentsInLog && e is IncidentShort) { }
                        else if (!Resources.showCustomTextInLog && e is CustomEvent) { }
                        else
                        {
                            if (e is CustomEvent)
                            {
                                Rect btnRect = new Rect(outter.x + 10, yoff, 20, 20);
                                if (Widgets.ButtonImage(btnRect, texDelete))
                                {
                                    e.EndEvent();
                                }
                            }
                            float height = Text.CalcHeight(e.ShowInLog(), txtWidth);
                            Widgets.Label(new Rect(outter.x + 50, yoff, txtWidth, height), e.ShowInLog());
                            yoff += height + 10;
                        }
                    }
                }

                foreach (IEvent e in Resources.eventsLog.Reverse<IEvent>())
                {
                    if (e is CustomEvent && !e.IsStillEvent())
                    {
                        Resources.eventsLog.Remove(e);
                    }
                }

                Rect txtRect = new Rect(outter.x + 50, yoff + 20, txtWidth, 200);
                listing_Standard.Begin(txtRect);

                if (Resources.eventsLog.Count == 0)
                {
                    listing_Standard.Label("Nothing here yet.");
                }
                listing_Standard.Label("Enter new story:");
                string str = listing_Standard.TextEntry(this.customText, 3);
                if (str.Length < 4000)
                {
                    this.customText = str;
                }
                if (listing_Standard.ButtonText("Save"))
                {
                    if (this.customText != "")
                    {
                        Resources.eventsLog.Add(new CustomEvent(Utils.CurrentDate(), this.customText));
                        this.customText = "";
                    }
                }
                listing_Standard.End();
            }
            Widgets.EndScrollView();

            filterRect = new Rect(new Vector2(outter.width, rect.position.y), new Vector2(200, 200));
            listing_Standard.Begin(filterRect);
            listing_Standard.CheckboxLabeled("ShowRaidsInLog".Translate(), ref Resources.showRaidsInLog);
            listing_Standard.CheckboxLabeled("ShowDeadColonistsInLog".Translate(), ref Resources.showDeadColonistsInLog);
            listing_Standard.CheckboxLabeled("ShowIncidentsInLog".Translate(), ref Resources.showIncidentsInLog);
            listing_Standard.CheckboxLabeled("Show custom events", ref Resources.showCustomTextInLog);
            listing_Standard.End();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }    

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override void Notify_ResolutionChanged()
        {
            base.Notify_ResolutionChanged();
        }

        public override void PostClose()
        {
            base.PostClose();
        }

        public override void PostOpen()
        {
            base.PostOpen();
        }

        public override void PreClose()
        {
            base.PreClose();
        }

        public override void PreOpen()
        {
            base.PreOpen();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override void WindowOnGUI()
        {
            base.WindowOnGUI();
        }

        public override void WindowUpdate()
        {
            base.WindowUpdate();
        }

        protected override void SetInitialSizeAndPosition()
        {
            base.SetInitialSizeAndPosition();
        }

        public void ExposeData()
        {
           // throw new NotImplementedException();
        }
    }
}
