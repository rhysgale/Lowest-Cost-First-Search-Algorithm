namespace Lowest_Cost_First_Search
{
    class Node
    {
        //visual
        public string _NodeName { get; set; }
        public Vector2 _ScreenPosition { get; set; }

        //parent node
        public Node _ParentNode { get; set; }
        public int _Distance { get; set; }

        public Node(int x, int y, string name)
        {
            _ScreenPosition = new Vector2(x, y);
            _NodeName = name;
        }
    }
}
