using System;
using System.Collections.Generic;
using System.Linq;

namespace Password_Protection
{
    public class Encryption
    {
        public string encryptData(string data)
        {
            string encryptString = null;
            List<string> newEbcryptList = new List<string>();
            char[] charEncrypList = data.ToLower().ToCharArray();
            foreach (var chr in charEncrypList)
            {
                switch (chr)
                {
                    case 'a':
                        newEbcryptList.Add("352");
                        break;
                    case 'b':
                        newEbcryptList.Add("798");
                        break;
                    case 'c':
                        newEbcryptList.Add("138");
                        break;
                    case 'd':
                        newEbcryptList.Add("774");
                        break;
                    case 'e':
                        newEbcryptList.Add("326");
                        break;
                    case 'f':
                        newEbcryptList.Add("621");
                        break;
                    case 'g':
                        newEbcryptList.Add("136");
                        break;
                    case 'h':
                        newEbcryptList.Add("721");
                        break;
                    case 'i':
                        newEbcryptList.Add("879");
                        break;
                    case 'ı':
                        newEbcryptList.Add("879");
                        break;
                    case 'j':
                        newEbcryptList.Add("731");
                        break;
                    case 'k':
                        newEbcryptList.Add("838");
                        break;
                    case 'l':
                        newEbcryptList.Add("537");
                        break;
                    case 'm':
                        newEbcryptList.Add("264");
                        break;
                    case 'n':
                        newEbcryptList.Add("213");
                        break;
                    case 'o':
                        newEbcryptList.Add("907");
                        break;
                    case 'p':
                        newEbcryptList.Add("809");
                        break;
                    case 'q':
                        newEbcryptList.Add("647");
                        break;
                    case 'r':
                        newEbcryptList.Add("397");
                        break;
                    case 's':
                        newEbcryptList.Add("823");
                        break;
                    case 't':
                        newEbcryptList.Add("134");
                        break;
                    case 'u':
                        newEbcryptList.Add("674");
                        break;
                    case 'v':
                        newEbcryptList.Add("426");
                        break;
                    case 'w':
                        newEbcryptList.Add("988");
                        break;
                    case 'x':
                        newEbcryptList.Add("614");
                        break;
                    case 'y':
                        newEbcryptList.Add("178");
                        break;
                    case 'z':
                        newEbcryptList.Add("154");
                        break;
                    default:
                        Console.WriteLine($"Error:encrypt ");
                        break;
                }
            }
            
            foreach (string str in newEbcryptList)
            {
                if (encryptString == null)
                {
                    encryptString = str;
                }
                else
                {
                    encryptString += str;
                }
            }
            return encryptString;
        }

        public string decodeData(string data)
        {
            int control = 0;
            string tmp = null;
            string decodeString = null;
            char[] charDecodeList = data.ToLower().ToCharArray();
            List<char> newDecodeCharList = new List<char>();
            foreach (var chr in charDecodeList)
            {
                if (control == 0)
                {
                    tmp = null;
                }
                if (control < 2)
                {
                    tmp += chr;
                    control++;
                }
               else if (control == 2)
                {
                    tmp += chr;
                    control = 0;
                }
                
                switch (tmp)
                {
                    case "352":
                        newDecodeCharList.Add('a');
                        break;
                    case "798":
                        newDecodeCharList.Add('b');
                        break;
                    case "138":
                        newDecodeCharList.Add('c');
                        break;
                    case "774":
                        newDecodeCharList.Add('d');
                        break;
                    case "326":
                        newDecodeCharList.Add('e');
                        break;
                    case "621":
                        newDecodeCharList.Add('f');
                        break;
                    case "136":
                        newDecodeCharList.Add('g');
                        break;
                    case "721":
                        newDecodeCharList.Add('h');
                        break;
                    case "879":
                        newDecodeCharList.Add('i');
                        break;
                    case "731":
                        newDecodeCharList.Add('j');
                        break;
                    case "838":
                        newDecodeCharList.Add('k');
                        break;
                    case "537":
                        newDecodeCharList.Add('l');
                        break;
                    case "264":
                        newDecodeCharList.Add('m');
                        break;
                    case "213":
                        newDecodeCharList.Add('n');
                        break;
                    case "907":
                        newDecodeCharList.Add('o');
                        break;
                    case "809":
                        newDecodeCharList.Add('p');
                        break;
                    case "647":
                        newDecodeCharList.Add('q');
                        break;
                    case "397":
                        newDecodeCharList.Add('r');
                        break;
                    case "823":
                        newDecodeCharList.Add('s');
                        break;
                    case "134":
                        newDecodeCharList.Add('t');
                        break;
                    case "674":
                        newDecodeCharList.Add('u');
                        break;
                    case "426":
                        newDecodeCharList.Add('v');
                        break;
                    case "988":
                        newDecodeCharList.Add('w');
                        break;
                    case "614":
                        newDecodeCharList.Add('x');
                        break;
                    case "178":
                        newDecodeCharList.Add('y');
                        break;
                    case "154":
                        newDecodeCharList.Add('z');
                        break;
                }
            }

            foreach (var str in newDecodeCharList)
            {
                decodeString += str;
            }
            return decodeString;
        }
    }
}