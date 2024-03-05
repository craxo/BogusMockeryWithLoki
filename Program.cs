using Serilog;
using Serilog.Sinks.Loki;

using Employee;
using Bogus;


// var credentials = new BasicAuthCredentials("http://localhost:3100", "<username>", "<password>");
var credentials = new NoAuthCredentials("http://172.21.134.165:3100"); // Address to local or remote Loki server

Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Information()
        .Enrich.FromLogContext()
        .WriteTo.LokiHttp(credentials)
        .CreateLogger();


// Set some random full name
var faker = new Faker();
string randomName = faker.Name.FullName();
//Console.WriteLine(randomName);

// We have a EmployeeInfo which we want to fill, lets fill hundred!
for (int i = 0; i < 100; i++)
{
    var bogusEmployee = EmployeeExtensions.GetBogusEmployee();

    Log.Information("Employee: {@Employee}", bogusEmployee);
}

Log.CloseAndFlush();