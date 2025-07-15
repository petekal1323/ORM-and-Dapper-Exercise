using System.Data;
using Dapper;

namespace ORM_Dapper
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }


        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO products (Name, Price, CategoryID) VALUES (@name, @price, @categoryID);",
                new { name, price, categoryID });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products;");
        }
        
        public void UpdateProduct(int productID, string updatedName)
        {
            _connection.Execute("UPDATE products SET Name = @updatedName WHERE ProductID = @productID;",
                new { productID, updatedName });
        }
    }
}