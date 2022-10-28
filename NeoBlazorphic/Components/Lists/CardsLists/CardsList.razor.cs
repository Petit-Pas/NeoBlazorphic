using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop.Infrastructure;


namespace NeoBlazorphic.Components.Lists.CardsLists
{
    public partial class CardsList<T>
    {

        [Parameter, EditorRequired]
        public List<T>? Items { get; set; }

        [Parameter]
        public RenderFragment<T>? ItemRenderFragment { get; set; }

        [Parameter]
        public Func<T, string, bool>? Filter { get; set; }

        public string? SearchBarQuery
        {
            get => _searchBarQuery;
            set => _searchBarQuery = value;
        }
        private string? _searchBarQuery = "";

        private IEnumerable<T>? DisplayableItems()
        {
            if (Filter == null || string.IsNullOrEmpty(SearchBarQuery))
            {
                return Items;
            }

            return Items?.Where(x => Filter(x, SearchBarQuery));
        }
    }
}
