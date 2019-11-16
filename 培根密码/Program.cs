using System;
using System.Collections;
using System.Linq;

namespace 培根密码
{
    /// <summary>
    /// 作者：Juston
    /// 日期：20191115
    /// 简介：该程序简单实现了培根密码的加密与解密
    /// </summary>
    class Program
    {
        //存储明文所对应的密文
        private static Hashtable table;
        static void Main(string[] args)
        {
            init();

            Console.WriteLine("***************培根密码**************\n");
            Console.WriteLine("1.加密\t2.解密\t按其他键退出\n");

            char readInfo = Console.ReadKey().KeyChar;
            Console.Clear();
            if (readInfo == '1')
            {
                Console.Write("Text:");
                String str = Console.ReadLine();
                Console.WriteLine("text = {0}\npwd = {1}", str, encryptPwd(str));
                Console.ReadLine();
            }
            else if (readInfo == '2')
            {
                //good GoOd STuDy day DAy Up hAHa
                Console.Write("Pwd:");
                String pwd = Console.ReadLine();
                Console.WriteLine("text = {0}\npwd = {1}", deencryptPwd(pwd), pwd);
                Console.ReadLine();
            }
            else
                return;
        }

        /// <summary>
        /// 初始化明文所对应的密文
        /// </summary>
        static void init()
        {
            table = new Hashtable();
            table.Add('a', "aaaaa");
            table.Add('b', "aaaab");
            table.Add('c', "aaaba");
            table.Add('d', "aaabb");
            table.Add('e', "aabaa");
            table.Add('f', "aabab");
            table.Add('g', "aabba");
            table.Add('h', "aabbb");
            table.Add('i', "abaaa");
            table.Add('j', "abaaa");
            table.Add('k', "ababa");
            table.Add('l', "ababb");
            table.Add('m', "abbaa");
            table.Add('n', "abbab");
            table.Add('o', "abbba");
            table.Add('p', "abbbb");
            table.Add('q', "baaaa");
            table.Add('r', "baaab");
            table.Add('s', "baaba");
            table.Add('t', "baabb");
            table.Add('u', "babaa");
            table.Add('v', "babab");
            table.Add('w', "babba");
            table.Add('x', "babbb");
            table.Add('y', "bbaaa");
            table.Add('z', "bbaab");
        }
        /// <summary>
        /// 培根加密
        /// </summary>
        /// <param name="str">明文</param>
        /// <returns>密文</returns>
        static String encryptPwd(String str)
        {
            //去除空格
            str = str.Replace(" ", string.Empty);
            String pwd = string.Empty;
            char[] arr = str.ToArray();

            //检查输入
            for (int j = 0; j < arr.Length; j++)
            {
                if (!isLetter(arr[j]))
                    return "输入不合法！";
            }

            //取出每个字母对应的密文并连接成一个字符串 以空格隔开
            for (int i = 0; i < str.Length; i++)
            {
                char ch = str[i];
                pwd += table[ch];
                pwd += ' ';
            }
            return pwd;
        }
        
        /// <summary>
        /// 培根解密
        /// </summary>
        /// <param name="pwd">密文</param>
        /// <returns>明文</returns>
        static String deencryptPwd(String pwd)
        {
            pwd = pwd.Replace(" ", string.Empty);
            String str = string.Empty,text = string.Empty;
            char[] arr = pwd.ToArray();

            //检查输入            
            for (int j = 0; j < arr.Length; j++)
            {
                if (!isLetter(arr[j]))
                    return "输入不合法！";
            }

            //转换为正常密文的形式
            for (int i = 0; i < pwd.Length; i++)
            {
                str += pwd[i] >= 'a' && pwd[i] <= 'z' ? 'a' : 'b';
            }

            //找出每5个字符组成的密文所对应的明文
            for (int i = 0; i < str.Length / 5; i++)
            {
                string tempStr = str.Substring(i * 5,5);
                //Console.WriteLine("tempStr = {0}",tempStr);
                foreach(char key in table.Keys)
                {
                    if (table[key].ToString() == tempStr)
                        text += (key);
                }
            }
            return text;
        }

        /// <summary>
        /// 判断是否为字母
        /// </summary>
        /// <param name="ch">字符</param>
        /// <returns>是否为字母</returns>
        static bool isLetter(char ch)
        {
            return ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'z'));
        }
    }
}
