using Microsoft.AspNetCore.Components;
using NeoBlazorphic.Math.Units;
using NeoBlazorphic.StyleParameters;

namespace NeoBlazorphic.Components.Inputs.CircularSelectors
{
    public partial class NewCircularSelector : ComponentBase
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

        public string? CenterText { get; set; }


        public List<NewCircularSelectorButtonContent> ButtonContents { get; set; } = new List<NewCircularSelectorButtonContent>();

        [Parameter]
        public int ButtonAngle { get; set; } = 30;

        private void RefreshValues()
        {
            var angleInRadians = Converter.ToRadian(ButtonAngle);
            AngleEnd = new Point2D(System.Math.Cos(angleInRadians) * 20, -System.Math.Sin(angleInRadians) * 20);
            AmountButtons = ButtonContents?.Count ?? 0;
        }

        public int AmountButtons { get; set; }
        public NewCircularSelectorButtonContent? SelectedItem { get; set; }

        private Point2D AngleEnd = new (0, 0);


        public void NotifyChangeOfState()
        {
            RefreshValues();
            StateHasChanged();
        }
    }
}
