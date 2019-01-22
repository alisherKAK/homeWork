using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crafter22_01_19
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Workbench workbench = new Workbench();
            bool isFinish = false, isEnd = false;
            ConsoleKeyInfo info;

            while (true)
            {
                switch(Choice())
                {
                    case Constants.FIRST_CHOISE:
                        Console.Clear();
                        Console.Write(" Workbench   \n");
                        WorkbenchPrint(workbench);
                        while (true)
                        {
                            isFinish = false;
                            info = Console.ReadKey(true);
                            switch (info.Key)
                            {
                                case ConsoleKey.LeftArrow:
                                    if (Cursor.cursorXPosition != Constants.NULL)
                                    {
                                        Cursor.cursorXPosition--;
                                        WorkbenchPrint(workbench);
                                    }
                                    break;
                                case ConsoleKey.RightArrow:
                                    if (Cursor.cursorXPosition != workbench.WorkbenchTableLenth - Constants.LENTH_TO_INDEX)
                                    {
                                        Cursor.cursorXPosition++;
                                        WorkbenchPrint(workbench);
                                    }
                                    break;
                                case ConsoleKey.UpArrow:
                                    if (Cursor.cursorYPosition != Constants.NULL)
                                    {
                                        Cursor.cursorYPosition = Cursor.cursorYPosition - Constants.LENTH_TO_INDEX;
                                        WorkbenchPrint(workbench);
                                    }
                                    break;
                                case ConsoleKey.DownArrow:
                                    if (Cursor.cursorYPosition != workbench.WorkbenchTableWidth - Constants.LENTH_TO_INDEX)
                                    {
                                        Cursor.cursorYPosition = Cursor.cursorYPosition + Constants.LENTH_TO_INDEX;
                                        WorkbenchPrint(workbench);
                                    }
                                    break;
                                case ConsoleKey.Enter:
                                    Console.SetCursorPosition(Constants.MESSAGE_X_POSITION, Constants.MESSAGE_Y_POSITION);
                                    Console.Write(InstrumentsRecipe.CheckRecipe(workbench));
                                    while (true)
                                    {
                                        info = Console.ReadKey(true);
                                        if(info.Key == ConsoleKey.Escape || info.Key == ConsoleKey.Enter)
                                        {
                                            break;
                                        }
                                    }
                                    isFinish = true;
                                    workbench.Clear();
                                    Console.Clear();
                                    break;
                                case ConsoleKey.D0:
                                    workbench = workbench + Materials.NULL;
                                    WorkbenchPrint(workbench);
                                    break;
                                case ConsoleKey.D1:
                                    workbench += Materials.WOOD;
                                    WorkbenchPrint(workbench);
                                    break;
                                case ConsoleKey.D2:
                                    workbench = workbench + Materials.STONE;
                                    WorkbenchPrint(workbench);
                                    break;
                                case ConsoleKey.D3:
                                    workbench = workbench + Materials.IRON;
                                    WorkbenchPrint(workbench);
                                    break;
                                case ConsoleKey.D4:
                                    workbench = workbench + Materials.GOLD;
                                    WorkbenchPrint(workbench);
                                    break;
                                case ConsoleKey.D5:
                                    workbench = workbench + Materials.STICK;
                                    WorkbenchPrint(workbench);
                                    break;
                                case ConsoleKey.Escape:
                                    isFinish = true;
                                    Console.Clear();
                                    break;
                                default:
                                    WorkbenchPrint(workbench);
                                    break;
                            }
                            if (isFinish == true)
                            {
                                break;
                            }
                        }
                        break;
                    case Constants.SECOND_CHOISE:
                        Console.Clear();
                        Instruction();
                        break;
                    case Constants.THIRD_CHOISE:
                        Console.Clear();
                        InstrumentsRecipe.RecipeShow();
                        Console.Clear();
                        break;
                    case Constants.FOURTH_CHOISE:
                        Console.Clear();
                        isEnd = true;
                        break;
                }
                if(isEnd == true)
                {
                    break;
                }
            }
        }
        public static void WorkbenchPrint(Workbench workbench)
        {
            for (int i = 0, a = 0; i < Constants.FRAME_TOP_WIDTH; i++)
            {
                Console.SetCursorPosition(Constants.STANDART_CURSOR_X_POSITION, Constants.STANDART_CURSOR_Y_POSITION + i);
                for (int j = 0, b = 0; j < Constants.FRAME_TOP_LENTH; j++)
                {
                    if (i % Constants.TWO != Constants.NULL)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write('-');
                    }
                    else if (i % Constants.TWO == Constants.NULL && j % Constants.TWO != Constants.NULL)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write('|');
                    }
                    else if ( (a == Cursor.cursorYPosition && b == Cursor.cursorXPosition) && (i % Constants.TWO == Constants.NULL && j % Constants.TWO == Constants.NULL) )
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(workbench[a, b]);
                        Console.ForegroundColor = ConsoleColor.White;
                        b++;
                    }
                    else if (i % Constants.TWO == Constants.NULL && j % Constants.TWO == Constants.NULL)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(workbench[a, b]);
                        b++;
                    }

                }
                if(i % Constants.TWO != Constants.NULL)
                {
                    a++;
                }
                Console.WriteLine();
            }
        }
        public static void WorkbenchPrint(char[,] worckbenchTable, int tableWidth, int tableLenth, int xPosition, int yPosition)
        {
            for (int i = 0, a = 0; i < tableWidth; i++)
            {
                Console.SetCursorPosition(xPosition, yPosition + i);
                for (int j = 0, b = 0; j < tableLenth; j++)
                {
                    if (i % Constants.TWO != Constants.NULL)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write('-');
                    }
                    else if (i % Constants.TWO == Constants.NULL && j % Constants.TWO != Constants.NULL)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write('|');
                    }
                    else if (i == Cursor.cursorYPosition && j == Cursor.cursorXPosition)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(worckbenchTable[a, b]);
                        b++;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(worckbenchTable[a, b]);
                        b++;
                    }

                }
                if (i % Constants.TWO != Constants.NULL)
                {
                    a++;
                }
                Console.WriteLine();
            }
        }
        public static void Instruction()
        {
            ConsoleKeyInfo info;

            Console.Write("Instruction\n" +
                          "_____________________\n" +
                          "|1-Wood             |\n" +
                          "|2-Stone            |\n" +
                          "|3-Iron             |\n" +
                          "|4-Gold             |\n" +
                          "|5-Stick            |\n" +
                          "|___________________|\n" +
                          "|Up-Up Button       |\n" +
                          "|Down-Down Button   |\n" +
                          "|Left-Left Button   |\n" +
                          "|Right-Right Button |\n" +
                          "|Exit-Escape        |\n" +
                          "|___________________|");

            while (true)
            {
                info = Console.ReadKey();
                if(info.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    break;
                }
            }
        }
        public static int Choice()
        {
            ConsoleKeyInfo info;

            Console.Write("_______________________\n" +
                          "|                     |\n" +
                          "|  1-Начать крафтить  |\n" +
                          "|  2-Инструкция       |\n" +
                          "|  3-Рецепты          |\n" +
                          "|  4-Выход            |\n" +
                          "|_____________________|");

            while (true)
            {
                info = Console.ReadKey();
                switch (info.Key)
                {
                    case ConsoleKey.D1:
                        return Constants.FIRST_CHOISE;
                    case ConsoleKey.D2:
                        return Constants.SECOND_CHOISE;
                    case ConsoleKey.D3:
                        return Constants.THIRD_CHOISE;
                    case ConsoleKey.D4:
                    case ConsoleKey.Escape:
                        return Constants.FOURTH_CHOISE;
                    default:
                        break;
                }
            }
        }
    }
}
