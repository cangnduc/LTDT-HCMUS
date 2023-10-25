class Cau2 {
    private string filePath;
    public Graph g;
    public Cau2(string filePath) {
        this.filePath = filePath;
        g = new Graph(filePath);
    }
}