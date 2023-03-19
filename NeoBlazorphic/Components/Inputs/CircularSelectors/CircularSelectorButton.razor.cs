using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using NeoBlazorphic.Extensions.BaseTypes;
using NeoBlazorphic.StyleParameters;

// TODO disabled missing + comportment to handle UniqueSelectableItemList

namespace NeoBlazorphic.Components.Inputs.CircularSelectors;

public partial class CircularSelectorButton : ComponentBase
{
    private Guid UID = Guid.NewGuid();

    private void OnClick(MouseEventArgs e)
    {
        CircularSelector.SelectedItem = ButtonContent;
        CircularSelector.NotifyChangeOfState();
    }
}