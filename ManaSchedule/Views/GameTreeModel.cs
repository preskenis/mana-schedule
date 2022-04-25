using Aga.Controls.Tree;
using ManaSchedule.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManaSchedule.Views
{
   


    public class GameTreeModel : ITreeModel
    {
        public class CompetitionNode
        {
            public Competition Competition { get; set; }
            public override string ToString()
            {
                return Competition != null ? Competition.Name : "";
            }
        }

        public class StageNode
        {
            public Stage Stage { get; set; }

            public override string ToString()
            {
                return Stage != null ? Stage.Name : "";
            }

        }

        public class GameNode
        {
            public Game Game { get; set; }

            public override string ToString()
            {
                if (Game == null) return "";
                return $"{Game?.Team?.Name} - {Game?.Team2?.Name}";
            }
        }


        public System.Collections.IEnumerable GetChildren(TreePath treePath)
        {
            var result = new List<object>();
            if (treePath.FirstNode == null)
            {
                using (var db = new Db())
                {
                    foreach (var item in db.CompetitionSet.OrderBy(f => f.Type))
                    {
                        result.Add(new CompetitionNode() {Competition = item});
                    }

                }

            }
            else if (treePath.LastNode is CompetitionNode competitionNode)
            {
                using (var db = new Db())
                {
                    foreach (var item in db.StageSet.Where(f => f.CompetitionId == competitionNode.Competition.Id))
                    {
                        result.Add(new StageNode() {Stage = item});
                    }


                }
            }
            else if (treePath.LastNode is StageNode stageNode)
            {
                using (var db = new Db())
                {
                    foreach (var item in db.GameSet.Where(f => f.StageId == stageNode.Stage.Id))
                    {
                        result.Add(new GameNode() { Game = item });
                    }


                }
            }
            


            //else
            //{
            //    if (treePath.LastNode is SoccerNode 
            //        || treePath.LastNode is VolleyNode 
            //        || treePath.LastNode is RugbyNode
            //        || treePath.LastNode is CookNode
            //        || treePath.LastNode is TourRelayNode
            //        || treePath.LastNode is SoloSongNode
            //        || treePath.LastNode is ShowSongNode
            //        || treePath.LastNode is LagerNode
            //        || treePath.LastNode is CarnivalNode


            //        )

            //    {
            //        result.Add(new ZherebNode() { Item = (treePath.LastNode as CompetitionNode).Item });
            //        result.Add(new GameListNode() { Item = (treePath.LastNode as CompetitionNode).Item });

            //    }

            //    if (treePath.LastNode is SoccerNode || treePath.LastNode is VolleyNode || treePath.LastNode is RugbyNode)
            //    {
            //        result.Add(new GameTableNode() { Item = (treePath.LastNode as CompetitionNode).Item });
            //    }

            //    if (treePath.LastNode is CookNode
            //        || treePath.LastNode is TourRelayNode
            //        || treePath.LastNode is SoloSongNode
            //        || treePath.LastNode is ShowSongNode
            //        || treePath.LastNode is LagerNode
            //        || treePath.LastNode is CarnivalNode

            //        )
            //    {
            //        result.Add(new GameResultNode() { Item = (treePath.LastNode as CompetitionNode).Item });

            //    }

            //    if (treePath.LastNode is ScheduleNode)
            //    {
            //        result.Add(new ScheduleGeneratorNode() { Text = "Генерация" });
            //    }



            //}

            return result;
        }
    

        public bool IsLeaf(TreePath treePath)
        {
            if (treePath.LastNode is CompetitionNode) return false;
            if (treePath.LastNode is StageNode) return false;  

            return true;
        }

        public event EventHandler<TreeModelEventArgs> NodesChanged;

        public event EventHandler<TreeModelEventArgs> NodesInserted;

        public event EventHandler<TreeModelEventArgs> NodesRemoved;

        public event EventHandler<TreePathEventArgs> StructureChanged;
    }
}
