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
    }

    public class SummaryNode : ExplorerTreeNode
    {

    }
    public class TeamNode : ExplorerTreeNode
    {

    }

    public class PersonNode : ExplorerTreeNode
    {

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

    }

}
