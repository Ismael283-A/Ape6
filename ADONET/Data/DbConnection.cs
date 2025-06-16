﻿using Microsoft.Data.SqlClient;


namespace ADONET.Data
{
    public class DbConnection
    {
        private readonly IConfiguration _configuration;

        private readonly string _connectionString;



        public DbConnection(IConfiguration configuration)

        {

            _configuration = configuration;

            _connectionString = _configuration.GetConnectionString("DefaultConnection");

        }



        public SqlConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
