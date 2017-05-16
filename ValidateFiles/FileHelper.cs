using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.ComponentModel;

namespace ValidateFiles
{
    public static class FileHelper
    {
        private static string myFilePathAndName;

        public static string FilePathAndName
        {
            get { return myFilePathAndName; }
            set { myFilePathAndName = value; }
        }

        private static string myFilePath;

        public static string FilePath
        {
            get { return myFilePath; }
            set { myFilePath = value; }
        }

        private static string myFileName;

        public static string FileName
        {
            get { return myFileName; }
            set { myFileName = value; }
        }

        private static string myNewFileName;

        public static string NewFileName
        {
            get { return myNewFileName; }
            set { myNewFileName = value; }
        }


        public static Excel.Application MyApp = new Excel.Application();
        public static Excel.Workbook MyBook;
        public static Excel.Worksheet MySheet;
        public static int lastRow;


        public static BindingList<AdvancedLeadRow> LoadDataWithValidations()
        { 
            BindingList<AdvancedLeadRow> EmpList = new BindingList<AdvancedLeadRow>();

            try
            {
                for (int index = 2; index <= FileHelper.lastRow; index++)
                {
                    System.Array MyValues = (System.Array)FileHelper.MySheet.get_Range("A" +
                       index.ToString(), "Y" + index.ToString()).Cells.Value;

                    AdvancedLeadRow row = new AdvancedLeadRow();
                    row.Empty1 = "0";
                    row.Beløb = (MyValues.GetValue(1, 2) != null) ? MyValues.GetValue(1, 2).ToString() : "";
                    row.Navn = (MyValues.GetValue(1, 3) != null) ? MyValues.GetValue(1, 3).ToString() : "";
                    row.Efternavn = (MyValues.GetValue(1, 4) != null) ? MyValues.GetValue(1, 4).ToString() : "";
                    row.Empty2 = (MyValues.GetValue(1, 5) != null) ? MyValues.GetValue(1, 5).ToString() : "";
                    row.Adresse = (MyValues.GetValue(1, 6) != null) ? MyValues.GetValue(1, 6).ToString() : "";
                    row.Postnr = (MyValues.GetValue(1, 7) != null) ? MyValues.GetValue(1, 7).ToString() : "";
                    row.Postdistrikt = (MyValues.GetValue(1, 8) != null) ? MyValues.GetValue(1, 8).ToString() : "";
                    row.Telefon = (MyValues.GetValue(1, 9) != null) ? MyValues.GetValue(1, 9).ToString() : "";
                    row.Telefon2 = (MyValues.GetValue(1, 10) != null) ? MyValues.GetValue(1, 10).ToString() : "";
                    row.Email = (MyValues.GetValue(1, 11) != null) ? MyValues.GetValue(1, 11).ToString() : "";
                    row.Empty3 = (MyValues.GetValue(1, 12) != null) ? MyValues.GetValue(1, 12).ToString() : "";
                    row.Regnr = (MyValues.GetValue(1, 13) != null) ? MyValues.GetValue(1, 13).ToString() : "";
                    row.Kontonr = (MyValues.GetValue(1, 14) != null) ? MyValues.GetValue(1, 14).ToString() : "";
                    row.CPR = (MyValues.GetValue(1, 15) != null) ? MyValues.GetValue(1, 15).ToString() : "";
                    row.Empty4 = (MyValues.GetValue(1, 16) != null) ? MyValues.GetValue(1, 16).ToString() : "";
                    row.Empty5 = (MyValues.GetValue(1, 17) != null) ? MyValues.GetValue(1, 17).ToString() : "";
                    row.Empty6 = (MyValues.GetValue(1, 18) != null) ? MyValues.GetValue(1, 18).ToString() : "";
                    row.Empty7 = (MyValues.GetValue(1, 19) != null) ? MyValues.GetValue(1, 19).ToString() : "";
                    row.Empty8 = (MyValues.GetValue(1, 20) != null) ? MyValues.GetValue(1, 20).ToString() : "";
                    row.Empty9 = (MyValues.GetValue(1, 21) != null) ? MyValues.GetValue(1, 21).ToString() : "";
                    row.EntryCode = (MyValues.GetValue(1, 22) != null) ? MyValues.GetValue(1, 22).ToString() : "";
                    row.Empty10 = (MyValues.GetValue(1, 23) != null) ? MyValues.GetValue(1, 23).ToString() : "";
                    row.Empty11 = (MyValues.GetValue(1, 24) != null) ? MyValues.GetValue(1, 24).ToString() : "";
                    row.StartDato = (MyValues.GetValue(1, 25) != null) ? MyValues.GetValue(1, 25).ToString() : "";

                    row.MakeRelevantPropertiesPascalCase();
                    row.RemoveDashAndDotFromRelevantProperties();

                    EmpList.Add(row);
                }

                FileHelper.MyBook.Close();
                FileHelper.MyApp.Quit();
            }
            catch (Exception ex)
            {
                FileHelper.MyBook.Close();
                FileHelper.MyApp.Quit();
            }

            return EmpList;
        }


        public static bool OpenFileDialogAndSetFilePath()
        {
            //Do not show alerts
            MyApp.DisplayAlerts = false;

            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                FilePathAndName = choofdlog.FileName;
                FilePath = Path.GetDirectoryName(FilePathAndName);
                FileName = choofdlog.SafeFileName;
                MyBook = MyApp.Workbooks.Open(FileHelper.FilePathAndName);
                MySheet = (Excel.Worksheet)MyBook.Sheets[1];
                lastRow = MySheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;
                //string[] arrAllFiles = choofdlog.FileNames; //used when Multiselect = true 
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void SaveFile(DataGridView dataGridView, string filePathAndName)
        {
            // creating Excel Application
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();


            // creating new WorkBook within Excel application
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);


            // creating new Excelsheet in workbook
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            //Do not show alerts
            app.DisplayAlerts = false;

            // see the excel sheet behind the program
            app.Visible = false;

            // get the reference of first sheet. By default its name is Sheet1.
            // store its reference to worksheet
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;

            // changing the name of active sheet
            worksheet.Name = "Exported from gridview";

            //// storing header part in Excel
            //int excelColNo = 1;
            //for (int i = 0; i < dataGridView.Columns.Count; i++)
            //{
            //    if (dataGridView.Columns[i].Visible == true)
            //    {
            //        worksheet.Cells[1, excelColNo] = dataGridView.Columns[i].HeaderText;
            //        excelColNo++;
            //    }

            //}

            // storing Each row and column value to excel sheet
            int excelColNo = 1;
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                excelColNo = 1;
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    if (dataGridView.Columns[j].Visible == true)
                    {
                        worksheet.Cells[i + 2, excelColNo] = "'" + dataGridView.Rows[i].Cells[j].Value.ToString();
                        excelColNo++;
                    }
                }
            }

            // save the application
            string timeStamp = DateTime.Now.ToString("ddMMyy");
            NewFileName = "DK12_Cold_TM_" + timeStamp + "_UTF8_TM-DK.txt";

            try
            {
                workbook.SaveAs(FileHelper.FilePath + "\\" + FileHelper.NewFileName, Excel.XlFileFormat.xlCurrentPlatformText, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                MessageBox.Show("File saved succesfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during save: " + ex.Message);
                workbook.Close();
                app.Quit();

            }
            workbook.Close();

            // Exit from the application
            app.Quit();
        }
    }
}
