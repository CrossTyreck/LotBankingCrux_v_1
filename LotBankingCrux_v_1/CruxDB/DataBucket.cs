using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LotBankingCrux_v_1.Crux
{
    public class DataBucket
    {
        public static int userID;
        public static int projectID;
        public static int userType;
        public static string userName; //hacking this in CHRIS


        public static void Clear()
        {

            userID = 0;
            projectID = 0;
            userType = 0;
            userName = "";


        }
    }

}