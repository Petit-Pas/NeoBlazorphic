using System.Collections;
using Microsoft.AspNetCore.Components;
using NeoBlazorphic.Extensions.BaseTypes;
using NeoBlazorphic.StyleParameters;

namespace NeoBlazorphic.Components.Lists.NeoPlainLists;

// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global

public partial class NeoPlainList<T> : ComponentBase
{
    /// <summary>
    ///     The main color used to compute hover and selected colors.
    /// </summary>
    [Parameter]
    public virtual ThemeColor Color { get; set; } = ThemeColor.Primary;

    /// <summary>
    ///     The ShadowPosition to use for the main card that embeds the list
    /// </summary>
    [Parameter]
    public virtual ShadowPosition ShadowPosition { get; set; } = ShadowPosition.Out;

    /// <summary>
    ///     The BorderRadius to use for the main card that embeds the list
    /// </summary>
    [Parameter]
    public virtual BorderRadius BorderRadius { get; set; } = new (0.75, "em");

    /// <summary>
    ///     The padding to use for the main card that embeds the list
    /// </summary>
    [Parameter]
    public virtual Spacing Margin { get; set; } = Spacing._0;

    /// <summary>
    ///     The margin to use for the main card that embeds the list
    /// </summary>
    [Parameter]
    public virtual Spacing Padding { get; set; } = Spacing._0;

    /// <summary>
    ///     Should be an IEnumerable of items to select from for any "selection" component
    ///     List components should be able to handle non selectable items as well (for display purpose), in that case a,y IEnumerable should be good
    /// </summary>
    [Parameter, EditorRequired]
    public virtual IEnumerable? Items { get; set; }

    /// <summary>
    ///     This might not be needed, but if the implemented list can display an item however the user wishes, this is the template
    /// </summary>
    [Parameter]
    public virtual RenderFragment<T?>? ItemRenderFragment { get; set; }

    /// <summary>
    ///     If a filter has been provided, this is the string that will be used as the string input to the Func
    ///     Some components might decide to override this and take control of their filters themselves
    /// </summary>
    [Parameter]
    public virtual string FilterString { get; set; } = string.Empty;

    /// <summary>
    ///     This Func provides a custom way to filter using a string to describe any kind of object.
    ///     It can range from a string.Contains to a complex search mode with tags for instance.
    /// </summary>
    [Parameter]
    public Func<T, string, bool>? Filter { get; set; }

    /// <summary>
    ///     An event to subscribe for the click on an element.
    ///     IS a preffered way to handle interaction when you don't want to have to use SelectableItemList and all
    /// </summary>
    [Parameter]
    public virtual EventCallback<T> OnElementClickCallBack { get; set; }


    // UI Methods
    protected virtual string ColorClass => Color.GetCssClass();
}