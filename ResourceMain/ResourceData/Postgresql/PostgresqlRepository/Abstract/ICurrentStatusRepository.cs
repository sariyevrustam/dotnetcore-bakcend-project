using ResourceData.Postgresql.Models.BaseModelClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceData.Postgresql.PostgresqlRepository.Abstract
{
    public interface ICurrentStatusRepository
    {
        public ItemResult GetAll();
    }
}
