using System.Media;

namespace Monitor.Models
{
    public static class Naudio
    {
        public static void MusicPlay(string numSound, string operSound, string Lang)
        {
            try
            {
                if (Lang == "RU")
                {
                    SoundPlayer Sound = new SoundPlayer(@"C:\rsk\sound\ru\word\номер.wav");
                    Sound.PlaySync();
                    char suff = numSound[0];
                    numSound = numSound.Substring(1);
                    Sound.SoundLocation = @"C:\rsk\sound\ru\latters\" + suff + ".wav";
                    Sound.PlaySync();
                    if (int.Parse(numSound) <= 100)
                    {
                        Sound.SoundLocation = @"C:\rsk\sound\ru\" + numSound + ".wav";
                        Sound.PlaySync();
                    }
                    else if (int.Parse(numSound) > 100 && int.Parse(numSound) < 1000)
                    {
                        char sto = numSound[0];
                        string stosh = sto + "00";
                        Sound.SoundLocation = @"C:\rsk\sound\ru\" + stosh + ".wav";
                        Sound.PlaySync();

                        if (numSound[1] == '0')
                        {
                            Sound.SoundLocation = @"C:\rsk\sound\ru\" + numSound[2] + ".wav";
                            Sound.PlaySync();
                        }
                        else
                        {
                            string numSoundSub = numSound.Substring(1);
                            Sound.SoundLocation = @"C:\rsk\sound\ru\" + numSoundSub + ".wav";
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
                            Sound.SoundLocation = @"C:\rsk\sound\ru\" + stosh + ".wav";
                            Sound.PlaySync();
                        }
                        else
                        {
                            string w = numSound.Substring(1);
                            char tish = numSound[0];
                            string stosh = tish + "000";
                            Sound.SoundLocation = @"C:\rsk\sound\ru\" + stosh + ".wav";
                            Sound.PlaySync();
                            if (numSound[1] == '0' && numSound[2] == '0')
                            {
                                Sound.SoundLocation = @"C:\rsk\sound\ru\" + numSound[3] + ".wav";
                                Sound.PlaySync();
                            }
                            else if (numSound[1] == '0' && numSound[2] != '0')
                            {
                                string stos = numSound.Substring(2);
                                Sound.SoundLocation = @"C:\rsk\sound\ru\" + stos + ".wav";
                                Sound.PlaySync();
                            }
                            else
                            {
                                char sto = numSound[1];
                                string stoshi = sto + "00";
                                Sound.SoundLocation = @"C:\rsk\sound\ru\" + stoshi + ".wav";
                                Sound.PlaySync();
                                if (numSound[2] == '0')
                                {
                                    Sound.SoundLocation = @"C:\rsk\sound\ru\" + numSound[3] + ".wav";
                                    Sound.PlaySync();
                                }
                                else
                                {
                                    string numSoundSub = numSound.Substring(2);
                                    Sound.SoundLocation = @"C:\rsk\sound\ru\" + numSoundSub + ".wav";
                                    Sound.PlaySync();
                                }
                            }
                        }
                    }
                    Sound.SoundLocation = @"C:\rsk\sound\ru\word\пройдите_к_окну.wav";
                    Sound.PlaySync();
                    Sound.SoundLocation = @"C:\rsk\sound\ru\" + operSound + ".wav";
                    Sound.PlaySync();
                }
                else if (Lang == "KG")
                {
                    SoundPlayer Sound = new SoundPlayer(@"C:\rsk\sound\kg\word\номер.wav");
                    Sound.PlaySync();
                    char suff = numSound[0];
                    numSound = numSound.Substring(1);
                    Sound.SoundLocation = @"C:\rsk\sound\ru\latters\" + suff + ".wav";
                    Sound.PlaySync();
                    if (int.Parse(numSound) <= 100)
                    {
                        Sound.SoundLocation = @"C:\rsk\sound\kg\" + numSound + ".wav";
                        Sound.PlaySync();
                    }
                    else if (int.Parse(numSound) > 100 && int.Parse(numSound) < 1000)
                    {
                        char sto = numSound[0];
                        string stosh = sto + "00";
                        Sound.SoundLocation = @"C:\rsk\sound\kg\" + stosh + ".wav";
                        Sound.PlaySync();

                        if (numSound[1] == '0')
                        {
                            Sound.SoundLocation = @"C:\rsk\sound\kg\" + numSound[2] + ".wav";
                            Sound.PlaySync();
                        }
                        else
                        {
                            string numSoundSub = numSound.Substring(1);
                            Sound.SoundLocation = @"C:\rsk\sound\kg\" + numSoundSub + ".wav";
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
                            Sound.SoundLocation = @"C:\rsk\sound\kg\" + stosh + ".wav";
                            Sound.PlaySync();
                        }
                        else
                        {
                            string w = numSound.Substring(1);
                            char tish = numSound[0];
                            string stosh = tish + "000";
                            Sound.SoundLocation = @"C:\rsk\sound\kg\" + stosh + ".wav";
                            Sound.PlaySync();


                            if (numSound[1] == '0' && numSound[2] == '0')
                            {
                                Sound.SoundLocation = @"C:\rsk\sound\kg\" + numSound[3] + ".wav";
                                Sound.PlaySync();
                            }
                            else if (numSound[1] == '0' && numSound[2] != '0')
                            {
                                string stos = numSound.Substring(2);
                                Sound.SoundLocation = @"C:\rsk\sound\kg\" + stos + ".wav";
                                Sound.PlaySync();
                            }
                            else
                            {
                                char sto = numSound[1];
                                string stoshi = sto + "00";
                                Sound.SoundLocation = @"C:\rsk\sound\kg\" + stoshi + ".wav";
                                Sound.PlaySync();
                                if (numSound[2] == '0')
                                {
                                    Sound.SoundLocation = @"C:\rsk\sound\kg\" + numSound[3] + ".wav";
                                    Sound.PlaySync();
                                }
                                else
                                {
                                    string numSoundSub = numSound.Substring(2);
                                    Sound.SoundLocation = @"C:\rsk\sound\kg\" + numSoundSub + ".wav";
                                    Sound.PlaySync();
                                }
                            }
                        }
                    }
                    Sound.SoundLocation = @"C:\rsk\sound\kg\window\" + operSound + "-.wav";
                    Sound.PlaySync();
                    Sound.SoundLocation = @"C:\rsk\sound\kg\word\терезеге_келиниз.wav";
                    Sound.PlaySync();
                }

                else if (Lang == "EN")
                {
                    SoundPlayer Sound = new SoundPlayer(@"C:\rsk\sound\en\ЭКГ.wav");
                    Sound.PlaySync();
                    char suff = numSound[0];
                    numSound = numSound.Substring(1);
                    Sound.SoundLocation = @"C:\rsk\sound\en\" + suff + ".wav";
                    Sound.PlaySync();
                    if (int.Parse(numSound) <= 100)
                    {
                        Sound.SoundLocation = @"C:\rsk\sound\en\" + numSound + ".wav";
                        Sound.PlaySync();
                    }
                    else if (int.Parse(numSound) > 100 && int.Parse(numSound) < 1000)
                    {
                        char sto = numSound[0];
                        string stosh = sto + "00";
                        Sound.SoundLocation = @"C:\rsk\sound\en\" + stosh + ".wav";
                        Sound.PlaySync();

                        if (numSound[1] == '0')
                        {
                            Sound.SoundLocation = @"C:\rsk\sound\en\" + numSound[2] + ".wav";
                            Sound.PlaySync();
                        }
                        else
                        {
                            string numSoundSub = numSound.Substring(1);
                            Sound.SoundLocation = @"C:\rsk\sound\en\" + numSoundSub + ".wav";
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
                            Sound.SoundLocation = @"C:\rsk\sound\en\" + stosh + ".wav";
                            Sound.PlaySync();
                        }
                        else
                        {
                            string w = numSound.Substring(1);
                            char tish = numSound[0];
                            string stosh = tish + "000";
                            Sound.SoundLocation = @"C:\rsk\sound\en\" + stosh + ".wav";
                            Sound.PlaySync();


                            if (numSound[1] == '0' && numSound[2] == '0')
                            {
                                Sound.SoundLocation = @"C:\rsk\sound\en\" + numSound[3] + ".wav";
                                Sound.PlaySync();
                            }
                            else if (numSound[1] == '0' && numSound[2] != '0')
                            {
                                string stos = numSound.Substring(2);
                                Sound.SoundLocation = @"C:\rsk\sound\en\" + stos + ".wav";
                                Sound.PlaySync();
                            }
                            else
                            {
                                char sto = numSound[1];
                                string stoshi = sto + "00";
                                Sound.SoundLocation = @"C:\rsk\sound\en\" + stoshi + ".wav";
                                Sound.PlaySync();
                                if (numSound[2] == '0')
                                {
                                    Sound.SoundLocation = @"C:\rsk\sound\en\" + numSound[3] + ".wav";
                                    Sound.PlaySync();
                                }
                                else
                                {
                                    string numSoundSub = numSound.Substring(2);
                                    Sound.SoundLocation = @"C:\rsk\sound\en\" + numSoundSub + ".wav";
                                    Sound.PlaySync();
                                }
                            }
                        }
                    }
                    Sound.SoundLocation = @"C:\rsk\sound\en\пройдите_в_отдел.wav";
                    Sound.PlaySync();
                    Sound.SoundLocation = @"C:\rsk\sound\en\" + operSound + ".wav";
                    Sound.PlaySync();
                }
                else
                {
                    SoundPlayer Sound = new SoundPlayer(@"C:\rsk\sound\muz\ding.wav");
                    Sound.PlaySync();
                }
            }
            catch
            {
            }
        }
    }
}
