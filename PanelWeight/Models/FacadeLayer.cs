namespace PanelWeight.Models
{
    public class FacadeLayer
    {
        public string Name { get; set; }

        // [m2] - FacadeLayer Area = Panel surface area (excluding windows/holes)
        public decimal Area { get; set; }

        // [m] - Layer width
        public decimal LayerWidth { get; set; }

        public string Material { get; set; }

        public decimal MaterialDensity { get; set; }
    }
}
