using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace ManaSchedule.DataModels
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<Db>
    {
       
        
        protected override void Seed(Db context)
        {
            foreach (var team in Properties.Resources.Teams.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                context.TeamSet.Add(new Team() { Name = team });
            }

            var comp = context.CompetitionSet.Add(new Competition() { Type = GameType.Soccer, Name = "Футбол" });

            comp = context.CompetitionSet.Add(new Competition() { Type = GameType.Volleyball, Name = "Волейбол" });
            comp = context.CompetitionSet.Add(new Competition() { Type = GameType.Rugby, Name = "Рэгби" });

            comp = context.CompetitionSet.Add(new Competition() { Type = GameType.TourRelay, Name = "Тур-Эстафета" });
            comp = context.CompetitionSet.Add(new Competition() { Type = GameType.ShowSong, Name = "Шоу-Песня" });
            comp = context.CompetitionSet.Add(new Competition() { Type = GameType.SoloSong, Name = "Соло-песня" });
            comp = context.CompetitionSet.Add(new Competition() { Type = GameType.Lager, Name = "Конкурс лагерей" });
            comp = context.CompetitionSet.Add(new Competition() { Type = GameType.Carnival, Name = "Конкурс карнавальности" });
            comp = context.CompetitionSet.Add(new Competition() { Type = GameType.Cook, Name = "Конкурс кашеваров" });

//            SeedZherebCook(context);
//SeedZherebCarnival(context);
//            SeedZherebSolo(context);
//            SeedZherebShowSong(context);
//            SeedZherebLager(context);
//            SeedZherebRugby(context);
//            SeedZherebSoccer(context);
//            SeedZherebVolleyball(context);
//            SeedZherebTourRelay(context);
        }

        protected void SeedZherebCook(Db context)
        {
            var comp = context.CompetitionSet.Local.First(f => f.Type == GameType.Cook);

            for (int i = 1; i < 6; i++)
                context.CompetitionRefereeSet.Add(new CompetitionReferee()
                {
                    IsMainReferee = false,
                    Competition = comp,
                    Name = string.Format("Cудья №{0}", i)
                });
            
            AddZhereb(context, comp, "Клещи", 1);
            AddZhereb(context, comp, "Живой уголок", 2);
            AddZhereb(context, comp, "Бардак", 3);
            AddZhereb(context, comp, "В дрова", 4);
            AddZhereb(context, comp, "Негодяи", 5);
            AddZhereb(context, comp, "Мандраж", 6);
            AddZhereb(context, comp, "Апилки", 7);
            AddZhereb(context, comp, "Коротконосые Буратины", 8);
            AddZhereb(context, comp, "Дубль-В", 9);
            AddZhereb(context, comp, "Трикомана", 10);
            AddZhereb(context, comp, "ЗАО «Гондурас»", 11);
            AddZhereb(context, comp, "Мания", 12);
            AddZhereb(context, comp, "Бомболюк", 13);
            AddZhereb(context, comp, "Колхоз дело добровольное", 14);
            AddZhereb(context, comp, "Пионеры О. Бендера", 15);
            AddZhereb(context, comp, "Ночные Гоблины", 16);
            AddZhereb(context, comp, "Че", 17);
            AddZhereb(context, comp, "Людмила Петрова", 18);
            AddZhereb(context, comp, "Манты", 19);
            AddZhereb(context, comp, "Синие Лебеди", 20);
            AddZhereb(context, comp, "Звездолет", 21);
            AddZhereb(context, comp, "Безопасный Кекс", 22);
            AddZhereb(context, comp, "Телевтузики", 23);
            AddZhereb(context, comp, "Нечисть", 24);
            AddZhereb(context, comp, "Кайф", 25);
            AddZhereb(context, comp, "Лихо", 26);
            AddZhereb(context, comp, "Хреновые спортсмены", 27);
            AddZhereb(context, comp, "Куркули", 28);
            AddZhereb(context, comp, "Корсары удачи", 29);
            AddZhereb(context, comp, "Джем", 30);
            AddZhereb(context, comp, "Джа", 31);
            AddZhereb(context, comp, "Уже", 32);
            AddZhereb(context, comp, "Беларусь", 33);
            AddZhereb(context, comp, "ОбмАненые", 34);
            AddZhereb(context, comp, "Хвосты", 35);
            AddZhereb(context, comp, "Бух-та", 36);
            AddZhereb(context, comp, "НаМана", 37);
            AddZhereb(context, comp, "Азимут", 38);
            AddZhereb(context, comp, "Держи Глаза", 39);
            AddZhereb(context, comp, "Сибирские зебры", 40);
            AddZhereb(context, comp, "Чума", 41);
            AddZhereb(context, comp, "Не дробя", 42);
            AddZhereb(context, comp, "ЧеГеварнутые строители", 43);
            AddZhereb(context, comp, "Любители Активного Отдыха", 44);
            AddZhereb(context, comp, "Кряки", 45);
            AddZhereb(context, comp, "Фиг-Вам", 46);
            AddZhereb(context, comp, "Дикие колобки", 47);
            AddZhereb(context, comp, "ЗООПарк", 48);
            AddZhereb(context, comp, "Легион", 49);
            AddZhereb(context, comp, "Сенаторы", 50);
        }

        protected void SeedZherebShowSong(Db context)
        {
            var comp = context.CompetitionSet.Local.First(f => f.Type == GameType.ShowSong);

            context.CompetitionRefereeSet.Add(new CompetitionReferee()
            {
                IsMainReferee = true,
                Competition = comp,
                Name = string.Format("Главный судья")
            });

            for (int i = 1; i < 6; i++)
                context.CompetitionRefereeSet.Add(new CompetitionReferee()
                {
                    IsMainReferee = false,
                    Competition = comp,
                    Name = string.Format("Cудья №{0}", i)
                });
            
            AddZhereb(context, comp, "Колхоз дело добровольное", 60);
            AddZhereb(context, comp, "Не дробя", 4);
            AddZhereb(context, comp, "Чума", 32);
            AddZhereb(context, comp, "Кряки", 14);
            AddZhereb(context, comp, "Безопасный Кекс", 6);
            AddZhereb(context, comp, "Уже", 18);
            AddZhereb(context, comp, "Лихо", 15);
            AddZhereb(context, comp, "ОбмАненые", 39);
            AddZhereb(context, comp, "Негодяи", 38);
            AddZhereb(context, comp, "Живой уголок", 57);
            AddZhereb(context, comp, "Людмила Петрова", 33);
            AddZhereb(context, comp, "Дикие колобки", 55);
            AddZhereb(context, comp, "Корсары удачи", 5);
            AddZhereb(context, comp, "Пионеры О. Бендера", 35);
            AddZhereb(context, comp, "Звездолет", 37);
            AddZhereb(context, comp, "Джем", 31);
            AddZhereb(context, comp, "Манты", 27);
            AddZhereb(context, comp, "Куркули", 13);
            AddZhereb(context, comp, "Баня", 19);
            AddZhereb(context, comp, "Бух-та", 7);
            AddZhereb(context, comp, "Че", 23);
            AddZhereb(context, comp, "Синие Лебеди", 53);
            AddZhereb(context, comp, "Мандраж", 3);
            AddZhereb(context, comp, "Держи Глаза", 8);
            AddZhereb(context, comp, "Хреновые спортсмены", 58);
            AddZhereb(context, comp, "Некстати", 54);
            AddZhereb(context, comp, "Трикомана", 22);
            AddZhereb(context, comp, "В дрова", 21);
            AddZhereb(context, comp, "Мания", 17);
            AddZhereb(context, comp, "ЗООПарк", 52);
            AddZhereb(context, comp, "Азимут", 20);
            AddZhereb(context, comp, "Любители Активного Отдыха", 24);
            AddZhereb(context, comp, "Бардак", 30);
            AddZhereb(context, comp, "ЗАО «Гондурас»", 36);
            AddZhereb(context, comp, "Фиг-Вам", 51);
            AddZhereb(context, comp, "Дубль-В", 36);
            AddZhereb(context, comp, "ЧеГеварнутые строители", 28);
            AddZhereb(context, comp, "Кайф", 41);
            AddZhereb(context, comp, "Хвосты", 46);
            AddZhereb(context, comp, "Синема", 48);
            AddZhereb(context, comp, "Телевтузики", 50);
            AddZhereb(context, comp, "Клещи", 43);
            AddZhereb(context, comp, "Нечисть", 56);
            AddZhereb(context, comp, "Бомболюк", 1);
            AddZhereb(context, comp, "Легион", 34);
            AddZhereb(context, comp, "Сенаторы", 29);


        }

        protected void SeedZherebLager(Db context)
        {
            var comp = context.CompetitionSet.Local.First(f => f.Type == GameType.Lager);

            AddZhereb(context, comp, "Синие Лебеди", 1);
            AddZhereb(context, comp, "Телевтузики", 2);
            AddZhereb(context, comp, "Лихо", 3);
            AddZhereb(context, comp, "В дрова", 4);
            AddZhereb(context, comp, "Манты", 5);
            AddZhereb(context, comp, "Пионеры О. Бендера", 6);
            AddZhereb(context, comp, "Кряки", 7);
            AddZhereb(context, comp, "Че", 8);
            AddZhereb(context, comp, "Апилки", 9);
            AddZhereb(context, comp, "ОбмАненые", 10);
            AddZhereb(context, comp, "Бояне", 11);
            AddZhereb(context, comp, "Баня", 12);
            AddZhereb(context, comp, "Нечисть", 13);
            AddZhereb(context, comp, "Хвосты", 14);
            AddZhereb(context, comp, "Мандраж", 15);
            AddZhereb(context, comp, "Некстати", 16);
            AddZhereb(context, comp, "Негодяи", 17);
            AddZhereb(context, comp, "Корсары удачи", 18);
            AddZhereb(context, comp, "Безопасный Кекс", 19);
            AddZhereb(context, comp, "Держи Глаза", 20);
            AddZhereb(context, comp, "Дикие колобки", 21);
            AddZhereb(context, comp, "Куркули", 22);
            AddZhereb(context, comp, "ЧеГеварнутые строители", 23);
            AddZhereb(context, comp, "Клещи", 24);
            AddZhereb(context, comp, "Ночные Гоблины", 25);
            AddZhereb(context, comp, "Легион", 26);
            AddZhereb(context, comp, "Бардак", 27);
            AddZhereb(context, comp, "Уже", 28);
            AddZhereb(context, comp, "Колхоз дело добровольное", 29);
            AddZhereb(context, comp, "Сенаторы", 30);
            AddZhereb(context, comp, "Людмила Петрова", 31);
            AddZhereb(context, comp, "Дубль-В", 32);
            AddZhereb(context, comp, "ЗАО «Гондурас»", 33);
            AddZhereb(context, comp, "Фиг-Вам", 34);
            AddZhereb(context, comp, "Хреновые спортсмены", 35);
            AddZhereb(context, comp, "Мания", 36);
            AddZhereb(context, comp, "Санта-Мана", 37);
            AddZhereb(context, comp, "Сокол", 38);
            AddZhereb(context, comp, "Джа", 39);
            AddZhereb(context, comp, "Трикомана", 40);
            AddZhereb(context, comp, "Бух-та", 41);
            AddZhereb(context, comp, "Звездолет", 42);
            AddZhereb(context, comp, "Чума", 43);
            AddZhereb(context, comp, "Азимут", 44);
            AddZhereb(context, comp, "НаМана", 45);
            AddZhereb(context, comp, "Любители Активного Отдыха", 46);
            AddZhereb(context, comp, "Не дробя", 47);
            AddZhereb(context, comp, "ЗООПарк", 48);
            AddZhereb(context, comp, "Джем", 49);
            AddZhereb(context, comp, "Живой уголок", 50);
            AddZhereb(context, comp, "Бомболюк", 51);
            AddZhereb(context, comp, "Сибирские зебры", 52);


        
        }


        protected void SeedZherebVolleyball(Db context)
        {
            var comp = context.CompetitionSet.Local.First(f => f.Type == GameType.Volleyball);

            AddZhereb(context, comp, "ЗАО «Гондурас»", 26);
            AddZhereb(context, comp, "В дрова", 39);
            AddZhereb(context, comp, "ЗООПарк", 6);
            AddZhereb(context, comp, "Трикомана", 31);
            AddZhereb(context, comp, "Лупцовщики", 5);
            AddZhereb(context, comp, "Че", 3);
            AddZhereb(context, comp, "Хреновые спортсмены", 27);
            //AddZhereb(context, comp, "Некстати", 7);
            AddZhereb(context, comp, "НаМана", 9);
            AddZhereb(context, comp, "Манты", 33);
            AddZhereb(context, comp, "Любители Активного Отдыха", 2);
            AddZhereb(context, comp, "Азимут", 15);
            AddZhereb(context, comp, "Пионеры О. Бендера", 45);
            AddZhereb(context, comp, "Джем", 36);
            AddZhereb(context, comp, "Звездолет", 34);
            AddZhereb(context, comp, "Телевтузики", 32);
            AddZhereb(context, comp, "Легион", 22);
            AddZhereb(context, comp, "Куркули", 49);
            AddZhereb(context, comp, "Синие Лебеди", 13);
            AddZhereb(context, comp, "Лихо", 43);
            AddZhereb(context, comp, "Синема", 25);
            AddZhereb(context, comp, "Корсары удачи", 11);
            AddZhereb(context, comp, "Джа", 14);
            //AddZhereb(context, comp, "Дубль-В", 17);
            AddZhereb(context, comp, "ОбмАненые", 58);
            //AddZhereb(context, comp, "Нечисть", 42);
            AddZhereb(context, comp, "Беларусь", 12);
            AddZhereb(context, comp, "Санта-Мана", 19);
            AddZhereb(context, comp, "Баня", 59);
            AddZhereb(context, comp, "Негодяи", 20);
            AddZhereb(context, comp, "Ночные Гоблины", 8);
            AddZhereb(context, comp, "Сибирский Горностай", 18);
            AddZhereb(context, comp, "Бояне", 10);
            AddZhereb(context, comp, "Сокол", 57);
            AddZhereb(context, comp, "Живой уголок", 16);
            AddZhereb(context, comp, "Держи Глаза", 41);
            AddZhereb(context, comp, "ЧеГеварнутые строители", 56);
            AddZhereb(context, comp, "Бардак", 60);
            AddZhereb(context, comp, "Сибирские зебры", 54);
            AddZhereb(context, comp, "Апилки", 28);
            AddZhereb(context, comp, "Безопасный Кекс", 52);
            AddZhereb(context, comp, "Кряки", 35);
            AddZhereb(context, comp, "Хвосты", 48);
            AddZhereb(context, comp, "Чума", 44);
            AddZhereb(context, comp, "Не дробя", 4);
            AddZhereb(context, comp, "Уже", 21);
            AddZhereb(context, comp, "Бомболюк", 24);
            AddZhereb(context, comp, "Кайф", 50);
            AddZhereb(context, comp, "Колхоз дело добровольное", 23);


            AddZherebPrevChamp(context, comp, "Мания", 1);
            AddZherebPrevChamp(context, comp, "Фиг-Вам", 2);
            AddZherebPrevChamp(context, comp, "Людмила Петрова", 3);
            AddZherebPrevChamp(context, comp, "Мандраж", 4);
            AddZherebPrevChamp(context, comp, "Дикие колобки", 6.5);
            AddZherebPrevChamp(context, comp, "Дубль-В", 6.5);
            AddZherebPrevChamp(context, comp, "Некстати", 6.5);
            AddZherebPrevChamp(context, comp, "Нечисть", 6.5);

        }

        protected void SeedZherebSoccer(Db context)
        {
            var comp = context.CompetitionSet.Local.First(f => f.Type == GameType.Soccer);

            //AddZhereb(context, comp, "Бичура", 58);
            //AddZhereb(context, comp, "(непонятное название)", 21);            

            AddZhereb(context, comp, "Уже", 3);
            AddZhereb(context, comp, "Сокол", 1);
            AddZhereb(context, comp, "Чума", 5);
            AddZhereb(context, comp, "Колхоз дело добровольное", 8);
            AddZhereb(context, comp, "Негодяи", 29);
            AddZhereb(context, comp, "Хвосты", 12);
            AddZhereb(context, comp, "ОбмАненые", 16);
            AddZhereb(context, comp, "Синема", 37);
            AddZhereb(context, comp, "Корсары удачи", 2);
            AddZhereb(context, comp, "ЧеГеварнутые строители", 20);
            AddZhereb(context, comp, "Бух-та", 7);
            AddZhereb(context, comp, "Держи Глаза", 24);
            AddZhereb(context, comp, "Джа", 44);
            AddZhereb(context, comp, "Куркули", 33);
            AddZhereb(context, comp, "Манты", 57);
            AddZhereb(context, comp, "Лихо", 48);
            AddZhereb(context, comp, "Беларусь", 28);
            AddZhereb(context, comp, "Лупцовщики", 41);
            AddZhereb(context, comp, "Мандраж", 15);
            AddZhereb(context, comp, "Синие Лебеди", 45);
            AddZhereb(context, comp, "ЗООПарк", 25);
            AddZhereb(context, comp, "Сибирские зебры", 6);
            AddZhereb(context, comp, "Дикие колобки", 19);
            AddZhereb(context, comp, "Сибирский Горностай", 42);
            AddZhereb(context, comp, "Хреновые спортсмены", 46);
            AddZhereb(context, comp, "Трикомана", 23);
            AddZhereb(context, comp, "Дубль-В", 4);
            AddZhereb(context, comp, "Бояне", 27);
            AddZhereb(context, comp, "Любители Активного Отдыха", 10);
            AddZhereb(context, comp, "Безопасный Кекс", 31);
            AddZhereb(context, comp, "Азимут", 35);
            AddZhereb(context, comp, "Некстати", 38);
            //AddZhereb(context, comp, "Апилки", 14);
            AddZhereb(context, comp, "Баня", 18);
            AddZhereb(context, comp, "Бомболюк", 39);
            AddZhereb(context, comp, "Фиг-Вам", 52);
            AddZhereb(context, comp, "Телевтузики", 26);
            AddZhereb(context, comp, "Нечисть", 56);
            AddZhereb(context, comp, "Кайф", 60);
            AddZhereb(context, comp, "НаМана", 9);
            AddZhereb(context, comp, "Джем", 30);
            AddZhereb(context, comp, "Звездолет", 13);
            AddZhereb(context, comp, "Клещи", 47);

            AddZherebPrevChamp(context, comp, "Сенаторы", 1);
            AddZherebPrevChamp(context, comp, "Бардак", 2);
            AddZherebPrevChamp(context, comp, "В дрова", 3);
            AddZherebPrevChamp(context, comp, "Людмила Петрова", 4);
            AddZherebPrevChamp(context, comp, "Апилки", 6.5);
            AddZherebPrevChamp(context, comp, "Кряки", 6.5);
            AddZherebPrevChamp(context, comp, "Легион", 6.5);
            AddZherebPrevChamp(context, comp, "Мания", 6.5);
        }

        protected void SeedZherebCarnival(Db context)
        {
            var comp = context.CompetitionSet.Local.First(f => f.Type == GameType.Carnival);

            
            for (int i = 1; i < 6; i++)
                context.CompetitionRefereeSet.Add(new CompetitionReferee()
                {
                    IsMainReferee = false,
                    Competition = comp,
                    Name = string.Format("Cудья №{0}", i)
                });

            AddZhereb(context, comp, "Азимут", 1);
            AddZhereb(context, comp, "Баня", 2);
            AddZhereb(context, comp, "Бардак", 3);
            AddZhereb(context, comp, "Безопасный Кекс", 4);
            AddZhereb(context, comp, "Бомболюк", 5);
            AddZhereb(context, comp, "Бояне", 6);
            AddZhereb(context, comp, "Бух-та", 7);
            AddZhereb(context, comp, "В дрова", 8);
            AddZhereb(context, comp, "Держи Глаза", 9);
            AddZhereb(context, comp, "Джа", 10);
            AddZhereb(context, comp, "Джем", 11);
            AddZhereb(context, comp, "Дикие колобки", 12);
            AddZhereb(context, comp, "Дубль-В", 13);
            AddZhereb(context, comp, "ЗАО «Гондурас»", 14);
            AddZhereb(context, comp, "Звездолет", 15);
            AddZhereb(context, comp, "ЗООПарк", 16);
            AddZhereb(context, comp, "Клещи", 17);
            AddZhereb(context, comp, "Колхоз дело добровольное", 18);
            AddZhereb(context, comp, "Корсары удачи", 19);
            AddZhereb(context, comp, "Кряки", 20);
            AddZhereb(context, comp, "Куркули", 21);
            AddZhereb(context, comp, "Любители Активного Отдыха", 22);
            AddZhereb(context, comp, "Легион", 23);
            AddZhereb(context, comp, "Лихо", 24);
            AddZhereb(context, comp, "Людмила Петрова", 25);
            AddZhereb(context, comp, "Мандраж", 26);
            AddZhereb(context, comp, "Мания", 27);
            AddZhereb(context, comp, "Манты", 28);
            AddZhereb(context, comp, "Не дробя", 29);
            AddZhereb(context, comp, "Негодяи", 30);
            AddZhereb(context, comp, "Некстати", 31);
            AddZhereb(context, comp, "Нечисть", 32);
            AddZhereb(context, comp, "ОбмАненые", 33);
            AddZhereb(context, comp, "Пионеры О. Бендера", 34);
            AddZhereb(context, comp, "Санта-Мана", 35);
            AddZhereb(context, comp, "Сенаторы", 36);
            AddZhereb(context, comp, "Сибирские зебры", 37);
            AddZhereb(context, comp, "Сокол", 38);
            AddZhereb(context, comp, "Телевтузики", 39);
            AddZhereb(context, comp, "Трикомана", 40);
            AddZhereb(context, comp, "Уже", 41);
            AddZhereb(context, comp, "Хвосты", 42);
            AddZhereb(context, comp, "Хреновые спортсмены", 43);
            AddZhereb(context, comp, "ЧеГеварнутые строители", 44);
            AddZhereb(context, comp, "Чума", 45);

        }

        protected void SeedZherebSolo(Db context)
        {
            var comp = context.CompetitionSet.Local.First(f => f.Type == GameType.SoloSong);

            context.CompetitionRefereeSet.Add(new CompetitionReferee()
            {
                IsMainReferee = true,
                Competition = comp,
                Name = string.Format("Главный судья")
            });

            for (int i = 1; i < 6; i++)
                context.CompetitionRefereeSet.Add(new CompetitionReferee()
                {
                    IsMainReferee = false,
                    Competition = comp,
                    Name = string.Format("Cудья №{0}", i)
                });


            AddZhereb(context, comp, "Любители Активного Отдыха", 1);
            AddZhereb(context, comp, "Синема", 2);
            AddZhereb(context, comp, "Бардак", 3);
            AddZhereb(context, comp, "Пионеры О. Бендера", 4);
            AddZhereb(context, comp, "Корсары удачи", 5);
            AddZhereb(context, comp, "Лупцовщики", 6);
            AddZhereb(context, comp, "Бух-та", 7);
            AddZhereb(context, comp, "ОбмАненые", 8);
            AddZhereb(context, comp, "НаМана", 9);
            AddZhereb(context, comp, "Дубль-В", 10);
            AddZhereb(context, comp, "Негодяи", 11);
            AddZhereb(context, comp, "ЧеГеварнутые строители", 12);
            AddZhereb(context, comp, "Манты", 13);
            AddZhereb(context, comp, "ЗООПарк", 14);
            AddZhereb(context, comp, "Дикие колобки", 15);
            AddZhereb(context, comp, "Мания", 16);
            AddZhereb(context, comp, "Держи Глаза", 17);
            AddZhereb(context, comp, "Че", 18);
            AddZhereb(context, comp, "Людмила Петрова", 19);
            AddZhereb(context, comp, "Беларусь", 20);
            AddZhereb(context, comp, "Куркули", 21);
            AddZhereb(context, comp, "Лихо", 22);
            AddZhereb(context, comp, "Синие Лебеди", 23);
            AddZhereb(context, comp, "Колхоз дело добровольное", 24);
            AddZhereb(context, comp, "Хреновые спортсмены", 25);
            AddZhereb(context, comp, "Мандраж", 26);
            AddZhereb(context, comp, "Живой уголок", 27);
            AddZhereb(context, comp, "В дрова", 28);
            AddZhereb(context, comp, "Кряки", 29);
            AddZhereb(context, comp, "Безопасный Кекс", 30);
            AddZhereb(context, comp, "ЗАО «Гондурас»", 31);
            AddZhereb(context, comp, "Азимут", 32);
            AddZhereb(context, comp, "Сибирские зебры", 33);
            AddZhereb(context, comp, "Фиг-Вам", 34);
            AddZhereb(context, comp, "Клещи", 35);
            AddZhereb(context, comp, "Звездолет", 36);
            AddZhereb(context, comp, "Джа", 37);
            AddZhereb(context, comp, "Телевтузики", 38);
            AddZhereb(context, comp, "Баня", 39);
            AddZhereb(context, comp, "Некстати", 40);
            AddZhereb(context, comp, "Нечисть", 41);
            AddZhereb(context, comp, "Трикомана", 42);
            AddZhereb(context, comp, "Хвосты", 43);
            AddZhereb(context, comp, "Джем", 44);
            AddZhereb(context, comp, "Уже", 45);
            AddZhereb(context, comp, "Бомболюк", 46);
            AddZhereb(context, comp, "Кайф", 47);
            AddZhereb(context, comp, "Сенаторы", 48);
            AddZhereb(context, comp, "Легион", 49);

        }


        protected void SeedZherebRugby(Db context)
        {
            var comp = context.CompetitionSet.Local.First(f => f.Type == GameType.Rugby);

            AddZhereb(context, comp, "Нечисть", 38);
            AddZhereb(context, comp, "Клещи", 34);
            AddZhereb(context, comp, "Телевтузики", 30);
            AddZhereb(context, comp, "Азимут", 23);
            AddZhereb(context, comp, "Кряки", 57);
            AddZhereb(context, comp, "Людмила Петрова", 58);
            AddZhereb(context, comp, "Лихо", 53);
            AddZhereb(context, comp, "Держи Глаза", 59);
            AddZhereb(context, comp, "Бояне", 60);
            AddZhereb(context, comp, "Чума", 55);
            AddZhereb(context, comp, "Бомболюк", 56);
            AddZhereb(context, comp, "Бух-та", 49);
            AddZhereb(context, comp, "Дикие колобки", 50);
            AddZhereb(context, comp, "Дубль-В", 51);
            AddZhereb(context, comp, "Корсары удачи", 52);
            AddZhereb(context, comp, "Мандраж", 22);
            AddZhereb(context, comp, "Хвосты", 26);
            AddZhereb(context, comp, "Сибирский Горностай", 48);
            AddZhereb(context, comp, "Манты", 47);
            AddZhereb(context, comp, "Беларусь", 45);
            AddZhereb(context, comp, "ЧеГеварнутые строители", 46);
            AddZhereb(context, comp, "ЗАО «Гондурас»", 19);
            AddZhereb(context, comp, "Трикомана", 42);
            AddZhereb(context, comp, "Хреновые спортсмены", 43);
            AddZhereb(context, comp, "Любители Активного Отдыха", 41);
            AddZhereb(context, comp, "Апилки", 27);
            AddZhereb(context, comp, "Легион", 31);
            AddZhereb(context, comp, "Сибирские зебры", 35);
            AddZhereb(context, comp, "Сенаторы", 61);


            AddZherebPrevChamp(context, comp, "Фиг-Вам", 1);
            AddZherebPrevChamp(context, comp, "В дрова", 2);
            AddZherebPrevChamp(context, comp, "Уже", 3);
            AddZherebPrevChamp(context, comp, "Безопасный Кекс", 4);
            AddZherebPrevChamp(context, comp, "Кайф", 6.5);
            AddZherebPrevChamp(context, comp, "Мания", 6.5);
            AddZherebPrevChamp(context, comp, "Бардак", 6.5);
            AddZherebPrevChamp(context, comp, "Негодяи", 6.5);
        }

        protected void SeedZherebTourRelay(Db context)
        {
            var comp = context.CompetitionSet.Local.First(f => f.Type == GameType.TourRelay);

            context.CompetitionRefereeSet.Add(new CompetitionReferee()
            {
                IsMainReferee = true,
                Competition = comp,
                Name = string.Format("Главный судья")
            });

            AddZhereb(context, comp, "Баня", 19);
            AddZhereb(context, comp, "Бардак", 29);
            AddZhereb(context, comp, "Безопасный Кекс", 37);
            AddZhereb(context, comp, "Бомболюк", 16);
            AddZhereb(context, comp, "Бояне", 3);
            AddZhereb(context, comp, "В дрова", 10);
            AddZhereb(context, comp, "Держи Глаза", 36);
            AddZhereb(context, comp, "Джа", 34);
            AddZhereb(context, comp, "Джем", 22);
            AddZhereb(context, comp, "Дикие колобки", 14);
            AddZhereb(context, comp, "Звездолет", 30);
            AddZhereb(context, comp, "ЗООПарк", 1);
            AddZhereb(context, comp, "Кайф", 17);
            AddZhereb(context, comp, "Клещи", 18);
            AddZhereb(context, comp, "Колхоз дело добровольное", 32);
            AddZhereb(context, comp, "Корсары удачи", 13);
            AddZhereb(context, comp, "Кряки", 9);
            AddZhereb(context, comp, "Легион", 21);
            AddZhereb(context, comp, "Людмила Петрова", 28);
            AddZhereb(context, comp, "Мандраж", 33);
            AddZhereb(context, comp, "Мания", 7);
            AddZhereb(context, comp, "Манты", 15);
            AddZhereb(context, comp, "Негодяи", 11);
            AddZhereb(context, comp, "Некстати", 39);
            AddZhereb(context, comp, "Нечисть", 2);
            AddZhereb(context, comp, "ОбмАненые", 27);
            AddZhereb(context, comp, "Апилки", 5);
            AddZhereb(context, comp, "Пионеры О. Бендера", 6);
            AddZhereb(context, comp, "Сибирские зебры", 38);
            AddZhereb(context, comp, "Сибирский Горностай", 20);
            AddZhereb(context, comp, "Синие Лебеди", 35);
            AddZhereb(context, comp, "Сокол", 8);
            AddZhereb(context, comp, "Телевтузики", 23);
            AddZhereb(context, comp, "Трикомана", 24);
            AddZhereb(context, comp, "Хвосты", 31);
            AddZhereb(context, comp, "Хреновые спортсмены", 4);
            AddZhereb(context, comp, "ЧеГеварнутые строители", 12);
            AddZhereb(context, comp, "Чума", 40);

            AddZherebPrevChamp(context, comp, "ЗАО «Гондурас»", 1);
            AddZherebPrevChamp(context, comp, "Бух-та", 3);
            AddZherebPrevChamp(context, comp, "Фиг-Вам", 4);
            AddZherebPrevChamp(context, comp, "Дубль-В", 5);
            AddZherebPrevChamp(context, comp, "Азимут", 6);
            AddZherebPrevChamp(context, comp, "Уже", 7);
            AddZherebPrevChamp(context, comp, "Сенаторы", 8);
        }



        protected void AddZherebPrevChamp(Db context, Competition comp, string teamName, double champPlace)
        {
            try
            {
            
                context.TeamCompetitionSet.Add(new TeamCompetition() { Team = context.TeamSet.Local.First(f => f.Name == teamName), IsPastWinner = true, Competition = comp, PastWinnerPlace = champPlace });
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        protected void AddZhereb(Db context, Competition comp, string teamName, short zhereb)
        {
            try
            {
              

                context.TeamCompetitionSet.Add(new TeamCompetition() { Team = context.TeamSet.Local.First(f => f.Name == teamName), Order = zhereb, Competition = comp });
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
