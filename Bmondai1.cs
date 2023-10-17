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
        int[,] MoneyArrayData = new int[N,M];
        for (var i = 0; i < N; i++)
        {
            string[] ArrayData = Console.ReadLine().Trim().Split(' ');
            for (var j = 0; j<M; j++){
                MoneyArrayData[i, j] = int.Parse(ArrayData[j]);
            } 
            
            
            
        }
        string[] LData = Console.ReadLine().Trim().Split(' ');
        int[] intLArray = LData.Select(int.Parse).ToArray();
        int L = intLArray[0];
        int Goukei = 0;
        int Now= 0;
        for (var i = 0; i < L; i++)
        {
            string[] RoutData = Console.ReadLine().Trim().Split(' ');
            int[] RoutArray = RoutData.Select(int.Parse).ToArray();
            //i=0の時
            if(i==0){
                Goukei =MoneyArrayData[RoutArray[0]-1, RoutArray[1]-1];
                Now =RoutArray[1]-1; //現在の駅
                continue;
            }
            if(Now-(RoutArray[1]-1)<0){
                     Goukei= Goukei+(MoneyArrayData[RoutArray[0]-1, RoutArray[1]-1]-MoneyArrayData[RoutArray[0]-1, Now]);
                     Now =RoutArray[1]-1;
                     continue;
             }
            if(Now-(RoutArray[1]-1)>0){
                Goukei= Goukei+(MoneyArrayData[RoutArray[0]-1, Now]-MoneyArrayData[RoutArray[0]-1, RoutArray[1]-1]);
                Now =RoutArray[1]-1;
                        }
            
        }
        Console.WriteLine("{0}", Goukei);
    }
    
}