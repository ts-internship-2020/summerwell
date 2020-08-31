using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ado.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConferencePlanner.WinUi
{
    static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 

        [STAThread]
        static void Main()
        {
            if (HasInternet())
            {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                ConfigureServices();

                Application.Run(ServiceProvider.GetService<StartUpForm>());
            }
            else MessageBox.Show("No internet");
        }


        public static IServiceProvider ServiceProvider { get; set; }

        static void ConfigureServices()
        {
                var services = new ServiceCollection();
                services.AddScoped<StartUpForm>();
                services.AddScoped<IConferenceRepository, ConferenceRepository>();
                services.AddScoped<IGetSpeakerDetail, GetSpeakerDetail>();
                services.AddScoped<IConferenceTypeRepository, ConferenceTypeRepository>();
                services.AddScoped<IDictionaryCountryRepository, DictionaryCountryRepository>();
                services.AddScoped<IDictionaryCountyRepository, DictionaryCountyRepository>();
                services.AddScoped<IDictionaryCityRepository, DictionaryCityRepository>();
                services.AddScoped<IDictionaryConferenceCategoryRepository, DictionaryConferenceCategoryRepository>();
                services.AddSingleton<SqlConnection>(a =>
                {
                    SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString);
                    sqlConnection.Open();
                    return sqlConnection;
                });
                ServiceProvider = services.BuildServiceProvider();
        }
        static bool HasInternet()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/"))
                    return true;
            }
            catch { return false; }
        }
    }
}
