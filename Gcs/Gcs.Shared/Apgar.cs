using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Gcs
{
    public class Apgar
    {
        public int[] Category = new int[5];
        public int[] SelectedCategory = new int[5];

        public string AppearanceString { get { return Appearance[Category[0]]; } }
        public string PulseString { get { return Pulse[Category[1]]; } }
        public string GrimaceString { get { return Grimace[Category[2]]; } }
        public string MuscleActivityString { get { return MuscleActivity[Category[3]]; } }
        public string RespirationString { get { return Respiration[Category[4]]; } }

        public Apgar()
        {
            var random = new Random();

            Category[0] = random.Next(0, 3);
            Category[1] = random.Next(0, 3);
            Category[2] = random.Next(0, 3);
            Category[3] = random.Next(0, 3);
            Category[4] = random.Next(0, 3);

            var bmp = Math.Round(random.NextDouble() * 80.0, 0);

            Pulse = new Dictionary<int, string>
            { 
                {0, "absent"},
                {1,  bmp + " bpm"},
                {2, (100 + bmp) + " bpm"},
            };
        }

        public bool Finished()
        {
            if (SelectedCategory[0] > 0 &&
                SelectedCategory[1] > 0 &&
                SelectedCategory[2] > 0 &&
                SelectedCategory[3] > 0 &&
                SelectedCategory[4] > 0)
            {
                return true;
            }
            return false;
        }

        public int CorrectScore()
        {
            return Category.Sum();
        }
        public int SelectedScore()
        {
            var score = SelectedCategory.Sum();

            return score;
        }


        public bool Correct()
        {
            if (Category[0] == SelectedCategory[0] &&
                Category[1] == SelectedCategory[1] &&
                Category[2] == SelectedCategory[2] &&
                Category[3] == SelectedCategory[3] &&
                Category[4] == SelectedCategory[4])
            {
                return true;
            }
            return false;
        }

        public Dictionary<int, string> Appearance = new Dictionary<int, string>
        { 
            {0, "blue, pale"},
            {1, "pink body, blue extremities"},
            {2, "pink and/or not cyanosed"},
        };

        public Dictionary<int, string> Pulse;

        public Dictionary<int, string> Grimace = new Dictionary<int, string>
        { 
            {0, "no response"},
            {1, "grimace"},
            {2, "cry, cough"},
        };

        public Dictionary<int, string> MuscleActivity = new Dictionary<int, string>
        { 
            {0, "flaccid"},
            {1, "some flexion"},
            {2, "well flexed"},
        };

        public Dictionary<int, string> Respiration = new Dictionary<int, string>
        { 
            {0, "absent"},
            {1, "weak, irregular, gasping"},
            {2, "strong, lusty cry"},
        };
        private double _bmp;
        
    }
}
