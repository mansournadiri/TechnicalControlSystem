using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Application.Base
{
    public static class BaseValidation
    {
        public static bool ValidationMobileNumber(string? Number)
        {
            try
            {
                if (Number == null) { return false; }
                Number = BaseReplacmentChar.Char_FarsiRemove(Number);
                int count = Convert.ToInt16(Number.Length);
                if (count == 10)
                {
                    Number = Number.Insert(0, "0");
                }
                else if (count == 13)
                {
                    Number = Number.Remove(0, 3);
                    Number = Number.Insert(0, "0");
                }
                string Num;
                bool resualt;
                count = Convert.ToInt16(Number.Length);
                if (count == 11)
                {
                    for (int i = 0; i < 11; i++)
                    {
                        Num = Number.Substring(i, 1);
                        if (i == 0)
                        {
                            resualt = Regex.IsMatch(Num, @"^([0])$");
                            if (resualt == false)
                            {
                                return false;
                            }
                        }
                        else if (i == 1)
                        {
                            resualt = Regex.IsMatch(Num, @"^([9])$");
                            if (resualt == false)
                            {
                                return false;
                            }
                        }
                        else
                        {
                            resualt = System.Text.RegularExpressions.Regex.IsMatch(Num, @"^([0-9])$");
                            if (resualt == false)
                            {
                                return false;
                            }
                        }
                    }
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool ValidationNationalId(string? Number)
        {
            try
            {
                if (Number == null) { return false; }
                Number = BaseReplacmentChar.Char_FarsiRemove(Number);
                Number = BaseReplacmentChar.Char_SpecialRemove(Number);
                int count = Convert.ToInt16(Number.Length);
                if (count < 8)
                {
                    return false;
                }
                else if (count == 8)
                {
                    Number = Number.Insert(0, "00");
                }
                else if (count == 9)
                {
                    Number = Number.Insert(0, "0");
                }

                int sum = 0;
                int Num = 0;
                int location = 10;
                count = Convert.ToInt16(Number.Length);
                if (count == 10)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        Num = Convert.ToInt16(Number.Substring(i, 1));
                        sum += Num * location;
                        location--;
                    }

                    int ModeDiv = sum % 11;  //باقیمانده تقسیم
                    int lastNum = Convert.ToInt16(Number.Substring(count - 1, 1)); // آخرین عدد موجود در کدملی
                    if (ModeDiv < 2)
                    {
                        if (lastNum == ModeDiv)
                            return true;
                        else
                            return false;
                    }
                    else
                    {
                        ModeDiv = 11 - ModeDiv;
                        if (lastNum == ModeDiv)
                            return true;
                        else
                            return false;
                    }
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool ValidationNumber(string? Number)
        {
            if (Number == null) return false;
            Regex regex = new Regex(@"^\d+$");
            if (regex.IsMatch(Number))
            {
                return true;
            }
            return false;
        }
        public static bool ValidationPersianDateFormat(string? Number)
        {
            try
            {
                if (Number == null) { return false; }
                int count = Convert.ToInt16(Number.Length);
                if (count != 10)
                {
                    return false;
                }
                string Num;
                bool resualt;
                count = Convert.ToInt16(Number.Length);
                if (count == 10)
                {
                    for (int i = 0; i < 10; i++)
                    {

                        Num = Number.Substring(i, 1);
                        if (i == 4 || i == 7)
                        {
                            resualt = System.Text.RegularExpressions.Regex.IsMatch(Num, @"^([/,-])$");
                            if (resualt == false)
                            {
                                return false;
                            }
                        }
                        else
                        {
                            resualt = System.Text.RegularExpressions.Regex.IsMatch(Num, @"^([0-9])$");
                            if (resualt == false)
                            {
                                return false;
                            }
                        }
                    }
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool ValidationEmailAddress(string? Number)
        {
            try
            {
                if (!string.IsNullOrEmpty(Number))
                {
                    MailAddress m = new MailAddress(Number);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public static bool ValidationNBankCardFormat(string? Number)
        {
            if (Number != null)
            {
                Number = Number.Replace("-", string.Empty);
                var res = Regex.Match(Number, @"\d{16}");
                if (res.Success)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool ValidationValueNotNull(string? value)
        {
            if (string.IsNullOrEmpty(value)) return false;
            value.Trim();
            value.Replace(" ", string.Empty);
            value.Replace("&zwnj;", " ");
            value.Replace("&nbsp;", " ");
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool ValidationImageFileType(string file_ContentType)
        {
            string FileExtensions = file_ContentType;
            string[] ValidExtensions = { "image/png", "image/jpeg" };
            if (Array.IndexOf(ValidExtensions, FileExtensions) < 0)
            {
                return false;
            }
            return true;
        }
        public static bool ValidationAttachmentFileType(string file_ContentType)
        {
            string FileExtensions = file_ContentType;
            string[] ValidExtensions = { "image/png", "image/jpeg", "image/gif", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "application/msexcel", "application/pdf", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" };
            if (Array.IndexOf(ValidExtensions, FileExtensions) < 0)
            {
                return false;
            }
            return true;
        }
    }
}
