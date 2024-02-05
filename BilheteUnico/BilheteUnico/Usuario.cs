using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace BilheteUnico
{

    internal class Usuario
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        [RegularExpression(@"^(?=.{1,64}@)[A-Za-z0-9_-]+(\.[A-Za-z0-9_-]+)*@[A-Za-z0-9]+(\.[A-Za-z0-9]+)*(\.[A-Za-z]{2,})$", ErrorMessage = "O email inserido não é válido.")]
        public string Email { get; set; }
        public string Phone { get; set; }
        public static bool ValidateCpf(string cpf)
        {
            cpf = cpf.Replace(".", "").Replace("-", ""); // remover pontos e traços

            if (cpf.Length != 11)
                return false;

            int[] digits = cpf.Select(c => int.Parse(c.ToString())).ToArray();

            // Verifica se todos os dígitos são iguais
            if (digits.Distinct().Count() == 1)
                return false;

            // Calcula o primeiro dígito verificador
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                sum += digits[i] * (10 - i);
            }
            int firstDigit = 11 - (sum % 11);
            if (firstDigit >= 10)
                firstDigit = 0;

            // Calcula o segundo dígito verificador
            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += digits[i] * (11 - i);
            }
            int secondDigit = 11 - (sum % 11);
            if (secondDigit >= 10)
                secondDigit = 0;

            return firstDigit == digits[9] && secondDigit == digits[10];
        }
        public static bool IsValidEmail(string email)
        {
            Regex regex = new Regex(@"^(?=.{1,64}@)[A-Za-z0-9_-]+(\.[A-Za-z0-9_-]+)*@[A-Za-z0-9]+(\.[A-Za-z0-9]+)*(\.[A-Za-z]{2,})$");

            return regex.IsMatch(email);
        }

    }

}

