using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace FoodDoAn.HttpCode
{
    public class FoodType
    {
		private int _type_id;
		private string _type_name;
		private int _type_post;
		private string _type_img;
		private int _status;
		private string _username;
		private DateTime _modified;

		public DateTime Modified
		{
			get { return _modified; }
			set { _modified = value; }
		}


		public string UserName
		{
			get { return _username; }
			set { _username = value; }
		}


		public int Status
		{
			get { return _status; }
			set { _status = value; }
		}

		public string TypeImg
		{
			get { return _type_img; }
			set { _type_img = value; }
		}

		public int TypeID
		{
			get { return _type_id; }
			set { _type_id = value; }
		}

		

		public string TypeName
		{
			get { return _type_name; }
			set { _type_name = value; }
		}

		

		public int TypePost
		{
			get { return _type_post; }
			set { _type_post = value; }
		}

		public FoodType (string type_name , int type_post , string type_img, int status , string username, DateTime modified )
		{
			this._type_name = type_name;
			this._type_post = type_post;
			this._type_img = type_img;
			this._status = status;
			this._username = username;
			this._modified = modified;
		}
		public FoodType ()
		{

		}
		public FoodType (int id)
		{
			this._type_id = id;
		}
		public DataTable getId(int id)
		{
			string sQuery = "SELECT * FROM[dbo].[food_type] WHERE [type_id] = '" + id + "'";
			return DataProvider.getUserName(sQuery);
		}
		public bool AddFoodType()
		{
			string ketnoi = "INSERT INTO [dbo].[food_type] ([type_name],[type_pos],[type_img],[status],[username],[modidied]) VALUES (@type_name , @type_pos, @type_img, @status, @username, @modidied  )";
			SqlParameter[] paras = {
			   new SqlParameter("@type_name", SqlDbType.NVarChar, 50){ Value = this.TypeName },
			   new SqlParameter("@type_pos", SqlDbType.Int){ Value = this.TypePost},
			   new SqlParameter("@type_img", SqlDbType.NVarChar, 255){ Value = this.TypeImg},
			   new SqlParameter("@status", SqlDbType.Int){ Value = this.Status},
			   new SqlParameter("@username", SqlDbType.NVarChar, 50){ Value = this.UserName},
			   new SqlParameter("@modidied", SqlDbType.DateTime){ Value = this.Modified},

			};

			return DataProvider.executeNonQuery(ketnoi, paras);
		}
		public bool updateFood(int id)
		{
			string sQuery = "UPDATE [dbo].[food_type] SET[type_name] = @type_name,[type_pos] = @type_pos,[type_img] = @type_img,[status] = @status,[username] = @username,[modidied] = @modidied  WHERE [type_id] = " + id ;
			SqlParameter[] paras = {
			  
			   new SqlParameter("@type_name", SqlDbType.NVarChar, 50){ Value = this.TypeName },
			   new SqlParameter("@type_pos", SqlDbType.Int){ Value = this.TypePost},
			   new SqlParameter("@type_img", SqlDbType.NVarChar, 255){ Value = this.TypeImg},
			   new SqlParameter("@status", SqlDbType.Int){ Value = this.Status},
			   new SqlParameter("@username", SqlDbType.NVarChar, 50){ Value = this.UserName},
			   new SqlParameter("@modidied", SqlDbType.DateTime){ Value = this.Modified},

			};

			return DataProvider.executeNonQuery(sQuery, paras);
		}
		public DataTable dataFood()
		{
			string sQuery = "SELECT * FROM [dbo].[food_type]";
			return DataProvider.getUserName(sQuery);
		}
	}
}