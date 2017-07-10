using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using amis._Common;
using amis._DataLayer;
using System.Web.UI;
using System.Web.UI.WebControls;
using Infragistics.Web.UI;
using Infragistics.Web.UI.EditorControls;
using Infragistics.Web.UI.GridControls;
using amis.Models;
using amis._DataLayer.GeneratedCode;

namespace amis._BusinessLayer.GeneratedCode
{
    public class BcAssetEvent
    {
        public void Copy(AssetEvent objSource, ref AssetEvent objDestination)
        {
            new DcAssetEvent().Copy(objSource, ref objDestination);
        }

        public AssetEvent Save(AssetEvent objSource, out string errorMessage)
        {
            AssetEvent obj = new DcAssetEvent().Save(objSource, out errorMessage);
            if (obj != null)
                errorMessage = "El activo fue guardado correctamente.";

            else if (errorMessage == "Repeated Asset name")
                errorMessage = "No fue posible guardar el activo, pues ya existe en la Base de Datos.";

            else
                errorMessage = "No fue posible guardar el activo, por favor informe al Administrador del Sistema. El Servidor entregó el siguiente mensaje: " + errorMessage;
            return obj;
        }
    }
}