using System;
using System.Linq;
using System.Collections.Generic;

public class Node
{
    public int key;
    public Node left;
    public Node right;
    public Node(int x)
    {
        key = x;
    }
}

public class Btree
{
    public Node root;

    public void Insert(int x)
    {
        if (root == null)
            root = new Node(x);
        else
            insert(root, x);
    }
    private void insert(Node p, int x)
    {
        if (x < p.key)
            if (p.left == null)
                p.left = new Node(x);
            else
                insert(p.left, x);
        else
            if (p.right == null)
            p.right = new Node(x);
        else
            insert(p.right, x);
    }

    public void Print()
    {
        if(root != null)
        print(root, 0);

    }
    private void print(Node p, int shift)
    {
        if (p.right != null)
            print(p.right, shift + 1);

        for (int i = 0; i != shift; i++)
            Console.Write("__");
        Console.WriteLine(p.key);

        if (p.left != null)
            print(p.left, shift + 1);
    }
    public int GetMaxRec()
    {
        if (root != null)
            return findMax(root).key;
        else
            return -1;
    }
    private Node findMax(Node p)
    {
        return p.right != null ? findMax(p.right) : p;
    }
    public void ChangeTree()
    {
        root=buildTree(root);
    }
    private Node buildTree(Node p)
    {
        var nodes = new List<Node>();
        store(p, nodes);
        return build_from_nodes(nodes, 0, nodes.Count - 1); 
    }
    private void store(Node p, List<Node> nodes)
    {
        if (p == null)
            return;
        store(p.left, nodes);
        nodes.Add(p);
        store(p.right, nodes);
    }
    private Node build_from_nodes(List<Node> nodes, int start, int end)
    {
        if (start > end)
            return null;
        int mid = (start + end) / 2;
        Node p = nodes[mid];
        p.left = build_from_nodes(nodes, start, mid - 1);
        p.right = build_from_nodes(nodes, mid + 1, end);
        return p;
    }
    public int Height()
    {
        return height(root);
    }
    private int height(Node p)
    {
        if (p == null)
            return 0;
        return 1 + Math.Max(height(p.left), height(p.right));
    }
    //private override string ToString() => tostr(root).Item2;
    //private(int, string) tostr(Node p)
    //{
    //   return (1, "\n");
    //}
    public void Print2()
    {
        Console.WriteLine(tostr(root));
    }
    private string tostr(Node p)
    {
        if (p == null)
            return "\n";
        return " ";
    }
}


    class Program
{
        static void Main(string[] args)
    {
        var mytuple = new Tuple<int, char>(1, 't');

        var bt = new Btree();
        Random r = new Random();
        var arr =
        Enumerable.Range(0, 7).OrderBy(x => r.Next()).ToArray();
        foreach(var i in arr)
         bt.Insert(i);

        //bt.Insert(5);
        //bt.Insert(2);
        //bt.Insert(7);

        //bt.Insert(1);
        //bt.Insert(3);
        //bt.Insert(6);
        //bt.Insert(8);

        //bt.Print();
        bt.ChangeTree();
        bt.Print();
        //bt.Print2();

        //Console.WriteLine(bt.Height());
        //Console.Writeline(bt);

        // ___6
        // __5_
        // ___4
        // 3___
        // ___2
        // _1__
        // ___0

        // -1, -1, 6
        // -1, 5, -1
        // -1, -1, 4
        // 3, -1, -1
        // -1, -1, 4
    }
}

