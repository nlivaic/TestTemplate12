using System;
using System.IO;
using DbUp;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace TestTemplate12.Migrations
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var connectionString = string.Empty;
            var dbUser = string.Empty;
            var dbPassword = string.Empty;
            var scriptsPath = string.Empty;
            var sqlUsersGroupName = string.Empty;

            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                ?? "Production";
            Console.WriteLine($"Environment: {env}.");
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env}.json", true, true)
                .AddEnvironmentVariables();

            var config = builder.Build();
            InitializeParameters();
            var connectionStringBuilderTestTemplate12 = new SqlConnectionStringBuilder(connectionString);
            if (env.Equals("Development"))
            {
                connectionStringBuilderTestTemplate12.UserID = dbUser;
                connectionStringBuilderTestTemplate12.Password = dbPassword;
            }
            else
            {
                connectionStringBuilderTestTemplate12.UserID = dbUser;
                connectionStringBuilderTestTemplate12.Password = dbPassword;
                connectionStringBuilderTestTemplate12.Authentication = SqlAuthenticationMethod.ActiveDirectoryPassword;
            }
            var upgraderTestTemplate12 =
                DeployChanges.To
                    .SqlDatabase(connectionStringBuilderTestTemplate12.ConnectionString)
                    .WithVariable("SqlUsersGroupNameVariable", sqlUsersGroupName)    // This is necessary to perform template variable replacement in the scripts.
                    .WithScriptsFromFileSystem(
                        !string.IsNullOrWhiteSpace(scriptsPath)
                                ? Path.Combine(scriptsPath, "TestTemplate12Scripts")
                            : Path.Combine(Environment.CurrentDirectory, "TestTemplate12Scripts"))
                    .LogToConsole()
                    .Build();
            Console.WriteLine($"Now upgrading TestTemplate12.");
            if (env == "Development")
            {
                upgraderTestTemplate12.MarkAsExecuted("0000_AzureSqlContainedUser.sql");
            }
            var resultTestTemplate12 = upgraderTestTemplate12.PerformUpgrade();

            if (!resultTestTemplate12.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"TestTemplate12 upgrade error: {resultTestTemplate12.Error}");
                Console.ResetColor();
                return -1;
            }

            // Uncomment the below sections if you also have an Identity Server project in the solution.
            /*
            var connectionStringTestTemplate12Identity = string.IsNullOrWhiteSpace(args.FirstOrDefault())
                ? config["ConnectionStrings:TestTemplate12IdentityDb"]
                : args.FirstOrDefault();

            var upgraderTestTemplate12Identity =
                DeployChanges.To
                    .SqlDatabase(connectionStringTestTemplate12Identity)
                    .WithScriptsFromFileSystem(
                        scriptsPath != null
                            ? Path.Combine(scriptsPath, "TestTemplate12IdentityScripts")
                            : Path.Combine(Environment.CurrentDirectory, "TestTemplate12IdentityScripts"))
                    .LogToConsole()
                    .Build();
            Console.WriteLine($"Now upgrading TestTemplate12 Identity.");
            if (env != "Development")
            {
                upgraderTestTemplate12Identity.MarkAsExecuted("0004_InitialData.sql");
                Console.WriteLine($"Skipping 0004_InitialData.sql since we are not in Development environment.");
                upgraderTestTemplate12Identity.MarkAsExecuted("0005_Initial_Configuration_Data.sql");
                Console.WriteLine($"Skipping 0005_Initial_Configuration_Data.sql since we are not in Development environment.");
            }
            var resultTestTemplate12Identity = upgraderTestTemplate12Identity.PerformUpgrade();

            if (!resultTestTemplate12Identity.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"TestTemplate12 Identity upgrade error: {resultTestTemplate12Identity.Error}");
                Console.ResetColor();
                return -1;
            }
            */

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;

            void InitializeParameters()
            {
                // Local database, populated from .env file.
                if (args.Length == 0)
                {
                    connectionString = config["TestTemplate12Db_Migrations_Connection"];
                    dbUser = config["DbUser"];
                    dbPassword = config["DbPassword"];
                }

                // Deployed database
                else if (args.Length == 5)
                {
                    connectionString = args[0];
                    dbUser = args[1];
                    dbPassword = args[2];
                    scriptsPath = args[3];
                    sqlUsersGroupName = args[4];
                }
            }
        }
    }
}
