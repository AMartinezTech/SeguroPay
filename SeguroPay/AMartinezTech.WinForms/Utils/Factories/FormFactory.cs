
//using Microsoft.Extensions.DependencyInjection;

namespace MotoStock.Utils.Factories;

public class FormFactory(IServiceProvider serviceProvider)  
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    //public T CreateFormFactory<T>() where T : Form
    //{
    //    return _serviceProvider.GetRequiredService<T>();    
    //}
}
