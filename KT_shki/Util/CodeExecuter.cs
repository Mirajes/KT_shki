using KT_shki.KTs;
using System;
using System.Collections.Generic;

namespace KT_shki
{
    class CodeExecuter
    {
        public void CodeExecution(KT1_PapersPlease KT_1)
        {
            KT_1.Execute();
        }

        public void CodeExecution(KT2_MarioKart KT_2)
        {
            KT_2.Execute();
        }
    }
}



// perevod Enum v Array => Enum.GetValues(typeof(Countries)).Cast<Countries>()
