using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using UEFA.Model;

namespace UEFA.Pages
{
    /// <summary>
    /// Логика взаимодействия для UpdateStatistic.xaml
    /// </summary>
    public partial class UpdateStatistic : Page
    {
        public List<PlayerT> Players { get; set; }
        public List<TeamT> Teams { get; set; }
        public PlayerT Player { get; set; }

        public UpdateStatistic()
        {
            InitializeComponent();
            Players = Connection.NewInstance().PlayerT.ToList();
            Teams = Connection.NewInstance().TeamT.ToList();
            DataContext = this;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((Player = PlayerComboBox.SelectedItem as PlayerT) != null)
            {

                switch ((sender as Button).Name)
                {
                    case "AddMiss":
                        MissTB.Text = (++Player.StatisticPlayerT.Missed).ToString();
                        Player.TeamT.StatisticTeamT.Missed++;
                        break;
                    case "RemoveMiss":
                        MissTB.Text = (--Player.StatisticPlayerT.Missed).ToString();
                        Player.TeamT.StatisticTeamT.Missed--;
                        break;
                    case "AddGoal":
                        ScoredTB.Text = (++Player.StatisticPlayerT.Scored).ToString();
                        Player.TeamT.StatisticTeamT.Scored++;
                        break;
                    case "RemoveGoal":
                        ScoredTB.Text = (--Player.StatisticPlayerT.Scored).ToString();
                        Player.TeamT.StatisticTeamT.Scored--;
                        break;
                    case "AddRedCard":
                        RedCardTB.Text = (++Player.StatisticPlayerT.RedCards).ToString();
                        Player.TeamT.StatisticTeamT.RedCards++;
                        break;
                    case "RemoveRedCard":
                        RedCardTB.Text = (--Player.StatisticPlayerT.RedCards).ToString();
                        Player.TeamT.StatisticTeamT.RedCards--;
                        break;
                    case "AddYellowCard":
                        YellowCardTB.Text = (++Player.StatisticPlayerT.YellowCards).ToString();
                        Player.TeamT.StatisticTeamT.YellowCards++;
                        break;
                    case "RemoveYellowCard":
                        YellowCardTB.Text = (--Player.StatisticPlayerT.YellowCards).ToString();
                        Player.TeamT.StatisticTeamT.YellowCards--;
                        break;
                    case "AddSubstitution":
                        SubstitutionTB.Text = (++Player.StatisticPlayerT.Substitution).ToString();
                        Player.TeamT.StatisticTeamT.Substitution++;
                        break;
                    case "RemoveSubstitution":
                        SubstitutionTB.Text = (--Player.StatisticPlayerT.Substitution).ToString();
                        Player.TeamT.StatisticTeamT.Substitution--;
                        break;
                    case "AddSave":
                        SaveTB.Text = (++Player.StatisticPlayerT.SaveGoal).ToString();
                        Player.TeamT.StatisticTeamT.SaveGoal++;
                        break;
                    case "RemoveSave":
                        SaveTB.Text = (--Player.StatisticPlayerT.SaveGoal).ToString();
                        Player.TeamT.StatisticTeamT.SaveGoal--;
                        break;
                }
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            try
            {
                Connection.NewInstance().SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DataContext = null;
                Players = Connection.NewInstance().PlayerT.ToList();
                Teams = Connection.NewInstance().TeamT.ToList();
                DataContext = this;
            }
        }

        private void ScoredTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (int.Parse(ScoredTB.Text) < 0)
                {
                    ScoredTB.Text = (++Player.StatisticPlayerT.Scored).ToString();
                    Player.TeamT.StatisticTeamT.Scored++;
                }
                if (int.Parse(MissTB.Text) < 0)
                {
                    MissTB.Text = (++Player.StatisticPlayerT.Missed).ToString();
                    Player.TeamT.StatisticTeamT.Missed++;
                }
                if (int.Parse(RedCardTB.Text) < 0)
                {
                    RedCardTB.Text = (++Player.StatisticPlayerT.RedCards).ToString();
                    Player.TeamT.StatisticTeamT.RedCards++;
                }
                if (int.Parse(YellowCardTB.Text) < 0)
                {
                    YellowCardTB.Text = (++Player.StatisticPlayerT.YellowCards).ToString();
                    Player.TeamT.StatisticTeamT.YellowCards++;
                }
                if (int.Parse(SubstitutionTB.Text) < 0)
                {
                    SubstitutionTB.Text = (++Player.StatisticPlayerT.Substitution).ToString();
                    Player.TeamT.StatisticTeamT.Substitution++;
                }
                if (int.Parse(SaveTB.Text) < 0)
                {
                    SaveTB.Text = (++Player.StatisticPlayerT.SaveGoal).ToString();
                    Player.TeamT.StatisticTeamT.SaveGoal++;
                }
            }
            catch
            {


            }
        }
    }
}
