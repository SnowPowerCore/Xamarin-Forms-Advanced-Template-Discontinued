using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinFormsAdvancedTemplate.Models;

namespace XamarinFormsAdvancedTemplate.Services.Apple
{
    public interface IAppleService
    {
        Task<DataResult<List<Models.Apple>>> GetApplesAsync();
    }
}