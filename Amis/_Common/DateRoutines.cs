using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace amis._Common
{
    public static class DateRoutines
    {
        public static string GetStringNowDateTime(string format)
        {
            return string.Format("{0:" + format + "}", DateTime.Now);
        }

        public static string GetStringToday()
        {
            DateTime date = DateTime.Now;
            int day = date.Day;
            int month = date.Month;
            int year = date.Year;
            string sDay = day.ToString();
            string sMonth = month.ToString();
            string sYear = year.ToString();
            if (day < 10) sDay = "0" + day.ToString();
            if (month < 10) sMonth = "0" + month.ToString();
            string sDate = sDay + "/" + sMonth + "/" + year.ToString();
            return sDate;
        }

        public static bool CleanDate(ref string date, string fieldName, out string errorMessage)
        {
            errorMessage = "";
            string newDate = "";
            for (int i = 0; i < date.Length; i++)
            {
                int number = 0;
                string character = date[i].ToString();
                bool isNumber = int.TryParse(character, out number);
                if (isNumber || character == "/" || character == "-" || character == ".")
                {
                    newDate += character.Replace("-", "/").Replace(".", "/");
                }
                else
                {
                    errorMessage = string.Format("El campo '{0}' no es una fecha válida", fieldName);
                    return false;
                }
            }
            int count = newDate.Count(f => f == '/');
            if (count != 2)
            {
                errorMessage = string.Format("El campo '{0}' no es una fecha válida", fieldName);
                return false;
            }
            string[] datePart = newDate.Split('/');
            if (datePart[0] == "" || datePart[1] == "" || datePart[2] == "")
            {
                errorMessage = string.Format("El campo '{0}' no es una fecha válida", fieldName);
                return false;
            }
            date = newDate;
            return true;
        }

        public static bool IsRealDate(string date, string fieldName, out string errorMessage)
        {
            errorMessage = "";
            string[] datePart = date.Split('/');
            int day = int.Parse(datePart[0]);
            int month = int.Parse(datePart[1]);
            int year = int.Parse(datePart[2]);
            if (day < 1 || day > 31)
            {
                errorMessage = string.Format("El campo '{0}' no es una fecha válida, el día debe ser un número entre 1 y 31", fieldName);
                return false;
            }
            if (month < 1 || month > 12)
            {
                errorMessage = string.Format("El campo '{0}' no es una fecha válida, el mes debe ser un número entre 1 y 12", fieldName);
                return false;
            }
            if (year < 1900 || year > 3000)
            {
                errorMessage = string.Format("El campo '{0}' no es una fecha válida, el año debe ser un número entre 1900 y 3000", fieldName);
                return false;
            }
            if (!ValidateDateTimeDay(year, month, day, fieldName, out errorMessage)) return false;
            return true;
        }

        public static bool ValidateDateTimeDay(int year, int month, int day, string fieldName, out string errorMessage)
        {
            errorMessage = "";
            // Validar febrero en anio bisiesto
            if (DateTime.IsLeapYear(year) && month == 2 && (day < 1 || day > 29))
            {
                errorMessage = string.Format("El campo '{0}' no es una fecha válida, pues '{1}' es año bisiesto y febrero tiene hasta 29 días (se digitó el día {2})", fieldName, year, day);
                return false;
            }
            // Validar febrero en anio no bisiesto
            else if (!DateTime.IsLeapYear(year) && month == 2 && (day < 1 || day > 28))
            {
                errorMessage = string.Format("El campo '{0}' no es una fecha válida, pues '{1}' no es año bisiesto y febrero tiene hasta 28 días (se digitó el día {2})", fieldName, year, day);
                return false;
            }
            // Validar meses de 30 dias
            else if ((month == 4 || month == 6 || month == 9 || month == 11) && (day < 1 || day > 30))
            {
                var monthName = "";
                if (month == 4) monthName = "abril";
                if (month == 6) monthName = "junio";
                if (month == 9) monthName = "septiembre";
                if (month == 11) monthName = "noviembre";
                errorMessage = string.Format("El campo '{0}' no es una fecha válida, pues el mes de '{1}' tiene hasta 30 días (se digitó el día {2})", fieldName, monthName, day);
                return false;
            }
            // Validar meses de 31 dias
            else if ((month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12) && (day < 1 || day > 31))
            {
                var monthName = "";
                if (month == 1) monthName = "enero"; // || month == 6 || month == 9 || month == 11
                if (month == 3) monthName = "marzo";
                if (month == 5) monthName = "mayo";
                if (month == 7) monthName = "julio";
                if (month == 8) monthName = "agosto";
                if (month == 10) monthName = "octubre";
                if (month == 12) monthName = "diciembre";
                errorMessage = string.Format("El campo '{0}' no es una fecha válida, pues el mes de '{1}' tiene hasta 31 días (se digitó el día {2})", fieldName, monthName, day);
                return false;
            }
            return true;
        }

        public static string FormatDateToString(string date)
        {
            string[] datePart = date.Split('/');
            int day = int.Parse(datePart[0]);
            int month = int.Parse(datePart[1]);
            int year = int.Parse(datePart[2]);
            string sDay = day.ToString();
            string sMonth = month.ToString();
            if (day < 10) sDay = "0" + day.ToString();
            if (month < 10) sMonth = "0" + month.ToString();
            string sDate = sDay + "/" + sMonth + "/" + year.ToString();
            return sDate;
        }

        public static DateTime GetDateFromString(string date)
        {
            string[] datePart = date.Split('/');
            int day = int.Parse(datePart[0]);
            int month = int.Parse(datePart[1]);
            int year = int.Parse(datePart[2]);
            DateTime dDate = new DateTime(year, month, day);
            return dDate;
        }

        public static string GetStringFromDate(DateTime date)
        {
            int day = date.Day;
            int month = date.Month;
            int year = date.Year;
            string sDay = day.ToString();
            string sMonth = month.ToString();
            if (day < 10) sDay = "0" + day.ToString();
            if (month < 10) sMonth = "0" + month.ToString();
            string sDate = sDay + "/" + sMonth + "/" + year.ToString();
            return sDate;
        }

        public static string FormatDateTimeToString(string date)
        {
            string[] datePart = date.Split(' ');
            string fecha = datePart[0];
            string horacompleta = datePart[1];

            datePart = fecha.Split('/');
            int day = int.Parse(datePart[0]);
            int month = int.Parse(datePart[1]);
            int year = int.Parse(datePart[2]);
            string sDay = day.ToString();
            string sMonth = month.ToString();
            string sYear = year.ToString();
            if (day < 10) sDay = "0" + day.ToString();
            if (month < 10) sMonth = "0" + month.ToString();
            string sDate = sDay + "/" + sMonth + "/" + year.ToString();

            datePart = horacompleta.Split('.');
            string hrminseg = datePart[0];
            int miliseg = int.Parse(datePart[1]);
            string sMiliseg = miliseg.ToString();

            datePart = hrminseg.Split(':');
            int hour = int.Parse(datePart[0]);
            int min = int.Parse(datePart[1]);
            int seg = int.Parse(datePart[2]);
            string sHour = hour.ToString();
            string sMin = min.ToString();
            string sSeg = seg.ToString();
            if (hour < 10) sHour = "0" + hour.ToString();
            if (min < 10) sMin = "0" + min.ToString();
            if (seg < 10) sSeg = "0" + seg.ToString();

            string sDateTime = string.Format("{0}/{1}/{2} {3}:{4}:{5}.{6}", sDay, sMonth, sYear, sHour, sMin, sSeg, sMiliseg);

            return sDateTime;
        }

        public static DateTime GetDateTimeFromString(string dateTime)
        {
            string[] datePart = dateTime.Split(' ');
            string fecha = datePart[0];
            string horacompleta = datePart[1];

            datePart = fecha.Split('/');
            int day = int.Parse(datePart[0]);
            int month = int.Parse(datePart[1]);
            int year = int.Parse(datePart[2]);

            datePart = horacompleta.Split('.');
            string hrminseg = datePart[0];
            int miliseg = int.Parse(datePart[1]);

            datePart = hrminseg.Split(':');
            int hour = int.Parse(datePart[0]);
            int min = int.Parse(datePart[1]);
            int seg = int.Parse(datePart[2]);

            DateTime dDateTime = new DateTime(year, month, day, hour, min, seg, miliseg);
            return dDateTime;
        }

        public static string GetStringFromDateTime(DateTime date)
        {
            int day = date.Day;
            int month = date.Month;
            int year = date.Year;
            string sDay = day.ToString();
            string sMonth = month.ToString();
            string sYear = year.ToString();
            if (day < 10) sDay = "0" + day.ToString();
            if (month < 10) sMonth = "0" + month.ToString();
            string sDate = sDay + "/" + sMonth + "/" + year.ToString();

            int hour = date.Hour;
            int min = date.Minute;
            int seg = date.Second;
            string sHour = hour.ToString();
            string sMin = min.ToString();
            string sSeg = seg.ToString();
            if (hour < 10) sHour = "0" + hour.ToString();
            if (min < 10) sMin = "0" + min.ToString();
            if (seg < 10) sSeg = "0" + seg.ToString();

            string sMiliseg = date.Millisecond.ToString();

            string sDateTime = string.Format("{0}/{1}/{2} {3}:{4}:{5}.{6}", sDay, sMonth, sYear, sHour, sMin, sSeg, sMiliseg);

            return sDateTime;
        }

        public static bool ValidateFecha(ref TextBox dateTextBox, ref Label errorLabel, string fieldName)
        {
            string errorMessage = "";
            string date = dateTextBox.Text;
            if (date != "")
            {
                if (!ValidateDate(ref date, fieldName, false, out errorMessage))
                {
                    if (date == "") dateTextBox.Text = "";
                    ControlRoutines.SetErrorLabel(errorLabel, errorMessage);
                    return false;
                }
                dateTextBox.Text = DateRoutines.FormatDateToString(date);
                ControlRoutines.SetErrorLabel(errorLabel, "");
            }
            return true;
        }

        public static bool ValidateDate(ref string date, string fieldName, bool checkEmpty, out string errorMessage)
        {
            errorMessage = "";
            if (checkEmpty)
            {
                if (!StringRoutines.CheckEmptyString(ref date, fieldName, out errorMessage)) return false;
            }
            if (!CleanDate(ref date, fieldName, out errorMessage)) return false;
            if (!IsRealDate(date, fieldName, out errorMessage)) return false;
            date = FormatDateToString(date);
            return true;
        }

        public static DateTime GetIniDate(string fecha)
        {
            string errorMessage = "";
            DateTime dFecha = new DateTime(1900, 1, 1);
            if (fecha != "")
            {
                if (DateRoutines.IsRealDate(fecha, "", out errorMessage))
                {
                    dFecha = DateRoutines.GetDateFromString(fecha);
                }
            }
            return dFecha;
        }

        public static DateTime GetFinDate(string fecha)
        {
            string errorMessage = "";
            DateTime dFecha = new DateTime(3000, 12, 31);
            if (fecha != "")
            {
                if (DateRoutines.IsRealDate(fecha, "", out errorMessage))
                {
                    dFecha = DateRoutines.GetDateFromString(fecha);
                }
            }
            return dFecha;
        }
    }
}