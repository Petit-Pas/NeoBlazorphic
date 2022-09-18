using Microsoft.AspNetCore.Components;
using NeoBlazorphic.EventArgs;
using NeoBlazorphic.Math.Units;
using NeoBlazorphic.Models.SelectableItems;
using NeoBlazorphic.StyleParameters;

namespace NeoBlazorphic.Components.Inputs.CircularSelectors
{
    public partial class CircularSelector<T> : UiComponentBase
    {
        [Parameter, EditorRequired]
        public SelectableItemList<T> Items { get; set; } = SelectableItemList<T>.Empty;

        /// <summary>
        ///     Expected to be in degrees
        /// </summary>
        [Parameter]
        public int ButtonAngle { get; set; } = 45;

        [Parameter]
        public int ViewBoxSize { get; set; } = 300;

        [Parameter]
        public int AngleOffset { get; set; } = 0;

        [Parameter]
        public EventCallback<SelectedItemEventArgs<T>> OnItemSelected { get; set; }

        [Parameter]
        public EventCallback<SelectedItemEventArgs<T>> OnItemHovered { get; set; }

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
                    Console.WriteLine($"WARNING: CircularSelector.Shape cannot be {Enum.GetName(value)}. Try with {Enum.GetName(BackgroundShape.Concave)} or {Enum.GetName(BackgroundShape.Convex)}");
                }
                _shape = value;
                StateHasChanged();
            }
        }
        private BackgroundShape _shape = BackgroundShape.Concave;


        protected Point2D AngleEnd { get; set; }

        [Parameter]
        public string CenterText { get; set; } = "Default";

        [Parameter]
        public string AccentClass { get; set; } = "neo-primary";

        protected override void OnInitialized()
        {
            base.OnInitialized();

            if (Items.Count * ButtonAngle > 360)
            {
                Console.WriteLine($"WARN: {Items.Count} of {ButtonAngle}° will result in more than a full circle!");
            }

            CalculateAngleEnd();
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            CalculateAngleEnd();
        }

        private void CalculateAngleEnd()
        {
            var angleInRadians = Converter.ToRadian(ButtonAngle);
            AngleEnd = new Point2D(System.Math.Cos(angleInRadians) * 20, -System.Math.Sin(angleInRadians) * 20);
        }

        public virtual async Task OnButtonMouseOver(SelectableItem<T> selectedItem)
        {
            await OnItemHovered.InvokeAsync(new SelectedItemEventArgs<T>(selectedItem));
        }

        public virtual async Task OnButtonClicked(SelectableItem<T> selectedItem)
        {
            if (selectedItem.IsEnabled)
            {
                Items.ResetSelected(selectedItem);
                StateHasChanged();
                await OnItemSelected.InvokeAsync(new SelectedItemEventArgs<T>(selectedItem));
            }
        }
    }
}
