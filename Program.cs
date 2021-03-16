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
        public bool isOffLimits = false ;
        public States state = States.Idle ;
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
            
            addValue('o');
            addValue('x');
            showArea();
          //  while(true)
           // {
                goRight();
                showArea();
                goLeft();
                showArea();
                goUp();
                showArea();
                goDown();
                showArea();
                
            //}
            
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
            state = States.Left ;
            int targetRow = head.Irow ;
            int targetColl = head.Icoll-1 ;
            if(targetColl < 0) isOffLimits = true ;
            go(targetRow,targetColl);
        }
        public void goRight()
        {   
            state = States.Right ;
            int targetRow = head.Irow ;
            int targetColl = head.Icoll+1 ;
            if(targetColl >=this.coll) isOffLimits = true ;
            go(targetRow,targetColl);
        }
        public void goUp()
        {   
            state = States.Up ;
            int targetRow = head.Irow-1 ;
            int targetColl = head.Icoll ;
            if(targetRow < 0) isOffLimits = true ;
            go(targetRow,targetColl);
        }
        public void goDown()
        {   
            state = States.Down ;
            int targetRow = head.Irow +1 ;
            int targetColl = head.Icoll ;
            if(targetRow>=this.row) isOffLimits = true ;
            go(targetRow,targetColl);
        }

        public void go(int targetRow, int targetColl)
        {   
            if(isOffLimits)
            {
                if (state == States.Left)
                {
                    targetColl = coll-1 ;
                }
                else if (state == States.Right)
                {
                    targetColl = 0 ;
                }
                else if (state == States.Up)
                {
                    targetRow = 0;
                }
                else if (state == States.Down)
                {
                    targetRow = row-1 ;
                }
            }
            if(nodeArr[targetRow,targetColl].value == 'o') 
            {
                isOver = true ;
                return ;
            }
            else if (nodeArr[targetRow,targetColl].value == 'x') isEdible = true ;
            nodeArr[targetRow,targetColl].next = head.head ;
            nodeArr[targetRow,targetColl].value = 'o';
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
