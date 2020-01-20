using Newtonsoft.Json;
using Npgsql;
using NpgsqlTypes;
using ResourceData.Postgresql.Models.BaseModelClasses;
using ResourceData.Postgresql.Models.Inputs;
using ResourceData.Postgresql.Models.Inputs.AcceptedBasket;
using ResourceData.Postgresql.Models.Inputs.BasketByUser;
using ResourceData.Postgresql.Models.Inputs.ReturnedResource;
using ResourceData.Postgresql.Models.Inputs.ReturningBookshelfResources;
using ResourceData.Postgresql.Models.Outputs;
using ResourceData.Postgresql.Models.Outputs.OutBasketInventors;
using ResourceData.Postgresql.PostgresqlRepository.Abstract;
using ResourceData.Postgresql.Utils;
using ResourceData.Settings;
using ResourceDomainCore.Bus;
using System;
using System.Collections.Generic;

namespace ResourceData.Postgresql.PostgresqlRepository.Solid
{
    public class PgResourceRepository : MainPgRepository, IResourceRepository
    {
        public PgResourceRepository(DbSettings _dbSettings, IEventBus _bus) : base(_dbSettings, _bus) { }

        public ItemResult Get(int resourceId)
        {
            ItemResult itemResult = new ItemResult();

            using (NpgsqlConnection connection = this.CreateConnection())
            {
                try
                {
                    connection.Open();
                    this.CreateFunctionCallQuery(LibraryFunctions.fn_resource_get, connection);
                    this.Cmd.Parameters.AddWithValue("p_resource_id", resourceId);

                    NpgsqlDataReader dataReader = null;
                    dataReader = this.Cmd.ExecuteReader();
                    using (dataReader)
                    {
                        while (dataReader.Read())
                        {
                            itemResult.Item = JsonConvert.DeserializeObject<Resource>((string)dataReader[0]);
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

        public ItemResult GetAll()
        {
            ItemResult itemResult = new ItemResult();

            using (NpgsqlConnection connection = this.CreateConnection())
            {
                try
                {
                    connection.Open();
                    this.CreateFunctionCallQuery(LibraryFunctions.fn_resource_get_all, connection);

                    NpgsqlDataReader dataReader = null;
                    dataReader = this.Cmd.ExecuteReader();
                    using (dataReader)
                    {
                        while (dataReader.Read())
                        {
                            itemResult.Item = JsonConvert.DeserializeObject<List<Resource>>((string)dataReader[0]);
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

        public ItemResult Delete(int resourceId, int deletedBy)
        {
            ItemResult itemResult = new ItemResult();

            using (NpgsqlConnection connection = this.CreateConnection())
            {
                try
                {
                    connection.Open();
                    this.CreateFunctionCallQuery(LibraryFunctions.fn_resource_delete, connection);
                    this.Cmd.Parameters.AddWithValue("p_resource_id", resourceId);
                    this.Cmd.Parameters.AddWithValue("p_deleted_by", deletedBy);

                    NpgsqlDataReader dataReader = null;
                    dataReader = this.Cmd.ExecuteReader();
                    using (dataReader)
                    {
                        while (dataReader.Read())
                        {
                            itemResult.Item = dataReader[0];
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

        public ItemResult Add(InResource newResource)
        {
            ItemResult itemResult = new ItemResult();

            using (NpgsqlConnection connection = this.CreateConnection())
            {
                try
                {
                    connection.Open();
                    this.CreateFunctionCallQuery(LibraryFunctions.fn_resource_add, connection);                    
                    this.Cmd.Parameters.AddWithValue("p_category_id", newResource.CategoryId);
                    this.Cmd.Parameters.AddWithValue("p_resource_name", newResource.ResourceName);
                    this.Cmd.Parameters.AddWithValue("p_shelf", newResource.Shelf);
                    this.Cmd.Parameters.AddWithValue("p_catalogue", newResource.Catalogue);
                    this.Cmd.Parameters.AddWithValue("p_publish_year", newResource.PublishYear);
                    this.Cmd.Parameters.AddWithValue("p_card_number", newResource.CardNumber);
                    this.Cmd.Parameters.AddWithValue("p_rfid", newResource.Rfid);
                    this.Cmd.Parameters.AddWithValue("p_resource_type_id", newResource.ResourceTypeId);
                    this.Cmd.Parameters.AddWithValue("p_author_id", newResource.AuthorId);
                    this.Cmd.Parameters.AddWithValue("p_book_location_id", newResource.BookLocationId);
                    this.Cmd.Parameters.AddWithValue("p_catalogue_id", newResource.CatalogId);

                    NpgsqlDataReader dataReader = null;
                    dataReader = this.Cmd.ExecuteReader();
                    using (dataReader)
                    {
                        while (dataReader.Read())
                        {
                            itemResult.Item = dataReader[0];
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

        public ItemResult Edit(int resourceId, int updatedBy, InResource editedResource)
        {
            ItemResult itemResult = new ItemResult();

            using (NpgsqlConnection connection = this.CreateConnection())
            {
                try
                {
                    connection.Open();
                    this.CreateFunctionCallQuery(LibraryFunctions.fn_resource_edit, connection);
                    this.Cmd.Parameters.AddWithValue("p_resource_id", resourceId);
                    this.Cmd.Parameters.AddWithValue("p_updated_by", updatedBy);
                    this.Cmd.Parameters.AddWithValue("p_category_id", editedResource.CategoryId);
                    this.Cmd.Parameters.AddWithValue("p_resource_name", editedResource.ResourceName);
                    this.Cmd.Parameters.AddWithValue("p_shelf", editedResource.Shelf);
                    this.Cmd.Parameters.AddWithValue("p_catalogue", editedResource.Catalogue);
                    this.Cmd.Parameters.AddWithValue("p_publish_year", editedResource.PublishYear);
                    this.Cmd.Parameters.AddWithValue("p_card_number", editedResource.CardNumber);
                    this.Cmd.Parameters.AddWithValue("p_rfid", editedResource.Rfid);
                    this.Cmd.Parameters.AddWithValue("p_resource_type_id", editedResource.ResourceTypeId);
                    this.Cmd.Parameters.AddWithValue("p_author_id", editedResource.AuthorId);
                    this.Cmd.Parameters.AddWithValue("p_book_location_id", editedResource.BookLocationId);
                    this.Cmd.Parameters.AddWithValue("p_catalogue_id", editedResource.CatalogId);

                    NpgsqlDataReader dataReader = null;
                    dataReader = this.Cmd.ExecuteReader();
                    using (dataReader)
                    {
                        while (dataReader.Read())
                        {
                            itemResult.Item = dataReader[0];
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

        public ItemResult CheckAvailabilityForBasket(InBasket inBasket)
        {
            ItemResult itemResult = new ItemResult();

            using (NpgsqlConnection connection = this.CreateConnection())
            {
                try
                {
                    connection.Open();
                    this.CreateFunctionCallQuery(LibraryFunctions.fn_resource_check_basket, connection);
                    this.Cmd.Parameters.AddWithValue("p_basket", JsonConvert.SerializeObject(inBasket));
                    NpgsqlDataReader dataReader = null;
                    dataReader = this.Cmd.ExecuteReader();
                    using (dataReader)
                    {
                        while (dataReader.Read())
                        {
                            itemResult.Item = JsonConvert.DeserializeObject<InCheckedBasketByUser>((string)dataReader[0]);
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

        public ItemResult CheckBasketResourcesByInventorNumbers(BasketInventors inBasketInventors)
        {
            ItemResult itemResult = new ItemResult();

            using (NpgsqlConnection connection = this.CreateConnection())
            {
                try
                {
                    connection.Open();
                    this.CreateFunctionCallQuery(LibraryFunctions.fn_resource_check_basket_resource_by_inventor_no, connection);
                    this.Cmd.Parameters.AddWithValue("p_basket_resource_inventor_numbers", JsonConvert.SerializeObject(inBasketInventors));
                    NpgsqlDataReader dataReader = null;
                    dataReader = this.Cmd.ExecuteReader();
                    using (dataReader)
                    {
                        while (dataReader.Read())
                        {
                            itemResult.Item = JsonConvert.DeserializeObject<OutBasketInventors>((string)dataReader[0]);
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

        public ItemResult DoubleCheckBasketResources(InAcceptedBasket inAcceptedBasket)
        {
            ItemResult itemResult = new ItemResult();

            using (NpgsqlConnection connection = this.CreateConnection())
            {
                try
                {
                    connection.Open();
                    this.CreateFunctionCallQuery(LibraryFunctions.fn_resource_double_check_basket_resources, connection);
                    this.Cmd.Parameters.AddWithValue("p_accepted_basket_by_oprator", JsonConvert.SerializeObject(inAcceptedBasket));
                    NpgsqlDataReader dataReader = null;
                    dataReader = this.Cmd.ExecuteReader();
                    using (dataReader)
                    {
                        while (dataReader.Read())
                        {
                            itemResult.Item = JsonConvert.DeserializeObject<InAcceptedBasket>((string)dataReader[0]);
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

        public ItemResult GetByInventarNumbers(ReturnedResources returnedResources)
        {
            ItemResult itemResult = new ItemResult();

            using (NpgsqlConnection connection = this.CreateConnection())
            {
                try
                {
                    connection.Open();
                    this.CreateFunctionCallQuery(LibraryFunctions.fn_resource_get_by_inventar_number, connection);
                    this.Cmd.Parameters.AddWithValue("p_returned_resources", JsonConvert.SerializeObject(returnedResources));
                    NpgsqlDataReader dataReader = null;
                    dataReader = this.Cmd.ExecuteReader();
                    using (dataReader)
                    {
                        while (dataReader.Read())
                        {
                            itemResult.Item = JsonConvert.DeserializeObject<ReturnedResources>((string)dataReader[0]);
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

        public ItemResult GetAvailableResourceCopyCount(InReturningBookshelfResourceCollection inReturningBookshelfResourceCollection)
        {
            ItemResult itemResult = new ItemResult();

            using (NpgsqlConnection connection = this.CreateConnection())
            {
                try
                {
                    connection.Open();
                    this.CreateFunctionCallQuery(LibraryFunctions.fn_resource_get_available_resource_copy_count, connection);
                    this.Cmd.Parameters.AddWithValue("p_returned_resource_collection", JsonConvert.SerializeObject(inReturningBookshelfResourceCollection));
                    NpgsqlDataReader dataReader = null;
                    dataReader = this.Cmd.ExecuteReader();
                    using (dataReader)
                    {
                        while (dataReader.Read())
                        {
                            itemResult.Item = JsonConvert.DeserializeObject<ReturnedResources>((string)dataReader[0]);
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

        public ItemResult GetByCategory(int categoryId)
        {
            ItemResult itemResult = new ItemResult();

            using (NpgsqlConnection connection = this.CreateConnection())
            {
                try
                {
                    connection.Open();
                    this.CreateFunctionCallQuery(LibraryFunctions.fn_resource_get_by_category, connection);
                    this.Cmd.Parameters.AddWithValue("p_category_id", categoryId);

                    NpgsqlDataReader dataReader = null;
                    dataReader = this.Cmd.ExecuteReader();
                    using (dataReader)
                    {
                        while (dataReader.Read())
                        {
                            itemResult.Item = JsonConvert.DeserializeObject<List<DetailedResource>>((string)dataReader[0]);
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

        public ItemResult GetAllByCategory(int categoryId)
        {
            ItemResult itemResult = new ItemResult();

            using (NpgsqlConnection connection = this.CreateConnection())
            {
                try
                {
                    connection.Open();
                    this.CreateFunctionCallQuery(LibraryFunctions.fn_resource_get_all_by_category, connection);
                    this.Cmd.Parameters.AddWithValue("p_category_id", categoryId);

                    NpgsqlDataReader dataReader = null;
                    dataReader = this.Cmd.ExecuteReader();
                    using (dataReader)
                    {
                        while (dataReader.Read())
                        {
                            itemResult.Item = JsonConvert.DeserializeObject<List<DetailedResource>>((string)dataReader[0]);
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
