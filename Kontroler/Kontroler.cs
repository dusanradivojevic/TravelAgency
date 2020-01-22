﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;
using BrokerBazePodataka;
using SistemskeOperacije;

namespace Kontroler
{
    public class Kontroler
    {
        private Broker broker;
        private static Kontroler _instance;
        public static Kontroler Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Kontroler();
                }

                return _instance;
            }
        }

        public List<Zemlja> VratiSveZemlje()
        {
            Zemlja z = new Zemlja();
            OpstaSO os = new VratiSve();
            try
            {
                os.IzvrsiSO(z);
                List<Zemlja> lista = ((VratiSve)os).lista.Cast<Zemlja>().ToList();
                return lista;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Zemlja>();
            }
        }

        public bool UnesiNovuDestinaciju(string grad, Zemlja zemlja, Korisnik korisnik)
        {
            Destinacija d = new Destinacija
            {
                NazivGrada = grad,
                Zemlja = zemlja,
                Korisnik = korisnik
            };

            OpstaSO os = new UnesiNovuDestinaciju();
            try
            {
                os.IzvrsiSO(d);
            }
            catch
            {
                return false;
            }
            if (((UnesiNovuDestinaciju)os).Destinacija != null)
                return true;
            else
                return false;
        }

        public List<Putnik> VratiSvePutnike()
        {
            Putnik p = new Putnik();
            OpstaSO os = new VratiSve();
            try
            {
                os.IzvrsiSO(p);
                List<Putnik> lista = ((VratiSve)os).lista.Cast<Putnik>().ToList();
                return lista;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Putnik>();
            }
        }

        public Putnik KreirajPutnika(string jmbg, string ime, string prezime, DateTime datum, 
            Korisnik korisnik)
        {
            Putnik p = new Putnik
            {
                JMBG = jmbg,
                Ime = ime,
                Prezime = prezime,
                DatumDodavanja = datum,
                Korisnik = korisnik
            };

            OpstaSO os = new KreirajPutnika();
            try
            {
                os.IzvrsiSO(p);
            }
            catch
            {
                return null;
            }
            
            return ((KreirajPutnika)os).Putnik;
        }    

        public List<Destinacija> VratiSveDestinacije() //ovde metode mogu da vracaju i object
        {
            Destinacija d = new Destinacija();
            OpstaSO os = new VratiSve();
            try
            {
                os.IzvrsiSO(d);
                List<Destinacija> lista = ((VratiSve)os).lista.Cast<Destinacija>().ToList();
                return lista;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Destinacija>();
            }
        }

        public bool ObrisiPutnika(Putnik p)
        {
            OpstaSO os = new ObrisiPutnika();
            try
            {
                os.IzvrsiSO(p);
            }
            catch
            {
                return false;
            }

            return ((ObrisiPutnika)os).Obrisan;
        }

        private Kontroler()
        {
            broker = new Broker();
        }

        public List<Aranzman> VratiSveAranzmane()
        {
            Aranzman a = new Aranzman();
            OpstaSO os = new VratiSve();
            try
            {
                os.IzvrsiSO(a);
                List<Aranzman> lista = ((VratiSve)os).lista.Cast<Aranzman>().ToList();
                return lista;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Aranzman>();
            }
        }        

        public Korisnik Prijava(string email, string pw)
        {
            Korisnik k = new Korisnik();
            k.Email = email;
            k.Sifra = pw;
            OpstaSO os = new PrijaviMe();
            try
            {
                os.IzvrsiSO(k);
                return ((PrijaviMe)os).Korisnik;
            }
            catch
            {
                return null;   // U bazi ne postoji korisnik sa unetim mejlom i sifrom
            }
        }
        public bool UnesiNoviAranzman(string naziv, string opis, double cena,
            DateTime datum, int ukBrMesta, int brPutnika, int brSlbMesta,
            Destinacija destinacija, Korisnik korisnik)
        {
            Aranzman a = new Aranzman
            {
                NazivAranzmana = naziv,
                OpisAranzmana = opis,
                Cena = cena,
                Datum = datum,
                UkupanBrMesta = ukBrMesta,
                BrojPutnika = brPutnika,
                BrSlobodnihMesta = brSlbMesta,
                Destinacija = destinacija,
                Korisnik = korisnik
            };

            OpstaSO os = new UnesiNoviAranzman();
            try
            {
                os.IzvrsiSO(a);
            }
            catch
            {
                return false;
            }
            if (((UnesiNoviAranzman)os).Aranzman != null)
                return true;
            else
                return false;
        }
    }
}
