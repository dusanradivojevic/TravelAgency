﻿using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class UnesiNovuDestinaciju : OpstaSO
    {
        public Destinacija Destinacija { get; set; }
        protected override void IzvrsiKonkretnuOperaciju(IDomenskiObjekat objekat)
        {
            object rezultat = broker.VratiNajveciID(objekat);
            if (rezultat is DBNull)
            {
                throw new Exception($"{objekat.NazivTabele} ne postoji!");
            }
            int noviID = (int)rezultat + 1;
            ((Destinacija)objekat).DestinacijaID = noviID;
            int brojRedova = broker.Sacuvaj(objekat);
            if (brojRedova == 1)
            {
                Destinacija = objekat as Destinacija;
            }
            else
            {
                Destinacija = null;
                throw new Exception("Sistem ne moze da zapamti novi aranzman!");
            }
        }

        protected override void Validacija(IDomenskiObjekat objekat)
        {
            //mora da se proveri da li vec postoji takva destinacija u bazi
            //(slicno i za ostale insert SO
            // !
        }
    }
}