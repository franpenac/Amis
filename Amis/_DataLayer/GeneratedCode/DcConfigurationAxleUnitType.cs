using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using amis._Common;
using amis.Models;

namespace amis._DataLayer.GeneratedCode
{
    public class DcConfigurationAxleUnitType
    {
        public List<ConfigurationAxleUnitType> GetConfigurationAxleUnitTypeByAxleConfigId(int configurationUnitTypeId)
        {
            string errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<ConfigurationAxleUnitType> conf = (from caut in context.ConfigurationAxleUnitType where caut.ConfigurationUnitTypeId == configurationUnitTypeId select caut).ToList();
                    return conf;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }
    }
}