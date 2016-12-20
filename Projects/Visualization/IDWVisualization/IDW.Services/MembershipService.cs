using IDW.Data.Infrastructure;
using IDW.Data.Repositories;
using IDW.Entities.Membership;
using IDW.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDW.Data.Extensions;
using IDW.Services.Utilities;
using System.Security.Principal;

namespace IDW.Services
{
    public class MembershipService:IMembershipService
    {

        #region Variables

        private readonly IEntityBaseRepository<User> _userRepository;
        private readonly IEntityBaseRepository<Role> _roleRepository;
        private readonly IEntityBaseRepository<UserRole> _userRoleRepository;
        private readonly IEncryptionService _encryptionService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        public MembershipService(IEntityBaseRepository<User> userRepository,
            IEntityBaseRepository<Role> roleRepository, IEntityBaseRepository<UserRole> userRoleRepository,
            IEncryptionService encryptionService, IUnitOfWork unitOfWork)
        {
            this._userRepository = userRepository;
            this._roleRepository = roleRepository;
            this._userRoleRepository = userRoleRepository;
            this._encryptionService = encryptionService;
            this._unitOfWork = unitOfWork;
        }

        private void AddUserToRole(User user,int roleId)
        {
            var role = _roleRepository.GetSingle(roleId);
            if (role == null)
                throw new ApplicationException("Role doesn't exist");

            UserRole userRole = new UserRole()
            {
                UserId = (int)user.ID,
                RoleId = roleId
            };

            _userRoleRepository.Add(userRole);
        }

        private bool IsPasswordValid(User user,string password)
        {
            return _encryptionService.EncryptPassword(password, user.Salt).Equals(user.HashedPassword);
        }

        private bool IsUserValid(User user,string password)
        {
            if(IsPasswordValid(user,password))
            {
                return !user.IsLocked;
            }

            return false;
        }

        public Utilities.MembershipContext ValidateUser(string username, string password)
        {
            var membershipCtx = new MembershipContext();

            User user = _userRepository.GetSingleByUsername(username);

            if(user != null && IsUserValid(user,password))
            {
                var userRoles = GetUserRoles(user.Username);
                membershipCtx.User = user;

                var identity = new GenericIdentity(user.Username);
                membershipCtx.Principal = new GenericPrincipal(identity, userRoles.Select(x=>x.Name).ToArray());
                
            }
            return membershipCtx;
        }

        public Entities.Membership.User CreateUser(string username, string email, string password, int[] roles)
        {
            User user = _userRepository.GetSingleByUsername(username);
            if (user != null)
                throw new ApplicationException("User name already exists");

            string usersalt = _encryptionService.CreateSalt();

            User newuser = new User
            {
                Username = username,
                Email = email,
                Salt = usersalt,
                HashedPassword = _encryptionService.EncryptPassword(password,usersalt),
                DateCreated = DateTime.Now,
                IsLocked = false
            };

            _userRepository.Add(newuser);
            _unitOfWork.Commit();

            if(roles!=null && roles.Length>0)
            {
                foreach(var role in roles)
                {
                    AddUserToRole(newuser, role);
                }
            }

            _unitOfWork.Commit();
            return user;
        }

        public Entities.Membership.User GetUser(int userId)
        {
            return _userRepository.GetSingle(userId);
        }

        public List<Entities.Membership.Role> GetUserRoles(string username)
        {
            List<Role> userroles = new List<Role>();
            var existinguser = _userRepository.GetSingleByUsername(username);

            if(existinguser!=null)
            {
                foreach(var userRole in existinguser.UserRoles)
                {
                    userroles.Add(userRole.Role);
                }
            }

            return userroles.Distinct().ToList();
        }
    }
}
