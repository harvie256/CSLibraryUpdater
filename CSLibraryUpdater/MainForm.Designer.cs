namespace CSLibraryUpdater
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOpenSchLib = new System.Windows.Forms.Button();
            this.lbxComponents = new System.Windows.Forms.ListBox();
            this.gVparameters = new System.Windows.Forms.DataGridView();
            this.ParamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParamValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParamId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLoadSupplierData = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAddSupplier = new System.Windows.Forms.Button();
            this.btnClearAllParameters = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gVparameters)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpenSchLib
            // 
            this.btnOpenSchLib.Location = new System.Drawing.Point(8, 14);
            this.btnOpenSchLib.Name = "btnOpenSchLib";
            this.btnOpenSchLib.Size = new System.Drawing.Size(118, 23);
            this.btnOpenSchLib.TabIndex = 0;
            this.btnOpenSchLib.Text = "Open Sch Library";
            this.btnOpenSchLib.UseVisualStyleBackColor = true;
            this.btnOpenSchLib.Click += new System.EventHandler(this.btnOpenSchLib_Click);
            // 
            // lbxComponents
            // 
            this.lbxComponents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbxComponents.FormattingEnabled = true;
            this.lbxComponents.Location = new System.Drawing.Point(8, 43);
            this.lbxComponents.Name = "lbxComponents";
            this.lbxComponents.Size = new System.Drawing.Size(298, 433);
            this.lbxComponents.TabIndex = 1;
            this.lbxComponents.SelectedIndexChanged += new System.EventHandler(this.lbxComponents_SelectedIndexChanged);
            // 
            // gVparameters
            // 
            this.gVparameters.AllowUserToAddRows = false;
            this.gVparameters.AllowUserToDeleteRows = false;
            this.gVparameters.AllowUserToOrderColumns = true;
            this.gVparameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gVparameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gVparameters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ParamName,
            this.ParamValue,
            this.ParamId});
            this.gVparameters.Location = new System.Drawing.Point(310, 43);
            this.gVparameters.Name = "gVparameters";
            this.gVparameters.ReadOnly = true;
            this.gVparameters.Size = new System.Drawing.Size(390, 431);
            this.gVparameters.TabIndex = 2;
            // 
            // ParamName
            // 
            this.ParamName.HeaderText = "Name";
            this.ParamName.Name = "ParamName";
            this.ParamName.ReadOnly = true;
            // 
            // ParamValue
            // 
            this.ParamValue.HeaderText = "Value";
            this.ParamValue.Name = "ParamValue";
            this.ParamValue.ReadOnly = true;
            // 
            // ParamId
            // 
            this.ParamId.HeaderText = "Unique ID";
            this.ParamId.Name = "ParamId";
            this.ParamId.ReadOnly = true;
            // 
            // btnLoadSupplierData
            // 
            this.btnLoadSupplierData.Enabled = false;
            this.btnLoadSupplierData.Location = new System.Drawing.Point(310, 14);
            this.btnLoadSupplierData.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLoadSupplierData.Name = "btnLoadSupplierData";
            this.btnLoadSupplierData.Size = new System.Drawing.Size(109, 23);
            this.btnLoadSupplierData.TabIndex = 3;
            this.btnLoadSupplierData.Text = "Load Supplier Data";
            this.btnLoadSupplierData.UseVisualStyleBackColor = true;
            this.btnLoadSupplierData.Click += new System.EventHandler(this.btnLoadSupplierData_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(130, 14);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(134, 24);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAddSupplier
            // 
            this.btnAddSupplier.Location = new System.Drawing.Point(422, 14);
            this.btnAddSupplier.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddSupplier.Name = "btnAddSupplier";
            this.btnAddSupplier.Size = new System.Drawing.Size(88, 22);
            this.btnAddSupplier.TabIndex = 5;
            this.btnAddSupplier.Text = "AddSupplier";
            this.btnAddSupplier.UseVisualStyleBackColor = true;
            this.btnAddSupplier.Click += new System.EventHandler(this.btnAddSupplier_Click);
            // 
            // btnClearAllParameters
            // 
            this.btnClearAllParameters.Location = new System.Drawing.Point(516, 13);
            this.btnClearAllParameters.Name = "btnClearAllParameters";
            this.btnClearAllParameters.Size = new System.Drawing.Size(75, 23);
            this.btnClearAllParameters.TabIndex = 6;
            this.btnClearAllParameters.Text = "Clear All";
            this.btnClearAllParameters.UseVisualStyleBackColor = true;
            this.btnClearAllParameters.Click += new System.EventHandler(this.btnClearAllParameters_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 489);
            this.Controls.Add(this.btnClearAllParameters);
            this.Controls.Add(this.btnAddSupplier);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoadSupplierData);
            this.Controls.Add(this.gVparameters);
            this.Controls.Add(this.lbxComponents);
            this.Controls.Add(this.btnOpenSchLib);
            this.Name = "MainForm";
            this.Text = "SchLib Helper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gVparameters)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenSchLib;
        private System.Windows.Forms.ListBox lbxComponents;
        private System.Windows.Forms.DataGridView gVparameters;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParamValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParamId;
        private System.Windows.Forms.Button btnLoadSupplierData;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAddSupplier;
        private System.Windows.Forms.Button btnClearAllParameters;
    }
}

