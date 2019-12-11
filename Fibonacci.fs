open System

//function to ge the nth fibonacci number using dynamic programming
let fibonacci n :int = 
//initialize variables to store values as mutable so that they may be updated as iteration occurs
  let mutable x = 0
  let mutable y = 1
  let mutable z = 0
  for i = 2 to n do
    //set z to the sum of x and y
    z <- x + y
    //assign x to y and y to z signifying iterating through the fibonacci numbers
    x <- y
    y <- z
  y

//function to ge the nth fibonacci number using recursion
let rec fibonacciRec n: int = 
  if n <= 2 then 1
  ////return the sum of the last 2 fibonacci numbers
  else fibonacciRec (n-1) + fibonacciRec (n-2)


let main =

  let recwatch = new System.Diagnostics.Stopwatch()//stopwatch to measure execution time
  recwatch.Start()
  Console.WriteLine("Using Recursion: 10th digit = {0}",fibonacciRec(10))
  recwatch.Stop()
  Console.WriteLine("Execution Time: {0} ms" ,recwatch.ElapsedMilliseconds)


  let watch = new System.Diagnostics.Stopwatch()
  watch.Start()
  Console.WriteLine("Using Divide and Conquer:  10th digit = {0}",fibonacci(10))
  watch.Stop()
  Console.WriteLine("Execution Time: {0} ms" ,watch.ElapsedMilliseconds )
