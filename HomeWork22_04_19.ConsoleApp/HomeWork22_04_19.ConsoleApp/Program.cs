using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HomeWork22_04_19.Services;

namespace HomeWork22_04_19.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet shopDb = new DataSet("ShopDB");

            DataTable employees = TableCreator.CreateEmployeesTable();
            DataTable customers = TableCreator.CreateCustomersTable();
            DataTable products = TableCreator.CreateProductsTable();
            DataTable orderDetails = TableCreator.CreateOrderDetailsTable();
            DataTable orders = TableCreator.CreateOrdersTable();

            ForeignKeyConstraint emplyeeWithOrderDetail = new ForeignKeyConstraint(employees.Columns["Id"], orderDetails.Columns["EmployeeId"]);
            ForeignKeyConstraint productWithOrder = new ForeignKeyConstraint(products.Columns["Id"], orders.Columns["ProductId"]);
            ForeignKeyConstraint customerWithOrder = new ForeignKeyConstraint(customers.Columns["Id"], orders.Columns["CustomerId"]);
            ForeignKeyConstraint orderDetailWithOrder = new ForeignKeyConstraint(orderDetails.Columns["Id"], orders.Columns["OrderDetailId"]);

            shopDb.Tables.AddRange(new DataTable[] { employees, customers, products, orderDetails, orders});
        }
    }
}
