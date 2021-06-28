using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ViveVolar.Abstractions;

namespace ViveVolar.Services
{
    public class Validaciones : IValidaciones
    {
        public Validaciones()
        {

        }
        public bool ValidarPassword(string password)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasMinimumChars = new Regex(@".{5,}");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            var isValidated = password.Length<=9 && hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password) && hasLowerChar.IsMatch(password) && hasMinimumChars.IsMatch(password)&& hasSymbols.IsMatch(password);
            return isValidated;

        }
        public string GenerateCode(int p_CodeLength)
        {
            string result = "";
            // Nuestro patrón de caracteres para formar el código
            string pattern = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            // Creamos una instancia del generador de números aleatorios
            // cogemos como semilla los Ticks de reloj de esta forma nos 
            // aseguramos de no generar códigos con la misma semilla.
            Random myRndGenerator = new Random((int)DateTime.Now.Ticks);
            // Procedemos a conformar el código
            for (int i = 0; i < p_CodeLength; i++)
            {
                // Obtenemos un número aleatorio que se corresponde con una
                // posición dentro del pattern.
                int mIndex = myRndGenerator.Next(pattern.Length);
                // Vamos formando el código
                result += pattern[mIndex];
            }

            return result;
        }
    }
}
