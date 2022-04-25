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

    


    public enum GameValueType
    {

        [Display(Name = "Вокал")]
        Vocal,
        [Display(Name = "Музыкальность")]
        Music,
        [Display(Name = "Артистичность")]
        Artist,
        [Display(Name = "Раскрытие темы (ВОВ, Мана, Туризм)")]
        RaskrTema,
        [Display(Name = "тема ВОВ")]
        WOW,
        [Display(Name = "тема Маны")]
        Mana,
        [Display(Name = "тема Туризм")]
        Tourism,
        [Display(Name = "Собственный текст")]
        SelfSong,
        [Display(Name = "Собственная музыка")]
        SelfMusic,
        [Display(Name = "Вовлечение зрителей")]
        Interactive,
        [Display(Name = "Поддержка зрителей")]
        FanSupport,
        [Display(Name = "Штраф за поведение")]
        BadBehaviour,

        [Display(Name = "Поддержка команды")]
        CommandSupport,

        [Display(Name = "Вкус")]
        Taste,
        [Display(Name = "Оформление")]
        Visual,
        [Display(Name = "Подача")]
        CookShow,

        [Display(Name = "Неисп. продукты")]
        NonUsedIngredients,
        [Display(Name = "Неубр. территория")]
        UncleanTerritory,
        [Display(Name = "> 60 мин.")]
        LongCook,
        [Display(Name = "Розжиг воспл. средствами")]
        FireBenzin,
        [Display(Name = "Исп гот. продуктов")]
        CookWithCooked,
        [Display(Name = "Помощь посторонних")]
        HelpOther,
        [Display(Name = "Препятствие сопернику")]
        Prepatstvie,

        [Display(Name = "Целостность идеи")]
        CookIdea,
        [Display(Name = "Подача и сервировка")]
        CookVisualShow,


        [Display(Name = "Штраф за мат")]
        MatShtraf,


        [Display(Name = "Время")]
        Time,


        [Display(Name = "Флаг")]
        Flag,
        [Display(Name = "Обозн. территории")]
        Territory,
        [Display(Name = "Дежурный")]
        Dezhur,
        [Display(Name = "Костр. хоз-во")]
        FireHoz,
        [Display(Name = "Место костра")]
        FirePlace,
        [Display(Name = "Аптечка")]
        Medicine,
        [Display(Name = "Оп. знаки")]
        Znaki,
        [Display(Name = "Тент")]
        Tent,
        [Display(Name = "Зона дров")]
        DrovaZone,
        [Display(Name = "Зона мусора")]
        TrashZone,
        [Display(Name = "Зона еды")]
        EatZone,
        [Display(Name = "Чистота")]
        Clean,
        [Display(Name = "Оформление")]
        Oformlenie,
        [Display(Name = "Стенд")]
        Stend,
        [Display(Name = "Фишки")]
        Fishki,
        [Display(Name = "Лапник")]
        Lapnik,
        [Display(Name = "Плохое повед.")]
        BadPovedenie,
        [Display(Name = "Пож. опасность")]
        FireDanger,
        [Display(Name = "Итоговое место")]
        FinalPlace,

        [Display(Name = "Откр. ком. кост.")]
        OtkrTeamSuite,
        [Display(Name = "Откр. инд. кост.")]
        OtkrManSuite,
        [Display(Name = "Откр. флаг")]
        OtkrFlag,
        [Display(Name = "Откр. наклейки")]
        OtkrNakl,
        [Display(Name = "Откр. настрой")]
        OtkrNastroi,

        [Display(Name = "Откр.выст. красочность")]
        OtkrShowKras,
        [Display(Name = "Откр.выст. зрелищ.")]
        OtkrShowZrel,
        [Display(Name = "Откр.выст. реакция")]
        OtkrShowReact,
        [Display(Name = "Откр.выст. настрой")]
        OtkrShowNastroi,

        [Display(Name = "Шоу красочность")]
        ShowKras,
        [Display(Name = "Шоу зрелищ.")]
        ShowZrel,
        [Display(Name = "Шоу реакция")]
        ShowReact,
        [Display(Name = "Шоу настрой")]
        ShowNastroi,

        [Display(Name = "Ин. красочность")]
        InKras,
        [Display(Name = "Ин. зрелищ.")]
        InZrel,
        [Display(Name = "Ин. настрой")]
        InNastroi,
        
        [Display(Name = "Неадекват.")]
        Neadekvat,
        [Display(Name = "Ненорматив.")]
        Nenorm,
        [Display(Name = "Наруш. норм")]
        Narush,


        [Display(Name = "1. Спорт костюмы")]
        SportSuite1,
        [Display(Name = "1. Спорт кричалки")]
        SportSongs1,
        [Display(Name = "1. Спорт поддержка")]
        SportSupport1,
        [Display(Name = "1. Спорт неадекват")]
        SportNeadekvat1,

        [Display(Name = "2. Спорт костюмы")]
        SportSuite2,
        [Display(Name = "2. Спорт кричалки")]
        SportSongs2,
        [Display(Name = "2. Спорт поддержка")]
        SportSupport2,
        [Display(Name = "2. Спорт неадекват")]
        SportNeadekvat2,
    }
}
