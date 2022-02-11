using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SorteringsAlgoritmer
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            List<int> bblRnd = new List<int>();
            List<int> insRnd = new List<int>();

            Stopwatch bblSW = new Stopwatch();
            Stopwatch insSW = new Stopwatch();
            Stopwatch mergeSW = new Stopwatch();

            int antal = 10000;

            for (int i = 0; i < antal; i++)
            {
                bblRnd.Add(rnd.Next());
                insRnd.Add(rnd.Next());
            }

            // Bubblesort 
            int Length = bblRnd.Count;
            
            bblSW.Start();
            
            for(int bblA = 0; bblA < (Length - 1); bblA++){
                for(int bblB = 0; bblB < (Length - 1 - bblA); bblB++){
                    if(bblRnd[bblB] > bblRnd[bblB + 1]){
                        int bblC = bblRnd[bblB + 1];
                        bblRnd[bblB + 1] = bblRnd[bblB];
                        bblRnd[bblB] = bblC;
                    }
                }
            }

            bblSW.Stop();
            
            //Insertionsort
            int Lengthlist = insRnd.Count;
            
            insSW.Start();
            for(int insA = 1; insA < Lengthlist; ++insA){
                int key = insRnd[insA];
                int insB = insA - 1;

                while(insB >= 0 && insRnd[insB] > key){
                    insRnd[insB + 1] = insRnd[insB];
                    insB = insB - 1;
                }
                insRnd[insB + 1] = key;
            }

            insSW.Stop();

            //Merge sort
            mergeSW.Start();

            List<int> mergeRnd = new List<int>();
            List<int> sorted;

            for(int a = 0; a< antal;a++){
                mergeRnd.Add(rnd.Next(0, 100));
            }
            Console.WriteLine();

            sorted = MergeSort(mergeRnd);

            mergeSW.Stop();

            Console.WriteLine("Bubblesort: " + bblSW.ElapsedMilliseconds);
            Console.WriteLine("Insertionsort: " + insSW.ElapsedMilliseconds);
            Console.WriteLine("Merge sort: " + mergeSW.ElapsedMilliseconds);


        }

        private static List<int> MergeSort(List<int> mergeRnd)
        {
            if (mergeRnd.Count <= 1)
                return mergeRnd;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int middle = mergeRnd.Count / 2;
            for (int i = 0; i < middle;i++)
            {
                left.Add(mergeRnd[i]);
            }
            for (int i = middle; i < mergeRnd.Count; i++)
            {
                right.Add(mergeRnd[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while (left.Count > 0 || right.Count > 0)
            {
                if(left.Count > 0 && right.Count > 0)
                {
                    if(left.First() <= right.First())
                    {
                        result.Add(left.First());
                        left.Remove(left.First());
                    }
                    
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }  
                }

                else if(left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }

                else if(right.Count > 0)
                {
                    result.Add(right.First());
                    right.Remove(right.First());
                }
            }
            return result;
        }
    }
}
