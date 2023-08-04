namespace PanelWeight.Models
{
    public class PanelWeightResultsDetails
    {
        public Project Project { get; set; }
        public Panel Panel { get; set; }
        public List<Window> Windows { get; set; }
        public List<Insulation> Insulations { get; set; }
        public List<FacadeLayer> FacadeLayers { get; set; }


        // PANEL - Structural element

        // [m2] - Entire panel surface area
        public decimal PanelArea { get; set; }
        // [m3] - Entire panel volume
        public decimal PanelVolume { get; set; }
        // [kN] - Entire panel weight (structural element)
        public decimal PanelWeight { get; set; }


        // WINDOWS

        //[m2] - Surface area of all windows
        public decimal WindowsArea { get; set; }
        //[kN] - Weight of all windows
        public decimal WindowsWeightTotal { get; set; }


        // INSULATION

        // [m] - Total width of the insulation
        public decimal InsulationWidthTotal { get; set; }

        // [m2] - Surface area of insulation (excluding windows area)
        public decimal InsulationArea { get; set; }

        // [m3] - Volume of insulation (excluding windows area)
        public decimal InsulationVolumeTotal { get; set; }

        // [kN] - Weight of insulation (excluding windows surface are from panel surface area)
        public decimal InsulationWeightTotal { get; set; }


        // FACADE

        // [m2]
        public decimal FacadeArea { get; set; }
        // [m3]
        public decimal FacadeVolumeTotal { get; set; }
        // [kN]
        public decimal FacadeWeightTotal { get; set; }

        // TOTAL WEIGHT
        // [kN]
        //public decimal PanelWeightTotalKN { get; set; }
        //public decimal PanelWeightTotalT {get; set; }
        public bool IsPanelWeightCorrect { get; set; }
    }
}
