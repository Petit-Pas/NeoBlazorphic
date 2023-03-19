using Microsoft.AspNetCore.Components;
using NeoBlazorphic.Math.Units;

namespace NeoBlazorphic.Components.Inputs.CircularSelectors;

public partial class CircularSelector : ComponentBase
{
    private Guid UID = Guid.NewGuid();

    public List<CircularSelectorButtonContent> ButtonContents { get; set; } = new List<CircularSelectorButtonContent>();

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

    public void AddButtonContentIfMissing(CircularSelectorButtonContent buttonContent)
    {
        if (!ButtonContents.Contains(buttonContent))
        {
            ButtonContents.Add(buttonContent);
            NotifyChangeOfState();
        }
    }
}