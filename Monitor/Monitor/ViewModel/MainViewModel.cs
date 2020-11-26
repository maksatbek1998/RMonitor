using Monitor.Models;
using Monitor.ViewModel.BaseViews;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace Monitor.ViewModel
{
    class MainViewModel : BaseViews.BaseViewModel
    {
        DataBase.BaseData dataBase;
        public ICommand Con { get; set; }
        public ICommand ButClick { get; set; }

        private static string _number;
        public string number
        {
            get => _number;
            set => Set(ref _number, value);
        }

        private static string _MainNumber;
        public string MainNumber
        {
            get => _MainNumber;
            set => Set(ref _MainNumber, value);
        }

        private static string _MainOper;
        public string MainOper
        {
            get => _MainOper;
            set => Set(ref _MainOper, value);
        }

        private static string _oper;
        public string oper
        {
            get => _oper;
            set => Set(ref _oper, value);
        }
        private static string _video;
        public string video
        {
            get => _video;
            set => Set(ref _video, value);
        }

        private ObservableCollection<Turns> _ListColl = new ObservableCollection<Turns>();

        public ObservableCollection<Turns> ListColl
        {
            get => _ListColl;

            set => Set(ref _ListColl, value);
        }
        #region Выбранная очередь

        private Turns _SelectedNum;

        public Turns SelectedNum
        {
            get => _SelectedNum;
            set
            {
                Set(ref _SelectedNum, value);
                StaticVariables.Number_Name = SelectedNum.number;
                StaticVariables.Operator_Name = SelectedNum.oper;
            }
        }

        #endregion
        public MainViewModel()
        {
            Con = new CommandView(new Action<object>(Conne));
            

            dataBase = new DataBase.BaseData();
            dataBase.del += db =>
            {
                if (db.Rows.Count > 0)
                {
                    var och = new ObservableCollection<Turns>();
                    for (int i = 0; i < db.Rows.Count; i++)
                    {
                        och.Add(
                        new Turns
                        {
                            number = db.Rows[i][0].ToString(),
                            oper = db.Rows[i][1].ToString()
                        });
                    }
                    MainNumber = och[0].number;
                    MainOper = och[0].oper;
                    ListColl = och;
                }
            };
            dataBase.SoursData("SELECT * from turns");
        }

        public void timeDelation(ref MediaElement obj)
        {
            MediaElement element = (MediaElement)obj;
            dataBase = new DataBase.BaseData();
            dataBase.del += bd =>
            {
                if (bd.Rows.Count > 0)
                {
                    for (int i = 0; i < bd.Rows.Count; i++)
                    {
                        if (DateTime.Now.ToString() == bd.Rows[i][1].ToString())
                        {
                            element.Source = new Uri(bd.Rows[i][6].ToString());
                            element.Play();
                        }
                        else if (DateTime.Now.ToString() == bd.Rows[i][2].ToString())
                        {
                            element.Stop();
                        }
                    }
                }
            };
            dataBase.SoursData("SELECT * FROM ads_schedules JOIN ads ON ads.id = ads_schedules.ads_id");
        }
        private void Conne(object obj)
        {
            NumberWindow numberWindow = new NumberWindow();
            numberWindow.Show();
            number = StaticVariables.Number_Name;
            oper = StaticVariables.Operator_Name;
        }
    }
}
