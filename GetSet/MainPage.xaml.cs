using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using Xamarin.Forms;

namespace GetSet
{
    public partial class MainPage : ContentPage
    {
        string coWybrac = "nazwa";
        class Kontakt
        {
            public string nazwa { get; set; }
            public string numer { get; set; }
            public string email { get; set; }

            public Kontakt(string _nazwa, string numer, string _email)
            {
                nazwa = _nazwa;
                this.numer = numer;
                email = _email;
            }
        }
        public MainPage()
        {
            InitializeComponent();
            kontakty.Add(new Kontakt("Szybki Tomek", "123456789","szybki.tomek@dbd.com"));
            kontakty.Add(new Kontakt("Wolny Maciek", "987654321", "wolny.maciek@valorant.eu"));
            kontakty.Add(new Kontakt("Klopoty", "997", "klopoty.niedzwon@nigdy.pl"));
        }
        List<Kontakt> kontakty = new List<Kontakt>();
        private void Pokaz(object sender, EventArgs e)
        {
            string[] wpisy = new string[kontakty.Count];
            for(int i = 0; i < kontakty.Count; i++)
            {
                if(coWybrac=="nazwa")
                    wpisy[i] = kontakty[i].nazwa;
                else if(coWybrac == "numer")
                    wpisy[i] = kontakty[i].numer;
                else if(coWybrac == "mail")
                    wpisy[i] = kontakty[i].email;
            }
            lista.ItemsSource = wpisy;
        }
        private void Dodaj(object sender, EventArgs e)
        {
            string imie = name.Text;
            string telefon = phone.Text;
            string adres = mail.Text;
            
            void Czyszczenie()
            {
                name.Text = "";
                phone.Text = "";
                mail.Text = "";
            }

            kontakty.Add(new Kontakt(imie, telefon, adres));
            List<string> dodano = new List<string>();
            if (kontakty[kontakty.Count - 1].nazwa == "" && kontakty[kontakty.Count - 1].numer == "" && kontakty[kontakty.Count - 1].email == "")
            {
                dodano.Add("Nie mozna dodac pustego wpisu");
                string[] wyswietl = new string[dodano.Count];
                for (int i = 0; i < dodano.Count; i++)
                {
                    wyswietl[i] = dodano[i];
                }
                lista.ItemsSource = wyswietl;
                kontakty.RemoveAt(kontakty.Count - 1);
            }
            else
            {
                dodano.Add("Dodano:");
                dodano.Add($"Imie: {imie}");
                dodano.Add($"Telefon: {telefon}");
                dodano.Add($"E-mail: {adres}");

                string[] wyswietl = new string[dodano.Count];
                for (int i = 0; i < dodano.Count; i++)
                {
                    wyswietl[i] = dodano[i];
                }
                lista.ItemsSource = wyswietl;
            }
            Czyszczenie();
        }
            
        private void Nazwa(object sender, EventArgs e)
        {
            coWybrac = "nazwa";
            przeslij.Text = "POKAZ WPISY: nazwa";
        }
        private void Numer(object sender, EventArgs e) 
        { 
            coWybrac = "numer";
            przeslij.Text = "POKAZ WPISY: numer";
        }
        private void Mail(object sender, EventArgs e)
        {
            coWybrac = "mail";
            przeslij.Text = "POKAZ WPISY: e-mail";
        }
    }
}