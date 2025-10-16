
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
            Application.Run(new FLogin());

            if (AppState.virtualWeb != null)
            {
                AppState.virtualWeb.DisposeAsync().AsTask().GetAwaiter().GetResult();
                AppState.virtualWeb = null;
            }
        }
    }
}