using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace amis._Common
{
    public static class ErrorController
    {
        public static string GetErrorMessage(Exception ex)
        {
            string errorMessage = ex.Message;
            if (ex.InnerException != null)
            {
                if (errorMessage != ex.InnerException.Message)
                {
                    errorMessage = errorMessage + ". " + ex.InnerException.Message;
                }
                if (ex.InnerException.InnerException != null)
                {
                    errorMessage = errorMessage + ". " + ex.InnerException.InnerException.Message;
                }
            }
            return errorMessage;
        }

        public static object SetErrorMessage(string errorNumber, out string errorMessage)
        {
            errorMessage = errorNumber;
            return null;
        }

        public static bool SetBoolErrorMessage(string errorNumber, out string errorMessage)
        {
            errorMessage = errorNumber;
            return false;
        }
    }
}