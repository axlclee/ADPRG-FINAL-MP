// splitList the input list
let splitList divSize lst = 
  let rec splitAcc divSize cont = function
    | [] -> cont([],[])
    | l when divSize = 0 -> cont([], l)
    | h::t -> splitAcc (divSize-1) (fun acc -> cont(h::fst acc, snd acc)) t
  splitAcc divSize (fun x -> x) lst

// merge two sub-lists
let merge l r =
  let rec mergeCont cont l r = 
    match l, r with
    | l, [] -> cont l
    | [], r -> cont r
    | hl::tl, hr::tr ->
      if hl<hr then mergeCont (fun acc -> cont(hl::acc)) tl r
      else mergeCont (fun acc -> cont(hr::acc)) l tr
  mergeCont (fun x -> x) l r

// Sorting via merge
let mergeSort lst = 
  let rec mergeSortCont lst cont =
    match lst with
    | [] -> cont([])
    | [x] -> cont([x])
    | l -> let left, right = splitList (l.Length/2) l
           mergeSortCont left  (fun accLeft ->
           mergeSortCont right (fun accRight -> cont(merge accLeft accRight)))
  mergeSortCont lst (fun x -> x)

// create a random list
let testlist = [ 5; 4; 3; 2; 1; ]

// result:
let res = mergeSort testlist

let printlist lst =
    lst |> Seq.iter (fun x -> printf "%d " x)
    printf "\n"
    
printlist testlist
printlist res