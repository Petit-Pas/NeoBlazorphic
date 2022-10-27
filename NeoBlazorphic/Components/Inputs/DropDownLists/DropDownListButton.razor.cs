using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using NeoBlazorphic.Models.SelectableItems;
using NeoBlazorphic.StyleParameters;
using NeoBlazorphic.UserInteraction.Mouse.BaseComponents;

namespace NeoBlazorphic.Components.Inputs.DropDownLists
{
    public partial class DropDownListButton<T> : MouseInteractiveBaseComponent
    {
        [Parameter, EditorRequired]
        public SelectableItem<T> Item { get; set; } = SelectableItem<T>.Empty;
        private BackgroundShape _shape { get; set; } = BackgroundShape.Flat;
        private ShadowPosition _shadowPlacement { get; set; } = ShadowPosition.Out;

        private string shadowStyle { get; set; } = "shadow-neo-out";
        private string shapeStyle { get; set; } = "flat";


        [Parameter]
        public ShadowPosition ShadowPosition
        {
            get => _shadowPlacement;
            set
            {
                if (_shadowPlacement != value) {
                    SetNewShadowStyle(value);
                    _shadowPlacement = value;
                }
            }
        }
        [Parameter]
        public BackgroundShape Shape
        {
            get => _shape;
            set
            {
                if (_shape != value) {
                    SetNewShapeStyle(value);
                    _shape = value;
                }
            }
        }
        private void SetNewShapeStyle(BackgroundShape newShape)
        {
            switch (newShape) {
                case BackgroundShape.Convex:
                    shapeStyle = "convex";
                    break;
                case BackgroundShape.Concave:
                    shapeStyle = "concave";
                    break;
                case BackgroundShape.Flat:
                    shapeStyle = "flat";
                    break;
                default:
                    Shape = BackgroundShape.Flat;
                    break;
            }
            StateHasChanged();
        }
        private void SetNewShadowStyle(ShadowPosition newShadow)
        {
            switch (newShadow) {
                case ShadowPosition.Out:
                    shadowStyle = "shadow-neo-out";
                    break;
                case ShadowPosition.In:
                    shadowStyle = "shadow-neo-in";
                    break;
                default:
                    ShadowPosition = ShadowPosition.Out;
                    break;
            }
            StateHasChanged();
        }
        protected override Task OnMouseOver(MouseEventArgs args)
        {
            _isHovered = true;
            Shape = BackgroundShape.Concave;
            return base.OnMouseOver(args);
        }
        protected override Task OnMouseOut(MouseEventArgs args)
        {
            if (Item != SelectableItem<T>.Empty && Item.IsEnabled) {
                _isHovered = false;
                Shape = BackgroundShape.Flat;
            }
            return base.OnMouseOut(args);
        } 
    }
}
