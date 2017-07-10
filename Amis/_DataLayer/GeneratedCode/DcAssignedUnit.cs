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
    public partial class DcAssignedUnit
    {
        
		public bool HasUnit(int UnitId, ref AssignedUnit first)
        {
            using (var context = new Entity())
            {
                
                return true;
            }
        }
    }
}