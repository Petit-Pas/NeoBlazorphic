using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using NeoBlazorphic.Extensions.BaseTypes;
using NeoBlazorphic.StyleParameters;
using NeoBlazorphic.UserInteraction.Mouse.BaseComponents;

namespace NeoBlazorphic.Components.Inputs.Checks.CheckBoxes
{
    // TODO the check mark shoulkd be updated with font awesome but it is currenly down
    // TODO the expected comportment is a slicker V in the squared checkbox and a dot in the round checkbox

    public partial class CheckBox : MouseInteractiveBaseComponent
    {
        [Parameter]
        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                if (_isEnabled != value)
                {
                    _isEnabled = value;
                    ComputeOpacity();
                    ComputeCursor();
                }
            }
        }
        private bool _isEnabled = true;

        [Parameter]
        public string AccentClass { get; set; } = "neo-primary";

        // TODO This should be EditorRequired
        // But as of the 14-10-22, there is an unsolved bug on Microsoft's end that makes binding to an EditorRequired property raise a warning stating a value may have not been provided
        // https://github.com/dotnet/razor-compiler/issues/125
        [Parameter]
        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                if (_isChecked != value)
                {
                    _isChecked = value;
                    ComputeShadowPosition();
                    ComputeMarkOpacity();
                }
            }
        }
        private bool _isChecked;

        [Parameter]
        public EventCallback<bool> IsCheckedChanged { get; set; }

        [Parameter] 
        public CheckBoxShape BoxShape { get; set; } = CheckBoxShape.Normal;

        private BackgroundShape _backgroundShape { get; set; } = BackgroundShape.Flat;
        private ShadowPosition _shadowPosition { get; set; } = ShadowPosition.Out;
        private Opacity _markOpacity { get; set; } = Opacity.Transparent;
        private Opacity _opacity { get; set; } = Opacity.Full;
        private Cursor _cursor { get; set; } = Cursor.Pointer;

        protected override async Task OnMouseOut(MouseEventArgs args)
        {
            if (IsEnabled)
            {
                _backgroundShape = BackgroundShape.Flat;
            }
            await base.OnMouseOut(args);
        }

        protected override async Task OnMouseOver(MouseEventArgs args)
        {
            if (IsEnabled)
            {
                _backgroundShape = BackgroundShape.Concave;
            }
            await base.OnMouseOver(args);
        }

        protected override async Task OnMouseClick(MouseEventArgs args)
        {
            if (IsEnabled)
            {
                IsChecked = !IsChecked;
                await IsCheckedChanged.InvokeAsync(IsChecked);
            }
            await base.OnMouseClick(args);
        }

        // Refresh methods
        private void ComputeShadowPosition() 
        {
            _shadowPosition = IsChecked ? ShadowPosition.In : ShadowPosition.Out;
        }
        private void ComputeMarkOpacity()
        {
            _markOpacity = IsChecked ? Opacity.Full : Opacity.Transparent;
        }
        private void ComputeOpacity()
        {
            _opacity = IsEnabled ? Opacity.Full : Opacity.Disabled;
        }

        private void ComputeCursor()
        {
            _cursor = IsEnabled ? Cursor.Pointer : Cursor.Default;
        }

        // UI Methods
        private string GetBackgroundShape() => _backgroundShape.GetCssClass();
        private string GetBoxShape() => BoxShape.GetCssClass();
        private string GetShadowPosition() => _shadowPosition.GetCssClass();
        private string GetMarkOpacity() => _markOpacity.GetCssClass();
        private string GetOpacity() => _opacity.GetCssClass();
        private string GetCursor() => _cursor.GetCssClass();
        private string GetAccentClass() => IsChecked ? AccentClass : "";

    }
}
