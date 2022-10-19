using System;
using System.Data;
using System.Windows.Forms;

namespace SpreadsheetApp
{
    public partial class SpreadsheetAppMain : Form
    {
        private SharableSpreadsheet spreadSheet;
        private DataTable dataTable;
        private bool addRow;
        private int addIndex;
        public SpreadsheetAppMain()
        {
            InitializeComponent();
            this.CenterToScreen();
            spreadSheet = new SharableSpreadsheet(1, 1);
            dataTable = new DataTable();
            int row = 0;
            int col = 0;
            spreadSheet.getSize(ref row, ref col);
            for (int c = 0; c < col; c++)
            {
                dataTable.Columns.Add("Column " + (c + 1), typeof(string));
            }
            for (int r = 0; r < row; r++)
            {
                dataTable.Rows.Add((spreadSheet.spreadSheet[r]).ToArray());
            }
            dataGridView1.DataSource = dataTable;
            dataGridView1.AllowUserToAddRows = false;
            textBox1.Text = "1";
            addRow = true;
            addIndex = 0;
        }

        private void refreshTable()
        {
            dataTable = new DataTable();
            dataGridView1.DataSource = dataTable;
            int row = 0;
            int col = 0;
            spreadSheet.getSize(ref row, ref col);
            for (int c = 0; c < col; c++)
            {
                dataTable.Columns.Add("Column " + (c + 1), typeof(string));
            }
            for (int r = 0; r < row; r++)
            {
                dataTable.Rows.Add((spreadSheet.spreadSheet[r]).ToArray());
            }
        }

        private void Load_Click(object sender, EventArgs e)
        {
            dataTable = new DataTable();
            dataGridView1.DataSource = dataTable;
            //Use open file dialog component to load the file
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                if (spreadSheet.load(filePath))
                {
                    int row = 0;
                    int col = 0;
                    spreadSheet.getSize(ref row, ref col);
                    for (int c = 0; c < col; c++)
                    {
                        dataTable.Columns.Add("Column " + (c + 1), typeof(string));
                    }
                    for (int r = 0; r < row; r++)
                    {
                        dataTable.Rows.Add((spreadSheet.spreadSheet[r]).ToArray());
                    }
                    MessageBox.Show("The Spreadsheet was loaded successfuly", "Error");
                }
                else
                    MessageBox.Show("The Spreadsheet was not loaded successfuly", "Notice");
            }

        }

        private void exchangeRow_Click(object sender, EventArgs e)
        {
            if (excRowCom.Text == "" || inputExcRow.Text == "")
            {
                MessageBox.Show("Enter a valid place in the spreadsheet", "Error");
                return;
            }
            int row1 = Int32.Parse(excRowCom.Text);
            int row2 = Int32.Parse(inputExcRow.Text);
            if (row1 < 1 || row2 < 1 || row1 > spreadSheet.spreadSheet.Count || row2 > spreadSheet.spreadSheet.Count)
            {
                MessageBox.Show("Enter a valid place in the spreadsheet", "Error");
                return;
            }
            if (row1 == row2)
            {
                MessageBox.Show("Can't swap the same row", "Error");
                return;
            }
            if (spreadSheet.exchangeRows(row1, row2))
            {
                refreshTable();
                MessageBox.Show("Rows " + row1 + " and " + row2 + " have been replaced");
            }
            else
                MessageBox.Show("Rows " + row1 + " and " + row2 + " failed to be replaced");
            inputExcRow.Text = "";
            excRowCom.Text = "";
        }

        private void exchangeCol_Click(object sender, EventArgs e)
        {
            if (excColCom.Text == "" || inputColExc.Text == "")
            {
                MessageBox.Show("Enter a valid place in the spreadsheet", "Error");
                return;
            }
            int col1 = Int32.Parse(excColCom.Text);
            int col2 = Int32.Parse(inputColExc.Text);
            if (col1 == col2)
            {
                MessageBox.Show("Can't swap the same col", "Error");
                return;
            }
            if (col1 < 1 || col2 <1 || col1 > spreadSheet.spreadSheet[0].Count || col2> spreadSheet.spreadSheet[0].Count)
            {
                MessageBox.Show("Enter a valid place in the spreadsheet", "Error");
                return;
            }
            if (spreadSheet.exchangeRows(col1, col2))
            {
                refreshTable();
                MessageBox.Show("Columns " + col1 + " and " + col2 + " have been replaced");
            }
            else
                MessageBox.Show("Columns " + col1 + " and " + col2 + " failed to be replaced");
            inputColExc.Text = "";
            excColCom.Text = "";
        }

        private void searchInRow_Click(object sender, EventArgs e)
        {
            string str = searchInRowCom.Text;
            if (inputSearchInRow.Text == "")
            {
                MessageBox.Show("Enter a valid place in the spreadsheet", "Error");
                return;
            }
            int row = Int32.Parse(inputSearchInRow.Text);
            if (row < 1 || row > spreadSheet.spreadSheet.Count)
            {
                MessageBox.Show("Enter a valid place in the spreadsheet", "Error");
                return;
            }
            int col = 0;
            if (spreadSheet.searchInRow(row, str, ref col))
                MessageBox.Show(str + " found in cell [" + row + "," + col + "]");
            else
                MessageBox.Show(str + " not found in row "+ row);
            searchInRowCom.Text = "";
            inputSearchInRow.Text = "";
         
        }

        private void searchInCol_Click(object sender, EventArgs e)
        {
            string str = textBox3.Text;
            if (textBox2.Text == "")
            {
                MessageBox.Show("Enter a valid place in the spreadsheet", "Error");
                return;
            }
            int col = Int32.Parse(textBox2.Text);
            if (col < 1 || col > spreadSheet.spreadSheet[0].Count)
            {
                MessageBox.Show("Enter a valid place in the spreadsheet", "Error");
                return;
            }
            int row = 0;
            if (spreadSheet.searchInCol(col, str, ref row))
                MessageBox.Show(str + " found in cell [" + row + "," + col + "]");
            else
                MessageBox.Show(str + " not found in col " + col);
            textBox3.Text = "";
            textBox2.Text = "";

        }

        private void searchStr_Click(object sender, EventArgs e)
        {
            string str = inputB.Text;
            Random rnd = new Random();
            //random num for row,column of cell
            int row = 0;
            int col = 0;
            if (spreadSheet.searchString(str, ref row, ref col))
                MessageBox.Show(str + " found in cell [" + row + "," + col + "]");
            else
                MessageBox.Show(str + " not found");
            inputB.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SpreadsheetAppMain_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dataTable;
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;
                if (!filePath.Contains(".dat") || filePath == "")
                {
                    MessageBox.Show("File must be saved in 'name.dat' format", "Error");
                    return;
                }
                else
                {
                    spreadSheet.save(filePath);
                    MessageBox.Show("The Spreadsheet was saved successfuly", "Notice");
                }
            }

        }

        private void add_Row_CheckedChanged(object sender, EventArgs e)
        {
            addRow = true;
        }

        private void add_Col_CheckedChanged(object sender, EventArgs e)
        {
            addRow = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                return;
            try
            {
                addIndex = Int32.Parse(textBox1.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Must be a number", "Error");
                textBox1.Text = "";
            }
            
        }

        private void add_Row_Col_Click(object sender, EventArgs e)
        {
            if (addRow)
            {
                if (addIndex < 0 || addIndex > spreadSheet.spreadSheet.Count || addIndex == 0)
                {
                    MessageBox.Show("Enter a valid place in the spreadsheet" , "Error");
                    return;
                }
                spreadSheet.addRow(addIndex);
            }
            else
            {
                if (addIndex < 0 || addIndex > spreadSheet.spreadSheet[0].Count)
                {
                    MessageBox.Show("Enter a valid place in the spreadsheet", "Error");
                    return;
                }
                spreadSheet.addCol(addIndex);
            }
            refreshTable();
        }

        private void new_table_Click(object sender, EventArgs e)
        {
            DialogResult makeNew = MessageBox.Show("Are you sure you want to make a new table?\nAll unsaved changes will be deleted.", "Warning", MessageBoxButtons.OKCancel);
            if (makeNew == DialogResult.OK)
            {
                spreadSheet = new SharableSpreadsheet(1, 1);
                dataTable = new DataTable();
                int row = 0;
                int col = 0;
                spreadSheet.getSize(ref row, ref col);
                for (int c = 0; c < col; c++)
                {
                    dataTable.Columns.Add("Column " + (c + 1), typeof(string));
                }
                for (int r = 0; r < row; r++)
                {
                    dataTable.Rows.Add((spreadSheet.spreadSheet[r]).ToArray());
                }
                dataGridView1.DataSource = dataTable;
                MessageBox.Show("A new Spreadsheet has been successfuly made", "Notice");
            }
            
        }

        private void inputSearchInRow_TextChanged(object sender, EventArgs e)
        {
            if (inputSearchInRow.Text == "")
                return;
            try
            {
                addIndex = Int32.Parse(inputSearchInRow.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Must be a number", "Error");
                inputSearchInRow.Text = "";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
                return;
            try
            {
                addIndex = Int32.Parse(textBox2.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Must be a number", "Error");
                textBox2.Text = "";
            }
        }

        private void excRowCom_TextChanged(object sender, EventArgs e)
        {
            if (excRowCom.Text == "")
                return;
            try
            {
                addIndex = Int32.Parse(excRowCom.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Must be a number", "Error");
                excRowCom.Text = "";
            }
        }

        private void inputExcRow_TextChanged(object sender, EventArgs e)
        {
            if (inputExcRow.Text == "")
                return;
            try
            {
                addIndex = Int32.Parse(inputExcRow.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Must be a number", "Error");
                inputExcRow.Text = "";
            }
        }

        private void excColCom_TextChanged(object sender, EventArgs e)
        {
            if (excColCom.Text == "")
                return;
            try
            {
                addIndex = Int32.Parse(excColCom.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Must be a number", "Error");
                excColCom.Text = "";
            }
        }

        private void inputColExc_TextChanged(object sender, EventArgs e)
        {
            if (inputColExc.Text == "")
                return;
            try
            {
                addIndex = Int32.Parse(inputColExc.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Must be a number", "Error");
                inputColExc.Text = "";
            }
        }
    }
}
