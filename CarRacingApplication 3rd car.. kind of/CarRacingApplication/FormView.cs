using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarRacingApplication
{
    public partial class FormView : Form
    {
        #region Fields
        //редовете и колоните на играта
        private int rows;
        private int cols;

        // началната точка на таблото
        private int startX;
        private int startY;
        //позицията на първата кола
        private int carX;
        private int carY;

        private int carXSec;
        private int carYSec;

        private int elementSize; // колко голяма да виждаш играта

        private int[,] matrixGame;

        private Random random; // кара черната кола да пада хаотично,т.е. не само в левия край на таблото
        private int myCarPosition;
        private int myCarPositionSecond;


        #endregion

        public FormView()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame() //въвежда размерите на колните,редовете и т.н.
        {
            rows = 16;
            cols = 9;
            startX = 50;
            startY = 50;
            elementSize = 20;
            matrixGame = new int[rows, cols];
            ResetGameBoard();
            random = new Random(31);
            myCarPosition = 3;
            myCarPositionSecond = 6;

            DrawCar(12, myCarPosition, 1); //мисля че рисува 2та кола,но нз защо каквото и да се промени от тях(5,myCarPosition и 1) 
                                           //нищо в играта не се променя

            DrawCar(12, myCarPositionSecond, 1);
        }

        private void FormView_Paint(object sender, PaintEventArgs e)
        {
            DrawGameBoard(e.Graphics);
        }

        private void DrawGameBoard(Graphics gameBoard) //прави таблото на играта като обхожда всеки ред и колона;рисува и 2те коли 
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    gameBoard.DrawRectangle(new Pen(Brushes.Brown), startX + col * elementSize, startY + row * elementSize,
                        elementSize, elementSize);
                    //оцветява първата кола
                    if (matrixGame[row, col] == 1)
                    {
                        gameBoard.FillRectangle(Brushes.Black, startX + col * elementSize, startY + row * elementSize,
                            elementSize, elementSize);
                        //оцветява втората кола
                    }
                    if (matrixGame[row, col] == 2)
                    {
                        gameBoard.FillRectangle(Brushes.Purple, startX + col * elementSize, startY + row * elementSize,
                            elementSize, elementSize);

                    }
                    if (matrixGame[row, col] == 3)
                    {
                        gameBoard.FillRectangle(Brushes.Beige, startX + col * elementSize, startY + row * elementSize,
                            elementSize, elementSize);

                    }
                }
            }
        }

        #region Funcions
        private void ResetGameBoard() //ако е свършило таблото на играта,т.е. е нарисувано цялото табло,заниулява колоните и редовете
                                      // и го започва от начало 
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrixGame[row, col] = 0;
                }
            }
        }
        //x->row, y->col  value->коя кола от 2те е
        private void DrawCar(int x, int y, int value) //рисува колата като я прави да изглежда нещо такова:
        {
            DrawPoint(x, y + 1, value);        //            #
            DrawPoint(x + 1, y + 1, value);    //           ###
            DrawPoint(x + 2, y + 1, value);    //            #
            DrawPoint(x + 3, y + 1, value);    //           ###
            DrawPoint(x + 1, y, value);
            DrawPoint(x + 1, y + 2, value);
            DrawPoint(x + 3, y, value);
            DrawPoint(x + 3, y + 2, value);
        }

        private void DrawPoint(int x, int y, int value) //проверява дали колата не излиза от рамките на играта
        {
            if (x < rows && x >= 0 && y < cols && y >= 0)
            {
                matrixGame[x, y] = value;
            }
        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e) //първата кола(черната) се движи надолу
        {
            ResetGameBoard();
            DrawCar(12, myCarPosition, 2);
           // ResetGameBoard();
            DrawCar(16, myCarPositionSecond, 3);//този ред разкарва бялото петно дето се лепеше за основната кола
            DrawCar(carX, carY, 1);
            DrawCar(carXSec, carYSec, 2);
            Invalidate();

            carXSec++;
            carX++;
            //тук пуска втората кола(лилавата падаща), но има проблем, от време на време пуска лилава, застъпваща се с черната и движеща се между линиите
            if (carXSec == rows)
            {
                
                carXSec = 0;
                carYSec = 0;

                carYSec = random.Next(0, 30);
                if (carYSec <= 10)
                {
                    carYSec = 0;

                }
                else if (carYSec >= 11 && carY <= 20)
                {
                    carYSec = 3;

                }
                else if (carYSec >= 21 && carY <= 30)
                {
                    carYSec = 6;

                }
            }

            if (carX == rows) 
            {
                carY = 0;
                carX = 0;
                carXSec = 0;
                carYSec = 0;
                carY = random.Next(0,30);
                carYSec = random.Next(0, 30);
             if (carY <= 10 )
                {
                    carY = 0;
                   
                }
                else if (carY >= 11 && carY <= 20)
                {
                    carY = 3;
                   
                }
                else if (carY >= 21 && carY <= 30)
                {
                    carY = 6;
                    
                }
            }
            CheckGame();
        }

        private void CheckGame() //ако едната кола удари другата играта спира
        {
            if (carX + 3 > 12 && carY == myCarPosition)
            {
                timerRacing.Enabled = false;
            }
        }

        private void FormView_KeyDown(object sender, KeyEventArgs e) //втората кола се движи наляво и надясно
        {

            if (e.KeyCode == Keys.Left && myCarPosition == 3)
            {
                myCarPositionSecond = 0;
                myCarPosition = 0;
            }
            else if (e.KeyCode == Keys.Left && myCarPosition == 6)
            {
                myCarPositionSecond = 3;
                myCarPosition = 3;
            }
            else if (e.KeyCode == Keys.Right && myCarPosition == 3)
            {
                myCarPositionSecond = 6;
                myCarPosition = 6;
            }
            else if (e.KeyCode == Keys.Right && myCarPosition == 0)
            {
                myCarPositionSecond = 3;
                myCarPosition = 3;
            }
        }

        private void FormView_MouseDoubleClick(object sender, MouseEventArgs e) //ако удариш другата кола,с двойно кликане на мишката 
                                                                                //в/у таблото рестартираш играта
        {
            carX = carY = 0;
            myCarPosition = 0;
            timerRacing.Enabled = true;
        }

        private void FormView_Load(object sender, EventArgs e)
        {

        }
    }
}