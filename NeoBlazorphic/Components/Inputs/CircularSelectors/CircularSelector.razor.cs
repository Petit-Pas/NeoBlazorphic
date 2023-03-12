using Microsoft.AspNetCore.Components;
using NeoBlazorphic.Extensions.BaseTypes;
using NeoBlazorphic.Math.Units;
using NeoBlazorphic.StyleParameters;

namespace NeoBlazorphic.Components.Inputs.CircularSelectors
{
    public partial class CircularSelector : ComponentBase
    {
        private Guid UID = Guid.NewGuid();

        [Parameter]
        public RenderFragment? ChildContent { get; set; } = null;

        [Parameter]
        public int AngleOffset { get; set; } = 0;

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

        [Parameter]
        public ThemeColor ThemeColor { get; set; } = ThemeColor.Base;
        [Parameter]
        public ThemeColor Selected { get; set; } = ThemeColor.Primary;

        public string? CenterText { get; set; }


        public List<CircularSelectorButtonContent> ButtonContents { get; set; } = new List<CircularSelectorButtonContent>();

        [Parameter]
        public int ButtonAngle { get; set; } = 30;

        private void RefreshValues()
        {
            var angleInRadians = Converter.ToRadian(ButtonAngle);
            AngleEnd = new Point2D(System.Math.Cos(angleInRadians) * 20, -System.Math.Sin(angleInRadians) * 20);
            AmountButtons = ButtonContents?.Count ?? 0;
        }

        public int AmountButtons { get; set; }
        public CircularSelectorButtonContent? SelectedItem { get; set; }

        private Point2D AngleEnd = new (0, 0);


        public void NotifyChangeOfState()
        {
            RefreshValues();
            StateHasChanged();
        }

        private string GetColorThemeClass => ThemeColor.GetCssClass();

        private string GetShapeClass => Shape.GetCssClass();
    }
}
