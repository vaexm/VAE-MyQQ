using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MODEL
{
    public  class UserInfo
    {
        public static int LoginId =1000 ;
        /// <summary>
        /// 存当前用户的信息的表
        /// </summary>
        public static DataSet UserTable;
        public static DataSet ChatTable;
        //存当前用户的头像
        public static int FaceId;
        public static bool IsFaClick = true;
        public static int ToUserId;
        //控制好友刷新
        public static bool IsUpdateFri = false;
        public static string LoginPwd;
        public static DataSet ChatFriend;
        public static DateTime Time;
    }
}
