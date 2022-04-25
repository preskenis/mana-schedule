using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManaSchedule.Services
{
    public static class ExcelService
    {
        public static string[] NameColumns = new string[] { "название", "команда" };


        public static int GetNameColumnIndex(ISheet sheet)
        {
            var cell = sheet.GetRow(0).Cells.Where(f => f.CellType == NPOI.SS.UserModel.CellType.String).FirstOrDefault(f => NameColumns.Contains(f.StringCellValue.ToLower(), StringComparer.InvariantCultureIgnoreCase));

            return cell != null ? cell.ColumnIndex : -1;
        }


    }
}
