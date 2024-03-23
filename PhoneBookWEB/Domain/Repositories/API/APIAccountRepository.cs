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
        //private UserManager<IdentityUser> _userManager;
        //private SignInManager<IdentityUser> _signInManager;
        //private RoleManager<IdentityRole> _roleManager;

        private List<string> userRoles;
        private List<string> roleNames;
        private IEnumerable<IdentityRole> roles;
        private List<IdentityUser> users;
        private UserWithRolesModel userWithRoles;

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
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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
            urlRequest = $"{url}" + "RegisterAPI/CreateNewUser/" + $"{model}";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (response = await _httpClient.PostAsJsonAsync(urlRequest, model))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                    apiResponseBoolean = JsonConvert.DeserializeObject<bool>(apiResponse);
                }
            }
            
            return apiResponseBoolean;
        }

        public List<string> GetRoleNames()
        {
            roleNames = new List<string>();
            urlRequest = $"{url}" + "RegisterAPI/GetRoleNames";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string result = _httpClient.GetStringAsync(urlRequest).Result;
                roleNames = JsonConvert.DeserializeObject<List<string>>(result);
            }

            return roleNames;
        }

        public Task<IdentityUser> GetUser(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IdentityRole> GetRoles()
        {
            urlRequest = $"{url}" + "RolesAPI/GetRoles";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string result = _httpClient.GetStringAsync(urlRequest).Result;
                roles = JsonConvert.DeserializeObject<IEnumerable<IdentityRole>>(result);
            }

            return roles;
        }

        public async Task<List<string>> GetUserRoles(LoginModel model)
        {
            urlRequest = $"{url}" + "Login/GetUserRoles/" + $"{model}";
            using(_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (response = await _httpClient.PostAsJsonAsync(urlRequest, model))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                    userRoles = JsonConvert.DeserializeObject<List<string>>(apiResponse);
                }
            }
            
            return userRoles;
        }

        public async Task<bool> CreateRole(IdentityRole role)
        {
            urlRequest = $"{url}" + "RolesAPI/CreateRole/" + $"{role}";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (response = await _httpClient.PostAsJsonAsync(urlRequest, role))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                    apiResponseBoolean = JsonConvert.DeserializeObject<bool>(apiResponse);
                }
            }

            return apiResponseBoolean;
        }

        public async Task<bool> DeleteRole(string id)
        {
            urlRequest = $"{url}" + "RolesAPI/DeleteRole/" + $"{id}";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (response = await _httpClient.PostAsJsonAsync(urlRequest, id))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                    apiResponseBoolean = JsonConvert.DeserializeObject<bool>(apiResponse);
                }
            }

            return apiResponseBoolean;
        }

        public List<IdentityUser> GetUsers()
        {
            urlRequest = $"{url}" + "UsersAPI/GetUsers";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string result = _httpClient.GetStringAsync(urlRequest).Result;
                users = JsonConvert.DeserializeObject<List<IdentityUser>>(result);
            }

            return users;
        }

        public UserWithRolesModel GetUserWithRoles(string id)
        {
            urlRequest = $"{url}" + "UsersAPI/GetUserWithRoles/" + $"{id}";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string result = _httpClient.GetStringAsync(urlRequest).Result;
                userWithRoles = JsonConvert.DeserializeObject<UserWithRolesModel>(result);
            }

            return userWithRoles;
        }

        public async Task<bool> AddRoleToUser(RoleUserModel model)
        {
            urlRequest = $"{url}" + "UsersAPI/AddRoleToUser/" + $"{model}/";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (response = await _httpClient.PostAsJsonAsync(urlRequest, model))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                    apiResponseBoolean = JsonConvert.DeserializeObject<bool>(apiResponse);
                }
            }

            return apiResponseBoolean;
        }

        public async Task<bool> DeleteRoleUser(RoleUserModel model)
        {
            urlRequest = $"{url}" + "UsersAPI/DeleteRoleUser/" + $"{model}/";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (response = await _httpClient.PostAsJsonAsync(urlRequest, model))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                    apiResponseBoolean = JsonConvert.DeserializeObject<bool>(apiResponse);
                }
            }

            return apiResponseBoolean;
        }

        public async void LogoutUser()
        {
            urlRequest = $"{url}" + "LogoutAPI/LogoutUser";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                await _httpClient.GetAsync(urlRequest);
            }
        }

        //public async Task<UserManager<IdentityUser>> GetUserManager()
        //{
        //    urlRequest = $"{url}" + "APIRegister/GetUserManager";
        //    using (_httpClient = new HttpClient())
        //    {
        //        using (response = await _httpClient.GetAsync(urlRequest))
        //        {
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //            _userManager = JsonConvert.DeserializeObject<UserManager<IdentityUser>>(apiResponse);
        //        }
        //    }
            
        //    return _userManager;
        //}

        //public async Task<SignInManager<IdentityUser>> GetSignInManager()
        //{
        //    urlRequest = $"{url}" + "APIRegister/GetSignInManager";
        //    using (_httpClient = new HttpClient())
        //    {
        //        using (response = await _httpClient.GetAsync(urlRequest))
        //        {
        //             string apiResponse = await response.Content.ReadAsStringAsync();
        //             _signInManager = JsonConvert.DeserializeObject<SignInManager<IdentityUser>>(apiResponse);
        //        }
        //    }
            
        //    return _signInManager;
        //}

        //public async Task<RoleManager<IdentityRole>> GetRoleManager()
        //{
        //    urlRequest = $"{url}" + "APIRegister/GetRoleManager";
        //    using (_httpClient = new HttpClient())
        //    {
        //        using (response = await _httpClient.GetAsync(urlRequest))
        //        {
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //            _roleManager = JsonConvert.DeserializeObject<RoleManager<IdentityRole>>(apiResponse);
        //        }
        //    }
            
        //    return _roleManager;
        //}
    }
}
