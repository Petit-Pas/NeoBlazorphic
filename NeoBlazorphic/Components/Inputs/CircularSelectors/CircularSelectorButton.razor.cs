using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using NeoBlazorphic.StyleParameters;
using NeoBlazorphic.UserInteraction.Mouse.BaseComponents;

namespace NeoBlazorphic.Components.Inputs.CircularSelectors
{
    public partial class CircularSelectorButton : MouseInteractiveBaseComponent
    {
        /// <summary>
        ///     the pathstring to use for the path component of the SVG 
        /// </summary>
        [Parameter]
        public string PathString { get; set; } = "";

        [Parameter]
        public int AngleShift { get; set; } = 0;

        /// <summary>
        ///     Used to bubble up events
        /// </summary>
        [Parameter]
        public int Index { get; set; } = 0;

        /// <summary>
        ///     Used to dinamically calculate the position of the label on the button
        /// </summary>
        [Parameter, EditorRequired]
        public int ButtonAngle { get; set; }

        [Parameter, EditorRequired]
        public bool IsSelected { get; set; }

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
                    // TODO: tu peux simplement appeler BackgroundShape.Concave.ToString(), c'est plus lisible.
                    Console.WriteLine($"WARNING: CircularSelectorButton.Shape cannot be {Enum.GetName(value)}. Try with {Enum.GetName(BackgroundShape.Concave)} or {Enum.GetName(BackgroundShape.Convex)}");
                }
                _shape = value;
                StateHasChanged();
            }
        }
        private BackgroundShape _shape = BackgroundShape.Concave;

        [Parameter]
        public string AccentClass { get; set; } = "selected-primary";

        // TODO: petit problème ici.
        // tu demandes un redraw si le scaleFactor change.
        // Du coup, tu associes un comportement de ton composant à un set de propriété.
        // Dans ce composant ci, c'est parfaitement copréhensible de le faire dans le OnMouseOver & OnMouseOut, mais pas dans le set de propriété
        // C'est l'event handler lui même qui doit faire appel au redraw, pas le set de propriété
        // Ce redraw dans le set de prorpriété aurait du sens en revanche si ton composant avait un input "ScaleFactor" de type slide range,
        // ce qui te permettrai d'avoir un rendu temps réel
        protected string Scale {
            get => _scaleFactor;
            set
            {
                if (_scaleFactor != value)
                {
                    _scaleFactor = value;
                    StateHasChanged();
                }
            }
        }
        private string _scaleFactor = "1";

        protected override Task OnMouseOver(MouseEventArgs args)
        {
            Scale = "1.15";
            return base.OnMouseOver(args);
        }

        protected override Task OnMouseOut(MouseEventArgs args)
        {
            Scale = "1";
            return base.OnMouseOut(args);
        }

        protected string GetButtonClass() => this.IsSelected ? AccentClass : string.Empty;
    }
}
