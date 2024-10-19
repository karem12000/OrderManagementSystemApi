using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;


namespace OrderManagementSystem.Common.General
{
    public static class ExtentionMethods
    {


        #region User

        public static bool IsAuthorize(this HttpContext httpContext)
        {
            return httpContext.Request.Cookies.ContainsKey(AppConstants._UserIdCookie);
        }

        public static Guid UserId(this IHttpContextAccessor httpContext)
        {
            return (httpContext?.HttpContext?.User?.Identity?.IsAuthenticated ?? false) ? Guid.Parse(httpContext?.HttpContext.User.Claims.FirstOrDefault().Value) : Guid.TryParse(httpContext?.HttpContext?.Request?.Cookies[AppConstants._UserIdCookie], out Guid guid) ? guid : Guid.Empty;
        }
        public static Guid UserId(this HttpContext httpContext)
        {
            return (httpContext?.User?.Identity?.IsAuthenticated ?? false) ? Guid.Parse(httpContext?.User.Identity.Name) : Guid.TryParse(httpContext?.Request?.Cookies[AppConstants._UserIdCookie], out Guid guid) ? guid : Guid.Empty;
        }
        public static void AppendCookie(this IResponseCookies responseCookies, string key, string value, bool IsExpire = false)
        {
            var cOption = new CookieOptions()
            {
                HttpOnly = true,
                Path = "/",
                //TODO please un comment the next line if y will use HTTPS
                // Secure = true
            };

            if (!IsExpire)
            {
                cOption.Expires = AppDateTime.Now.AddYears(5);
            }


            responseCookies.Append(key, value, cOption);
        }

        public static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPEG", ".JPE", ".BMP", ".GIF", ".PNG" };

        public static bool IsImage(this string fileName) => ImageExtensions.Any(p => p.ToLower() == Path.GetExtension(fileName).ToLower());

        #endregion
        public static bool IsEmpty(this string s) => s == null || string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s);
        public static bool IsValidEmail(this string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        public static string GetUsernameFromEmail(this string email)
        {
            if (IsValidEmail(email))
            {
                return email.Split('@')[0];
            }

            return "";
        }

        #region Get Url , Action ,etc

        public static string GetAction(this IUrlHelper html, string action)
        {
            string _url = "/";
            if (html.ActionContext.HttpContext.GetRouteValue("area") != null)
                _url += html.ActionContext.HttpContext.GetRouteValue("area").ToString() + "/";
            _url += html.ActionContext.HttpContext.GetRouteValue("controller").ToString() + "/";
            _url += action;
            return _url;
        }
        public static string GetAction(this IUrlHelper html, string action, string controller)
        {
            string _url = "/";
            if (html.ActionContext.HttpContext.GetRouteValue("area") != null)
                _url += html.ActionContext.HttpContext.GetRouteValue("area").ToString() + "/";
            _url += controller + "/";
            _url += action;
            return _url;
        }
        public static string GetAction(this IUrlHelper html, string action, string controller, string area)
        {
            string _url = "/";
            _url += area + "/";
            _url += controller + "/";
            _url += action;
            return _url;
        }

        public static string GetAction(this IUrlHelper html, string action, string controller, string area, string route)
        {
            string _url = "/";
            _url += area + "/";
            _url += controller + "/";
            _url += action + "/";
            _url += route;
            return _url;
        }
        public static string GetFullUrl(this IUrlHelper url, string fileName = "")
        {
            var request = url.ActionContext.HttpContext.Request;
            string FullUrl = $"{request.Scheme}://{request.Host}/{fileName}";

            return FullUrl;
        }

        #endregion


        public static string Serialize(this object obj) => JsonConvert.SerializeObject(obj);

        public static T Desrialize<T>(this string obj) => JsonConvert.DeserializeObject<T>(obj);


        #region EncryptString_And_DecryptString
        public static string EncryptString(this string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(AppConstants.EncryptKey);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public static string DecryptString(this string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(AppConstants.EncryptKey);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
        #endregion

    }

}
