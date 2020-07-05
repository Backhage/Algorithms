module ListTypes

type Node<'a> =
    {
        Item : 'a
        Next : Node<'a> option
    }

type SinglyLinkedList<'a> =
    {
        Node : Node<'a> option
    }