using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Excel = Microsoft.Office.Interop.Excel;

namespace ReadFromExcel
{
    class Excel
    {
        public string Path { get; set; }
        Application excelApp = new _Excel.Application();
        public Workbook workbook;
        public Worksheet worksheet;

        public Excel(string path)
        {
            excelApp.Visible = true;
            Path = path;
            workbook = excelApp.Workbooks.Open(path);
            worksheet = (Worksheet)workbook.ActiveSheet;
        }

        public string ReadCell(int i, int j)
        {
            i++;
            j++;
            string value = ((_Excel.Range)worksheet.Cells[i, j]).Value2.ToString();
            if (value != null)
            {
                return value;
            }
            else
            {
                return "";
            }
        }

        public int CountOfRows 
        { 
            get
            {
                return worksheet.Rows.Count;
            }
        }

        public int CountOfCells
        {
            get
            {
                return worksheet.Cells.Count;
            }
        }
    }
}
