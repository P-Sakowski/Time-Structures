using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeStructures;

namespace SimpleConsoleApp
{
    class Program
    {
        static void Main()
        {
            try
            {
                Time time1 = new Time("06:29:00");
                Time time2 = new Time(22);
                Time time3 = new Time(22,00);
                Time time4 = new Time(22,00,45);
                TimePeriod timeperiod1 = new TimePeriod(9,45,00);
                TimePeriod timeperiod2 = new TimePeriod(9,45);
                TimePeriod timeperiod3 = new TimePeriod(555);
                TimePeriod timeperiod4 = new TimePeriod("111:22:33");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("-------------------------TEST OBIEKTU TIME-----------------------------------------------------------------------");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Wywołanie metody ToString, obiekt Time, konstruktor z argumentem string: ");
                Console.WriteLine(time1.ToString());
                Console.WriteLine("Wywołanie metody ToString, obiekt Time, konstruktor 3-argumentowy: ");
                Console.WriteLine(time4.ToString());
                Console.WriteLine("Wywołanie metody ToString, obiekt Time, konstruktor 2-argumentowy: ");
                Console.WriteLine(time3.ToString());
                Console.WriteLine("Wywołanie metody ToString, obiekt Time, konstruktor 1-argumentowy: ");
                Console.WriteLine(time2.ToString());
                Console.WriteLine("Porównanie dwóch obiektów tego samego typu (Time) z identycznymi wartościami metodą Equals: ");
                Console.WriteLine($"Arg1: {time3}, Arg2: {time2}, Wynik: {time3.Equals(time2)}");
                Console.WriteLine("Porównanie dwóch obiektów tego samego typu (Time) z różnymi wartościami metodą Equals: ");
                Console.WriteLine($"Arg1: {time3}, Arg2: {time4}, Wynik: {time3.Equals(time4)}");
                Console.WriteLine("Porównanie dwóch obiektów tego samego typu (Time) z identycznymi wartościami operatorem ==: ");
                Console.WriteLine($"Arg1: {time3}, Arg2: {time2}, Wynik: {time3 == time2}");
                Console.WriteLine("Porównanie dwóch obiektów tego samego typu (Time) z różnymi wartościami operatorem ==: ");
                Console.WriteLine($"Arg1: {time3}, Arg2: {time4}, Wynik: {time3 == time4}");
                Console.WriteLine("Porównanie dwóch obiektów tego samego typu (Time) z identycznymi wartościami operatorem !=: ");
                Console.WriteLine($"Arg1: {time3}, Arg2: {time2}, Wynik: {time3 != time2}");
                Console.WriteLine("Porównanie dwóch obiektów tego samego typu (Time) z różnymi wartościami operatorem !=: ");
                Console.WriteLine($"Arg1: {time3}, Arg2: {time4}, Wynik: {time3 != time4}");
                Console.WriteLine("Porównanie dwóch obiektów tego samego typu (Time) z takimi samymi wartościami metodą CompareTo: ");
                Console.WriteLine($"Arg1: {time3}, Arg2: {time2}, Wynik: {time3.CompareTo(time2)}");
                Console.WriteLine("Porównanie dwóch obiektów tego samego typu (Time) z różnymi wartościami metodą CompareTo: ");
                Console.WriteLine($"Arg1: {time3}, Arg2: {time4}, Wynik: {time3.CompareTo(time4)}");
                Console.WriteLine("Porównanie dwóch obiektów tego samego typu (Time) z różnymi wartościami metodą CompareTo: ");
                Console.WriteLine($"Arg1: {time4}, Arg2: {time3}, Wynik: {time4.CompareTo(time3)}");
                Console.WriteLine("Porównanie dwóch obiektów tego samego typu (Time) z różnymi wartościami operatorem <: ");
                Console.WriteLine($"Arg1: {time3}, Arg2: {time4}, Wynik: {time3 < time4}");
                Console.WriteLine("Porównanie dwóch obiektów tego samego typu (Time) z różnymi wartościami operatorem >: ");
                Console.WriteLine($"Arg1: {time3}, Arg2: {time4}, Wynik: {time3 > time4}");
                Console.WriteLine("Porównanie dwóch obiektów tego samego typu (Time) z różnymi wartościami operatorem >=: ");
                Console.WriteLine($"Arg1: {time3}, Arg2: {time4}, Wynik: {time3 >= time4}");
                Console.WriteLine("Porównanie dwóch obiektów tego samego typu (Time) z różnymi wartościami operatorem <=: ");
                Console.WriteLine($"Arg1: {time3}, Arg2: {time4}, Wynik: {time3 <= time4}");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("-------------------------TEST OBIEKTU TIME PERIOD----------------------------------------------------------------");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Wywołanie metody ToString, obiekt TimePeriod, konstruktor z argumentem string: ");
                Console.WriteLine(timeperiod4.ToString());
                Console.WriteLine("Wywołanie metody ToString, obiekt TimePeriod, konstruktor 3-argumentowy: ");
                Console.WriteLine(timeperiod1.ToString());
                Console.WriteLine("Wywołanie metody ToString, obiekt TimePeriod, konstruktor 2-argumentowy: ");
                Console.WriteLine(timeperiod2.ToString());
                Console.WriteLine("Wywołanie metody ToString, obiekt TimePeriod, konstruktor 1-argumentowy: ");
                Console.WriteLine(timeperiod3.ToString());
                Console.WriteLine("Porównanie dwóch obiektów tego samego typu (TimePeriod) z identycznymi wartościami metodą Equals: ");
                Console.WriteLine($"Arg1: {timeperiod1}, Arg2: {timeperiod2}, Wynik: {timeperiod1.Equals(timeperiod2)}");
                Console.WriteLine("Porównanie dwóch obiektów tego samego typu (TimePeriod) z różnymi wartościami metodą Equals: ");
                Console.WriteLine($"Arg1: {timeperiod3}, Arg2: {timeperiod4}, Wynik: {timeperiod3.Equals(timeperiod4)}");
                Console.WriteLine("Porównanie dwóch obiektów tego samego typu (TimePeriod) z identycznymi wartościami operatorem ==: ");
                Console.WriteLine($"Arg1: {timeperiod1}, Arg2: {timeperiod2}, Wynik: {timeperiod1 == timeperiod2}");
                Console.WriteLine("Porównanie dwóch obiektów tego samego typu (TimePeriod) z różnymi wartościami operatorem ==: ");
                Console.WriteLine($"Arg1: {timeperiod3}, Arg2: {timeperiod4}, Wynik: {timeperiod3 == timeperiod4}");
                Console.WriteLine("Porównanie dwóch obiektów tego samego typu (TimePeriod) z identycznymi wartościami operatorem !=: ");
                Console.WriteLine($"Arg1: {timeperiod1}, Arg2: {timeperiod2}, Wynik: {timeperiod1 != timeperiod2}");
                Console.WriteLine("Porównanie dwóch obiektów tego samego typu (TimePeriod) z różnymi wartościami operatorem !=: ");
                Console.WriteLine($"Arg1: {timeperiod3}, Arg2: {timeperiod4}, Wynik: {timeperiod3 != timeperiod4}");
                Console.WriteLine("Porównanie dwóch obiektów tego samego typu (TimePeriod) z takimi samymi wartościami metodą CompareTo: ");
                Console.WriteLine($"Arg1: {timeperiod1}, Arg2: {timeperiod2}, Wynik: {timeperiod1.CompareTo(timeperiod2)}");
                Console.WriteLine("Porównanie dwóch obiektów tego samego typu (TimePeriod) z różnymi wartościami metodą CompareTo: ");
                Console.WriteLine($"Arg1: {timeperiod3}, Arg2: {timeperiod4}, Wynik: {timeperiod3.CompareTo(timeperiod4)}");
                Console.WriteLine("Porównanie dwóch obiektów tego samego typu (TimePeriod) z różnymi wartościami metodą CompareTo: ");
                Console.WriteLine($"Arg1: {timeperiod4}, Arg2: {timeperiod3}, Wynik: {timeperiod4.CompareTo(timeperiod3)}");
                Console.WriteLine("Porównanie dwóch obiektów tego samego typu (TimePeriod) z różnymi wartościami operatorem <: ");
                Console.WriteLine($"Arg1: {timeperiod3}, Arg2: {timeperiod4}, Wynik: {timeperiod3 < timeperiod4}");
                Console.WriteLine("Porównanie dwóch obiektów tego samego typu (TimePeriod) z różnymi wartościami operatorem >: ");
                Console.WriteLine($"Arg1: {timeperiod3}, Arg2: {timeperiod4}, Wynik: {timeperiod3 > timeperiod4}");
                Console.WriteLine("Porównanie dwóch obiektów tego samego typu (TimePeriod) z różnymi wartościami operatorem >=: ");
                Console.WriteLine($"Arg1: {timeperiod3}, Arg2: {timeperiod4}, Wynik: {timeperiod3 >= timeperiod4}");
                Console.WriteLine("Porównanie dwóch obiektów tego samego typu (TimePeriod) z różnymi wartościami operatorem <=: ");
                Console.WriteLine($"Arg1: {timeperiod3}, Arg2: {timeperiod4}, Wynik: {timeperiod3 <= timeperiod4}");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("----------------------------OPERACJE ARYTMETYCZNE----------------------------------------------------------------");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Dodanie obiektu TimePeriod do innego obiektu TimePeriod, metoda Plus: ");
                Console.WriteLine($"Arg1: {timeperiod3}, Arg2: {timeperiod2}, Wynik: {timeperiod3.Plus(timeperiod2)}");
                Console.WriteLine("Dodanie obiektu TimePeriod do innego obiektu TimePeriod, metoda statyczna Plus z dwoma argumentami: ");
                Console.WriteLine($"Arg1: {timeperiod2}, Arg2: {timeperiod3}, Wynik: {TimePeriod.Plus(timeperiod2, timeperiod3)}");
                Console.WriteLine("Dodanie obiektu TimePeriod do innego obiektu TimePeriod, operator +: ");
                Console.WriteLine($"Arg1: {timeperiod3}, Arg2: {timeperiod2}, Wynik: {timeperiod3 + timeperiod2}");
                Console.WriteLine("Odejmowanie obiektu TimePeriod od innego obiektu TimePeriod, operator -, pierwszy obiekt większy: ");
                Console.WriteLine($"Arg1: {timeperiod2}, Arg2: {timeperiod3}, Wynik: {timeperiod2 - timeperiod3}");
                Console.WriteLine("Mnożenie obiektu TimePeriod przez liczbę całkowitą, operator *: ");
                Console.WriteLine($"Arg1: {timeperiod2}, Arg2: 2, Wynik: {timeperiod2 * 2}");
                Console.WriteLine("Dodanie obiektu TimePeriod do obiektu Time, metoda Plus: ");
                Console.WriteLine($"Arg1: {time1}, Arg2: {timeperiod2}, Wynik: {time1.Plus(timeperiod2)}");
                Console.WriteLine("Dodanie obiektu TimePeriod do obiektu Time, metoda statyczna Plus z dwoma argumentami: ");
                Console.WriteLine($"Arg1: {time1}, Arg2: {timeperiod2}, Wynik: {Time.Plus(time1, timeperiod2)}");
                Console.WriteLine("Dodanie obiektu TimePeriod do obiektu Time, operator +: ");
                Console.WriteLine($"Arg1: {time1}, Arg2: {timeperiod2}, Wynik: {time1 + timeperiod2}");
                _ = Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(value: ex.Message);
                _ = Console.ReadKey();
            }
        }
    }
}
