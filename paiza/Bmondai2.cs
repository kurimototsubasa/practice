using System;
using System.Linq;
class Program
{
    static void Main()
    {
        string[] stArrayData = Console.ReadLine().Trim().Split(' ');
        int[] intArray = stArrayData.Select(int.Parse).ToArray();
        int N = intArray[0];
        int M = intArray[1];
        var A = new int[N];
        var A_initial = new int[N];
         for (int i = 0; i < N; i++)
        {
            A[i] = int.Parse(Console.ReadLine());
             A_initial[i] = A[i];
        }
        var B = new int[M];
         for (int i = 0; i < M; i++)
        {
            B[i] = int.Parse(Console.ReadLine());
        }
        
            
        var gondola = new int[N];
        var gondola1 = 0;
        var group = 0;
        while (group < M)
        {
            if (A[gondola1] >=B[group])
            {
                gondola[gondola1] +=B[group];
                A[gondola1] -=B[group];
                group++;
                gondola1 =(gondola1 +1)%N ;
                A[gondola1] = A_initial[gondola1];
            }
            else
            {
                 gondola[gondola1] +=A[gondola1];
                  B[group] -=A[gondola1];
                  A[gondola1] = 0;
            }
            if(A[gondola1]==0 )
            {
                gondola1 =(gondola1 +1)%N ;
                A[gondola1] = A_initial[gondola1];
                
            }
            
        }
         for (int i=0; i< N;i++)
            {
                Console.WriteLine(gondola[i]);
            }
    }
}