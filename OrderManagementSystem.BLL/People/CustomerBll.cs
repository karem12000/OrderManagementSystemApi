using Mapster;
using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Common.General;
using OrderManagementSystem.DAL.DesignPattern;
using OrderManagementSystem.DTO;
using OrderManagementSystem.DTO.People;
using OrderManagementSystem.Tables.People;

namespace OrderManagementSystem.BLL.People
{
    public class CustomerBll(IRepository<Customer> repoCustomer)
    {
        public GetCustomerDto GetById(Guid id)
        {
            var customer = repoCustomer.GetAll().Where(x => x.Id == id).Select(x => new GetCustomerDto()
            {
                Id = x.Id,
                Address = x.Address,
                DateOfBirth = x.DateOfBirth,
                Email = x.Email,
                Name = x.Name,
                Phone = x.Phone,
                DateOfBirthStr = x.DateOfBirth.ToString("yyyy-MM-dd")
            }).FirstOrDefault();

            return customer;
        }
        public IQueryable<SelectListDto> GetCustomerSelect()
        {
            return repoCustomer.GetAllAsNoTracking().Where(p => !p.IsDeleted && p.IsActive).Select(p => new SelectListDto()
            {
                Value = p.Id,
                Text = p.Name
            });
        }
        public async Task<PaginatedResponse<GetCustomerDto>> GetAllCustomers(PaginatedDto data)
        {
            var query = repoCustomer.GetAllAsNoTracking().Where(x => !x.IsDeleted)
                .Select(x => new GetCustomerDto()
                {
                    Id = x.Id,
                    Email = x.Email,
                    Name = x.Name,
                    Phone = x.Phone,
                    Address = x.Address,
                    DateOfBirth = x.DateOfBirth,
                    DateOfBirthStr = x.DateOfBirth.ToString("yyyy-MM-dd")
                }).AsQueryable();

            if (!string.IsNullOrWhiteSpace(data.Search))
            {
                query = query.Where(p => p.Name.Contains(data.Search));
            }

            var customers = await query
                .Skip((data.Page - 1) * data.PageSize)
                .Take(data.PageSize)
                .ToListAsync();

            var totalCount = await query.CountAsync();

            return new PaginatedResponse<GetCustomerDto>
            {
                Items = customers,
                TotalCount = totalCount
            };
        }
        public ResultDto CreateCustomer(CreateCustomerDto data)
        {
            var result = new ResultDto() { Message = AppConstants.EnMessages.SavedFailed };
            try
            {

                var emailValid = data.Email.IsValidEmail();
                if (!emailValid)
                {
                    result.Message = AppConstants.EnMessages.InvalidEmail;
                    return result;
                }

                if (data.Name.IsEmpty())
                {
                    result.Message = AppConstants.EnMessages.NameRequired;
                    return result;
                }

                if (data.Phone.IsEmpty())
                {
                    result.Message = AppConstants.EnMessages.PhoneRequired;
                    return result;
                }

                var existCustomer = repoCustomer.GetAllAsNoTracking()
                    .FirstOrDefault(x => x.Email.Trim() == data.Email.Trim());
                if (existCustomer != null)
                {
                    result.Status = false;
                    result.Message = AppConstants.EnMessages.EmailAlreadyExists;
                    return result;
                }

                var newCustomer = data.Adapt<Customer>();
                newCustomer.AddedBy = AppConstants.AdminUserId;

                if (repoCustomer.Insert(newCustomer))
                {
                    result.Status = true;
                    result.Message = AppConstants.EnMessages.SavedSuccess;
                    result.Data = newCustomer.Id;
                    return result;
                }

                return result;
            }
            catch (Exception e)
            {
                return result;
            }
        }

        public ResultDto UpdateCustomer(UpdateCustomerDto data)
        {
            var result = new ResultDto() { Message = AppConstants.EnMessages.SavedFailed };
            try
            {
                if (data.Id == Guid.Empty) return result;

                var emailValid = data.Email.IsValidEmail();
                if (!emailValid)
                {
                    result.Message = AppConstants.EnMessages.InvalidEmail;
                    return result;
                }

                if (data.Name.IsEmpty())
                {
                    result.Message = AppConstants.EnMessages.NameRequired;
                    return result;
                }

                if (data.Phone.IsEmpty())
                {
                    result.Message = AppConstants.EnMessages.PhoneRequired;
                    return result;
                }
                var oldCustomer = repoCustomer.GetAll().FirstOrDefault(x => x.Id == data.Id);
                if (oldCustomer == null) return result;


                var existProduct = repoCustomer.GetAllAsNoTracking()
                    .FirstOrDefault(x => x.Email.Trim() == data.Email.Trim() && x.Id != data.Id);
                if (existProduct != null)
                {
                    result.Status = false;
                    result.Message = AppConstants.EnMessages.EmailAlreadyExists;
                    return result;
                }


                oldCustomer.Name = data.Name;
                oldCustomer.Email = data.Email;
                oldCustomer.Phone = data.Phone;
                oldCustomer.Address = data.Address;
                oldCustomer.DateOfBirth = data.DateOfBirth;
                oldCustomer.ModifiedBy = repoCustomer.UserId;
                oldCustomer.ModifiedDate = AppDateTime.Now;

                if (repoCustomer.Update(oldCustomer))
                {
                    result.Status = true;
                    result.Message = AppConstants.EnMessages.SavedSuccess;
                    return result;
                }

                return result;
            }
            catch (Exception e)
            {
                return result;
            }
        }

        public ResultDto Delete(Guid id)
        {
            var result = new ResultDto() { Message = AppConstants.EnMessages.DeletedFailed };

            var tbl = repoCustomer.GetAll().FirstOrDefault(p => p.Id == id);
            if (tbl == null) return result;

            tbl.IsDeleted = true;
            tbl.DeletedBy = repoCustomer.UserId;
            tbl.DeletedDate = AppDateTime.Now;
            var isSuceess = repoCustomer.Update(tbl);

            result.Status = isSuceess;
            if (isSuceess)
                result.Message = AppConstants.EnMessages.DeletedSuccess;
            else
                result.Message = AppConstants.EnMessages.DeletedFailed;

            return result;
        }


    }
}
