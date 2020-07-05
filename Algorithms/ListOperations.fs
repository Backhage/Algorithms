module ListOperations

open ListTypes
open System.Collections.Generic

let insertList list item =
    let newNode = { Item = item; Next = list.Node }
    { Node = Some newNode }

let deleteList list item =
    let rec traverse list node item =
        match node with
        | None -> list
        | Some n ->
            if n.Item = item then
                traverse list n.Next item
            else
                let list = insertList list n.Item
                traverse list n.Next item

    traverse { Node = None } list.Node item

let searchList list item =
    let rec traverse node item =
        if node.Item = item then
            Some item 
        else
            match node.Next with
            | Some n -> traverse n item
            | None -> None

    match list.Node with
    | Some n -> traverse n item
    | None -> None

let lengthList list =
    let rec accumulator count node =
        match node with
        | Some n -> accumulator (count+1) n.Next
        | None -> count

    accumulator 0 list.Node

let reverseList list =
    let rec buildQueue (queue : Queue<'a>) node =
        match node with
        | Some n ->
            queue.Enqueue n.Item
            buildQueue queue n.Next
        | None -> queue 

    let rec buildReverseList (queue : Queue<'a>) list =
        if (queue.Count > 0) then
            let list = insertList list (queue.Dequeue())
            buildReverseList queue list
        else
            list

    let queue = buildQueue (Queue<'a>()) list.Node
    buildReverseList queue { Node = None }
