using System;

public class Node{
    public int data;
    public Node Next;

    private Node(){}

    public Node(int data){
        this.data = data;
        this.Next = null;
    }

}


public class SingleLinkList{

    public Node Head;

    public Node Last;

    public void MakeCycle(){
        Head = new Node(1);
        Node two = new Node(2);
        Node three = new Node(3);
        Node four = new Node(4);
        Node five = new Node(5);
        Node six = new Node(6);
        Node seven = new Node(7);
        Node eight = new Node(8);
        Node nine = new Node(9);
        Node ten = new Node(10);
        Head.Next = two;
        two.Next = three;
        three.Next = four;
        four.Next = five;
        five.Next = six;
        six.Next = seven;
        seven.Next = eight;
        eight.Next = nine;
        nine.Next = ten;
        ten.Next = seven;


    }

    public Node FindStartCycle(){
         if(Head == null ||Head.Next == null)
            return null;
        
        Node front = Head;
        Node back = Head;

        while(front != null){
            front = front.Next;
            if(front != null){
                front = front.Next;
                back = back.Next;
            }

            if(front == back)
                break;
        }

        if(front == null)
            return null;

        // There is definitely a cycle
        // Move front to head and start moving both front
        // and back by one. Whereever they meet again
        // is start of cycle

        front = Head;

        while(front != back){

            front = front.Next;
            back = back.Next;
        }

        return back;


        



    }



    public void AddDataHead(int data){
        Node add = new Node(data);
        add.Next = Head;
        Head = add;
        Last = add;

    }

    public void AddDataTail(int data){
        Node add = new Node(data);

        if(Head == null){
            Head = add;
            return;
        }
        Node temp = Head;
        while(temp.Next != null){
            temp = temp.Next;
        }
        temp.Next = add;
        Last = add;
    }

    public void PrintList(){
        if(Head == null)
            return;
        
        Node temp = Head;

        while(temp != null){
            Console.Write(temp.data + "->");
            temp = temp.Next;
        }
        Console.WriteLine("Null");

    }

    public int GetLength(){
        if(Head == null)
            return 0;
        
        Node temp = Head;
        int count = 1;

        while(temp.Next != null){
            temp = temp.Next;
            count ++;
        }
        
        return count;

    }

    public Node FindMid(){
        if(Head == null || Head.Next == null)
            return Head;
        
        Node front = Head;
        Node back = Head;

        while(front.Next != null){
            front = front.Next;
            if(front.Next != null)
            {
                front = front.Next;
                back = back.Next;
            }
        }

        return back;
    }


    public bool Ispalindrome(){
        if(Head == null || Head.Next == null)
            return true;
        
        Node second = BreakListInMiddle();

        second = Reverse(second);

        Node temp1 = Head;
        Node temp2 = second;

        bool palindrome = true;

        while(temp1 != null || temp2 != null){

            if(temp1.data != temp2.data){
                palindrome = false;
                break;
            }
            temp1 = temp1.Next;
            temp2 = temp2.Next;
        }

        // put the list back
        second = Reverse(second);

        temp1 = Head;
        while(temp1.Next != null)
            temp1 = temp1.Next;
        
        temp1.Next = second;

        return palindrome;


    }


    public Node SortedMerge(Node node1, Node node2){

        Node result = null;

        if(node1 == null)
            return node2;

        if(node2 == null)
            return node1;
        
        if(node1.data < node2.data){
            result = node1;
            result.Next = SortedMerge(node1.Next, node2);
        }
        else{
            result = node2;
            result.Next = SortedMerge(node1, node2.Next);
        }
        return result;
    }

    public void ZipMerge(){

        Node second = BreakListInMiddle();
        Node first = Head;
        second = Reverse(second);

        Head = ZipMerge(first, second, true);

    }

    public Node ZipMerge(Node node1, Node node2, bool bSwitch){

        Node result = null;
        if(node1 == null)
            return node2;
        if(node2 == null)
            return node1;
        if(bSwitch == true){
            result = node1;
            result.Next = ZipMerge(node1.Next, node2, false);
        }else{
            result = node2;
            result.Next = ZipMerge(node1, node2.Next, true);

        }
        return result;

    }


        public Node BreakListInMiddle(){
        if(Head == null || Head.Next == null)
            return Head;
        
        Node front = Head;
        Node back = Head;

        while(front.Next != null){
            front = front.Next;
            if(front.Next != null)
            {
                front = front.Next;
                back = back.Next;
            }
        }
        Node temp = back.Next;
        back.Next = null;
        return temp;

    }

    public Node Reverse( Node node){
        if(node == null || node.Next == null)
            return null;
        
        Node Back = null;
        Node Mid = node;
        Node Front = node.Next;

        while(Front != null){
            Mid.Next = Back;
            Back = Mid;
            Mid = Front;
            Front = Front.Next;
        }

        Mid.Next = Back;
        node = Mid;
        return node;
    }

    public void ReverseList(){
        if(Head == null || Head.Next == null)
            return;
        
        Node Back = null;
        Node Mid = Head;
        Node Front = Head.Next;

        while(Front != null){
            Mid.Next = Back;
            Back = Mid;
            Mid = Front;
            Front = Front.Next;
        }

        Mid.Next = Back;
        Last = Head;
        Head = Mid;

    }

    public Node FindNthFromEnd(int n){

        if(Head == null)
            return null;
        
        if(n < 0)
            return null;
        
        Node Front = Head;
        Node Back = Head;

        for(int i = 0 ; i < n; i ++){
            Front = Front.Next;
            if(Front == null)
                return null;
        }

        while(Front != null){
            Front = Front.Next;
            Back = Back.Next;
        }
        return Back;
    }

    public bool IsCyclic(){
        if(Head == null ||Head.Next == null)
            return false;
        
        Node front = Head;
        Node back = Head;

        while(front != null){
            front = front.Next;
            if(front != null){
                front = front.Next;
                back = back.Next;
            }

            if(front == back)
                return true;
        }
        return false;

    }




}