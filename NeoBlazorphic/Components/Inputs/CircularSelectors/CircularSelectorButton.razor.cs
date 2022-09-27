using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using NeoBlazorphic.Models.SelectableItems;
using NeoBlazorphic.StyleParameters;
using NeoBlazorphic.UserInteraction.Mouse.BaseComponents;

namespace NeoBlazorphic.Components.Inputs.CircularSelectors
{
    public partial class CircularSelectorButton<T> : MouseInteractiveBaseComponent
    {
        /// <summary>
        ///     the pathstring to use for the path component of the SVG 
        /// </summary>
        [Parameter]
        public string PathString { get; set; } = "";

        [Parameter]
        public int AngleShift { get; set; } = 0;

        [Parameter, EditorRequired]
        public SelectableItem<T> Item { get; set; } = SelectableItem<T>.Empty;

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

        protected override Task OnMouseOver(MouseEventArgs args)
        {
            if (Item != SelectableItem<T>.Empty && Item.IsEnabled)
            {
                ScaleFactor = "1.15";
            }
            return base.OnMouseOver(args);
        }

        protected override Task OnMouseOut(MouseEventArgs args)
        {
            if (Item != SelectableItem<T>.Empty && Item.IsEnabled)
            {
                ScaleFactor = "1";
            }
            return base.OnMouseOut(args);
        }

        // UI methods
        private string GetOpacityOfColoredButton() => Item.IsSelected ? "1" : "0";

        private string GetMainButtonClass() => Item.IsEnabled ? "" : "neo-disabled";
    }
}
