using Microsoft.AspNetCore.Components;
using NeoBlazorphic.Extensions.BaseTypes;
using NeoBlazorphic.Math.Units;

namespace NeoBlazorphic.Components.Inputs.CircularSelectors;

// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
public partial class CircularSelector<T> : ComponentBase
{
    private Guid _uid = Guid.NewGuid();

    protected virtual Stack<CircularSelectorButtonContent<T>> ButtonContents { get; set; } = new ();

    protected virtual void UpdateState()
    {
        RefreshValues();
        StateHasChanged();
    }

    public void AddButtonContentIfMissing(CircularSelectorButtonContent<T> buttonContent)
    {
        if (!ButtonContents.Contains(buttonContent))
        {
            ButtonContents.Push(buttonContent);
            UpdateState();
        }
    }

    private void RefreshValues()
    {
        var angleInRadians = Converter.ToRadian(ButtonAngle);
        _angleEnd = new Point2D(System.Math.Cos(angleInRadians) * 20, -System.Math.Sin(angleInRadians) * 20);
        _buttonSvgPath = $"M 0 0 L 20 0 A 20 20 0 0 0 {_angleEnd.X.ToInvariantString()} {_angleEnd.Y.ToInvariantString()} L 0 0";
    }

    private int AngleForButton(int buttonIndex) => - buttonIndex * ButtonAngle + AngleOffset;

    private Point2D _angleEnd = new(0, 0);
    private string _buttonSvgPath = "";
}