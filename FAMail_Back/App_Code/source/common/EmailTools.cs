// Type: Common.EmailTools
// Assembly: Common, Version=1.0.4653.30060, Culture=neutral, PublicKeyToken=null
// MVID: B142D8A0-D9D6-42A2-9558-CA68472CD692
// Assembly location: C:\Program Files (x86)\Live Software Inc\Live Email Verifier\Common.dll

using System.Collections;
using System.Text.RegularExpressions;


    public class EmailTools
    {
        public static Regex regexFindEmail = new Regex("(((\\w|([-]))+([.](\\w|([-]))+)+)|((\\w|([-]))+))@((\\w|([-]))+([.](\\w|([-]))+)+)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static Regex regexEmail = new Regex("^(((\\w|([-]))+([.](\\w|([-]))+)+)|((\\w|([-]))+))@((\\w|([-]))+([.](\\w|([-]))+)+)$", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static Regex regexFindDomain = new Regex("((\\w|([-]))+([.](\\w|([-]))+)+)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static Regex regexDomain = new Regex("^((\\w|([-]))+([.](\\w|([-]))+)+)$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        static EmailTools()
        {
        }

        public static bool ValidateEmail(string source, out string result)
        {
            result = string.Empty;
            ArrayList emails = EmailTools.FindEmails(source);
            if (emails.Count > 0)
            {
                result = (string)emails[0];
                return true;
            }
            else
            {
                string str = EmailTools.CorrectEmail(source);
                if (str == null || str.Length == 0)
                    return false;
                result = str;
                return true;
            }
        }

        public static string CorrectEmail(string email)
        {
            int num1 = 0;
            int num2 = 0;
            int startIndex = 0;
            string str1 = "";
            string str2 = "";
            string str3 = "";
            bool flag1 = false;
            bool flag2 = false;
            email = email.Replace("%20", " ");
            email = email.Replace("%40", "@");
            while (true)
            {
                for (int index = 0; index < email.Length; ++index)
                {
                    char ch1 = email[index];
                    switch (num1)
                    {
                        case 0:
                            if ((int)ch1 > 32 && (int)ch1 != (int)sbyte.MaxValue)
                            {
                                switch (ch1)
                                {
                                    case ':':
                                    case ';':
                                    case '<':
                                    case '>':
                                    case '[':
                                    case '\\':
                                    case ']':
                                    case '!':
                                    case ')':
                                    case ',':
                                        continue;
                                    case '@':
                                        str2 = str2 + str1;
                                        str1 = "";
                                        if (!str2.Equals(""))
                                        {
                                            if ((int)str2[str2.Length - 1] == 46)
                                                str2 = str2.Substring(0, str2.Length - 1);
                                            string str4 = str3 + str2;
                                            str2 = "";
                                            str3 = str4 + "@";
                                            num1 = 5;
                                            continue;
                                        }
                                        else
                                            continue;
                                    case '"':
                                        num1 = 1;
                                        startIndex = index + 1;
                                        continue;
                                    case '(':
                                        if (!flag1)
                                        {
                                            num2 = num1;
                                            num1 = 2;
                                            continue;
                                        }
                                        else
                                            continue;
                                    case '-':
                                        if (!str1.Equals(""))
                                        {
                                            num1 = 3;
                                            startIndex = index;
                                            continue;
                                        }
                                        else
                                            continue;
                                    case '.':
                                        str2 = str2 + str1;
                                        str1 = "";
                                        continue;
                                    default:
                                        num1 = 3;
                                        startIndex = index;
                                        continue;
                                }
                            }
                            else
                                break;
                        case 1:
                            switch (ch1)
                            {
                                case '"':
                                    num1 = 4;
                                    int num3 = index;
                                    str1 = email.Substring(startIndex, num3 - startIndex);
                                    startIndex = index + 1;
                                    continue;
                                case '\\':
                                    ++index;
                                    continue;
                                default:
                                    continue;
                            }
                        case 2:
                            switch (ch1)
                            {
                                case ')':
                                    num1 = num2;
                                    startIndex = index + 1;
                                    continue;
                                case '\\':
                                    ++index;
                                    continue;
                                default:
                                    continue;
                            }
                        case 3:
                            if ((int)ch1 <= 32 || (int)ch1 == (int)sbyte.MaxValue)
                            {
                                num1 = 4;
                                int num4 = index;
                                str1 = str1 + email.Substring(startIndex, num4 - startIndex);
                                startIndex = index + 1;
                                break;
                            }
                            else
                            {
                                char ch2 = ch1;
                                if ((int)ch2 <= 46)
                                {
                                    if ((int)ch2 != 34)
                                    {
                                        switch ((int)ch2 - 40)
                                        {
                                            case 0:
                                                num2 = 4;
                                                num1 = 2;
                                                int num4 = index;
                                                str1 = str1 + email.Substring(startIndex, num4 - startIndex);
                                                continue;
                                            case 1:
                                            case 4:
                                                break;
                                            case 6:
                                                num1 = 0;
                                                int num5 = index + 1;
                                                str1 = str1 + email.Substring(startIndex, num5 - startIndex);
                                                startIndex = index + 1;
                                                continue;
                                            default:
                                                continue;
                                        }
                                    }
                                }
                                else
                                {
                                    switch (ch2)
                                    {
                                        case ':':
                                            num1 = 0;
                                            str1 = "";
                                            startIndex = index + 1;
                                            continue;
                                        case ';':
                                        case '>':
                                        case '[':
                                        case '\\':
                                        case ']':
                                            break;
                                        case '<':
                                            num1 = 6;
                                            int num6 = index;
                                            str2 = str2 + email.Substring(startIndex, num6 - startIndex);
                                            startIndex = index + 1;
                                            continue;
                                        case '@':
                                            num1 = 5;
                                            int num7 = index + 1;
                                            str3 = str1 + email.Substring(startIndex, num7 - startIndex);
                                            str1 = "";
                                            startIndex = index + 1;
                                            continue;
                                        default:
                                            continue;
                                    }
                                }
                                num1 = 4;
                                int num8 = index;
                                str1 = str1 + email.Substring(startIndex, num8 - startIndex);
                                startIndex = index + 1;
                                break;
                            }
                        case 4:
                            if ((int)ch1 > 32 && (int)ch1 != (int)sbyte.MaxValue)
                            {
                                switch (ch1)
                                {
                                    case ':':
                                    case ';':
                                    case '>':
                                    case '[':
                                    case '\\':
                                    case ']':
                                    case ')':
                                    case ',':
                                        continue;
                                    case '<':
                                        num1 = 6;
                                        str2 = str2 + str1;
                                        str1 = "";
                                        continue;
                                    case '@':
                                        num1 = 5;
                                        string str5 = str3 + str1;
                                        str1 = "";
                                        str3 = str5 + "@";
                                        continue;
                                    case '"':
                                        num1 = 1;
                                        str2 = str2 + str1;
                                        str1 = "";
                                        startIndex = index + 1;
                                        continue;
                                    case '(':
                                        num2 = num1;
                                        num1 = 2;
                                        continue;
                                    case '.':
                                        num1 = 0;
                                        str1 = str1 + ".";
                                        continue;
                                    default:
                                        num1 = 3;
                                        str2 = str2 + str1;
                                        str1 = "";
                                        startIndex = index;
                                        continue;
                                }
                            }
                            else
                                break;
                        case 5:
                            if ((int)ch1 > 32 && (int)ch1 != (int)sbyte.MaxValue)
                            {
                                switch (ch1)
                                {
                                    case ':':
                                    case ';':
                                    case '<':
                                    case '>':
                                    case '@':
                                    case '[':
                                    case '\\':
                                    case ']':
                                    case '"':
                                    case ')':
                                    case ',':
                                    case '.':
                                        continue;
                                    case '(':
                                        num2 = num1;
                                        num1 = 2;
                                        continue;
                                    default:
                                        num1 = 7;
                                        startIndex = index;
                                        continue;
                                }
                            }
                            else
                                break;
                        case 6:
                            if ((int)ch1 > 32 && (int)ch1 != (int)sbyte.MaxValue)
                            {
                                switch (ch1)
                                {
                                    case ':':
                                    case ';':
                                    case '<':
                                    case '>':
                                    case '[':
                                    case '\\':
                                    case ']':
                                    case '"':
                                    case ')':
                                    case ',':
                                    case '.':
                                    case '/':
                                        continue;
                                    case '@':
                                        num1 = 10;
                                        continue;
                                    case '(':
                                        num2 = num1;
                                        num1 = 2;
                                        continue;
                                    default:
                                        num1 = 9;
                                        startIndex = index;
                                        continue;
                                }
                            }
                            else
                                break;
                        case 7:
                            if ((int)ch1 <= 32 || (int)ch1 == (int)sbyte.MaxValue)
                            {
                                num1 = 14;
                                int num4 = index;
                                str3 = str3 + email.Substring(startIndex, num4 - startIndex);
                                startIndex = index + 1;
                                break;
                            }
                            else
                            {
                                char ch2 = ch1;
                                if ((int)ch2 <= 46)
                                {
                                    if ((int)ch2 != 34)
                                    {
                                        switch ((int)ch2 - 40)
                                        {
                                            case 0:
                                                num2 = 14;
                                                num1 = 2;
                                                int num4 = index;
                                                str3 = str3 + email.Substring(startIndex, num4 - startIndex);
                                                continue;
                                            case 1:
                                            case 4:
                                                break;
                                            case 6:
                                                num1 = 14;
                                                int num5 = index;
                                                str3 = str3 + email.Substring(startIndex, num5 - startIndex);
                                                startIndex = index + 1;
                                                str1 = ".";
                                                continue;
                                            default:
                                                continue;
                                        }
                                    }
                                }
                                else
                                {
                                    switch (ch2)
                                    {
                                        case ':':
                                        case ';':
                                        case '<':
                                        case '>':
                                        case '@':
                                        case '\\':
                                            break;
                                        default:
                                            continue;
                                    }
                                }
                                int num6 = index;
                                str3 = str3 + email.Substring(startIndex, num6 - startIndex);
                                startIndex = index + 1;
                                goto label_110;
                            }
                        case 8:
                            switch (ch1)
                            {
                                case '"':
                                    num1 = 11;
                                    int num9 = index;
                                    str3 = str3 + email.Substring(startIndex, num9 - startIndex);
                                    startIndex = index + 1;
                                    continue;
                                case '\\':
                                    ++index;
                                    continue;
                                default:
                                    continue;
                            }
                        case 9:
                            if ((int)ch1 <= 32 || (int)ch1 == (int)sbyte.MaxValue)
                            {
                                num1 = 11;
                                int num4 = index;
                                str3 = str3 + email.Substring(startIndex, num4 - startIndex);
                                startIndex = index + 1;
                                break;
                            }
                            else
                            {
                                char ch2 = ch1;
                                if ((int)ch2 <= 47)
                                {
                                    if ((int)ch2 != 34)
                                    {
                                        switch ((int)ch2 - 40)
                                        {
                                            case 0:
                                                num2 = 11;
                                                num1 = 2;
                                                int num4 = index;
                                                str3 = str3 + email.Substring(startIndex, num4 - startIndex);
                                                continue;
                                            case 1:
                                            case 4:
                                                break;
                                            case 6:
                                                num1 = 6;
                                                int num5 = index + 1;
                                                str3 = str3 + email.Substring(startIndex, num5 - startIndex);
                                                startIndex = index + 1;
                                                continue;
                                            case 7:
                                                goto label_85;
                                            default:
                                                continue;
                                        }
                                    }
                                }
                                else
                                {
                                    switch (ch2)
                                    {
                                        case ':':
                                        case '<':
                                            goto label_85;
                                        case ';':
                                        case '>':
                                        case '[':
                                        case '\\':
                                        case ']':
                                            break;
                                        case '@':
                                            num1 = 12;
                                            int num6 = index + 1;
                                            str3 = str3 + email.Substring(startIndex, num6 - startIndex);
                                            startIndex = index + 1;
                                            continue;
                                        default:
                                            continue;
                                    }
                                }
                                num1 = 11;
                                int num7 = index;
                                str3 = str3 + email.Substring(startIndex, num7 - startIndex);
                                startIndex = index + 1;
                                break;
                            label_85:
                                num1 = 6;
                                str3 = "";
                                startIndex = index + 1;
                                break;
                            }
                        case 10:
                            if ((int)ch1 == 58)
                            {
                                num1 = 6;
                                break;
                            }
                            else
                                break;
                        case 11:
                            if ((int)ch1 > 32 && (int)ch1 != (int)sbyte.MaxValue)
                            {
                                switch (ch1)
                                {
                                    case '<':
                                        num1 = 6;
                                        str3 = "";
                                        startIndex = index + 1;
                                        continue;
                                    case '@':
                                        num1 = 12;
                                        str3 = str3 + "@";
                                        continue;
                                    case '(':
                                        num2 = num1;
                                        num1 = 2;
                                        continue;
                                    case '.':
                                        num1 = 6;
                                        str3 = str3 + "@";
                                        continue;
                                    default:
                                        continue;
                                }
                            }
                            else
                                break;
                        case 12:
                            if ((int)ch1 > 32 && (int)ch1 != (int)sbyte.MaxValue)
                            {
                                switch (ch1)
                                {
                                    case ':':
                                    case ';':
                                    case '<':
                                    case '>':
                                    case '@':
                                    case '[':
                                    case '\\':
                                    case ']':
                                    case '"':
                                    case '#':
                                    case ')':
                                    case ',':
                                    case '.':
                                        continue;
                                    case '(':
                                        num2 = num1;
                                        num1 = 2;
                                        continue;
                                    default:
                                        num1 = 13;
                                        startIndex = index;
                                        continue;
                                }
                            }
                            else
                                break;
                        case 13:
                            if ((int)ch1 < 32 || (int)ch1 == (int)sbyte.MaxValue)
                            {
                                num1 = 15;
                                int num4 = index;
                                str3 = str3 + email.Substring(startIndex, num4 - startIndex);
                                startIndex = index + 1;
                                break;
                            }
                            else
                            {
                                char ch2 = ch1;
                                if ((int)ch2 <= 44)
                                {
                                    switch ((int)ch2 - 32)
                                    {
                                        case 0:
                                            int num4 = index;
                                            str3 = str3 + email.Substring(startIndex, num4 - startIndex);
                                            startIndex = index + 1;
                                            continue;
                                        case 2:
                                        case 9:
                                        case 12:
                                            break;
                                        case 8:
                                            num2 = 15;
                                            num1 = 2;
                                            int num5 = index;
                                            str3 = str3 + email.Substring(startIndex, num5 - startIndex);
                                            startIndex = index + 1;
                                            continue;
                                        default:
                                            continue;
                                    }
                                }
                                else
                                {
                                    switch (ch2)
                                    {
                                        case '/':
                                        case ':':
                                        case ';':
                                        case '<':
                                        case '>':
                                        case '@':
                                        case '\\':
                                            break;
                                        default:
                                            continue;
                                    }
                                }
                                int num6 = index;
                                str3 = str3 + email.Substring(startIndex, num6 - startIndex);
                                goto label_110;
                            }
                        case 14:
                            if ((int)ch1 > 32 && (int)ch1 != (int)sbyte.MaxValue)
                            {
                                switch (ch1)
                                {
                                    case '(':
                                        num2 = num1;
                                        num1 = 2;
                                        continue;
                                    case '.':
                                        if (!str1.Equals("."))
                                        {
                                            num1 = 5;
                                            str3 = str3 + ".";
                                            startIndex = index + 1;
                                            continue;
                                        }
                                        else
                                            goto label_110;
                                    default:
                                        if (str1.Equals("."))
                                        {
                                            num1 = 7;
                                            str3 = str3 + ".";
                                            str1 = "";
                                            startIndex = index;
                                            continue;
                                        }
                                        else
                                            goto label_110;
                                }
                            }
                            else
                                break;
                        case 15:
                            if ((int)ch1 > 32 && (int)ch1 != (int)sbyte.MaxValue)
                            {
                                switch (ch1)
                                {
                                    case '(':
                                        num2 = num1;
                                        num1 = 2;
                                        continue;
                                    case '.':
                                        num1 = 12;
                                        str3 = str3 + ".";
                                        startIndex = index + 1;
                                        continue;
                                    default:
                                        continue;
                                }
                            }
                            else
                                break;
                    }
                }
                switch (num1)
                {
                    case 4:
                        str2 = str2 + str1;
                        break;
                    case 7:
                        str3 = str3 + email.Substring(startIndex);
                        break;
                }
            label_110:
                if (str3.Equals("") && !flag1)
                {
                    flag1 = true;
                    num1 = 0;
                    str2 = "";
                    str1 = "";
                }
                else
                {
                    if (str3.IndexOf('@') == -1)
                        str3 = str3.Replace("_at_", "@");
                    if ((str3.IndexOf('@') == -1 || str3.LastIndexOf('.') < str3.IndexOf('@')) && !flag2)
                    {
                        flag2 = true;
                        email = string.Copy(str2);
                        str2 = string.Copy(str3);
                        str3 = "";
                        num1 = 0;
                        str1 = "";
                    }
                    else
                        break;
                }
            }
            while (str3.IndexOf('@') != -1 && str3.LastIndexOf('.') >= str3.IndexOf('@'))
            {
                if (str3.LastIndexOf('.') == str3.Length)
                {
                    str3 = str3.Substring(0, str3.Length - 1);
                }
                else
                {
                    string str4 = str3.Substring(str3.LastIndexOf('.') + 1);
                    str3 = str3.Substring(0, str3.LastIndexOf('.'));
                    if (str4.Length >= 2)
                    {
                        if (str4.Length != 2)
                        {
                            if (str4.ToLower().StartsWith("com"))
                                str4 = str4.Substring(0, 3);
                            else if (str4.ToLower().StartsWith("net"))
                                str4 = str4.Substring(0, 3);
                            else if (str4.ToLower().StartsWith("org"))
                                str4 = str4.Substring(0, 3);
                            else if (str4.ToLower().StartsWith("edu"))
                                str4 = str4.Substring(0, 3);
                            else if (str4.ToLower().StartsWith("biz"))
                                str4 = str4.Substring(0, 3);
                            else if (str4.ToLower().StartsWith("info"))
                                str4 = str4.Substring(0, 4);
                            else if (str4.ToLower().StartsWith("name"))
                                str4 = str4.Substring(0, 4);
                            else if (str4.ToLower().StartsWith("mil"))
                                str4 = str4.Substring(0, 3);
                            else if (str4.ToLower().StartsWith("gov"))
                                str4 = str4.Substring(0, 3);
                            else if (str4.ToLower().StartsWith("int"))
                                str4 = str4.Substring(0, 3);
                            else if (str4.ToLower().StartsWith("aero"))
                                str4 = str4.Substring(0, 4);
                            else if (str4.ToLower().StartsWith("coop"))
                                str4 = str4.Substring(0, 4);
                            else if (str4.ToLower().StartsWith("museum"))
                                str4 = str4.Substring(0, 6);
                            else if (str4.ToLower().StartsWith("pro"))
                                str4 = str4.Substring(0, 3);
                            else if (str4.ToLower().StartsWith("arpa"))
                                str4 = str4.Substring(0, 4);
                            else if (str4.ToLower().StartsWith("nato"))
                                str4 = str4.Substring(0, 4);
                            else
                                continue;
                        }
                        string str5 = str3 + "." + str4;
                        if (str2.Equals(""))
                            return str5;
                        return "\"" + str2 + "\" <" + str5 + ">";
                    }
                }
            }
            return "";
        }

        public static ArrayList FindEmails(string source)
        {
            ArrayList arrayList = new ArrayList();
            for (Match match = EmailTools.regexFindEmail.Match(source); match.Success; match = match.NextMatch())
                arrayList.Add((object)match.Groups[0].Captures[0].Value);
            return arrayList;
        }

        public static bool IsEmail(string email)
        {
            return EmailTools.regexEmail.Match(email).Success;
        }

        public static string GetDomain(string email)
        {
            string[] strArray = email.Split(new char[2]
      {
        '@',
        '>'
      });
            if (strArray.Length > 1)
                return strArray[1];
            else
                return "";
        }

        public static string GetEmail(string recipient)
        {
            string[] strArray = recipient.Split(new char[2]
      {
        '<',
        '>'
      });
            if (strArray.Length > 1)
                return strArray[1];
            ArrayList emails = EmailTools.FindEmails(recipient);
            if (emails.Count > 1)
                return (string)emails[0];
            else
                return string.Empty;
        }

        public static ArrayList FindDomains(string source)
        {
            ArrayList arrayList = new ArrayList();
            for (Match match = EmailTools.regexFindDomain.Match(source); match.Success; match = match.NextMatch())
                arrayList.Add((object)match.Groups[0].Captures[0].Value);
            return arrayList;
        }

        public static bool IsDomain(string source)
        {
            return EmailTools.regexDomain.Match(source).Success;
        }
    }

