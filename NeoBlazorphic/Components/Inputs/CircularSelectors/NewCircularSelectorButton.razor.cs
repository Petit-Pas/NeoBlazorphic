using Microsoft.AspNetCore.Components;
using NeoBlazorphic.Models.SelectableItems;
using NeoBlazorphic.StyleParameters;

namespace NeoBlazorphic.Components.Inputs.CircularSelectors
{
    public partial class NewCircularSelectorButton : ComponentBase
    {
        /// <summary>
        ///     the pathstring to use for the path component of the SVG 
        /// </summary>
        [Parameter]
        public string PathString { get; set; } = "";

        [Parameter]
        public int AngleShift { get; set; } = 0;

        [Parameter, EditorRequired]
        public NewCircularSelectorButtonContent? ButtonContent { get; set; } = null;

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
        public string AccentClass { get; set; } = "neo-primary";

        protected string ScaleFactor { get; set; } = "1";
    }
}
