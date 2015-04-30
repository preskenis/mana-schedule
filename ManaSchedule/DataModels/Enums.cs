using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ManaSchedule.DataModels
{
    public enum GameType
    {
        [Display(Name = "Футбол")]
        Soccer,
        [Display(Name = "Волейбол")]
        Volleyball,
        [Display(Name = "Регби")]
        Rugby,
        [Display(Name = "Шоу-песня")]
        ShowSong,
        [Display(Name = "Соло-песня")]
        SoloSong,
        [Display(Name = "Тур-эстафета")]
        TourRelay,
        [Display(Name = "Конкурс лагерей")]
        Lager,
        [Display(Name = "Конкурс карнавальности")]
        Carnival,
        [Display(Name = "Конкурс кашеваров")]
        Cook,
    }

    public enum StageType
    {
        [Display(Name = "Финал")]
        Final = 0,
        [Display(Name = "Матч за третье место")]
        Third,
        [Display(Name = "Полуфинал")]
        Stage12,
        [Display(Name = "Четвертьфинал")]
        Stage14,
        [Display(Name = "1/8")]
        Stage18,
        [Display(Name = "1/16")]
        Stage116,
        [Display(Name = "1/32")]
        Stage132,
        [Display(Name = "1/64")]
        Stage164,
        [Display(Name = "1/128")]
        Stage1128,
        [Display(Name = "Отборочный")]
        Otbor,
    }

    public enum GameState
    {
        NoData,
        AllMissed,
        Team1Missed,
        Team2Missed,
        WaitingEnd,
        Finished,
    }

}
