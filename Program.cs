using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace hej
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd =new Random();
            List<int> rndL = new List<int>();
            List<int> rndli = new List<int>();
            Stopwatch spw = new Stopwatch();
            Stopwatch spw2 = new Stopwatch(); 

            for(int i = 0; i<20000;i++){
                rndL.Add(rnd.Next());
                rndli.Add(rnd.Next());
            }
   

            int length =rndL.Count;
            int Length = rndli.Count;
            //bpouble sort

            spw.Start();
            
                for(int a = 0; a < length;a++){  
                    for(int b = 0;b < (length-1-a); b++){
                        if(rndL[b] > rndL[b+1]){
                            int c = rndL[b+1];
                            rndL[b+1] = rndL[b];
                            rndL[b] = c;
                        }
                    }
                }
            spw.Stop();
     
            

            Console.WriteLine(spw.ElapsedMilliseconds);

            //insetion sort

            spw2.Start();

                for(int d = 1;d < Length; ++d){
                    int key = rndli[d];
                    int e = d-1;

                    while(e >= 0 && rndli[e] > key){
                        rndli[e + 1] =rndli[e];
                        e = e - 1;
                    }
                    rndli[e + 1] = key;
                }

            spw2.Stop();

            Console.WriteLine(spw2.ElapsedMilliseconds);


        }
    }
}
