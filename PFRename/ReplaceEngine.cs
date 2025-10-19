using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace PFRename
{
    [DesignerCategory("Code")]
    public class ReplaceEngine : Component
    {
        #region Public Classes

        public class CompletedEventArgs : EventArgs
        {
            public readonly Dictionary<int, string> Errors;
            public readonly bool Preview;
            public readonly Dictionary<int, string> Results;

            public CompletedEventArgs(Dictionary<int, string> results, Dictionary<int, string> errors, bool preview)
            {
                Errors = errors;
                Preview = preview;
                Results = results;
            }
        }

        public delegate void CompletedEventHandler(object sender, CompletedEventArgs e);

        public class ErrorOccurredEventArgs : EventArgs
        {
            public bool Cencel = false;
            public readonly string ErrorMessage;
            public readonly bool Preview;

            public ErrorOccurredEventArgs(string errorMessage, bool preview)
            {
                ErrorMessage = errorMessage;
                Preview = preview;
            }
        }

        public delegate void ErrorOccurredEventHandler(object sender, ErrorOccurredEventArgs e);

        public class FileNameReplacedEventArgs : EventArgs
        {
            public bool Cancel = false;
            public readonly string DirectoryName;
            public readonly int Index;
            public readonly string NewFileName;
            public readonly string OldFileName;

            public FileNameReplacedEventArgs(int index, string oldFileName, string newFileName, string directoryName)
            {
                DirectoryName = directoryName;
                Index = index;
                NewFileName = newFileName;
                OldFileName = oldFileName;
            }
        }

        public delegate void FileNameReplacedEventHandler(object sender, FileNameReplacedEventArgs e);

        public class PreviewFileNameReplaceEventArgs : EventArgs
        {
            public bool Abort = false;
            public bool Cancel = false;
            public readonly string DirectoryName;
            public readonly int Index;
            public readonly string NewFileName;
            public readonly string OldFileName;

            public PreviewFileNameReplaceEventArgs(int index, string oldFileName, string newFileName, string directoryName)
            {
                DirectoryName = directoryName;
                Index = index;
                NewFileName = newFileName;
                OldFileName = oldFileName;
            }
        }

        public delegate void PreviewFileNameReplaceEventHandler(object sender, PreviewFileNameReplaceEventArgs e);

        #endregion

        #region Private Classes

        private delegate void MethodInvoker<T>(T arg);

        #endregion

        #region Private Fields

        private readonly AutoResetEvent autoResetEvent = new AutoResetEvent(false);
        private bool cancelled = false;
        private readonly Dictionary<int, string> errors = new Dictionary<int, string>();
        private string[] files = null;
        private readonly Dictionary<int, string> results = new Dictionary<int, string>();
        private ReplacePlan[] replacePlans = null;
        private Thread thread = null;

        #endregion

        #region Public Properties

        public event CompletedEventHandler Completed = delegate { };
        public event ErrorOccurredEventHandler ErrorOccurred = delegate { };
        public event FileNameReplacedEventHandler FileNameReplaced = delegate { };
        public event PreviewFileNameReplaceEventHandler PreviewFileNameReplace = delegate { };

        public bool IsBusy
        {
            get
            {
                return ((thread != null) && thread.IsAlive);
            }
        }

        public Form Owner
        {
            get;
            set;
        }

        #endregion

        #region Public Methods

        public ReplaceEngine()
        {
        }

        public void BeginReplace(string[] files, ReplacePlan[] plans, bool preview)
        {
            if (IsBusy)
            {
                throw new Exception("実行中です。");
            }

            cancelled = false;
            errors.Clear();
            this.files = files;
            results.Clear();

            if (plans.Any(n => string.IsNullOrEmpty(n.From)))
            {
                throw new Exception("変更前の文字列を空にすることはできません。");
            }

            replacePlans = new ReplacePlan[plans.Length];
            Array.Copy(plans, replacePlans, plans.Length);

            thread = new Thread(ThreadMain)
            {
                Priority = ThreadPriority.Normal
            };

            thread.Start(preview);
        }

        #endregion

        #region Private Methods

        private void BeginInvoke<T>(MethodInvoker<T> handler, T eventArgs)
            where T : EventArgs
        {
            if (Owner == null)
            {
                return;
            }

            Owner.BeginInvoke(new Action<T>(handler), eventArgs);
            autoResetEvent.WaitOne();
        }

        private void InvokeCompleted(CompletedEventArgs e)
        {
            Completed(this, e);
            autoResetEvent.Set();
        }

        private void InvokeErrorOccurred(ErrorOccurredEventArgs e)
        {
            ErrorOccurred(this, e);

            if (e.Cencel)
            {
                cancelled = true;
            }

            autoResetEvent.Set();
        }

        private void InvokeFileNameReplaced(FileNameReplacedEventArgs e)
        {
            FileNameReplaced(this, e);

            if (e.Cancel)
            {
                cancelled = true;
            }

            autoResetEvent.Set();
        }

        private void InvokePreviewFileNameReplace(PreviewFileNameReplaceEventArgs e)
        {
            PreviewFileNameReplace(this, e);
            autoResetEvent.Set();
        }

        private void ThreadMain(object parameter)
        {
            bool preview = (bool)parameter;

            for (int i = 0; i < files.Length; ++i)
            {
                if (cancelled)
                {
                    break;
                }

                string fileName = files[i];
                string path;
                string name;

                try
                {
                    path = Path.GetDirectoryName(fileName);
                    name = Path.GetFileName(fileName);
                }
                catch (Exception exception)
                {
                    string message = exception.Message;
                    errors.Add(i, message);
                    BeginInvoke(InvokeErrorOccurred, new ErrorOccurredEventArgs(message, preview));
                    continue;
                }

                string newFileName = name;
                bool skipped = false;

                foreach (ReplacePlan plan in replacePlans)
                {
                    try
                    {
                        newFileName = plan.Replace(newFileName);
                    }
                    catch (Exception exception)
                    {
                        // 正規表現の例外
                        string message = exception.Message;
                        errors.Add(i, message);
                        BeginInvoke(InvokeErrorOccurred, new ErrorOccurredEventArgs(message, preview));
                        skipped = true;
                        break;
                    }
                }

                if (cancelled || skipped)
                {
                    break;
                }

                if (name == newFileName)
                {
                    continue;
                }

                string newFileFullName;

                try
                {
                    newFileFullName = Path.Combine(path, newFileName);
                    bool isFile = File.Exists(fileName);
                    bool isDirectory = Directory.Exists(fileName);

                    if (!(isFile || isDirectory))
                    {
                        throw new Exception($"{fileName} がありません。");
                    }

                    if (!preview)
                    {
                        var args = new PreviewFileNameReplaceEventArgs(i, name, newFileName, path);
                        BeginInvoke(InvokePreviewFileNameReplace, args);

                        if (args.Abort)
                        {
                            break;
                        }

                        if (args.Cancel)
                        {
                            continue;
                        }
                    }

                    if (isFile)
                    {
                        if (preview)
                        {
                            new FileInfo(newFileName);
                        }
                        else
                        {
                            File.Move(fileName, newFileFullName);
                        }
                    }
                    else if (isDirectory)
                    {
                        if (preview)
                        {
                            new DirectoryInfo(newFileName);
                        }
                        else
                        {
                            Directory.Move(fileName, newFileFullName);
                        }
                    }
                }
                catch (Exception exception)
                {
                    string message = exception.Message;
                    errors.Add(i, message);
                    BeginInvoke(InvokeErrorOccurred, new ErrorOccurredEventArgs(message, preview));
                    continue;
                }

                results.Add(i, newFileName);

                if (!preview)
                {
                    BeginInvoke(InvokeFileNameReplaced, new FileNameReplacedEventArgs(i, name, newFileName, path));
                }
            }

            BeginInvoke(InvokeCompleted, new CompletedEventArgs(results, errors, preview));
        }

        #endregion
    }
}
