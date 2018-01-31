using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Web;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;

namespace MISUI.Services.Report
{
    public class ReportFactory
    {

        protected static Queue reportQueue = new Queue();

        public ReportDocument GetReport(ReportDocument repDoc)
        {
            //object report = Activator.CreateInstance(repDoc);
            reportQueue.Enqueue(repDoc);
            return (ReportDocument)repDoc;
        }

        public ReportDocument SetReport(ReportDocument repDoc)
        {

            //75 is my print job limit.
            if (reportQueue.Count > 25) ((ReportDocument)reportQueue.Dequeue()).Dispose();
            return GetReport(repDoc);
        }
    }
}