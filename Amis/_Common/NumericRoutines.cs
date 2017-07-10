using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace amis._Common
{
    public static class NumericRoutines
    {

        public static bool ValidateLong(ref string nro, string fieldName, out string errorMessage)
        {
            errorMessage = "";
            if (!StringRoutines.CheckEmptyString(ref nro, fieldName, out errorMessage)) return false;
            if (!CleanLong(ref nro, fieldName, out errorMessage)) return false;
            string formatedNumber = StringRoutines.FormatMontoToString(long.Parse(nro));
            nro = formatedNumber;
            return true;
        }

        public static bool ValidateNegativeLong(ref string nro, string fieldName, out string errorMessage)
        {
            errorMessage = "";
            if (!StringRoutines.CheckEmptyString(ref nro, fieldName, out errorMessage)) return false;
            if (!CleanNegativeLong(ref nro, fieldName, out errorMessage)) return false;
            string formatedNumber = StringRoutines.FormatNegativeMontoToString(long.Parse(nro));
            nro = formatedNumber;
            return true;
        }

        public static bool CleanLong(ref string nro, string fieldName, out string errorMessage)
        {
            errorMessage = "";
            string newNro = "";
            for (int i = 0; i < nro.Length; i++)
            {
                long number = 0;
                string character = nro[i].ToString();
                bool isNumber = long.TryParse(character, out number);
                if (isNumber || character == ".")
                {
                    newNro += character;
                }
                else
                {
                    nro = "";
                    errorMessage = string.Format("El campo '{0}' no es un número válido", fieldName);
                    return false;
                }
            }
            newNro = newNro.Replace(".", "");
            long lngNro = 0;
            if (!long.TryParse(newNro, out lngNro))
            {
                nro = "";
                errorMessage = string.Format("El campo '{0}' no es un número válido", fieldName);
                return false;
            }
            nro = lngNro.ToString();
            return true;
        }

        public static bool CleanNegativeLong(ref string nro, string fieldName, out string errorMessage)
        {
            errorMessage = "";
            string newNro = "";
            for (int i = 0; i < nro.Length; i++)
            {
                long number = 0;
                string character = nro[i].ToString();
                bool isNumber = false;
                if (i == 0 && character == "-")
                {
                    newNro += character;
                    isNumber = true;
                }
                else
                {
                    isNumber = long.TryParse(character, out number);
                    if (isNumber || character == ".")
                    {
                        newNro += character;
                    }
                    else
                    {
                        nro = "";
                        errorMessage = string.Format("El campo '{0}' no es un número válido", fieldName);
                        return false;
                    }
                }
            }
            newNro = newNro.Replace(".", "");
            long lngNro = 0;
            if (!long.TryParse(newNro, out lngNro))
            {
                nro = "";
                errorMessage = string.Format("El campo '{0}' no es un número válido", fieldName);
                return false;
            }
            nro = lngNro.ToString();
            return true;
        }
    }
}