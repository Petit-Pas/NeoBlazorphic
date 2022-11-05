using Microsoft.AspNetCore.Components;

namespace NeoBlazorphic.Components
{
    /// <summary>
    ///     This class is intended to contain what is going to be shared among any possible blazor component
    /// </summary>
    public abstract class UiComponentBase : ComponentBase
    {
        protected int UID { get; set; } = Random.Shared.Next();
    }
}
