
using AutoMapper;
using DTO;
using UserAcountManagement.Storage;
using UserAcountManagement.Storage.Entities;

namespace UserAcountManagement.Service;

public class AcountService : IAcountService
{
    private readonly IAcountStorage _AcountStorage;
    private readonly IMapper _mapper;
    public AcountService(IAcountStorage AcountStorag, IMapper mapper)
    {
        _AcountStorage = AcountStorag;
        _mapper = mapper;
    }

    public async Task<Acount> GetAcount(AcountInfoDTO newAcountInfo)
    {
        try
        {
            Acount acount = await _AcountStorage.GetAcountInfo(newAcountInfo.AcountId);
            if (acount != null)
                return acount;
            return null;
        }
        catch(Exception ex)
        {
            throw new Exception("404");

        }
    }

    public Task<bool> PostAcount(AcountDTO acountDTO)
    {
        throw new NotImplementedException();
        //לשאול את אילה מה אני צריכה לעשותת כאן
    }

    
}
