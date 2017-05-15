using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unidecode.NET;

namespace ValidateFiles
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void openFileDialog_Click(object sender, EventArgs e)
        {
            if (FileHelper.OpenFileDialogAndSetFilePath() == true)
            {
                dataGridView1.DataSource = FileHelper.LoadDataWithValidations();
                DataGridHelper.SetColumnWidths(dataGridView1);
                DataGridHelper.ColorCellsWithValidationErrors(dataGridView1);
            }
            else
            {
                //Problem with file?
            }

            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            FileHelper.SaveFile(dataGridView1, FileHelper.FilePath + "\\" + timeStamp + FileHelper.FileName);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void chkIncludeHeadersOnCopyPaste_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIncludeHeadersOnCopyPaste.Checked == true)
            {
                dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            }
            else
            {
                dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            }
        }
    }
}
