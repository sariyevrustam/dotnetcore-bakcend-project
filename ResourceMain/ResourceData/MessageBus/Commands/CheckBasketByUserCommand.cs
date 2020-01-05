using ResourceData.Postgresql.Models.Inputs.BasketByUser;
using ResourceDomainCore.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceData.MessageBus.Commands
{
    public class CheckBasketByUserCommand : Command
    {
        public InCheckedBasketByUser CheckedBasketByUser { get; set; }
        public int UserId { get; set; }

        public CheckBasketByUserCommand(InCheckedBasketByUser _checkedBasketByUser,
            int _userId)
        {
            CheckedBasketByUser = _checkedBasketByUser;
            UserId = _userId;
        }
    }

}
