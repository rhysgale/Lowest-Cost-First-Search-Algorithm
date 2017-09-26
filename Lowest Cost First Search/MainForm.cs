using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lowest_Cost_First_Search
{
    public partial class MainForm : Form
    {
        //storage for the main part
        Vector2 _NodeSize;
        List<Node> _NodeList;
        List<Path> _PathList;

        //Bit for the algorithm to find the best path!
        List<Node> _OpenNodes = new List<Node>();
        List<Node> _ClosedNodes = new List<Node>();
        Node _CurrentNode;
        Node _EndNode;
        Node _StartNode;

        public MainForm()
        {
            _NodeSize = new Vector2(100, 25);
            _NodeList = new List<Node>();
            _PathList = new List<Path>();

            InitializeComponent();

            InitialiseNodes();
            InitialisePaths();
            DrawNodes(false);
            DrawDistanceLabels(false);
        }

        //==================================shortest path first algorithm!============================================
        public void ShortestPathFirst(string startNode, string endNode)
        {
            _CurrentNode = GetNodeByName(startNode);
            _StartNode = _CurrentNode;
            _EndNode = GetNodeByName(endNode);
            _OpenNodes.Add(_CurrentNode);

            ShortestPathFirst(); //call recursive function
        }

        public void ShortestPathFirst()
        {
            ExpandNode(_CurrentNode); //expand the node, close the node, open the new nodes

            _CurrentNode = FindShortestPath(); //get the shortest node

            if (IsEndNode(_EndNode, _CurrentNode))
            {
                Node cur = _CurrentNode;
                string path = "";

                while (cur != _StartNode)
                {
                    path = " ==> " + cur._NodeName + path;
                    cur = cur._ParentNode;
                }
                path = cur._NodeName + path;

                MessageBox.Show("Distance: " + _CurrentNode._Distance.ToString() + " Path Used: " + path);
                Reset();
                return;
            }
            else
            {
                ShortestPathFirst(); //must go again!
            }
        }

        private void ExpandNode(Node expandable)
        {
            foreach (Path edge in _PathList) //get each path
            {
                if (edge.locationA == expandable && !_ClosedNodes.Contains(edge.locationB)) //if edge joins expandable node to non closed node
                {
                    if (edge.locationB._Distance > edge.distance + expandable._Distance || edge.locationB._Distance == 0) //make sure not already a distance
                    {
                        edge.locationB._Distance = edge.distance + expandable._Distance; //add on the distance
                        edge.locationB._ParentNode = expandable; //change parent
                    }

                    if (!_OpenNodes.Contains(edge.locationB))
                    {
                        _OpenNodes.Add(edge.locationB); //open node for expansion
                    }
                }
                else if (edge.locationB == expandable && !_ClosedNodes.Contains(edge.locationA)) //if edge joins expandable node to non closed node
                {
                    if (edge.locationA._Distance > edge.distance + expandable._Distance || edge.locationA._Distance == 0) //make sure not already a distance
                    {
                        edge.locationA._Distance = edge.distance += expandable._Distance; //add on the distance
                        edge.locationA._ParentNode = expandable; //set parent node to the node we expanded
                    }

                    if (!_OpenNodes.Contains(edge.locationA))
                    {
                        _OpenNodes.Add(edge.locationA); //open node for expansion
                    }
                }
            }

            _OpenNodes.Remove(expandable); //remove from list of open nodes
            _ClosedNodes.Add(expandable); //close the node
        }

        private void Reset()
        {
            _OpenNodes.Clear();
            _ClosedNodes.Clear();

            foreach (Node location in _NodeList)
            {
                location._Distance = 0;
            }
        }
            
        private Node FindShortestPath()
        {
            Node shortest = null;
            foreach (Node location in _OpenNodes) //in each of the open nodes
            {
                if (shortest == null || location._Distance < shortest._Distance) //if node is shortest
                {
                    shortest = location;
                }
            }
            return shortest;
        }

        private bool IsEndNode(Node end, Node current)
        {
            return end == current;
        }

        //======================Get the current Node class by node name!=========================
        private Node GetNodeByName(string name)
        {
            foreach (Node location in _NodeList)
            {
                if (location._NodeName.ToLower() == name.ToLower())
                {
                    return location;
                }
            }
            return null;
        }

        //==========================Create initial nodes======================================
        public void InitialiseNodes()
        {
            _NodeList.Add(new Node(500, 100, "Long Eaton"));
            _NodeList.Add(new Node(250, 200, "Breaston"));
            _NodeList.Add(new Node(750, 200, "Chilwell"));
            _NodeList.Add(new Node(500, 300, "Beeston"));
            _NodeList.Add(new Node(300, 400, "Derby Centre"));
        }

        //==========================Create some paths!=========================================
        public void InitialisePaths()
        {
            CreatePath("Long Eaton", "Breaston", 12);
            CreatePath("Long Eaton", "Chilwell", 15);
            CreatePath("Long Eaton", "Beeston", 20);
            CreatePath("Chilwell", "Beeston", 10);
            CreatePath("Breaston", "Beeston", 15);
            CreatePath("Beeston", "Derby Centre", 30);
            CreatePath("Breaston", "Derby Centre", 10);        
        }

        //=================================================Below method is for creating paths by specifying names rather than indexes!=============================================
        public void CreatePath(string locationA, string locationB, int distance)
        {
            Node start = null;
            Node end = null;

            foreach (Node location in _NodeList)
            {
                if (location._NodeName.ToLower() == locationA.ToLower())
                {
                    start = location;
                }
                else if (location._NodeName.ToLower() == locationB.ToLower())
                {
                    end = location;
                }
                else if (start != null && end != null)
                {
                    break;
                }
            }

            _PathList.Add(new Path(start, end, distance));
        }


        //===================================Below methods are for presentation only!=======================================
        public void DrawNodes(bool dynamicNode)
        {
            if (!dynamicNode)
            {
                foreach (Node location in _NodeList)
                {
                    Button node = new Button();
                    node.Click += new EventHandler(CreateNewPath);
                    node.Height = _NodeSize._Y;
                    node.Width = _NodeSize._X;
                    node.Text = location._NodeName;
                    node.Location = new Point(location._ScreenPosition._X, location._ScreenPosition._Y);

                    Controls.Add(node);
                }
            }
            else
            {
                Node location = _NodeList[_NodeList.Count - 1];
                Button node = new Button();

                node.Click += new EventHandler(CreateNewPath);
                node.Height = _NodeSize._Y;
                node.Width = _NodeSize._X;
                node.Text = location._NodeName;
                node.Location = new Point(location._ScreenPosition._X, location._ScreenPosition._Y);

                Controls.Add(node);
            }
                 
        }

        private void DrawEdges(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                foreach (Path edge in _PathList)
                {
                    var p = new Pen(Color.Black, 2);
                    Point locA = new Point(edge.locationA._ScreenPosition._X + (_NodeSize._X / 2), edge.locationA._ScreenPosition._Y + (_NodeSize._Y / 2));
                    Point locB = new Point(edge.locationB._ScreenPosition._X + (_NodeSize._X / 2), edge.locationB._ScreenPosition._Y + (_NodeSize._Y / 2));
                    g.DrawLine(p, locA, locB);
                }
            }
        }

        private void DrawDistanceLabels(bool dynamic)
        {
            if (!dynamic)
            {
                foreach (Path edge in _PathList)
                {
                    Button label = new Button();
                    label.BackColor = Color.Red;
                    label.Width = 30;
                    label.Text = edge.distance.ToString();

                    int x = 0;
                    int y = 0;

                    int locAx = edge.locationA._ScreenPosition._X;
                    int locAy = edge.locationA._ScreenPosition._Y;

                    int locBx = edge.locationB._ScreenPosition._X;
                    int locBy = edge.locationB._ScreenPosition._Y;

                    if (locAx < locBx)
                    {
                        x = locAx + ((locBx - locAx) / 2);
                    }
                    else
                    {
                        x = locBx + ((locAx - locBx) / 2);
                    }

                    if (locAy < locBy)
                    {
                        y = locAy + ((locBy - locAy) / 2);
                    }
                    else
                    {
                        y = locBy + ((locAy - locBy) / 2);
                    }

                    label.Location = new Point(x, y);
                    Controls.Add(label);
                }
            }
            else //is dynamic
            {
                Path edge = _PathList[_PathList.Count - 1];

                Button label = new Button();
                label.BackColor = Color.Red;
                label.Width = 30;
                label.Text = edge.distance.ToString();

                int x = 0;
                int y = 0;

                int locAx = edge.locationA._ScreenPosition._X;
                int locAy = edge.locationA._ScreenPosition._Y;

                int locBx = edge.locationB._ScreenPosition._X;
                int locBy = edge.locationB._ScreenPosition._Y;

                if (locAx < locBx)
                {
                    x = locAx + ((locBx - locAx) / 2);
                }
                else
                {
                    x = locBx + ((locAx - locBx) / 2);
                }

                if (locAy < locBy)
                {
                    y = locAy + ((locBy - locAy) / 2);
                }
                else
                {
                    y = locBy + ((locAy - locBy) / 2);
                }

                label.Location = new Point(x, y);
                Controls.Add(label);
            }
        }

        //==============================Dynamic Stuff===================================
        //==========================Dynamically create nodes============================
        private void CreateNode(object sender, MouseEventArgs e)
        {
            InputForm chooseName = new InputForm(false);

            int nodePosX = e.X;
            int nodePosY = e.Y;
            string nodeName;

            using (chooseName)
            {
                if (chooseName.ShowDialog() == DialogResult.OK)
                {
                    nodeName = chooseName._NodeName;
                }
                else
                {
                    return;
                }
            }

            _NodeList.Add(new Node(nodePosX, nodePosY, nodeName));
            DrawNodes(true);
        }

        //==================================Dynamically Create Paths========================================

        string nodeName = null;
        private void CreateNewPath(object sender, EventArgs e)
        {
            if (nodeName == null)
            {
                nodeName = ((Button)sender).Text;
            }
            else
            {
                //we can create new path!
                InputForm distance = new InputForm(true);
                using (distance)
                {
                    if (distance.ShowDialog() == DialogResult.OK)
                    {
                        CreatePath(GetNodeByName(nodeName)._NodeName, GetNodeByName(((Button)sender).Text)._NodeName, distance._Distance);
                        DrawDistanceLabels(true);
                        Refresh();
                        nodeName = null;
                    }
                    else
                    {
                        nodeName = null;
                    }
                }
            }
        }

        private void ShortestPathButton_Clicked(object sender, EventArgs e)
        {
            ShortestPathFirst(StartNodeTextBox.Text, EndNodeTextBox.Text);
        }
    }
}
