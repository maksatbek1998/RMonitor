using System.Media;

namespace Monitor.Models
{
    public static class Naudio
    {
        public static void MusicPlay(string numSound, string operSound, string Lang)
        {
            if (Lang == "ru")
            {
                SoundPlayer Sound = new SoundPlayer(@"D:\music\ogpisound\ru\ЭКГ.wav");
                Sound.PlaySync();
                Sound.SoundLocation = @"D:\music\ogpisound\ru\а.wav";
                Sound.PlaySync();
                if (int.Parse(numSound) <= 100)
                {
                    Sound.SoundLocation = @"D:\music\ogpisound\ru\" + numSound + ".wav";
                    Sound.PlaySync();
                }
                else if (int.Parse(numSound) > 100 && int.Parse(numSound) < 1000)
                {
                    char sto = numSound[0];
                    string stosh = sto + "00";
                    Sound.SoundLocation = @"D:\music\ogpisound\ru\" + stosh + ".wav";
                    Sound.PlaySync();

                    if (numSound[1] == '0')
                    {
                        Sound.SoundLocation = @"D:\music\ogpisound\ru\" + numSound[2] + ".wav";
                        Sound.PlaySync();
                    }
                    else
                    {
                        string numSoundSub = numSound.Substring(1);
                        Sound.SoundLocation = @"D:\music\ogpisound\ru\" + numSoundSub + ".wav";
                        Sound.PlaySync();
                    }
                }
                else if (int.Parse(numSound) >= 1000 && int.Parse(numSound) < 10000)
                {
                    if (numSound[1] == '0' && numSound[2] == '0' && numSound[3] == '0')
                    {
                        string w = numSound.Substring(1);
                        char tish = numSound[0];
                        string stosh = tish + "000";
                        Sound.SoundLocation = @"D:\music\ogpisound\ru\" + stosh + ".wav";
                        Sound.PlaySync();
                    }
                    else
                    {
                        string w = numSound.Substring(1);
                        char tish = numSound[0];
                        string stosh = tish + "000";
                        Sound.SoundLocation = @"D:\music\ogpisound\ru\" + stosh + ".wav";
                        Sound.PlaySync();


                        if (numSound[1] == '0' && numSound[2] == '0')
                        {
                            Sound.SoundLocation = @"D:\music\ogpisound\ru\" + numSound[3] + ".wav";
                            Sound.PlaySync();
                        }
                        else if (numSound[1] == '0' && numSound[2] != '0')
                        {
                            string stos = numSound.Substring(2);
                            Sound.SoundLocation = @"D:\music\ogpisound\ru\" + stos + ".wav";
                            Sound.PlaySync();
                        }
                        else
                        {
                            char sto = numSound[1];
                            string stoshi = sto + "00";
                            Sound.SoundLocation = @"D:\music\ogpisound\ru\" + stoshi + ".wav";
                            Sound.PlaySync();
                            if (numSound[2] == '0')
                            {
                                Sound.SoundLocation = @"D:\music\ogpisound\ru\" + numSound[3] + ".wav";
                                Sound.PlaySync();
                            }
                            else
                            {
                                string numSoundSub = numSound.Substring(2);
                                Sound.SoundLocation = @"D:\music\ogpisound\ru\" + numSoundSub + ".wav";
                                Sound.PlaySync();
                            }
                        }
                    }
                }
                Sound.SoundLocation = @"D:\music\ogpisound\ru\пройдите_в_отдел.wav";
                Sound.PlaySync();
                Sound.SoundLocation = @"D:\music\ogpisound\ru\" + operSound + ".wav";
                Sound.PlaySync();
            }
            else if (Lang == "kg")
            {
                SoundPlayer Sound = new SoundPlayer(@"D:\music\ogpisound\kg\А.wav");
                Sound.PlaySync();
                if (int.Parse(numSound) <= 100)
                {
                    Sound.SoundLocation = @"D:\music\ogpisound\kg\" + numSound + ".wav";
                    Sound.PlaySync();
                }
                else if (int.Parse(numSound) > 100 && int.Parse(numSound) < 1000)
                {
                    char sto = numSound[0];
                    string stosh = sto + "00";
                    Sound.SoundLocation = @"D:\music\ogpisound\kg\" + stosh + ".wav";
                    Sound.PlaySync();

                    if (numSound[1] == '0')
                    {
                        Sound.SoundLocation = @"D:\music\ogpisound\kg\" + numSound[2] + ".wav";
                        Sound.PlaySync();
                    }
                    else
                    {
                        string numSoundSub = numSound.Substring(1);
                        Sound.SoundLocation = @"D:\music\ogpisound\kg\" + numSoundSub + ".wav";
                        Sound.PlaySync();
                    }
                }
                else if (int.Parse(numSound) >= 1000 && int.Parse(numSound) < 10000)
                {
                    if (numSound[1] == '0' && numSound[2] == '0' && numSound[3] == '0')
                    {
                        string w = numSound.Substring(1);
                        char tish = numSound[0];
                        string stosh = tish + "000";
                        Sound.SoundLocation = @"D:\music\ogpisound\kg\" + stosh + ".wav";
                        Sound.PlaySync();
                    }
                    else
                    {
                        string w = numSound.Substring(1);
                        char tish = numSound[0];
                        string stosh = tish + "000";
                        Sound.SoundLocation = @"D:\music\ogpisound\kg\" + stosh + ".wav";
                        Sound.PlaySync();


                        if (numSound[1] == '0' && numSound[2] == '0')
                        {
                            Sound.SoundLocation = @"D:\music\ogpisound\kg\" + numSound[3] + ".wav";
                            Sound.PlaySync();
                        }
                        else if (numSound[1] == '0' && numSound[2] != '0')
                        {
                            string stos = numSound.Substring(2);
                            Sound.SoundLocation = @"D:\music\ogpisound\kg\" + stos + ".wav";
                            Sound.PlaySync();
                        }
                        else
                        {
                            char sto = numSound[1];
                            string stoshi = sto + "00";
                            Sound.SoundLocation = @"D:\music\ogpisound\kg\" + stoshi + ".wav";
                            Sound.PlaySync();
                            if (numSound[2] == '0')
                            {
                                Sound.SoundLocation = @"D:\music\ogpisound\kg\" + numSound[3] + ".wav";
                                Sound.PlaySync();
                            }
                            else
                            {
                                string numSoundSub = numSound.Substring(2);
                                Sound.SoundLocation = @"D:\music\ogpisound\kg\" + numSoundSub + ".wav";
                                Sound.PlaySync();
                            }
                        }
                    }
                }
                Sound.SoundLocation = @"D:\music\ogpisound\kg\ЭКГ.wav";
                Sound.PlaySync();
                Sound.SoundLocation = @"D:\music\ogpisound\kg\" + operSound + ".wav";
                Sound.PlaySync();
                Sound.SoundLocation = @"D:\music\ogpisound\kg\РегистрРегистр.wav";
                Sound.PlaySync();
            }
            else if (Lang == "en")
            {
                SoundPlayer Sound = new SoundPlayer(@"D:\music\ogpisound\en\A.wav");
                Sound.PlaySync();
                if (int.Parse(numSound) <= 100)
                {
                    Sound.SoundLocation = @"D:\music\ogpisound\en\" + numSound + ".wav";
                    Sound.PlaySync();
                }
                else if (int.Parse(numSound) > 100 && int.Parse(numSound) < 1000)
                {
                    char sto = numSound[0];
                    string stosh = sto + "00";
                    Sound.SoundLocation = @"D:\music\ogpisound\en\" + stosh + ".wav";
                    Sound.PlaySync();

                    if (numSound[1] == '0')
                    {
                        Sound.SoundLocation = @"D:\music\ogpisound\en\" + numSound[2] + ".wav";
                        Sound.PlaySync();
                    }
                    else
                    {
                        string numSoundSub = numSound.Substring(1);
                        Sound.SoundLocation = @"D:\music\ogpisound\en\" + numSoundSub + ".wav";
                        Sound.PlaySync();
                    }
                }
                else if (int.Parse(numSound) >= 1000 && int.Parse(numSound) < 10000)
                {
                    if ( numSound[1] == '0' && numSound[2] == '0' && numSound[3] == '0')
                    {
                        string w = numSound.Substring(1);
                        char tish = numSound[0];
                        string stosh = tish + "000";
                        Sound.SoundLocation = @"D:\music\ogpisound\en\" + stosh + ".wav";
                        Sound.PlaySync();
                    }
                    else
                    {
                        string w = numSound.Substring(1);
                        char tish = numSound[0];
                        string stosh = tish + "000";
                        Sound.SoundLocation = @"D:\music\ogpisound\en\" + stosh + ".wav";
                        Sound.PlaySync();


                        if (numSound[1] == '0' && numSound[2] == '0')
                        {
                            Sound.SoundLocation = @"D:\music\ogpisound\en\" + numSound[3] + ".wav";
                            Sound.PlaySync();
                        }
                        else if (numSound[1] == '0' && numSound[2] != '0')
                        {
                            string stos = numSound.Substring(2);
                            Sound.SoundLocation = @"D:\music\ogpisound\en\" + stos + ".wav";
                            Sound.PlaySync();
                        }
                        else
                        {
                            char sto = numSound[1];
                            string stoshi = sto + "00";
                            Sound.SoundLocation = @"D:\music\ogpisound\en\" + stoshi + ".wav";
                            Sound.PlaySync();
                            if (numSound[2] == '0')
                            {
                                Sound.SoundLocation = @"D:\music\ogpisound\en\" + numSound[3] + ".wav";
                                Sound.PlaySync();
                            }
                            else
                            {
                                string numSoundSub = numSound.Substring(2);
                                Sound.SoundLocation = @"D:\music\ogpisound\en\" + numSoundSub + ".wav";
                                Sound.PlaySync();
                            }
                        }
                    }
                }
                Sound.SoundLocation = @"D:\music\ogpisound\en\Сиздин талон жараксыз.wav";
                Sound.PlaySync();
                Sound.SoundLocation = @"D:\music\ogpisound\en\" + operSound + ".wav";
                Sound.PlaySync();
            }
            else
            {
                SoundPlayer Sound = new SoundPlayer(@"D:\music\ogpisound\kg\А.wav");
                Sound.PlaySync();
            }
        }
    }
}
