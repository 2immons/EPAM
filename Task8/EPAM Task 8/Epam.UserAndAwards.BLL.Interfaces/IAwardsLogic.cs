using Epam.UsersAndAwards.Entities;
using System;
using System.Collections.Generic;

namespace Epam.UsersAndAwards.BLL.Interfaces
{
    public interface IAwardsLogic
    {
        Award AddAward(Guid userId, string title);

        void RemoveAward(Guid awardId);

        void EditAward(Guid awardId, string title);

        Award GetAward(Guid id);

        IEnumerable<Award> GetAwards(bool orderedById = true);
    }
}