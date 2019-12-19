using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeStructures
{
    public readonly struct Time : IEquatable<Time>, IComparable<Time>
    {
        private byte Hours { get; }
        private byte Minutes { get; }
        private byte Seconds { get; }
        /// <summary>
        /// Implementacja interfejsu IComparable
        /// </summary>
        /// <param name="time"> Inny, dowolny obiekt typu Time</param>
        /// <returns> 1, gdy pierwszy obiekt jest większy, 0 gdy jest równy, -1 gdy jest mniejszy od obiektu drugiego</returns>
        public int CompareTo(Time time)
        {
            if(this.Hours > time.Hours)
                return 1;
            else if (this.Hours < time.Hours)
                return -1;
            else 
            {
                if (this.Minutes > time.Minutes)
                    return 1;
                else if(this.Minutes < time.Minutes)
                    return -1;
                else
                {
                    if (this.Seconds > time.Seconds)
                        return 1;
                    else if (this.Seconds < time.Seconds)
                        return -1;
                    else return 0;
                }
            }
        }
        /// <summary>
        /// Implementacja interfejsu IEquatable
        /// </summary>
        /// <param name="obj">Dowolny obiekt</param>
        /// <returns>Fałsz, gdy obiekt u nie można zrzutować na Time. Jeśli jest - zwraca wynik sprawdzenia równości.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else if (obj is Time == false)
                return false;
            return base.Equals((Time)obj);
        }
        /// <summary>
        /// Implementacja interfejsu IEquatable
        /// </summary>
        /// <returns> Hash obiektu typu Time</returns>
        public override int GetHashCode() => (Hours, Minutes, Seconds).GetHashCode();
        /// <summary>
        /// Implementacja interfejsu IEquatable
        /// </summary>
        /// <param name="obj"> Dowolny obiekt typu Time</param>
        /// <returns>True jeśli obiekty są równe, w przeciwnym wypadku False</returns>
        public bool Equals(Time obj)
        {
            if (this.Hours == obj.Hours && this.Minutes==obj.Minutes && this.Seconds==obj.Seconds)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Przeciążenie operatora ==
        /// </summary>
        /// <param name="left"> Dowolny obiekt typu Time </param>
        /// <param name="right"> Dowolny obiekt typu Time </param>
        /// <returns> True jeśli obiekty są równe, w przeciwnym wypadku False </returns>
        public static bool operator ==(Time left, Time right) => Equals(left, right);
        /// <summary>
        /// Przeciążenie operatora !=
        /// </summary>
        /// <param name="left"> Dowolny obiekt typu Time </param>
        /// <param name="right"> Dowolny obiekt typu Time </param>
        /// <returns> True jeśli obiekty są różne, w przeciwnym wypadku False </returns>
        public static bool operator !=(Time left, Time right) => !Equals(left, right);
        /// <summary>
        /// Przeciążenie operatora >
        /// </summary>
        /// <param name="left"> Dowolny obiekt typu Time </param>
        /// <param name="right"> Dowolny obiekt typu Time </param>
        /// <returns> True jeśli pierwszy obiekt jest większy, w przeciwnym wypadku False </returns>
        public static bool operator >(Time left, Time right) {
            if (left.Hours > right.Hours)
                return true;
            else if (left.Hours < right.Hours)
                return false;
            else
            {
                if (left.Minutes > right.Minutes)
                    return true;
                else if (left.Minutes < right.Minutes)
                    return false;
                else
                {
                    if (left.Seconds > right.Seconds)
                        return true;
                    else
                        return false;
                }
            }
        }
        /// <summary>
        /// Przeciążenie operatora <
        /// </summary>
        /// <param name="left"> Dowolny obiekt typu Time </param>
        /// <param name="right"> Dowolny obiekt typu Time </param>
        /// <returns> True jeśli pierwszy obiekt jest mniejszy, w przeciwnym wypadku False </returns>
        public static bool operator <(Time left, Time right)
        {
            if (left.Hours < right.Hours)
                return true;
            else if (left.Hours > right.Hours)
                return false;
            else
            {
                if (left.Minutes < right.Minutes)
                    return true;
                else if (left.Minutes > right.Minutes)
                    return false;
                else
                {
                    if (left.Seconds < right.Seconds)
                        return true;
                    else
                        return false;
                }
            }
        }
        /// <summary>
        /// Przeciążenie operatora <=
        /// </summary>
        /// <param name="left"> Dowolny obiekt typu Time </param>
        /// <param name="right"> Dowolny obiekt typu Time </param>
        /// <returns> True jeśli pierwszy obiekt jest mniejszy lub równy drugiemu obiektowi, w przeciwnym wypadku False </returns>
        public static bool operator <=(Time left, Time right)
        {
            if (left.Hours < right.Hours)
                return true;
            else if (left.Hours > right.Hours)
                return false;
            else
            {
                if (left.Minutes < right.Minutes)
                    return true;
                else if (left.Minutes > right.Minutes)
                    return false;
                else
                {
                    if (left.Seconds > right.Seconds)
                        return false;
                    else
                        return true;
                }
            }
        }
        /// <summary>
        /// Przeciążenie operatora >=
        /// </summary>
        /// <param name="left"> Dowolny obiekt typu Time </param>
        /// <param name="right"> Dowolny obiekt typu Time </param>
        /// <returns> True jeśli pierwszy obiekt jest większy lub równy drugiemu obiektowi, w przeciwnym wypadku False </returns>
        public static bool operator >=(Time left, Time right)
        {
            if (left.Hours > right.Hours)
                return true;
            else if (left.Hours < right.Hours)
                return false;
            else
            {
                if (left.Minutes > right.Minutes)
                    return true;
                else if (left.Minutes < right.Minutes)
                    return false;
                else
                {
                    if (left.Seconds < right.Seconds)
                        return false;
                    else
                        return true;
                }
            }
        }
        /// <summary>
        /// Konstruktor 3-argumentowy
        /// </summary>
        /// <param name="h"> Liczba typu byte z przedziału 0-23 oznaczająca godzinę </param>
        /// <param name="m"> Liczba typu byte z przedziału 0-59 oznaczająca minutę </param>
        /// <param name="s"> Liczba typu byte z przedziału 0-59 oznaczająca sekundę </param>
        public Time(byte h, byte m, byte s)
        {
            if (h > 23 || h < 0)
                throw new ArgumentOutOfRangeException("Nieprawidłowa godzina! Podaj godzinę z przedziału 0-23.");
            else
                Hours = h;
            if (m > 59 || m < 0)
                throw new ArgumentOutOfRangeException("Nieprawidłowa minuta! Podaj minutę z przedziału 0-59.");
            else
                Minutes = m;
            if (s > 59 || s < 0)
                throw new ArgumentOutOfRangeException("Nieprawidłowa sekunda! Podaj sekundę z przedziału 0-59.");
            else
                Seconds = s;
        }
        /// <summary>
        /// Konstruktor 2-argumentowy (domyślnie 0 sekund)
        /// </summary>
        /// <param name="h"> Liczba typu byte z przedziału 0-23 oznaczająca godzinę </param>
        /// <param name="m"> Liczba typu byte z przedziału 0-59 oznaczająca minutę </param>
        public Time(byte h, byte m)
        {
            if (h > 23 || h < 0)
                throw new ArgumentOutOfRangeException("Nieprawidłowa godzina! Podaj godzinę z przedziału 0-23.");
            else
                Hours = h;
            if (m > 59 || m < 0)
                throw new ArgumentOutOfRangeException("Nieprawidłowa minuta! Podaj minutę z przedziału 0-59.");
            else
                Minutes = m;
                Seconds = 0;
        }
        /// <summary>
        /// Konstruktor 1-argumentowy (domyślnie 0 sekund, 0 minut)
        /// </summary>
        /// <param name="h"> Liczba typu byte z przedziału 0-23 oznaczająca godzinę </param>
        public Time(byte h)
        {
            if (h > 23 || h < 0)
                throw new ArgumentOutOfRangeException("Nieprawidłowa godzina! Podaj godzinę z przedziału 0-23.");
            else
                Hours = h;
                Minutes = 0;
                Seconds = 0;
        }
        /// <summary>
        /// Konstruktor 1-argumentowy (wersja string)
        /// </summary>
        /// <param name="time"> łańcuch znaków w formacie hh:mm:ss (hh z przedziału 0-23, mm i ss z przedziału 0-59 </param>
        public Time(string time)
        {
            if (time.Length != 8)
                throw new ArgumentException("Nieprawidłowy format daty! Podaj datę w formie hh:mm:ss");
            else
            {
                string[] tab = time.Split(':');
                if ((byte.TryParse(tab[0], out _) == false) || (byte.TryParse(tab[1], out _) == false) || (byte.TryParse(tab[2], out _) == false))
                {
                    throw new ArgumentException("Nieprawidłowy format daty! Używaj wyłącznie cyfr w formacie hh:mm:ss");
                }
                if (byte.Parse(tab[0]) > 23 || byte.Parse(tab[0]) < 0)
                    throw new ArgumentOutOfRangeException("Nieprawidłowa godzina! Podaj godzinę z przedziału 0-23.");
                else
                    Hours = byte.Parse(tab[0]);
                if (byte.Parse(tab[1]) > 59 || byte.Parse(tab[1]) < 0)
                    throw new ArgumentOutOfRangeException("Nieprawidłowa minuta! Podaj minutę z przedziału 0-59.");
                else
                    Minutes = byte.Parse(tab[1]);
                if (byte.Parse(tab[2]) > 59 || byte.Parse(tab[2]) < 0)
                    throw new ArgumentOutOfRangeException("Nieprawidłowa sekunda! Podaj sekundę z przedziału 0-59.");
                else
                    Seconds = byte.Parse(tab[2]);
            }
        }
        /// <summary>
        /// Przeciążenie operatora +
        /// </summary>
        /// <param name="left"> Dowolny obiekt typu Time </param>
        /// <param name="right"> Dowolny obiekt typu Time </param>
        /// <returns> Nowy obiekt typu Time będący wynikiem dodania odcinka right do punktu w czasie left. </returns>
        public static Time operator +(Time left, TimePeriod right)
        {
            return Plus(left, right);
        }
        /// <summary>
        /// Metoda dodająca do klasy dany odcinek czasowy
        /// </summary>
        /// <param name="other"> Dowolny obiekt typu TimePeriod </param>
        /// <returns> Nowy obiekt typu Time będący wynikiem dodania odcinka other do bazowego obiektu typu Time. </returns>
        public Time Plus(TimePeriod other)
        {
            if (other.totalSeconds < 0)
                throw new ArgumentException("Błędny format argumentu, podaj prawidłowy odstęp czasu.");
            else
            {
                long seconds = (this.Seconds + other.totalSeconds)%60;
                long minutes = (this.Minutes + (other.totalSeconds / 60)) % 60;
                long hours =( (this.Minutes + ((other.totalSeconds / 60) % 60)) / 60 + this.Hours + (other.totalSeconds / 3600)) %24;
                return new Time((byte)hours,(byte)minutes,(byte)seconds);
            }
        }
        /// <summary>
        /// Statyczna metoda dodająca dany odcinek czasu do określonej godziny
        /// </summary>
        /// <param name="left"> Dowolny obiekt typu Time </param>
        /// <param name="right"> Dowolny obiekt typu TimePeriod </param>
        /// <returns> Nowy obiekt typu Time będący wynikiem dodania odcinka right do obiektu left typu Time. </returns>
        public static Time Plus(Time left, TimePeriod right)
        {
            if (right.totalSeconds < 0)
                throw new ArgumentException("Błędny format argumentu, podaj prawidłowy odstęp czasu.");
            else
            {
                long seconds = (left.Seconds + right.totalSeconds) % 60;
                long minutes = (left.Minutes + (right.totalSeconds / 60 )) % 60;
                long hours = ((left.Minutes + (right.totalSeconds / 60) % 60) / 60 + left.Hours + (right.totalSeconds / 3600)) % 24;
                return new Time((byte)hours, (byte)minutes, (byte)seconds);
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
            if(Hours.ToString().Length == 1)
                hOut = "0" + Hours;
            else
                hOut = Hours.ToString();
            if (Minutes.ToString().Length == 1)
                mOut = "0" + Minutes;
            else
                mOut = Minutes.ToString();
            if (Seconds.ToString().Length == 1)
                sOut = "0" + Seconds;
            else
                sOut = Seconds.ToString();
            return hOut + ":" + mOut + ":" + sOut;
        }
    }
}