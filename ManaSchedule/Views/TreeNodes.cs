using ManaSchedule.DataModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ManaSchedule.Views
{
    public abstract class ExplorerTreeNode
    {
        public string Text { get; set; }
        public Bitmap Icon { get; set; }

        public abstract ContentView GetView();
    }

    public class SummaryNode : ExplorerTreeNode
    {
        public override ContentView GetView()
        {
            var view = new SummaryScoreView();
            view.Init();
            return view;
        }
    }
    public class TeamNode : ExplorerTreeNode
    {
        public override ContentView GetView()
        {
            var view = new TeamView();
            view.Init();
            return view;
        }
    }

    public class PersonNode : ExplorerTreeNode
    {
         public override ContentView GetView()
        {
            var view = new PersonView();
            view.Init();
            return view;
        }
    }

    public abstract class ItemNode<T> : ExplorerTreeNode
    {
        public T Item { get; set; }

    }

    public abstract class CompetitionNode : ItemNode<Competition>
    {

    }

    public class SoccerNode : CompetitionNode
    {
        public SoccerNode()
        {
            Text = "Футбол";
            Icon = Properties.Resources._1430184782_sport_soccer;
        }
        public override ContentView GetView()
        {
            var view = new CompetitionSummaryView();
            view.Init(Item);
            return view;
        }
    }

    public class VolleyNode : CompetitionNode
    {
        public VolleyNode()
        {
            Text = "Волейбол";
            Icon = Properties.Resources._1430183930_699881_icon_22_volleyball_20;
        }

        public override ContentView GetView()
        {
            var view = new CompetitionSummaryView();
            view.Init(Item);
            return view;
        }
    }
    public class RugbyNode : CompetitionNode
    {
        public RugbyNode()
        {
            Text = "Рэгби";
            Icon = Properties.Resources._1430183903_rugby_20;
        }

        public override ContentView GetView()
        {
            var view = new CompetitionSummaryView();
            view.Init(Item);
            return view;
        }
    }

    public class CookNode : CompetitionNode
    {
        public CookNode()
        {
            Text = "Конкурс кашеваров";
            Icon = Properties.Resources._1430319987_hamburger;
        }
        public override ContentView GetView()
        {
            var view = new CompetitionSummaryView();
            view.Init(Item);
            return view;
        }
    }

    public class CarnivalNode : CompetitionNode
    {
        public CarnivalNode()
        {
            Text = "Конкурс карнавальности";
            Icon = Properties.Resources._1430320271_user_clown;
        }
        public override ContentView GetView()
        {
            var view = new CompetitionSummaryView();
            view.Init(Item);
            return view;
        }
    }

    public class LagerNode : CompetitionNode
    {
        public LagerNode()
        {
            Text = "Конкурс лагерей";
            Icon = Properties.Resources._1430320145_circus;
        }
        public override ContentView GetView()
        {
            var view = new CompetitionSummaryView();
            view.Init(Item);
            return view;
        }
    }

    public class SoloSongNode : CompetitionNode
    {
        public SoloSongNode()
        {
            Text = "Соло-Песня";
            Icon = Properties.Resources._1430319956_acoustic_guitar;
        }
        public override ContentView GetView()
        {
            var view = new CompetitionSummaryView();
            view.Init(Item);
            return view;
        }
    }

    public class ShowSongNode : CompetitionNode
    {
        public ShowSongNode()
        {
            Text = "Шоу-Песня";
            Icon = Properties.Resources._1430319865_microphone;
        }
        public override ContentView GetView()
        {
            var view = new CompetitionSummaryView();
            view.Init(Item);
            return view;
        }
    }

    public class TourRelayNode : CompetitionNode
    {
        public TourRelayNode()
        {
            Text = "Тур-Эстафета";
            Icon = Properties.Resources._1430320339_animation;
        }
        public override ContentView GetView()
        {
            var view = new CompetitionSummaryView();
            view.Init(Item);
            return view;
        }
    }







    public class GameListNode : ItemNode<Competition>
    {
        public GameListNode()
        {
            Text = "Список игр";
        }
        public override ContentView GetView()
        {
            var view = new GameListView();
            view.Init(Item);
            return view;
        }
    }

    public class GameTableNode : ItemNode<Competition>
    {
        public GameTableNode()
        {
            Text = "Турнирная таблица";
        }
        public override ContentView GetView()
        {
            var view = new GameTableView();
            view.Init(Item);
            return view;
        }
    }

    public class ZherebNode : ItemNode<Competition>
    {
        public ZherebNode()
        {
            Text = "Жеребьёвка";
        }
        public override ContentView GetView()
        {
            var view = new ZherebView();
            view.Init(Item);
            return view;
        }
    }

}
