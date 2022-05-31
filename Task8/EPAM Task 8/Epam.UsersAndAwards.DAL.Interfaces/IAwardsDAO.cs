using Epam.UsersAndAwards.Entities;
using System;
using System.Collections.Generic;

namespace Epam.UsersAndAwards.DAL.Interfaces
{
    public interface IAwardsDAO
    {
        Award AddAward(Guid userId, string title);

        void RemoveAward(Guid awardId);

        void EditAward(Guid awardId, string title);

        Award GetAward(Guid id);

        IEnumerable<Award> GetAwards(bool orderedById);
    }
}
