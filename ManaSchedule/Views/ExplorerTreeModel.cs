using Aga.Controls.Tree;
using ManaSchedule.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManaSchedule.Views
{
    public class ExplorerTreeModel : ITreeModel
    {
        public System.Collections.IEnumerable GetChildren(TreePath treePath)
        {
            var result = new List<object>();
            if (treePath.FirstNode == null)
            {
                result.Add(new SummaryNode() { Text= "Сводный результат", Icon = Properties.Resources.chart_column });
                result.Add(new TeamNode() { Text = "Команды", Icon = Properties.Resources.users_family});
                result.Add(new PersonNode() { Text = "Люди", Icon = Properties.Resources.user });

                using (var db = new Db())
                { 
                   foreach (var c in db.CompetitionSet.OrderBy(f=>f.Type))
                   switch (c.Type)
                   {
                       case Models.GameType.Soccer:
                           result.Add(new SoccerNode() { Item = c, Text = c.Name, Icon = Properties.Resources.soccer_ball });
                           break;
                       default:
                           throw new NotSupportedException();
                           break;
                   }
                
                }

            }
            else
            {

            }
            return result;
        }
    

        public bool IsLeaf(TreePath treePath)
        {
            return true;
        }

        public event EventHandler<TreeModelEventArgs> NodesChanged;

        public event EventHandler<TreeModelEventArgs> NodesInserted;

        public event EventHandler<TreeModelEventArgs> NodesRemoved;

        public event EventHandler<TreePathEventArgs> StructureChanged;
    }
}
