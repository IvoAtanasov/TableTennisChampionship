namespace TableTennisChampionshipMain.ViewModels
{
    using System;
    using System.Collections.Generic;
    public class SelectedPlayerInfo
    {
        public int? SelectedPlayerID { get; set; }
        public IEnumerable<PlayerInfo> PlayerList { get; set; }

        public SelectedPlayerInfo()
        { 
            this.PlayerList=new List<PlayerInfo>();
        }
    }
}