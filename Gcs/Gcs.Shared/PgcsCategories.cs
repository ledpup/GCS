using System;
using System.Collections.Generic;
using System.Text;

namespace Gcs
{
    public class PgcsCategories
    {
        public static Dictionary<int, string> Eyes = new Dictionary<int, string>
        { 
            {1, "do not open"},
            {2, "open to pain"},
            {3, "open to speech"},
            {4, "open spontaneously"},
        };

        //public static Dictionary<int, string> Verbal = new Dictionary<int, string>
        //{ 
        //    {1, "no sound"},
        //    {2, "inconsolable, agitated"},
        //    {3, "inconsistently inconsolable, moaning"},
        //    {4, "cries but consolable, inappropriate interactions"},
        //    {5, "smiles, oriented to sounds, follows objects, interacts"},
        //};

        public static Dictionary<int, string> Verbal = new Dictionary<int, string>
        { 
            {1, "no sound"},
            {2, "moans and grunts"},
            {3, "cries to pain"},
            {4, "irritable, cries"},
            {5, "babbles, follows objects"},
        };

        public static Dictionary<int, string> Motor = new Dictionary<int, string>
        { 
            {1, "no movement"},
            {2, "extension to pain"},
            {3, "flexion to pain"},
            {4, "withdrawal from pain"},
            {5, "localises pain"},
            {6, "spontaneous"},
        };

        //public static Dictionary<int, string> Motor = new Dictionary<int, string>
        //{ 
        //    {1, "no movement"},
        //    {2, "extension to pain"},
        //    {3, "flexion to pain"},
        //    {4, "withdrawal from pain"},
        //    {5, "withdraws from touch"},
        //    {6, "moves spontaneously or purposefully"},
        //};
    }
}
