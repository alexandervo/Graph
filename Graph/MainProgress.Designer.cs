namespace Graph
{
    partial class MainProgress
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainProgress));
            this.kryptonContextMenuItem1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.kryptonContextMenuItem2 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.kryptonContextMenuItem3 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.kryptonContextMenuItem4 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.kryptonContextMenuSeparator1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuSeparator();
            this.kryptonContextMenuItem5 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.lvTableView = new System.Windows.Forms.ListView();
            this.lvMatrixView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctMenuStripMatrix = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyMatrixToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlGraph = new System.Windows.Forms.Panel();
            this.picGraphView = new System.Windows.Forms.PictureBox();
            this.ctMenustripGrapView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyGraphImageInClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gboxPath = new System.Windows.Forms.GroupBox();
            this.txbLogDijkstra = new System.Windows.Forms.RichTextBox();
            this.MyOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.MySaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SaveFileDialogImage = new System.Windows.Forms.SaveFileDialog();
            this.MyColorDialog = new System.Windows.Forms.ColorDialog();
            this.panelControl = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gboxLogs = new System.Windows.Forms.GroupBox();
            this.txbLogs = new System.Windows.Forms.RichTextBox();
            this.kryptonRibbon = new ComponentFactory.Krypton.Ribbon.KryptonRibbon();
            this.TabHome = new ComponentFactory.Krypton.Ribbon.KryptonRibbonTab();
            this.RibbonFile = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
            this.RibbonOpen = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.HomeOpen = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonGroupSeparator1 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupSeparator();
            this.RibbonGrSave = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.RibbonSave = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.RibbonImage = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.RibbonGraphType = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
            this.grType = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLines();
            this.rbtnUnDirected = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupRadioButton();
            this.rbtnDirected = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupRadioButton();
            this.kryptonRibbonGroupSeparator7 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupSeparator();
            this.grGridLine = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.GridLine = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupCheckBox();
            this.RibbonNew = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
            this.RibbonNewGraph = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.RibbonBtnNew = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonGroupSeparator2 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupSeparator();
            this.RibbonGrAdd = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.RibbonAddVertex = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.RibbonAddEdge = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.RibbonEdit = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
            this.RibbonGrEdit = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.RibbonBtnMove = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.BtnErase = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.RibbonBtnColor = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonGroupTriple2 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.btnRefresh = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.TabSPA = new ComponentFactory.Krypton.Ribbon.KryptonRibbonTab();
            this.RibbonSPAAlgorithms = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
            this.RibbonGrAlgo = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.SPADijkstra = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupRadioButton();
            this.SPAFordBellman = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupRadioButton();
            this.RibbonGrChoosePoint = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
            this.RibbonChoosePointLb = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLines();
            this.SPAStartPoint = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLabel();
            this.SPAEndPoint = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLabel();
            this.RibbonGrChoosePointVal = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLines();
            this.cbStartPoint = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupComboBox();
            this.cbEndPoint = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupComboBox();
            this.RibbonGrRunMethod = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
            this.kryptonRibbonGroupSeparator3 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupSeparator();
            this.kryptonRibbonGroupTriple1 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.SPAStep = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.SPAPath = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonGroupSeparator4 = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupSeparator();
            this.TabHelp = new ComponentFactory.Krypton.Ribbon.KryptonRibbonTab();
            this.RibbonHelp = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup();
            this.RibbonGrHelp = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.HelpGuide = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.HelpAbout = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.RibbonGrNew = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.RbBtnNew = new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.ctMenuStripMatrix.SuspendLayout();
            this.pnlGraph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGraphView)).BeginInit();
            this.ctMenustripGrapView.SuspendLayout();
            this.gboxPath.SuspendLayout();
            this.panelControl.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gboxLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonRibbon)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonContextMenuItem1
            // 
            this.kryptonContextMenuItem1.Text = "&New";
            this.kryptonContextMenuItem1.Click += new System.EventHandler(this.newToolStripMenuItem1_Click);
            // 
            // kryptonContextMenuItem2
            // 
            this.kryptonContextMenuItem2.Text = "&Open";
            this.kryptonContextMenuItem2.Click += new System.EventHandler(this.btnOpenGraph_Click);
            // 
            // kryptonContextMenuItem3
            // 
            this.kryptonContextMenuItem3.Text = "&Save";
            this.kryptonContextMenuItem3.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // kryptonContextMenuItem4
            // 
            this.kryptonContextMenuItem4.Text = "Save &As";
            this.kryptonContextMenuItem4.Click += new System.EventHandler(this.saveAsImageToolStripMenuItem_Click);
            // 
            // kryptonContextMenuItem5
            // 
            this.kryptonContextMenuItem5.Text = "E&xit";
            this.kryptonContextMenuItem5.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // lvTableView
            // 
            this.lvTableView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvTableView.FullRowSelect = true;
            this.lvTableView.HideSelection = false;
            this.lvTableView.Location = new System.Drawing.Point(0, 20);
            this.lvTableView.Name = "lvTableView";
            this.lvTableView.Size = new System.Drawing.Size(684, 148);
            this.lvTableView.TabIndex = 4;
            this.lvTableView.UseCompatibleStateImageBehavior = false;
            this.lvTableView.View = System.Windows.Forms.View.Details;
            // 
            // lvMatrixView
            // 
            this.lvMatrixView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvMatrixView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvMatrixView.ContextMenuStrip = this.ctMenuStripMatrix;
            this.lvMatrixView.FullRowSelect = true;
            this.lvMatrixView.HideSelection = false;
            this.lvMatrixView.Location = new System.Drawing.Point(0, 20);
            this.lvMatrixView.Name = "lvMatrixView";
            this.lvMatrixView.Size = new System.Drawing.Size(287, 119);
            this.lvMatrixView.TabIndex = 14;
            this.lvMatrixView.UseCompatibleStateImageBehavior = false;
            this.lvMatrixView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 35;
            // 
            // ctMenuStripMatrix
            // 
            this.ctMenuStripMatrix.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ctMenuStripMatrix.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctMenuStripMatrix.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyMatrixToClipboardToolStripMenuItem});
            this.ctMenuStripMatrix.Name = "ctMenuStripMatrix";
            this.ctMenuStripMatrix.Size = new System.Drawing.Size(209, 26);
            // 
            // copyMatrixToClipboardToolStripMenuItem
            // 
            this.copyMatrixToClipboardToolStripMenuItem.Name = "copyMatrixToClipboardToolStripMenuItem";
            this.copyMatrixToClipboardToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.copyMatrixToClipboardToolStripMenuItem.Text = "Copy Matrix to Clipboard";
            this.copyMatrixToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyMatrixToClipboardToolStripMenuItem_Click);
            // 
            // pnlGraph
            // 
            this.pnlGraph.Controls.Add(this.picGraphView);
            this.pnlGraph.Location = new System.Drawing.Point(320, 0);
            this.pnlGraph.Name = "pnlGraph";
            this.pnlGraph.Size = new System.Drawing.Size(696, 335);
            this.pnlGraph.TabIndex = 22;
            // 
            // picGraphView
            // 
            this.picGraphView.BackColor = System.Drawing.Color.White;
            this.picGraphView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picGraphView.ContextMenuStrip = this.ctMenustripGrapView;
            this.picGraphView.Location = new System.Drawing.Point(9, 4);
            this.picGraphView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picGraphView.Name = "picGraphView";
            this.picGraphView.Size = new System.Drawing.Size(684, 327);
            this.picGraphView.TabIndex = 3;
            this.picGraphView.TabStop = false;
            this.picGraphView.Paint += new System.Windows.Forms.PaintEventHandler(this.picGraphView_Paint);
            this.picGraphView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picGraphView_MouseDown);
            this.picGraphView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picGraphView_MouseMove);
            this.picGraphView.Resize += new System.EventHandler(this.picGraphView_Resize);
            // 
            // ctMenustripGrapView
            // 
            this.ctMenustripGrapView.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ctMenustripGrapView.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctMenustripGrapView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearAllToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.copyGraphImageInClipboardToolStripMenuItem});
            this.ctMenustripGrapView.Name = "ctMenustripGrapView";
            this.ctMenustripGrapView.Size = new System.Drawing.Size(261, 70);
            // 
            // clearAllToolStripMenuItem
            // 
            this.clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            this.clearAllToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.clearAllToolStripMenuItem.Text = "Clear all";
            this.clearAllToolStripMenuItem.Click += new System.EventHandler(this.clearAllToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // copyGraphImageInClipboardToolStripMenuItem
            // 
            this.copyGraphImageInClipboardToolStripMenuItem.Name = "copyGraphImageInClipboardToolStripMenuItem";
            this.copyGraphImageInClipboardToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.copyGraphImageInClipboardToolStripMenuItem.Text = "Copy Graph image to the clipboard";
            this.copyGraphImageInClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyGraphImageInClipboardToolStripMenuItem_Click);
            // 
            // gboxPath
            // 
            this.gboxPath.Controls.Add(this.txbLogDijkstra);
            this.gboxPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gboxPath.Location = new System.Drawing.Point(12, 337);
            this.gboxPath.Name = "gboxPath";
            this.gboxPath.Size = new System.Drawing.Size(293, 160);
            this.gboxPath.TabIndex = 5;
            this.gboxPath.TabStop = false;
            this.gboxPath.Text = "Đường đi";
            // 
            // txbLogDijkstra
            // 
            this.txbLogDijkstra.BackColor = System.Drawing.Color.White;
            this.txbLogDijkstra.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbLogDijkstra.Location = new System.Drawing.Point(0, 20);
            this.txbLogDijkstra.Name = "txbLogDijkstra";
            this.txbLogDijkstra.Size = new System.Drawing.Size(287, 155);
            this.txbLogDijkstra.TabIndex = 1;
            this.txbLogDijkstra.Text = "";
            // 
            // MyOpenFileDialog
            // 
            this.MyOpenFileDialog.FileName = "Graph";
            this.MyOpenFileDialog.Filter = ".txt|*.txt";
            this.MyOpenFileDialog.Title = "Open Graph";
            // 
            // MySaveFileDialog
            // 
            this.MySaveFileDialog.FileName = "Graph";
            this.MySaveFileDialog.Filter = ".txt|*.txt";
            this.MySaveFileDialog.Title = "Save Graph";
            // 
            // SaveFileDialogImage
            // 
            this.SaveFileDialogImage.FileName = "Graph";
            this.SaveFileDialogImage.Filter = ".png|*.png";
            this.SaveFileDialogImage.Title = "Save Graph Image";
            // 
            // MyColorDialog
            // 
            this.MyColorDialog.FullOpen = true;
            // 
            // panelControl
            // 
            this.panelControl.Controls.Add(this.groupBox3);
            this.panelControl.Controls.Add(this.groupBox1);
            this.panelControl.Controls.Add(this.pnlGraph);
            this.panelControl.Location = new System.Drawing.Point(13, 160);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(1019, 532);
            this.panelControl.TabIndex = 23;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lvTableView);
            this.groupBox3.Location = new System.Drawing.Point(329, 341);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(684, 174);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bảng mô phỏng chạy tay";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox1.Controls.Add(this.gboxPath);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.gboxLogs);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(311, 510);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvMatrixView);
            this.groupBox2.Location = new System.Drawing.Point(12, 186);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(290, 145);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ma trận kề";
            // 
            // gboxLogs
            // 
            this.gboxLogs.Controls.Add(this.txbLogs);
            this.gboxLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gboxLogs.Location = new System.Drawing.Point(6, 6);
            this.gboxLogs.Name = "gboxLogs";
            this.gboxLogs.Size = new System.Drawing.Size(296, 178);
            this.gboxLogs.TabIndex = 3;
            this.gboxLogs.TabStop = false;
            this.gboxLogs.Text = "Nhật ký";
            // 
            // txbLogs
            // 
            this.txbLogs.BackColor = System.Drawing.Color.White;
            this.txbLogs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbLogs.Location = new System.Drawing.Point(6, 16);
            this.txbLogs.Name = "txbLogs";
            this.txbLogs.ReadOnly = true;
            this.txbLogs.Size = new System.Drawing.Size(287, 156);
            this.txbLogs.TabIndex = 0;
            this.txbLogs.Text = "Chào ^^";
            // 
            // kryptonRibbon
            // 
            this.kryptonRibbon.InDesignHelperMode = true;
            this.kryptonRibbon.Name = "kryptonRibbon";
            this.kryptonRibbon.RibbonAppButton.AppButtonMenuItems.AddRange(new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.kryptonContextMenuItem1,
            this.kryptonContextMenuItem2,
            this.kryptonContextMenuItem3,
            this.kryptonContextMenuItem4,
            this.kryptonContextMenuSeparator1,
            this.kryptonContextMenuItem5});
            this.kryptonRibbon.RibbonAppButton.AppButtonShowRecentDocs = false;
            this.kryptonRibbon.RibbonTabs.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonTab[] {
            this.TabHome,
            this.TabSPA,
            this.TabHelp});
            this.kryptonRibbon.SelectedTab = this.TabHelp;
            this.kryptonRibbon.Size = new System.Drawing.Size(1174, 115);
            this.kryptonRibbon.TabIndex = 24;
            // 
            // TabHome
            // 
            this.TabHome.Groups.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup[] {
            this.RibbonFile,
            this.RibbonGraphType,
            this.RibbonNew,
            this.RibbonEdit});
            this.TabHome.Text = "Các công cụ";
            // 
            // RibbonFile
            // 
            this.RibbonFile.DialogBoxLauncher = false;
            this.RibbonFile.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.RibbonOpen,
            this.kryptonRibbonGroupSeparator1,
            this.RibbonGrSave});
            this.RibbonFile.TextLine1 = "Tệp";
            // 
            // RibbonOpen
            // 
            this.RibbonOpen.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.HomeOpen});
            this.RibbonOpen.MinimumSize = ComponentFactory.Krypton.Ribbon.GroupItemSize.Large;
            // 
            // HomeOpen
            // 
            this.HomeOpen.ImageLarge = ((System.Drawing.Image)(resources.GetObject("HomeOpen.ImageLarge")));
            this.HomeOpen.TextLine1 = "Mở file";
            this.HomeOpen.Click += new System.EventHandler(this.btnOpenGraph_Click);
            // 
            // RibbonGrSave
            // 
            this.RibbonGrSave.ItemAlignment = ComponentFactory.Krypton.Ribbon.RibbonItemAlignment.Far;
            this.RibbonGrSave.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.RibbonSave,
            this.RibbonImage});
            this.RibbonGrSave.MinimumSize = ComponentFactory.Krypton.Ribbon.GroupItemSize.Large;
            // 
            // RibbonSave
            // 
            this.RibbonSave.Checked = true;
            this.RibbonSave.ImageLarge = ((System.Drawing.Image)(resources.GetObject("RibbonSave.ImageLarge")));
            this.RibbonSave.TextLine1 = "Lưu file";
            this.RibbonSave.Click += new System.EventHandler(this.btnSaveGraph_Click);
            // 
            // RibbonImage
            // 
            this.RibbonImage.ImageLarge = ((System.Drawing.Image)(resources.GetObject("RibbonImage.ImageLarge")));
            this.RibbonImage.TextLine1 = "Lưu thành ảnh";
            // 
            // RibbonGraphType
            // 
            this.RibbonGraphType.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.grType,
            this.kryptonRibbonGroupSeparator7,
            this.grGridLine});
            this.RibbonGraphType.TextLine1 = "Loại đồ thị";
            // 
            // grType
            // 
            this.grType.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.rbtnUnDirected,
            this.rbtnDirected});
            // 
            // rbtnUnDirected
            // 
            this.rbtnUnDirected.Checked = true;
            this.rbtnUnDirected.TextLine1 = "Vô hướng";
            // 
            // rbtnDirected
            // 
            this.rbtnDirected.TextLine1 = "Có hướng";
            // 
            // grGridLine
            // 
            this.grGridLine.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.GridLine});
            // 
            // GridLine
            // 
            this.GridLine.Checked = true;
            this.GridLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.GridLine.TextLine1 = "Lưới";
            this.GridLine.CheckedChanged += new System.EventHandler(this.GridLine_CheckedChanged);
            // 
            // RibbonNew
            // 
            this.RibbonNew.DialogBoxLauncher = false;
            this.RibbonNew.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.RibbonNewGraph,
            this.kryptonRibbonGroupSeparator2,
            this.RibbonGrAdd});
            this.RibbonNew.TextLine1 = "Thêm";
            // 
            // RibbonNewGraph
            // 
            this.RibbonNewGraph.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.RibbonBtnNew});
            // 
            // RibbonBtnNew
            // 
            this.RibbonBtnNew.ButtonType = ComponentFactory.Krypton.Ribbon.GroupButtonType.Check;
            this.RibbonBtnNew.ImageLarge = ((System.Drawing.Image)(resources.GetObject("RibbonBtnNew.ImageLarge")));
            this.RibbonBtnNew.TextLine1 = "Đồ thị mới";
            this.RibbonBtnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // RibbonGrAdd
            // 
            this.RibbonGrAdd.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.RibbonAddVertex,
            this.RibbonAddEdge});
            this.RibbonGrAdd.MaximumSize = ComponentFactory.Krypton.Ribbon.GroupItemSize.Medium;
            // 
            // RibbonAddVertex
            // 
            this.RibbonAddVertex.ButtonType = ComponentFactory.Krypton.Ribbon.GroupButtonType.Check;
            this.RibbonAddVertex.ImageLarge = ((System.Drawing.Image)(resources.GetObject("RibbonAddVertex.ImageLarge")));
            this.RibbonAddVertex.ImageSmall = ((System.Drawing.Image)(resources.GetObject("RibbonAddVertex.ImageSmall")));
            this.RibbonAddVertex.TextLine1 = "Thêm đỉnh";
            this.RibbonAddVertex.Click += new System.EventHandler(this.btnDrawPoint_Click);
            // 
            // RibbonAddEdge
            // 
            this.RibbonAddEdge.ButtonType = ComponentFactory.Krypton.Ribbon.GroupButtonType.Check;
            this.RibbonAddEdge.ImageLarge = ((System.Drawing.Image)(resources.GetObject("RibbonAddEdge.ImageLarge")));
            this.RibbonAddEdge.ImageSmall = ((System.Drawing.Image)(resources.GetObject("RibbonAddEdge.ImageSmall")));
            this.RibbonAddEdge.TextLine1 = "Thêm cạnh";
            this.RibbonAddEdge.Click += new System.EventHandler(this.btnDrawLine_Click);
            // 
            // RibbonEdit
            // 
            this.RibbonEdit.DialogBoxLauncher = false;
            this.RibbonEdit.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.RibbonGrEdit,
            this.kryptonRibbonGroupTriple2});
            this.RibbonEdit.TextLine1 = "Chỉnh sửa";
            // 
            // RibbonGrEdit
            // 
            this.RibbonGrEdit.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.RibbonBtnMove,
            this.BtnErase,
            this.RibbonBtnColor});
            // 
            // RibbonBtnMove
            // 
            this.RibbonBtnMove.ButtonType = ComponentFactory.Krypton.Ribbon.GroupButtonType.Check;
            this.RibbonBtnMove.ImageLarge = ((System.Drawing.Image)(resources.GetObject("RibbonBtnMove.ImageLarge")));
            this.RibbonBtnMove.TextLine1 = "Di chuyển đỉnh";
            this.RibbonBtnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // BtnErase
            // 
            this.BtnErase.ButtonType = ComponentFactory.Krypton.Ribbon.GroupButtonType.Check;
            this.BtnErase.ImageLarge = ((System.Drawing.Image)(resources.GetObject("BtnErase.ImageLarge")));
            this.BtnErase.TextLine1 = "Xóa cạnh";
            this.BtnErase.Click += new System.EventHandler(this.btnCutLine_Click);
            // 
            // RibbonBtnColor
            // 
            this.RibbonBtnColor.ButtonType = ComponentFactory.Krypton.Ribbon.GroupButtonType.Check;
            this.RibbonBtnColor.ImageLarge = ((System.Drawing.Image)(resources.GetObject("RibbonBtnColor.ImageLarge")));
            this.RibbonBtnColor.TextLine1 = "Màu sắc";
            this.RibbonBtnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // kryptonRibbonGroupTriple2
            // 
            this.kryptonRibbonGroupTriple2.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.btnRefresh});
            // 
            // btnRefresh
            // 
            this.btnRefresh.ButtonType = ComponentFactory.Krypton.Ribbon.GroupButtonType.Check;
            this.btnRefresh.ImageLarge = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageLarge")));
            this.btnRefresh.TextLine1 = "Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // TabSPA
            // 
            this.TabSPA.Groups.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup[] {
            this.RibbonSPAAlgorithms,
            this.RibbonGrChoosePoint,
            this.RibbonGrRunMethod});
            this.TabSPA.Text = "Thuật toán đường đi ngắn nhất";
            // 
            // RibbonSPAAlgorithms
            // 
            this.RibbonSPAAlgorithms.DialogBoxLauncher = false;
            this.RibbonSPAAlgorithms.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.RibbonGrAlgo});
            this.RibbonSPAAlgorithms.TextLine1 = "Giải thuật";
            // 
            // RibbonGrAlgo
            // 
            this.RibbonGrAlgo.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.SPADijkstra,
            this.SPAFordBellman});
            // 
            // SPADijkstra
            // 
            this.SPADijkstra.TextLine1 = "Dijkstra";
            // 
            // SPAFordBellman
            // 
            this.SPAFordBellman.TextLine1 = "Ford-Bellman";
            // 
            // RibbonGrChoosePoint
            // 
            this.RibbonGrChoosePoint.DialogBoxLauncher = false;
            this.RibbonGrChoosePoint.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.RibbonChoosePointLb,
            this.RibbonGrChoosePointVal});
            this.RibbonGrChoosePoint.TextLine1 = "Chọn đỉnh";
            // 
            // RibbonChoosePointLb
            // 
            this.RibbonChoosePointLb.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.SPAStartPoint,
            this.SPAEndPoint});
            // 
            // SPAStartPoint
            // 
            this.SPAStartPoint.TextLine1 = "Bắt đầu";
            // 
            // SPAEndPoint
            // 
            this.SPAEndPoint.TextLine1 = "Kết thúc";
            // 
            // RibbonGrChoosePointVal
            // 
            this.RibbonGrChoosePointVal.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.cbStartPoint,
            this.cbEndPoint});
            // 
            // cbStartPoint
            // 
            this.cbStartPoint.DropDownWidth = 121;
            this.cbStartPoint.FormattingEnabled = false;
            this.cbStartPoint.ItemHeight = 15;
            this.cbStartPoint.MaximumSize = new System.Drawing.Size(50, 0);
            this.cbStartPoint.MinimumSize = new System.Drawing.Size(50, 0);
            this.cbStartPoint.Text = "";
            // 
            // cbEndPoint
            // 
            this.cbEndPoint.DropDownWidth = 121;
            this.cbEndPoint.FormattingEnabled = false;
            this.cbEndPoint.ItemHeight = 15;
            this.cbEndPoint.Items.AddRange(new object[] {
            "All"});
            this.cbEndPoint.MaximumSize = new System.Drawing.Size(50, 0);
            this.cbEndPoint.MinimumSize = new System.Drawing.Size(50, 0);
            this.cbEndPoint.Text = "";
            // 
            // RibbonGrRunMethod
            // 
            this.RibbonGrRunMethod.DialogBoxLauncher = false;
            this.RibbonGrRunMethod.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupSeparator3,
            this.kryptonRibbonGroupTriple1,
            this.kryptonRibbonGroupSeparator4});
            this.RibbonGrRunMethod.TextLine1 = "Phương thức chạy";
            // 
            // kryptonRibbonGroupTriple1
            // 
            this.kryptonRibbonGroupTriple1.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.SPAStep,
            this.SPAPath});
            // 
            // SPAStep
            // 
            this.SPAStep.ButtonType = ComponentFactory.Krypton.Ribbon.GroupButtonType.Check;
            this.SPAStep.ImageLarge = ((System.Drawing.Image)(resources.GetObject("SPAStep.ImageLarge")));
            this.SPAStep.TextLine1 = "Chạy từng bước";
            this.SPAStep.Click += new System.EventHandler(this.btnRunStep_Click);
            // 
            // SPAPath
            // 
            this.SPAPath.ButtonType = ComponentFactory.Krypton.Ribbon.GroupButtonType.Check;
            this.SPAPath.ImageLarge = ((System.Drawing.Image)(resources.GetObject("SPAPath.ImageLarge")));
            this.SPAPath.TextLine1 = "Đường đi ";
            this.SPAPath.Click += new System.EventHandler(this.btnRunAll_Click);
            // 
            // TabHelp
            // 
            this.TabHelp.Groups.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup[] {
            this.RibbonHelp});
            this.TabHelp.Text = "Trợ giúp";
            // 
            // RibbonHelp
            // 
            this.RibbonHelp.DialogBoxLauncher = false;
            this.RibbonHelp.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.RibbonGrHelp});
            this.RibbonHelp.TextLine1 = "Help";
            // 
            // RibbonGrHelp
            // 
            this.RibbonGrHelp.Items.AddRange(new ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.HelpGuide,
            this.HelpAbout});
            // 
            // HelpGuide
            // 
            this.HelpGuide.ImageLarge = ((System.Drawing.Image)(resources.GetObject("HelpGuide.ImageLarge")));
            this.HelpGuide.TextLine1 = "Hướng dẫn";
            this.HelpGuide.Click += new System.EventHandler(this.guide_Click);
            // 
            // HelpAbout
            // 
            this.HelpAbout.ImageLarge = ((System.Drawing.Image)(resources.GetObject("HelpAbout.ImageLarge")));
            this.HelpAbout.TextLine1 = "Về chúng tôi";
            this.HelpAbout.Click += new System.EventHandler(this.about_Click);
            // 
            // RbBtnNew
            // 
            this.RbBtnNew.TextLine1 = "New";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1;
            // 
            // MainProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Silver;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1191, 660);
            this.Controls.Add(this.kryptonRibbon);
            this.Controls.Add(this.panelControl);
            this.DoubleBuffered = true;
            this.Enabled = false;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Crimson;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "MainProgress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mô phỏng thuật toán lý thuyết đồ thị";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            this.ctMenuStripMatrix.ResumeLayout(false);
            this.pnlGraph.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picGraphView)).EndInit();
            this.ctMenustripGrapView.ResumeLayout(false);
            this.gboxPath.ResumeLayout(false);
            this.panelControl.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.gboxLogs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonRibbon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private ComponentFactory.Krypton.Ribbon.KryptonRibbon kryptonRibbon;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem kryptonContextMenuItem1;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem kryptonContextMenuItem2;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem kryptonContextMenuItem3;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem kryptonContextMenuItem4;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuSeparator kryptonContextMenuSeparator1;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem kryptonContextMenuItem5;
        private System.Windows.Forms.ListView lvTableView;
        private System.Windows.Forms.ListView lvMatrixView;
        private System.Windows.Forms.Panel pnlGraph;
        private System.Windows.Forms.OpenFileDialog MyOpenFileDialog;
        private System.Windows.Forms.SaveFileDialog MySaveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.SaveFileDialog SaveFileDialogImage;
        private System.Windows.Forms.ColorDialog MyColorDialog;
        private System.Windows.Forms.ContextMenuStrip ctMenustripGrapView;
        private System.Windows.Forms.ToolStripMenuItem clearAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyGraphImageInClipboardToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ctMenuStripMatrix;
        private System.Windows.Forms.ToolStripMenuItem copyMatrixToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.PictureBox picGraphView;
        private System.Windows.Forms.Panel panelControl;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonTab TabHome;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup RibbonFile;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple RibbonOpen;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton HomeOpen;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupSeparator kryptonRibbonGroupSeparator1;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple RibbonGrSave;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton RibbonSave;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton RibbonImage;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup RibbonNew;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup RibbonEdit;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple RibbonGrEdit;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton RibbonBtnMove;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupSeparator kryptonRibbonGroupSeparator2;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple RibbonGrAdd;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton RibbonAddVertex;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton RibbonAddEdge;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton BtnErase;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonTab TabSPA;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup RibbonSPAAlgorithms;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple RibbonGrAlgo;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup RibbonGrChoosePoint;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLines RibbonChoosePointLb;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupSeparator kryptonRibbonGroupSeparator3;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLines RibbonGrChoosePointVal;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup RibbonGrRunMethod;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLabel SPAStartPoint;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLabel SPAEndPoint;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupComboBox cbStartPoint;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupComboBox cbEndPoint;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple1;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton SPAStep;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton SPAPath;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupSeparator kryptonRibbonGroupSeparator4;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupRadioButton SPADijkstra;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupRadioButton SPAFordBellman;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple RibbonGrNew;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton RbBtnNew;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple RibbonNewGraph;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton RibbonBtnNew;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonTab TabHelp;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup RibbonHelp;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple RibbonGrHelp;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton HelpGuide;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton HelpAbout;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton RibbonBtnColor;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup RibbonGraphType;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLines grType;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupSeparator kryptonRibbonGroupSeparator7;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple grGridLine;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupRadioButton rbtnUnDirected;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupRadioButton rbtnDirected;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupCheckBox GridLine;
        private System.Windows.Forms.GroupBox gboxPath;
        private System.Windows.Forms.RichTextBox txbLogDijkstra;
        private System.Windows.Forms.GroupBox gboxLogs;
        private System.Windows.Forms.RichTextBox txbLogs;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple2;
        private ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton btnRefresh;
        private System.Windows.Forms.Timer timer;
    }
}

