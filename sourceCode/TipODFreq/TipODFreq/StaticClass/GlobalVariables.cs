﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipODFreq
{
   public static class GlobalVariables
    {
        public static string ConnectionString { get; set; }
        public static IDbConnection GetDbConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public static string PathApp { get; set; }

        public static string PathOd { get; set; }
        public static string PathFormulaG { get; set; }
        public static string PathFormulaPo { get; set; }

        public static int ShaftNumSanding { get; set; }
        public static int ShaftNumOd { get; set; }
        public static int ShaftNumPolishing { get; set; }
        public static int ShaftNumSave { get; set; }
    }
}
