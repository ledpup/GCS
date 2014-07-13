using System;
using System.Collections.Generic;
using System.Text;

namespace Gcs
{
    public class ApgarCategories
    {
        public static Dictionary<int, string> Appearance = new Dictionary<int, string>
        { 
            {0, "blue, pale"},
            {1, "pink body, blue extremities"},
            {2, "pink and/or not cyanosed"},
        };

        public static Dictionary<int, string> Pulse = new Dictionary<int, string>
        { 
            {0, "absent"},
            {1, "< 100 bpm"},
            {2, "> 100 bpm"},
        };

        public static Dictionary<int, string> Grimace = new Dictionary<int, string>
        { 
            {0, "no response"},
            {1, "grimace"},
            {2, "cry, cough"},
        };
        
        public static Dictionary<int, string> MuscleActivity = new Dictionary<int, string>
        { 
            {0, "flaccid"},
            {1, "some flexion"},
            {2, "well flexed"},
        };

        public static Dictionary<int, string> Respiration = new Dictionary<int, string>
        { 
            {0, "absent"},
            {1, "weak, irregular, gasping"},
            {2, "strong, lusty cry"},
        };
    }
}
