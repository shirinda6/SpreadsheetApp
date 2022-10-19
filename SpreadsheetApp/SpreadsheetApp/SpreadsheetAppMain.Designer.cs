
namespace SpreadsheetApp
{
    partial class SpreadsheetAppMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Load = new System.Windows.Forms.Button();
            this.exchangeRow = new System.Windows.Forms.Button();
            this.exchangeCol = new System.Windows.Forms.Button();
            this.searchStr = new System.Windows.Forms.Button();
            this.searchInRow = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.Save = new System.Windows.Forms.Button();
            this.add_Row = new System.Windows.Forms.RadioButton();
            this.add_Col = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.add_Row_Col = new System.Windows.Forms.Button();
            this.new_table = new System.Windows.Forms.Button();
            this.inputB = new System.Windows.Forms.TextBox();
            this.searchInRowCom = new System.Windows.Forms.TextBox();
            this.inputSearchInRow = new System.Windows.Forms.TextBox();
            this.excColCom = new System.Windows.Forms.TextBox();
            this.inputColExc = new System.Windows.Forms.TextBox();
            this.excRowCom = new System.Windows.Forms.TextBox();
            this.inputExcRow = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.searchInCol = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Load
            // 
            this.Load.BackColor = System.Drawing.Color.SteelBlue;
            this.Load.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Load.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.Load.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.Load.Font = new System.Drawing.Font("Trebuchet MS", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Load.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Load.Location = new System.Drawing.Point(11, 7);
            this.Load.Margin = new System.Windows.Forms.Padding(2);
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(114, 40);
            this.Load.TabIndex = 0;
            this.Load.Text = "Load";
            this.Load.UseVisualStyleBackColor = false;
            this.Load.Click += new System.EventHandler(this.Load_Click);
            // 
            // exchangeRow
            // 
            this.exchangeRow.BackColor = System.Drawing.Color.SteelBlue;
            this.exchangeRow.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.exchangeRow.Location = new System.Drawing.Point(449, 299);
            this.exchangeRow.Margin = new System.Windows.Forms.Padding(2);
            this.exchangeRow.Name = "exchangeRow";
            this.exchangeRow.Size = new System.Drawing.Size(114, 40);
            this.exchangeRow.TabIndex = 1;
            this.exchangeRow.Text = "Exchange rows";
            this.exchangeRow.UseVisualStyleBackColor = false;
            this.exchangeRow.Click += new System.EventHandler(this.exchangeRow_Click);
            // 
            // exchangeCol
            // 
            this.exchangeCol.BackColor = System.Drawing.Color.SteelBlue;
            this.exchangeCol.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.exchangeCol.Location = new System.Drawing.Point(567, 299);
            this.exchangeCol.Margin = new System.Windows.Forms.Padding(2);
            this.exchangeCol.Name = "exchangeCol";
            this.exchangeCol.Size = new System.Drawing.Size(114, 40);
            this.exchangeCol.TabIndex = 2;
            this.exchangeCol.Text = "Exchange cols";
            this.exchangeCol.UseVisualStyleBackColor = false;
            this.exchangeCol.Click += new System.EventHandler(this.exchangeCol_Click);
            // 
            // searchStr
            // 
            this.searchStr.BackColor = System.Drawing.Color.SteelBlue;
            this.searchStr.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.searchStr.Location = new System.Drawing.Point(449, 93);
            this.searchStr.Margin = new System.Windows.Forms.Padding(2);
            this.searchStr.Name = "searchStr";
            this.searchStr.Size = new System.Drawing.Size(114, 40);
            this.searchStr.TabIndex = 3;
            this.searchStr.Text = "Search string";
            this.searchStr.UseVisualStyleBackColor = false;
            this.searchStr.Click += new System.EventHandler(this.searchStr_Click);
            // 
            // searchInRow
            // 
            this.searchInRow.BackColor = System.Drawing.Color.SteelBlue;
            this.searchInRow.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.searchInRow.Location = new System.Drawing.Point(449, 191);
            this.searchInRow.Margin = new System.Windows.Forms.Padding(2);
            this.searchInRow.Name = "searchInRow";
            this.searchInRow.Size = new System.Drawing.Size(114, 39);
            this.searchInRow.TabIndex = 4;
            this.searchInRow.Text = "Search in row";
            this.searchInRow.UseVisualStyleBackColor = false;
            this.searchInRow.Click += new System.EventHandler(this.searchInRow_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.MenuBar;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 61);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(433, 278);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.Text = "dataGridView1";
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.Color.SteelBlue;
            this.Save.Font = new System.Drawing.Font("Trebuchet MS", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Save.Location = new System.Drawing.Point(130, 7);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(114, 40);
            this.Save.TabIndex = 6;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.save_Click);
            // 
            // add_Row
            // 
            this.add_Row.AutoSize = true;
            this.add_Row.Checked = true;
            this.add_Row.Location = new System.Drawing.Point(490, 7);
            this.add_Row.Name = "add_Row";
            this.add_Row.Size = new System.Drawing.Size(56, 19);
            this.add_Row.TabIndex = 7;
            this.add_Row.TabStop = true;
            this.add_Row.Text = "A row";
            this.add_Row.UseVisualStyleBackColor = true;
            this.add_Row.CheckedChanged += new System.EventHandler(this.add_Row_CheckedChanged);
            // 
            // add_Col
            // 
            this.add_Col.AutoSize = true;
            this.add_Col.Location = new System.Drawing.Point(490, 27);
            this.add_Col.Name = "add_Col";
            this.add_Col.Size = new System.Drawing.Size(52, 19);
            this.add_Col.TabIndex = 7;
            this.add_Col.TabStop = true;
            this.add_Col.Text = "A col";
            this.add_Col.UseVisualStyleBackColor = true;
            this.add_Col.CheckedChanged += new System.EventHandler(this.add_Col_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(615, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(28, 23);
            this.textBox1.TabIndex = 8;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(545, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "After place";
            // 
            // add_Row_Col
            // 
            this.add_Row_Col.BackColor = System.Drawing.Color.SteelBlue;
            this.add_Row_Col.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.add_Row_Col.Location = new System.Drawing.Point(370, 6);
            this.add_Row_Col.Name = "add_Row_Col";
            this.add_Row_Col.Size = new System.Drawing.Size(114, 41);
            this.add_Row_Col.TabIndex = 11;
            this.add_Row_Col.Text = "Add";
            this.add_Row_Col.UseVisualStyleBackColor = false;
            this.add_Row_Col.Click += new System.EventHandler(this.add_Row_Col_Click);
            // 
            // new_table
            // 
            this.new_table.BackColor = System.Drawing.Color.SteelBlue;
            this.new_table.Font = new System.Drawing.Font("Trebuchet MS", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.new_table.Location = new System.Drawing.Point(250, 7);
            this.new_table.Name = "new_table";
            this.new_table.Size = new System.Drawing.Size(114, 41);
            this.new_table.TabIndex = 12;
            this.new_table.Text = "New";
            this.new_table.UseVisualStyleBackColor = false;
            this.new_table.Click += new System.EventHandler(this.new_table_Click);
            // 
            // inputB
            // 
            this.inputB.Location = new System.Drawing.Point(449, 62);
            this.inputB.Margin = new System.Windows.Forms.Padding(2);
            this.inputB.Name = "inputB";
            this.inputB.Size = new System.Drawing.Size(114, 23);
            this.inputB.TabIndex = 14;
            // 
            // searchInRowCom
            // 
            this.searchInRowCom.Location = new System.Drawing.Point(499, 137);
            this.searchInRowCom.Margin = new System.Windows.Forms.Padding(2);
            this.searchInRowCom.Name = "searchInRowCom";
            this.searchInRowCom.Size = new System.Drawing.Size(64, 23);
            this.searchInRowCom.TabIndex = 16;
            // 
            // inputSearchInRow
            // 
            this.inputSearchInRow.Location = new System.Drawing.Point(499, 164);
            this.inputSearchInRow.Margin = new System.Windows.Forms.Padding(2);
            this.inputSearchInRow.Name = "inputSearchInRow";
            this.inputSearchInRow.Size = new System.Drawing.Size(64, 23);
            this.inputSearchInRow.TabIndex = 17;
            this.inputSearchInRow.TextChanged += new System.EventHandler(this.inputSearchInRow_TextChanged);
            // 
            // excColCom
            // 
            this.excColCom.Location = new System.Drawing.Point(615, 245);
            this.excColCom.Margin = new System.Windows.Forms.Padding(2);
            this.excColCom.Name = "excColCom";
            this.excColCom.Size = new System.Drawing.Size(66, 23);
            this.excColCom.TabIndex = 19;
            this.excColCom.TextChanged += new System.EventHandler(this.excColCom_TextChanged);
            // 
            // inputColExc
            // 
            this.inputColExc.Location = new System.Drawing.Point(615, 272);
            this.inputColExc.Margin = new System.Windows.Forms.Padding(2);
            this.inputColExc.Name = "inputColExc";
            this.inputColExc.Size = new System.Drawing.Size(66, 23);
            this.inputColExc.TabIndex = 20;
            this.inputColExc.TextChanged += new System.EventHandler(this.inputColExc_TextChanged);
            // 
            // excRowCom
            // 
            this.excRowCom.Location = new System.Drawing.Point(497, 245);
            this.excRowCom.Margin = new System.Windows.Forms.Padding(2);
            this.excRowCom.Name = "excRowCom";
            this.excRowCom.Size = new System.Drawing.Size(66, 23);
            this.excRowCom.TabIndex = 21;
            this.excRowCom.TextChanged += new System.EventHandler(this.excRowCom_TextChanged);
            // 
            // inputExcRow
            // 
            this.inputExcRow.Location = new System.Drawing.Point(497, 272);
            this.inputExcRow.Margin = new System.Windows.Forms.Padding(2);
            this.inputExcRow.Name = "inputExcRow";
            this.inputExcRow.Size = new System.Drawing.Size(66, 23);
            this.inputExcRow.TabIndex = 22;
            this.inputExcRow.TextChanged += new System.EventHandler(this.inputExcRow_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(449, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "String";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(449, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Row";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(449, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Row 1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(449, 275);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Row 2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(567, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Col 1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(566, 275);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "Col 2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(568, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 15);
            this.label8.TabIndex = 9;
            this.label8.Text = "Col";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(568, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "String";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(618, 164);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(64, 23);
            this.textBox2.TabIndex = 17;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(618, 137);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(64, 23);
            this.textBox3.TabIndex = 16;
            // 
            // searchInCol
            // 
            this.searchInCol.BackColor = System.Drawing.Color.SteelBlue;
            this.searchInCol.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.searchInCol.Location = new System.Drawing.Point(568, 191);
            this.searchInCol.Margin = new System.Windows.Forms.Padding(2);
            this.searchInCol.Name = "searchInCol";
            this.searchInCol.Size = new System.Drawing.Size(114, 39);
            this.searchInCol.TabIndex = 4;
            this.searchInCol.Text = "Search in col";
            this.searchInCol.UseVisualStyleBackColor = false;
            this.searchInCol.Click += new System.EventHandler(this.searchInCol_Click);
            // 
            // SpreadsheetAppMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(693, 355);
            this.Controls.Add(this.searchInCol);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inputExcRow);
            this.Controls.Add(this.excRowCom);
            this.Controls.Add(this.inputColExc);
            this.Controls.Add(this.excColCom);
            this.Controls.Add(this.inputSearchInRow);
            this.Controls.Add(this.searchInRowCom);
            this.Controls.Add(this.inputB);
            this.Controls.Add(this.new_table);
            this.Controls.Add(this.add_Row_Col);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.add_Col);
            this.Controls.Add(this.add_Row);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.searchInRow);
            this.Controls.Add(this.searchStr);
            this.Controls.Add(this.exchangeCol);
            this.Controls.Add(this.exchangeRow);
            this.Controls.Add(this.Load);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SpreadsheetAppMain";
            this.Text = "SpreadsheetAppMain";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Load;
        private System.Windows.Forms.Button exchangeRow;
        private System.Windows.Forms.Button exchangeCol;
        private System.Windows.Forms.Button searchStr;
        private System.Windows.Forms.Button searchInRow;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.RadioButton add_Row;
        private System.Windows.Forms.RadioButton add_Col;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button add_Row_Col;
        private System.Windows.Forms.Button new_table;
        private System.Windows.Forms.TextBox inputB;
        private System.Windows.Forms.TextBox searchInRowCom;
        private System.Windows.Forms.TextBox inputSearchInRow;
        private System.Windows.Forms.TextBox excColCom;
        private System.Windows.Forms.TextBox inputColExc;
        private System.Windows.Forms.TextBox excRowCom;
        private System.Windows.Forms.TextBox inputExcRow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button searchInCol;
    }
}

