using System;
using System.Threading;
using System.Threading.Tasks;

public class Program
{
	private static int[] MergeSort(int[] input, int start, int end)
	{
		if (end - start < 2)
		{
			int[] result = new int[1];
			result[0] = input[start];
			return (result);
		}
	
		Task<int[]> Tleft = Task<int[]>.Factory.StartNew(() => { return MergeSort(input, start, (start + end) / 2); });
	
		Task<int[]> Tright = Task<int[]>.Factory.StartNew(() => { return MergeSort(input, (start + end) / 2, end); });
	
		int[] left = Tleft.Result;
	
		int[] right = Tright.Result;
		int[] Result = Task<int[]>.Factory.StartNew(() => { return Merge(left, right); }).Result;
	
		return Result;
	}
	
	private static int[] Merge(int[] left, int[] right)
	{
		int leftSize = left.Length, rightSize = right.Length;
		int[] result = new int[leftSize + rightSize];
		int leftIndex = 0, rightIndex = 0, resultIndex = 0;
	
		while (rightIndex < rightSize && leftIndex < leftSize)
			result[resultIndex++] = left[leftIndex] < right[rightIndex] ? left[leftIndex++] : right[rightIndex++];
		while (rightIndex < rightSize)
			result[resultIndex++] = right[rightIndex++];
		while (leftIndex < leftSize)
			result[resultIndex++] = left[leftIndex++];
		return result;
	}
	
	public static void Main()
	{
		int [] testValues = new int [10] {100,10,56,896,145,4512,16456,1,568,115615};

		Console.WriteLine("Before sorting: ");
		for (int i = 0; i < testValues.Length; i++)
    		Console.WriteLine(testValues[i]);

		MergeSort(testValues, 0, testValues.Length - 1);

		Console.WriteLine("After sorting: ");
		for (int i = 0; i < testValues.Length; i++)
    		Console.WriteLine(testValues[i]);
	}
}