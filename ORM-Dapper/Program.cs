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