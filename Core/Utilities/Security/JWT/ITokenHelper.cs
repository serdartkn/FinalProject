using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        //Burası token uretmemıze yaracaktır.
        //Kim için oluşturuyoeuz User için.
        //tokena hangi yetkiler konulacak. Operationclaimden gelen kullanıcıya aıt yetkıler(bu yetkılerı dbde görebılırız.) yetkiler(değerler).
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);

    }
}
