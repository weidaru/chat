using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TcpSocket
{
    class HasDisplayDelegate
    {
        protected DisplayDelegate displayDelegate;
        public delegate void DisplayDelegate(String name, String message);
        public void SetDisplayDelegate(DisplayDelegate d)
        {
            displayDelegate = d;
        }

        protected LogDelegate logDelegate;
        public delegate void LogDelegate(String m);
        public void SetLogDelegate(LogDelegate l)
        {
            logDelegate = l;
        }
    }

    class CaesarCoding
    {
        public static byte[] Encrypt(byte[] org)
        {
            byte[] res = org;

            for (int i = 0; i < res.Length; i++)
            {
                if (org[i] >= 65 && org[i] <= 90)
                    org[i] = (byte)((org[i] - 65 + 3) % 26 + 65);
                else if (org[i] >= 97 && org[i] <= 122)
                    org[i] = (byte)((org[i] - 97 + 3) % 26 + 97);
            }

            return res;
        }

        public static byte[] Decrypt(byte[] res)
        {
            byte[] org = res;

            for (int i = 0; i < org.Length; i++)
            {
                if (res[i] >= 65 && res[i] <= 90)
                {
                    if (res[i] < 68)
                        res[i] = (byte)(res[i] - 3 + 26);
                    else
                        res[i] = (byte)(res[i] - 3);
                }
                else if (org[i] >= 97 && org[i] <= 122)
                {
                    if (res[i] < 100)
                        res[i] = (byte)(res[i] - 3 + 26);
                    else
                        res[i] = (byte)(res[i] - 3);
                }
            }

            return org;
        }
    }
}
