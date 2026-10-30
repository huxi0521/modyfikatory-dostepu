using System;

namespace SystemZarzadzaniaPracownikami
{
    // 1. Klasa Pracownik
    public class Pracownik
    {
        //  pole przechowujące wynagrodzenie 
        private decimal wynagrodzenie;

        protected string imie;

        
        internal string dzial;

        // Konstruktor przyjmujący imię dział i wynagrodzenie
        public Pracownik(string imie, string dzial, decimal wynagrodzenie)
        {
            this.imie = imie;
            this.dzial = dzial;
            ZmienWynagrodzenie(wynagrodzenie); 
        }

        //  metoda wyświetlająca informacje o pracowniku
        public virtual void PokazDane()
        {
            Console.WriteLine($"Pracownik: {imie} | Dział: {dzial} | Wynagrodzenie: {wynagrodzenie:C}");
        }

        //  metoda pozwalająca zmienić wynagrodzenie
        public void ZmienWynagrodzenie(decimal kwota)
        {
            if (kwota > 0)
            {
                wynagrodzenie = kwota;
            }
            else
            {
                Console.WriteLine($"[Błąd] Wynagrodzenie dla {imie} musi być większe od zera!");
            }
        }
    }

    // 2. Klasa Kierownik dziedzicząca po klasie Pracownik
    public class Kierownik : Pracownik
    {
        public Kierownik(string imie, string dzial, decimal wynagrodzenie)
            : base(imie, dzial, wynagrodzenie)
        {
        }

        // Publiczna metoda korzystająca z pola 'protected imie' dziedziczonego z klasy bazowej
        public void PrzedstawSie()
        {
            Console.WriteLine($"Dzień dobry! Jestem kierownikiem, nazywam się {imie} i zarządzam działem: {dzial}.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Konsole obsługująca polskie znaki
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // obiekt klasy Pracownik
            Pracownik pracownik = new Pracownik("Jan Kowalski", "Logistyka", 4500m);

            // obiekt klasy kierownik
            Kierownik kierownik = new Kierownik("Anna Nowak", "IT", 9500m);

            Console.WriteLine("--- Wyświetlanie danych początkowych ---");
            pracownik.PokazDane();
            kierownik.PokazDane();
            Console.WriteLine();

            kierownik.PrzedstawSie();
            Console.WriteLine();

         
            Console.WriteLine("--- Zmiana wynagrodzenia metodą publiczną ---");
            pracownik.ZmienWynagrodzenie(5200m);
            pracownik.PokazDane();
            Console.WriteLine();

            
            Console.WriteLine("--- Działanie modyfikatora internal ---");
            Console.WriteLine($"Odczytany dział pracownika (pole internal): {pracownik.dzial}");

            pracownik.dzial = "Rozwój Oprogramowania";
            Console.WriteLine($"Dział po bezpośredniej zmianie w Main: {pracownik.dzial}");

            Console.WriteLine("\nNaciśnij dowolny klawisz, aby zakończyć program...");
            Console.ReadKey();
        }
    }
}