

class Edge{

    private Edge(){}

    public string startNode { get; private set; }
    public string endNode { get; private set; }

    public int weight { get; private set; }

    public Edge(string startNode, string endNode, int weight){
        this.startNode = startNode;
        this.endNode = endNode;
        this.weight = weight;

    }

}