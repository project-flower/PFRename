using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PFRename
{
    public partial class FormMain : Form
    {
        #region Private Fields

        private readonly FileManager fileManager = new FileManager();
        private bool messageShowing = false;
        private readonly string newLine = Environment.NewLine;
        private readonly string title;

        #endregion

        #region Public Methods

        public FormMain()
        {
            InitializeComponent();
            title = Text;
        }

        #endregion

        #region Private Methods

        private void AddItems(string[] files)
        {
            listViewFiles.BeginUpdate();

            foreach (string fileName in files)
            {
                string trimmedFileName = fileName.TrimEnd(Path.DirectorySeparatorChar);
                bool skip = false;

                foreach (ListViewItem item in listViewFiles.Items)
                {
                    if (string.Compare(trimmedFileName, item.Tag as string) == 0)
                    {
                        skip = true;
                        break;
                    }
                }

                if (skip)
                {
                    continue;
                }

                string path;
                string name;

                try
                {
                    path = $"{Path.GetDirectoryName(trimmedFileName)}{Path.DirectorySeparatorChar}";
                    name = Path.GetFileName(trimmedFileName);
                }
                catch
                {
                    continue;
                }

                var newItem = new ListViewItem(new string[] { path, name, string.Empty })
                {
                    Tag = trimmedFileName,
                    UseItemStyleForSubItems = false
                };

                listViewFiles.Items.Add(newItem);
            }

            listViewFiles.EndUpdate();
        }

        private void ClearFiles()
        {
            listViewFiles.Items.Clear();
        }

        private void ClearProject()
        {
            ClearFiles();
            replaceBoxList.Clear();
            SetTitle("無題");
        }

        private void DoReplace(bool preview)
        {
            string[] fileNames = GetFileNames();

            if (fileNames.Length < 1)
            {
                return;
            }

            listViewFiles.BeginUpdate();
            Color color = listViewFiles.ForeColor;

            foreach (ListViewItem item in listViewFiles.Items)
            {
                item.SubItems[columnHeaderName.Index].ForeColor = color;
                ListViewItem.ListViewSubItem subItem = item.SubItems[columnHeaderReplacedName.Index];
                subItem.Text = string.Empty;
                subItem.ForeColor = color;
            }

            listViewFiles.EndUpdate();

            EnableControls(false);

            try
            {
                replaceEngine.BeginReplace(fileNames, replaceBoxList.GetPlans(), preview);
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        private void EnableControls(bool enable)
        {
            menuStrip.Enabled = enable;
            container.Enabled = enable;
            checkBoxConfirm.Enabled = enable;
            buttonExec.Enabled = enable;
        }

        private string GetFileNameFromFileFullName(string fileFullName)
        {
            try
            {
                return Path.GetFileName(fileFullName);
            }
            catch
            {
            }

            return fileFullName;
        }

        private string[] GetFileNames()
        {
            ListView.ListViewItemCollection items = listViewFiles.Items;
            var result = new string[items.Count];

            for (int i = 0; i < result.Length; ++i)
            {
                result[i] = items[i].Tag as string;
            }

            return result;
        }

        private void OpenFile(string fileName)
        {
            Project project;

            try
            {
                project = fileManager.LoadProject(fileName);
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
                return;
            }

            ClearFiles();
            AddItems(project.Files);
            replaceBoxList.Apply(project.ReplacePlans);
            SetTitle(GetFileNameFromFileFullName(fileName));
            saveFileDialog.FileName = fileName;
        }

        private void SaveFile()
        {
            Project project;

            try
            {
                project = new Project()
                {
                    Files = GetFileNames(),
                    ReplacePlans = replaceBoxList.GetPlans()
                };
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
                return;
            }

            if (string.IsNullOrEmpty(saveFileDialog.FileName))
            {
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }

            string fileName = saveFileDialog.FileName;

            try
            {
                fileManager.SaveProject(fileName, project);
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
                return;
            }

            SetTitle(GetFileNameFromFileFullName(fileName));
            openFileDialog.FileName = fileName;
        }

        private void SetTitle(string fileName)
        {
            Text = $"{fileName} - {title}";
        }

        private void ShowErrorMessage(string text)
        {
            ShowMessage(text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private DialogResult ShowMessage(string text, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            if (messageShowing)
            {
                return DialogResult.None;
            }

            messageShowing = true;
            DialogResult result = MessageBox.Show(this, text, title, buttons, icon);
            messageShowing = false;
            return result;
        }

        #endregion

        // Designer Methods

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (openFileDialogFiles.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            AddItems(openFileDialogFiles.FileNames);
        }

        private void buttonClearFileList_Click(object sender, EventArgs e)
        {
            ClearFiles();
        }

        private void buttonClearReplaceList_Click(object sender, EventArgs e)
        {
            replaceBoxList.Clear();
        }

        private void buttonExec_Click(object sender, EventArgs e)
        {
            DoReplace(false);
        }

        private void buttonPreview_Click(object sender, EventArgs e)
        {
            DoReplace(true);
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection selectedIndices = listViewFiles.SelectedIndices;

            if (selectedIndices.Count < 1)
            {
                return;
            }

            var indices = new int[listViewFiles.SelectedItems.Count];

            for (int i = 0; i < indices.Length; ++i)
            {
                indices[i] = selectedIndices[i];
            }

            listViewFiles.BeginUpdate();

            for (int i = 0; i < indices.Length; ++i)
            {
                listViewFiles.Items.RemoveAt(indices[i] - i);
            }

            listViewFiles.EndUpdate();
        }

        private void dragDrop(object sender, DragEventArgs e)
        {
            if (!(e.Data.GetData(DataFormats.FileDrop) is string[] data) || (data.Length < 1))
            {
                return;
            }

            try
            {
                OpenFile(data[0]);
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        private void dragEnter(object sender, DragEventArgs e)
        {
            e.Effect = (e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.All : DragDropEffects.None);
        }

        private void listViewFiles_DragDrop(object sender, DragEventArgs e)
        {
            if (!(e.Data.GetData(DataFormats.FileDrop) is string[] data) || (data.Length < 1))
            {
                return;
            }

            try
            {
                AddItems(data);
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        private void listViewFiles_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = (e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.All : DragDropEffects.None);
        }

        private void load(object sender, EventArgs e)
        {
            ClearProject();
        }

        private void replaceEngine_Completed(object sender, ReplaceEngine.CompletedEventArgs e)
        {
            Dictionary<int, string> results = e.Results;
            int nameIndex = columnHeaderName.Index;
            int replacedNameIndex = columnHeaderReplacedName.Index;
            listViewFiles.BeginUpdate();

            foreach (int index in results.Keys)
            {
                ListViewItem item = listViewFiles.Items[index];
                ListViewItem.ListViewSubItem subItem = item.SubItems[replacedNameIndex];
                subItem.ForeColor = Color.Blue;
                item.SubItems[replacedNameIndex].Text = results[index];

                if (!e.Preview)
                {
                    item.Tag = (item.SubItems[columnHeaderPath.Index].Text + results[index]);
                }
            }

            Dictionary<int, string> errors = e.Errors;

            foreach (int index in errors.Keys)
            {
                ListViewItem item = listViewFiles.Items[index];
                Color color = Color.Red;
                item.SubItems[nameIndex].ForeColor = color;
                ListViewItem.ListViewSubItem subItem = item.SubItems[nameIndex];
                subItem.ForeColor = color;
                subItem.Text = errors[index];
            }

            listViewFiles.EndUpdate();
            string message;
            MessageBoxIcon icon;
            int resultsCount = results.Count;
            bool preview = e.Preview;

            if (resultsCount < 1)
            {
                message = "名前は変更されません";
                message += (preview ? "。" : "でした。");
                icon = MessageBoxIcon.Stop;
            }
            else
            {
                message = $"{resultsCount} 個の名前";
                message += preview ? "が変更されます。" : "を変更しました。";
                icon = MessageBoxIcon.Information;
            }

            int errorsCount = errors.Count;

            if (errorsCount > 0)
            {
                message += string.Format("{0}{0}{1} 件のエラーがあります。", newLine, errorsCount);
                icon = MessageBoxIcon.Error;
            }

            EnableControls(true);
            ShowMessage(message, MessageBoxButtons.OK, icon);
        }

        private void replaceEngine_ErrorOccurred(object sender, ReplaceEngine.ErrorOccurredEventArgs e)
        {
            if (!checkBoxConfirm.Checked || e.Preview) return;

            if (ShowMessage(e.ErrorMessage, MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.Cancel)
            {
                e.Cencel = true;
            }
        }

        private void replaceEngine_FileNameReplaced(object sender, ReplaceEngine.FileNameReplacedEventArgs e)
        {
            if (checkBoxConfirm.Checked)
            {
                if (ShowMessage(string.Format("{0}{1}を{1}{2}{1}に変更しました。", e.OldFileName, newLine, e.NewFileName),
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void replaceEngine_PreviewFileNameReplace(object sender, ReplaceEngine.PreviewFileNameReplaceEventArgs e)
        {
            if (checkBoxConfirm.Checked)
            {
                DialogResult dialogResult = ShowMessage(string.Format("{0}{1}を{1}{2}{1}に変更します。よろしいですか？", e.OldFileName, newLine, e.NewFileName),
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                switch (dialogResult)
                {
                    case DialogResult.No:
                        e.Cancel = true;
                        break;
                    case DialogResult.Cancel:
                        e.Abort = true;
                        break;
                }
            }
        }

        private void toolStripMenuItemCreateNew_Click(object sender, EventArgs e)
        {
            ClearProject();
        }

        private void toolStripMenuItemOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            OpenFile(openFileDialog.FileName);
        }

        private void toolStripMenuItemQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripMenuItemSave_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void toolStripMenuItemSaveAs_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            SaveFile();
        }
    }
}
