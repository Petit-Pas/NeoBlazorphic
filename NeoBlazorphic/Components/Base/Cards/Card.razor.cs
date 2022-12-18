using System.Security.Cryptography;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using NeoBlazorphic.Extensions.BaseTypes;
using NeoBlazorphic.StyleParameters;
using NeoBlazorphic.UserInteraction.Mouse.BaseComponents;

namespace NeoBlazorphic.Components.Base.Cards
{

    /// <summary>
    ///     To work properly, a css class should set these variables: 
    ///         --main-color
    ///         --dark-shadow
    ///         --light-shadow
    ///         --dark-color ==> only needed if using Concave or Convex shape
    ///         --light-color ==> only needed if using Concave or Convex shape
    ///         
    ///     some default ones are provided already with the css file of the NeoBlazorphic lirbary.
    ///         
    ///     https://neumorphism.io/ can help you design these
    /// </summary>
    public partial class Card : MouseInteractiveBaseComponent
    {
        [Inject]
        protected ILogger<Card> Logger { get; set; } = default!;

        // made for inherited classes only that simply want to apply an additional class everytime the element is displayed. 
        // if the parent wants to add some classes, he should surround the Card element with a div that has the given style.
        protected string CustomClasses { get; set; } = "";

        [Parameter]
        public RenderFragment? ChildContent { get; set; } = default!;

        [Parameter] 
        public Spacing Padding { get; set; } = Spacing._3;
        [Parameter] 
        public Spacing Margin { get; set; } = Spacing._0;

        [Parameter] 
        public BorderRadius BorderRadius { get; set; } = new (0.75, "rem");

        [Parameter] 
        public bool ShouldBeVisibleWhenEmpty { get; set; } = true;

        private string GetPadding() => Padding.GetCssClass("padding");
        private string GetMargin() => Margin.GetCssClass("margin");

        [Parameter]
        public bool TextSelectable
        {
            get => _textSelectable;
            set
            {
                if (value != _textSelectable)
                {
                    SetNewTextSelectableStyle(value);
                    _textSelectable = value;
                }
            }
        }
        private bool _textSelectable = true;
        private string textSelectableStyle = "";

        [Parameter]
        public BackgroundShape Shape { get; set; } = BackgroundShape.Flat;


        [Parameter]
        public ShadowPosition ShadowPosition { get; set; } = ShadowPosition.Out;


        private void SetNewTextSelectableStyle(bool selectable)
        {
            switch (selectable)
            {
                case true:
                    textSelectableStyle = "";
                    break;
                case false:
                    textSelectableStyle = "select-none";
                    break;
            }
        }

        // UI Methods
        private string GetShadowPosition() => ShadowPosition.GetCssClass();
        private string GetBackgroundShape() => Shape.GetCssClass();
        private string GetBorderRadius() => BorderRadius.GetCssProperty();

        private string GetVisiblityDependingOnEmptiness() => ShouldBeVisibleWhenEmpty ? "": "invisible-when-empty";
    }
}
