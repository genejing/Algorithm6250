
using System;
using System.Collections.Generic;

class Node{
    public Node Left;
    public Node Right;
    public int data;
    private Node(){}

    public Node(int data){
        this.data = data;
        this.Left = null;
        this.Right = null;
    }
}

class Tree{

    Node root;
    public Tree(){
        root = null;
        CreateTree();
    }

    private void CreateTree(){
        Node node = new Node(1);

        node.Left = new Node(2);
        node.Right = new Node(3);

        node.Left.Left = new Node(4);
        node.Left.Right = new Node(5);
        node.Right.Left = new Node(6);
        node.Right.Right = new Node(7);

        node.Left.Left.Left = new Node(8);
        node.Left.Left.Right = new Node(9);
        node.Left.Right.Right = new Node(10);
        node.Right.Right.Right = new Node(11);

        root = node;


    }
    public void PreOrder(){
        PreOrder(root);
        Console.WriteLine();
    }

    private void PreOrder(Node node1){
        if(node1 != null){
            Console.Write(node1.data + ",");
            PreOrder(node1.Left);
            PreOrder(node1.Right);
        }
    }

    public void PrintTopView(){
        Dictionary<int, int> dict = new  Dictionary<int,int>();
        
        PrintTopView(root, 0 ,  ref dict);

        Console.WriteLine();
    }

    private void PrintTopView(Node node1,  int col,  ref Dictionary<int, int> dict){
        if(node1 != null){
            if(!dict.ContainsKey(col))
                dict.Add(col, node1.data);

            PrintTopView(node1.Left, col -1 ,  ref dict);
            
            PrintTopView(node1.Right, col +1 , ref dict);
        }
    }

public void PrintAtKDistance( int k){
        PrintAtKDistance(root, k);
    }

    private void PrintAtKDistance(Node node1, int k ){

        if(node1 == null)
            return;
            
        if(k == 0)
                Console.WriteLine(node1.data );
        PrintAtKDistance(node1.Left, k - 1);
        PrintAtKDistance(node1.Right, k - 1);
        
    }


    public void PreOrderLeftOnly(){
        PreOrderLeftOnly(root);
    }

    private void PreOrderLeftOnly(Node node1){
        if(node1 != null){
            Console.WriteLine(node1.data );
            PreOrderLeftOnly(node1.Left);
        }
    }

    public void InOrder(){
        InOrder(root);
        Console.WriteLine();
    }

    private void InOrder(Node node1){
        if(node1 != null){
            InOrder(node1.Left);
            Console.Write(node1.data + ",");
            InOrder(node1.Right);
        }
    }

     public void PostOrder(){
        PostOrder(root);
        Console.WriteLine();
    }

    private void PostOrder(Node node1){
        if(node1 != null){
            PostOrder(node1.Left);
            PostOrder(node1.Right);
            Console.Write(node1.data + ",");
        }
    }

    public int GetSize(){
        return GetSize(root);
    }

    private int GetSize(Node node1){
        if(node1 == null)
            return 0;
        return  1 + GetSize(node1.Left) + GetSize(node1.Right);

    }

     public int GetSize1(){
        int size = 0;
        GetSize(root, ref size);
        return size;
    }

    private void GetSize(Node node1, ref int size){
        if(node1 != null){
            GetSize(node1.Left, ref size);
            GetSize(node1.Right, ref size);
            size ++;
        }
    }

    public int GetHeight(){
        return GetHeight(root);
    }

    private int GetHeight(Node node1){
        if(node1 == null)
            return 0;
        int leftHeight = GetHeight(node1.Left);
        int rightHeight = GetHeight(node1.Right);

        return 1 + Math.Max(leftHeight, rightHeight);
    }

    public void LevelOrder(){
        if(root == null)
            return;
        
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(root);
        queue.Enqueue(null);

        while(queue.Count != 0){

            Node node = queue.Dequeue();
            if(node != null){
                Console.Write(node.data + ",");
                if(node.Left != null)
                    queue.Enqueue(node.Left);
                if(node.Right != null)
                    queue.Enqueue(node.Right);
            }
            else{
                if(queue.Count == 0)
                    break;
                Console.WriteLine();
                queue.Enqueue(null);
            }
        }
        Console.WriteLine();
    }

public void PrintLeftView(){
        if(root == null)
            return;
        
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(root);
        queue.Enqueue(null);

        bool bPrint = true;

        while(queue.Count != 0){

            Node node = queue.Dequeue();
            if(node != null){
                if(bPrint == true){
                    Console.Write(node.data + ",");
                    bPrint = !bPrint;
                }
                if(node.Left != null)
                    queue.Enqueue(node.Left);
                if(node.Right != null)
                    queue.Enqueue(node.Right);
            }
            else{
                if(queue.Count == 0)
                    break;
                bPrint = true;
                Console.WriteLine();
                queue.Enqueue(null);
            }
        }
        Console.WriteLine();
    }


public void PrintRightView(){
        if(root == null)
            return;
        
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(root);
        queue.Enqueue(null);

        int prev = root.data;

        while(queue.Count != 0){

            Node node = queue.Dequeue();
            if(node != null){
                prev = node.data;
                if(node.Left != null)
                    queue.Enqueue(node.Left);
                if(node.Right != null)
                    queue.Enqueue(node.Right);
            }
            else{
                if(queue.Count == 0)
                    break;
                Console.Write(prev);
                Console.WriteLine();
                queue.Enqueue(null);
            }
        }
        Console.Write(prev );
        Console.WriteLine();
    }




    public void PrintZigZag(){
        if(root == null)
            return;
        
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(root);
        queue.Enqueue(null);
        Stack<Node> stack = new Stack<Node>();
        bool bPrint = true;

        while(queue.Count != 0){

            Node node = queue.Dequeue();
            if(node != null){
                if(bPrint == true)
                    Console.Write(node.data + ",");
                else
                    stack.Push(node);

                if(node.Left != null)
                    queue.Enqueue(node.Left);
                if(node.Right != null)
                    queue.Enqueue(node.Right);
            }
            else{
                if(queue.Count == 0)
                    break;
                bPrint = !bPrint;
                while(stack.Count != 0)
                    Console.Write(stack.Pop().data + ",");
                Console.WriteLine();
                queue.Enqueue(null);
            }
        }

         while(stack.Count != 0)
            Console.Write(stack.Pop().data + ",");

        Console.WriteLine();

    }

    public void PrintLeafNodes(){

        PrintLeafNodes(root);
        Console.WriteLine();
    }
    

    private void PrintLeafNodes(Node node){
        if(node != null){
            if(node.Left == null && node.Right == null)
                Console.Write(node.data + ",");
            PrintLeafNodes(node.Left);
            PrintLeafNodes(node.Right);
        }
    }

     private void PrintLeftNodes(Node node){
        if(node != null){
            Console.Write(node.data + ",");
            PrintLeftNodes(node.Left);
        }
    }

    public void PrintPerimeter(){
        if(root == null)
            return;
        Stack<Node> stack = new Stack<Node>();

        Console.Write(root.data + ",");
        PrintPerimeter(root, 0, 0, ref stack );
        while(stack.Count != 0)
            Console.Write(stack.Pop().data + ",");

        Console.WriteLine();
    }

    public void PrintPerimeter(Node node, int left, int right, ref Stack<Node> stack){
        if(node != null){

            if(right == 0  && left != 0)
                Console.Write(node.data + ",");
            else if(right != 0  && left == 0)
                stack.Push(node);
            else if(node.Left == null && node.Right == null)
                Console.Write(node.data + ",");
            PrintPerimeter(node.Left , left +1, right, ref stack);
            PrintPerimeter(node.Right , left, right +1, ref stack);
        }


    }





}
