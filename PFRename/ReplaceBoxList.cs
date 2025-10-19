using System;
using System.Windows.Forms;

namespace PFRename
{
    public partial class ReplaceBoxList : UserControl
    {
        #region Public Methods

        public ReplaceBoxList()
        {
            InitializeComponent();
        }

        public void Add()
        {
            var inputBox = new InputBox()
            {
                Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top)
            };

            inputBox.ButtonAddClick += inputBox_ButtonAddClick;
            inputBox.ButtonDeleteClick += inputBox_ButtonDeleteClick;
            inputBox.Left = (Padding.Left + inputBox.Margin.Left);
            int top = Padding.Top;

            if (Controls.Count > 0)
            {
                Control control = Controls[Controls.Count - 1];
                top = (control.Bottom + control.Margin.Bottom);
            }
            else
            {
                inputBox.CanDelete = false;
            }

            inputBox.Tag = Controls.Count;
            inputBox.Top = (top + inputBox.Margin.Top);
            inputBox.Width = (ClientRectangle.Width - inputBox.Left - inputBox.Margin.Right - Padding.Right);
            Controls.Add(inputBox);
        }

        public void Apply(ReplacePlan[] plans)
        {
            if ((plans == null) || (plans.Length < 1))
            {
                Clear();
                return;
            }

            while (plans.Length > Controls.Count)
            {
                Add();
            }

            while (plans.Length < Controls.Count)
            {
                Remove(1);
            }

            for (int i = 0; i < plans.Length; ++i)
            {
                var inputBox = Controls[i] as InputBox;
                inputBox.ApplyPlan(plans[i]);
            }
        }

        public void Clear()
        {
            while (Controls.Count > 1)
            {
                ReleaseItem(1);
            }

            (Controls[0] as InputBox).Clear();
        }

        public ReplacePlan[] GetPlans()
        {
            var result = new ReplacePlan[Controls.Count];

            for (int i = 0; i < result.Length; ++i)
            {
                var inputBox = Controls[i] as InputBox;

                try
                {
                    result[i] = inputBox.GeneratePlan();
                }
                catch (Exception exception)
                {
                    throw new Exception($"{exception.Message}\r\n\r\n({i + 1} 個目)");
                }
            }

            return result;
        }

        #endregion

        #region Private Methods

        private void inputBox_ButtonAddClick(object sender, EventArgs e)
        {
            var inputBox = sender as InputBox;
            int index = (int)(inputBox.Tag);
            Insert(index);
        }

        private void inputBox_ButtonDeleteClick(object sender, EventArgs e)
        {
            var inputBox = sender as InputBox;
            int index = (int)(inputBox.Tag);
            Remove(index);
        }

        private void Insert(int index)
        {
            Add();
            var inputBox = Controls[index] as InputBox;
            bool regex = inputBox.Regex;

            for (int i = (Controls.Count - 1); i > (index + 1); --i)
            {
                inputBox = Controls[i] as InputBox;
                var prevInputBox = Controls[i - 1] as InputBox;
                inputBox.CopyFrom(prevInputBox);
            }

            (Controls[index + 1] as InputBox).Clear(regex);
        }

        private void ReleaseItem(int index)
        {
            var inputBox = Controls[index] as InputBox;
            inputBox.ButtonAddClick -= inputBox_ButtonAddClick;
            inputBox.ButtonDeleteClick -= inputBox_ButtonDeleteClick;
            Controls.RemoveAt(index);
        }

        private void Remove(int index)
        {
            InputBox inputBox;

            for (int i = index; i < (Controls.Count - 1); ++i)
            {
                inputBox = Controls[i] as InputBox;
                var nextInputBox = Controls[i + 1] as InputBox;
                inputBox.CopyFrom(nextInputBox);
            }

            ReleaseItem(Controls.Count - 1);
        }

        #endregion

        // Designer Methods

        private void load(object sender, EventArgs e)
        {
            Add();
        }
    }
}
