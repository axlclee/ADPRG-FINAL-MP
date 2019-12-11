
let fibonacci n :int = 
  let mutable x = 0
  let mutable y = 1
  let mutable z = 0
  for i = 2 to n do
    z <- x + y
    x <- y
    y <- z
  y

let main =
  let x = fibonacci 6
  printfn "%d" x
