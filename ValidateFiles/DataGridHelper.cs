using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ValidateFiles
{
    static class DataGridHelper
    {

        public static void SetColumnWidths(DataGridView dataGridView)
        {
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (column.Index % 2 != 0)
                {
                    dataGridView.Columns[column.Index].Visible = false;
                }

                if (dataGridView.Columns[column.Index].HeaderText.ToLower() == "empty1")
                {
                    dataGridView.Columns[column.Index].Width = 0;
                }

                if (dataGridView.Columns[column.Index].HeaderText.ToLower() == "beløb")
                {
                    dataGridView.Columns[column.Index].Width = 50;
                }

                if (dataGridView.Columns[column.Index].HeaderText.ToLower() == "empty2")
                {
                    dataGridView.Columns[column.Index].Width = 0;
                }

                if (dataGridView.Columns[column.Index].HeaderText.ToLower() == "adresse")
                {
                    dataGridView.Columns[column.Index].Width = 125;
                }

                if (dataGridView.Columns[column.Index].HeaderText.ToLower() == "postnr")
                {
                    dataGridView.Columns[column.Index].Width = 45;
                }

                if (dataGridView.Columns[column.Index].HeaderText.ToLower() == "telefon2")
                {
                    dataGridView.Columns[column.Index].Width = 0;
                }

                if (dataGridView.Columns[column.Index].HeaderText.ToLower() == "email")
                {
                    dataGridView.Columns[column.Index].Width = 200;
                }

                if (dataGridView.Columns[column.Index].HeaderText.ToLower() == "empty3")
                {
                    dataGridView.Columns[column.Index].Width = 0;
                }

                if (dataGridView.Columns[column.Index].HeaderText.ToLower() == "regnr")
                {
                    dataGridView.Columns[column.Index].Width = 45;
                }

                if (dataGridView.Columns[column.Index].HeaderText.ToLower() == "empty4")
                {
                    dataGridView.Columns[column.Index].Width = 0;
                }

                if (dataGridView.Columns[column.Index].HeaderText.ToLower() == "empty5")
                {
                    dataGridView.Columns[column.Index].Width = 0;
                }

                if (dataGridView.Columns[column.Index].HeaderText.ToLower() == "empty6")
                {
                    dataGridView.Columns[column.Index].Width = 0;
                }

                if (dataGridView.Columns[column.Index].HeaderText.ToLower() == "empty7")
                {
                    dataGridView.Columns[column.Index].Width = 0;
                }

                if (dataGridView.Columns[column.Index].HeaderText.ToLower() == "empty8")
                {
                    dataGridView.Columns[column.Index].Width = 0;
                }

                if (dataGridView.Columns[column.Index].HeaderText.ToLower() == "empty9")
                {
                    dataGridView.Columns[column.Index].Width = 0;
                }

                if (dataGridView.Columns[column.Index].HeaderText.ToLower() == "empty10")
                {
                    dataGridView.Columns[column.Index].Width = 0;
                }

                if (dataGridView.Columns[column.Index].HeaderText.ToLower() == "empty11")
                {
                    dataGridView.Columns[column.Index].Width = 0;
                }

            }

        }

        public static void ColorCellsWithValidationErrors(DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                try
                {
                    foreach (DataGridViewColumn col in dataGridView.Columns)
                    {
                        if (col.Index % 2 != 0)
                        {
                            string cellValue = dataGridView.Rows[row.Index].Cells[col.Index].Value.ToString();
                            if (cellValue.ToLower() == "true")
                            {
                                dataGridView.Rows[row.Index].Cells[col.Index - 1].Style.BackColor = Color.Red;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

    }


}
