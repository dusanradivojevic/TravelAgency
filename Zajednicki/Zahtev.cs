﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zajednicki
{
    public enum Operacija
    {
        KreirajPutnika,
        ObrisiAranzman,
        ObrisiDestinaciju,
        ObrisiPutnika,
        PrijaviMe,
        VratiSveAranzmane,
        UnesiNoviAranzman,
        UnesiNovuDestinaciju,
        SacuvajAranzmanSlozen,
        VratiFiltrirano,
        VratiPodatkeAranzmana,
        VratiSve
    }
    
    [Serializable]
    public class Zahtev
    {
        public Operacija Operacija { get; set; }
        public object Objekat { get; set; }
    }
}
