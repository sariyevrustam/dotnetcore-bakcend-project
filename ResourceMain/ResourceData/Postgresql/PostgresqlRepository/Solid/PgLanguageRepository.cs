using Npgsql;
using ResourceData.Postgresql.Models.BaseModelClasses;
using ResourceData.Postgresql.Models.Outputs;
using ResourceData.Postgresql.PostgresqlRepository.Abstract;
using ResourceData.Postgresql.Utils;
using ResourceData.Settings;
using ResourceDomainCore.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceData.Postgresql.PostgresqlRepository.Solid
{
    public class PgLanguageRepository : MainPgRepository, ILanguageRepository
    {
        public PgLanguageRepository(DbSettings _dbSettings, IEventBus _bus) : base(_dbSettings, _bus) { }

        public ItemResult GetAll()
        {
            ItemResult itemResult = new ItemResult();

            using (NpgsqlConnection connection = this.CreateConnection())
            {
                try
                {
                    connection.Open();
                    this.CreateFunctionCallQuery(LibraryFunctions.fn_language_get_all, connection);

                    NpgsqlDataReader dataReader = null;
                    dataReader = this.Cmd.ExecuteReader();
                    using (dataReader)
                    {
                        while (dataReader.Read())
                        {
                            itemResult.Item = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Language>>((string)dataReader[0]);
                        }
                    }
                    connection.Close();
                }
                catch (PostgresException e)
                {
                    itemResult.Code = e.MessageText;
                    itemResult.Message = LibraryErrorMessages.GetErrorMessage(itemResult.Code);
                }
                catch (NpgsqlException e)
                {
                    itemResult.Code = (e.ErrorCode).ToString();
                    itemResult.Message = LibraryErrorMessages.GetErrorMessage(itemResult.Code);
                }
            }

            return itemResult;
        }
    }
}
