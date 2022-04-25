using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

        public static List<List<string>> GetTableFromClipboard()
        {
            var result = new List<List<string>>();
            try
            {
                
                using (var ms = Clipboard.GetData("Csv") as MemoryStream)
                    using(var sr = new StreamReader(ms, Encoding.GetEncoding(1251)))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            result.Add(line.Split(new string[] {";"}, StringSplitOptions.None).ToList());
                        }

                        if (result.Any())
                        {
                            var max = result.Max(f => f.Count);
                            result.ForEach(f =>
                            {
                                while (f.Count < max) f.Add("");
                            });

                        }

                        
                        




                    }

            }
            catch (Exception e)
            {
               
            }
            
            return result;
        }
    }
}
