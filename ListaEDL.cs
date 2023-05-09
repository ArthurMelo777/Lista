using System;

class ListaVaziaException : Exception {

}

class Node {
    private object element;
    private Node prev, next;

    public Node (object e, Node p, Node n) {
        element = e;
        prev = p;
        next = n;
    }
}

class ListLinkedList {
    private Node first, last;
    private int countSize = 0, n = 1;

    public ListLinkedList (Node f, Node l) {
        first = f;
        last = l;
    }

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
}

class ListArray {
    private object [] = new object[1];
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
}
