using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTree
{
    class Program
    {
        static void Main(string[] args)
        {
            AVLTree tree = new AVLTree();

            tree.Insert(6);

            tree.Insert(12);
            tree.Insert(22);
            tree.Insert(3);
            tree.Insert(2);
            tree.Insert(7);
            tree.Insert(9);

            tree.Insert(10);
            tree.Insert(8);

            tree.Print();
        }
    }
}
