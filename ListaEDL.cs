using System;

class ListEmpty : Exception {

}

class Node {
    private object element;
    private Node prev, next;

    public Node (object e, Node p, Node n) {
        element = e;
        prev = p;
        next = n;
    }

    public void setElement (object e) {
        element = e;
    }

    public object getElement () {
        return element;
    }

    public void setPrev (Node p) {
        prev = p;
    }

    public Node getPrev () {
        return prev;
    }

    public void setNext (Node n) {
        next = n;
    }

    public Node getNext () {
        return next;
    }
}

class ListLinkedList {
    private Node head, tail;
    private int countSize = 0, n = 1;

    public ListLinkedList () {
        Node node = new Node(null, null, null);
        head = new Node(null, null, node);
        tail = new Node(null, node, null);
    }

    public int size () {
        return countSize;
    }

    public bool isEmpty () {
        if (countSize == 0) {
            return true;
        }
        return false;
    }

    public Node search (object o) {
        Node new_node = head;
        while (new_node.getElement() != o) {
            new_node = new_node.getNext();
        }

        return new_node;
    }

    public bool isFirst (Node n) {
        if (isEmpty()) {
            throw new ListEmpty();
        }
        if (n == head.getNext()) {
            return true;
        }
        return false;
    }

    public bool isLast (Node n) {
        if (isEmpty()) {
            throw new ListEmpty();
        }
        if (n == tail.getPrev()) {
            return true;
        }
        return false;
    }

    public Node first () {
        if (isEmpty()) {
            throw new ListEmpty();
        }
        return head.getNext();
    }

    public Node last () {
        if (isEmpty()) {
            throw new ListEmpty();
        }
        return tail.getPrev();
    }

    public Node before (Node p) {
        if (isEmpty()) {
            throw new ListEmpty();
        }
        return p.getPrev();
    }

    public Node after (Node p) {
        if (isEmpty()) {
            throw new ListEmpty();
        }
        return p.getNext();
    }

    public void replaceElement (Node n, object o) {
        if (isEmpty()) {
            throw new ListEmpty();
        }
        n.setElement(o);
    }

    public void swapElements (Node n, Node q) {
        if (isEmpty()) {
            throw new ListEmpty();
        }
        object o = n.getElement();
        n.setElement(q.getElement());
        q.setElement(o);
    }

    public void insertBefore (Node n, object o) {
        Node new_node;
        if (isEmpty()) {
            throw new ListEmpty();
        }
        else {
            new_node = new Node(o, n.getPrev(), n);
            n.getPrev().setNext(new_node);
            n.setPrev(new_node);
            countSize++;
        }
    }

    public void insertAfter (Node n, object o) {
        Node new_node;
        if (isEmpty()){
            throw new ListEmpty();
        }
        else {
            new_node = new Node(o, n, n.getNext());
            n.getNext().setPrev(new_node);
            n.setNext(new_node);
            countSize++;
        }
    }

    public void insertFirst (object o) {
        Node new_node = new Node(o, head, head.getNext());
        head.getNext().setPrev(new_node);
        head.setNext(new_node);
        if (isEmpty()) {
            tail.setPrev(new_node);
            new_node.setNext(tail);
        }
        countSize++;
    }

    public void insertLast (object o) {
        Node new_node = new Node(o, tail.getPrev(), tail);
        (tail.getPrev()).setNext(new_node);
        tail.setPrev(new_node);
        if (isEmpty()) {
            head.setNext(new_node);
            new_node.setPrev(head);
        }
        countSize++;
    }

    public object remove (Node n) {
        if (isEmpty()) {
            throw new ListEmpty();
        }

        n.getPrev().setNext(n.getNext());
        n.getNext().setPrev(n.getPrev());
        n.setPrev(null);
        n.setNext(null);

        countSize--;

        return n.getElement();
    }

    public void printList () {
        if (isEmpty()) {
            Console.WriteLine("Lista vazia coleguinha!");
        }
        else {
            Node node = head.getNext();
            for (int i = 0; i < countSize; i++) {
                Console.Write($" [{node.getElement()}]");
                node = node.getNext();
            }
            Console.WriteLine();
        }
    }
}

class ListArray {
    private object [] list = new object[1];
    private int countSize = 0, cap = 1;

    public void increment () {}

    public void decrement () {}

    public int size () {}

    public bool isEmpty () {}

    public bool isFirst (int n) {}

    public bool isLast (int n) {}

    public Node first () {}

    public Node last () {}

    public Node before () {}

    public Node after () {}

    public void replaceElement (int n, object o) {}

    public void swapElements (int n, int q) {}

    public void insertBefore (int n, object o) {}

    public void insertAfter (int n, object o) {}

    public void insertFirst (object o) {}

    public void insertLast (object o) {}

    public void remove (int n) {}

    public void printList () {}
}

class Program {
    public static void Main () {
        ListLinkedList list = new ListLinkedList();
        Node node, node2;
        list.printList(); // Lista vazia coleguinha
        Console.WriteLine(list.size()); // 0
        Console.WriteLine(list.isEmpty()); // true
        list.insertFirst(1); //
        list.printList(); // [ 1 ]
        list.insertLast(2); //
        list.printList(); // [ 1 2 ]
        node = list.first(); // 
        node2 = list.last(); // 
        Console.WriteLine(list.before(node2).getElement()); // 1
        Console.WriteLine(list.after(node).getElement()); // 2
        Console.WriteLine(list.first().getElement()); // 1
        Console.WriteLine(list.last().getElement()); // 2
        list.replaceElement(node, 0); //
        list.printList(); // [ 0 2 ]
        list.swapElements(node, node2); //
        list.printList(); // [ 2 0 ]
        list.insertBefore(node, 1); //
        list.printList(); // [ 1 2 0 ]
        list.insertAfter(node2, 3); //
        list.printList(); // [ 1 2 0 3 ]
        Console.WriteLine(list.remove(node)); //
        list.printList(); // [ 1 0 3 ]
    }
}