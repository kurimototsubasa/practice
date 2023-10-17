using System;
using System.Linq;
using System.Collections.Generic;
class Program
{
    static int H, W;
    static char[] [] lst;
    static int[] [] checkList;
    static List<int[]> Info= new List<int[]>();
    static void Main()
    {
        var HW =Console.ReadLine().Split().Select(int.Parse).ToArray();
        H =HW[0];
        W =HW[1];
        
        lst = new char[H][];
        for (int i=0; i < H; i++){
            lst[i]=Console.ReadLine().ToCharArray();
        }
        checkList = new int[H][];
        for (int i= 0;i < H; i++){
            checkList[i] = new int[W];
        }
       for (int i=0; i < H; i++){
           for(int j =0;j< W; j++){
               if(lst[i][j]== '#' && checkList[i][j] == 0)
               {
                   Info.Add(new int[2]);
                   Island(i, j);
               }
           }
       }
       Info = Info.OrderByDescending(x =>x[0]).ThenByDescending(x =>x[1]).ToList();
       foreach (var lst2 in Info)
       {
           Console.WriteLine(string.Join(" " ,lst2));
          
       }
       
    }
    static void Island(int h,int w)
    {
        checkList[h][w] =1;
        Info[Info.Count - 1][0] +=1;
        
        if (H<= h+1  || lst[h + 1][w] == '.'){
            Info[Info.Count-1][1] +=1;
        }
        if (h-1<0  || lst[h - 1][w] == '.'){
            Info[Info.Count-1][1] +=1;
        }
        if (W<=w+1  || lst[h][w+1] == '.'){
            Info[Info.Count-1][1] +=1;
        }
        if (w - 1 < 0  || lst[h][w-1] == '.'){
            Info[Info.Count-1][1] +=1;
        }
        
        if(h+1<H  && lst[h+1][w] == '#' && checkList[h+1][w]== 0)
        {
        Island(h+1, w);
        }
        if(0<=h-1 && lst[h-1][w] == '#' && checkList[h-1][w]== 0)
        {
        Island(h-1, w);
        }
        if(w+1<W && lst[h][w+1] == '#' && checkList[h][w+1]== 0)
        {
        Island(h, w+1);
        }
        if(0<=w-1 && lst[h][w-1] == '#' && checkList[h][w-1]== 0)
        {
        Island(h, w-1);
        }
    }
}