using System;
					
public class Program
{
	private static void Merge(int[] input, int left, int middle, int right)
	{
		// creates new array of ints for the left and right portion
		int[] leftArray = new int[middle - left + 1];
		int[] rightArray = new int[right - middle];
	
		// copy all the values into the respective array
		Array.Copy(input, left, leftArray, 0, middle - left + 1);
		Array.Copy(input, middle + 1, rightArray, 0, right - middle);
	
		int i = 0;
		int j = 0;
		// actual merging
		for (int k = left; k < right + 1; k++)
		{
			if (i == leftArray.Length)
			{
				input[k] = rightArray[j];
				j++;
			}
			else if (j == rightArray.Length)
			{
				input[k] = leftArray[i];
				i++;
			}
			else if (leftArray[i] <= rightArray[j])
			{
				input[k] = leftArray[i];
				i++;
			}
			else
			{
				input[k] = rightArray[j];
				j++;
			}
		}
	}
 
	private static void MergeSort(int[] input, int left, int right)
	{
		if (left < right)
		{
			int middle = (left + right) / 2;
	
			// merge sort both sides
			MergeSort(input, left, middle);
			MergeSort(input, middle + 1, right);
	
			// rearrange
			Merge(input, left, middle, right);
		}
	}    
	
	public static void Main()
	{
		int [] testValues = new int [10] {100,10,56,896,145,4512,16456,1,568,115615};

		MergeSort(testValues, 0, testValues.Length - 1);
	}
}