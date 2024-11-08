using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Base
{
    public static class BaseReplacmentChar
    {
        public static string Char_ThousandRemove(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return "0";
            }
            return input.Replace(@",", "");
        }
        public static string Char_FarsiRemove(string input)
        {
            if (input == null)
            {
                return string.Empty;
            }
            input = input.Replace(@"۰", "0");
            input = input.Replace(@"۱", "1");
            input = input.Replace(@"۲", "2");
            input = input.Replace(@"۳", "3");
            input = input.Replace(@"۴", "4");
            input = input.Replace(@"۵", "5");
            input = input.Replace(@"۶", "6");
            input = input.Replace(@"۷", "7");
            input = input.Replace(@"۸", "8");
            input = input.Replace(@"۹", "9");
            return input;
        }
        public static string Char_SpecialRemove(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                input = SanitizeString(input, ' ');
                input = input.Replace("&zwnj;", " ");
                input = input.Replace("&nbsp;", " ");
                input = input.Replace("-", "");
                input = input.Replace("/", "");
            }
            return input;
        }
        public static string Url_Format(string title)
        {
            if (!string.IsNullOrEmpty(title))
            {
                title = title.Replace(".", " ");
                title = title.Replace("+", " ");
                title = title.Replace("#", " ");
                title = title.Replace("&", " ");
                title = title.Replace("*", " ");
                title = title.Replace("_", " ");
                title = title.Replace("/", " ");
                title = title.Replace("  ", " ");
                title = title.Replace("  ", " ");
                title = title.Replace(" ", "-");
                return title;
            }
            return title;
        }
        public static string SanitizeString(string fileName, char replacementChar)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                var blackList = new HashSet<char>(System.IO.Path.GetInvalidFileNameChars());
                blackList.Add('\'');
                var output = fileName.ToCharArray();
                for (int i = 0, ln = output.Length; i < ln; i++)
                {
                    if (blackList.Contains(output[i]))
                    {
                        output[i] = replacementChar;
                    }
                }
                return new String(output);
            }
            return fileName;
        }
        public static string Mobile_Format_IR(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            input = Char_FarsiRemove(input);
            int count = input.Length;
            if (BaseValidation.ValidationMobileNumber(input))
            {
                if (count == 11)
                {
                    input = input.Remove(0, 1);
                    input = "+98" + input;
                    return input;
                }
                else if (count == 13)
                {
                    return input;
                }
                else
                {
                    input = "+98" + input;
                    return input;
                }
            }
            return string.Empty;
        }
        public static string Mobile_Format_IRZero(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            input = Char_FarsiRemove(input);
            int count = input.Length;
            if (BaseValidation.ValidationMobileNumber(input))
            {
                if (count == 11)
                {
                    return input;
                }
                else if (count == 13)
                {
                    input = input.Remove(0, 3);
                    input = "0" + input;
                    return input;
                }
                else
                {
                    input = "0" + input;
                    return input;
                }
            }
            return string.Empty;
        }
        public static string CodeMeli_Format(string input)
        {
            if (!BaseValidation.ValidationNationalId(input)) return string.Empty;
            input = Char_FarsiRemove(input);
            input = Char_SpecialRemove(input);
            int count = Convert.ToInt16(input.Length);
            if (count == 8)
            {
                input = input.Insert(0, "00");
            }
            else if (count == 9)
            {
                input = input.Insert(0, "0");
            }
            return input;
        }
        public static string HtmlToPlainText(string html)
        {
            if (string.IsNullOrEmpty(html)) return html;
            const string tagWhiteSpace = @"(>|$)(\W|\n|\r)+<";//matches one or more (white space or line breaks) between '>' and '<'
            const string stripFormatting = @"<[^>]*(>|$)";//match any character between '<' and '>', even when end tag is missing
            const string lineBreak = @"<(br|BR)\s{0,1}\/{0,1}>";//matches: <br>,<br/>,<br />,<BR>,<BR/>,<BR />
            var lineBreakRegex = new Regex(lineBreak, RegexOptions.Multiline);
            var stripFormattingRegex = new Regex(stripFormatting, RegexOptions.Multiline);
            var tagWhiteSpaceRegex = new Regex(tagWhiteSpace, RegexOptions.Multiline);

            var text = html;
            //Decode html specific characters
            text = System.Net.WebUtility.HtmlDecode(text);
            //Remove tag whitespace/line breaks
            text = tagWhiteSpaceRegex.Replace(text, "><");
            //Replace <br /> with line breaks
            text = lineBreakRegex.Replace(text, Environment.NewLine);
            //Strip formatting
            text = stripFormattingRegex.Replace(text, string.Empty);

            return text;
        }
        public static string TextCrop(string str, int countCharacter)
        {
            string resualt = string.Empty;
            if (str != null && str.Length > countCharacter)
            {
                resualt = str.Substring(0, countCharacter);
                resualt += " ...";
            }
            return resualt;
        }
        public static string Currency_Format(string data, bool Rial, bool toman)
        {
            try
            {
                if (string.IsNullOrEmpty(data))
                {
                    data = "0";
                    data = (Rial == true) ? data + " ریال" : data;
                    data = (toman) ? data + " تومان" : data;
                    return data;
                }
                string Data = string.Format("{0:N0}", Int64.Parse(data.Replace(",", "")));
                Data = (Rial == true) ? Data + " ریال" : Data;
                Data = (toman) ? Data + " تومان" : Data;
                return Data;
            }
            catch (Exception) { }
            return data;
        }
        public static string Rounded_Number(decimal number)
        {
            if (number >= 0 && number <= 100)
            {
                number = Math.Round(number);
            }
            else if (number > 100 && number <= 10000)
            {
                number = Math.Round(number / 100) * 100;
            }
            else if (number > 10000)
            {
                number = Math.Round(number / 1000) * 1000;
            }
            return number.ToString();
        }
    }
}
