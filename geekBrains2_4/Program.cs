using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace geekBrains2_4
{
    class Program
    {
        public static HashSet<string> hashString = new HashSet<string>();
        public static string[] massString = new string[10000];
        static void Main(string[] args)
        {
            

            AddHashSet(hashString);
            AddString(massString);
          
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
            Console.WriteLine(BechmarkClass.HashSetTest(hashString));// Проверка кода
            Console.WriteLine(BechmarkClass.MassTest(massString));// Проверка кода
            Console.ReadLine();
        }

        static void AddString(string[] massString)
        {
            for (int i = 0; i < 10000; i++)
            {
                massString[i] = i.ToString();
            }
        }
        static void AddHashSet(HashSet<string> hashString)
        {
            for (int i = 0; i < 10000; i++)
            {
                hashString.Add(i.ToString());
            }
        }
    }



    public class BechmarkClass
    {
        public static bool HashSetTest(HashSet<string> hashString)
        {
            foreach (string str in hashString)
            {
                if (str.Contains("5000"))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool MassTest(string[] massString)
        {   
            foreach (string str in massString)
            {
                if (str.Contains("5000"))
                {
                    return true;
                }
            }
            return false;
        }

        [Benchmark]
        public void HashSet()
        {
            HashSetTest(Program.hashString);
        }

        [Benchmark]
        public void Mass()
        {
            MassTest(Program.massString);
        }
    }
}
