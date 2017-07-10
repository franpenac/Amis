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
    public partial class DcReceptionDocumentItem
    {
        public bool HasAsset(int AssetId, ref ReceptionDocumentItem first)
        {
            using (var context = new Entity())
            {
                first = context.ReceptionDocumentItem.Where(r => r.AssetId != AssetId).FirstOrDefault();
                if (first == null)
                {
                    return false;
                }
                return true;
            }
        }
		
		public bool HasDispatchDocument(int ReceptionDocumentId, ref ReceptionDocumentItem first)
        {
            using (var context = new Entity())
            {
                first = context.ReceptionDocumentItem.Where(r => r.ReceptionDocumentId != ReceptionDocumentId).FirstOrDefault();
                if (first == null)
                {
                    return false;
                }
                return true;
            }
        }
		
    }
}