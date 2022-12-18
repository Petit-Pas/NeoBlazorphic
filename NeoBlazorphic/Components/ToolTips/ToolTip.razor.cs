using Microsoft.AspNetCore.Components;
using NeoBlazorphic.StyleParameters;

namespace NeoBlazorphic.Components.ToolTips
{
    public partial class ToolTip : ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        ///     The client code should always provide either ToolTipContent or Text, never both.
        ///     In case both are provided, ToolTipContent will prevail.
        /// 
        ///     This is a div that will be displayed in the tooltip
        /// </summary>
        [Parameter]
        public RenderFragment? ToolTipContent { get; set; }

        /// <summary>
        ///     The client code should always provide either ToolTipContent or Text, never both.
        ///     In case both are provided, ToolTipContent will prevail.
        /// 
        ///     This is a simple text that will be displayed in the tooltip
        /// </summary>
        [Parameter]
        public string Text { get; set; } = "tooltip";

        /// <summary>
        ///     Position of the label compared to the ChildContent
        /// </summary>
        [Parameter]
        public ElementRelativePosition LabelPosition { get; set; } = ElementRelativePosition.Bottom;

        //[Parameter] 
        //public bool TriggerOnHover { get; set; } = false;

        private bool _isVisible  = true;

        /// <summary>
        ///     Shows the tooltip
        /// </summary>
        public void Show()
        {
            _isVisible = true;
        }

        /// <summary>
        ///     Hides the tooltip
        /// </summary>
        public void Hide()
        {
            _isVisible = false;
        }

        /// <summary>
        ///     Will shot the tooltip if its not visible, hide it otherwise
        /// </summary>
        public void SwitchVisibility()
        {
            _isVisible = !_isVisible;
        }

    }
}
