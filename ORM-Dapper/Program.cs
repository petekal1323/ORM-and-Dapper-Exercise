using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using ORM_Dapper;

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build(); 

string connString = config.GetConnectionString("DefaultConnection"); 
IDbConnection conn = new MySqlConnection(connString);

var dapdepartmentRepo = new DapperDepartmentRepository(conn);

var departments = dapdepartmentRepo.GetAllDepartments();

foreach (var dep in departments)
{
    Console.WriteLine($"Name: {dep.Name} | Department ID: {dep.DepartmentID}");
}

var repo = new DapperProductRepository(conn);

Console.WriteLine("What is the name of your new product?");
var prodName = Console.ReadLine();

Console.WriteLine("What is the price?");
var prodPrice = double.Parse(Console.ReadLine());

Console.WriteLine("What is the category id?");
var prodCat = int.Parse(Console.ReadLine());

repo.CreateProduct(prodName, prodPrice, prodCat);

var prodList = repo.GetAllProducts();

foreach (var prod in prodList)
{
    Console.WriteLine($"Name: {prod.Name} | Product ID: {prod.ProductID}");
}

Console.WriteLine("What is the ID of the product you want to update?");
var prodID = int.Parse(Console.ReadLine());

Console.WriteLine("What is the new prod name?");
var newName = Console.ReadLine();

repo.UpdateProduct(prodID, newName);

