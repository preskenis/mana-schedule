using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManaSchedule
{
    public static class Utils
    {
        public static int MinPow2(int value)
        {
            var pow = 1;
            while (Math.Pow(2, pow) < value) pow++;
            return (int)Math.Pow(2, pow);
        }

        public static DataModels.StageType GetStageTypeByGamesCount(int games)
        {
            switch (games)
            {
                case 2: return DataModels.StageType.Stage12;
                case 4: return DataModels.StageType.Stage14;
                case 8: return DataModels.StageType.Stage18;
                case 16: return DataModels.StageType.Stage116;
                case 32: return DataModels.StageType.Stage132;
                case 64: return DataModels.StageType.Stage164;
                case 128: return DataModels.StageType.Stage1128;
            }

            return DataModels.StageType.Otbor;
        }


    }
}
