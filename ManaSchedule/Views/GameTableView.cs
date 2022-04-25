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
using Crainiate.Diagramming.Forms;

namespace ManaSchedule.Views
{
    
   

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
   
                    if (game.Team != null && View.TeamCompetitions[game.Team.Id].IsPastWinner)
                    {
                        label += string.Format("({0}) ", View.TeamCompetitions[game.Team.Id].PastWinnerPlace.ToString());
                    }
                    else
                    {
                        if (game.ParentGame1 == null && game.Team != null) label += string.Format("({0}) ", View.TeamCompetitions[game.Team.Id].Order.ToString());
                    }

                    if (game.Team != null) label += game.Team.Name.Length < 20 ? game.Team.Name :  game.Team.Name.Substring(0,20);
                    label += Environment.NewLine;
                    if (game.Team2Missed == true) label += "[-] ";
                    if (game.Team2Win == true) label += "[✓] ";

                    if (game.Team2 != null && View.TeamCompetitions[game.Team2.Id].IsPastWinner)
                    {
                        label += string.Format("({0}) ", View.TeamCompetitions[game.Team2.Id].PastWinnerPlace.ToString());
                    }
                    else
                        if (game.ParentGame2 == null && game.Team2 != null) label += string.Format("({0}) ", View.TeamCompetitions[game.Team2.Id].Order.ToString());
                    if (game.Team2 != null) label += game.Team2.Name.Length < 20 ? game.Team2.Name :  game.Team2.Name.Substring(0,20);
                   
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

            ContentCaption = string.Format("{0} - Турнирная таблица", content.Name);

            var tt = DbContext.TeamCompetitionSet.Where(f => f.CompetitionId == Competition.Id).GroupBy(f=>f.Team).Where(f=>f.Count() > 1).ToList();
            if (tt.Count > 0)
            {

            }

            TeamCompetitions = DbContext.TeamCompetitionSet.Where(f => f.CompetitionId == Competition.Id).ToDictionary(f => f.TeamId, f => f);

            var teams = DbContext.TeamSet.Where(f=>f.Used).ToList();

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
                    GameService.UpdateGame(game);
                    UpdateDiagram();
                    diagram.Refresh();
                }
            }
        }

      
        public override Janus.Windows.Ribbon.Ribbon RibbonControl
        {
            get
            {
                return ribbon1;
            }
        }

        private void btExportToExcel_Click(object sender, Janus.Windows.Ribbon.CommandEventArgs e)
        {
           
        }

        private void btExportToImage_Click(object sender, Janus.Windows.Ribbon.CommandEventArgs e)
        {
            using (var fs = new SaveFileDialog() { FileName = string.Format("{0}.png", Competition.Name), Filter = "png (*.png)|*.png" })
                if (fs.ShowDialog(this) == DialogResult.OK)
                {

                    Render render = new Render();

                    render.AddRenderer(typeof(GameShape), new GameShapeRenderer(this));

                    Rectangle renderRect = new Rectangle(new Point(0, 0), Size.Round(diagram.Model.Size));

                    //Get the bounds of the renderlist
                    if (Singleton.Instance.ClipExport)
                    {
                        renderRect = System.Drawing.Rectangle.Round(diagram.Model.Elements.GetBounds());
                        renderRect.Inflate(20, 20);

                        if (renderRect.X < 0) renderRect.X = 0;
                        if (renderRect.Y < 0) renderRect.Y = 0;
                    }

                    //Set the render rectangle
                    render.Zoom = 100;
                    render.RenderRectangle = renderRect;
                    render.Layers = diagram.Model.Layers;
                    render.Elements = diagram.Model.Elements;

                    //Use a default paging
                    render.RenderDiagram(renderRect, new Paging());

                    using (var s = fs.OpenFile())
                    {
                        render.Bitmap.Save(s, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    
                }
                    
        }
          
        
        
    }
    public class GameShape : Shape
    { 
    
    }

   

}
