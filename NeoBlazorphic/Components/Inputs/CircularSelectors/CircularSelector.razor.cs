using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NeoBlazorphic.EventArgs;
using NeoBlazorphic.Math.Units;
using NeoBlazorphic.StyleParameters;
using NeoBlazorphic.UserInteraction.Mouse.BaseComponents;

namespace NeoBlazorphic.Components.Inputs.CircularSelectors
{
    public partial class CircularSelector : UiComponentBase
    {
        [Parameter]
        public uint AmountButtons { get; set; } = 3;

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
        public EventCallback<SelectedItemEventArgs> OnItemSelected { get; set; }

        [Parameter]
        public EventCallback<SelectedItemEventArgs> OnItemHovered { get; set; }

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
                if (value is not BackgroundShape.Concave or BackgroundShape.Convex)
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

        protected int SelectedIndex { get; set; } = -1;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            if (AmountButtons * ButtonAngle > 360)
            {
                Console.WriteLine($"WARN: {AmountButtons} of {ButtonAngle}° will result in more than a full circle!");
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

        public virtual async Task OnButtonMouseOver(int buttonIndex)
        {
            await OnItemHovered.InvokeAsync(new SelectedItemEventArgs(buttonIndex, buttonIndex));
        }

        public virtual async Task OnButtonClicked(int buttonIndex)
        {
            SelectedIndex = buttonIndex;
            StateHasChanged();
            await OnItemSelected.InvokeAsync(new SelectedItemEventArgs(buttonIndex, buttonIndex));
        }
    }
}
