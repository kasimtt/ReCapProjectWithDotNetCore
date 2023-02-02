using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Result;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
        public IDataResult<User> Login(UserForLogin userForLogin)
        {
            var UserToCheck = _userService.GetByEmail(userForLogin.Email);
            if(UserToCheck==null)
            {
                new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if(!HashingHelper.VeriFyPasswordHash(userForLogin.Password,UserToCheck.Data.PasswordHash,UserToCheck.Data.PasswordSalt))
            {
                new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(UserToCheck.Data, Messages.SuccessfulLogin);
        }

        public IDataResult<User> Register(UserForRegister userForRegister)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegister.Password,out passwordHash,out passwordSalt);
            var user = new User
            {
                FirstName = userForRegister.FirstName,
                LastName = userForRegister.LastName,
                Email = userForRegister.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true

            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IResult UserExists(string email)
        {
           var user =  _userService.GetByEmail(email);
           if(user!=null)
            {
                new ErrorResult(Messages.UserAlreadyExist);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateToken(User user )
        {
            var claims = _userService.GetClaim(user);
            var accessToken = _tokenHelper.CreateAccessToken(user,claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken,Messages.AccessTokenCreate);
        }
    }
}
