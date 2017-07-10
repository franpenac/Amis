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
    public class DcAssetPosition
    {
        public List<AssetPosition> GetAssetPositionByAxleId(int axleId)
        {
            string errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<AssetPosition> list = (from assetPosition in context.AssetPosition where assetPosition.AxleConfigurationId == axleId select assetPosition).ToList();
                    if (list != null)
                    {
                        return list;
                    }else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public AssetPosition GetAssetPositionById(int assetPositionId)
        {
            string errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    AssetPosition obj = (from ast in context.AssetPosition where ast.AssetPositionId == assetPositionId select ast).FirstOrDefault();
                    return obj;
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