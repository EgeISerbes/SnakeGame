using System;

namespace SnakeGame
{   
    enum States
    {
        Up,
        Down,
        Left,
        Right,

    }
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
         public int row,coll ;
        public GameArea(int row1, int coll)
        {
            nodeArr = new Node[row,coll];
            this.row = row;
            this.coll = coll ;
            for (int i =0 ;i<row ; i++)
            {
                for(int j = 0; j<coll ; j++)
                {
                    nodeArr[i,j] = new Node() ;
                }
            }
        }

        public void showArea()
        {
            string roof = new string('_',this.row);
            Console.WriteLine(roof);
            char sides = '|';
            string bottom = new string('-',row);
            for(int i =0 ; i<row;i++)
            {
                Console.Write(sides);
                for(int j = 0 ; j< coll ; j++)
                {
                    Console.Write(nodeArr[i,j].value);
                }
                Console.Write(sides+"\n");
            }
            Console.WriteLine(bottom);
        }
    }

    class GameSnake : GameArea
    {
        public Head head ;
        public GameSnake()
        {
            
        }

        public void StartGame()
        {

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
