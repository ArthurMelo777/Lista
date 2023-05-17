using System;

class ListEmpty : Exception {

}

class ElementNotFound : Exception {

}

class Position {
    private object element;

    public Position (object e) {
        element = e;
    }

    public void setElement (object e) {
        element = e;
    }

    public object getElement () {
        return element;
    }
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

    public void increment (int n, bool opc) { // inserção antes == true; depois == false;
        object [] new_list = new object[++cap];

        for (int i = 0; i < countSize; i++) {
            if (opc && n-1 == i) {
                i++;
            }
            else if (!opc && n+1 == i) {
                i++;
            }
            new_list[i] = list[i];
        }

        list = new_list;
    }

    public void decrement (int n) {
        object [] new_list = new object[--cap];

        int j = 0;

        for (int i = 0; i < countSize; i++) {
            if (n == i) {
                j--;
            }
            j++;
            new_list[i] = list[i];
        }

        list = new_list;
    }

    public int search (Position p) {
        for (int i = 0; i < countSize; i++) {
            //Console.WriteLine($"indice = {i}, elemento = {list[i]}, position = {p.getElement()}");
            if (p.getElement() == list[i]) {
                //Console.WriteLine($"indice = {i}");
                return i;
            }
        }
        return -1;
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

    public bool isFirst (Position p) {
        if (isEmpty()) {
            throw new ListEmpty();
        }
        if (search(p) == 0) {
            return true;
        }
        return false;
    }

    public bool isLast (Position p) {
        if (isEmpty()) {
            throw new ListEmpty();
        }
        if (search(p) == countSize-1) {
            return true;
        }
        return false;
    }

    public object first () {
        if (isEmpty()) {
            throw new ListEmpty();
        }
        return list[0];
    }

    public object last () {
        if (isEmpty()) {
            throw new ListEmpty();
        }
        return list[countSize-1];
    }

    public object before (Position p) {
        if (isEmpty()) {
            throw new ListEmpty();
        }

        int i = search(p);

        if (i-1 < 0) {
            throw new ElementNotFound();
        }
        return list[i-1];
    }

    public object after (Position p) {
        if (isEmpty()) {
            throw new ListEmpty();
        }

        int i = search(p);

        if (i+1 >= countSize) {
            throw new ElementNotFound();
        }
        return list[i+1];
    }

    public void replaceElement (Position p, object o) {
        if (isEmpty()) {
            throw new ListEmpty();
        }
        list[search(p)] = o;
    }

    public void swapElements (Position p, Position q) {
        if (isEmpty()) {
            throw new ListEmpty();
        }

        int i1 = search(p), i2 = search(q);

        //Console.WriteLine($"p = {p.getElement()}, i1 = {i1}, i2 = {i2}");

        object aux = list[i1];
        list[i1] = list[i2];
        list[i2] = aux;
    }

    public void insertBefore (Position p, object o) {
        int i = search(p);
        if (i-1 < 0) {
            throw new ElementNotFound();
        }
        countSize++;
        increment(i, true);
        list[i-1] = o;
    }

    public void insertAfter (Position p, object o) {
        int i = search(p);
        
        if (i >= countSize) {
            throw new ElementNotFound();
        }
        countSize++;
        increment(i, false);
        list[i+1] = o;
    }

    public void insertFirst (object o) {
        countSize++;
        increment(0, true);
        list[0] = o;
    }

    public void insertLast (object o) {
        countSize++;
        increment(countSize-1, false);
        list[countSize-1] = o;
    }

    public void remove (Position p) {
        countSize--;
        decrement(search(p));
    }

    public void printList () {
        if (countSize == 0) {
            Console.WriteLine("Lista vazia coleguinha!");
        }
        else {
            for (int i = 0; i < countSize; i++) {
                Console.Write($" [{list[i]}]");
            }
            Console.WriteLine();
        }
    }
}

class Program {
    public static void Main () {
        ListArray list = new ListArray();
        list.printList(); // Lista vazia coleguinha
        Console.WriteLine(list.size()); // 0
        Console.WriteLine(list.isEmpty()); // true
        list.insertFirst(1); //
        list.printList(); // [ 1 ]
        list.insertLast(2); //
        list.printList(); // [ 1 2 ]
        Position p1 = new Position(list.first()); // 
        Position p2 = new Position(list.last()); // 
        Console.WriteLine(list.before(p2)); // 1
        Console.WriteLine(list.after(p1)); // 2
        Console.WriteLine(list.first()); // 1
        Console.WriteLine(list.last()); // 2
        //list.replaceElement(p1, 0); //
        //list.printList();
        //p1 = new Position(0);
        //list.swapElements(p1, p2); //
        //list.printList();
        list.insertBefore(p2, 1); //
        list.printList();
        list.insertAfter(p2, 3); //
        list.printList();
        list.remove(p1); //
        list.printList(); // [ 1 0 3 ]
    }
}