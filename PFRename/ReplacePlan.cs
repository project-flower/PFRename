using System.Text.RegularExpressions;

namespace PFRename
{
    public class ReplacePlan
    {
        #region Public Fields

        public string From = string.Empty;
        public Regex Regex = null;
        public string To = string.Empty;

        #endregion

        #region Public Methods

        public ReplacePlan() :
            this(string.Empty, string.Empty, false)
        {
        }

        public ReplacePlan(string from, string to, bool regex)
        {
            From = from;

            if (regex)
            {
                try
                {
                    Regex = new Regex(from);
                }
                catch
                {
                    throw;
                }
            }

            To = to;
        }

        public string Replace(string value)
        {
            if (Regex != null)
            {
                return Regex.Replace(value, From, To);
            }

            return value.Replace(From, To);
        }

        #endregion
    }
}
