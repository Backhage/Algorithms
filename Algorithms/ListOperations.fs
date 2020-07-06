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
    let rec buildReverseList reverseList node =
        match node with
        | Some n ->
            let reverseList = insertList reverseList n.Item
            buildReverseList reverseList n.Next
        | None -> reverseList
    buildReverseList { Node = None } list.Node
