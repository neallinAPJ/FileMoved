using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMover
{

    public enum EnumOperator
     {
        /// <summary>
        /// Equal
        /// </summary>
         EQ=1,
        /// <summary>
         /// Contain
        /// </summary>
         CT= 2,
        /// <summary>
         /// GreaterThan
        /// </summary>
         GT=3,
        /// <summary>
         /// GreaterThanAndEqual
        /// </summary>
         GE=4,
        /// <summary>
         /// LessThan
        /// </summary>
         LT=5,
        /// <summary>
         /// LessThanAndEqual
        /// </summary>
         LE=6,
        /// <summary>
         /// BeginsWith
        /// </summary>
         BW=7,
        /// <summary>
         /// EndWith
        /// </summary>
         EW=8
    }

     public enum EnumfieldType
     {
         Int=1,
         Long=2,
         Date=3
     }

}
