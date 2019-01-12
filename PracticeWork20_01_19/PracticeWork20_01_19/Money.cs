using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeWork20_01_19
{
    public class Money
    {
        #region Поля
        private int _parMoney;
        private int _billCount;
        #endregion

        #region Констукторы
        public Money() { }
        public Money(int parMoney, int billCount)
        {
            _parMoney = parMoney;
            _billCount = billCount;
        }
        #endregion

        #region Методы
        public void ShowParMoneyAndBillCount()
        {
            Console.WriteLine($"Par money: {_parMoney}");
            Console.WriteLine($"Bill count: {_billCount}");
        }
        public bool IsEnoughToBuyProduct(double productCost)
        {
            if(_parMoney * _billCount >= productCost)
            {
                return true;
            }
            return false;
        }
        public int CountProductsWhitchYouCanBuy(double produtCost)
        {
            return (int)( (_parMoney * _billCount) / produtCost );
        }
        #endregion

        #region Свойства(Геттеры и Сеттеры)
        public int GetParMoney() { return _parMoney; }
        public void SetParMoney(int parMoney) { _parMoney = parMoney; }
        public int GetBillCount() { return _billCount; }
        public void SetBillCount(int billCount) { _billCount = billCount; }

        public int GetFullSumOfMoney() { return _parMoney * _billCount; }
        #endregion
    }
}
