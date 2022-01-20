using GringottsBank.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GringottsBank.Domain.Accounts.Rules
{
    public class IdCannotBeNull : IBusinessRule
    {
        private readonly Guid _id;
        public IdCannotBeNull(Guid id)
        {
            _id = id;
        }

        public string Message => MessageConstants.IdCannotBeNull;

        public bool IsBroken() => _id == Guid.Empty;
    }
}
