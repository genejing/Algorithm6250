

using System.Collections.Generic;

 class Node{

    private Node(){}

    public string name { get; private set; }
    public bool visited { get; set; }

    public List<Edge> listEdges { get; set; }

    public Node(string name){
        listEdges = new List<Edge>();
        this.name = name;
        this.visited = false;
    }

    public bool AddEdge( string endNode, int weight){

        for(int i = 0 ; i < listEdges.Count; i ++){
            if(listEdges[i].endNode == endNode)
                return false;
        }

        Edge edge = new Edge(this.name, endNode, weight);
        listEdges.Add(edge);
        return true;

    }

    public List<string> GetNeighbours(){

        List<string> neighbours = new List<string>();
        for(int i = 0 ; i < listEdges.Count ; i ++){
            neighbours.Add(listEdges[i].endNode);
        }
        return neighbours;
    }

    public int GetNumEdges(){
        return listEdges.Count;
    }
}