
using DemoNganHangNCB.Services;

namespace DemoNganHangNCB
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            AppState.virtualWeb = new VirtualWebService(headless: false, useOffscreen: true);
            await AppState.virtualWeb.InitializeAsync();
            
            Application.Run(new FLogin());

            AppState.DangXuat();
        }
    }
}