module Algorithms.Test

open NUnit.Framework
open ListTypes
open ListOperations

[<Test>]
let create () =
    let list = { Node = None }
    Assert.That(lengthList list, Is.EqualTo(0))

[<Test>]
let insert () =
    let list = { Node = None }
    let list = insertList list 1

    Assert.That (lengthList list, Is.EqualTo(1))
    Assert.That (list.Node.IsSome)
    Assert.That (list.Node.Value.Item, Is.EqualTo(1))

    let list = insertList list 2

    Assert.That (lengthList list, Is.EqualTo(2))
    Assert.That (list.Node.IsSome)
    Assert.That (list.Node.Value.Item, Is.EqualTo(2))
    Assert.That (list.Node.Value.Next.IsSome)
    Assert.That (list.Node.Value.Next.Value.Item, Is.EqualTo(1))

[<Test>]
let search () =
    let list = { Node = None }
    let list = insertList list 1
    let list = insertList list 2
    let list = insertList list 3
    
    let existingElement = searchList list 2
    let nonExistingElement = searchList list 42

    Assert.That (existingElement.IsSome)
    Assert.That (existingElement.Value, Is.EqualTo(2))
    Assert.That (nonExistingElement.IsNone)

[<Test>]
let deleteOnlyItem () =
    let list = { Node = Some { Item = 1; Next = None } }
    let list = deleteList list 1;
    Assert.That (lengthList list, Is.EqualTo(0))

[<Test>]
let deleteOneItemOfMany () =
    let list = { Node = None }
    let list = insertList list 3
    let list = insertList list 4
    let list = insertList list 2
    let list = insertList list 6

    let list = deleteList list 4

    Assert.That (lengthList list, Is.EqualTo(3))
    Assert.That (searchList list 4, Is.EqualTo(None))

[<Test>]
let reverse () =
    let list = { Node = None }
    let list = insertList list 3
    let list = insertList list 2
    let list = insertList list 1
    let list = insertList list 0

    let rec verify assertFunc (node : Node<'a> option) (nextNode : Node<'a> option) =
        match node, nextNode with
        | Some n, Some nn ->
            Assert.That (n.Item, assertFunc(nn.Item))
            verify assertFunc (Some nn) nn.Next
        | _, _ -> ()

    verify Is.LessThan list.Node list.Node.Value.Next

    let reversedList = reverseList list

    verify Is.GreaterThan reversedList.Node reversedList.Node.Value.Next

    Assert.That(lengthList list, Is.EqualTo(lengthList reversedList))
