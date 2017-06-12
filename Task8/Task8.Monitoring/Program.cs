using System;
using System.Configuration;
using System.Diagnostics;
using System.Threading;

namespace Task8.Monitoring
{
    class Program
    {
        private static void RegisterCategory()
        {
            if (PerformanceCounterCategory.Exists(ConfigurationManager.AppSettings["PerformanceCategoryName"]))
            {
                Console.WriteLine("Performance category already exists");
                return;
            }

            var counterCreationDataCollection = new CounterCreationDataCollection();
            var successfullLoginCounter = new CounterCreationData
            {
                CounterName = ConfigurationManager.AppSettings["SuccessfullLoginCounterName"],
                CounterType = PerformanceCounterType.NumberOfItems32
            };
            counterCreationDataCollection.Add(successfullLoginCounter);

            var failedLoginCounter = new CounterCreationData
            {
                CounterName = ConfigurationManager.AppSettings["FailedLoginCounterName"],
                CounterType = PerformanceCounterType.NumberOfItems32
            };
            counterCreationDataCollection.Add(failedLoginCounter);

            var logoutCounter = new CounterCreationData
            {
                CounterName = ConfigurationManager.AppSettings["LogoutCounterName"],
                CounterType = PerformanceCounterType.NumberOfItems32
            };
            counterCreationDataCollection.Add(logoutCounter);

            try
            {
                PerformanceCounterCategory.Create(
                    ConfigurationManager.AppSettings["PerformanceCategoryName"], "",
                    PerformanceCounterCategoryType.SingleInstance,
                    counterCreationDataCollection);
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Do not have permissions to create performance category");
            }
            Console.WriteLine("Performance category created");
        }

        private static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        static void Main()
        {
            RegisterCategory();
            PerformanceCounter logoutCounter = null;
            PerformanceCounter failedLoginCounter = null;
            PerformanceCounter successfullLoginCounter = null;

            Console.WriteLine();

            try
            {
                logoutCounter = new PerformanceCounter(
                    ConfigurationManager.AppSettings["PerformanceCategoryName"],
                    ConfigurationManager.AppSettings["LogoutCounterName"], true);
                failedLoginCounter = new PerformanceCounter(
                    ConfigurationManager.AppSettings["PerformanceCategoryName"],
                    ConfigurationManager.AppSettings["FailedLoginCounterName"], false);
                successfullLoginCounter = new PerformanceCounter(
                    ConfigurationManager.AppSettings["PerformanceCategoryName"],
                    ConfigurationManager.AppSettings["SuccessfullLoginCounterName"], false);

                while (true)
                {
                    Thread.Sleep(300);
                    ClearCurrentConsoleLine();
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.WriteLine(
                        $"Successfull login: {successfullLoginCounter.NextValue()} Failed login: {failedLoginCounter.NextValue()} Logout: {logoutCounter.NextValue()}");
                }
            }
            finally
            {
                logoutCounter?.Dispose();
                failedLoginCounter?.Dispose();
                successfullLoginCounter?.Dispose();
            }
        }
    }
}
