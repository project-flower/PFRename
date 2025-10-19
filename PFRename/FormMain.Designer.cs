
namespace PFRename
{
    partial class FormMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCreateNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.container = new System.Windows.Forms.SplitContainer();
            this.buttonClearFileList = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.listViewFiles = new DoubleBufferredListView();
            this.columnHeaderPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderReplacedName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonClearReplaceList = new System.Windows.Forms.Button();
            this.replaceBoxList = new PFRename.ReplaceBoxList();
            this.checkBoxConfirm = new System.Windows.Forms.CheckBox();
            this.buttonPreview = new System.Windows.Forms.Button();
            this.buttonExec = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogFiles = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.replaceEngine = new PFRename.ReplaceEngine();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.container)).BeginInit();
            this.container.Panel1.SuspendLayout();
            this.container.Panel2.SuspendLayout();
            this.container.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFile,
            this.toolStripMenuItemHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItemFile
            // 
            this.toolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCreateNew,
            this.toolStripMenuItemOpen,
            this.toolStripMenuItemSave,
            this.toolStripMenuItemSaveAs,
            this.toolStripSeparator1,
            this.toolStripMenuItemQuit});
            this.toolStripMenuItemFile.Name = "toolStripMenuItemFile";
            this.toolStripMenuItemFile.Size = new System.Drawing.Size(67, 20);
            this.toolStripMenuItemFile.Text = "ファイル(&F)";
            // 
            // toolStripMenuItemCreateNew
            // 
            this.toolStripMenuItemCreateNew.Name = "toolStripMenuItemCreateNew";
            this.toolStripMenuItemCreateNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.toolStripMenuItemCreateNew.Size = new System.Drawing.Size(257, 22);
            this.toolStripMenuItemCreateNew.Text = "新規(&N)";
            this.toolStripMenuItemCreateNew.Click += new System.EventHandler(this.toolStripMenuItemCreateNew_Click);
            // 
            // toolStripMenuItemOpen
            // 
            this.toolStripMenuItemOpen.Name = "toolStripMenuItemOpen";
            this.toolStripMenuItemOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.toolStripMenuItemOpen.Size = new System.Drawing.Size(257, 22);
            this.toolStripMenuItemOpen.Text = "開く(&O)...";
            this.toolStripMenuItemOpen.Click += new System.EventHandler(this.toolStripMenuItemOpen_Click);
            // 
            // toolStripMenuItemSave
            // 
            this.toolStripMenuItemSave.Name = "toolStripMenuItemSave";
            this.toolStripMenuItemSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.toolStripMenuItemSave.Size = new System.Drawing.Size(257, 22);
            this.toolStripMenuItemSave.Text = "上書き保存(&S)";
            this.toolStripMenuItemSave.Click += new System.EventHandler(this.toolStripMenuItemSave_Click);
            // 
            // toolStripMenuItemSaveAs
            // 
            this.toolStripMenuItemSaveAs.Name = "toolStripMenuItemSaveAs";
            this.toolStripMenuItemSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.toolStripMenuItemSaveAs.Size = new System.Drawing.Size(257, 22);
            this.toolStripMenuItemSaveAs.Text = "名前を付けて保存(&A)...";
            this.toolStripMenuItemSaveAs.Click += new System.EventHandler(this.toolStripMenuItemSaveAs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(254, 6);
            // 
            // toolStripMenuItemQuit
            // 
            this.toolStripMenuItemQuit.Name = "toolStripMenuItemQuit";
            this.toolStripMenuItemQuit.Size = new System.Drawing.Size(257, 22);
            this.toolStripMenuItemQuit.Text = "終了(&X)";
            this.toolStripMenuItemQuit.Click += new System.EventHandler(this.toolStripMenuItemQuit_Click);
            // 
            // toolStripMenuItemHelp
            // 
            this.toolStripMenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAbout});
            this.toolStripMenuItemHelp.Name = "toolStripMenuItemHelp";
            this.toolStripMenuItemHelp.Size = new System.Drawing.Size(65, 20);
            this.toolStripMenuItemHelp.Text = "ヘルプ(&H)";
            // 
            // toolStripMenuItemAbout
            // 
            this.toolStripMenuItemAbout.Name = "toolStripMenuItemAbout";
            this.toolStripMenuItemAbout.Size = new System.Drawing.Size(167, 22);
            this.toolStripMenuItemAbout.Text = "バージョン情報(&A)...";
            // 
            // container
            // 
            this.container.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.container.Location = new System.Drawing.Point(12, 27);
            this.container.Name = "container";
            this.container.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // container.Panel1
            // 
            this.container.Panel1.Controls.Add(this.buttonClearFileList);
            this.container.Panel1.Controls.Add(this.buttonRemove);
            this.container.Panel1.Controls.Add(this.buttonAdd);
            this.container.Panel1.Controls.Add(this.listViewFiles);
            // 
            // container.Panel2
            // 
            this.container.Panel2.Controls.Add(this.buttonClearReplaceList);
            this.container.Panel2.Controls.Add(this.replaceBoxList);
            this.container.Size = new System.Drawing.Size(776, 353);
            this.container.SplitterDistance = 176;
            this.container.TabIndex = 1;
            // 
            // buttonClearFileList
            // 
            this.buttonClearFileList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearFileList.Location = new System.Drawing.Point(698, 61);
            this.buttonClearFileList.Name = "buttonClearFileList";
            this.buttonClearFileList.Size = new System.Drawing.Size(75, 23);
            this.buttonClearFileList.TabIndex = 3;
            this.buttonClearFileList.Text = "クリア";
            this.buttonClearFileList.UseVisualStyleBackColor = true;
            this.buttonClearFileList.Click += new System.EventHandler(this.buttonClearFileList_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemove.Location = new System.Drawing.Point(698, 32);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 2;
            this.buttonRemove.Text = "削除(&R)";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Location = new System.Drawing.Point(698, 3);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "追加(&A)";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // listViewFiles
            // 
            this.listViewFiles.AllowDrop = true;
            this.listViewFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderPath,
            this.columnHeaderName,
            this.columnHeaderReplacedName});
            this.listViewFiles.FullRowSelect = true;
            this.listViewFiles.HideSelection = false;
            this.listViewFiles.Location = new System.Drawing.Point(3, 3);
            this.listViewFiles.Name = "listViewFiles";
            this.listViewFiles.Size = new System.Drawing.Size(689, 170);
            this.listViewFiles.TabIndex = 0;
            this.listViewFiles.UseCompatibleStateImageBehavior = false;
            this.listViewFiles.View = System.Windows.Forms.View.Details;
            this.listViewFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.listViewFiles_DragDrop);
            this.listViewFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.listViewFiles_DragEnter);
            // 
            // columnHeaderPath
            // 
            this.columnHeaderPath.Text = "パス";
            this.columnHeaderPath.Width = 300;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "名前";
            this.columnHeaderName.Width = 190;
            // 
            // columnHeaderReplacedName
            // 
            this.columnHeaderReplacedName.Text = "変更後の名前";
            this.columnHeaderReplacedName.Width = 190;
            // 
            // buttonClearReplaceList
            // 
            this.buttonClearReplaceList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearReplaceList.Location = new System.Drawing.Point(698, 3);
            this.buttonClearReplaceList.Name = "buttonClearReplaceList";
            this.buttonClearReplaceList.Size = new System.Drawing.Size(75, 23);
            this.buttonClearReplaceList.TabIndex = 1;
            this.buttonClearReplaceList.Text = "クリア";
            this.buttonClearReplaceList.UseVisualStyleBackColor = true;
            this.buttonClearReplaceList.Click += new System.EventHandler(this.buttonClearReplaceList_Click);
            // 
            // replaceBoxList
            // 
            this.replaceBoxList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.replaceBoxList.AutoScroll = true;
            this.replaceBoxList.Location = new System.Drawing.Point(3, 3);
            this.replaceBoxList.Name = "replaceBoxList";
            this.replaceBoxList.Size = new System.Drawing.Size(689, 167);
            this.replaceBoxList.TabIndex = 0;
            // 
            // checkBoxConfirm
            // 
            this.checkBoxConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxConfirm.AutoSize = true;
            this.checkBoxConfirm.Checked = true;
            this.checkBoxConfirm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxConfirm.Location = new System.Drawing.Point(624, 419);
            this.checkBoxConfirm.Name = "checkBoxConfirm";
            this.checkBoxConfirm.Size = new System.Drawing.Size(83, 16);
            this.checkBoxConfirm.TabIndex = 2;
            this.checkBoxConfirm.Text = "確認する(&C)";
            this.checkBoxConfirm.UseVisualStyleBackColor = true;
            // 
            // buttonPreview
            // 
            this.buttonPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPreview.Location = new System.Drawing.Point(713, 386);
            this.buttonPreview.Name = "buttonPreview";
            this.buttonPreview.Size = new System.Drawing.Size(75, 23);
            this.buttonPreview.TabIndex = 3;
            this.buttonPreview.Text = "プレビュー(&P)";
            this.buttonPreview.UseVisualStyleBackColor = true;
            this.buttonPreview.Click += new System.EventHandler(this.buttonPreview_Click);
            // 
            // buttonExec
            // 
            this.buttonExec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExec.Location = new System.Drawing.Point(713, 415);
            this.buttonExec.Name = "buttonExec";
            this.buttonExec.Size = new System.Drawing.Size(75, 23);
            this.buttonExec.TabIndex = 4;
            this.buttonExec.Text = "実行(&E)";
            this.buttonExec.UseVisualStyleBackColor = true;
            this.buttonExec.Click += new System.EventHandler(this.buttonExec_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "xml";
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "XML ファイル|*.xml|すべてのファイル|*.*";
            this.openFileDialog.Title = "開く";
            // 
            // openFileDialogFiles
            // 
            this.openFileDialogFiles.Multiselect = true;
            this.openFileDialogFiles.Title = "追加";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "XML ファイル|*.xml|すべてのファイル|*.*";
            this.saveFileDialog.Title = "名前を付けて保存";
            // 
            // replaceEngine
            // 
            this.replaceEngine.Owner = this;
            this.replaceEngine.Completed += new PFRename.ReplaceEngine.CompletedEventHandler(this.replaceEngine_Completed);
            this.replaceEngine.ErrorOccurred += new PFRename.ReplaceEngine.ErrorOccurredEventHandler(this.replaceEngine_ErrorOccurred);
            this.replaceEngine.FileNameReplaced += new PFRename.ReplaceEngine.FileNameReplacedEventHandler(this.replaceEngine_FileNameReplaced);
            this.replaceEngine.PreviewFileNameReplace += new PFRename.ReplaceEngine.PreviewFileNameReplaceEventHandler(this.replaceEngine_PreviewFileNameReplace);
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonExec);
            this.Controls.Add(this.buttonPreview);
            this.Controls.Add(this.checkBoxConfirm);
            this.Controls.Add(this.container);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "PFRename";
            this.Load += new System.EventHandler(this.load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.dragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.dragEnter);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.container.Panel1.ResumeLayout(false);
            this.container.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.container)).EndInit();
            this.container.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCreateNew;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSave;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemQuit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAbout;
        private System.Windows.Forms.SplitContainer container;
        private DoubleBufferredListView listViewFiles;
        private System.Windows.Forms.ColumnHeader columnHeaderPath;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderReplacedName;
        private System.Windows.Forms.Button buttonClearFileList;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonClearReplaceList;
        private ReplaceBoxList replaceBoxList;
        private System.Windows.Forms.CheckBox checkBoxConfirm;
        private System.Windows.Forms.Button buttonPreview;
        private System.Windows.Forms.Button buttonExec;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialogFiles;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private ReplaceEngine replaceEngine;
    }
}

