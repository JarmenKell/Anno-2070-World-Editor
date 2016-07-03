namespace Anno_2070_World_Editor
{
    partial class Editor
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.datagrid = new System.Windows.Forms.DataGridView();
            this.save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.size = new System.Windows.Forms.ComboBox();
            this.generate = new System.Windows.Forms.Button();
            this.leftto = new System.Windows.Forms.MaskedTextBox();
            this.toright = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.arkgrid = new System.Windows.Forms.DataGridView();
            this.arkx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arky = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.resourcegrid = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.nummer = new System.Windows.Forms.Label();
            this.k = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.direction = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.positionx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.positiony = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xysize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_resources = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_fertility = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arkgrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourcegrid)).BeginInit();
            this.SuspendLayout();
            // 
            // datagrid
            // 
            this.datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.k,
            this.name,
            this.direction,
            this.type,
            this.positionx,
            this.positiony,
            this.xysize});
            this.datagrid.Location = new System.Drawing.Point(153, 41);
            this.datagrid.MultiSelect = false;
            this.datagrid.Name = "datagrid";
            this.datagrid.Size = new System.Drawing.Size(412, 375);
            this.datagrid.TabIndex = 0;
            // 
            // save
            // 
            this.save.AutoSize = true;
            this.save.Location = new System.Drawing.Point(177, 12);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(65, 23);
            this.save.TabIndex = 1;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(248, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mapsize";
            // 
            // size
            // 
            this.size.FormattingEnabled = true;
            this.size.Items.AddRange(new object[] {
            "Big",
            "Medium",
            "Small"});
            this.size.Location = new System.Drawing.Point(336, 11);
            this.size.Name = "size";
            this.size.Size = new System.Drawing.Size(58, 21);
            this.size.TabIndex = 3;
            // 
            // generate
            // 
            this.generate.Location = new System.Drawing.Point(403, 9);
            this.generate.Name = "generate";
            this.generate.Size = new System.Drawing.Size(76, 23);
            this.generate.TabIndex = 4;
            this.generate.Text = "Update";
            this.generate.UseVisualStyleBackColor = true;
            this.generate.Click += new System.EventHandler(this.generate_Click);
            // 
            // leftto
            // 
            this.leftto.Location = new System.Drawing.Point(485, 12);
            this.leftto.Mask = "0";
            this.leftto.Name = "leftto";
            this.leftto.Size = new System.Drawing.Size(15, 20);
            this.leftto.TabIndex = 5;
            this.leftto.Text = "1";
            // 
            // toright
            // 
            this.toright.Location = new System.Drawing.Point(517, 12);
            this.toright.Mask = "0";
            this.toright.Name = "toright";
            this.toright.Size = new System.Drawing.Size(15, 20);
            this.toright.TabIndex = 6;
            this.toright.Text = "3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(500, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "to";
            // 
            // arkgrid
            // 
            this.arkgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.arkgrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.arkx,
            this.arky});
            this.arkgrid.Location = new System.Drawing.Point(12, 41);
            this.arkgrid.Name = "arkgrid";
            this.arkgrid.Size = new System.Drawing.Size(134, 375);
            this.arkgrid.TabIndex = 8;
            // 
            // arkx
            // 
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.arkx.DefaultCellStyle = dataGridViewCellStyle13;
            this.arkx.HeaderText = "PosX";
            this.arkx.Name = "arkx";
            this.arkx.Width = 37;
            // 
            // arky
            // 
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.arky.DefaultCellStyle = dataGridViewCellStyle14;
            this.arky.HeaderText = "PosY";
            this.arky.Name = "arky";
            this.arky.Width = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(43, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Arc Spots";
            // 
            // resourcegrid
            // 
            this.resourcegrid.AllowUserToAddRows = false;
            this.resourcegrid.AllowUserToDeleteRows = false;
            this.resourcegrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resourcegrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.m_resources,
            this.Column2,
            this.m_fertility});
            this.resourcegrid.Location = new System.Drawing.Point(571, 41);
            this.resourcegrid.Name = "resourcegrid";
            this.resourcegrid.RowHeadersWidth = 4;
            this.resourcegrid.Size = new System.Drawing.Size(231, 375);
            this.resourcegrid.TabIndex = 10;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Anno World|*.www";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(608, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Island Number";
            // 
            // nummer
            // 
            this.nummer.AutoSize = true;
            this.nummer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nummer.Location = new System.Drawing.Point(709, 16);
            this.nummer.Name = "nummer";
            this.nummer.Size = new System.Drawing.Size(15, 16);
            this.nummer.TabIndex = 12;
            this.nummer.Text = "0";
            // 
            // k
            // 
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.White;
            this.k.DefaultCellStyle = dataGridViewCellStyle15;
            this.k.HeaderText = "Index";
            this.k.Name = "k";
            this.k.ReadOnly = true;
            this.k.Width = 40;
            // 
            // name
            // 
            dataGridViewCellStyle16.NullValue = "Wählen";
            this.name.DefaultCellStyle = dataGridViewCellStyle16;
            this.name.HeaderText = "Island Name";
            this.name.Items.AddRange(new object[] {
            "N_D01",
            "N_D02",
            "N_D03",
            "N_D04",
            "N_D05",
            "N_D06",
            "N_D07",
            "N_D08",
            "N_D09",
            "N_D10",
            "N_D11",
            "N_D12",
            "N_D13",
            "N_D14",
            "N_D15",
            "N_D16",
            "N_D17",
            "N_D18",
            "N_D19",
            "N_D20",
            "N_L01",
            "N_L02",
            "N_L03",
            "N_L04",
            "N_L05",
            "N_L06",
            "N_L07",
            "N_L08",
            "N_L09",
            "N_L10",
            "N_L11",
            "N_L12",
            "N_L13",
            "N_L14",
            "N_L15",
            "N_L16",
            "N_L17",
            "N_L18",
            "N_L19",
            "N_L20",
            "N_L21",
            "N_L22",
            "N_L25",
            "N_L26",
            "N_L29",
            "N_L30",
            "N_L31",
            "N_L32",
            "N_L34",
            "N_L35",
            "N_L03p",
            "N_L05p",
            "N_L07p",
            "N_L09p",
            "N_L10p",
            "N_L12p",
            "N_L13p",
            "N_L15p",
            "N_L16p",
            "N_L17p",
            "N_L18p",
            "N_L19p",
            "N_L20p",
            "N_L22p",
            "N_L25p",
            "N_L26p",
            "N_L32p",
            "N_L34p",
            "N_L35p",
            "N_L03n",
            "N_L05n",
            "N_L07n",
            "N_L09n",
            "N_L10n",
            "N_L12n",
            "N_L13n",
            "N_L15n",
            "N_L16n",
            "N_L17n",
            "N_L18n",
            "N_L19n",
            "N_L20n",
            "N_L22n",
            "N_L25n",
            "N_L26n",
            "N_L32n",
            "N_L34n",
            "N_L35n",
            "N_M01",
            "N_M02",
            "N_M03",
            "N_M04",
            "N_M05",
            "N_M06",
            "N_M07",
            "N_M08",
            "N_M09",
            "N_M10",
            "N_M11",
            "N_M12",
            "N_M13",
            "N_M14",
            "N_M15",
            "N_M16",
            "N_M17",
            "N_M18",
            "N_M19",
            "N_M20",
            "N_M01p",
            "N_M02p",
            "N_M04p",
            "N_M05p",
            "N_M07p",
            "N_M08p",
            "N_M12p",
            "N_M19p",
            "N_M20p",
            "N_M01n",
            "N_M02n",
            "N_M04n",
            "N_M05n",
            "N_M07n",
            "N_M08n",
            "N_M12n",
            "N_M19n",
            "N_M20n",
            "N_S01",
            "N_S02",
            "N_S03",
            "N_S04",
            "N_S05",
            "N_S06",
            "N_S07",
            "N_S08",
            "N_S09",
            "N_S10",
            "U_D01",
            "U_D02",
            "U_D03",
            "U_D04",
            "U_D05",
            "U_D06",
            "U_D07",
            "U_D08",
            "U_D09",
            "U_D10",
            "U_D11",
            "U_D12",
            "U_D13",
            "U_D14",
            "U_L03",
            "U_L04",
            "U_L05",
            "U_L06",
            "U_M01",
            "U_M02",
            "U_M03",
            "U_M04",
            "U_M06",
            "U_M07",
            "U_M08",
            "U_M10",
            "U_M13",
            "U_M14",
            "U_M15",
            "U_M16",
            "U_S01",
            "U_S02",
            "U_S03",
            "U_S05",
            "U_S06",
            "U_S07",
            "U_S08",
            "U_L03_addon",
            "U_L03_rift",
            "U_L04_addon",
            "U_L04_rift",
            "U_L05_addon",
            "U_L05_rift",
            "U_L06_addon",
            "U_L06_rift",
            "U_M01_addon",
            "U_M01_rift",
            "U_M02_addon",
            "U_M02_rift",
            "U_M03_addon",
            "U_M03_rift",
            "U_M04_addon",
            "U_M04_rift",
            "U_M05_addon",
            "U_M05_rift",
            "U_M06_addon",
            "U_M06_rift",
            "U_M07_addon",
            "U_M07_rift",
            "U_M08_addon",
            "U_M08_rift",
            "U_M10_addon",
            "U_M10_rift",
            "U_M13_addon",
            "U_M13_rift",
            "U_M14_addon",
            "U_M14_rift",
            "U_M15_addon",
            "U_M15_rift",
            "U_M16_addon",
            "U_M16_rift",
            "U_S01_addon",
            "U_S01_rift",
            "U_S02_addon",
            "U_S02_rift",
            "U_S03_addon",
            "U_S03_rift",
            "U_S05_addon",
            "U_S05_rift",
            "U_S06_addon",
            "U_S06_rift",
            "U_S07_addon",
            "U_S07_rift",
            "U_S08_addon",
            "U_S08_rift",
            "N_X01",
            "N_X02",
            "N_X03",
            "U_X01",
            "U_X02",
            "U_X03",
            "U_X01_rift",
            "U_X02_rift",
            "U_X03_rift"});
            this.name.Name = "name";
            this.name.Width = 79;
            // 
            // direction
            // 
            this.direction.HeaderText = "Direction";
            this.direction.Items.AddRange(new object[] {
            "North",
            "East",
            "South",
            "West"});
            this.direction.Name = "direction";
            this.direction.Width = 60;
            // 
            // type
            // 
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.White;
            this.type.DefaultCellStyle = dataGridViewCellStyle17;
            this.type.HeaderText = "Islandtype";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            this.type.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.type.Width = 62;
            // 
            // positionx
            // 
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.positionx.DefaultCellStyle = dataGridViewCellStyle18;
            this.positionx.HeaderText = "PosX";
            this.positionx.Name = "positionx";
            this.positionx.Width = 37;
            // 
            // positiony
            // 
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.positiony.DefaultCellStyle = dataGridViewCellStyle19;
            this.positiony.HeaderText = "PosY";
            this.positiony.Name = "positiony";
            this.positiony.Width = 37;
            // 
            // xysize
            // 
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.White;
            this.xysize.DefaultCellStyle = dataGridViewCellStyle20;
            this.xysize.HeaderText = "Size";
            this.xysize.Name = "xysize";
            this.xysize.ReadOnly = true;
            this.xysize.Width = 37;
            // 
            // Column1
            // 
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.White;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle21;
            this.Column1.HeaderText = "Resources";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 55;
            // 
            // m_resources
            // 
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle22.NullValue = null;
            this.m_resources.DefaultCellStyle = dataGridViewCellStyle22;
            this.m_resources.HeaderText = "Amount";
            this.m_resources.Name = "m_resources";
            this.m_resources.Width = 68;
            // 
            // Column2
            // 
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.White;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle23;
            this.Column2.HeaderText = "Fertility";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 82;
            // 
            // m_fertility
            // 
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle24.NullValue = false;
            this.m_fertility.DefaultCellStyle = dataGridViewCellStyle24;
            this.m_fertility.HeaderText = "";
            this.m_fertility.Name = "m_fertility";
            this.m_fertility.Width = 20;
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 429);
            this.Controls.Add(this.nummer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.resourcegrid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.arkgrid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.toright);
            this.Controls.Add(this.leftto);
            this.Controls.Add(this.generate);
            this.Controls.Add(this.size);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.save);
            this.Controls.Add(this.datagrid);
            this.Name = "Editor";
            this.Text = "Anno 2070 World Editor";
            ((System.ComponentModel.ISupportInitialize)(this.datagrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arkgrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourcegrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView datagrid;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox size;
        private System.Windows.Forms.Button generate;
        private System.Windows.Forms.MaskedTextBox leftto;
        private System.Windows.Forms.MaskedTextBox toright;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView arkgrid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView resourcegrid;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label nummer;
        private System.Windows.Forms.DataGridViewTextBoxColumn arkx;
        private System.Windows.Forms.DataGridViewTextBoxColumn arky;
        private System.Windows.Forms.DataGridViewTextBoxColumn k;
        private System.Windows.Forms.DataGridViewComboBoxColumn name;
        private System.Windows.Forms.DataGridViewComboBoxColumn direction;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionx;
        private System.Windows.Forms.DataGridViewTextBoxColumn positiony;
        private System.Windows.Forms.DataGridViewTextBoxColumn xysize;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_resources;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn m_fertility;
    }
}

