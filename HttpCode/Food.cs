using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
namespace FoodDoAn.HttpCode
{
    public class Food
    {
        private int _id;
        private string _name;
        private string _description;
        private decimal _price;
        private decimal _price_promo;
        private string _thumb;
        private string _img;
        private string _unit;
        private decimal _percent_promo;
        private int _rating;
        private int _sold;
        private decimal _point;
        private int _type;
        private int _status;
        private string _username;
        private string _modified;

        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public decimal Price { get => _price; set => _price = value; }
        public decimal Price_promo { get => _price_promo; set => _price_promo = value; }
        public string Thumb { get => _thumb; set => _thumb = value; }
        public string Img { get => _img; set => _img = value; }
        public string Unit { get => _unit; set => _unit = value; }
        public decimal Percent_promo { get => _percent_promo; set => _percent_promo = value; }
        public int Rating { get => _rating; set => _rating = value; }
        public int Sold { get => _sold; set => _sold = value; }
        public decimal Point { get => _point; set => _point = value; }
        public int Type { get => _type; set => _type = value; }
        public int Status { get => _status; set => _status = value; }
        public string Username { get => _username; set => _username = value; }
        public string Modified { get => _modified; set => _modified = value; }
        public int Id { get => _id; set => _id = value; }

        public Food (int id)
        {
            this._id = id;
        }
        public Food ()
        {

        }
        public Food(string _name, string _Description, decimal _Price, decimal _Price_promo, string _Thumb, string _Img, string _Unit, decimal _Percent_promo , int _Rating, int _Sold, decimal _Point , int _Type,int _Status, string _Username , string _Modified)
        {
            
            this._name = _name;
            this._description = _Description;
            this._price = _Price;
            this._price_promo = _Price_promo;
            this._thumb = _Thumb;
            this._img = _Img;
            this._unit = _Unit;
            this._percent_promo = _Percent_promo;
            this._rating = _Rating;
            this._sold = _Sold;
            this._point = _Point;
            this._type = _Type;
            this._status = _Status;
            this._username = _Username;
            this._modified = _Modified;
        }
        public bool AddFood()
        {
            string ketnoi = "INSERT INTO [dbo].[food] ([name] ,[description] ,[price] ,[price_promo] ,[thumb] ,[img] ,[unit] ,[percent_promo] ,[rating] ,[sold] ,[point] ,[type] ,[status] ,[username] ,[modified]) VALUES(@name,@desc ,@price ,@price_promo ,@thump ,@img ,@unit,@precent ,@rating ,@sold,@point ,@type,@status,@username ,@modified)";
            SqlParameter[] paras = {
               new SqlParameter("@name", SqlDbType.NVarChar, 50){ Value = this.Name },
               new SqlParameter("@desc", SqlDbType.Text){ Value = this.Description},
               new SqlParameter("@price", SqlDbType.Decimal,10){ Value = this.Price},
               new SqlParameter("@price_promo", SqlDbType.Decimal,10){ Value = this.Price_promo},
               new SqlParameter("@thump", SqlDbType.NVarChar, 255){ Value = this.Thumb},
               new SqlParameter("@img", SqlDbType.NVarChar, 255){ Value = this.Img},
               new SqlParameter("@unit", SqlDbType.NVarChar,10){ Value = this.Unit},
               new SqlParameter("@precent",SqlDbType.Decimal,10){Value=this.Percent_promo},
               new SqlParameter("@rating",SqlDbType.Int){Value=this.Rating},
               new SqlParameter("@sold",SqlDbType.Int){Value=this.Sold},
               new SqlParameter("@point",SqlDbType.Decimal,10){Value=this.Point},
               new SqlParameter("@type",SqlDbType.Int){Value=this.Type},
               new SqlParameter("@status",SqlDbType.Int){Value=this.Status},
               new SqlParameter("@username",SqlDbType.NVarChar, 50){Value=this.Username},
               new SqlParameter("@modified",SqlDbType.NVarChar,50){Value=this.Modified},

                 };

            return DataProvider.executeNonQuery(ketnoi, paras);
        }
        public DataTable getId(int id)
        {
            string sQuery = "SELECT * FROM[dbo].[food] WHERE [id] = '" + id + "'";
            return DataProvider.getUserName(sQuery);
        }

        public bool updateFood( int id)
        {
            string sQuery = " UPDATE[dbo].[food] SET [name] = @name ,[description] = @desc ,[price] = @price ,[price_promo] = @price_promo ,[thumb] = @thumb,[img] = @img,[unit] = @unit,[percent_promo] = @percent,[rating] = @rating,[sold] = @sold ,[point] = @point,[type] = @type ,[status] = @status,[username] = @username,[modified] = @modified WHERE [id] = @id";
              SqlParameter[] paras = {
                   new SqlParameter("@id" , SqlDbType.Int){Value = id},
                   new SqlParameter("@name", SqlDbType.NVarChar, 50){ Value = this.Name },

                   new SqlParameter("@desc", SqlDbType.Text){ Value = this.Description},
                   new SqlParameter("@price", SqlDbType.Decimal,10){ Value = this.Price},
                   new SqlParameter("@price_promo", SqlDbType.Decimal,10){ Value = this.Price_promo},
                   new SqlParameter("@thumb", SqlDbType.NVarChar, 255){ Value = this.Thumb},
                   new SqlParameter("@img", SqlDbType.NVarChar, 255){ Value = this.Img},
                   new SqlParameter("@unit", SqlDbType.NVarChar,10){ Value = this.Unit},
                   new SqlParameter("@percent",SqlDbType.Decimal,10){Value=this.Percent_promo},
                   new SqlParameter("@rating",SqlDbType.Int){Value=this.Rating},
                   new SqlParameter("@sold",SqlDbType.Int){Value=this.Sold},
                   new SqlParameter("@point",SqlDbType.Decimal,10){Value=this.Point},
                   new SqlParameter("@type",SqlDbType.Int){Value=this.Type},
                   new SqlParameter("@status",SqlDbType.Int){Value=this.Status},
                   new SqlParameter("@username",SqlDbType.NVarChar, 50){Value=this.Username},
                   new SqlParameter("@modified",SqlDbType.NVarChar,50){Value=this.Modified},

              };

            return DataProvider.executeNonQuery(sQuery,paras);
        }
        public DataTable dataFood()
        {
            string sQuery = "SELECT * FROM [dbo].[food]";
            return DataProvider.getUserName(sQuery);
        }
        public bool delect()
        {
            string sQuery = "DELETE FROM [dbo].[food] WHERE [id] = '" + this.Id + "'";
            // SqlParameter sqlParams = new SqlParameter("@username", SqlDbType.VarChar, 50) { Value = this.UserName };


            return DataProvider.deleteUsername(sQuery);
        }
        public DataTable timKiem(string text)
        {
            string sQuery = "select * from food where name like '%" + text + "%'";
            return DataProvider.getUserName(sQuery);
        }
    }
}