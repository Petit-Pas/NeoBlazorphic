using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using NeoBlazorphic.EventArgs;
using NeoBlazorphic.Models.SelectableItems;
using NeoBlazorphic.StyleParameters;
using NeoBlazorphic.UserInteraction.Mouse.BaseComponents;
using Microsoft.JSInterop;


namespace NeoBlazorphic.Components.Inputs.DropDownLists
{
	public partial class DropDownList<T> : MouseInteractiveBaseComponent
    {
        private bool _isHovered = false;
        private bool _isClicked = false;

        private string shadowStyle { get; set; } = "shadow-neo-out";
        private string shapeStyle { get; set; } = "flat";
        protected string SelectedThemeString
        {
            get => _selectedThemeString;
            set
            {
                if (_selectedThemeString != value) {
                    _selectedThemeString = value;
                }
            }
        }
        private string _selectedThemeString = "Empty";

        [Inject]
        protected IJSRuntime _jsRuntimeMouseDown { get; set; } = null!;

        [Parameter, EditorRequired]
        public SelectableItemList<T> Items { get; set; } = SelectableItemList<T>.Empty;

        [Parameter]
        public EventCallback<SelectedItemEventArgs<T>> OnItemSelected { get; set; }
        protected override void OnParametersSet()
        {
            _selectedThemeString = Items.FirstOrDefault()?.Item?.ToString() ?? "Empty";
        }
        [Parameter]
        public EventCallback<SelectedItemEventArgs<T>> OnItemHovered { get; set; }
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
        [JSInvokable]
        public void MouseDownFromJs(MouseEventArgs args)
        {
            Console.WriteLine("coords: {0} {1}", args.ScreenX, args.ScreenY);
            Console.WriteLine("in MouseDownFromJs func");

            OnMouseDown(args);
        }

        private BackgroundShape _shape { get; set; } = BackgroundShape.Flat;
        private ShadowPosition _shadowPlacement { get; set; } = ShadowPosition.Out;
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
        protected override async Task OnMouseOver(MouseEventArgs args)
        {
            _isHovered = true;
            Shape = BackgroundShape.Concave;
            await base.OnMouseOver(args);
        }
        protected override async Task OnMouseOut(MouseEventArgs args)
        {
            _isHovered = false;
            //_isShowing = false; //@TODO: detect when other elements are hovered
            if (_isClicked == false)
            {
                Shape = BackgroundShape.Flat;
                await base.OnMouseOut(args);
            }
        }
        protected override async Task OnMouseDown(MouseEventArgs args)
        {
            if (_isHovered)
            {
                _isClicked = true;
            }
            ShadowPosition = ShadowPosition.In;
            await CustomMouseDown(args);
            //await base.OnMouseDown(args);
        }
        protected async Task CustomMouseDown(MouseEventArgs args)
        {
            Console.WriteLine("in custom func");
            await _jsRuntimeMouseDown.InvokeVoidAsync("window.registerToMouseDownWithGeneralScope", "NeoBlazorphic", "MouseDownFromJs", DotNetObjectReference.Create(this));
            await OnMouseDownCallBack.InvokeAsync(args);
        }
        protected override async Task OnMouseUp(MouseEventArgs args)
        {
            // if the button is not hovered (click then drag) we first want to restore the original color of the button, which is triggered in OnMouseOut
            if (_isHovered == false) {
                _isClicked = false;
                await OnMouseOut(args);
            }
            this.ShadowPosition = ShadowPosition.Out;
            await base.OnMouseUp(args);
        }
        public virtual async Task OnButtonClicked(SelectableItem<T> selectedItem)
        {

            if (selectedItem.IsEnabled) {
                _isClicked = false;
                Shape = BackgroundShape.Flat;

                Items.ResetSelected(selectedItem);
                _selectedThemeString = selectedItem.Item?.ToString() ?? "Empty";
                StateHasChanged();
                await OnItemSelected.InvokeAsync(new SelectedItemEventArgs<T>(selectedItem));
            }
        }
        public virtual async Task OnButtonMouseOver(SelectableItem<T> selectedItem)
        {
            _isHovered = true;
            await OnItemHovered.InvokeAsync(new SelectedItemEventArgs<T>(selectedItem));
        }
    }
}
