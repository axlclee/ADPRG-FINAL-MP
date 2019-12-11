using System;
using System.Threading;
using System.Threading.Tasks;

public class Program
{
	private static int[] MergeSort(int[] input, int start, int end)
	{
		// when sorting an array with one element
		if (end - start < 2)
		{
			int[] result = new int[1];
			result[0] = input[start];
			return (result);
		}
	
		// create a new thread for merge sorting the left side
		Task<int[]> Tleft = Task<int[]>.Factory.StartNew(() => { return MergeSort(input, start, (start + end) / 2); });
	
		// create a new thread for merge sorting the right side
		Task<int[]> Tright = Task<int[]>.Factory.StartNew(() => { return MergeSort(input, (start + end) / 2, end); });
	
		int[] left = Tleft.Result;
	
		int[] right = Tright.Result;

		// merge the left and right side
		int[] Result = Task<int[]>.Factory.StartNew(() => { return Merge(left, right); }).Result;
	
		return Result;
	}
	
	private static int[] Merge(int[] left, int[] right)
	{
		int leftSize = left.Length, rightSize = right.Length;
		int[] result = new int[leftSize + rightSize];
		int leftIndex = 0, rightIndex = 0, resultIndex = 0;
	
		// if there are still values to get from both sides
		while (rightIndex < rightSize && leftIndex < leftSize)
			result[resultIndex++] = left[leftIndex] < right[rightIndex] ? left[leftIndex++] : right[rightIndex++];
		// when only right side has values
		while (rightIndex < rightSize)
			result[resultIndex++] = right[rightIndex++];
		// when only left side has values
		while (leftIndex < leftSize)
			result[resultIndex++] = left[leftIndex++];
		return result;
	}
	
	public static void Main()
	{
		int [] testValues = new int [10] {100,10,56,896,145,4512,16456,1,568,115615};

		MergeSort(testValues, 0, testValues.Length - 1);
	}
}