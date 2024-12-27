using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using OfficeOpenXml;
using Project_ABP.Dto.ExcelDtos;

namespace Project_ABP.Services
{
    public static class ExcelService
    {
        public static async Task CreateExcelFile(FileInfo file, List<ExcelDto> listData, string sheetName, string title)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            if (file.Exists) file.Delete();
            using var package = new ExcelPackage(file);
            var ws = package.Workbook.Worksheets.Add(sheetName);
            var range = ws.Cells["B4"].LoadFromCollection(listData, true);
            range.AutoFitColumns();

            ws.Cells["B2"].Value = title;
            ws.Cells["B2:D2"].Merge = true;
            ws.Column(2).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            ws.Column(3).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            ws.Column(4).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            ws.Row(2).Style.Font.Size = 24;
            ws.Row(2).Style.Font.Color.SetColor(Color.DarkBlue);
            ws.Row(4).Style.Font.Bold = true;

            await package.SaveAsync();
        }
    }
}
