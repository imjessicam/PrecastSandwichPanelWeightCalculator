using Microsoft.AspNetCore.Mvc;
using PanelWeight.Models;

namespace PanelWeight.Controllers
{
    [ApiController]
    [Route("Panel weight")]
    public class PanelWeightController : Controller
    {
        [HttpPost]
        [Route("weight calculator")]
        public IActionResult CalculateWeight([FromBody] PanelWeightResultsDetails model)
        {

            var result = new PanelWeightResultsDetails();

            result.Project = model.Project;
            result.Panel = model.Panel;
            result.Windows = new List<Window>();
            result.Insulations = new List<Insulation>();
            result.FacadeLayers = new List<FacadeLayer>();


            // MATERIAL DENISTY

            const decimal ConcereteDensity = 25M;
            const decimal GlassDensity = 0.7M;
            const decimal MineralWoolDensity = 0.6M;
            const decimal ClinkerBrickDensity = 20M;

            // PANEL WEIGHT

            result.PanelArea = result.Panel.PanelLenght * result.Panel.PanelHeight;
            result.PanelVolume = result.PanelArea * result.Panel.PanelWidth;
            result.PanelWeight = result.PanelVolume * ConcereteDensity;

            // WINDOWS WEIGHT 

            foreach (var window  in model.Windows) 
            {
                var windowData = new Window();

                windowData.Name = window.Name;
                windowData.Amount = window.Amount;
                windowData.WindowHeight = window.WindowHeight;
                windowData.WindowWidth = window.WindowWidth;

                window.SingleWindowArea = window.WindowWidth * window.WindowHeight;
                window.OneTypeWindowArea = window.SingleWindowArea * window.Amount;

                windowData.SingleWindowArea = window.SingleWindowArea;
                windowData.OneTypeWindowArea = window.OneTypeWindowArea;

                result.Windows.Add(windowData);
            }

            result.WindowsArea = result.Windows.Select(x => x.OneTypeWindowArea).Sum();
            result.WindowsWeightTotal = result.WindowsArea * GlassDensity;


            // INSULATION

            foreach (var insulation in model.Insulations) 
            { 
                var insulationData = new Insulation();

                insulationData.Name = insulation.Name;
                insulationData.InsulationWidth = insulation.InsulationWidth;

                result.Insulations.Add(insulationData);
            }

            result.InsulationWidthTotal = result.Insulations.Select(x => x.InsulationWidth).Sum();
            result.InsulationArea = result.PanelArea - result.WindowsArea;
            result.InsulationVolumeTotal = result.InsulationArea * result.Insulations.Select(x => x.InsulationWidth).Sum();
            result.InsulationWeightTotal = result.InsulationVolumeTotal * MineralWoolDensity;


            //// FACADE

            //foreach(var layer in model.FacadeLayers) 
            //{
            //    var layerData = new FacadeLayer();

            //    layerData.Name = layer.Name;
            //    layerData.LayerWidth = layer.LayerWidth;

            //    result.FacadeLayers.Add(layerData);
            //}

            //result.


            return Ok(result);
        }

    }
}
