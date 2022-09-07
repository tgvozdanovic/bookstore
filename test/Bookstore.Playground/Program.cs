using ConsoleDump;
using Rhetos;
using Rhetos.Dom.DefaultConcepts;
using Rhetos.Logging;
using Rhetos.Utilities;



namespace Bookstore.Playground
{
    static class Program
    {



        static void Main(string[] args)
        {
            ConsoleLogger.MinLevel = EventType.Info; // Use EventType.Trace for more detailed log.
            string rhetosHostAssemblyPath = @"..\..\..\..\..\bookstore\bin\Debug\net6.0\Bookstore.Service.dll";
            using (var scope = LinqPadRhetosHost.CreateScope(rhetosHostAssemblyPath))
            {
                var context = scope.Resolve<Common.ExecutionContext>();
                var repository = context.Repository;



                // Query data from the `Common.Claim` table:




                var actionParameter = new Bookstore.InsertManyBooks
                {
                    NumberOfBooks = 7,
                    TitlePrefix = "A Song of Ice and Fire"
                };
                repository.Bookstore.InsertManyBooks.Execute(actionParameter);
                scope.CommitAndClose();
                scope.CommitAndClose(); // Database transaction is rolled back by default.
            }
        }
    }
}