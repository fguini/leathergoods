using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using System.Data;

namespace Data
{
    public class OrderData : DataAccessComponent
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public Order Create(Order order)
        {
            const string sqlStatement = "INSERT INTO dbo.Order ([ClientId], [OrderDate], [TotalPrice], [State], [OrderNumber], [CreatedBy]) " +
                "VALUES(@ClientId, @OrderDate, @TotalPrice, @State, @OrderNumber, @CreatedBy); SELECT SCOPE_IDENTITY();";

            //var db = DatabaseFactory.CreateDatabase(ConnectionName);
            //using (var cmd = db.GetSqlStringCommand(sqlStatement))
            //{
            //    db.AddInParameter(cmd, "@ClientId", DbType.Int32, order.ClientId);
            //    db.AddInParameter(cmd, "@OrderDate", DbType.DateTime2, order.OrderDate);
            //    db.AddInParameter(cmd, "@TotalPrice", DbType.Decimal, order.TotalPrice);
            //    db.AddInParameter(cmd, "@State", DbType.String, order.State);    
            //    db.AddInParameter(cmd, "@OrderNumber", DbType.Int32, order.OrderNumber);
            //    db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, order.CreatedBy);
            //    // Obtener el valor de la primary key.
            //    order.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            //}

            return order;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        public void UpdateById(Order order)
        {
            const string sqlStatement = "UPDATE dbo.Order " +
                "SET [ClientId]=@ClientId, " +
                    "[TotalPrice]=@TotalPrice, " +
                    "[State]=@State, " +
                    "[OrderNumber]=@OrderNumber, " +
                    "[ChangedOn]=@ChangedOn, " +
                    "[ChangedBy]=@ChangedBy " +
                "WHERE [Id]=@Id ";

            //var db = DatabaseFactory.CreateDatabase(ConnectionName);
            //using (var cmd = db.GetSqlStringCommand(sqlStatement))
            //{
            //    db.AddInParameter(cmd, "@ClientId", DbType.Int32, order.ClientId);
            //    db.AddInParameter(cmd, "@TotalPrice", DbType.Decimal, order.TotalPrice);
            //    db.AddInParameter(cmd, "@State", DbType.String, order.State);
            //    db.AddInParameter(cmd, "@OrderNumber", DbType.Int32, order.OrderNumber);
            //    db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, order.CreatedBy);
            //    db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, order.ChangedOn);
            //    db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, order.ChangedBy);
            //    db.AddInParameter(cmd, "@Id", DbType.Int32, order.Id);
            //    db.ExecuteNonQuery(cmd);
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.Order WHERE [Id]=@Id ";
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
        public Order SelectById(int id)
        {
            const string sqlStatement = "SELECT [Id], [ClientId], [OrderDate], [TotalPrice], [State], [OrderNumber], [ItemCount], [Rowid], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] " +
                "FROM dbo.Order WHERE [Id]=@Id ";

            Order order = null;
            //var db = DatabaseFactory.CreateDatabase(ConnectionName);
            //using (var cmd = db.GetSqlStringCommand(sqlStatement))
            //{
            //    db.AddInParameter(cmd, "@Id", DbType.Int32, id);
            //    using (var dr = db.ExecuteReader(cmd))
            //    {
            //        if (dr.Read()) order = LoadOrder(dr);
            //    }
            //}

            return order;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>		
        public List<Order> Select()
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [Id], [ClientId], [OrderDate], [TotalPrice], [State], [OrderNumber], [ItemCount], [Rowid], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.Order";

            var result = new List<Order>();
            //var db = DatabaseFactory.CreateDatabase(ConnectionName);
            //using (var cmd = db.GetSqlStringCommand(sqlStatement))
            //{
            //    using (var dr = db.ExecuteReader(cmd))
            //    {
            //        while (dr.Read())
            //        {
            //            var order = LoadOrder(dr); // Mapper
            //            result.Add(order);
            //        }
            //    }
            //}

            return result;
        }

        /// <summary>
        /// Crea una nueva Order desde un Datareader.
        /// </summary>
        /// <param name="dr">Objeto DataReader.</param>
        /// <returns>Retorna un objeto Order.</returns>		
        private static Order LoadOrder(IDataReader dr)
        {
            var order = new Order
            {
                Id = GetDataValue<int>(dr, "Id"),
                ClientId = GetDataValue<int>(dr, "ClientId"),
                OrderDate = GetDataValue<DateTime>(dr, "OrderDate"),
                TotalPrice = GetDataValue<float>(dr, "TotalPrice"),
                State = GetDataValue<int>(dr, "State"),
                OrderNumber = GetDataValue<int>(dr, "OrderNumber"),
                ItemCount = GetDataValue<int>(dr, "ItemCount"),
                Rowid = GetDataValue<Guid>(dr, "Rowid"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };

            return order;
        }

    }
}
