using System.ComponentModel;
using System.Windows.Forms;

[DesignerCategory("Code")]
class DoubleBufferredListView : ListView
{
    protected override bool DoubleBuffered
    {
        get
        {
            return true;
        }

        set
        {
        }
    }

}
