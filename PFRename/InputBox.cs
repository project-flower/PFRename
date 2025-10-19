using System;
using System.Drawing;
using System.Windows.Forms;

namespace PFRename
{
    public partial class InputBox : UserControl
    {
        #region Public Properties

        public event EventHandler ButtonAddClick = delegate { };
        public event EventHandler ButtonDeleteClick = delegate { };

        public bool CanDelete
        {
            get
            {
                return buttonDelete.Enabled;
            }

            set
            {
                buttonDelete.Enabled = value;
            }
        }

        public string From
        {
            get
            {
                return textBoxFrom.Text;
            }

            set
            {
                textBoxFrom.Text = value;
            }
        }

        public bool Regex
        {
            get
            {
                return checkBoxRegex.Checked;
            }

            set
            {
                checkBoxRegex.Checked = value;
            }
        }

        public string To
        {
            get
            {
                return textBoxTo.Text;
            }

            set
            {
                textBoxTo.Text = value;
            }
        }

        #endregion

        #region Public Methods

        public InputBox()
        {
            InitializeComponent();
            MaximumSize = new Size(int.MaxValue, Height);
            Clear();
        }

        public void ApplyPlan(ReplacePlan plan)
        {
            if (plan == null)
            {
                Clear();
                return;
            }

            From = plan.From;
            Regex = (plan.Regex != null);
            To = plan.To;
        }

        public void Clear(bool regex = false)
        {
            From = string.Empty;
            Regex = regex;
            To = string.Empty;
        }

        public void CopyFrom(InputBox inputBox)
        {
            From = inputBox.From;
            Regex = inputBox.Regex;
            To = inputBox.To;
        }

        public ReplacePlan GeneratePlan()
        {
            try
            {
                return new ReplacePlan(From, To, Regex);
            }
            catch
            {
                throw;
            }
        }

        #endregion

        // Designer Methods

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ButtonAddClick(this, e);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            ButtonDeleteClick(this, e);
        }

        private void resize(object sender, EventArgs e)
        {
            textBoxFrom.Width = (labelTo.Left - textBoxFrom.Margin.Right - labelTo.Margin.Left - textBoxFrom.Left);
            textBoxTo.Left = (labelTo.Right + textBoxTo.Margin.Left + labelTo.Margin.Right);
            textBoxTo.Width = (buttonDelete.Left - textBoxTo.Left - textBoxTo.Margin.Right - buttonDelete.Margin.Left);
        }
    }
}
