using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using calx.Models;
namespace calx.ViewModels
{
    public class TransmisionsAndStylesCar
    {
        public IEnumerable<Transmission> Transmissions { get; set; }
        public IEnumerable<CarStyle> CarStyles { get; set; }

        public Car Car { get; set; }
    }
}