using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using NeoBlazorphic.Extensions.BaseTypes;
using NeoBlazorphic.StyleParameters;

// TODO disabled missing + comportment to handle SelectableItemList

namespace NeoBlazorphic.Components.Inputs.CircularSelectors
{
    public partial class CircularSelectorButton : ComponentBase
    {
        /// <summary>
        ///     the pathstring to use for the path component of the SVG 
        /// </summary>
        [Parameter]
        public string PathString { get; set; } = "";

        [Parameter]
        public int AngleShift { get; set; } = 0;

        [Parameter, EditorRequired]
        public CircularSelectorButtonContent? ButtonContent { get; set; } = null;

        [CascadingParameter]
        public CircularSelector CircularSelector { get; set; }

        [Parameter, EditorRequired] 
        public bool Selected { get; set; } = false;

        private Guid UID = Guid.NewGuid();

        /// <summary>
        ///     Used to dinamically calculate the position of the label on the button
        /// </summary>
        [Parameter, EditorRequired]
        public int ButtonAngle { get; set; }

        [Parameter]
        public BackgroundShape Shape
        {
            get => _shape;
            set
            {
                if (_shape == value)
                {
                    return;
                }
                if (value != BackgroundShape.Concave && value != BackgroundShape.Convex)
                {
                    Console.WriteLine($"WARNING: CircularSelectorButton.Shape cannot be {Enum.GetName(value)}. Try with {BackgroundShape.Concave} or {BackgroundShape.Convex}");
                }
                _shape = value;
                StateHasChanged();
            }
        }
        private BackgroundShape _shape = BackgroundShape.Concave;

        [Parameter]
        public ColorTheme SelectedTheme { get; set; } = ColorTheme.Primary;

        private void OnClick(MouseEventArgs e)
        {
            CircularSelector.SelectedItem = ButtonContent;
            CircularSelector.NotifyChangeOfState();
        }

        // UI Methods
        private string GetSelectedThemeClass => Selected ? SelectedTheme.GetCssClass() : "";

        private string GetShapeClass => Shape.GetCssClass();
    }
}
