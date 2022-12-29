using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    public enum EnumCreditCard
    {
        [Description("HDFC")]
        HDFC = 1,
        [Description("SBI")]
        SBI = 2,
        [Description("AXIS")]
        AXIS = 3,
    }
}
