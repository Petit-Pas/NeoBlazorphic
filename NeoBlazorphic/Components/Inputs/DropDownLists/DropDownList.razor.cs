﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using NeoBlazorphic.Models.SelectableItems;
using NeoBlazorphic.StyleParameters;
using NeoBlazorphic.UserInteraction.Mouse.BaseComponents;


namespace NeoBlazorphic.Components.Inputs.DropDownLists
{
	public partial class DropDownList<T> : MouseInteractiveBaseComponent
    {
        [Parameter, EditorRequired]
        public SelectableItemList<T> Items { get; set; } = SelectableItemList<T>.Empty;
        private bool _isHovered = false;
        private bool _isClicked = false;

        private string shadowStyle { get; set; } = "shadow-neo-out";
        private string shapeStyle { get; set; } = "flat";

        protected string SelectedThemeString
        {
            get => _selectedThemeString;
            set
            {
                if (_selectedThemeString != value) {
                    _selectedThemeString = value;
                }
            }
        }
        private string _selectedThemeString = "gray";
        //onfocus=@onMouseFocus()

        [Parameter]
        public BackgroundShape Shape
        {
            get => _shape;
            set
            {
                if (_shape != value) {
                    SetNewShapeStyle(value);
                    _shape = value;
                }
            }
        }
        private BackgroundShape _shape { get; set; } = BackgroundShape.Flat;
        private ShadowPosition _shadowPlacement { get; set; } = ShadowPosition.Out;
        private void SetNewShadowStyle(ShadowPosition newShadow)
        {
            switch (newShadow) {
                case ShadowPosition.Out:
                    shadowStyle = "shadow-neo-out";
                    break;
                case ShadowPosition.In:
                    shadowStyle = "shadow-neo-in";
                    break;
                default:
                    ShadowPosition = ShadowPosition.Out;
                    break;
            }
            StateHasChanged();
        }
        private void SetNewShapeStyle(BackgroundShape newShape)
        {
            switch (newShape) {
                case BackgroundShape.Convex:
                    shapeStyle = "convex";
                    break;
                case BackgroundShape.Concave:
                    shapeStyle = "concave";
                    break;
                case BackgroundShape.Flat:
                    shapeStyle = "flat";
                    break;
                default:
                    Shape = BackgroundShape.Flat;
                    break;
            }
            StateHasChanged();
        }

        [Parameter]
        public ShadowPosition ShadowPosition
        {
            get => _shadowPlacement;
            set
            {
                if (_shadowPlacement != value) {
                    SetNewShadowStyle(value);
                    _shadowPlacement = value;
                }
            }
        }
        protected override async Task OnMouseOver(MouseEventArgs args)
        {
            _isHovered = true;
            Shape = BackgroundShape.Concave;
            await base.OnMouseOver(args);
        }

        protected override async Task OnMouseOut(MouseEventArgs args)
        {
            _isHovered = false;
            if (_isClicked == false)
            {
                Shape = BackgroundShape.Flat;
                await base.OnMouseOut(args);
            }
            
        }
        public void OnChange(ChangeEventArgs e)
        {
            _selectedThemeString = e.Value.ToString();
        }
    }
}