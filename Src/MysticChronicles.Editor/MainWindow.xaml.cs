using System.Collections.Generic;
using System.Windows;

using MysticChronicles.PCL.Transports.SolarSystem;

using Newtonsoft.Json;

namespace MysticChronicles.Editor {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            var mapDefinition = new List<SolarSystemMapDefinitionResponseItem> {
                new SolarSystemMapDefinitionResponseItem {
                    XCoordinate = 0,
                    TextureName = "Bases/Mega",
                    YCoorindate = 0
                },
                new SolarSystemMapDefinitionResponseItem {
                    XCoordinate = 0,
                    TextureName = "Planets/GreyExplode",
                    YCoorindate = 2
                },
                new SolarSystemMapDefinitionResponseItem {
                    XCoordinate = 2,
                    TextureName = "Planets/GreyExplode",
                    YCoorindate = 3
                }
            };

            tbMain.Text = JsonConvert.SerializeObject(mapDefinition);
        }
    }
}