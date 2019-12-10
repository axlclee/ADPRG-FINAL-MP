using System;
					
public class Fib
{
	
	public static int Fibonacci(int n)
	{
		int x = 0, y = 1, z;
		for(int i=2;i<=n;i++)
		{
			z=x+y;
			x=y;
			y=z;
		}
		return y;
	}
	
	public static void Main()
	{
		
		Console.WriteLine(Fibonacci(1));
	}
}