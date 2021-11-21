/**
 * This is a string module
 */
// This file is auto-generated, don't edit it. Thanks.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using Tea;
using Tea.Utils;


namespace AlibabaCloud.DarabonbaString
{
    public class StringUtil 
    {

        public static List<string> Split(string raw, string sep, int? limit = null)
        {
            if(raw == null)
            {
                return null;
            }

            if(limit == null)
            {
                return new List<string>(raw.Split(new string[] { sep }, StringSplitOptions.None));
            }

            return new List<string>(raw.Split(new string[] { sep }, limit.Value, StringSplitOptions.None));
            
        }

        public static string Replace(string raw, string oldStr, string newStr, int? index = null)
        {
            if(raw == null)
            {
                return null;
            }

            if(index == null)
            {
                return raw.Replace(oldStr, newStr);
            }

            string result = string.Empty;

            string[] rawSplit = raw.Split(new string[] { oldStr }, StringSplitOptions.None);

            if(rawSplit.Length <= index.Value + 1 )
            {
                return raw;
            }

            List<string> rawList = new List<string>(rawSplit);
            string left = string.Join(oldStr, rawList.GetRange(0, index.Value + 1));
            string right = string.Join(oldStr, rawList.GetRange(index.Value + 1, rawList.Count - index.Value - 1));

            result = left + newStr + right;

            return result;
        }

        public static bool? Contains(string s, string substr)
        {
            if(s == null)
            {
                return false;
            }
            return s.Contains(substr);
        }

        public static int? Count(string s, string substr)
        {
            if(s == null)
            {
                return 0;
            }
            if(string.IsNullOrEmpty(substr))
            {
                return 0;
            }
            string[] rawSplit = s.Split(new string[] { substr }, StringSplitOptions.None);
            return rawSplit.Length - 1;
        }

        public static bool? HasPrefix(string s, string prefix)
        {
            if(s == null)
            {
                return false;
            }
            return s.StartsWith(prefix);
        }

        public static bool? HasSuffix(string s, string substr)
        {
            if (s == null)
            {
                return false;
            }
            return s.EndsWith(substr);
        }

        public static int? Index(string s, string substr)
        {
            if (s == null)
            {
                return -1;
            }
            return s.IndexOf(substr);
        }

        public static string ToLower(string s)
        {
            if (s == null)
            {
                return null;
            }
            return s.ToLower();
        }

        public static string ToUpper(string s)
        {
            if (s == null)
            {
                return null;
            }
            return s.ToUpper();
        }

        public static string SubString(string s, int? start, int? end)
        {
            if (s == null)
            {
                return null;
            }
            if(end.Value >= s.Length)
            {
                return s.Substring(start.Value);
            }

            int length = end.Value - start.Value + 1;
            if(length < 0)
            {
                return string.Empty;
            }
            return s.Substring(start.Value, length);
        }

        public static bool? Equals(string expect, string actual)
        {
            if(expect == null)
            {
                return false;
            }
            return expect.Equals(actual);
        }

    }
}
