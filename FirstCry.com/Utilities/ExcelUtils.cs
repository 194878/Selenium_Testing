﻿using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstCry.com.Utilities
{
    internal class ExcelUtils
    {
        public static List<ExcelData> ReadExcelData(string excelFilePath, string sheetName)
        {
            List<ExcelData> excelDataList = new List<ExcelData>();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            using (var stream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                        }
                    });

                    var dataTable = result.Tables[sheetName];

                    if (dataTable != null)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            ExcelData excelData = new ExcelData
                            {
                               Search = GetValueOrDefault(row, "search"),
                               Name = GetValueOrDefault(row, "name"),
                               MobileNumber = GetValueOrDefault(row, "mobilenumber"),
                               Email = GetValueOrDefault(row, "email"),
                               Password = GetValueOrDefault(row, "password"),
                                ChildName = GetValueOrDefault(row, "childname")
                            };

                            excelDataList.Add(excelData);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Sheet '{sheetName}' not found in the Excel file.");
                    }
                }
            }

            return excelDataList;
        }
       
        

        static string GetValueOrDefault(DataRow row, string columnName)
        {
            Console.WriteLine(row + "  " + columnName);
            return row.Table.Columns.Contains(columnName) ? row[columnName]?.ToString() : null;
        }

    }
}
