using System.Collections;
using Microsoft.AspNetCore.Components;
using NeoBlazorphic.Models.SelectableItems;
using NeoBlazorphic.StyleParameters;

namespace NeoBlazorphic.Components.Lists.CardsLists;

public partial class CardsList<T>
{
    [Parameter, EditorRequired]
    public IEnumerable? Items { get; set; }

    [Parameter]
    public RenderFragment<T>? ItemRenderFragment { get; set; }

    [Parameter]
    public RenderFragment? FooterRenderFragment { get; set; }

    [Parameter]
    public RenderFragment? HeaderRenderFragment { get; set; }

    [Parameter]
    public BorderRadius BorderRadius { get; set; } = BorderRadius.Default;
    
    [Parameter]
    public Func<T, string, bool>? Filter { get; set; }

    [Parameter]
    public string? FilterString { get; set; }

    /// <summary>
    ///     This is only used for the cards of selected elements when Items is an ISelectableItemList
    /// </summary>
    [Parameter]
    public ThemeColor AccentClass { get; set; } = ThemeColor.Primary;


    // UI Methods
    protected virtual string AdditionalClasses => Items is ISelectableItemList ? "neo-concave-on-hover" : "";
}