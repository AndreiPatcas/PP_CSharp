using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Lab3PPCS
{
    class Program
    {
        static void generateFile(String filename, int size, int min, int max)

        {
            using (StreamWriter writetext = new StreamWriter(filename))
            {
                Random rand = new Random();
                for (int i = 0; i < size; i++)
                {
                    int x = rand.Next(max - min) + min;
                    writetext.Write(x+" ");
                }
            }

        }

        static int[] getData(String filename,int nr)
        {
            Random rand = new Random();
            //int x = rand.Next(30) + 10;
            try
            {
                generateFile(filename, nr, -25, 25);
            }
            catch (FileNotFoundException e)
            {

            }
            int[] list = new int[nr];
            using (StreamReader readtext = new StreamReader(filename))
            {
                char[] ch = { ' ' };
                String[] line = readtext.ReadLine().Trim().Split(ch);
                for (int i = 0; i < line.Length; i++)

                {
                    //Console.WriteLine(line[i]);
                    list[i] = int.Parse(line[i]);
                }
            }
            return list;

        }

        public static int[] copy(int[] list, int pos1, int pos2)
        {
            int[] rez = new int[pos2 - pos1];
            int k = 0;
            for (int i = pos1; i < pos2; i++)
            {
                rez[k] = list[i]; k++;
            }
            return rez;
        }


        public static int[] merge(int[] a, int[] b)
        {
            int k = 0;
            int[] merged = new int[a.Length + b.Length];
            int i = 0, j = 0;
            while (i != a.Length && j != b.Length)
            {
                //System.out.println(i+" "+ j);
                if (a[i] <= b[j])
                {
                    merged[k] = a[i];
                    k++;
                    i++;
                }
                else
                {
                    merged[k] = b[j];
                    k++;
                    j++;
                }
            }
            if (i != a.Length)
            {
                for (int ii = i; ii < a.Length; ii++)
                {
                    merged[k] = a[ii];
                    k++;
                }
            }
            if (j != b.Length)
            {
                for (int jj = j; jj < b.Length; jj++)
                {
                    merged[k] = b[jj];
                    k++;
                }
            }
            return merged;
        }
        public static int[] mergeSortSecv(int[] list)
        {
            if (list.Length == 1)
            {
                return list;
            }
            else
            {
                int m = list.Length / 2;
                //  System.out.println(m + " m");
                int[] a = copy(list, 0, m);
                int[] b = copy(list, m, list.Length);
                int[] aSorted = mergeSortSecv(a);
                int[] bSorted = mergeSortSecv(b);
                return merge(aSorted, bSorted);
            }
        }

        static void Main(String[] args)
        {
            
            int[] a = getData("C:\\Users\\Patcas\\source\\repos\\Lab3PPCS\\Lab3PPCS\\data.txt", 25);
            int[] rez = mergeSortSecv(a);
            using (StreamWriter writetext = new StreamWriter("C:\\Users\\Patcas\\source\\repos\\Lab3PPCS\\Lab3PPCS\\rez.txt"))
            {
                for (int i = 0; i < rez.Length; i++)
                {
                    writetext.Write(rez[i] + " ");
                }
            }
           


        }
    }

}