using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader;

namespace Specflow.ExcelUtility
{
  public class ExcelReaderHelper
    {
        private static IDictionary<string, IExcelDataReader> _cache;
        private static FileStream stream;
        private static IExcelDataReader reader;

        //Constructor

        static ExcelReaderHelper()
        {
            _cache = new Dictionary<string, IExcelDataReader>();
        }

        private static IExcelDataReader GetExcelReader(string sheetname, string excelPath)
        {
            if (_cache.ContainsKey(sheetname))
            {
                reader = _cache[sheetname];
            }
            else
            {
                stream = new FileStream(excelPath, FileMode.Open, FileAccess.Read);
                reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                _cache.Add(sheetname, reader);
            }
            return reader;
        }

        public static int GetTotalRows(string excelPath, string sheetname)
        {
            IExcelDataReader _reader = GetExcelReader(excelPath, sheetname);
            return _reader.AsDataSet().Tables[sheetname].Rows.Count;
        }

        public static object GetCellData(string excelPath, string sheetname, int row, int col)
        {
            IExcelDataReader _reader = GetExcelReader(excelPath, sheetname);
            DataTable table = reader.AsDataSet().Tables[sheetname];
            return GetDataType(table.Rows[row][col].GetType(), table.Rows[row][col]);
        }

        private static object GetDataType(Type type, object data)
        {
            switch (type.Name)
            {
                case "string":
                    return data.ToString();
                case "int":
                    return Convert.ToInt32(data);
                case "double":
                    return Convert.ToDouble(data);
                case "DateTime":
                    return Convert.ToDateTime(data);
                default:
                    return data.ToString();                    
            }
        }

    }
}
