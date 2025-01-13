using BlogAPI.Application.Common;
using BlogAPI.Data;
using BlogAPI.Entites.DO;
using BlogAPI.Entites.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Infrastructure.Repositories
{

    
    public class AccountServices : IAccountServices
    {
        private readonly BlogAPIContext dbcontext;

        public AccountServices(BlogAPIContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<LoginResponseData> AccountLogin(AccountLoginRequestData requestData)
        {
            var returnData = new LoginResponseData();
            try
            {
                if (requestData == null
                    || string.IsNullOrEmpty(requestData.UserName)
                    || string.IsNullOrEmpty(requestData.Password))
                {
                    returnData.ReturnCode = -1;
                    returnData.ReturnMessage = "Dữ liệu khong hợp lệ";
                    return returnData;

                }

                await Task.Yield();

                // xử lý gọi vào db 

                var hashPassword = Security.ComputeSha256Hash(requestData.Password);

                var user =  dbcontext.User.ToList().FindAll(x => x.UserName
                  == requestData.UserName && x.Password == hashPassword).FirstOrDefault();

                if (user == null || user.UserID <= 0)
                {
                    returnData.ReturnCode = -1;
                    returnData.ReturnMessage = "Tài khoản hoặc mật khẩu không đúng!";
                    return returnData;
                }


                returnData.ReturnCode = 1;
                returnData.ReturnMessage = "Đăng nhập thành công!";
                returnData.user = user;
                return returnData;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Task<int> Account_LogOut(string token)
        {
            throw new NotImplementedException();
        }

        public Task<int> Account_UpdateRefeshToken(Account_UpdateRefeshTokenRequestData requestData)
        {
            try
            {
                var user = dbcontext.User.ToList().FindAll(x => x.UserID
                 == requestData.UserId).FirstOrDefault();
                if (user == null || user.UserID <= 0)
                {
                    return Task.FromResult(-1);
                }
                user.Refeshtoken = requestData.RefeshToken;
                user.Exprired = requestData.Exprired;

                dbcontext.User.Update(user);

                dbcontext.SaveChanges();
                return Task.FromResult(1);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Task<JSType.Function> GetFunctionByCode(string code)
        {
            throw new NotImplementedException();
        }
    }
}
