module Algoritms.Test

open DictionaryTypes
open DictionaryOperations
open NUnit.Framework

[<Test>]
let create () =
    let dict = { Data = Array.zeroCreate 10 } 
    Assert.That (dict, Is.Not.Null)

[<Test>]
let insert () =
    let dict = { Data = Array.zeroCreate 1000 } 
    let simpleDictionary = insertDictionary dict 1000
    Assert.That (searchDictionary simpleDictionary 1000, Is.EqualTo(Some 1000))

[<Test>]
let delete () =
    let dict = insertDictionary { Data = Array.zeroCreate 10 } 5
    Assert.That (searchDictionary dict 5, Is.EqualTo(Some 5))

    let dict = deleteDictionary dict 5
    Assert.That (searchDictionary dict 5, Is.EqualTo(None))

