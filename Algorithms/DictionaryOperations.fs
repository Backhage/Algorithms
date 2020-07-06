(* 
    Functions that work on an array backed dictionary.
    Performs insert, delete, and search in O(1).
    Major limitation is that only values 
    0 < n < Array.size are supported.
*)
module DictionaryOperations

open DictionaryTypes

let insertDictionary dictionary value =
    dictionary.Data.[value-1] <- value
    dictionary

let deleteDictionary dictionary value =
    dictionary.Data.[value-1] <- 0
    dictionary

let searchDictionary dictionary value =
    match dictionary.Data.[value-1] with
    | 0 -> None
    | n -> Some n
