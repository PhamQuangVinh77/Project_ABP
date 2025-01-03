using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        public static async Task<string> UploadFileExcel(IFormFile fileUpload)
        {
            if (fileUpload == null || fileUpload.Length <= 0) throw new Exception(message: "File không tồn tại hoặc rỗng!");
            if (!fileUpload.FileName.EndsWith(".xlsx")) throw new Exception(message: "File không đúng định dạng!");
            var path = $"{Directory.GetCurrentDirectory()}\\wwwroot\\import-excels";
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            var filePath = Path.Combine(path, fileUpload.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await fileUpload.CopyToAsync(stream);
            }
            return filePath;
        }

        public static async Task<List<ExcelDto>> ReadExcelFile(string filePath)
        {
            var listData = new List<ExcelDto>();
            FileInfo file = new FileInfo(filePath);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using var package = new ExcelPackage(file);
            var ws = package.Workbook.Worksheets[0];
            var rowCount = ws.Dimension.End.Row;
            for (int row = 5; row <= rowCount; row++)
            {
                listData.Add(new ExcelDto
                {
                    Ma = int.Parse(ws.Cells[row, 2].Value.ToString()),
                    Ten = ws.Cells[row, 3].Value.ToString(),
                    Cap = ws.Cells[row, 4].Value.ToString()
                });
            }
            return listData;
        }
    }
}
