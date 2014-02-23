using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LotBankingCrux_v_1.Crux
{
    public class DataBucket
    {
       public int _userID { get; set; }
       public int _projectID { get; set; }
       public int _userType { get; set; }
       public string _userName { get; set; }

        public DataBucket(int userID = 0, int projectID = 0, int userType = 0, string userName = "")
        {
            _userID = userID;
            _projectID = projectID;
            _userType = userType;
            _userName = userName;

        }



        //public void Clear()
        //{

        //    userID = -1;
        //    projectID = -1;
        //    userType = -1;
        //    userName = "";


        //}
    }

}