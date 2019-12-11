using System;
					
public class Fib
{
	//method to ge the nth fibonacci number using dynamic programming
	public static int Fibonacci(int n)
	{
		//varables to store the values
		int x = 0, y = 1, z;
		for(int i=2;i<=n;i++)
		{
			//make z the sum of x and y
			z=x+y;
			//assign x to y and y to z signifying iterating through the fibonacci numbers
			x=y;
			y=z;
		}
		return y;
	}

	//method to ge the nth fibonacci number using recursion
	public static int FibonacciRec(int n)
    {
        if(n<=2)
            return 1;
        else
			//return the sum of the last 2 fibonacci numbers
            return FibonacciRec(n-1) + FibonacciRec(n-2);
    }
	
	public static void Main()
	{
			var recwatch = new System.Diagnostics.Stopwatch(); //stopwatch to measure execution time
			recwatch.Start();
			Console.WriteLine("Using Recursion: 10th digit = " + FibonacciRec(10));
			recwatch.Stop();
			Console.WriteLine("Execution Time: " + recwatch.ElapsedMilliseconds + "ms");


			var watch = new System.Diagnostics.Stopwatch();
			watch.Start();
			Console.WriteLine("Using Divide and Conquer: 10th digit = " + Fibonacci(10));
			watch.Stop();
			Console.WriteLine("Execution Time: " + watch.ElapsedMilliseconds + "ms");
		


	}
