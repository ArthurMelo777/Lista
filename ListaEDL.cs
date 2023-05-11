using System;

// Os valores passados por parametro são indices ou nós?

class ListEmptyException : Exception {

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

    public Node search (int n) {
        Node new_node = head;
        for (int i = 0; i <= n; i++) {
            new_node = new_node.getNext();
        }

        return new_node;
    }

    public bool isFirst (int n) {
        if (isEmpty()) {
            throw new ListEmptyException();
        }
        if (search(n) == head.getNext()) {
            return true;
        }
        return false;
    }

    public bool isLast (int n) {
        if (isEmpty()) {
            throw new ListEmptyException();
        }
        if (search(n) == tail.getPrev()) {
            return true;
        }
        return false;
    }

    public Node first () {
        if (isEmpty()) {
            throw new ListEmptyException();
        }
        return head.getNext();
    }

    public Node last () {
        if (isEmpty()) {
            throw new ListEmptyException();
        }
        return tail.getPrev();
    }

    public Node before (int p) {
        if (isEmpty()) {
            throw new ListEmptyException();
        }
        return search(p).getPrev();
    }

    public Node after (int p) {
        if (isEmpty()) {
            throw new ListEmptyException();
        }
        return search(p).getNext();
    }

    public void replaceElement (int n, object o) {
        if (isEmpty()) {
            throw new ListEmptyException();
        }
        Node new_node = search(n);
        new_node.setElement(o);
    }

    public void swapElements (int n, int q) {
        if (isEmpty()) {
            throw new ListEmptyException();
        }
        Node new_node = search(n);
        Node new_node2 = search(q);
        object o = new_node.getElement();
        new_node.setElement(new_node2.getElement());
        new_node2.setElement(o);
    }

    public void insertBefore (int n, object o) {
        Node new_node;
        if (isEmpty()) {
            throw new ListEmptyException();
        }
        else {
            Node node = search(n);
            new_node = new Node(o, node.getPrev(), node);
            node.getPrev().setNext(new_node);
            node.setPrev(new_node);
            countSize++;
        }
    }

    public void insertAfter (int n, object o) {
        Node new_node;
        if (isEmpty()){
            throw new ListEmptyException();
        }
        else {
            Node node = search(n);
            new_node = new Node(o, node, node.getNext());
            node.getNext().setPrev(new_node);
            node.setNext(new_node);
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

    public object remove (int n) {
        if (isEmpty()) {
            throw new ListEmptyException();
        }

        Node new_node = search(n);

        new_node.getPrev().setNext(new_node.getNext());
        new_node.getNext().setPrev(new_node.getPrev());
        new_node.setPrev(null);
        new_node.setNext(null);

        countSize--;

        return new_node.getElement();
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
    private int countSize = 0, n = 1;

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
        list.printList();
        Console.WriteLine(list.size());
        Console.WriteLine(list.isEmpty());
        list.insertFirst(1);
        list.printList();
        list.insertLast(2);
        list.printList();
        Console.WriteLine(list.before(1).getElement());
        Console.WriteLine(list.after(0).getElement());
        Console.WriteLine(list.first().getElement());
        Console.WriteLine(list.last().getElement());
        list.replaceElement(0, 0);
        list.printList();
        list.swapElements(0, 1);
        list.printList();
        list.insertBefore(1, 1);
        list.printList();
        list.insertAfter(0, 3); // 2 3 1 0
        list.printList();
        Console.WriteLine(list.remove(1));
        list.printList();
    }
}