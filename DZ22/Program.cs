using Microsoft.Data.SqlClient;
using System;

namespace DZ22
{
    internal class Program
    {
        private static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Country1;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Завдання 1
                GetAllCountryInformation(connection);

                // Завдання 2
                GetAllCountryNames(connection);
                GetAllCapitals(connection);
                GetBigCitiesInCountry(connection, 1); // example country ID
                GetCapitalsWithPopulationMoreThanFiveMillion(connection);
                GetEuropeanCountries(connection);

                // Завдання 3
                GetCapitalsWithAP(connection);
                GetCapitalsStartingWithK(connection);
                GetCountriesByAreaRange(connection, 100000, 1000000);
                GetCountriesByPopulation(connection, 50000000);

                // Завдання 4
                GetTop5LargestCountries(connection);
                GetTop5LargestCapitals(connection);
                GetCountryWithLargestArea(connection);
                GetCapitalWithLargestPopulation(connection);
                GetSmallestEuropeanCountry(connection);
                GetAverageAreaInEurope(connection);
                GetTop3CitiesByPopulationInCountry(connection, 1); // example country ID
                GetTotalCountries(connection);
                GetContinentWithMaxCountries(connection);
                GetCountryCountByContinent(connection);
            }
        }

        // Завдання 1
        private static void GetAllCountryInformation(SqlConnection connection)
        {
            string query = @"SELECT c.Name AS CountryName, c.Area, c.Continent, 
                            cap.Name AS CapitalName, cap.Population AS CapitalPopulation,
                            bc.Name AS CityName, bc.Population AS CityPopulation
                            FROM Country c
                            JOIN Capitalss cap ON c.ID = cap.CountryID
                            JOIN BigCitiess bc ON c.ID = bc.CountryID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Country: {reader["CountryName"]}, Area: {reader["Area"]}, Continent: {reader["Continent"]}, " +
                                          $"Capital: {reader["CapitalName"]}, Capital Population: {reader["CapitalPopulation"]}, " +
                                          $"City: {reader["CityName"]}, City Population: {reader["CityPopulation"]}");
                    }
                }
            }
        }

        // Завдання 2
        private static void GetAllCountryNames(SqlConnection connection)
        {
            string query = "SELECT Name FROM Country";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Country Name: {reader["Name"]}");
                    }
                }
            }
        }

        private static void GetAllCapitals(SqlConnection connection)
        {
            string query = "SELECT Name FROM Capitalss";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Capital Name: {reader["Name"]}");
                    }
                }
            }
        }

        private static void GetBigCitiesInCountry(SqlConnection connection, int countryID)
        {
            string query = "SELECT Name FROM BigCitiess WHERE CountryID = @CountryID";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@CountryID", countryID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Big City: {reader["Name"]}");
                    }
                }
            }
        }

        private static void GetCapitalsWithPopulationMoreThanFiveMillion(SqlConnection connection)
        {
            string query = "SELECT Name FROM Capitalss WHERE Population > 5000000";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Capital Name: {reader["Name"]}");
                    }
                }
            }
        }

        private static void GetEuropeanCountries(SqlConnection connection)
        {
            string query = "SELECT Name FROM Country WHERE Continent = 'Europe'";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"European Country: {reader["Name"]}");
                    }
                }
            }
        }

        // Завдання 3
        private static void GetCapitalsWithAP(SqlConnection connection)
        {
            string query = "SELECT Name FROM Capitalss WHERE Name LIKE '%a%' AND Name LIKE '%p%'";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Capital Name: {reader["Name"]}");
                    }
                }
            }
        }

        private static void GetCapitalsStartingWithK(SqlConnection connection)
        {
            string query = "SELECT Name FROM Capitalss WHERE Name LIKE 'k%'";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Capital Name: {reader["Name"]}");
                    }
                }
            }
        }

        private static void GetCountriesByAreaRange(SqlConnection connection, float minArea, float maxArea)
        {
            string query = "SELECT Name FROM Country WHERE Area > @MinArea AND Area < @MaxArea";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@MinArea", minArea);
                command.Parameters.AddWithValue("@MaxArea", maxArea);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Country Name: {reader["Name"]}");
                    }
                }
            }
        }

        private static void GetCountriesByPopulation(SqlConnection connection, int population)
        {
            string query = "SELECT Name FROM Country WHERE Population > @Population";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Population", population);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Country Name: {reader["Name"]}");
                    }
                }
            }
        }

        // Завдання 4
        private static void GetTop5LargestCountries(SqlConnection connection)
        {
            string query = "SELECT TOP 5 * FROM Country ORDER BY Area DESC";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Country Name: {reader["Name"]}, Area: {reader["Area"]}");
                    }
                }
            }
        }

        private static void GetTop5LargestCapitals(SqlConnection connection)
        {
            string query = "SELECT TOP 5 * FROM Capitalss ORDER BY Population DESC";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Capital Name: {reader["Name"]}, Population: {reader["Population"]}");
                    }
                }
            }
        }

        private static void GetCountryWithLargestArea(SqlConnection connection)
        {
            string query = "SELECT * FROM Country ORDER BY Area DESC OFFSET 0 ROWS FETCH NEXT 1 ROW ONLY";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.WriteLine($"Country with Largest Area: {reader["Name"]}, Area: {reader["Area"]}");
                    }
                }
            }
        }

        private static void GetCapitalWithLargestPopulation(SqlConnection connection)
        {
            string query = "SELECT * FROM Capitalss ORDER BY Population DESC OFFSET 0 ROWS FETCH NEXT 1 ROW ONLY";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.WriteLine($"Capital with Largest Population: {reader["Name"]}, Population: {reader["Population"]}");
                    }
                }
            }
        }

        private static void GetSmallestEuropeanCountry(SqlConnection connection)
        {
            string query = "SELECT * FROM Country WHERE Continent = 'Europe' ORDER BY Area ASC OFFSET 0 ROWS FETCH NEXT 1 ROW ONLY";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.WriteLine($"Smallest European Country: {reader["Name"]}, Area: {reader["Area"]}");
                    }
                }
            }
        }

        private static void GetAverageAreaInEurope(SqlConnection connection)
        {
            string query = "SELECT AVG(Area) AS AverageArea FROM Country WHERE Continent = 'Europe'";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.WriteLine($"Average Area in Europe: {reader["AverageArea"]}");
                    }
                }
            }
        }

        private static void GetTop3CitiesByPopulationInCountry(SqlConnection connection, int countryID)
        {
            string query = "SELECT TOP 3 * FROM BigCitiess WHERE CountryID = @CountryID ORDER BY Population DESC";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@CountryID", countryID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"City: {reader["Name"]}, Population: {reader["Population"]}");
                    }
                }
            }
        }

        private static void GetTotalCountries(SqlConnection connection)
        {
            string query = "SELECT COUNT(*) FROM Country";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                object result = command.ExecuteScalar();
                Console.WriteLine($"Total number of countries: {result}");
            }
        }

        private static void GetContinentWithMaxCountries(SqlConnection connection)
        {
            string query = "SELECT Continent, COUNT(*) AS Count FROM Country GROUP BY Continent ORDER BY Count DESC OFFSET 0 ROWS FETCH NEXT 1 ROW ONLY";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.WriteLine($"Continent with most countries: {reader["Continent"]}, Count: {reader["Count"]}");
                    }
                }
            }
        }

        private static void GetCountryCountByContinent(SqlConnection connection)
        {
            string query = "SELECT Continent, COUNT(*) AS CountryCount FROM Country GROUP BY Continent";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Continent: {reader["Continent"]}, Country Count: {reader["CountryCount"]}");
                    }
                }
            }
        }
    }
}
