using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using System.Data;

namespace Data
{
    public class OrderNumberData : DataAccessComponent
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <returns></returns>
        public OrderNumber Create(OrderNumber orderN)
        {
            const string sqlStatement = "INSERT INTO dbo.OrderNumber([Number], [CreatedBy]) " +
                "VALUES(@Number, @CreatedBy); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Number", DbType.String, orderN.Number);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, orderN.CreatedBy);
                // Obtener el valor de la primary key.
                orderN.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return orderN;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderNumber"></param>
        public void UpdateById(OrderNumber orderN)
        {
            const string sqlStatement = "UPDATE dbo.OrderNumber " +
                "SET [Number]=@Number, " +
                    "[ChangedOn]=@ChangedOn, " +
                    "[ChangedBy]=@ChangedBy " +
                "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Number", DbType.String, orderN.Number);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, orderN.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, orderN.ChangedBy);
                db.AddInParameter(cmd, "@Id", DbType.Int32, orderN.Id);
                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.OrderNumber WHERE [Id]=@Id ";
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OrderNumber SelectById(int id)
        {
            const string sqlStatement = "SELECT [Id], [Number], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] " +
                "FROM dbo.OrderNumber WHERE [Id]=@Id ";

            OrderNumber orderN = null;
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (var dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read()) orderN = LoadOrderNumber(dr);
                }
            }

            return orderN;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>		
        public List<OrderNumber> Select()
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [Id], [Number], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.OrderNumber ";

            var result = new List<OrderNumber>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var orderN = LoadOrderNumber(dr); // Mapper
                        result.Add(orderN);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Crea un nuevo OrderNumber desde un Datareader.
        /// </summary>
        /// <param name="dr">Objeto DataReader.</param>
        /// <returns>Retorna un objeto OrderNumber.</returns>		
        private static OrderNumber LoadOrderNumber(IDataReader dr)
        {
            var orderN = new OrderNumber
            {
                Id = GetDataValue<int>(dr, "Id"),
                Number = GetDataValue<int>(dr, "Number"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };

            return orderN;
        }

    }
}
