using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeStructures
{
    public readonly struct TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
    {
        /// <summary>
        /// Łączna suma sekund konkretnego odstępu czasowego - podstawowy sposób wewnętrznego opisania obiektu
        /// </summary>
        public readonly long totalSeconds;
        /// <summary>
        /// Konstruktor 3-argumentowy
        /// </summary>
        /// <param name="hours"> liczba typu byte, nie mniejsza niż 0, odpowiada liczbie godzin </param>
        /// <param name="minutes"> liczba typu byte z przedziału 0-59, odpowiada liczbie minut </param>
        /// <param name="seconds"> liczba typu byte z przedziału 0-59, odpowiada liczbie sekund </param>
        public TimePeriod(byte hours, byte minutes, byte seconds)
        {
            if (hours < 0)
                throw new ArgumentOutOfRangeException("Ilość godzin nie może być ujemna! Podaj prawidłową ilość godzin.");
            else if (minutes > 59 || minutes < 0)
                throw new ArgumentOutOfRangeException("Nieprawidłowa ilość minut! Podaj ilość minut z przedziału 0-59.");
            else if (seconds > 59 || seconds < 0)
                throw new ArgumentOutOfRangeException("Nieprawidłowa ilość sekund! Podaj ilość sekund z przedziału 0-59.");
            else
                totalSeconds = seconds + 60 * minutes + 3600 * hours;
        }
        /// <summary>
        /// Konstruktor 2-argumentowy
        /// </summary> 
        /// <param name="hours"> liczba typu byte, nie mniejsza niż 0, odpowiada liczbie godzin </param>
        /// <param name="minutes"> liczba typu byte z przedziału 0-59, odpowiada liczbie minut </param>
        public TimePeriod(byte hours, byte minutes)
        {
            if (hours < 0)
                throw new ArgumentOutOfRangeException("Ilość godzin nie może być ujemna! Podaj prawidłową ilość godzin.");
            else if (minutes > 59 || minutes < 0)
                throw new ArgumentOutOfRangeException("Nieprawidłowa ilość minut! Podaj ilość minut z przedziału 0-59.");
            else
                totalSeconds = 60 * minutes + 3600 * hours;
        }
        /// <summary>
        /// Konstruktor 1-argumentowy
        /// </summary>
        /// <param name="seconds"> Liczba typu long określająca całkowitą liczbę sekund w danym odcinku czasu </param>
        public TimePeriod(long seconds)
        {
            if (seconds < 0)
                throw new ArgumentOutOfRangeException("Ilość sekund nie może być ujemna! Podaj prawidłową ilość sekund.");
            else
                totalSeconds = seconds;
        }
        /// <summary>
        /// Konstruktor 1-argumentowy, wersja string
        /// </summary>
        /// <param name="time"> łańcuch znaków, conajmniej 8-znakowy, w formacie hh:mm:ss </param>
        public TimePeriod(string time)
        {
            totalSeconds = 0;
            if (time.Length < 8)
                throw new ArgumentException("Nieprawidłowy format daty! Podaj datę w formie hh:mm:ss");
            else
            {
                string[] tab = time.Split(':');
                if ((byte.TryParse(tab[0], out _) == false) || (byte.TryParse(tab[1], out _) == false) || (byte.TryParse(tab[2], out _) == false))
                    throw new ArgumentException("Nieprawidłowy format daty! Używaj wyłącznie cyfr w formacie hh:mm:ss");
                if (byte.Parse(tab[0]) < 0)
                    throw new ArgumentOutOfRangeException("Nieprawidłowa godzina! Podaj godzinę z przedziału 0-23.");
                else
                    totalSeconds += 3600 * byte.Parse(tab[0]);
                if (byte.Parse(tab[1]) > 59 || byte.Parse(tab[1]) < 0)
                    throw new ArgumentOutOfRangeException("Nieprawidłowa minuta! Podaj minutę z przedziału 0-59.");
                else
                    totalSeconds += 60 * byte.Parse(tab[1]);
                if (byte.Parse(tab[2]) > 59 || byte.Parse(tab[2]) < 0)
                    throw new ArgumentOutOfRangeException("Nieprawidłowa sekunda! Podaj sekundę z przedziału 0-59.");
                else
                    totalSeconds += byte.Parse(tab[2]);
            }
        }
        /// <summary>
        /// Przeciążenie tekstowej metody przedstawienia obiektu
        /// </summary>
        /// <returns> String w formacie hh:mm:ss </returns>
        public override string ToString()
        {
            string hOut;
            string mOut;
            string sOut;
            if ((totalSeconds / 3600).ToString().Length == 1)
                hOut = "0" + totalSeconds / 3600;
            else
                hOut = (totalSeconds / 3600).ToString();
            if (((totalSeconds / 60) % 60).ToString().Length == 1)
                mOut = "0" + (totalSeconds / 60) % 60;
            else
                mOut = ((totalSeconds / 60) % 60).ToString();
            if ((totalSeconds - (totalSeconds / 3600) * 60 * 60 - ((totalSeconds / 60) % 60) * 60).ToString().Length == 1)
                sOut = "0" + (totalSeconds - (totalSeconds / 3600) * 60 * 60 - ((totalSeconds / 60) % 60) * 60);
            else
                sOut = (totalSeconds - (totalSeconds / 3600) * 60 * 60 - ((totalSeconds / 60) % 60) * 60).ToString();
            return hOut + ":" + mOut + ":" + sOut;
        }
        /// <summary>
        /// Implementacja interfejsu IEquatable
        /// </summary>
        /// <param name="obj"> Dowolny obiekt typu TimePeriod</param>
        /// <returns>True jeśli obiekty są równe, w przeciwnym wypadku False</returns>
        public bool Equals(TimePeriod other)
        {
            if (this.totalSeconds == other.totalSeconds)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Implementacja interfejsu IEquatable
        /// </summary>
        /// <param name="obj">Dowolny obiekt</param>
        /// <returns>Fałsz, gdy obiekt nie jest typu TimePeriod. Jeśli jest - zwraca wynik sprawdzenia równości.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else if (obj is TimePeriod != true)
                return false;
            return base.Equals((TimePeriod)obj);
        }
        /// <summary>
        /// Implementacja interfejsu IEquatable
        /// </summary>
        /// <returns> Hash obiektu typu TimePeriod</returns>
        public override int GetHashCode() => totalSeconds.GetHashCode();
        /// <summary>
        /// Implementacja interfejsu IComparable
        /// </summary>
        /// <param name="other"> Inny, dowolny obiekt typu TimePeriod</param>
        /// <returns> 1, gdy pierwszy obiekt jest większy, 0 gdy jest równy, -1 gdy jest mniejszy od obiektu drugiego</returns>
        public int CompareTo(TimePeriod other)
        {
            if (this.totalSeconds > other.totalSeconds)
                return 1;
            else if (this.totalSeconds < other.totalSeconds)
                return -1;
            else
                return 0;
        }
        /// <summary>
        /// Przeciążenie operatora ==
        /// </summary>
        /// <param name="left"> Dowolny obiekt typu TimePeriod </param>
        /// <param name="right"> Dowolny obiekt typu TimePeriod </param>
        /// <returns> True jeśli obiekty są równe, w przeciwnym wypadku False </returns>
        public static bool operator ==(TimePeriod left, TimePeriod right) => Equals(left, right);
        /// <summary>
        /// Przeciążenie operatora !=
        /// </summary>
        /// <param name="left"> Dowolny obiekt typu TimePeriod </param>
        /// <param name="right"> Dowolny obiekt typu TimePeriod </param>
        /// <returns> True jeśli obiekty są różne, w przeciwnym wypadku False </returns>
        public static bool operator !=(TimePeriod left, TimePeriod right) => !Equals(left, right);
        /// <summary>
        /// Przeciążenie operatora <
        /// </summary>
        /// <param name="left"> Dowolny obiekt typu TimePeriod </param>
        /// <param name="right"> Dowolny obiekt typu TimePeriod </param>
        /// <returns> True jeśli pierwszy obiekt jest mniejszy, w przeciwnym wypadku False </returns>
        public static bool operator <(TimePeriod left, TimePeriod right)
        {
            if (left.totalSeconds < right.totalSeconds)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Przeciążenie operatora >
        /// </summary>
        /// <param name="left"> Dowolny obiekt typu TimePeriod </param>
        /// <param name="right"> Dowolny obiekt typu TimePeriod </param>
        /// <returns> True jeśli pierwszy obiekt jest większy, w przeciwnym wypadku False </returns>
        public static bool operator >(TimePeriod left, TimePeriod right)
        {
            if (left.totalSeconds > right.totalSeconds)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Przeciążenie operatora <=
        /// </summary>
        /// <param name="left"> Dowolny obiekt typu TimePeriod </param>
        /// <param name="right"> Dowolny obiekt typu TimePeriod </param>
        /// <returns> True jeśli pierwszy obiekt jest mniejszy lub równy drugiemu obiektowi, w przeciwnym wypadku False </returns>
        public static bool operator <=(TimePeriod left, TimePeriod right)
        {
            if (left.totalSeconds <= right.totalSeconds)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Przeciążenie operatora >=
        /// </summary>
        /// <param name="left"> Dowolny obiekt typu TimePeriod </param>
        /// <param name="right"> Dowolny obiekt typu TimePeriod </param>
        /// <returns> True jeśli pierwszy obiekt jest większy lub równy drugiemu obiektowi, w przeciwnym wypadku False </returns>
        public static bool operator >=(TimePeriod left, TimePeriod right)
        {
            if (left.totalSeconds >= right.totalSeconds)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Metoda dodająca do danego odcinka czasu, drugi dowolny odcinek czasu
        /// </summary>
        /// <param name="other"> Dowolny obiekt typu TimePeriod </param>
        /// <returns> Nowy obiekt typu TimePeriod będący sumą dwóch odcinków czasu </returns>
        public TimePeriod Plus(TimePeriod other)
        {
            if (other.totalSeconds < 0)
                throw new ArgumentException("Błędny format argumentu, podaj prawidłowy odstęp czasu.");
            else
                return new TimePeriod(this.totalSeconds + other.totalSeconds);
        }
        /// <summary>
        /// Metoda dodająca do siebie dwa dowolne odcinki czasu
        /// </summary>
        /// <param name="left"> Dowolny obiekt typu TimePeriod </param>
        /// <param name="right"> Dowolny obiekt typu TimePeriod </param>
        /// <returns> Nowy obiekt typu TimePeriod będący sumą dwóch odcinków czasu </returns>
        public static TimePeriod Plus(TimePeriod left, TimePeriod right)
        {
            if (left.totalSeconds < 0 || right.totalSeconds < 0)
                throw new ArgumentException("Błędny format argumentu, podaj prawidłowy odstęp czasu.");
            else
                return new TimePeriod(left.totalSeconds + right.totalSeconds);
        }
        /// <summary>
        /// Przeciążenie operatora + 
        /// </summary>
        /// <param name="left"> Dowolny obiekt typu TimePeriod </param>
        /// <param name="right"> Dowolny obiekt typu TimePeriod </param>
        /// <returns> Nowy obiekt typu TimePeriod będący sumą dwóch odcinków czasu </returns>
        public static TimePeriod operator +(TimePeriod left, TimePeriod right)
        {
            if (left.totalSeconds < 0 || right.totalSeconds < 0)
                throw new ArgumentException("Błędny format argumentu, podaj prawidłowy odstęp czasu.");
            else
                return new TimePeriod(left.totalSeconds + right.totalSeconds);
        }
        /// <summary>
        /// Przeciążenie operatora -
        /// </summary>
        /// <param name="left"> Dowolny obiekt typu TimePeriod </param>
        /// <param name="right"> Dowolny obiekt typu TimePeriod, mniejszy od pierwszego podanego parametru </param>
        /// <returns> Nowy obiekt typu TimePeriod będący różnicą dwóch odcinków czasu </returns>
        public static TimePeriod operator -(TimePeriod left, TimePeriod right)
        {
            if (left.totalSeconds < 0 || right.totalSeconds < 0)
                throw new ArgumentException("Błędny format argumentu, podaj prawidłowy odstęp czasu.");
            else if (left.totalSeconds < right.totalSeconds)
                throw new InvalidOperationException("Próbujesz odjąć dłuższy odstęp czasu od odstępu krótszego, nie można uzyskać ujemnego odstępu czasowego.");
            else
                return new TimePeriod(left.totalSeconds - right.totalSeconds);
        }
        /// <summary>
        /// Przeciążenie operatora *
        /// </summary>
        /// <param name="left"> Dowolny obiekt typu TimePeriod  </param>
        /// <param name="right"> Nieujemna liczba całkowita </param>
        /// <returns> Nowy obiekt typu TimePeriod będący efektem mnożenia liczby sekund przez liczbę całkowitą </returns>
        public static TimePeriod operator *(TimePeriod left, int right)
        {
            if (left.totalSeconds * right > long.MaxValue)
            {
                throw new OverflowException("Wynik przekracza pojemność zmiennej, podaj mniejszą liczbę");
            }
            else if (right < 0)
            {
                throw new ArgumentOutOfRangeException("Liczba przez którą mnożysz nie może być ujemna!");
            }
            else return new TimePeriod(left.totalSeconds * right);
        }
    } 
}
