// takes the first n from a list
let take n list = 
    List.ofSeq <| Seq.take n list

// takes everything after n of a list
let rec takeRest n list = 
    match (n, list) with
    // if n is zero take all
    | (0, l) -> l
    // recursive part
    | (n, _ :: tl) -> takeRest (n - 1) tl
    | (_, _) -> failwith "unknown pattern"

let rec mergeList list1 list2 =
    match (list1, list2) with
    // if both lists are empty return empty
    | [], [] -> []
    // if only one list is empty return the other one
    | [], l -> l
    | l, [] -> l
    // tail end recursion
    | hd1 :: tl1, (hd2 :: _ as tl2) when hd1 < hd2 -> hd1 ::  mergeList tl1 tl2
    | l1, hd2 :: tl2 -> hd2 :: mergeList l1 tl2

let rec mergeSort = function
    // if empty or only one element
    | [] -> [] 
    | [x] -> [x]
    // else
    | l -> 
        // get midpoint
        let n = (int)(List.length l / 2)      
        // mergesort left and right side  
        let list1 = mergeSort (take n l)
        let list2 = mergeSort (takeRest n l)
        // then merge
        mergeList list1 list2

[<EntryPoint>]
let main args = 
    let input = [10; 7; 1; 0; -1; 9; 33; 12; 6; 2; 3; 33; 34;];
    List.iter (fun x -> printfn "%i" x) (mergeSort input)
    0