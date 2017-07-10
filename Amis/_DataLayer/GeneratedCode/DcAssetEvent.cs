using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using amis._Common;
using amis.Models;
//holahola
namespace amis._DataLayer.GeneratedCode
{
    public partial class DcAssetEvent
    {
        public void Copy(AssetEvent objSource, ref AssetEvent objDestination)
        {
            objDestination.AssetEventId = objSource.AssetEventId;
            objDestination.AssetId = objSource.AssetId;
            objDestination.SubEventAssetTypeId = objSource.SubEventAssetTypeId;
            objDestination.MeasurementUnitId = objSource.MeasurementUnitId;
            objDestination.AssetPositionId = objSource.AssetPositionId;
            objDestination.AsignmentId = objSource.AsignmentId;
            objDestination.AssetSituationId = objSource.AssetSituationId;
            objDestination.AssetEventMemberId = objSource.AssetEventMemberId;
            objDestination.FacilityId = objSource.FacilityId;
            objDestination.UnitId = objSource.UnitId;
            objDestination.AssetEventDate = objSource.AssetEventDate;
            objDestination.AssetEventCost = objSource.AssetEventCost;
            objDestination.MeasurementAsset = objSource.MeasurementAsset;
            objDestination.MeasurementKm = objSource.MeasurementKm;
            objDestination.StartPressureMeasurement = objSource.StartPressureMeasurement;
            objDestination.FinishPressureMeasurement = objSource.FinishPressureMeasurement;
            objDestination.MeasurementTireTreadDepth1 = objSource.MeasurementTireTreadDepth1;
            objDestination.MeasurementTireTreadDepth2 = objSource.MeasurementTireTreadDepth2;
            objDestination.MeasurementTireTreadDepth3 = objSource.MeasurementTireTreadDepth3;
            objDestination.MeasurementTireTreadDepth4 = 0;
            objDestination.MeasurementTireTreadDepth5 = 0;
            objDestination.MeasurementTireTreadDepth6 = 0;
            objDestination.MeasurementTireTreadDepth7 = 0;
            objDestination.MeasurementTireTreadDepth8 = 0;
            objDestination.MeasurementTireTreadDepth9 = 0;
            objDestination.MeasurementTireTreadDepth10 = 0;
            objDestination.ExecutingUserId = objSource.ExecutingUserId;
            objDestination.AuthorizingUserId = objSource.AuthorizingUserId;
        }

        public AssetEvent Save(AssetEvent objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        AssetEvent row = context.AssetEvent.Where(r => r.AssetEventId == objSource.AssetEventId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new AssetEvent();
                            Copy(objSource, ref row);
                            context.AssetEvent.Add(row);
                        }
                        else
                        {
                            Copy(objSource, ref row);
                        }
                        context.SaveChanges();
                        transaction.Complete();
                        return row;
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public List<AssetEvent> GetAssetEventList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<AssetEvent> list = context.AssetEvent.ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public bool ExistsAssetEvent(int AssetEventId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                AssetEvent obj = null;
                using (var context = new Entity())
                {
                    obj = context.AssetEvent.Where(r => r.AssetEventId != AssetEventId).FirstOrDefault();
                    if (obj == null)
                    {
                        return false;
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return false;
            }
        }

        public CommonEnums.DeletedRecordStates DeleteAssetEvent(int IAssetEventId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    AssetEvent obj = context.AssetEvent.Where(r => r.AssetEventId == IAssetEventId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.AssetEvent.Remove(obj);
                    context.SaveChanges();
                    return CommonEnums.DeletedRecordStates.DeletedOk;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return CommonEnums.DeletedRecordStates.NotDeleted;
            }
        }

        public bool HasAsset(int AssetId, ref AssetEvent first)
        {
            using (var context = new Entity())
            {
                first = context.AssetEvent.Where(r => r.AssetId != AssetId).FirstOrDefault();
                if (first == null)
                {
                    return false;
                }
                return true;
            }
        }
		
		public bool HasMember(int MemberId, ref AssetEvent first)
        {
            using (var context = new Entity())
            {
                first = context.AssetEvent.Where(r => r.AssetEventMemberId != MemberId).FirstOrDefault();
                if (first == null)
                {
                    return false;
                }
                return true;
            }
        }
		
		public bool HasAssignment(int AssignmentId, ref AssetEvent first)
        {
            using (var context = new Entity())
            {
                first = context.AssetEvent.Where(r => r.AsignmentId != AssignmentId).FirstOrDefault();
                if (first == null)
                {
                    return false;
                }
                return true;
            }
        }
    }
}