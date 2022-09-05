using AutoMapper;
using DTO;
using CustomerAcountManagement.Storage;
using CustomerAcountManagement.Storage.Entities;

namespace CustomerAcountManagement.Service;

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
            throw new Exception("Acount does not exist");
            

        }
        catch(Exception ex)
        {
            throw ex;

        }
    }

    public Task<bool> PostAcount(AcountDTO acountDTO)
    {
        throw new NotImplementedException();
        //לשאול את אילה מה אני צריכה לעשותת כאן
    }

    
}
