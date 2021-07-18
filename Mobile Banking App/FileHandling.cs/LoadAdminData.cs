using Autofac;
using ClassLibrary;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MobileBankingApplication
{
    internal static class LoadAdminData
    {
        internal static async Task<List<IAdministrator>> Load(Stream stream)
        {
            List<IAdministrator> output = new List<IAdministrator>();

            var package = new ExcelPackage(stream);

            await package.LoadAsync(stream);

            var ws = package.Workbook.Worksheets[0];

            int row = 3;
            int col = 1;

            var container = ContainerConfig.Configure();

            while (string.IsNullOrWhiteSpace(ws.Cells[row, col].Value?.ToString()) == false)
            {
                using(var scope = container.BeginLifetimeScope())
                {
                    var admin = scope.Resolve<IAdministrator>();

                    admin.Name = ws.Cells[row, col].Value.ToString();
                    admin.userName = ws.Cells[row, col + 1].Value.ToString();
                    admin.password = ws.Cells[row, col + 2].Value.ToString();

                    output.Add(admin);
                    row += 1;
                }
            }

            return output;
        }
    }
}
