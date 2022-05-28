using System;
using System.Collections.Generic;

namespace Insert_Interval
{
  class Program
  {
    static void Main(string[] args)
    {
      // https://leetcode.com/problems/insert-interval/
      Console.WriteLine("Hello World!");
    }
  }

  public class Solution
  {
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
      // possibility - 1, new interval will be added before any interval from the input array 
      // Example - [1,2] input = [[3,4],[5,6],[7,8]] Answer = [[1,2],[3,4],[5,6],[7,8]]
      // Example - [5,6] input = [[3,4],[7,8]] Answer = [[3,4],[5,6],[7,8]] - here during second iteration new interval would be added before [7,8]
      // possibility - 2, new interval would be added at the end of the interval array - for this will be adding the new interval after itterating the entire interval array.  
      // possibility 3 - we have overlapped intervals - for this will update the newInterval[0] = min(newInterval[0], inetervals[i][0]) and newInterval[1] = max(newInterval[1], inetervals[i][1]), after this will skip adding any thing to our result.

      List<int[]> result = new List<int[]>();
      int newStart = newInterval[0];
      int newEnd = newInterval[1];
      for (int index = 0; index < intervals.Length; index++)
      {
        int start = intervals[index][0];
        int end = intervals[index][1];
        // possibility - 1
        if (newEnd < start)
        {
          // add the newInterval to the result
          result.Add(new int[] { newStart, newEnd });
          // We can add the rest of the array items from the current item.
          var subarray = intervals[index..];
          result.AddRange(subarray);
          // return the result as we are done.
          return result.ToArray();
        }
        else if (newStart > end)
        { // possibility - 2
          result.Add(intervals[index]);
        }
        else
        { // possibility 3
          newStart = Math.Min(newStart, start);
          newEnd = Math.Max(newEnd, end);
        }
      }

      result.Add(new int[] { newStart, newEnd });

      return result.ToArray();
    }
  }
}
