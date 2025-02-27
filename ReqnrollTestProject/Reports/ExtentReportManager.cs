using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollTestProject.Reports
{
    public class ExtentReportManager
    {
        private static ExtentReports _extent;
        private static ExtentTest _test;
        private static string _reportPath = Path.Combine(Directory.GetCurrentDirectory(), "/Reports/TestsResults", "ExtentReport.html");

        public static void InitReport()
        {
            var sparkReporter = new ExtentSparkReporter(_reportPath);

            _extent = new ExtentReports();

            _extent.AttachReporter(sparkReporter);
        }

        public static void StartTest(string testName)
        {
            _test = _extent.CreateTest(testName);
        }

        public static void LogStep(bool isSuccess, string stepDetails)
        {
            if (isSuccess)
            {
                _test.Log(Status.Pass, stepDetails);
            }
            else
            {
                _test.Log(Status.Fail, stepDetails);
            }
        }

        public static void FlushReport()
        {
            _extent.Flush();
        }
    }
}
