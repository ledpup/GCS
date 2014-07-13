using System;
using System.Collections.Generic;
using System.Text;

namespace Gcs
{
    public class GcsCategories
    {
        public static Dictionary<int, string> Eyes = new Dictionary<int, string>
        { 
            {1, "do not open"},
            {2, "open to pain"},
            {3, "open to voice"},
            {4, "open spontaneously"},
        };

        public static Dictionary<int, string> Verbal = new Dictionary<int, string>
        { 
            {1, "no sound"},
            {2, "incomprehensible sounds"},
            {3, "inappropriate words"},
            {4, "confused"},
            {5, "oriented"},
        };

        public static Dictionary<int, string> Motor = new Dictionary<int, string>
        { 
            {1, "no movement"},
            {2, "extension to pain"},
            {3, "flexion to pain"},
            {4, "withdrawal from pain"},
            {5, "localises pain"},
            {6, "obeys commands"},
        };
    }
}
