﻿using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SharpApi.Helpers.ValueTypeExtensions
{
    public static partial class StringHelpers
    {
        /// <summary>
        /// Gets the matches between delimiters.
        /// </summary>
        /// <param name="input">The source string.</param>
        /// <param name="beginDelim">The beginning string delimiter.</param>
        /// <param name="endDelim">The end string delimiter.</param>
        /// <returns></returns>

        public static IEnumerable<string> ExtractBetween(this string input, string beginDelim, string endDelim)
        {
            if (string.IsNullOrEmpty(input)) return new List<string>();
            var reg = new Regex($"(?<={Regex.Escape(beginDelim)})(.+?)(?={Regex.Escape(endDelim)})");
            var matches = reg.Matches(input);
            return (from Match m in matches select m.Value).ToList();
        }

        /// <summary>
        /// Returns true if the string is a url path
        /// </summary>
        /// <param name="str"></param>
        public static bool IsValidUrl(this string str)
        {
            if (string.IsNullOrEmpty(str)) return false;

            return Regex.Match(str,
                @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?",
                RegexOptions.IgnoreCase).Success;
        }


        /// <summary>
        /// Returns a string from the left side with a fixed length of characters
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length">The number of characters </param>
        public static string Left(this string str, int length)
        {
            if (length == 0 || str.Length == 0) return string.Empty;
            var result = str;
            if (length < str.Length)
            {
                result = str.Substring(0, length);
            }
            return result;
        }

        /// <summary>
        /// Returns a string from the right side with a fixed length of characters
        /// </summary>
        /// <param name="str"></param>
        ///<param name="length">The number of characters </param>
        public static string Right(this string str, int length)
        {
            if (length == 0 || str.Length == 0) return string.Empty;
            var result = str;
            if (length < str.Length)
            {
                result = str[^length..];
            }
            return result;
        }

        public static bool IsNullOrEmpty(this string? s)
        {
            return string.IsNullOrEmpty(s);
        }
    }
}
