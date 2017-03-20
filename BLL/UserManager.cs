using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace BLL
{
    public  class UserManager
    {
        public static int LoginUser(int LoginId,string LoginPwd)
        {
            return GetUserData.GetUser(LoginId,LoginPwd);
        }
        public static int bllInsertUser(string LoginPwd, string NickName, string Sex, int Age, string Name, int Star, int BloodTypeId)
        {
            return GetUserData.dalInsertUser(LoginPwd,NickName,Sex,Age,Name,Star,BloodTypeId);
        }
        public static DataSet bllGetStar()
        {
            return GetUserData.dalGetStar();
        }
        public static DataSet bllGetBlood()
        {
            return GetUserData.dalGetBlood();
        }
        public static DataSet bllGetUser(int id)
        {
            return GetUserData.getUserInfo(id);
        }
        public static DataSet bllGetFriend()
        {
            return GetUserData.dalGetFriend();
        }

        public static int bllUpLoUsInfo(string Pwd,int FriendshipPolicyId,string NickName,int FaceId,string Sex,int Age,string Name,int StarId,int BloodTypeId)
        {
            return GetUserData.dalUpLoInfo(Pwd,FriendshipPolicyId,NickName,FaceId,Sex,Age,Name,StarId,BloodTypeId);

        }
        public static int SendMessage(int FromUserId,int ToUserId,string Message,int MessageTypeId,int MessageState,DateTime MessageTime)
        {
            return GetUserData.SendMessage(FromUserId,ToUserId,Message,MessageTypeId,MessageState,MessageTime);
        }
        public static DataSet ReadMessage()
        {
            return GetUserData.ReadMessage();
        }
        public static int UpdateMessage(int id )
        {
            return GetUserData.UpdateMessage(id);
        }

        public static DataSet SelectNearBy()
        {
            return GetUserData.SelectNearBy();
        }
        public static DataSet FindFriendN(string NickName)
        {
            return GetUserData.FindFriendN(NickName);
        }
        public static DataSet FindFriendI(int Id)
        {
            return GetUserData.FindFriendI(Id);
        }
        public static int IsFriend(int FriendId)
        {
            return GetUserData.IsFriend(FriendId);
        }
        public static int AddFriend(int id)
        {
            return GetUserData.AddFriend(id);
        }
        public static int DeleteFriend(int Friendid)
        {
            return GetUserData.DeleteFriend(Friendid);
        }
    

    }
}
