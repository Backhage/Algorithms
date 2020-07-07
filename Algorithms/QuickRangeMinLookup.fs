module QuickRangeMinLookup

(* 
    Task:
    Given n integers x0, x1, ..., xn-1, create a way to find local 
    minimum in the range i,j where 0 <= i,j < n in O(1) time.

    Solution:
    This creates a lookuptable using a 2D array where each element
    is the local minimum. Initialization is O(n^2) but lookup is
    then O(1).
*)

let initQuickLookup (values : list<int>) =
    let result = Array2D.zeroCreate values.Length values.Length
    for i in 0..values.Length-1 do
        let mutable min = values.[i]
        for j in i..values.Length-1 do
            if values.[j] < min then
                min <- values.[j]
            else
                min <- min
            result.[i,j] <- min
    result

let minQuickLookup (lookupTable : int[,]) minIdx maxIdx =
    lookupTable.[minIdx, maxIdx]

