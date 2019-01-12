using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork21_01_19
{
    public partial class Plane
    {
        #region Поля
        private static int _pilotsCount;
        private static int _wingsCount;
        private PlaneModels _model;
        private double _carrying;
        private double _cargoWeight;
        private double _width;
        private double _lenth;
        private double _velocity;
        #endregion

        #region Конструкторы
        static Plane()
        {
            _pilotsCount = Constants.STANDART_PILOTS_COUNT;
            _wingsCount = Constants.STANDART_WINGS_COUNT;
        }
        public Plane() { }
        public Plane(PlaneModels model, double carrying, double cargoWeight, double width, double lenth)
        {
            _pilotsCount = Constants.STANDART_PILOTS_COUNT;
            _wingsCount = Constants.STANDART_WINGS_COUNT;
            _model = model;
            _cargoWeight = cargoWeight;
            _carrying = carrying;
            _width = width;
            _lenth = lenth;
        }
        public Plane(PlaneModels model, double carrying, double cargoWeight, double width, double lenth, double velocity)
        {
            _pilotsCount = Constants.STANDART_PILOTS_COUNT;
            _wingsCount = Constants.STANDART_WINGS_COUNT;
            _model = model;
            _cargoWeight = cargoWeight;
            _carrying = carrying;
            _width = width;
            _lenth = lenth;
            _velocity = velocity;
        }
        #endregion

        #region Свойства(Геттеры и Сеттеры)
        public static int GetWingsCount() { return _wingsCount; }
        public static void SetWingsCount(int wingsCount) { _wingsCount = wingsCount; }
        public static int GetPilotsCount() { return _pilotsCount; }
        public static void SetPilotsCount(int pilotsCount) { _pilotsCount = pilotsCount;9 }
        public double GetCargoWeight() { return _cargoWeight; }
        public void SetCargoWeight(double cargoWeight)
        {
            if (cargoWeight <= _carrying)
            {
                _cargoWeight = cargoWeight;
            }
        }
        public double GetCarrying() { return _carrying; }
        public void SetCarrying(double carrying) { _carrying = carrying; }
        public PlaneModels GetModel() { return _model; }
        public void SetModel(PlaneModels model) { _model = model; }
        public double GetWidth() { return _width; }
        public void SetWidth(double width) { _width = width; }
        public double GetLenth() { return _lenth; }
        public void SetLenth(double lenth) { _lenth = lenth; }
        public double GetVelocity() { return _velocity; }
        public void SetVelocity(double velocity) { _velocity = velocity; }
        #endregion

        #region Методы
        public bool IsMove(ref double velocity)
        {
            if(_velocity > Constants.NULL)
            {
                velocity = _velocity;
                return true;
            }
            velocity = Constants.NULL;
            return false;
        }
        #endregion
    }
}
