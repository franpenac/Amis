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
    public partial class DcDispatchDocumentItem
    {
        public bool HasAsset(int AssetId, ref DispatchDocumentItem first)
        {
            using (var context = new Entity())
            {
                first = context.DispatchDocumentItem.Where(r => r.AssetId != AssetId).FirstOrDefault();
                if (first == null)
                {
                    return false;
                }
                return true;
            }
        }
		
		public bool HasDispatchDocument(int DispatchDocumentId, ref DispatchDocumentItem first)
        {
            using (var context = new Entity())
            {
                first = context.DispatchDocumentItem.Where(r => r.DispatchDocumentId != DispatchDocumentId).FirstOrDefault();
                if (first == null)
                {
                    return false;
                }
                return true;
            }
        }
		
    }
}