using TrackerLibrary;

namespace TrackerUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //Intialise the database connection
            TrackerLibrary.GlobalConfig.InitiazeConnections(DatabaseType.Sql);
            Application.Run(new CreatePrizeForm());

            //Application.Run(new TournamentDashboardForm());
        }
    }
}