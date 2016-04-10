using System;
using CSharpConcepts.Interfaces;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Transactions;

namespace CSharpConcepts.DataAccessConcepts
{
    internal class WorkingWithADO_DOTNET_Concepts : IMainMethod
    {
        string connectionString = string.Empty;
        public WorkingWithADO_DOTNET_Concepts()
        {
            this.connectionString = ReadConnectionString();
        }

        private string ReadConnectionString()
        {
            string conn = string.Empty;

            if (ConfigurationManager.ConnectionStrings["conn"] != null)
                conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            else
                Console.WriteLine("Connection String not available");

            return conn;
        }

        public void SummaryMethod()
        {
            Console.WriteLine("Working with ADO.NET Concepts");
        }

        public void MainMethod()
        {
            if (!String.IsNullOrWhiteSpace(this.connectionString))
            {
                ReadPeopleData();
                Console.WriteLine("\n-------------------------------------------------------------------------\n");
                ExecuteQueryWithMultipleResultSet();
                Console.WriteLine("\n-------------------------------------------------------------------------\n");
                UpdateDataWithExecuteNonQuery();
                Console.WriteLine("\n-------------------------------------------------------------------------\n");
                UsingParameterizedQuery();
                Console.WriteLine("\n-------------------------------------------------------------------------\n");
                UsingTransactions();
                Console.WriteLine("\n-------------------------------------------------------------------------\n");
            }
            else
            {
                Console.WriteLine("Database connection string not initialized");
            }
        }

        private async void ReadPeopleData()
        {
            Console.WriteLine("Reading people data from database");
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM People", connection);
                await connection.OpenAsync();

                SqlDataReader dataReader = await command.ExecuteReaderAsync();

                while(await dataReader.ReadAsync())
                {
                    string formatStringwithMiddleName = "Person ({0}) is named {1} {2} {3}";
                    string formatStringWithoutMiddleName = "Person ({0}) is names {1} {2}";

                    if(dataReader["MiddleName"]==null)
                    {
                        Console.WriteLine(formatStringWithoutMiddleName,
                            dataReader["id"],
                            dataReader["FirstName"].ToString(),
                            dataReader["LastName"].ToString());
                    }
                    else
                    {
                        Console.WriteLine(formatStringwithMiddleName,
                            dataReader["id"],
                            dataReader["FirstName"].ToString(),
                            dataReader["MiddleName"].ToString(),
                            dataReader["LastName"].ToString());
                    }
                }
                dataReader.Close();
            }
        }

        private async void ExecuteQueryWithMultipleResultSet()
        {
            Console.WriteLine("Reading multiple result sets using NextResult method of datareader");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM People;SELECT TOP 1 * FROM People Order By LastName;", connection);
                await connection.OpenAsync();
                SqlDataReader dataReader = await command.ExecuteReaderAsync();
                await ReadQueryResults(dataReader);
                await dataReader.NextResultAsync();
                await ReadQueryResults(dataReader);
                dataReader.Close();
            }
        }

        private async void UpdateDataWithExecuteNonQuery()
        {
            Console.WriteLine("Updating data in database using ExecuteNonQueryAsync");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("Update People SET FirstName = 'John'", connection);
                await connection.OpenAsync();
                int numberOfUpdatedRows = await command.ExecuteNonQueryAsync();
                Console.WriteLine("Updated {0} rows", numberOfUpdatedRows);
            }
        }

        private async void UsingParameterizedQuery()
        {
            Console.WriteLine("Paramterized Query Example:");
            using (SqlConnection connection = new SqlConnection())
            {
                SqlCommand command = new SqlCommand("INSERT INTO People([FisrtName],[MiddleName],[LastName]) VALUES(@firstname,@middlename,@lastname);", connection);
                command.Parameters.AddWithValue("@firstname", "Mayank");
                command.Parameters.AddWithValue("@lastname", "Aggarwal");
                command.Parameters.AddWithValue("@middlename", "Kumar");

                await connection.OpenAsync();
                int numberOfRowsInserted = await command.ExecuteNonQueryAsync();
                Console.WriteLine("Inserted {0} rows:", numberOfRowsInserted);
            }
        }

        private async void UsingTransactions()
        {
            Console.WriteLine("Using TransactionScope from System.Transaction namespace");
            using (TransactionScope transactionScope = new TransactionScope())
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    SqlCommand cmd1 = new SqlCommand("INSERT INTO People(FirstName,LastName,MiddleName VALUES('John','Doe',null)", connection);
                    SqlCommand cmd2 = new SqlCommand("INSERT INTO People(FirstName,LastName,MiddleName VALUES('John','Doe',null)", connection);
                    await cmd1.ExecuteNonQueryAsync();
                    await cmd2.ExecuteNonQueryAsync();
                }

                transactionScope.Complete();
            }
        }

        private async Task ReadQueryResults(SqlDataReader dataReader)
        {
            while(await dataReader.ReadAsync())
            {
                string formatStringWithMiddleName = "People ({0}) is named {1} {2} {3}";
                string formatStringWithoutMiddleName = "People ({0}) is named {1} {2}";
                if(dataReader["MiddleName"] != null)
                {
                    Console.WriteLine(formatStringWithMiddleName,
                        dataReader["id"].ToString(),
                        dataReader["FirstName"].ToString(),
                        dataReader["MiddleName"].ToString(),
                        dataReader["LastName"].ToString());
                }
                else
                {
                    Console.WriteLine(formatStringWithoutMiddleName,
                        dataReader["id"].ToString(),
                        dataReader["FirstName"].ToString(),
                        dataReader["LastName"].ToString());
                }
            }
        }
    }
}