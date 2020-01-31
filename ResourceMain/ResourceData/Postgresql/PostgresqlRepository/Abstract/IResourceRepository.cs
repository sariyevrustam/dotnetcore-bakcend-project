using ResourceData.Postgresql.Models.BaseModelClasses;
using ResourceData.Postgresql.Models.Inputs;
using ResourceData.Postgresql.Models.Inputs.AcceptedBasket;
using ResourceData.Postgresql.Models.Inputs.ReturnedResource;
using ResourceData.Postgresql.Models.Inputs.ReturningBookshelfResources;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceData.Postgresql.PostgresqlRepository.Abstract
{
    public interface IResourceRepository : IGenericPgRepository<InResource>
    {
        public ItemResult CheckAvailabilityForBasket(InBasket inBasket);
        public ItemResult CheckBasketResourcesByInventorNumbers(BasketInventors inBasketInventors);
        public ItemResult DoubleCheckBasketResources(InAcceptedBasket inAcceptedBasket);
        public ItemResult GetByInventarNumbers(ReturnedResources returnedResources);
        public ItemResult GetByCategory(int categoryId);
        public ItemResult GetAllByCategory(int categoryId);
        public ItemResult ResourceAuthorSearch(InResourceAuthorSearchFilter inResourceAuthorSearchFilter);
        public ItemResult ReturnResources(InReturningBookshelfResourceCollection inReturningBookshelfResourceCollection);
        public ItemResult ResourceSearchForSearchButton(InResourceAuthorSearchFilter inResourceAuthorSearchFilter);
        public ItemResult GetAvailableCopyIds(InReturningBookshelfResourceCollection inReturningBookshelfResourceCollection);
    }
}
