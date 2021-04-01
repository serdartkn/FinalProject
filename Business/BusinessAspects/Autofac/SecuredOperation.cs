using Business.Constants;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;

namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        //Bu SecuredOperation JWT İçindir
        private string[] _roles;
        //burası yapılan her istek için bir context oluşturur.
        private IHttpContextAccessor _httpContextAccessor;

        //Bu metotta bana rolleri ver diyoruz.
        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            //Ihttp AspNetCore içinden geliyr o yuzden ıjectıon etmek gerek
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            //o an verilen kullanıcının rollerini al gez ve ılgılı rol varsa calısmaya devam et eger yoksa yetkin yok hata ver.
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
