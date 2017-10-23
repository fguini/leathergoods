using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using System.Data;

namespace Data
{
    public class ClientData : DataAccessComponent
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public Client Create(Client client)
        {
            const string sqlStatement = "INSERT INTO dbo.Client ([FirstName], [LastName], [Email], [CountryId], [AspNetUsers], [City], [CreatedBy]) " +
                "VALUES(@FirstName, @LastName, @Email, @CountryId, @AspNetUsers, @City, @CreatedBy); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@FirstName", DbType.String, client.FirstName);
                db.AddInParameter(cmd, "@LastName", DbType.String, client.LastName);
                db.AddInParameter(cmd, "@Email", DbType.String, client.Email);
                db.AddInParameter(cmd, "@CountryId", DbType.Int32, client.CountryId);
                db.AddInParameter(cmd, "@AspNetUsers", DbType.String, client.AspNetUsers);
                db.AddInParameter(cmd, "@City", DbType.String, client.City);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, client.CreatedBy);
                // Obtener el valor de la primary key.
                client.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return client;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        public void UpdateById(Client client)
        {
            const string sqlStatement = "UPDATE dbo.Client " +
                "SET [FirstName]=@FirstName, " +
                    "[LastName]=@LastName, " +
                    "[Email]=@Email, " +
                    "[CountryId]=@CountryId, " +
                    "[AspNetUsers]=@AspNetUsers, " +
                    "[City]=@City, " +
                    "[OrderCount]=@OrderCount, " +
                    "[ChangedOn]=@ChangedOn, " +
                    "[ChangedBy]=@ChangedBy " +
                "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@FirstName", DbType.String, client.FirstName);
                db.AddInParameter(cmd, "@LastName", DbType.String, client.LastName);
                db.AddInParameter(cmd, "@Email", DbType.String, client.Email);
                db.AddInParameter(cmd, "@CountryId", DbType.Int32, client.CountryId);
                db.AddInParameter(cmd, "@AspNetUsers", DbType.String, client.AspNetUsers);
                db.AddInParameter(cmd, "@City", DbType.String, client.City);
                db.AddInParameter(cmd, "@OrderCount", DbType.Int32, client.OrderCount);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, client.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, client.ChangedBy);
                db.AddInParameter(cmd, "@Id", DbType.Int32, client.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.Client WHERE [Id]=@Id ";
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
        public Client SelectById(int id)
        {
            const string sqlStatement = "SELECT [Id], [FirstName], [LastName], [Email], [CountryId], [AspNetUsers], [City], [SignupDate], [Rowid], [OrderCount], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] " +
                "FROM dbo.Client WHERE [Id]=@Id ";

            Client client = null;
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (var dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read()) client = LoadClient(dr);
                }
            }

            return client;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>		
        public List<Client> Select()
        {
            // WARNING! Performance
            const string sqlStatement = "SELECT [Id], [FirstName], [LastName], [Email], [CountryId], [AspNetUsers], [City], [SignupDate], [Rowid], [OrderCount], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.Client ";

            var result = new List<Client>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var client = LoadClient(dr); // Mapper
                        result.Add(client);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Crea un nuevo Cliente desde un Datareader.
        /// </summary>
        /// <param name="dr">Objeto DataReader.</param>
        /// <returns>Retorna un objeto Cliente.</returns>		
        private static Client LoadClient(IDataReader dr)
        {
            var client = new Client
            {
                Id = GetDataValue<int>(dr, "Id"),
                FirstName = GetDataValue<string>(dr, "FirstName"),
                LastName = GetDataValue<string>(dr, "LastName"),
                Email = GetDataValue<string>(dr, "Email"),
                CountryId = GetDataValue<int>(dr, "CountryId"),
                AspNetUsers = GetDataValue<string>(dr, "AspNetUsers"),
                City = GetDataValue<string>(dr, "City"),
                SignupDate = GetDataValue<DateTime>(dr, "SignupDate"),
                Rowid = GetDataValue<Guid>(dr, "Rowid"),
                OrderCount = GetDataValue<int>(dr, "OrderCount"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };
            return client;
        }

    }
}
