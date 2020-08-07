using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using AutoMapper;
using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;


namespace BussinessServices
{
    class UserServices : IUserServices
    {
        private readonly UnitOfWork _unitOfWork;

        public UserServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;  
        }

        public int Authenticate(string userName, string password)
        {
            var user = _unitOfWork.UserRepository.Get(u => u.UserName == userName && u.Password == password);

            if( user != null && user.UserId > 0)
            {
                return user.UserId;
            }

            return 0;

        }

        public int CreateUser(BusinessEntities.UserEntity userEntity)
        {
            using (var scope = new TransactionScope())
            {
                var user = new User
                {
                    UserName = userEntity.Name,
                    Password = userEntity.Password,
                    Name = userEntity.Name

                };
                
                _unitOfWork.UserRepository.Insert(user);
                _unitOfWork.Save();
                scope.Complete();
                return user.UserId;
            }
        }

    }
}
