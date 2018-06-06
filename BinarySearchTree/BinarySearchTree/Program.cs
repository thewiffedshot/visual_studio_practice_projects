using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class Program
    {
        static int[] data = new int[32];
        static Queue<int> queue = new Queue<int>();
        static TreeNode root;
        static object[][] rowValues;

        static readonly uint treeDepth = 4; // NOTE: Starts from level 0. The tree consists of (treeDepth + 1) levels.

        static void Main(string[] args)
        {
            PopulateData(data);                       // Generate graph data...
            root = new TreeNode(data[0]);             // Use first element from queue to initialize the root value.
            queue.Dequeue();                          // Remove said first element from the queue.
            PopulateTree(root, treeDepth);            // Generate a tree with 'n' levels (starting from 0th)...
            rowValues = new object[root.depth + 1][]; // Set the rows to the appropriate depth of the primary tree.
            TraverseLevelValues(root, 0, rowValues);  // Traverse tree with the given array to populate it with the values. 
                                                      // *Optional step. Don't have to do this to draw tree, but convenient data.*
            try
            {
                DrawTree(root, 0, 260);
            } catch (Exception ex)
            {
                Console.Write(ex);
            }

            Console.ReadKey();
        }

        static void PopulateData(int[] array)
        {
            Random randy = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                int value = randy.Next(1, array.Length * 2 + 1);

                while (array.Contains(value))
                {
                    value = randy.Next(1, array.Length * 2 + 1);
                }

                array[i] = value;
            }

            //SortArray(data);

            foreach (int num in data)
            {
                queue.Enqueue(num);
            }
        }

        static void SortArray(int[] array)
        {
            bool sorted = true;

            do
            {
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i - 1] > array[i])
                    {
                        int ph = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = ph;

                        sorted = false;
                    }
                }
            }
            while (!sorted);
        }

        static void PopulateTree(TreeNode parent, uint depth)
        {
            if (parent != null) parent.depth = depth;
            else return;
            if (depth == 0) return;

            int[] values = new int[2];
            values[0] = int.MinValue;
            values[1] = int.MinValue;

            if (queue.Count != 0)
            {
                values[0] = queue.Dequeue();
            }

            if (queue.Count != 0)
            {
                values[1] = queue.Dequeue();
            }

            if ((values[0] < (int)(parent.value) && values[1] < (int)(parent.value)) || (values[0] > (int)(parent.value) && values[1] > (int)(parent.value)))
            {
                if (values[0] <= values[1])
                {
                    if (values[0] != int.MinValue)
                        parent.left = new TreeNode(values[0]);
                    if (values[1] != int.MinValue)
                        parent.right = new TreeNode(values[1]);
                }
                else
                {
                    if (values[0] != int.MinValue)
                        parent.right = new TreeNode(values[0]);
                    if (values[1] != int.MinValue)
                        parent.left = new TreeNode(values[1]);
                }
            }
            else if (values[0] < (int)(parent.value))
            {
                if (values[0] != int.MinValue)
                    parent.left = new TreeNode(values[0]);
                if (values[1] != int.MinValue)
                    parent.right = new TreeNode(values[1]);
            }
            else if (values[1] < (int)(parent.value))
            {
                if (values[1] != int.MinValue)
                    parent.left = new TreeNode(values[1]);
                if (values[0] != int.MinValue)
                    parent.right = new TreeNode(values[0]);
            }

            if (parent != null)
            {
                PopulateTree(parent.left, depth - 1);
                PopulateTree(parent.right, depth - 1);
            }
            else return;
        }

        static void DrawTree(TreeNode _root, int _cursorY, int _spacesFromParent)
        {
            int headway = _spacesFromParent;

            // Calculate additional buffer headway
            for (int i = 1; i <= root.depth; i++)
            {
                headway += ((int)Math.Sqrt(headway) + 1);
            }

            headway *= 2;

            // Make sure the buffer can fit the tree. 
            
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

            try
            {
                Console.BufferWidth = headway + 15; // Leaving some wiggle room for writing and whatnot.
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.SetWindowSize(headway + 15, Console.LargestWindowHeight);
                Console.BufferWidth = headway + 15;
            }

            Console.CursorLeft = Console.BufferWidth / 2;
            Console.Write((int)(_root.value));
            Console.CursorLeft -= ((int)(_root.value)).ToString().Length;

            if (_root.left == null && _root.right == null) return;
            DrawTreeUtil(_root, Console.BufferWidth / 2, _cursorY, _spacesFromParent);
        }

        static void DrawTreeUtil(TreeNode root, int cursorX, int cursorY, int spacesFromParent)
        {
            if (root == null) return;
            else if (root.left != null && spacesFromParent < ((int)(root.left.value)).ToString().Length + 1)
            {
                throw new FormatException("Not enough space from parent for the twin nodes to not overlap. Aborting drawing...");
            }

            // root.left
            if (root.left != null)
            {
                Console.CursorTop = cursorY + 2;
                Console.CursorLeft = cursorX;
                Console.CursorLeft -= spacesFromParent;
                Console.Write((int)(root.left.value));
                Console.CursorLeft -= ((int)(root.left.value)).ToString().Length;

                DrawTreeUtil(root.left, Console.CursorLeft, Console.CursorTop, (int)Math.Ceiling(Math.Sqrt(spacesFromParent)));
            }

            // root.right
            if (root.right != null)
            {
                Console.CursorTop = cursorY + 2;
                Console.CursorLeft = cursorX;
                Console.CursorLeft += spacesFromParent;
                Console.Write((int)(root.right.value));
                Console.CursorLeft -= ((int)(root.right.value)).ToString().Length;

                DrawTreeUtil(root.right, Console.CursorLeft, Console.CursorTop, (int)Math.Ceiling(Math.Sqrt(spacesFromParent)));
            }
        }

        static void TraverseLevelValues(TreeNode root, uint depth, object[][] _rowValues) // Must get jagged array with initialized first part 
        {                                                                                 // (aka. the amount of rows the tree has)
            int i;

            if (_rowValues[depth] == null)
            {
                _rowValues[depth] = new object[(int)Math.Pow(2, depth)];
                for (i = 0; i < _rowValues[depth].Length; i++)
                {
                    _rowValues[depth][i] = int.MinValue;
                }
            }

            for (i = 0; i < _rowValues[depth].Length; i++)
            {
                if ((int)_rowValues[depth][i] == int.MinValue)
                {
                    _rowValues[depth][i] = root.value;
                    break;
                }
            }

            if (root.left != null)
            TraverseLevelValues(root.left, depth + 1, _rowValues);
            if (root.right != null)
            TraverseLevelValues(root.right, depth + 1, _rowValues);
        }
    }
}
