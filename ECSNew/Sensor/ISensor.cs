using System;
using System.Collections.Generic;
using System.Text;

namespace ECSNew
{
    public interface ISensor
    {
        int GetTemp();

        bool RunSelfTest();
    }
}
