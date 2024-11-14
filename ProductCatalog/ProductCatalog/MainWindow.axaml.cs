using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using System;
using System.IO;
using System.Linq;

namespace ProductCatalog
{
    public partial class MainWindow : Window
    {
        private class Produkt
        {
            public string Nazwa { get; set; }
            public decimal Cena { get; set; }
            public bool Dostepnosc { get; set; }
            public string Kategoria { get; set; }
            public string ImagePath { get; set; }
        }
        
        private readonly Produkt[] produkty = new Produkt[]
        {
            new Produkt { Nazwa = "Monitor", Cena = 700m, Dostepnosc = false, Kategoria = "Elektronika", ImagePath = "monitor.png" },
            new Produkt { Nazwa = "Kawa", Cena = 4, Dostepnosc = true, Kategoria = "Picie", ImagePath = "kawa.png" },
            new Produkt { Nazwa = "Kebab", Cena = 16m, Dostepnosc = true, Kategoria = "Jedzenie", ImagePath = "kebab.png" }
        };

        private Produkt aktualnyProdukt; 

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object? sender, RoutedEventArgs e)
        {
            string szukanaNazwa = InputTextBox.Text.ToLower();
            aktualnyProdukt = produkty.FirstOrDefault(p => p.Nazwa.ToLower().Contains(szukanaNazwa));

            AktualizujWyswietlanie();
        }

        private void AktualizujWyswietlanie()
        {
            if (aktualnyProdukt != null)
            {
                ShowTextBlock.Text = $"Nazwa: {aktualnyProdukt.Nazwa}\nCena: {aktualnyProdukt.Cena} PLN\nDostępność: {(aktualnyProdukt.Dostepnosc ? "Dostępny" : "Niedostępny")}\nKategoria: {aktualnyProdukt.Kategoria}";

                
                string imagePath = Path.Combine(AppContext.BaseDirectory, aktualnyProdukt.ImagePath);
                if (File.Exists(imagePath))
                {
                    ProductImage.Source = new Bitmap(imagePath);
                }
                else
                {
                    ProductImage.Source = null;
                }

                ZmienDostepnoscButton.IsVisible = true; 
            }
            else
            {
                ShowTextBlock.Text = "Produkt nie znaleziony";
                ProductImage.Source = null;
                ZmienDostepnoscButton.IsVisible = false;
            }
        }

        private void ZmienDostepnosc_Click(object? sender, RoutedEventArgs e)
        {
            if (aktualnyProdukt != null)
            {
                aktualnyProdukt.Dostepnosc = !aktualnyProdukt.Dostepnosc;
                AktualizujWyswietlanie();
            }
        }
    }
}
