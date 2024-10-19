using Mapster;
using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Common.General;
using OrderManagementSystem.DAL.DesignPattern;
using OrderManagementSystem.DTO;
using OrderManagementSystem.DTO.People;
using OrderManagementSystem.Tables.People;
using System.Net;

namespace OrderManagementSystem.BLL.People
{
    public class UserBll(IRepository<User> repoUser)
    {

        public async Task<PaginatedResponse<User>> GetUsers(PaginatedDto data)
        {
            var query = repoUser.GetAllAsNoTracking()
                .Where(x => !x.IsDeleted && !x.IsAdmin).AsQueryable();

            if (!string.IsNullOrWhiteSpace(data.Search))
            {
                query = query.Where(p => p.FullName.Contains(data.Search));
            }


            var users = await query
                .Skip((data.Page - 1) * data.PageSize)
                .Take(data.PageSize)
                .ToListAsync();

            var totalCount = await query.CountAsync();

            return new PaginatedResponse<User>
            {
                Items = users,
                TotalCount = totalCount
            };
        }
        public ApiUserResponseDto FindByEmailApi(UserParameters mdl)
        {
            var responce = new ApiUserResponseDto();
            responce.Status = false;
            responce.ResponseCode = HttpStatusCode.UnprocessableEntity;
            if (mdl.UserName.IsEmpty())
            {
                responce.Messages = new List<string>() { AppConstants.EnMessages.EmailRequired };
                return responce;
            }
            string userName = string.IsNullOrEmpty(mdl.UserName) ? mdl.UserName : mdl.UserName;

            var entity = GetUserByUserNameEmailAndPassword(new UserParameters() { UserName = userName, Password = mdl.Password });

            if (entity == null)
            {
                responce.Messages.Add("Incorrect data");
                return responce;
            }

            responce.Status = true;
            responce.ResponseCode = HttpStatusCode.OK;
            responce.Results = new LohInResponse
            {
                Id = entity.Id,
                Email = entity.Email,
                IsActive = true,
                Fullname = entity.FullName ?? entity.UserName,
                IsAdmin = entity.IsAdmin
            };
            return responce;


        }
        private User GetUserByUserNameEmailAndPassword(UserParameters mdl)
        {
            var data = repoUser.GetAll().FirstOrDefault(x => (x.UserName ?? "").ToLower() == mdl.UserName.ToLower() || (x.Email ?? "").ToLower() == mdl.UserName.ToLower());
            if (data != null)
            {

                if (data.PasswordHash != mdl.Password.EncryptString())
                {
                    return null;
                }
            }

            return data;
        }
        public ResultDto SaveUser(UserDto userDTO)
        {
            var result = new ResultDto() { Message = AppConstants.EnMessages.SavedFailed };


            if (userDTO.FullName.IsEmpty())
            {
                result.Message = AppConstants.EnMessages.NameRequired;
                return result;
            }

            if (!userDTO.Email.IsValidEmail())
            {
                result.Message = AppConstants.EnMessages.InvalidEmail;
                return result;
            }
            if (string.IsNullOrEmpty(userDTO.Password))
            {
                result.Message = AppConstants.EnMessages.PasswordRequired;
                return result;
            }
            var existEmail = repoUser.GetAllAsNoTracking().FirstOrDefault(x => x.Email.Trim() == userDTO.Email.Trim());
            if (existEmail != null)
            {
                result.Message = AppConstants.EnMessages.EmailAlreadyExists;
                return result;
            }

            var user = userDTO.Adapt<User>();
            user.UserName = userDTO.Email.GetUsernameFromEmail();

            user.PasswordHash = userDTO.Password.EncryptString();
            user.Salt = AppConstants.EncryptKey;

            if (repoUser.Insert(user))
            {

                result.Status = true;
                result.Message = AppConstants.EnMessages.SavedSuccess;

            }

            return result;
        }

        public ResultDto EditUser(EditUserDto userDTO)
        {
            var result = new ResultDto() { Message = AppConstants.EnMessages.SavedFailed };

            if (userDTO.Id == Guid.Empty)
            {
                return result;
            }

            if (userDTO.FullName.IsEmpty())
            {
                result.Message = AppConstants.EnMessages.NameRequired;
                return result;
            }

            if (!userDTO.Email.IsValidEmail())
            {
                result.Message = AppConstants.EnMessages.InvalidEmail;
                return result;
            }
            if (string.IsNullOrEmpty(userDTO.Password))
            {
                result.Message = AppConstants.EnMessages.PasswordRequired;
                return result;
            }
            var existEmail = repoUser.GetAllAsNoTracking().FirstOrDefault(x => x.Email.Trim() == userDTO.Email.Trim() && x.Id != userDTO.Id);
            if (existEmail != null)
            {
                result.Message = AppConstants.EnMessages.EmailAlreadyExists;
                return result;
            }

            var oldUser = repoUser.GetAll().FirstOrDefault(x => x.Id == userDTO.Id);
            if (oldUser == null) return result;

            oldUser.Email = userDTO.Email.Trim();
            oldUser.UserName = userDTO.Email.GetUsernameFromEmail();
            oldUser.FullName = userDTO.FullName;

            if (repoUser.Update(oldUser))
            {
                result.Status = true;
                result.Message = AppConstants.EnMessages.SavedSuccess;
            }

            return result;
        }

        public ResultDto ChangePassword(UserChangePasswordParameters para)
        {
            ResultDto result = new ResultDto();
            var data = repoUser.GetAll().FirstOrDefault(p => p.Id == para.UserId);
            if (data != null)
            {
                var hashPass = para.CurrentPassword.EncryptString();
                if (para.NewPassword != para.ConfirmNewPassword)
                {
                    result.Message = AppConstants.EnMessages.NewAndConfirmPassword;
                    return result;
                }

                if (para.NewPassword == para.CurrentPassword)
                {
                    result.Message = AppConstants.EnMessages.CurrentAndNewPasswordEqual;
                    return result;
                }
                if (hashPass == data.PasswordHash)
                {
                    var hashNewPass = (para.NewPassword).EncryptString();
                    if (hashNewPass != null)
                    {
                        data.PasswordHash = hashNewPass;
                        if (repoUser.Update(data))
                        {
                            result.Status = true;
                            result.Message = AppConstants.EnMessages.SavedSuccess;
                        }
                    }
                }
                else
                {
                    result.Message = AppConstants.EnMessages.InvalidCurrentPassword;
                    return result;
                }

            }
            return result;

        }

        public ResultDto<UserDto> GetById(Guid id)
        {
            var result = new ResultDto<UserDto>() { Message = AppConstants.EnMessages.UserNotFound };

            var user = repoUser.GetAllAsNoTracking().Where(p => p.Id == id).Select(p => new UserDto()
            {
                FullName = p.FullName,
                Email = p.Email
            }).FirstOrDefault();

            if (user != null)
            {
                result.Status = true;
                result.Data = user;
                return result;
            }

            return result;
        }


    }


}
