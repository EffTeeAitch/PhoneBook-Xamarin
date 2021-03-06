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
        string whatToPick = "name";
        class Contact
        {
            public string name { get; set; }
            public string number { get; set; }
            public string email { get; set; }

            public Contact(string _name, string _number, string _email)
            {
                name = _name;
                number = _number;
                email = _email;
            }
        }
        public MainPage()
        {
            InitializeComponent();
            contacts.Add(new Contact("Szybki Tomek", "123456789","szybki.tomek@dbd.com"));
            contacts.Add(new Contact("Wolny Maciek", "987654321", "wolny.maciek@valorant.eu"));
            contacts.Add(new Contact("Klopoty", "997", "klopoty.niedzwon@nigdy.pl"));
        }
        List<Contact> contacts = new List<Contact>();
        private void Show(object sender, EventArgs e)
        {
            string[] data = new string[contacts.Count];
            for(int i = 0; i < contacts.Count; i++)
            {
                if(whatToPick=="name")
                    data[i] = contacts[i].name;
                else if(whatToPick == "number")
                    data[i] = contacts[i].number;
                else if(whatToPick == "email")
                    data[i] = contacts[i].email;
            }
            list.ItemsSource = data;
        }
        private void Add(object sender, EventArgs e)
        {
            string nameUser = name.Text;
            string phoneNumber = phone.Text;
            string adress = mail.Text;
            
            void Clear()
            {
                name.Text = "";
                phone.Text = "";
                mail.Text = "";
            }

            contacts.Add(new Contact(nameUser, phoneNumber, adress));
            List<string> added = new List<string>();
            if (contacts[contacts.Count - 1].name == "" && contacts[contacts.Count - 1].number == "" && contacts[contacts.Count - 1].email == "")
            {
                added.Add("You can not insert empty record");
                string[] show = new string[added.Count];
                for (int i = 0; i < added.Count; i++)
                {
                    show[i] = added[i];
                }
                list.ItemsSource = show;
                contacts.RemoveAt(contacts.Count - 1);
            }
            else
            {
                added.Add("Added:");
                added.Add($"Name: {nameUser}");
                added.Add($"Phone number: {phoneNumber}");
                added.Add($"E-mail adress: {adress}");

                string[] show = new string[added.Count];
                for (int i = 0; i < added.Count; i++)
                {
                    show[i] = added[i];
                }
                list.ItemsSource = show;
            }
            Clear();
        }
            
        private void Name(object sender, EventArgs e)
        {
            whatToPick = "name";
            send.Text = "DISPLAY RECORDS: name";
        }
        private void Number(object sender, EventArgs e) 
        { 
            whatToPick = "number";
            send.Text = "DISPLAY RECORDS: number";
        }
        private void Mail(object sender, EventArgs e)
        {
            whatToPick = "email";
            send.Text = "DISPLAY RECORDS: e-mail";
        }
    }
}