using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics) //logics iş kuralı anlamına gelıyor trde
        {
            foreach (var logic in logics)//eger hata varsa hatayı dondurecek hata yoksa bos donecek 
                                        //managerdede bunu cagırıp bır degıskene atayacagız ve ıf ıle degıskenın boş olmaması durumunda yanı hata ıcerır olması
                                       //durumunda degıskenı ekrana yansıtacagız hata olmaması durumunda ıse eklenecektır.
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }
            return null;
        }

    }
}
