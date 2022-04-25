using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ManaSchedule.DataModels;
using ManaSchedule.Services;

namespace ManaSchedule.Views
{
    public partial class CompetitionView : ContentView
    {

        public CompetitionView()
        {
            InitializeComponent();
           
        }

        public override void OnClosing()
        {
            base.OnClosing();
        }

        public GameService GameService { get; set; }

        public Competition Competition { get; set; }

        public virtual void Init(Competition content)
        {
            Competition = DbContext.CompetitionSet.First(f => f.Id == content.Id);
            GameService = GameService.GetGameService(Competition, DbContext);
        }

      
    }
}
