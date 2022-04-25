using Janus.Windows.GridEX;
using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ManaSchedule
{
    public static class Utils
    {
        public static void ExportToExcel(GridEX grid, HSSFWorkbook workbook, string sheetName)
        {
            var sheet = workbook.CreateSheet(sheetName);

            var index = 0;

            var hdr = sheet.CreateRow(index++);

            for (int i = 0; i < grid.RootTable.Columns.Count; i++)
            {
                var cell = hdr.CreateCell(i);
                cell.SetCellValue(grid.RootTable.Columns[i].Caption);
                cell.CellStyle.WrapText = true;
                cell.CellStyle.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;

            }

            foreach (var r in grid.GetRows())
            {
                var sr = sheet.CreateRow(index++);

                for (int i = 0; i < r.Cells.Count; i++)
                {
                    if (r.Cells[i] == null || r.Cells[i].Value == null) continue;

                    if (r.Cells[i].Value.GetType() == typeof(string))
                    {
                        var cell = sr.CreateCell(i);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue((string)r.Cells[i].Value);
                    }
                    else if (r.Cells[i].Value.GetType() == typeof(short))
                    {
                        var cell = sr.CreateCell(i);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.Numeric);
                        cell.SetCellValue((short)r.Cells[i].Value);
                    }
                    else if (r.Cells[i].Value.GetType() == typeof(int))
                    {
                        var cell = sr.CreateCell(i);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.Numeric);
                        cell.SetCellValue((int)r.Cells[i].Value);
                    }
                    else if (r.Cells[i].Value.GetType() == typeof(double))
                    {
                        var cell = sr.CreateCell(i);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.Numeric);
                        cell.SetCellValue((double)r.Cells[i].Value);
                    }
                    else
                    {
                        sr.CreateCell(i).SetCellValue(r.Cells[i].Text);
                    }


                    sheet.AutoSizeColumn(i);


                }
            }

            

        }

        public static void ExportToExcel(DataTable grid, HSSFWorkbook workbook, string sheetName)
        {
            var sheet = workbook.CreateSheet(sheetName);

            var index = 0;

            var hdr = sheet.CreateRow(index++);

            for (int i = 0; i < grid.Columns.Count; i++)
            {
                hdr.CreateCell(i).SetCellValue(grid.Columns[i].ColumnName);
            }

            foreach (var r in grid.Rows.Cast<DataRow>())
            {
                
                var sr = sheet.CreateRow(index++);

                for (int i = 0; i < grid.Columns.Count; i++)
                {
                    sr.CreateCell(i).SetCellValue(r[i] != null ? r[i].ToString() : "");
                }
            }

        }


        public static int MinPow2(int value)
        {
            var pow = 1;
            while (Math.Pow(2, pow) < value) pow++;
            return (int)Math.Pow(2, pow);
        }

        public static DataModels.StageType GetStageTypeByGamesCount(int games)
        {
            switch (games)
            {
                case 2: return DataModels.StageType.Stage12;
                case 4: return DataModels.StageType.Stage14;
                case 8: return DataModels.StageType.Stage18;
                case 16: return DataModels.StageType.Stage116;
                case 32: return DataModels.StageType.Stage132;
                case 64: return DataModels.StageType.Stage164;
                case 128: return DataModels.StageType.Stage1128;
            }

            return DataModels.StageType.Otbor;
        }


    }

    public static class EnumHelper<T>
    {

        public static IList<T> GetValues()
        {
            var enumValues = new List<T>();

            foreach (FieldInfo fi in typeof(T).GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                enumValues.Add((T)Enum.Parse(typeof(T), fi.Name, false));
            }
            return enumValues;
        }

        public static IList<T> GetValues(Enum value)
        {
            var enumValues = new List<T>();

            foreach (FieldInfo fi in value.GetType().GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                enumValues.Add((T)Enum.Parse(value.GetType(), fi.Name, false));
            }
            return enumValues;
        }

        public static T Parse(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static IList<string> GetNames(Enum value)
        {
            return value.GetType().GetFields(BindingFlags.Static | BindingFlags.Public).Select(fi => fi.Name).ToList();
        }

        public static IList<string> GetDisplayValues(Enum value)
        {
            return GetNames(value).Select(obj => GetDisplayValue(Parse(obj))).ToList();
        }

        public static T GetValueByDisplayValue(string displayValue)
        {
            return GetValues().First(f => GetDisplayValue(f) == displayValue);
        }

        public static string GetDisplayValue(T value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            var descriptionAttributes = fieldInfo.GetCustomAttributes(
                typeof(DisplayAttribute), false) as DisplayAttribute[];

            if (descriptionAttributes == null) return string.Empty;
            return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Name : value.ToString();
        }
    }
}
