﻿using Mapster;
using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Common.General;
using OrderManagementSystem.DAL.DesignPattern;
using OrderManagementSystem.DTO;
using OrderManagementSystem.DTO.Guide;
using OrderManagementSystem.Tables.Guide;
using System.Data;
using System.Reflection;

namespace OrderManagementSystem.BLL.Guide
{
    public class ProductBll(IRepository<Product> repoProduct)
    {
        #region Fields
        private const string SpProducts = "[Guide].[spProducts]";
        #endregion
        #region Get
        public ResultDto<GetProductDto> GetById(Guid id)
        {
            var result = new ResultDto<GetProductDto>() { Message = AppConstants.EnMessages.ProductNotFound };

            var product = repoProduct.GetAllAsNoTracking().Where(p => p.Id == id).Select(p => new GetProductDto()
            {
                Id = p.Id,
                StockQuantity = p.StockQuantity,
                Price = p.Price,
                Name = p.Name
            }).FirstOrDefault();

            if (product != null)
            {
                result.Status = true;
                result.Data = product;
                return result;
            }

            return result;
        }
        public async Task<ResultDto<GetProductDto>> GetByIdAsync(Guid id)
        {
            var result = new ResultDto<GetProductDto>() { Message = AppConstants.EnMessages.ProductNotFound };

            var product = repoProduct.GetAll().Where(p => p.Id == id).Select(p => new GetProductDto()
            {
                Id = p.Id,
                StockQuantity = p.StockQuantity,
                Price = p.Price,
                Name = p.Name
            }).FirstOrDefault();

            if (product != null)
            {
                result.Status = true;
                result.Data = product;
                return result;
            }

            return result;
        }
        public async Task<PaginatedResponse<Product>> GetProducts(PaginatedDto data)
        {
            var query = repoProduct.GetAllAsNoTracking()
                .Where(x => !x.IsDeleted && !x.User.IsDeleted)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(data.Search))
            {
                query = query.Where(p => p.Name.Contains(data.Search));
            }

            if (data.OwnerId != null && !data.isGetAll)
            {
                query = query.Where(p => p.OwnerId == data.OwnerId);
            }

            if (data.MinPrice.HasValue)
            {
                query = query.Where(p => p.Price >= data.MinPrice.Value);
            }

            if (data.MaxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= data.MaxPrice.Value);
            }

            var products = await query
                .Skip((data.Page - 1) * data.PageSize)
                .Take(data.PageSize)
                .ToListAsync();

            var totalCount = await query.CountAsync();

            return new PaginatedResponse<Product>
            {
                Items = products,
                TotalCount = totalCount
            };
        }


        #endregion
        public ResultDto CreateProduct(CreateProductDto data)
        {
            var result = new ResultDto() { Message = AppConstants.EnMessages.SavedFailed };
            try
            {

                result = isValid(data);
                if (!result.Status) return result;

                var existProduct = repoProduct.GetAllAsNoTracking()
                    .FirstOrDefault(x => x.Name.Trim() == data.Name.Trim());
                if (existProduct != null)
                {
                    result.Status = false;
                    result.Message = AppConstants.EnMessages.NameAlreadyExists;
                    return result;
                }

                var newProduct = data.Adapt<Product>();
                newProduct.AddedBy = repoProduct.UserId;
                newProduct.OwnerId = repoProduct.UserId;
                if (repoProduct.Insert(newProduct))
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
        public ResultDto UpdateProduct(UpdateProductDto data)
        {
            var result = new ResultDto() { Message = AppConstants.EnMessages.SavedFailed };
            try
            {

                result = isValid(data);
                if (!result.Status) return result;

                var existProduct = repoProduct.GetAllAsNoTracking()
                    .FirstOrDefault(x => x.Name.Trim() == data.Name.Trim() && x.Id != data.Id);
                if (existProduct != null)
                {
                    result.Message = AppConstants.EnMessages.NameAlreadyExists;
                    return result;
                }

                var oldProduct = repoProduct.GetAll().FirstOrDefault(x => x.Id == data.Id);
                if (oldProduct == null) return result;

                oldProduct.Name = data.Name.Trim();
                oldProduct.StockQuantity = data.StockQuantity;
                oldProduct.Price = data.Price;
                oldProduct.ModifiedBy = repoProduct.UserId;
                oldProduct.ModifiedDate = AppDateTime.Now;

                if (repoProduct.Update(oldProduct))
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

            var tbl = repoProduct.GetAll().Include(p => p.OrderItems).FirstOrDefault(p => p.Id == id);
            if (tbl == null) return result;

            tbl.IsDeleted = true;
            tbl.DeletedBy = repoProduct.UserId;
            tbl.DeletedDate = AppDateTime.Now;
            var isSuceess = repoProduct.Update(tbl);

            result.Status = isSuceess;
            if (isSuceess)
                result.Message = AppConstants.EnMessages.DeletedSuccess;
            else
                result.Message = AppConstants.EnMessages.DeletedFailed;

            return result;
        }

        #region Helper
        private ResultDto isValid(object data)
        {
            var result = new ResultDto { Message = AppConstants.EnMessages.SavedFailed };
            if (data == null) return result;

            Type type = data.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (var property in properties)
            {
                object value = property.GetValue(data);

                if (property.PropertyType == typeof(string))
                {
                    if (string.IsNullOrEmpty((string)value))
                    {
                        if (property.Name == "Name")
                        {
                            result.Message = $"{property.Name} {AppConstants.EnMessages.NameRequired}";
                            return result;
                        }
                    }
                }

                if (property.PropertyType == typeof(Guid))
                {
                    if ((Guid)value == Guid.Empty)
                    {
                        if (property.Name == "Id")
                        {
                            result.Message = $"{property.Name} {AppConstants.EnMessages.SavedFailed}";
                            return result;
                        }
                    }
                }

                if (property.PropertyType == typeof(decimal) || property.PropertyType == typeof(int) || property.PropertyType == typeof(long))
                {
                    if (value == null || Convert.ToDecimal(value) <= 0)
                    {
                        if (property.Name == "Price")
                        {
                            result.Message = $"{property.Name} {AppConstants.EnMessages.PriceRequired}";
                            return result;
                        }

                        if (property.Name == "StockQuantity")
                        {
                            result.Message = $"{property.Name} {AppConstants.EnMessages.StockQntyRequired}";
                            return result;
                        }
                    }
                }
            }
            result.Status = true;
            return result;
        }
        #endregion

    }


}
