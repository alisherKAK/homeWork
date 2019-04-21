using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork22_04_19.Services
{
    public static class ColumnCreator
    {
        public static DataColumn CreateIdColumn()
        {
            DataColumn id = new DataColumn("Id", typeof(int));
            id.Unique = true;
            id.AllowDBNull = false;
            id.AutoIncrement = true;
            id.AutoIncrementSeed = 1;
            id.AutoIncrementStep = 1;

            return id;
        }

        public static DataColumn CreateNameColumn()
        {
            DataColumn name = new DataColumn("Name", typeof(string))
            {
                AllowDBNull = false
            };

            return name;
        }

        public static DataColumn CreateSurnameColumn()
        {
            DataColumn surname = new DataColumn("Surname", typeof(string))
            {
                AllowDBNull = false
            };

            return surname
;
        }

        public static DataColumn CreatePriceColumn()
        {
            DataColumn price = new DataColumn("Price", typeof(double))
            {
                AllowDBNull = false
            };

            return price;
        }

        public static DataColumn CreateProducedDateColumn()
        {
            DataColumn producedDate = new DataColumn("ProducedDate", typeof(DateTime))
            {
                AllowDBNull = false
            };

            return producedDate;
        }

        public static DataColumn CreateExpirationDateColumn()
        {
            DataColumn expirationDate = new DataColumn("ExpirationDate", typeof(DateTime))
            {
                AllowDBNull = false
            };

            return expirationDate;
        }

        public static DataColumn CreateEmployeeIdColumn()
        {
            DataColumn employeeId = new DataColumn("EmployeeId", typeof(int))
            {
                AllowDBNull = false
            };

            return employeeId;
        }

        public static DataColumn CreateSaleDateColumn()
        {
            DataColumn saleDate = new DataColumn("SaleDate", typeof(DateTime))
            {
                 AllowDBNull = false
            };

            return saleDate;
        }

        public static DataColumn CreateCustomerIdColumn()
        {
            DataColumn customerId = new DataColumn("CustomerId", typeof(int))
            {
                AllowDBNull = false
            };

            return customerId;
        }

        public static DataColumn CreateOrderDetailIdColumn()
        {
            DataColumn orderDetailId = new DataColumn("OrderDetailId", typeof(int))
            {
                AllowDBNull = false
            };

            return orderDetailId;
        }

        public static DataColumn CreateProductIdColumn()
        {
            DataColumn productId = new DataColumn("ProductId", typeof(int))
            {
                AllowDBNull = false
            };

            return productId;
        }
    }
}
