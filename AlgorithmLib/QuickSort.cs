namespace AlgorithmLib;


public static class QuickSort
{
    private static int Partition(List<IComparable> data, int first, int last)
    {
        var q = first; //get first index saved
        for (int u = first; u <= last - 1; u++) //repeat until nothing left to partition
        {
            if (data[u].CompareTo(data[last] )<=0)
            {
                //code to swap partitioned items in indexes q and u
                var tempItem = data[q];
                data[q] = data[u];
                data[u] = tempItem;
                //increment q for partition
                q++;
            }
        }
        //code to swap partitioned items in indexes q and last
        var tempItem2 = data[q];
        data[q] = data[last];
        data[last] = tempItem2;
        return q;
    }

    public static void Sort(List<IComparable> data)
    {
        Sort(data, 0, data.Count - 1); //initiate through facade
    }
    public static void Sort(List<IComparable> data, int first, int last)
    {
        //run through quick sorting if there is at least two items in the given array
        if (first >= last) //if this then do nothing
        {
            //that's it return nothing
        }
        else if (first < last)
        {
            //find partition indexof array to use later
            int q = Partition(data, first, last);


            //recursively sort left side then right sides of the arrays until they are sorted
            Sort(data, first, q-1);
            Sort(data, q + 1, last);
          
        }
    }


}