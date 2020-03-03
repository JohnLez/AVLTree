using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTree
{
    class AVLTree
    {
        public Node Root { get; set; }
        public List<Node> Nodes { get; set; }

        public AVLTree()
        {
            Nodes = new List<Node>();
        }


        public void Insert(int number)
        {
            Root = RecursiveInsert(Root, number);
        }


        public int NodeHeight(Node node)
        {
            if (node == null)
                return 0;
            else
                return (int)node.Height;
        }

        public int Max(int x, int y)
        {
            return (x > y) ? x : y;
        }

        private Node RecursiveInsert(Node current, int number)
        {

            if (current == null)
            {
                current = new Node(number);
                return current;
            }
            else if (number < current.Value)
            {
                current.Left = RecursiveInsert(current.Left, number);
            }
            else if (number > current.Value)
            {
                current.Right = RecursiveInsert(current.Right, number);
            }
            else
                return current;

            current.Height = 1 + Max(NodeHeight(current.Left), NodeHeight(current.Right));

            int balance = NodeBalance(current);

            if (balance > 1 && number < current.Left.Value) //LL case
                return NodeRightRotate(current);

            if (balance < -1 && number > current.Right.Value) //RR case
                return NodeLeftRotate(current);

            if (balance > 1 && number > current.Left.Value) //LR case
            {
                current.Left = NodeLeftRotate(current.Left);
                return NodeRightRotate(current);
            }

            if (balance < -1 && number < current.Right.Value) //RL case
            {
                current.Right = NodeRightRotate(current.Right);
                return NodeLeftRotate(current);
            }

            return current;

        }

        private int NodeBalance(Node node)
        {
            if (node == null)
                return 0;
            else
                return NodeHeight(node.Left) - NodeHeight(node.Right);
        }

        private Node NodeRightRotate(Node n)
        {
            Node leftNode = n.Left;
            Node leftNodeRight = leftNode.Right;

            leftNode.Right = n;
            n.Left = leftNodeRight;

            n.Height = Max(NodeHeight(n.Left), NodeHeight(n.Right)) + 1;

            leftNode.Height = Max(NodeHeight(leftNode.Left), NodeHeight(leftNode.Right)) + 1;

            return leftNode;
        }

        private Node NodeLeftRotate(Node n)
        {
            Node rightNode = n.Right;
            Node nodeRightLeft = rightNode.Left;

            rightNode.Left = n;
            n.Right = nodeRightLeft;

            n.Height = Max(NodeHeight(n.Left), NodeHeight(n.Right)) + 1;
            rightNode.Height = Max(NodeHeight(rightNode.Left), NodeHeight(rightNode.Right)) + 1;

            return rightNode;
        }

        public void preOrder(Node node)
        {

            if (node != null)
            {
                Nodes.Add(node);
                preOrder(node.Left);
                preOrder(node.Right);
            }
        }


        public void Print()
        {
            preOrder(Root);
            var treeHeight = NodeHeight(Root);

            for (int i = treeHeight; i >= 1; i--)
            {
                for (int j = 0; j < Nodes.Count; j++)
                {
                    if (Nodes[j].Height == i)
                        Console.Write($" {Nodes[j].Value}\t");
                }
                Console.WriteLine();
            }
        }
    }
}