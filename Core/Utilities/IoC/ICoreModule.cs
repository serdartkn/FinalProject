using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    //Burası Northwind'den bağımsız bir şekilde injeksiyonlarına ihtiyaç duyacağımız ve diğer projelerde de kullanacabileciğimiz servislerin Modülüdür.
    public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}
