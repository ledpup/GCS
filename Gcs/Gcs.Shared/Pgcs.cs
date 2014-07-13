using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Gcs
{
    public class Pgcs
    {
        public int[] Category = new int[3];
        public int[] SelectedCategory = new int[3];

        public string EyesString { get { return PgcsCategories.Eyes[Category[0]]; } }
        public string VerbalString { get { return PgcsCategories.Verbal[Category[1]]; } }
        public string MotorString { get { return PgcsCategories.Motor[Category[2]]; } }

        public Pgcs()
        {
            var random = new Random();
            Category[0] = random.Next(1, 5);
            Category[1] = random.Next(1, 6);
            Category[2] = random.Next(1, 7);
        }

        public bool Finished()
        {
            if (SelectedCategory[0] > 0 &&
                SelectedCategory[1] > 0 &&
                SelectedCategory[2] > 0)
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
            return SelectedCategory.Sum();
        }


        public bool Correct()
        {
            if (Category[0] == SelectedCategory[0] &&
                Category[1] == SelectedCategory[1] &&
                Category[2] == SelectedCategory[2])
            {
                return true;
            }
            return false;
        }
    }
}
