using Multiplayer.API;
using RimWorld;
using Verse;


namespace Quarry
{
    [StaticConstructorOnStartup]
    public static class MultiplayerCompat
    {
        public static bool _MP_Enabled;
        
        static MultiplayerCompat()
        {
            if (!MP.enabled)
                return;

            _MP_Enabled = MP.enabled;
            MP.RegisterAll();
        }
        
        public static int PredictableSeed()
        {
            Map map = Find.CurrentMap;
            //int seedHourOfDay = GenLocalDate.HourOfDay(map);
            //int seedDayOfYear = GenLocalDate.DayOfYear(map);
            //int seedYear = GenLocalDate.Year(map);
            int seed = (GenLocalDate.HourOfDay(map) + GenLocalDate.DayOfYear(map)) * GenLocalDate.Year(map);
            //int seed = (seedHourOfDay + seedDayOfYear) * seedYear;
            //Log.Warning("seedHourOfDay: " + seedHourOfDay + "\nseedDayOfYear: " + seedDayOfYear + "\nseedYear: " + seedYear + "\n" + seed);
            return seed;
        }
    }
}