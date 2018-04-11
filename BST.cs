

using System;

class Node{
    public int data { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public int height { get; set; }

    private Node(){}

    public Node(int data){

        this.data = data;
    }


}

class BST{

    public Node root { get; set; }

    public BST(){
        root= null;
        Initialize();
    }

    private void Initialize(){
        Node node = new Node(8);

        node.Left = new Node(3);
        node.Right = new Node(10);

        node.Left.Left = new Node(1);
        node.Left.Right = new Node(6);
        node.Left.Right.Left = new Node(4);
        node.Left.Right.Right= new Node(7);

        node.Right.Right = new Node(14);
        node.Right.Right.Left = new Node(13);

        root = node;


    }


    public void Insert2(int data){

        root = Insert(root, data);
    }

    private Node Insert(Node node, int data){

        if(node == null){

            return new Node(data);
        }

        if(data < node.data){
            node.Left = Insert(node.Left, data);
        }
        else{
            node.Right = Insert(node.Right, data);
        }
        return node;
    }

    public void ReverseInOrder(){

        ReverseInorder(root);
        Console.WriteLine();

    }
    private void ReverseInorder(Node node){

        if(node != null){
            ReverseInorder(node.Right);
            Console.Write(node.data + " " );
            ReverseInorder(node.Left);
        }
    }


    public void FindKthSmallest(int k){
        int count = 0;
        FindKthSmallest(root, k, ref  count);
    }

    private void FindKthSmallest(Node node, int k, ref  int count){

        if(node != null){

            FindKthSmallest(node.Left, k, ref count);
            count ++;

            if(count == k){

                Console.WriteLine("Kth smallest = " + node.data);
                return;
            }
            FindKthSmallest(node.Right, k,  ref count);
            
        }

    }


    public int countNumbersInRangfe(int low, int high){

        return CountNumbersInRange(root, low, high);

    }

    public int CountNumbersInRange(Node node,int low, int high){

        if(node == null)
            return 0;

        
        if(node.data <= high && node.data >= low)
            return 1 + CountNumbersInRange(node.Left, low, high) + 
                        CountNumbersInRange(node.Right, low, high);

        else if(node.data < low)
            return CountNumbersInRange(node.Right, low, high);
        else
            return CountNumbersInRange(node.Left, low,high);
    }

    public void ConvertBinaryTreeToBST(){

        if(root == null)
            return;

        int count = GetCount();

        int[] arr = new int[count];
        int ptr = 0;

        AddValesToArray(root, arr, ref ptr);

        Array.Sort(arr);

        ptr= 0;
        AddValuesInTree(root, arr, ref ptr);

        Console.WriteLine();





    }

    private void AddValuesInTree(Node node, int[] arr, ref int ptr){

        if(node != null){
            AddValuesInTree(node.Left, arr, ref ptr);

            node.data = arr[ptr];
            ptr ++;
            AddValuesInTree(node.Right,  arr, ref ptr);


        }
    }

    private void AddValesToArray(Node node, int[] arr, ref int ptr){

        if(node != null){
            
            AddValesToArray(node.Left, arr,  ref ptr);
            AddValesToArray(node.Right,arr,  ref ptr);
            arr[ptr] = node.data;
            ptr ++;

        }


    }

    public int GetCount(){
        return GetCount(root);
    }

    private int GetCount(Node node){
        if(node != null){

            return 1 + GetCount(node.Left) + GetCount(node.Right);
        }
        return  0;
    }
    
    

    public void Inorder(){

        Inorder(root);
        Console.WriteLine();
    }

    private void Inorder(Node node){

        if(node != null){
            Inorder(node.Left);
            Console.Write(node.data + " " );
            Inorder(node.Right);
        }
    }

    public void Insert(int data){

        if(root == null){
            root = new Node(data);
            return;

        }
        
        Node parent = null;
        Node current = root;

        while(current != null){

            parent = current;
            if(current.data > data)
                current = current.Left;
            else
                current = current.Right;

        }

        if(parent.data > data)
            parent.Left = new Node(data);
        
        else
            parent.Right = new Node(data);
    }

}