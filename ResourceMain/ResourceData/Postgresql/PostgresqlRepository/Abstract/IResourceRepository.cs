using ResourceData.Postgresql.Models.BaseModelClasses;
using ResourceData.Postgresql.Models.Inputs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceData.Postgresql.PostgresqlRepository.Abstract
{
    public interface IResourceRepository : IGenericPgRepository<InResource>
    {
        public ItemResult CheckAvailabilityForBasket(InBasket inBasket);
    }
}
