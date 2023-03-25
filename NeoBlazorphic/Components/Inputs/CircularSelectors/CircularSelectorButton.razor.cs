using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using NeoBlazorphic.Extensions.BaseTypes;
using NeoBlazorphic.Math.Units;
using static System.Math;

// TODO disabled missing + comportment to handle UniqueSelectableItemList

namespace NeoBlazorphic.Components.Inputs.CircularSelectors;

public partial class CircularSelectorButton<T> : ComponentBase
{
    private Guid _uid;
    private string _gradientId;

    protected override void OnInitialized()
    {
        _uid = Guid.NewGuid();
        _gradientId = $"{_uid}-ButtonGradient";
    }

    private void OnClick(MouseEventArgs e)
    {
        ButtonContent?.OnMouseClick(e);
    }

    private void OnOver(MouseEventArgs e)
    {
        ButtonContent?.OnMouseOver(e);
    }


    protected override void OnParametersSet()
    {
        RefreshValues();
    }

    private string _gradientOriginX = "";
    private string _gradientOriginY = "";
    private string _gradientEndX = "";
    private string _gradientEndY = "";

    private string _labelOriginX = "";
    private string _labelOriginY = "";
    private string _labelShiftedX = "";
    private string _labelShiftedY = "";

    private void RefreshValues()
    {
        // calculate origins for gradients since we want the gradient to invert the rotation of the button itself
        // we take base angle as 135 deg
        var angleInRadiansForGradient = Converter.ToRadian(AngleShift + 135);

        // The 16 comes from the radius of the bigger circle (20, shortened to get the radius closer) of the selector, radius which we need to inject into the trigonometric calculations
        _gradientOriginX = (Cos(angleInRadiansForGradient) * 16).ToInvariantString();
        _gradientOriginY = (-Sin(angleInRadiansForGradient) * 16).ToInvariantString();
        _gradientEndX = (-Cos(angleInRadiansForGradient) * 16).ToInvariantString();
        _gradientEndY = (Sin(angleInRadiansForGradient) * 16).ToInvariantString();

        if (ButtonContent == null)
        {
            return;
        }

        // calculate label position
        var angleInRadians = Converter.ToRadian(ButtonAngle);

        // Since the radius is 20 but we don't want to place the label on the circle, we use a smaller radius for trigonometric calculations
        var labelX = (Cos(angleInRadians / 2) * 15);
        var labelY = (-(Sin(angleInRadians / 2) * 15));
        _labelOriginX = labelX.ToInvariantString();
        _labelOriginY = labelY.ToInvariantString();
        _labelShiftedX = (labelX + ButtonContent.xShift).ToInvariantString();
        _labelShiftedY = (labelY + ButtonContent.yShift).ToInvariantString();
    }
}