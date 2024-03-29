﻿using Aga.Controls.Tree;
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
                result.Add(new SummaryNode() { Text = "Общий итог", Icon = Properties.Resources.chart_column });
                result.Add(new ScheduleNode() { Text = "Расписание", Icon = Properties.Resources._1430704063_free_20_20 });
                result.Add(new TeamNode() { Text = "Команды", Icon = Properties.Resources.users_family });
                result.Add(new PersonNode() { Text = "Люди", Icon = Properties.Resources.user });
                result.Add(new RefereeNode() { Text = "Судьи", Icon = Properties.Resources._1430497231_699907_icon_38_whistle_20 });
                
                using (var db = new Db())
                {
                    foreach (var c in db.CompetitionSet.OrderBy(f => f.Type))
                        switch (c.Type)
                        {
                            case GameType.Soccer:
                                result.Add(new SoccerNode() { Item = c, Text = c.Name });
                                break;
                            case GameType.Volleyball:
                                result.Add(new VolleyNode() { Item = c, Text = c.Name });
                                break;
                            case GameType.Rugby:
                                result.Add(new RugbyNode() { Item = c, Text = c.Name });
                                break;
                            case GameType.Cook:
                                result.Add(new CookNode() { Item = c, Text = c.Name });
                                break;
                            case GameType.Lager:
                                result.Add(new LagerNode() { Item = c, Text = c.Name });
                                break;
                            case GameType.ShowSong:
                                result.Add(new ShowSongNode() { Item = c, Text = c.Name });
                                break;
                            case GameType.SoloSong:
                                result.Add(new SoloSongNode() { Item = c, Text = c.Name });
                                break;
                            case GameType.TourRelay:
                                result.Add(new TourRelayNode() { Item = c, Text = c.Name });
                                break;
                            case GameType.Carnival:
                                result.Add(new CarnivalNode() { Item = c, Text = c.Name });
                                break;
                            default:
                                throw new NotSupportedException();
                                break;
                        }

                }

            }
            else
            {
                if (treePath.LastNode is SoccerNode 
                    || treePath.LastNode is VolleyNode 
                    || treePath.LastNode is RugbyNode
                    || treePath.LastNode is CookNode
                    || treePath.LastNode is TourRelayNode
                    || treePath.LastNode is SoloSongNode
                    || treePath.LastNode is ShowSongNode
                    || treePath.LastNode is LagerNode
                    || treePath.LastNode is CarnivalNode
                    
                    
                    )

                {
                    result.Add(new ZherebNode() { Item = (treePath.LastNode as CompetitionNode).Item });
                    result.Add(new GameListNode() { Item = (treePath.LastNode as CompetitionNode).Item });
                    
                }

                if (treePath.LastNode is SoccerNode || treePath.LastNode is VolleyNode || treePath.LastNode is RugbyNode)
                {
                    result.Add(new GameTableNode() { Item = (treePath.LastNode as CompetitionNode).Item });
                }

                if (treePath.LastNode is CookNode
                    || treePath.LastNode is TourRelayNode
                    || treePath.LastNode is SoloSongNode
                    || treePath.LastNode is ShowSongNode
                    || treePath.LastNode is LagerNode
                    || treePath.LastNode is CarnivalNode
                    
                    )
                {
                    result.Add(new GameResultNode() { Item = (treePath.LastNode as CompetitionNode).Item });

                }

                if (treePath.LastNode is ScheduleNode)
                {
                    result.Add(new ScheduleGeneratorNode() { Text = "Генерация" });
                }



            }

            return result;
        }
    

        public bool IsLeaf(TreePath treePath)
        {
            if (treePath.LastNode is CompetitionNode) return false;
            if (treePath.LastNode is ScheduleNode) return false;  

            return true;
        }

        public event EventHandler<TreeModelEventArgs> NodesChanged;

        public event EventHandler<TreeModelEventArgs> NodesInserted;

        public event EventHandler<TreeModelEventArgs> NodesRemoved;

        public event EventHandler<TreePathEventArgs> StructureChanged;
    }
}
