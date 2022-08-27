
using Microsoft.AspNetCore.Components.Web;
using NeoBlazorphic.Components.Base.Cards;
using NeoBlazorphic.StyleParameters;

namespace NeoBlazorphic.Components.Inputs.Buttons
{
    public partial class ButtonCard : Card
    {
        private bool _isClicked = false;
        private bool _isHovered = false;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            TextSelectable = false;
        }

        protected override async Task OnMouseOut(MouseEventArgs args)
        {
            _isHovered = false;
            
            // if the button is clicked, we cancel this event because we don't want the color to change when the mouse gets out, it is still the focused button
            if (_isClicked == false)
            {
                Shape = BackgroundShape.Flat;
                await base.OnMouseOut(args);
            }
        }

        protected override async Task OnMouseOver(MouseEventArgs args)
        {
            _isHovered = true;
            Shape = BackgroundShape.Concave;
            await base.OnMouseOver(args);
        }

        protected override async Task OnMouseDown(MouseEventArgs args)
        {
            _isClicked = true;
            this.ShadowPosition = ShadowPosition.In;
            await base.OnMouseDown(args);
        }

        protected override async Task OnMouseUp(MouseEventArgs args)
        {
            _isClicked = false;

            // if the button is not hovered (click then drag) we first want to restore the original color of the button, which is triggered in OnMouseOut
            if (_isHovered == false)
            {
                await OnMouseOut(args);
            }

            this.ShadowPosition = ShadowPosition.Out;
            await base.OnMouseUp(args);
        }
    }
}
