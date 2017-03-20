using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using System.Data;

namespace DAL
{
    public  class GetUserData
    {
        /// <summary>
        /// 获取登陆信息 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int GetUser(int LoginId,string LoginPwd)
        {
            string text = "select count(*) from Users where Id="+LoginId+" and LoginPwd="+LoginPwd+"";
            return DBH.ExecuteScalar(text);
        }
        public static DataSet dalGetStar()
        {
            string str = "select *from Star";
            return DBH.Tables(str);
        }
        public static DataSet dalGetBlood()
        {
            string str = "select *from BloodType";
            return DBH.Tables(str);
        }
        public static int dalInsertUser(string LoginPwd, string NickName, string Sex, int Age, string Name, int Star, int BloodTypeId)
        {
            string str = "insert into Users  select '" + LoginPwd + "',1,'" + NickName + "',4,'" + Sex + "'," + Age + ",'','" + Star + "','" + BloodTypeId + "'select @@IDENTITY";
            return DBH.ExecuteScalar(str);

        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataSet getUserInfo(int id)
        {
            string str = "select *from Users where Id="+id;
            return DBH.Tables(str);
        }
        public static DataSet GetChatFriend()
        {
            string str = "";
            return DBH.Tables(str);
        }
        /// <summary>
        /// 获取朋友信息
        /// </summary>
        /// <returns></returns>
        public static DataSet dalGetFriend()
        {
            string str = "select *from Friends where HostId='"+UserInfo.LoginId+"'";
            return DBH.Tables(str);
        }
        /// <summary>
        /// 修改登录者信息
        /// </summary>
        /// <returns></returns>
        public static int dalUpLoInfo(string Pwd,int FriendShipPolicyId,string NickName,int FaceId,string Sex,int Age,string Name,int StarId,int BloodTypeId)
        {

            string str = "update Users set LoginPwd='"+Pwd+"',FriendshipPolicyId='"+FriendShipPolicyId+"',NickName='"+NickName+"',FaceId='"+FaceId+"',Sex='"+Sex+"',Age='"+Age+"' ,Name='"+Name+"',StarId='"+StarId+"',BloodTypeId='"+BloodTypeId+"' where Id="+UserInfo.LoginId;
            return DBH.ExecuteNonQuery(str);
 
        }
        //发送消息
        public static int SendMessage(int FromUserId,int ToUserId,string Messages,int MessageTypeId,int MessageState,DateTime MessageTime)
        {
            string str = "insert into Messages (FromUserId,ToUserId,Message,MessageTypeId,MessageState,MessageTime) select '"+FromUserId+"','"+ToUserId+"','"+Messages+"','"+MessageTypeId+"','"+MessageState+"','"+DateTime.Now+"'";

            return DBH.ExecuteNonQuery(str);
        }
        /// <summary>
        /// 读取消息
        /// </summary>
        /// <returns></returns>
        public static DataSet ReadMessage()
        {
            string str = "select *from Messages Where FromUserId='" + UserInfo.ToUserId + "'  and ToUserId='" + UserInfo.LoginId + "'";
            return DBH.Tables(str);
        }
        //修改消息状态
        public static int UpdateMessage(int id)
        {
            string str = "update Messages set MessageState=0 where Id="+id;
            return DBH.ExecuteNonQuery(str);
        }
        //查找附近的好友
        public static DataSet SelectNearBy()
        {
            string str = "select *from Users where Id<>"+UserInfo.LoginId;
            return DBH.Tables(str);
        }
        //按昵称查找好友
        public static DataSet FindFriendN(string NickName)
        {
            string str = "select *from Users where NickName='"+NickName+"'";
            return DBH.Tables(str);
        }
        //按账号查找好友
        public static DataSet FindFriendI(int Id)
        {
            string str = "select *from Users where Id="+Id;
            return DBH.Tables(str);
        }
        //判断两人是否为好友
        public static int IsFriend(int FriendId)
        {
            string str = "select COUNT(*)from Friends where HostId='"+UserInfo.LoginId+"' and FriendId="+FriendId;
            return DBH.ExecuteScalar(str);

        }
        //添加好友
        public static int AddFriend(int id)
        {
            string str = "insert into Friends select'" + UserInfo.LoginId + "','"+id+"'";
            return DBH.ExecuteNonQuery(str);
        }
        //删除好友
        public static int DeleteFriend(int Friendid)
        {
            string str = "delete from Friends where FriendId='"+Friendid+"' and HostId="+UserInfo.LoginId;
            return DBH.ExecuteNonQuery(str);


        }
      
    }
}
