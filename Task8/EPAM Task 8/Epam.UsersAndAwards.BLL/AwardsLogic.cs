using Epam.UsersAndAwards.Entities;

using Epam.UsersAndAwards.BLL.Interfaces;
using Epam.UsersAndAwards.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace Epam.UsersAndAwards.BLL
{
    public class AwardsLogic : IAwardsLogic
    {
        private IAwardsDAO _jsonDal;

        public AwardsLogic(IAwardsDAO jsonDAO)
        {
            _jsonDal = jsonDAO;
        }

        public Award AddAward(Guid userId, string title) => _jsonDal.AddAward(userId, title);

        public void EditAward(Guid awardId, string title) => _jsonDal.EditAward(awardId, title);

        public void RemoveAward(Guid awardId) => _jsonDal.RemoveAward(awardId);

        public Award GetAward(Guid id) => GetAward(id);

        public IEnumerable<Award> GetAwards(bool orderedById = true) => _jsonDal.GetAwards(orderedById);
    }
}
