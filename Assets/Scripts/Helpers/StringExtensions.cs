using UnityEngine;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

public static class StringExtensions {
 
        public static string[] SplitLines(this string text)
        {
                return text.Split(new string[] {"\r\n","\n"}, StringSplitOptions.None);
        }
        public static T? ParseEnum<T>(this string enumString) where T : struct
        {
                if (Enum.IsDefined(typeof(T), enumString))
                        return (T)Enum.Parse(typeof(T), enumString);
                return new T?();
        }
        public static string RemoveMultipleWhitespaces(this string text)
        {
                return Regex.Replace(text,"\\s\\s+"," ");
        }
        /// <summary>
        /// Join a list of strings with a separator
        /// From BReusable
        /// </summary>
        /// <param name="l"></param>
        /// <param name="seperator"></param>
        /// <returns></returns>
        public static string DelimitLarge(this IEnumerable<string> l, string separator)
        {
                var counter = 0;
        
                var result = new StringBuilder();
                foreach (var item in l)
                {
                        if (counter != 0) result.Append(separator);
                        result.Append(item);
                        counter++;
                }
                return result.ToString();
        }
 
public static string BeforeOrSelf(this string text, string delimiter)
        {
                if(text.Contains(delimiter)==false)
                        return text;
                return text.Before(delimiter);
        }
        public static string AfterLast(this string text, string delimiter)
        {
                return text.Substring(text.LastIndexOf(delimiter)+delimiter.Length);
        }
        public static string AfterLastOrSelf(this string text, string delimiter)
        {
                if(text.Contains(delimiter)==false)
                return text;
                return text.AfterLast(delimiter);
        }
        public static string Before(this string text, string delimiter)
        {
                return text.Substring(0,text.IndexOf(delimiter));
        }
        
        public static string AfterOrSelf(this string text, string delimiter)
        {
                if(text.Contains(delimiter)==false)
                return text;
                return text.After(delimiter);
        }
        
        // Write custom extension methods here. They will be available to all queries.
        public static bool IsNullOrEmpty(this string s)
        {
                return string.IsNullOrEmpty(s);
        }
        public static bool HasValue(this string s)
        {
                return !s.IsNullOrEmpty();
        }
        public static string After(this string text, string delimiter)
        {
                return text.Substring( text.IndexOf(delimiter)+delimiter.Length);
        }
        public static int StrComp(this string str1, string str2, bool ignoreCase)
        {
                return string.Compare(str1, str2, ignoreCase);
        }
        public static bool IsIgnoreCaseMatch(this string s, string comparisonText)
    {
        return s.StrComp(comparisonText, true) == 0;
    }
 
}
