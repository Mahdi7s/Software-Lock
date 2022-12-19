namespace SabaMediaLock.Locker.Controllers
{
    partial class DefaultThemes
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ddlProp = new Telerik.WinControls.UI.RadDropDownList();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.ddlWhichForm = new Telerik.WinControls.UI.RadDropDownList();
            this.ddlItem = new Telerik.WinControls.UI.RadDropDownList();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAdd = new Telerik.WinControls.UI.RadButton();
            this.btnDel = new Telerik.WinControls.UI.RadButton();
            this.themeSelector1 = new SabaMediaLock.Locker.Controllers.ThemeSelector();
            this.whichControl1 = new SabaMediaLock.Locker.Controllers.WhichControl();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlProp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlWhichForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlItem)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDel)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.tableLayoutPanel1);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1038, 583);
            this.radPanel1.TabIndex = 0;
            this.radPanel1.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.ddlProp, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.radGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ddlWhichForm, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ddlItem, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.themeSelector1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.whichControl1, 3, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1038, 583);
            this.tableLayoutPanel1.TabIndex = 2;
            this.tableLayoutPanel1.Visible = false;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // ddlProp
            // 
            this.ddlProp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlProp.AutoCompleteDisplayMember = "Item2";
            this.ddlProp.DataMember = "Item1";
            this.ddlProp.DisplayMember = "Item2";
            this.ddlProp.DropDownAnimationEnabled = true;
            this.ddlProp.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlProp.Location = new System.Drawing.Point(420, 550);
            this.ddlProp.MaxDropDownItems = 0;
            this.ddlProp.Name = "ddlProp";
            this.ddlProp.NullText = "انتخاب صفت";
            this.ddlProp.ShowImageInEditorArea = true;
            this.ddlProp.Size = new System.Drawing.Size(201, 20);
            this.ddlProp.SortStyle = Telerik.WinControls.Enumerations.SortStyle.Ascending;
            this.ddlProp.TabIndex = 10;
            this.ddlProp.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.ddlProp_SelectedIndexChanged);
            // 
            // radGridView1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.radGridView1, 5);
            this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView1.Location = new System.Drawing.Point(3, 38);
            // 
            // radGridView1
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.radGridView1.MasterTemplate.AllowColumnReorder = false;
            this.radGridView1.MasterTemplate.AllowDragToGroup = false;
            this.radGridView1.MasterTemplate.AllowEditRow = false;
            this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.Size = new System.Drawing.Size(1032, 496);
            this.radGridView1.TabIndex = 13;
            // 
            // ddlWhichForm
            // 
            this.ddlWhichForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlWhichForm.AutoCompleteDisplayMember = "Item2";
            this.ddlWhichForm.DataMember = "Item1";
            this.ddlWhichForm.DisplayMember = "Item2";
            this.ddlWhichForm.DropDownAnimationEnabled = true;
            this.ddlWhichForm.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlWhichForm.Location = new System.Drawing.Point(834, 550);
            this.ddlWhichForm.MaxDropDownItems = 0;
            this.ddlWhichForm.Name = "ddlWhichForm";
            this.ddlWhichForm.NullText = "انتخاب فرم مورد نظر";
            this.ddlWhichForm.ShowImageInEditorArea = true;
            this.ddlWhichForm.Size = new System.Drawing.Size(201, 20);
            this.ddlWhichForm.SortStyle = Telerik.WinControls.Enumerations.SortStyle.Ascending;
            this.ddlWhichForm.TabIndex = 8;
            this.ddlWhichForm.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.ddlWhichForm_SelectedIndexChanged);
            // 
            // ddlItem
            // 
            this.ddlItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlItem.AutoCompleteDisplayMember = "Item3";
            this.ddlItem.DataMember = "Item1";
            this.ddlItem.DisplayMember = "Item3";
            this.ddlItem.DropDownAnimationEnabled = true;
            this.ddlItem.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlItem.Location = new System.Drawing.Point(627, 550);
            this.ddlItem.MaxDropDownItems = 0;
            this.ddlItem.Name = "ddlItem";
            this.ddlItem.NullText = "انتخاب آیتم";
            this.ddlItem.ShowImageInEditorArea = true;
            this.ddlItem.Size = new System.Drawing.Size(201, 20);
            this.ddlItem.SortStyle = Telerik.WinControls.Enumerations.SortStyle.Ascending;
            this.ddlItem.TabIndex = 9;
            this.ddlItem.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.ddlItem_SelectedIndexChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.btnAdd, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnDel, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 540);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(80, 40);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.AutoSize = true;
            this.btnAdd.BackColor = System.Drawing.Color.Silver;
            this.btnAdd.DisplayStyle = Telerik.WinControls.DisplayStyle.Image;
            this.btnAdd.Image = global::SabaMediaLock.Locker.Properties.Resources.Add_32;
            this.btnAdd.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAdd.Location = new System.Drawing.Point(3, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(34, 34);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "اضافه کردن";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.AutoSize = true;
            this.btnDel.DisplayStyle = Telerik.WinControls.DisplayStyle.Image;
            this.btnDel.Image = global::SabaMediaLock.Locker.Properties.Resources.Delete_32;
            this.btnDel.Location = new System.Drawing.Point(43, 3);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(34, 34);
            this.btnDel.TabIndex = 14;
            this.btnDel.Text = "حذف کردن";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // themeSelector1
            // 
            this.themeSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tableLayoutPanel1.SetColumnSpan(this.themeSelector1, 5);
            this.themeSelector1.Location = new System.Drawing.Point(319, 3);
            this.themeSelector1.Name = "themeSelector1";
            this.themeSelector1.ParentPanel = null;
            this.themeSelector1.Size = new System.Drawing.Size(400, 29);
            this.themeSelector1.TabIndex = 15;
            this.themeSelector1.UcToTheming = null;
            this.themeSelector1.OnStylesLoaded += new System.EventHandler(this.themeSelector1_OnStylesLoaded);
            this.themeSelector1.Load += new System.EventHandler(this.themeSelector1_Load);
            // 
            // whichControl1
            // 
            this.whichControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.whichControl1.ControlType = SabaMediaLock.Locker.Controllers.ControlType.FileAddress;
            this.whichControl1.Location = new System.Drawing.Point(214, 550);
            this.whichControl1.Margin = new System.Windows.Forms.Padding(4);
            this.whichControl1.MinimumSize = new System.Drawing.Size(100, 20);
            this.whichControl1.Name = "whichControl1";
            this.whichControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.whichControl1.Size = new System.Drawing.Size(199, 20);
            this.whichControl1.TabIndex = 16;
            this.whichControl1.WhichValue = "";
            // 
            // DefaultThemes
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.radPanel1);
            this.Name = "DefaultThemes";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1038, 583);
            this.Load += new System.EventHandler(this.DefaultThemes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlProp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlWhichForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlItem)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Telerik.WinControls.UI.RadDropDownList ddlProp;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.UI.RadDropDownList ddlWhichForm;
        private Telerik.WinControls.UI.RadDropDownList ddlItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Telerik.WinControls.UI.RadButton btnAdd;
        private Telerik.WinControls.UI.RadButton btnDel;
        private ThemeSelector themeSelector1;
        private WhichControl whichControl1;


    }
}
