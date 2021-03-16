using System;

namespace SnakeGame
{   
    class Node
    {
       public Node next ;
       public char value ;

        public Node()
        {
            this.next = null ;
            this.value = " " ;
        }

        public void changeValue(char val)
        {
            this.value = val ;
        }

    }
    public struct Head 
    {
        Node head ;
        int row ;
        int coll ;

    }

    class GameArea 
    {
         public Node[,] nodeArr ;

        public GameArea(int row, int coll)
        {
            nodeArr = new Node[row,coll];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
