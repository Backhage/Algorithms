module QuickRangeMinLookup.Test

open System
open NUnit.Framework
open QuickRangeMinLookup

[<Test>]
let quickLookup () =
    let rng = new Random()
    let nums = [for _ in 1..1000 do rng.Next()]
    let lookupTable = initQuickLookup nums
    let min = minQuickLookup lookupTable 0 999

    Assert.That (minQuickLookup lookupTable 0 0, Is.EqualTo(nums.[0]))
    Assert.That (min, Is.EqualTo(nums |> List.min))

