using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using System.Data;

namespace Data
{
    /// <summary>
    /// 
    /// </summary>
    public class CartItemData : DataAccessComponent
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cartitem"></param>
        /// <returns></returns>
        public CartItem Create(CartItem cartitem)
        {
            const string sqlStatement = "INSERT INTO dbo.CartItem ([CartId], [ProductId], [Price] , [Quantity], [CreatedBy]) " +
                "VALUES(@CartId, @ProductId, @Price, @Quantity, @CreatedBy); SELECT SCOPE_IDENTITY();";

            //var db = DatabaseFactory.CreateDatabase(ConnectionName);
            //using (var cmd = db.GetSqlStringCommand(sqlStatement))
            //{
            //    db.AddInParameter(cmd, "@CartId", DbType.Int32, cartitem.CartId);
            //    db.AddInParameter(cmd, "@ProductId", DbType.Int32, cartitem.ProductId);
            //    db.AddInParameter(cmd, "@Price", DbType.Decimal, cartitem.Price);
            //    db.AddInParameter(cmd, "@Quantity", DbType.Int32, cartitem.Quantity);
            //    db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, cartitem.CreatedBy);
            //    // Obtener el valor de la primary key.
            //    cartitem.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            //}

            return cartitem;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cartiitem"></param>
        public void UpdateById(CartItem cartitem)
        {
            const string sqlStatement = "UPDATE dbo.CartItem " +
                "SET [ProductId]=@ProductId, " +
                    "[Price]=@Price, " +
                    "[Quantity]=@Quantity, " + 
                    "[ChangedOn]=@ChangedOn, " +
                    "[ChangedBy]=@ChangedBy " +
                "WHERE [Id]=@Id ";

            //var db = DatabaseFactory.CreateDatabase(ConnectionName);
            //using (var cmd = db.GetSqlStringCommand(sqlStatement))
            //{
            //    db.AddInParameter(cmd, "@CartId", DbType.Int32, cartitem.CartId);
            //    db.AddInParameter(cmd, "@ProductId", DbType.Int32, cartitem.ProductId);
            //    db.AddInParameter(cmd, "@Price", DbType.Decimal, cartitem.Price);
            //    db.AddInParameter(cmd, "@Quantity", DbType.Int32, cartitem.Quantity);
            //    db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, cartitem.ChangedOn);
            //    db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, cartitem.ChangedBy);
            //    db.AddInParameter(cmd, "@Id", DbType.Int32, cartitem.Id);
            //    db.ExecuteNonQuery(cmd);
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.CartItem WHERE [Id]=@Id ";
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
        public CartItem SelectById(int id)
        {
            const string sqlStatement = "SELECT [Id], [CartId], [ProductId], [Price], [Quantity], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] " +
                "FROM dbo.CartItem WHERE [Id]=@Id ";

            CartItem cartitem = null;
            //var db = DatabaseFactory.CreateDatabase(ConnectionName);
            //using (var cmd = db.GetSqlStringCommand(sqlStatement))
            //{
            //    db.AddInParameter(cmd, "@Id", DbType.Int32, id);
            //    using (var dr = db.ExecuteReader(cmd))
            //    {
            //        if (dr.Read()) cartitem = LoadCartItem(dr);
            //    }
            //}

            return cartitem;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>		
        public List<CartItem> Select()
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [Id], [CartId], [ProductId], [Price] , [Quantity], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.CartItem ";

            var result = new List<CartItem>();
            //var db = DatabaseFactory.CreateDatabase(ConnectionName);
            //using (var cmd = db.GetSqlStringCommand(sqlStatement))
            //{
            //    using (var dr = db.ExecuteReader(cmd))
            //    {
            //        while (dr.Read())
            //        {
            //            var cartitem = LoadCartItem(dr); // Mapper
            //            result.Add(cartitem);
            //        }
            //    }
            //}

            return result;
        }

        /// <summary>
        /// Crea un nuevo CartItem desde un Datareader.
        /// </summary>
        /// <param name="dr">Objeto DataReader.</param>
        /// <returns>Retorna un objeto CartItem.</returns>		
        private static CartItem LoadCartItem(IDataReader dr)
        {
            var cartitem = new CartItem
            {
                Id = GetDataValue<int>(dr, "Id"),
                CartId = GetDataValue<int>(dr, "CartId"),
                ProductId = GetDataValue<int>(dr, "ProductId"),
                Price = GetDataValue<double>(dr, "Price"),
                Quantity = GetDataValue<int>(dr, "Quantity"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };
            return cartitem;
        }

    }
}
