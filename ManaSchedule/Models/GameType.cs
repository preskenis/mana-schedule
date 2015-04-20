using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ManaSchedule.Models
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
    }
}
