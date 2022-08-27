using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoBlazorphic.EventArgs
{
    public class SelectedItemEventArgs
    {
        public SelectedItemEventArgs(object item, int itemIndex)
        {
            Item = item;
            ItemIndex = itemIndex;
        }

        public object Item { get; set; }
        public int ItemIndex { get; set; }
    }
}
