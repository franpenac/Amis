using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Infragistics.Web.UI.GridControls;
using amis.Models;
using amis._DataLayer.GeneratedCode;
using Infragistics.Web.UI.NavigationControls;

namespace amis._BusinessLayer.GeneratedCode
{
    public class BcUserAlarm
    {
        public void Copy(UserAlarm objSource, ref UserAlarm objDestination)
        {
            new DcUserAlarm().Copy(objSource, ref objDestination);
        }

        public UserAlarm Save(UserAlarm objSource, out string errorMessage)
        {
            UserAlarm obj = new DcUserAlarm().Save(objSource, out errorMessage);
            if (obj != null)
            {
                errorMessage = "Se han asignado alarmas correctamente.";
            }
            else
                errorMessage = "No fue posible guardar alarmas, por favor informe al Administrador del Sistema. El Servidor entregó el siguiente mensaje: " + errorMessage;
            return obj;
        }

        public UserAlarm GetUserAlarmById(int id, int userId)
        {
            UserAlarm userAlarm = new DcUserAlarm().GetUserAlarmById(id,userId);
            if (userAlarm != null)
            {
                return userAlarm;
            }else
            {
                return null;
            }
        }

        public List<UserAlarmSaved> GetUserAlarmList(int userId)
        {
            return new DcUserAlarm().GetUserAlarmList(userId);
        }
    }
}
