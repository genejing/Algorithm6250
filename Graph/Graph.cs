

using System;
using System.Collections.Generic;

class Graph{

    public string startNode { get; set; }
    public Dictionary<string, Node> nodes { get; set; }

    public Graph(){

        this.startNode = "";
        nodes = new Dictionary<string, Node>();

        Initialize();


    }


    private void Initialize(){

        Node A = new Node("A");
        Node B = new Node("B");
        Node C = new Node("C");
        Node D = new Node("D");
        Node E = new Node("E");
        Node F = new Node("F");
        Node G = new Node("G");

        A.AddEdge("B", 1);

        B.AddEdge("C", 1);
        B.AddEdge("D", 1);
        B.AddEdge("E", 1);

        C.AddEdge("E", 1);

        D.AddEdge("E", 1);

        E.AddEdge("F",1);

        G.AddEdge("D",1);

        nodes.Add("A", A);
        nodes.Add("B", B);
        nodes.Add("C", C);
        nodes.Add("D", D);
        nodes.Add("E", E);
        nodes.Add("F", F);
        nodes.Add("G", G);
    }

    public void SetStartNode(string startNode){

        if(nodes.ContainsKey(startNode))
            this.startNode = startNode;
    }

    public void AddNode(Node node){

        if(nodes.ContainsKey(node.name))
            return;

        nodes.Add(node.name, node);

    }

    public void ResetVisited(){

        foreach(KeyValuePair <string, Node> kv in nodes)
            kv.Value.visited = false;
    }

    public void BreadthFirstSearch(string startNode){
        if(!nodes.ContainsKey(startNode))
            return;
        int counter = 1;
        Console.WriteLine("Starting Breadth first search from " + startNode);
        ResetVisited();
        Queue<Node>  queue = new Queue<Node>();

        queue.Enqueue(nodes[startNode]);
        queue.Enqueue(null);

        while(queue.Count != 0 ){
            Node node = queue.Dequeue();

            if(node != null){
                // If I have not visited the node
                if(!node.visited){
                    // set visited = true
                    // Print the node
                    // add all its neighbours to the queue
                    node.visited = true;
                    Console.Write(node.name + ", ");
                    for(int i = 0 ; i < node.listEdges.Count; i ++){
                        queue.Enqueue( nodes[ node.listEdges[i].endNode]);
                    }
                }
            }
            else{
                // we have reached next level
                // check if the queue is empty otherwise you will go in infinite loop
                if(queue.Count == 0)
                    break;
                // increment the level counter
                Console.WriteLine("Level #" + counter);
                counter ++;
                // enqueue another null
                queue.Enqueue(null);
            }

        }
        // to print the last level of elements
        Console.WriteLine();

    }


    public void PrintAllPaths( string source, string dest){

        HashSet<string> visited = new HashSet<string>();
        PrintPath(visited, source, dest);

    }

    public void PrintPath(HashSet<string> visited, string current, string dest ){

        if(visited.Contains(dest)){
            return;
        }
        // we have reached destination print the visited Hashset
        if(dest == current){
            foreach(string str in visited)
                Console.Write(str + ", ");
            Console.WriteLine(dest);
        }

        visited.Add(current);

        // get the current node and for all the edges 
        // call PrintPath recursively

        Node node = nodes[current];

        for(int i = 0 ; i < node.listEdges.Count; i ++){
            // if we have not visited this neighbour
            // call print path recursively
            if( !visited.Contains( node.listEdges[i].endNode ) ) {
                PrintPath( visited, node.listEdges[i].endNode, dest);
            }
        }

        visited.Remove(current);

    }


    public void DepthFirst(string startNode){
        if(!nodes.ContainsKey(startNode))
            return;

        ResetVisited();
        
        Stack<Node> stack = new Stack<Node>();

        stack.Push(nodes[startNode]);

        while(stack.Count != 0){

            Node node = stack.Pop();

            if(!node.visited){
                node.visited = true;
                Console.Write(node.name + ", ");

                for(int i = 0 ; i < node.listEdges.Count; i ++){
                    if(nodes[node.listEdges[i].endNode].visited != true){
                        stack.Push( nodes[ node.listEdges[i].endNode ] );
                    }
                }

            }
        }

        Console.WriteLine();


    }


        public bool IsReachable(string startNode, string endNode){

        if(!nodes.ContainsKey(startNode)||!nodes.ContainsKey(endNode) )
            return false;

        ResetVisited();
        Queue<Node>  queue = new Queue<Node>();

        queue.Enqueue(nodes[startNode]);


        while(queue.Count != 0 ){
            Node node = queue.Dequeue();

            if(node.name == endNode)
                return true;

            // If I have not visited the node
            if(!node.visited){
                // set visited = true
                // Print the node  
                // add all its neighbours to the queue
                node.visited = true;
                for(int i = 0 ; i < node.listEdges.Count; i ++){
                     queue.Enqueue( nodes[ node.listEdges[i].endNode]);
                }
            }
        }

        return false;

    }


    public bool IsHamiltonian(){

        List<string> result = new List<string>();

        bool bHamiltonian = Hamiltonian(ref result);

        if(bHamiltonian){
            // print the cycle

        }

        return bHamiltonian;
    }


    private bool Hamiltonian(ref List<string> result){

        string startNode = nodes.
    }


}