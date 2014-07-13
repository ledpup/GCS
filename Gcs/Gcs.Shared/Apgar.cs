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

        public string AppearanceString { get { return ApgarCategories.Appearance[Category[0]]; } }
        public string PulseString { get { return ApgarCategories.Pulse[Category[1]]; } }
        public string GrimaceString { get { return ApgarCategories.Grimace[Category[2]]; } }
        public string MuscleActivityString { get { return ApgarCategories.MuscleActivity[Category[3]]; } }
        public string RespirationString { get { return ApgarCategories.Respiration[Category[4]]; } }

        public Apgar()
        {
            var random = new Random();

            Category[0] = random.Next(0, 3);
            Category[1] = random.Next(0, 3);
            Category[2] = random.Next(0, 3);
            Category[3] = random.Next(0, 3);
            Category[4] = random.Next(0, 3);
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
    }
}
