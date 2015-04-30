using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ManaSchedule.DataModels;
using Crainiate.Diagramming;
using ManaSchedule.Services;
using Crainiate.Diagramming.Forms.Rendering;

namespace ManaSchedule.Views
{
    public class GameShape : Shape
    {

    }

   

    public partial class GameTableView : CompetitionView
    {
        public class GameShapeRenderer : ShapeRender
        {
            public GameTableView View { get; set; }
            public GameShapeRenderer(GameTableView view)
            {
                View = view;
            }
            public override void RenderElement(IRenderable element, Graphics graphics, Render render)
            {
                if (element is GameShape)
                {
                    var shape = element as GameShape;
                    var game = shape.Tag as Game;

                    shape.BackColor = Color.White;



                    var label = "";

                    if (game.Team1Missed == true) label += "[-] ";
                    if (game.Team1Win == true) label += "[✓] ";
                    if (game.ParentGame1 == null && game.Team != null) label += string.Format("({0}) ", View.TeamCompetitions[game.Team.Id].Order.ToString());
                    if (game.Team != null)label += game.Team.Name;
                    label += Environment.NewLine;
                    if (game.Team2Missed == true) label += "[-] ";
                    if (game.Team2Win == true) label += "[✓] ";
                    if (game.ParentGame2 == null && game.Team2 != null) label += string.Format("({0}) ", View.TeamCompetitions[game.Team2.Id].Order.ToString());
                    if (game.Team2 != null)label += game.Team2.Name;
                   
                    switch (game.GetState())
                    { 
                        case GameState.Finished:
                            shape.BackColor = Color.DarkGreen;
                            break;
                        case GameState.WaitingEnd:
                            shape.BackColor = Color.LightGreen;
                            break;
                        case GameState.AllMissed:
                            shape.BackColor = Color.Red;
                            break;
                        case GameState.Team1Missed:
                            shape.BackColor = Color.LightSkyBlue;
                            break;
                        case GameState.Team2Missed:
                            shape.BackColor = Color.LightSkyBlue;
                            break;

                    }

                    shape.Label = new Crainiate.Diagramming.Label(label);


                }

                base.RenderElement(element, graphics, render);

            }

        }



        public GameTableView()
        {
            InitializeComponent();
            diagram.MouseWheel += diagram_MouseWheel;

            diagram.Render.AddRenderer(typeof(GameShape), new GameShapeRenderer(this));

            Model model = diagram.Model;
            diagram.Paging.Enabled = false;
            diagram.Model.SetSize(new Size(5000, 10000));
            diagram.Refresh();
        }

        void diagram_MouseWheel(object sender, MouseEventArgs e)
        {
            if (ModifierKeys.HasFlag(Keys.Control))
                diagram.Zoom += e.Delta / 10;
        }

        private Dictionary<Game, Shape> ShapeDict = new Dictionary<Game, Shape>();
        private Dictionary<int, TeamCompetition> TeamCompetitions = null;

        public override void OnClosing()
        { }

        public override void Init(Competition content)
        {
            base.Init(content);

            TeamCompetitions = DbContext.TeamCompetitionSet.Where(f => f.CompetitionId == Competition.Id).ToDictionary(f => f.TeamId, f => f);

            var teams = DbContext.TeamSet.ToList();

            var games = DbContext.GameSet.Where(f => f.CompetitionId == Competition.Id).ToList();

             
            var stages = DbContext.StageSet.Where(f => f.CompetitionId == Competition.Id).ToList();

            var xOffset = 10;

            var yStart = 60;
            var yStep = 40;
            Stage lastStage = null; 
            foreach (var stage in stages.OrderByDescending(f=>f.Type))
            {

                diagram.Model.Shapes.Add(new Crainiate.Diagramming.Shape()
                {
                    Location = new PointF(xOffset, 10),
                    Width = 150,
                    Height = 20,
                    Label = new Crainiate.Diagramming.Label(stage.Name),
                    BackColor = Color.LightGray
                });


                if (lastStage != null && lastStage.Game.Count > stage.Game.Count)
                {
                    yStart = 60 + yStep;
                    yStep = (int)(yStep * 2);
                }

                var yOffset = yStart;
                 foreach (var game  in stage.Game)
                 {

                     var shape = new GameShape();
                     shape.Location = new PointF(xOffset, yOffset);
                     yOffset += yStep;
                     shape.Width = 150;
                     shape.Height = 35;
                     shape.DrawSelected = false;
                     shape.Tag = game;
                     diagram.Model.Shapes.Add(game.Id.ToString(), shape);
                     ShapeDict.Add(game, shape);

                 }

                 lastStage = stage;
                 xOffset += 200;
                 
            }



            Arrow arrow = new Arrow();
            arrow.DrawBackground = true;
            arrow.Inset = 8;
            
            foreach (var item in ShapeDict)
            {
                if (item.Key.ParentGame1 != null && ShapeDict.ContainsKey(item.Key.ParentGame1))
                {
                    var line = new Link(diagram.Model.Shapes[item.Key.ParentGame1.Id.ToString()], diagram.Model.Shapes[item.Key.Id.ToString()]);
                    line.End.Marker = arrow;
                    diagram.Model.Lines.Add(diagram.Model.Lines.CreateKey(), line);
                }
                if (item.Key.ParentGame2 != null && ShapeDict.ContainsKey(item.Key.ParentGame2))
                {
                    var line = new Link(diagram.Model.Shapes[item.Key.ParentGame2.Id.ToString()], diagram.Model.Shapes[item.Key.Id.ToString()]);
                    line.End.Marker = arrow;
                    diagram.Model.Lines.Add(diagram.Model.Lines.CreateKey(), line);
                }
            }

            diagram.Model.SetSize(new Size(xOffset, yStart * 2));

            UpdateDiagram();
            diagram.Refresh();


            GameUpdater = new GameUpdater(DbContext);

        }

        private void UpdateDiagram()
        {
            foreach (var item in ShapeDict)
            {
                var game = item.Key;
                var label = (game.Team != null ? string.Format("({1}){0}", game.Team.Name, TeamCompetitions[game.Team.Id].Order) : "");
                label += Environment.NewLine + (game.Team2 != null ? string.Format("({1}){0}", game.Team2.Name, TeamCompetitions[game.Team2.Id].Order) : "");
                item.Value.Label = new Crainiate.Diagramming.Label(label);
            }
        }

        public GameUpdater GameUpdater { get; set; }

        private void diagram_ElementDoubleClick(object sender, EventArgs e)
        {
            var s = sender as Shape;
            if (s == null) return;
            var game = s.Tag as Game;
            if (game == null) return;
             
            using (var form = new GameEditForm(game, DbContext))
            {
                if (form.ShowDialog(this) == DialogResult.OK )
                {
                    GameUpdater.UpdateGame(game);
                    UpdateDiagram();
                    diagram.Refresh();
                }
            }
        }
        
    }
}
