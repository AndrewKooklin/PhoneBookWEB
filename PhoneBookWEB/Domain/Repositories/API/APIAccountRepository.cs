using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using PhoneBookWEB.Domain.Entities;
using PhoneBookWEB.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PhoneBookWEB.Domain.Repositories.API
{
    public class APIAccountRepository : IAccountRepository
    {
        private HttpClient _httpClient;
        private string url = @"https://localhost:44379/api/";
        private string urlRequest = "";
        private HttpResponseMessage response;
        private string apiResponse;
        private string result;
        private bool apiResponseBoolean;
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;

        //private UserWithRolesModel userWithRoles;

        public APIAccountRepository()
        {
            //_httpClient = new HttpClient();
            //_httpClient.DefaultRequestHeaders.Accept.Clear();
            //_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<bool> CheckUserToDB(LoginModel model)
        {
            urlRequest = $"{url}" + "Login/CheckUserToDB/" + $"{model}";
            using(_httpClient = new HttpClient())
            {
                using (response = await _httpClient.PostAsJsonAsync(urlRequest, model))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                    apiResponseBoolean = JsonConvert.DeserializeObject<bool>(apiResponse);
                }
            }
            
            return apiResponseBoolean;
        }

        public async Task<bool> CreateUser(RegisterModel model)
        {
            urlRequest = $"{url}" + "APIRegister/CreateNewUser/" + $"{model}";
            using (_httpClient = new HttpClient())
            {
                using (response = await _httpClient.PostAsJsonAsync(urlRequest, model))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                    apiResponseBoolean = JsonConvert.DeserializeObject<bool>(apiResponse);
                }
            }
            
            return apiResponseBoolean;
        }

        public Task<List<string>> GetRoles(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityUser> GetUser(LoginModel model)
        {
            throw new NotImplementedException();
        }

        //public async Task<UserWithRolesModel> GetUserWithRoles(LoginModel model)
        //{
        //    urlRequest = $"{url}" + "Login/GetUserWithRoles/" + $"{model}";
        //    using (response = await _httpClient.GetHttpClient().PostAsJsonAsync(urlRequest, model))
        //    {
        //        apiResponse = await response.Content.ReadAsStringAsync();
        //        userWithRoles = JsonConvert.DeserializeObject<UserWithRolesModel>(apiResponse);
        //    }
        //    return userWithRoles;
        //}

        public void LogoutUser()
        {
            throw new NotImplementedException();
        }

        public async Task<UserManager<IdentityUser>> GetUserManager()
        {
            urlRequest = $"{url}" + "APIRegister/GetUserManager";
            using (_httpClient = new HttpClient())
            {
                using (response = await _httpClient.GetAsync(urlRequest))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _userManager = JsonConvert.DeserializeObject<UserManager<IdentityUser>>(apiResponse);
                }
            }
            
            return _userManager;
        }

        public async Task<SignInManager<IdentityUser>> GetSignInManager()
        {
            urlRequest = $"{url}" + "APIRegister/GetSignInManager";
            using (_httpClient = new HttpClient())
            {
                using (response = await _httpClient.GetAsync(urlRequest))
                {
                     string apiResponse = await response.Content.ReadAsStringAsync();
                     _signInManager = JsonConvert.DeserializeObject<SignInManager<IdentityUser>>(apiResponse);
                }
            }
            
            return _signInManager;
        }

        public async Task<RoleManager<IdentityRole>> GetRoleManager()
        {
            urlRequest = $"{url}" + "APIRegister/GetRoleManager";
            using (_httpClient = new HttpClient())
            {
                using (response = await _httpClient.GetAsync(urlRequest))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _roleManager = JsonConvert.DeserializeObject<RoleManager<IdentityRole>>(apiResponse);
                }
            }
            
            return _roleManager;
        }
    }
}
