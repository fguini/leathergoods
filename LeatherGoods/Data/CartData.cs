using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using System.Data;

namespace Data
{
    public class CartData : DataAccessComponent
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public Cart Create(Cart cart)
        {
            const string sqlStatement = "INSERT INTO dbo.Cart ([Cookie], [CreatedBy]) " +
                "VALUES(@Cookie, @CreatedBy); SELECT SCOPE_IDENTITY();";

            //var db = DatabaseFactory.CreateDatabase(ConnectionName);
            //using (var cmd = db.GetSqlStringCommand(sqlStatement))
            //{
            //    db.AddInParameter(cmd, "@Cookie", DbType.String, cart.Cookie);
            //    db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, cart.CreatedBy);
            //    // Obtener el valor de la primary key.
            //    cart.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            //}

            return cart;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cart"></param>
        public void UpdateById(Cart cart)
        {
            const string sqlStatement = "UPDATE dbo.Cart " +
                "SET [Cookie]=@Cookie, " +
                    "[ChangedOn]=@ChangedOn, " +
                    "[ChangedBy]=@ChangedBy " +
                "WHERE [Id]=@Id ";

            //var db = DatabaseFactory.CreateDatabase(ConnectionName);
            //using (var cmd = db.GetSqlStringCommand(sqlStatement))
            //{
            //    db.AddInParameter(cmd, "@Cookie", DbType.String, cart.Cookie);
            //    db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, cart.ChangedOn);
            //    db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, cart.ChangedBy);
            //    db.AddInParameter(cmd, "@Id", DbType.Int32, cart.Id);
            //    db.ExecuteNonQuery(cmd);
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.Cart WHERE [Id]=@Id ";
            //var db = DatabaseFactory.CreateDatabase(ConnectionName);
            //using (var cmd = db.GetSqlStringCommand(sqlStatement))
            //{
            //    db.AddInParameter(cmd, "@Id", DbType.Int32, id);
            //    db.ExecuteNonQuery(cmd);
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Cart SelectById(int id)
        {
            const string sqlStatement = "SELECT [Id], [Cookie], [CartDate], [ItemCount], [Rowid], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] " +
                "FROM dbo.Cart WHERE [Id]=@Id ";

            Cart cart = null;
            //var db = DatabaseFactory.CreateDatabase(ConnectionName);
            //using (var cmd = db.GetSqlStringCommand(sqlStatement))
            //{
            //    db.AddInParameter(cmd, "@Id", DbType.Int32, id);
            //    using (var dr = db.ExecuteReader(cmd))
            //    {
            //        if (dr.Read()) cart = LoadCart(dr);
            //    }
            //}

            return cart;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>		
        public List<Cart> Select()
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [Id], [Cookie], [CartDate], [ItemCount], [Rowid], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.Cart ";

            var result = new List<Cart>();
            //var db = DatabaseFactory.CreateDatabase(ConnectionName);
            //using (var cmd = db.GetSqlStringCommand(sqlStatement))
            //{
            //    using (var dr = db.ExecuteReader(cmd))
            //    {
            //        while (dr.Read())
            //        {
            //            var cart = LoadCart(dr); // Mapper
            //            result.Add(cart);
            //        }
            //    }
            //}

            return result;
        }

        /// <summary>
        /// Crea un nuevo Cart desde un Datareader.
        /// </summary>
        /// <param name="dr">Objeto DataReader.</param>
        /// <returns>Retorna un objeto Cart.</returns>		
        private static Cart LoadCart(IDataReader dr)
        {
            var cart = new Cart
            {
                Id = GetDataValue<int>(dr, "Id"),
                Cookie = GetDataValue<string>(dr, "Cookie"),
                CartDate = GetDataValue<DateTime>(dr, "CartDate"),
                ItemCount = GetDataValue<int>(dr, "ItemCount"),
                Rowid = GetDataValue<Guid>(dr, "Rowid"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };
            return cart;
        }

    }
}
