using Microsoft.Reporting.WinForms;
using QuanLyCuaHangBanh.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QuanLyCuaHangBanh.Reports.QLCHBDataSet;

namespace QuanLyCuaHangBanh.Uitls
{
    public class ReportHanler
    {
        public static string reportsFolder = Application.StartupPath.Replace("bin\\Debug\\net9.0-windows", "Reports");

        public static void LoadData(
            ReportViewer reportViewer,
            List<object> Entities,
            DataTable dataTable,
            string reportName,
            string rptDataSource,
            Action<DataRow, object> action)
        {
            dataTable.Clear();

            foreach (var entity in Entities)
            {
                var row = dataTable.NewRow();
                action.Invoke(row, entity);
                dataTable.Rows.Add(row);
            }

            var reportDataSource = new ReportDataSource
            {
                Name = rptDataSource,
                Value = dataTable
            };

            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(reportDataSource);
            reportViewer.LocalReport.ReportPath = Path.Combine(reportsFolder, reportName);
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.RefreshReport();
        }

    }
}
