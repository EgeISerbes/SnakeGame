using System;

namespace SnakeGame
{   
    enum States
    {   
        Idle,
        Up,
        Down,
        Left,
        Right,

    }
     public class Node
    {
       public Node next ;
       public char value ;

        public Node()
        {
            this.next = null ;
            this.value = ' ' ;
        }

        public void changeValue(char val)
        {
            this.value = val ;
        }

    }
    public struct Head 
    {
       public Node head ;
       public int Irow ;
       public int Icoll ;

    }

    class GameArea 
    {
         public Node[,] nodeArr ;
         public int row,coll ;
         public int score ;
        public GameArea()
        {
           
        }

        public void showArea()
        {
            string roof = new string('_',this.row+2);
            Console.WriteLine(roof);
            char sides = '|';
            string bottom = new string('T',row+2);
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
        public bool isOver = false ; 
        public bool isEdible = false;
        public GameSnake(int row, int coll)
        {   
            
            this.nodeArr = new Node[row,coll];
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

        public void StartGame()
        {
            States state = States.Idle ;
            addValue('o');
            addValue('x');
            showArea();
            while(true)
            {

            }
            
        }

        public void addValue(char val)
        {
            Random random = new Random() ;
            int randRow = random.Next(0,this.row)  ;
            int randColl = random.Next(0,this.coll);
            nodeArr[randRow,randColl].value = val;
            if (val == 'o'){
                head.head = nodeArr[randRow,randColl] ;
                head.Irow = randRow;
                head.Icoll = randColl ;
            }
        }

        public void goLeft()
        {
            int targetRow = head.Irow ;
            int targetColl = head.Icoll-1 ;
            if(nodeArr[targetRow,targetColl].value == 'o') 
            {
                isOver = true ;
                return ;
            }
            else if (nodeArr[targetRow,targetColl].value == 'x') isEdible = true ;
            nodeArr[targetRow,targetColl].next = head.head ;
            head.head = nodeArr[targetRow,targetColl] ;
            head.Icoll = targetColl ;
            if(!isEdible)
            {
                Node temp = new Node();
                temp = head.head ;
                while(temp.next.next != null)
                {
                    temp = temp.next ;
                }
                temp.next.value = '';
                temp.next = null ;

            }
        }
        public void goRight()
        {
            int targetRow = head.Irow ;
            int targetColl = head.Icoll+1 ;
            if(nodeArr[targetRow,targetColl].value == 'o') 
            {
                isOver = true ;
                return ;
            }
            else if (nodeArr[targetRow,targetColl].value == 'x') isEdible = true ;
            nodeArr[targetRow,targetColl].next = head.head ;
            head.head = nodeArr[targetRow,targetColl] ;
            head.Icoll = targetColl ;
            if(!isEdible)
            {
                Node temp = new Node();
                temp = head.head ;
                while(temp.next.next != null)
                {
                    temp = temp.next ;
                }
                temp.next.value = ' ';
                temp.next = null ;

            }
        }
        public void goUp()
        {
            int targetRow = head.Irow ;
            int targetColl = head.Icoll-1 ;
            if(nodeArr[targetRow,targetColl].value == 'o') 
            {
                isOver = true ;
                return ;
            }
            else if (nodeArr[targetRow,targetColl].value == 'x') isEdible = true ;
            nodeArr[targetRow,targetColl].next = head.head ;
            head.head = nodeArr[targetRow,targetColl] ;
            head.Icoll = targetColl ;
            if(!isEdible)
            {
                Node temp = new Node();
                temp = head.head ;
                while(temp.next.next != null)
                {
                    temp = temp.next ;
                }
                temp.next.value = ' ';
                temp.next = null ;

            }
        }
        public void goDown()
        {
            int targetRow = head.Irow +1 ;
            int targetColl = head.Icoll ;
            if(nodeArr[targetRow,targetColl].value == 'o') 
            {
                isOver = true ;
                return ;
            }
            else if (nodeArr[targetRow,targetColl].value == 'x') isEdible = true ;
            nodeArr[targetRow,targetColl].next = head.head ;
            head.head = nodeArr[targetRow,targetColl] ;
            head.Icoll = targetColl ;
            if(!isEdible)
            {
                Node temp = new Node();
                temp = head.head ;
                while(temp.next.next != null)
                {
                    temp = temp.next ;
                }
                temp.next.value = ' ';
                temp.next = null ;

            }
        }




    }


    class Program  
    {
        static void Main(string[] args)
        {
            GameSnake game = new GameSnake(9,9);
            game.StartGame();
        }
    }
}
