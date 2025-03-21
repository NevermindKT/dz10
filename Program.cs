using Storecd.Repos;

namespace Store
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

            //var test = new RepositoryTest();

            //test.Add_AddsProductToDB();
            //test.GetById_ReturnsCorrectProduct();
            //test.Remove_RemovesProductFromDB();

            ApplicationConfiguration.Initialize();
            Application.Run(new RegForm());
        }
    }
}