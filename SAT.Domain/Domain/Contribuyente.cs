using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAT.Domain.Domain
{
    public class Contribuyente
    {
        public int IdUser { get; private set; }
        public string Nombre { get; private set; } = null!;
        public string ApellidoPaterno { get; private set; } = null!;
        public string ApellidoMaterno { get; private set; } = null!;
        public DateTime FechaNacimiento { get; private set; }
        public string? RFC { get; private set; }

        private Contribuyente() { }

        public Contribuyente(int idUser, string nombre, string apellidoPaterno, string apellidoMaterno, DateTime fechaNacimiento, string? rfc)
        {
            IdUser = idUser;
            Nombre = nombre;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            FechaNacimiento = fechaNacimiento;
            RFC = rfc;
        }

        public Contribuyente Create()
        {
            if (string.IsNullOrEmpty(Nombre) || string.IsNullOrEmpty(ApellidoPaterno) || FechaNacimiento == null)
            {
                throw new ArgumentException("Nombre, Apellido Paterno y Fecha de Nacimiento son obligatorios.");
            }
            return new Contribuyente(IdUser, Nombre, ApellidoPaterno, ApellidoMaterno, FechaNacimiento, RFC);
        }

        public void GenerarRfc()
        {
            string dato = "";
            if (!string.IsNullOrEmpty(ApellidoPaterno))
            {
                try
                {
                    string[] array = ApellidoPaterno.ToUpper().Split(' ');
                    dato = array[0].Trim();

                }
                catch
                {
                    dato = ApellidoPaterno.ToUpper().Trim();
                }
                RFC = $"{FirstLetter(dato)}{SecondLetter(dato)}";
            }
            if (!string.IsNullOrEmpty(ApellidoMaterno))
            {
                try
                {
                    string[] array = ApellidoMaterno.ToUpper().Split(' ');
                    dato = array[0].Trim();

                }
                catch
                {
                    dato = ApellidoMaterno.ToUpper().Trim();
                }
                RFC += $"{FirstLetter(dato)}";
            }
            else
            {
                ApellidoMaterno = "";
                RFC += "X";
            }
            if (!string.IsNullOrEmpty(Nombre))
            {
                dato = Nombre.ToUpper().Trim();
                RFC += $"{FirstLetterName(dato)}";
            }

            List<string> altisonante = new List<string> { "BUEI", "CACA", "BUEY", "CAGA", "CACO", "CAKA", "CAGO", "COGE", "CAKO", "COJE", "COJA", "COJO", "COJI", "FETO", "CULO", "JOTO", "GUEY", "KACO", "KACA", "KAGO", "KAGA", "KOJO", "KOGE", "KULO", "KAKA", "MAMO", "MAME", "MEAS", "MEAR", "MION", "MEON", "MULA", "MOCO", "PEDO", "PEDA", "PUTA", "PENE", "QULO", "PUTO", "RATA" };
            if (altisonante.Contains(RFC))
            {
                RFC = RFC.Substring(0, 3) + "X";
            }

            if (FechaNacimiento != null)
            {
                string[] fecha = FechaNacimiento.ToString().Split('/');
                RFC += fecha[2].Substring(2, 2);
                RFC += fecha[1];
                RFC += fecha[0];
            }
        }

        private char FirstLetter(string apellido)
        {
            char first;
            if (apellido[0] != 'Ñ')
            {
                first = apellido[0];
            }
            else
            {
                first = 'X';
            }
            return first;
        }
        private char SecondLetter(string apellido)
        {
            char second;
            foreach (char letter in apellido.Substring(1))
            {
                //if (flag != false) { break; }
                string vowels = "AEIOU";
                foreach (char vowel in vowels)
                {
                    if (vowel == letter)
                    {
                        return second = letter;
                        //flag = true;
                    }
                }
            }
            return 'X';
        }
        private char FirstLetterName(string dato)
        {
            List<string> Banned = new List<string> { "MARIA", "MA", "MA.", "JOSE", "J", "J.", "DEL", "DE", "LA", "EL" };
            List<string> Nombres = new List<string>();
            char first = ' ';

            string[] array = dato.Split(' ');

            foreach (string clean in array)
            {
                if (!string.IsNullOrWhiteSpace(clean))
                {
                    Nombres.Add(clean);
                }
            }

            foreach (string name in Nombres)
            {
                if (!Banned.Contains(name))
                {
                    dato = name;
                    first = dato[0];
                    break;
                }
            }
            if (first == ' ')
            {
                dato = Nombres[Nombres.Count() - 1];
                first = dato[0];
            }
            return first;
        }
    }
}
