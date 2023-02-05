using Microsoft.AspNetCore.Authorization;
using NeoBlazorphic.Extensions.BaseTypes;

namespace NeoBlazorphic.StyleParameters
{
    public class BorderRadius
    {
        public static readonly BorderRadius Default = new (3, "em");

        private readonly double[] _bordersPixels;
        private readonly string _unit;

        // These constructors mirror the different ways border-radius css property can be populated
        public BorderRadius(double tl, double tr, double bl, double br, string unit = "px")
        {
            _bordersPixels = new [] { tl, tr, bl, br };
            _unit = unit;
        }

        public BorderRadius(double tl, double diagonal, double br, string unit = "px")
        {
            _bordersPixels = new[] { tl, diagonal, br, diagonal };
            _unit = unit;
        }

        public BorderRadius(double first, double second, string unit = "px")
        {
            _bordersPixels = new[] { first, second, first, second };
            _unit = unit;
        }

        public BorderRadius(double value, string unit = "px")
        {
            _bordersPixels = new[] { value, value, value, value };
            _unit = unit;
        }

        public string GetCssProperty()
        {
            return "border-radius: " +
                   $"{_bordersPixels[0].ToInvariantString()}{_unit} " +
                   $"{_bordersPixels[1].ToInvariantString()}{_unit} " +
                   $"{_bordersPixels[2].ToInvariantString()}{_unit} " +
                   $"{_bordersPixels[3].ToInvariantString()}{_unit};";
        }
    }
}
