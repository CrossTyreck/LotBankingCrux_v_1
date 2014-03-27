using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LotBankingCrux_v_1.Crux
{
    public class DataBucket
    {
       public int _userID { get; set; }
       public int _builderID { get; set; }
       public int _projectID { get; set; }
       public int _userType { get; set; }
       public string _userName { get; set; }
       public int _docClassId { get; set; }

        public DataBucket(int userID = 0, int builderID = 0, int projectID = 0, int userType = 0, string userName = "", int docClassId = 0)
        {
            _userID = userID;
            _builderID = builderID;
            _projectID = projectID;
            _userType = userType;
            _userName = userName;
            _docClassId = docClassId;

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