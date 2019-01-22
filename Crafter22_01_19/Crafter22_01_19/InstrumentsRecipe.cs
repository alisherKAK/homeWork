using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crafter22_01_19
{
    public static class InstrumentsRecipe
    {
        #region Wood Instruments
        public static char[,] WoodShovelFirstRecipe = new char[,]{ { '1','0','0'}, {'5','0','0' }, { '5', '0', '0' } };
        public static char[,] WoodShovelSecondRecipe = new char[,] { { '0','1','0'}, {'0','5','0' }, { '0', '5', '0' } };
        public static char[,] WoodShovelThirdRecipe = new char[,] { { '0','0','1'}, {'0','0','5' }, { '0', '0', '5' } };
        public static char[,] WoodPickaxe = new char[,] { { '1', '1', '1' }, { '0', '5', '0' }, { '0', '5', '0' } };
        public static char[,] WoodAxe = new char[,] { { '1', '1', '0' }, { '1', '5', '0' }, { '0', '5', '0' } };
        public static char[,] WoodSwordFirstRecipe = new char[,] { { '1', '0', '0' }, { '1', '0', '0' }, { '5', '0', '0' } };
        public static char[,] WoodSwordSecondRecipe = new char[,] { { '0', '1', '0' }, { '0', '1', '0' }, { '0', '5', '0' } };
        public static char[,] WoodSwordThirdRecipe = new char[,] { { '0', '0', '1' }, { '0', '0', '1' }, { '0', '0', '5' } };
        #endregion

        #region Stone Instruments
        public static char[,] StoneShovelFirstRecipe = new char[,] { { '2', '0', '0' }, { '5', '0', '0' }, { '5', '0', '0' } };
        public static char[,] StoneShovelSecondRecipe = new char[,] { { '0', '2', '0' }, { '0', '5', '0' }, { '0', '5', '0' } };
        public static char[,] StoneShovelThirdRecipe = new char[,] { { '0', '0', '2' }, { '0', '0', '5' }, { '0', '0', '5' } };
        public static char[,] StonePickaxe = new char[,] { { '2', '2', '2' }, { '0', '5', '0' }, { '0', '5', '0' } };
        public static char[,] StoneAxe = new char[,] { { '2', '2', '0' }, { '2', '5', '0' }, { '0', '5', '0' } };
        public static char[,] StoneSwordFirstRecipe = new char[,] { { '2', '0', '0' }, { '2', '0', '0' }, { '5', '0', '0' } };
        public static char[,] StoneSwordSecondRecipe = new char[,] { { '0', '2', '0' }, { '0', '2', '0' }, { '0', '5', '0' } };
        public static char[,] StoneSwordThirdRecipe = new char[,] { { '0', '0', '2' }, { '0', '0', '2' }, { '0', '0', '5' } };
        #endregion

        #region Iron Instruments
        public static char[,] IronShovelFirstRecipe = new char[,] { { '3', '0', '0' }, { '5', '0', '0' }, { '5', '0', '0' } };
        public static char[,] IronShovelSecondRecipe = new char[,] { { '0', '3', '0' }, { '0', '5', '0' }, { '0', '5', '0' } };
        public static char[,] IronShovelThirdRecipe = new char[,] { { '0', '0', '3' }, { '0', '0', '5' }, { '0', '0', '5' } };
        public static char[,] IronPickaxe = new char[,]{ { '3', '3', '3' }, { '0', '5', '0' }, { '0', '5', '0' } };
        public static char[,] IronAxe = new char[,] { { '3', '3', '0' }, { '3', '5', '0' }, { '0', '5', '0' } };
        public static char[,] IronSwordFirstRecipe = new char[,] { { '3', '0', '0' }, { '3', '0', '0' }, { '5', '0', '0' } };
        public static char[,] IronSwordSecondRecipe = new char[,] { { '0', '3', '0' }, { '0', '3', '0' }, { '0', '5', '0' } };
        public static char[,] IronSwordThirdRecipe = new char[,] { { '0', '0', '3' }, { '0', '0', '3' }, { '0', '0', '5' } };
        #endregion

        #region Gold Instruments
        public static char[,] GoldShovelFirstRecipe = new char[,] { { '4', '0', '0' }, { '5', '0', '0' }, { '5', '0', '0' } };
        public static char[,] GoldShovelSecondRecipe = new char[,] { { '0', '4', '0' }, { '0', '5', '0' }, { '0', '5', '0' } };
        public static char[,] GoldShovelThirdRecipe = new char[,] { { '0', '0', '4' }, { '0', '0', '5' }, { '0', '0', '5' } };
        public static char[,] GoldPickaxe = new char[,] { { '4', '4', '4' }, { '0', '5', '0' }, { '0', '5', '0' } };
        public static char[,] GoldAxe = new char[,] { { '4', '4', '0' }, { '4', '5', '0' }, { '0', '5', '0' } };
        public static char[,] GoldSwordFirstRecipe = new char[,] { { '4', '0', '0' }, { '4', '0', '0' }, { '5', '0', '0' } };
        public static char[,] GoldSwordSecondRecipe = new char[,] { { '0', '4', '0' }, { '0', '4', '0' }, { '0', '5', '0' } };
        public static char[,] GoldSwordThirdRecipe = new char[,] { { '0', '0', '4' }, { '0', '0', '4' }, { '0', '0', '5' } };
        #endregion

        public static void RecipeShow()
        {
            ConsoleKeyInfo info;
            int recipe = Constants.RECIPE_NULL;
            Console.Clear();
            Console.Write("   Recipes   \n" +
                          "             \n" +
                          "             \n" +
                          "             \n" +
                          "             \n" +
                          "  <       >  \n" +
                          "             \n" +
                          "             \n" +
                          "             \n");
            Program.WorkbenchPrint(WoodShovelSecondRecipe, Constants.FRAME_TOP_WIDTH, Constants.FRAME_TOP_LENTH, Constants.STANDART_RECIPE_X_POSITION, Constants.STANDART_RECIPE_Y_POSITION);
            while (true)
            {
                info = Console.ReadKey();
                switch(info.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if(recipe != Constants.RECIPE_NULL)
                        {
                            recipe--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (recipe != Constants.RECIPE_COUNT)
                        {
                            recipe++;
                        }
                        break;
                    case ConsoleKey.Escape:
                        return;
                }

                switch (recipe)
                {
                    case 1:
                        Program.WorkbenchPrint(WoodShovelSecondRecipe, Constants.FRAME_TOP_WIDTH, Constants.FRAME_TOP_LENTH, Constants.STANDART_RECIPE_X_POSITION, Constants.STANDART_RECIPE_Y_POSITION);
                        break;
                    case 2:
                        Program.WorkbenchPrint(WoodPickaxe, Constants.FRAME_TOP_WIDTH, Constants.FRAME_TOP_LENTH, Constants.STANDART_RECIPE_X_POSITION, Constants.STANDART_RECIPE_Y_POSITION);
                        break;
                    case 3:
                        Program.WorkbenchPrint(WoodAxe, Constants.FRAME_TOP_WIDTH, Constants.FRAME_TOP_LENTH, Constants.STANDART_RECIPE_X_POSITION, Constants.STANDART_RECIPE_Y_POSITION);
                        break;
                    case 4:
                        Program.WorkbenchPrint(WoodSwordSecondRecipe, Constants.FRAME_TOP_WIDTH, Constants.FRAME_TOP_LENTH, Constants.STANDART_RECIPE_X_POSITION, Constants.STANDART_RECIPE_Y_POSITION);
                        break;
                    case 5:
                        Program.WorkbenchPrint(StoneShovelSecondRecipe, Constants.FRAME_TOP_WIDTH, Constants.FRAME_TOP_LENTH, Constants.STANDART_RECIPE_X_POSITION, Constants.STANDART_RECIPE_Y_POSITION);
                        break;
                    case 6:
                        Program.WorkbenchPrint(StonePickaxe, Constants.FRAME_TOP_WIDTH, Constants.FRAME_TOP_LENTH, Constants.STANDART_RECIPE_X_POSITION, Constants.STANDART_RECIPE_Y_POSITION);
                        break;
                    case 7:
                        Program.WorkbenchPrint(StoneAxe, Constants.FRAME_TOP_WIDTH, Constants.FRAME_TOP_LENTH, Constants.STANDART_RECIPE_X_POSITION, Constants.STANDART_RECIPE_Y_POSITION);
                        break;
                    case 8:
                        Program.WorkbenchPrint(StoneSwordSecondRecipe, Constants.FRAME_TOP_WIDTH, Constants.FRAME_TOP_LENTH, Constants.STANDART_RECIPE_X_POSITION, Constants.STANDART_RECIPE_Y_POSITION);
                        break;
                    case 9:
                        Program.WorkbenchPrint(IronShovelSecondRecipe, Constants.FRAME_TOP_WIDTH, Constants.FRAME_TOP_LENTH, Constants.STANDART_RECIPE_X_POSITION, Constants.STANDART_RECIPE_Y_POSITION);
                        break;
                    case 10:
                        Program.WorkbenchPrint(IronPickaxe, Constants.FRAME_TOP_WIDTH, Constants.FRAME_TOP_LENTH, Constants.STANDART_RECIPE_X_POSITION, Constants.STANDART_RECIPE_Y_POSITION);
                        break;
                    case 11:
                        Program.WorkbenchPrint(IronAxe, Constants.FRAME_TOP_WIDTH, Constants.FRAME_TOP_LENTH, Constants.STANDART_RECIPE_X_POSITION, Constants.STANDART_RECIPE_Y_POSITION);
                        break;
                    case 12:
                        Program.WorkbenchPrint(IronSwordSecondRecipe, Constants.FRAME_TOP_WIDTH, Constants.FRAME_TOP_LENTH, Constants.STANDART_RECIPE_X_POSITION, Constants.STANDART_RECIPE_Y_POSITION);
                        break;
                    case 13:
                        Program.WorkbenchPrint(GoldShovelSecondRecipe, Constants.FRAME_TOP_WIDTH, Constants.FRAME_TOP_LENTH, Constants.STANDART_RECIPE_X_POSITION, Constants.STANDART_RECIPE_Y_POSITION);
                        break;
                    case 14:
                        Program.WorkbenchPrint(GoldPickaxe, Constants.FRAME_TOP_WIDTH, Constants.FRAME_TOP_LENTH, Constants.STANDART_RECIPE_X_POSITION, Constants.STANDART_RECIPE_Y_POSITION);
                        break;
                    case 15:
                        Program.WorkbenchPrint(GoldAxe, Constants.FRAME_TOP_WIDTH, Constants.FRAME_TOP_LENTH, Constants.STANDART_RECIPE_X_POSITION, Constants.STANDART_RECIPE_Y_POSITION);
                        break;
                    case 16:
                        Program.WorkbenchPrint(GoldSwordSecondRecipe, Constants.FRAME_TOP_WIDTH, Constants.FRAME_TOP_LENTH, Constants.STANDART_RECIPE_X_POSITION, Constants.STANDART_RECIPE_Y_POSITION);
                        break;
                }
            }
        }

        public static string CheckRecipe(Workbench workbench)
        {
            bool isEqual = false;

            #region WoodInstrument
            for (int i = 0; i < Constants.STANDART_WORKBENCH_SIZE; i++)
            {
                for (int j = 0; j < Constants.STANDART_WORKBENCH_SIZE; j++)
                {
                    if (workbench[i, j] == WoodSwordFirstRecipe[i, j])
                    {
                        isEqual = true;
                    }
                    else
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual == false)
                {
                    break;
                }
            }

            if (isEqual == true)
            {
                return "Вы создали деревянный меч";
            }

            for (int i = 0; i < Constants.STANDART_WORKBENCH_SIZE; i++)
            {
                for (int j = 0; j < Constants.STANDART_WORKBENCH_SIZE; j++)
                {
                    if (workbench[i, j] == WoodSwordSecondRecipe[i, j])
                    {
                        isEqual = true;
                    }
                    else
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual == false)
                {
                    break;
                }
            }

            if (isEqual == true)
            {
                return "Вы создали деревянный меч";
            }

            for (int i = 0; i < Constants.STANDART_WORKBENCH_SIZE; i++)
            {
                for (int j = 0; j < Constants.STANDART_WORKBENCH_SIZE; j++)
                {
                    if (workbench[i, j] == WoodSwordThirdRecipe[i, j])
                    {
                        isEqual = true;
                    }
                    else
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual == false)
                {
                    break;
                }
            }

            if (isEqual == true)
            {
                return "Вы создали деревянный меч";
            }

            for (int i = 0; i < Constants.STANDART_WORKBENCH_SIZE; i++)
            {
                for(int j = 0; j < Constants.STANDART_WORKBENCH_SIZE; j++)
                {
                    if(workbench[i,j] == WoodShovelFirstRecipe[i, j])
                    {
                        isEqual = true;
                    }
                    else
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual == false)
                {
                    break;
                }
            }

            if(isEqual == true)
            {
                return "Вы создали деревянную лопату";
            }

            for (int i = 0; i < Constants.STANDART_WORKBENCH_SIZE; i++)
            {
                for (int j = 0; j < Constants.STANDART_WORKBENCH_SIZE; j++)
                {
                    if (workbench[i, j] == WoodShovelSecondRecipe[i, j])
                    {
                        isEqual = true;
                    }
                    else
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual == false)
                {
                    break;
                }
            }

            if (isEqual == true)
            {
                return "Вы создали деревянную лопату";
            }

            for (int i = 0; i < Constants.STANDART_WORKBENCH_SIZE; i++)
            {
                for (int j = 0; j < Constants.STANDART_WORKBENCH_SIZE; j++)
                {
                    if (workbench[i, j] == WoodShovelThirdRecipe[i, j])
                    {
                        isEqual = true;
                    }
                    else
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual == false)
                {
                    break;
                }
            }

            if (isEqual == true)
            {
                return "Вы создали деревянную лопату";
            }

            for (int i = 0; i < Constants.STANDART_WORKBENCH_SIZE; i++)
            {
                for (int j = 0; j < Constants.STANDART_WORKBENCH_SIZE; j++)
                {
                    if (workbench[i, j] == WoodPickaxe[i, j])
                    {
                        isEqual = true;
                    }
                    else
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual == false)
                {
                    break;
                }
            }

            if (isEqual == true)
            {
                return "Вы создали деревянную кирку";
            }

            for (int i = 0; i < Constants.STANDART_WORKBENCH_SIZE; i++)
            {
                for (int j = 0; j < Constants.STANDART_WORKBENCH_SIZE; j++)
                {
                    if (workbench[i, j] == WoodAxe[i, j])
                    {
                        isEqual = true;
                    }
                    else
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual == false)
                {
                    break;
                }
            }

            if (isEqual == true)
            {
                return "Вы создали деревянный топор";
            }
            #endregion

            #region StoneInstrument
            for (int i = 0; i < Constants.STANDART_WORKBENCH_SIZE; i++)
            {
                for (int j = 0; j < Constants.STANDART_WORKBENCH_SIZE; j++)
                {
                    if (workbench[i, j] == StoneSwordFirstRecipe[i, j])
                    {
                        isEqual = true;
                    }
                    else
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual == false)
                {
                    break;
                }
            }

            if (isEqual == true)
            {
                return "Вы создали каменный меч";
            }

            for (int i = 0; i < Constants.STANDART_WORKBENCH_SIZE; i++)
            {
                for (int j = 0; j < Constants.STANDART_WORKBENCH_SIZE; j++)
                {
                    if (workbench[i, j] == StoneSwordSecondRecipe[i, j])
                    {
                        isEqual = true;
                    }
                    else
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual == false)
                {
                    break;
                }
            }

            if (isEqual == true)
            {
                return "Вы создали каменный меч";
            }

            for (int i = 0; i < Constants.STANDART_WORKBENCH_SIZE; i++)
            {
                for (int j = 0; j < Constants.STANDART_WORKBENCH_SIZE; j++)
                {
                    if (workbench[i, j] == StoneSwordThirdRecipe[i, j])
                    {
                        isEqual = true;
                    }
                    else
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual == false)
                {
                    break;
                }
            }

            if (isEqual == true)
            {
                return "Вы создали каменный меч";
            }

            for (int i = 0; i < Constants.STANDART_WORKBENCH_SIZE; i++)
            {
                for (int j = 0; j < Constants.STANDART_WORKBENCH_SIZE; j++)
                {
                    if (workbench[i, j] == StoneShovelFirstRecipe[i, j])
                    {
                        isEqual = true;
                    }
                    else
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual == false)
                {
                    break;
                }
            }

            if (isEqual == true)
            {
                return "Вы создали каменную лопату";
            }

            for (int i = 0; i < Constants.STANDART_WORKBENCH_SIZE; i++)
            {
                for (int j = 0; j < Constants.STANDART_WORKBENCH_SIZE; j++)
                {
                    if (workbench[i, j] == StoneShovelSecondRecipe[i, j])
                    {
                        isEqual = true;
                    }
                    else
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual == false)
                {
                    break;
                }
            }

            if (isEqual == true)
            {
                return "Вы создали каменную лопату";
            }

            for (int i = 0; i < Constants.STANDART_WORKBENCH_SIZE; i++)
            {
                for (int j = 0; j < Constants.STANDART_WORKBENCH_SIZE; j++)
                {
                    if (workbench[i, j] == StoneShovelThirdRecipe[i, j])
                    {
                        isEqual = true;
                    }
                    else
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual == false)
                {
                    break;
                }
            }

            if (isEqual == true)
            {
                return "Вы создали каменную лопату";
            }

            for (int i = 0; i < Constants.STANDART_WORKBENCH_SIZE; i++)
            {
                for (int j = 0; j < Constants.STANDART_WORKBENCH_SIZE; j++)
                {
                    if (workbench[i, j] == StonePickaxe[i, j])
                    {
                        isEqual = true;
                    }
                    else
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual == false)
                {
                    break;
                }
            }

            if (isEqual == true)
            {
                return "Вы создали каменную кирку";
            }

            for (int i = 0; i < Constants.STANDART_WORKBENCH_SIZE; i++)
            {
                for (int j = 0; j < Constants.STANDART_WORKBENCH_SIZE; j++)
                {
                    if (workbench[i, j] == StoneAxe[i, j])
                    {
                        isEqual = true;
                    }
                    else
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual == false)
                {
                    break;
                }
            }

            if (isEqual == true)
            {
                return "Вы создали каменный топор";
            }
            #endregion

            #region IronInstrument
            for (int i = 0; i < Constants.STANDART_WORKBENCH_SIZE; i++)
            {
                for (int j = 0; j < Constants.STANDART_WORKBENCH_SIZE; j++)
                {
                    if (workbench[i, j] == IronSwordFirstRecipe[i, j])
                    {
                        isEqual = true;
                    }
                    else
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual == false)
                {
                    break;
                }
            }

            if (isEqual == true)
            {
                return "Вы создали железыный меч";
            }

            for (int i = 0; i < Constants.STANDART_WORKBENCH_SIZE; i++)
            {
                for (int j = 0; j < Constants.STANDART_WORKBENCH_SIZE; j++)
                {
                    if (workbench[i, j] == IronSwordSecondRecipe[i, j])
                    {
                        isEqual = true;
                    }
                    else
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual == false)
                {
                    break;
                }
            }

            if (isEqual == true)
            {
                return "Вы создали железыный меч";
            }

            for (int i = 0; i < Constants.STANDART_WORKBENCH_SIZE; i++)
            {
                for (int j = 0; j < Constants.STANDART_WORKBENCH_SIZE; j++)
                {
                    if (workbench[i, j] == IronSwordThirdRecipe[i, j])
                    {
                        isEqual = true;
                    }
                    else
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual == false)
                {
                    break;
                }
            }

            if (isEqual == true)
            {
                return "Вы создали железыный меч";
            }

            for (int i = 0; i < Constants.STANDART_WORKBENCH_SIZE; i++)
            {
                for (int j = 0; j < Constants.STANDART_WORKBENCH_SIZE; j++)
                {
                    if (workbench[i, j] == IronShovelFirstRecipe[i, j])
                    {
                        isEqual = true;
                    }
                    else
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual == false)
                {
                    break;
                }
            }

            if (isEqual == true)
            {
                return "Вы создали железную лопату";
            }

            for (int i = 0; i < Constants.STANDART_WORKBENCH_SIZE; i++)
            {
                for (int j = 0; j < Constants.STANDART_WORKBENCH_SIZE; j++)
                {
                    if (workbench[i, j] == IronShovelSecondRecipe[i, j])
                    {
                        isEqual = true;
                    }
                    else
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual == false)
                {
                    break;
                }
            }

            if (isEqual == true)
            {
                return "Вы создали железную лопату";
            }

            for (int i = 0; i < Constants.STANDART_WORKBENCH_SIZE; i++)
            {
                for (int j = 0; j < Constants.STANDART_WORKBENCH_SIZE; j++)
                {
                    if (workbench[i, j] == IronShovelThirdRecipe[i, j])
                    {
                        isEqual = true;
                    }
                    else
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual == false)
                {
                    break;
                }
            }

            if (isEqual == true)
            {
                return "Вы создали железную лопату";
            }

            for (int i = 0; i < Constants.STANDART_WORKBENCH_SIZE; i++)
            {
                for (int j = 0; j < Constants.STANDART_WORKBENCH_SIZE; j++)
                {
                    if (workbench[i, j] == IronPickaxe[i, j])
                    {
                        isEqual = true;
                    }
                    else
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual == false)
                {
                    break;
                }
            }

            if (isEqual == true)
            {
                return "Вы создали железную кирку";
            }

            for (int i = 0; i < Constants.STANDART_WORKBENCH_SIZE; i++)
            {
                for (int j = 0; j < Constants.STANDART_WORKBENCH_SIZE; j++)
                {
                    if (workbench[i, j] == IronAxe[i, j])
                    {
                        isEqual = true;
                    }
                    else
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual == false)
                {
                    break;
                }
            }

            if (isEqual == true)
            {
                return "Вы создали железный топор";
            }
            #endregion

            #region GoldInstrument
            for (int i = 0; i < Constants.STANDART_WORKBENCH_SIZE; i++)
            {
                for (int j = 0; j < Constants.STANDART_WORKBENCH_SIZE; j++)
                {
                    if (workbench[i, j] == GoldSwordFirstRecipe[i, j])
                    {
                        isEqual = true;
                    }
                    else
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual == false)
                {
                    break;
                }
            }

            if (isEqual == true)
            {
                return "Вы создали золотой меч";
            }

            for (int i = 0; i < Constants.STANDART_WORKBENCH_SIZE; i++)
            {
                for (int j = 0; j < Constants.STANDART_WORKBENCH_SIZE; j++)
                {
                    if (workbench[i, j] == GoldSwordSecondRecipe[i, j])
                    {
                        isEqual = true;
                    }
                    else
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual == false)
                {
                    break;
                }
            }

            if (isEqual == true)
            {
                return "Вы создали золотой меч";
            }

            for (int i = 0; i < Constants.STANDART_WORKBENCH_SIZE; i++)
            {
                for (int j = 0; j < Constants.STANDART_WORKBENCH_SIZE; j++)
                {
                    if (workbench[i, j] == GoldSwordThirdRecipe[i, j])
                    {
                        isEqual = true;
                    }
                    else
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual == false)
                {
                    break;
                }
            }

            if (isEqual == true)
            {
                return "Вы создали золотой меч";
            }

            for (int i = 0; i < Constants.STANDART_WORKBENCH_SIZE; i++)
            {
                for (int j = 0; j < Constants.STANDART_WORKBENCH_SIZE; j++)
                {
                    if (workbench[i, j] == GoldShovelFirstRecipe[i, j])
                    {
                        isEqual = true;
                    }
                    else
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual == false)
                {
                    break;
                }
            }

            if (isEqual == true)
            {
                return "Вы создали золотую лопату";
            }

            for (int i = 0; i < Constants.STANDART_WORKBENCH_SIZE; i++)
            {
                for (int j = 0; j < Constants.STANDART_WORKBENCH_SIZE; j++)
                {
                    if (workbench[i, j] == GoldShovelSecondRecipe[i, j])
                    {
                        isEqual = true;
                    }
                    else
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual == false)
                {
                    break;
                }
            }

            if (isEqual == true)
            {
                return "Вы создали золотую лопату";
            }

            for (int i = 0; i < Constants.STANDART_WORKBENCH_SIZE; i++)
            {
                for (int j = 0; j < Constants.STANDART_WORKBENCH_SIZE; j++)
                {
                    if (workbench[i, j] == GoldShovelThirdRecipe[i, j])
                    {
                        isEqual = true;
                    }
                    else
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual == false)
                {
                    break;
                }
            }

            if (isEqual == true)
            {
                return "Вы создали золотую лопату";
            }

            for (int i = 0; i < Constants.STANDART_WORKBENCH_SIZE; i++)
            {
                for (int j = 0; j < Constants.STANDART_WORKBENCH_SIZE; j++)
                {
                    if (workbench[i, j] == GoldPickaxe[i, j])
                    {
                        isEqual = true;
                    }
                    else
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual == false)
                {
                    break;
                }
            }

            if (isEqual == true)
            {
                return "Вы создали золотую кирку";
            }

            for (int i = 0; i < Constants.STANDART_WORKBENCH_SIZE; i++)
            {
                for (int j = 0; j < Constants.STANDART_WORKBENCH_SIZE; j++)
                {
                    if (workbench[i, j] == GoldAxe[i, j])
                    {
                        isEqual = true;
                    }
                    else
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual == false)
                {
                    break;
                }
            }

            if (isEqual == true)
            {
                return "Вы создали золотой топор";
            }
            else
            {
                return "Такого рецепта еще нет...";
            }
            #endregion
        }
    }
}
