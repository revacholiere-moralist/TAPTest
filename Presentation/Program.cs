
using Application;
using Application.Common.Options;
using Application.Features.TestResultFeatures.Queries.GetTotalPassingApplicants;
using Domain.Exceptions;
using Infrastructure;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using System.Text;

namespace Presentation
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            try
            {
                var quitProgram = false;

                while (!quitProgram)
                {
                    var host = CreateHostBuilder(args).Build();
                    var mediator = host.Services.GetRequiredService<IMediator>();

                    int numberOfApplicants = 0;
                    var applicantNumberInput = string.Empty;
                    var applicantDetails = new StringBuilder();

                    Console.WriteLine("Please input the number of applicants: ");
                    applicantNumberInput = Console.ReadLine();

                    if (!int.TryParse(applicantNumberInput, out numberOfApplicants))
                    {
                        Console.WriteLine("Please input a valid number");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Please input the test details: ");
                    for (int i = 1; i <= numberOfApplicants; i++)
                    {
                        applicantDetails.Append(Console.ReadLine());
                        applicantDetails.Append('\n');
                    }

                    var query = new GetTotalPassingApplicantsQuery(applicantDetails.ToString());
                    var passingApplicants = await mediator.Send(query, default);
                    Console.WriteLine(passingApplicants.ToString());
                    Console.WriteLine();
                    Console.WriteLine("Do you want to continue? enter Y/N");
                    var isQuitInput = Console.ReadLine();
                    // Change 2
                    if (string.IsNullOrWhiteSpace(isQuitInput) || isQuitInput.ToLower() == "n")
                    {
                        quitProgram = true;
                    }
                }
                
            }
            catch (BadRequestException ex)
            {
                Console.WriteLine(ex.ErrorMessage);
            }

            catch (IncompleteMasterDataException ex)
            {
                Console.WriteLine(ex.ErrorMessage);
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var builder = new ConfigurationBuilder()
                           .SetBasePath(Directory.GetCurrentDirectory())
                           .AddJsonFile("appsettings.json", optional: false);

                    IConfiguration config = builder.Build();

                    services.AddMediatR(Assembly.GetExecutingAssembly())
                    .BuildServiceProvider();
                    services.ConfigureApplication();
                    services.Configure<MinimumScoreOptions>(config.GetSection("MinimumScoreOptions"));
                    services.ConfigureServices();

                });
    }
}