﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dial
{
    public static class Translator
    {
        public static string? ToNumber(string raw)
        {
            if(string.IsNullOrEmpty(raw)) return null;

            raw = raw.ToUpperInvariant();

            var newNumber = new StringBuilder();
            foreach(var c in raw)
            {
                if(" -0123456789".Contains(c)) newNumber.Append(c);
                else
                {
                    var result = TranslateToNumber(c);
                    if (result != null) newNumber.Append(result);
                    else return null;
                }
            }
            return newNumber.ToString();
        }

        static bool Contains(this string keyString, char c) => keyString.IndexOf(c) >= 0;

        static readonly string[] digits =
        {
            "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"
        };

        static int? TranslateToNumber(char c)
        {
            for(int i = 0; i < digits.Length; i++)
            {
                if (digits[i].Contains(c)) return 2 + i;
            }
            return null;
        }
    }
}
