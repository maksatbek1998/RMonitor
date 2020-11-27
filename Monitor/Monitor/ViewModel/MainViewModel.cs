using Monitor.Models;
using Monitor.ViewModel.BaseViews;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Monitor.ViewModel
{
    class MainViewModel : BaseViews.BaseViewModel
    {
        DataBase.BaseData dataBase;
        MediaElement element;

        #region Обьявление Команд

        public ICommand Con { get; set; }
        public ICommand ButClick { get; set; }

        #endregion

        #region Пересенные

        private static string _number;
        public string number
        {
            get => _number;
            set => Set(ref _number, value);
        }

        private static string _MainNumber = "";
        public string MainNumber
        {
            get => _MainNumber;
            set => Set(ref _MainNumber, value);
        }

        private static string _MainOper = "";
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

        #endregion

        #region Выбранная очередь

        private Turns _SelectedNum;

        public Turns SelectedNum
        {
            get => _SelectedNum;
            set
            {
                Set(ref _SelectedNum, value);
            }
        }

        #endregion

        public MainViewModel()
        {

        }

        #region ТикТаймера

        public void timeDelation(ref MediaElement obj)
        {
            element = (MediaElement)obj;
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
        #endregion

    }

}
