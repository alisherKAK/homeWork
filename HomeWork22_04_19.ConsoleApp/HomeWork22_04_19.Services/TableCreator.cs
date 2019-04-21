using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork22_04_19.Services
{
    public static class TableCreator
    {
        public static DataTable CreateEmployeesTable()
        {
            DataTable employees = new DataTable("Employees");

            DataColumn id = ColumnCreator.CreateIdColumn();
            DataColumn name = ColumnCreator.CreateNameColumn();
            DataColumn surname = ColumnCreator.CreateSurnameColumn();

            employees.Columns.AddRange(new DataColumn[] { id, name, surname });
            employees.PrimaryKey = new DataColumn[] { id };

            return employees;
        }

        public static DataTable CreateCustomersTable()
        {
            DataTable customers = new DataTable("Customers");

            DataColumn id = ColumnCreator.CreateIdColumn();
            DataColumn name = ColumnCreator.CreateNameColumn();
            DataColumn surname = ColumnCreator.CreateSurnameColumn();

            customers.Columns.AddRange(new DataColumn[] { id, name, surname });
            customers.PrimaryKey = new DataColumn[] { id };

            return customers;
        }

        public static DataTable CreateProductsTable()
        {
            DataTable products = new DataTable("Products");

            DataColumn id = ColumnCreator.CreateIdColumn();
            DataColumn name = ColumnCreator.CreateNameColumn();
            DataColumn price = ColumnCreator.CreatePriceColumn();
            DataColumn producedDate = ColumnCreator.CreateProducedDateColumn();
            DataColumn expirationDate = ColumnCreator.CreateExpirationDateColumn();

            products.Columns.AddRange(new DataColumn[] { id, name, price, producedDate, expirationDate });
            products.PrimaryKey = new DataColumn[] { id };

            return products;
        }

        public static DataTable CreateOrderDetailsTable()
        {
            DataTable orderDetails = new DataTable("OrderDetails");
        
            DataColumn id = ColumnCreator.CreateIdColumn();
            DataColumn employeeId = ColumnCreator.CreateEmployeeIdColumn();
            DataColumn saleDate = ColumnCreator.CreateSaleDateColumn();

            orderDetails.Columns.AddRange(new DataColumn[] { id, employeeId, saleDate});
            orderDetails.PrimaryKey = new DataColumn[] { id };

            return orderDetails;
        }

        public static DataTable CreateOrdersTable()
        {
            DataTable orders = new DataTable("Orders");

            DataColumn id = ColumnCreator.CreateIdColumn();
            DataColumn productId = ColumnCreator.CreateProductIdColumn();
            DataColumn customerId = ColumnCreator.CreateCustomerIdColumn();
            DataColumn orderDetailId = ColumnCreator.CreateOrderDetailIdColumn();

            orders.Columns.AddRange(new DataColumn[] { id, productId, customerId, orderDetailId});
            orders.PrimaryKey = new DataColumn[] { id };

            return orders;
        }
    }
}
