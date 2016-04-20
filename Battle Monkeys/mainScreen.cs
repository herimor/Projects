using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace Battle_Monkeys
{
    public partial class mainScreen : Form
    {
        public mainScreen()
        {
            InitializeComponent();
        }
        public struct Player
        {
            public int health, indikator, shield, berserk;
            public double bonus_bers;
            public PictureBox position;
            public string name;
            public Image icon;
            public bool gun, lava, meteor, shockwave, storm, heal, shd;
            public ProgressBar pBar;
            public Label labe;
        }
        public struct Gorilla
        {
            public int health, indikator, shield, berserk;
            public double bonus_bers;
            public PictureBox position;
            public string name;
            public Image icon;
            public bool gun, lava, meteor, shockwave, storm, heal, shd;
            public ProgressBar pBar;
            public Label labe;
        }
        public struct Shimp
        {
            public int health, indikator, shield, berserk;
            public double bonus_bers;
            public PictureBox position;
            public string name;
            public Image icon;
            public bool gun, lava, meteor, shockwave, storm, heal, shd;
            public ProgressBar pBar;
            public Label labe;
        }
        public struct Baboon
        {
            public int health, indikator, shield, berserk;
            public double bonus_bers;
            public PictureBox position;
            public string name;
            public Image icon;
            public bool gun, lava, meteor, shockwave, storm, heal, shd;
            public ProgressBar pBar;
            public Label labe;
        }

        Random rnd = new Random();
        PictureBox[] pb_mass;
        List<string> skills = new List<string> { "lava.jpg", "lava.jpg", "health.jpg", "plitka.jpg", "storm.jpg", "storm.jpg", "plitka.jpg", "plitka.jpg", "meteorite.jpg", "meteorite.jpg","shockwave.jpg",
        "shockwave.jpg", "plitka.jpg", "shield.jpg", "gun.jpg", "gun.jpg", "berserk.jpg", "berserk.jpg"};
        string[] skills1 = new string[] { "lava.jpg", "lava.jpg", "health.jpg", "plitka.jpg", "storm.jpg", "storm.jpg", "plitka.jpg", "plitka.jpg", "meteorite.jpg", "meteorite.jpg","shockwave.jpg",
        "shockwave.jpg", "plitka.jpg", "shield.jpg", "gun.jpg", "gun.jpg", "berserk.jpg", "berserk.jpg"};
        List<Color> colors = new List<Color> { Color.Aqua, Color.Aqua,Color.Green,Color.Coral, Color.Blue,Color.Blue,Color.Coral,Color.Coral,Color.Orange,Color.Orange,
        Color.WhiteSmoke,Color.WhiteSmoke,Color.Coral,Color.Red,Color.Brown,Color.Brown,Color.Tomato,Color.Tomato};
        Color[] colors1 = new Color[] {Color.Aqua, Color.Aqua,Color.Green,Color.Coral, Color.Blue,Color.Blue,Color.Coral,Color.Coral,Color.Orange,Color.Orange,
        Color.WhiteSmoke,Color.WhiteSmoke,Color.Coral,Color.Red,Color.Brown,Color.Brown,Color.Tomato,Color.Tomato};
        int top_random, time = 1, schet = 1, rnd_number = 18, prokr_strk = 76, minus = 10, minus1 = 0, polozh, spor_rezult, indikator, spor1, spor2, spor3, spor4, indikat, health_ind, shield_ind, storm_ind, meteorite_ind,
            shockwave_ind, gun_ind, bersek_ind, nomers, timer_9scht, spor_index, spor_index1, win, dmg = 30;
        PictureBox player, player_up, health_pb, shield_pb, storm_pb, meteorite_pb, shockwave_pb, gun_pb, bersek_pb;
        bool scd_run, indexator, propusk, propusk1, propusk2, krutka, sterka;
        string name1, name2, name3, name4, nam1, nam2;
        Image plittkka = Image.FromFile("plitka.jpg");
        string nameSum_block = "", nameSum_damage = "";

        private void close(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        Player pl = new Player();
        Gorilla gr = new Gorilla();
        Shimp smp = new Shimp();
        Baboon bb = new Baboon();
        SoundPlayer stormm, lavva, metteorr, heell1, gunn;

        private void Stopper() 
        {
            if(stormm !=null)
                stormm.Stop();
            if (lavva != null)
                lavva.Stop();
            if (metteorr != null)
                metteorr.Stop();
            if (heell1 != null)
                heell1.Stop();
            if (gunn != null)
                gunn.Stop();
        }

        private void Slezhka(ref ProgressBar pBar, ref int health, ref int indikator, ref int shield, ref int berserk, ref PictureBox position, ref string name, ref Image icon, ref bool gun,
            ref bool lava, ref bool meteor, ref bool shockwave, ref bool storm, ref bool heal, ref Label labe)
        {
            if (name == "Игрок" && health <= 0)
            {
                timer9.Stop();
                MessageBox.Show("Игра закончена");
                Application.Exit();
            }
            else if (health <= 0 && position != null)
            {
                position.Image = plittkka;
                pBar.Visible = false;
                labe.Text = name + " выбит";
                indikator = -100;
                shield = berserk = 0;
                position = null;
                name = null;
                icon = null;
                gun = lava = meteor = shockwave = storm = heal = false;
                win++;
                if (win == 3)
                {
                    MessageBox.Show("Вы выиграли !");
                    Application.Exit();
                }
            }
            else
                pBar.Value = health;
        }

        private void storm_Beat(ref int first_hp, ref int second_hp, ref int third_hp, string name_1, string name_2, string name_3, ref int shield_1, ref int shield_2, ref int shield_3, double bonus_bers, ref Label label,
            string name, ref int bers1, ref int bers2, ref int bers3, ref bool gun1, ref bool gun2, ref bool gun3, ref bool meteor1, ref bool meteor2, ref bool meteor3, ref bool shock1, ref bool shock2, ref bool shock3,
            ref bool storm1, ref bool storm2, ref bool storm3, ref bool heal1, ref bool heal2, ref bool heal3, ref bool lava1, ref bool lava2, ref bool lava3, ref int indikat1, ref int indikat2, ref int indikat3,
            ref ProgressBar pbar, ref ProgressBar pbar1, ref ProgressBar pbar2, ref ProgressBar pbar3, ref PictureBox position1, ref PictureBox position2, ref PictureBox position3, ref Image image1, ref Image image2,
            ref Image image3, ref Label labe1, ref Label labe2, ref Label labe3)
        {
            if (shield_1 > 0)
            {
                nameSum_block += "||" + name_1 + "||";
                shield_1 -= Convert.ToInt32(dmg * bonus_bers);
            }
            else if(first_hp > 0)
            {
                first_hp -= Convert.ToInt32(dmg * bonus_bers);
                nameSum_damage += "||" + name_1 + "||";
                Slezhka(ref pbar1, ref first_hp, ref indikat1, ref shield_1, ref bers1, ref position1, ref name_1, ref image1, ref gun1, ref lava1, ref meteor1, ref shock1, ref storm1, ref heal1,ref labe1);
            }
            if (shield_2 > 0)
            {
                nameSum_block += "||" + name_2 + "||";
                shield_2 -= Convert.ToInt32(dmg * bonus_bers);
            }
            else if(second_hp>0)
            {
                second_hp -= Convert.ToInt32(dmg * bonus_bers);
                nameSum_damage += "||" + name_2 + "||";
                Slezhka(ref pbar2, ref second_hp, ref indikat2, ref shield_2, ref bers2, ref position2, ref name_2, ref image2, ref gun2, ref lava2, ref meteor2, ref shock2, ref storm2, ref heal2, ref labe2);
            }
            if (shield_3 > 0)
            {
                nameSum_block += "||" + name_3 + "||";
                shield_3 -= Convert.ToInt32(dmg * bonus_bers);
            }
            else if(third_hp>0)
            {
                third_hp -= Convert.ToInt32(dmg * bonus_bers);
                nameSum_damage += "||" + name_3 + "||";
                Slezhka(ref pbar3, ref third_hp, ref indikat3, ref shield_3, ref bers3, ref position3, ref name_3, ref image3, ref gun3, ref lava3, ref meteor3, ref shock3, ref storm3, ref heal3, ref labe3);
            }
            label.ForeColor = Color.Black;
            if (nameSum_block == "")
                nameSum_block = "Никто не";
            if (nameSum_damage == "")
                nameSum_damage = "Никто не";
            label.Text = name + " вызывает грозу| " + nameSum_block + " заблокировал(и) урон, а " + nameSum_damage + " получил(и) " + dmg * bonus_bers + "урона";
            nameSum_damage = nameSum_block = "";
        }

        private void shock_Beat(int indikator, string name, Label label, double bonus_bers)
        {
            int vnutr_ind = (indikator / 5) * 5, minus = 0, minus1 = 0;
            switch (vnutr_ind)
            {
                case 0:
                    minus = 5;
                    break;
                case 60:
                    minus1 = 5;
                    break;
            }
            for (int i = vnutr_ind - 5 + minus; i < (vnutr_ind + 10) - minus1; i++)
            {
                if (pb_mass[i].Image.Height == 50)
                {
                    if (i == pl.indikator && i != indikator)
                    {
                        if (pl.shield > 0)
                        {
                            pl.shield -= Convert.ToInt32(dmg * bonus_bers);
                            nameSum_block += "||Игрок||";
                        }
                        else
                        {
                            pl.health -= Convert.ToInt32(dmg * bonus_bers);
                            nameSum_damage += "||Игрок||";
                            Slezhka(ref pl.pBar, ref pl.health, ref pl.indikator, ref pl.shield, ref pl.berserk, ref pl.position, ref pl.name, ref pl.icon, ref pl.gun, ref pl.lava, ref pl.meteor, ref pl.shockwave,
                                    ref pl.storm, ref pl.heal, ref pl.labe);
                        }
                    }
                    else if (i == gr.indikator && i != indikator)
                    {
                        if (gr.shield > 0)
                        {
                            gr.shield -= Convert.ToInt32(dmg * bonus_bers);
                            nameSum_block += "||Горилла||";
                        }
                        else if(gr.health > 0)
                        {
                            gr.health -= Convert.ToInt32(dmg * bonus_bers);
                            nameSum_damage += "||Горилла||";
                            Slezhka(ref gr.pBar, ref gr.health, ref gr.indikator, ref gr.shield, ref gr.berserk, ref gr.position, ref gr.name, ref gr.icon, ref gr.gun, ref gr.lava, ref gr.meteor, ref gr.shockwave,
                                    ref gr.storm, ref gr.heal, ref gr.labe);
                        }
                    }
                    else if (i == smp.indikator && i != indikator)
                    {
                        if (smp.shield > 0)
                        {
                            smp.shield -= Convert.ToInt32(dmg * bonus_bers);
                            nameSum_block += "||Шимп||";
                        }
                        else if(smp.health > 0)
                        {
                            smp.health -= Convert.ToInt32(dmg * bonus_bers);
                            nameSum_damage += "||Шимп||";
                            Slezhka(ref smp.pBar, ref smp.health, ref smp.indikator, ref smp.shield, ref smp.berserk, ref smp.position, ref smp.name, ref smp.icon, ref smp.gun, ref smp.lava, ref smp.meteor,
                                    ref smp.shockwave, ref smp.storm, ref smp.heal, ref smp.labe);
                        }
                    }
                    else if (i == bb.indikator && i != indikator)
                    {
                        if (bb.shield > 0)
                        {
                            bb.shield -= Convert.ToInt32(dmg * bonus_bers);
                            nameSum_block += "||Бабуин||";
                        }
                        else if(bb.health > 0)
                        {
                            bb.health -= Convert.ToInt32(dmg * bonus_bers);
                            nameSum_damage += "||Бабуин||";
                            Slezhka(ref bb.pBar, ref bb.health, ref bb.indikator, ref bb.shield, ref bb.berserk, ref bb.position, ref bb.name, ref bb.icon, ref bb.gun, ref bb.lava, ref bb.meteor, ref bb.shockwave,
                                    ref bb.storm, ref bb.heal,ref bb.labe);
                        }
                    }
                }
            }
            label.ForeColor = Color.Black;
            minus = minus1 = 0;
            if (nameSum_block == "")
                nameSum_block = "Никто не";
            if (nameSum_damage == "")
                nameSum_damage = "Никто не";
            label.Text = name + " вызывает землетрясение| " + nameSum_block + " заблокировал(и) урон, а " + nameSum_damage + " получил(и) " + dmg * bonus_bers + "урона";
            nameSum_damage = nameSum_block = "";
        }

        private void meteor_Beat(ref int first_hp, ref int second_hp, ref int third_hp, string name_1, string name_2, string name_3, ref int shield_1, ref int shield_2, ref int shield_3, double bonus_bers, ref Label label,
            string name, ref int bers1, ref int bers2, ref int bers3, ref bool gun1, ref bool gun2, ref bool gun3, ref bool meteor1, ref bool meteor2, ref bool meteor3, ref bool shock1, ref bool shock2, ref bool shock3,
            ref bool storm1, ref bool storm2, ref bool storm3, ref bool heal1, ref bool heal2, ref bool heal3, ref bool lava1, ref bool lava2, ref bool lava3, ref int indikat1, ref int indikat2, ref int indikat3,
            ref ProgressBar pbar, ref ProgressBar pbar1, ref ProgressBar pbar2, ref ProgressBar pbar3, ref PictureBox position1, ref PictureBox position2, ref PictureBox position3, ref Image image1, ref Image image2,
            ref Image image3, ref Label labe1, ref Label labe2, ref Label labe3, ref int indikator)
        {
            int maksimum = Math.Abs(indikator - indikat1);
            int rrandd = 0;
            if (Math.Abs(indikator - indikat2) < maksimum)
            {
                maksimum = Math.Abs(indikator - indikat2);
                rrandd = 1;
            }
            if (Math.Abs(indikator - indikat3) < maksimum)
            {
                maksimum = Math.Abs(indikator - indikat3);
                rrandd = 2;
            }
            switch (rrandd)
            {
                case 0:
                    if (shield_1 > 0)
                    {
                        label.ForeColor = Color.Black;
                        label.Text = name + " кастует метеорит; " + name_1 + " заблокировал урон от метеорита";
                        shield_1 -= Convert.ToInt32(dmg * bonus_bers);
                    }
                    else if(first_hp > 0)
                    {
                        label.ForeColor = Color.Black;
                        first_hp -= Convert.ToInt32(dmg * bonus_bers);
                        label.Text = name + " кастует метеорит; " + name_1 + " получает " + dmg * bonus_bers + " урона от метеорита";
                        Slezhka(ref pbar1, ref first_hp, ref indikat1, ref shield_1, ref bers1, ref position1, ref name_1, ref image1, ref gun1, ref lava1, ref meteor1, ref shock1, ref storm1, ref heal1,ref labe1);
                    }
                    break;
                case 1:
                    if (shield_2 > 0)
                    {
                        label.ForeColor = Color.Black;
                        label.Text = name + " кастует метеорит; " + name_2 + " заблокировал урон от метеорита";
                        shield_2 -= Convert.ToInt32(dmg * bonus_bers);
                    }
                    else if(second_hp > 0)
                    {
                        label.ForeColor = Color.Black;
                        second_hp -= Convert.ToInt32(dmg * bonus_bers);
                        label.Text = name + " кастует метеорит; " + name_2 + " получает " + dmg * bonus_bers + " урона от метеорита";
                        Slezhka(ref pbar2, ref second_hp, ref indikat2, ref shield_2, ref bers2, ref position2, ref name_2, ref image2, ref gun2, ref lava2, ref meteor2, ref shock2, ref storm2, ref heal2, ref labe2);
                    }
                    break;
                case 2:
                    if (shield_3 > 0)
                    {
                        label.ForeColor = Color.Black;
                        label.Text = name + " кастует метеорит; " + name_3 + " заблокировал урон от метеорита";
                        shield_3 -= Convert.ToInt32(dmg * bonus_bers);
                    }
                    else if(third_hp > 0)
                    {
                        label.ForeColor = Color.Black;
                        third_hp -= Convert.ToInt32(dmg * bonus_bers);
                        label.Text = name + " кастует метеорит; " + name_3 + " получает " + dmg * bonus_bers + " урона от метеорита";
                        Slezhka(ref pbar3, ref third_hp, ref indikat3, ref shield_3, ref bers3, ref position3, ref name_3, ref image3, ref gun3, ref lava3, ref meteor3, ref shock3, ref storm3, ref heal3,ref labe3);
                    }
                    break;
            }
        }

        private void gun_beat(int ind, Label label, string name, double bonus_bers)
        {
            int change_ind = ind + 5, jj = 5, maks = 65;
            for (int i = 0; i < 2; i++)
            {
                for (int j = change_ind; j < maks; j += jj)
                {
                    if (pb_mass[j].Image.Height == 50)
                    {
                        if (j == pl.indikator)
                        {
                            if (pl.shield > 0)
                            {
                                pl.shield -= Convert.ToInt32(dmg * bonus_bers);
                                nameSum_block += "||Игрок||";
                            }
                            else
                            {
                                pl.health -= Convert.ToInt32(dmg * bonus_bers);
                                nameSum_damage += "||Игрок||";
                                Slezhka(ref pl.pBar, ref pl.health, ref pl.indikator, ref pl.shield, ref pl.berserk, ref pl.position, ref pl.name, ref pl.icon, ref pl.gun, ref pl.lava, ref pl.meteor, ref pl.shockwave,
                                    ref pl.storm, ref pl.heal,ref pl.labe);
                            }
                        }
                        else if (j == gr.indikator)
                        {
                            if (gr.shield > 0)
                            {
                                gr.shield -= Convert.ToInt32(dmg * bonus_bers);
                                nameSum_block += "||Горилла||";
                            }
                            else if (gr.health > 0)
                            {
                                gr.health -= Convert.ToInt32(dmg * bonus_bers);
                                nameSum_damage += "||Горилла||";
                                Slezhka(ref gr.pBar, ref gr.health, ref gr.indikator, ref gr.shield, ref gr.berserk, ref gr.position, ref gr.name, ref gr.icon, ref gr.gun, ref gr.lava, ref gr.meteor, ref gr.shockwave,
                                    ref gr.storm, ref gr.heal, ref gr.labe);
                            }
                        }
                        else if (j == smp.indikator)
                        {
                            if (smp.shield > 0)
                            {
                                smp.shield -= Convert.ToInt32(dmg * bonus_bers);
                                nameSum_block += "||Шимп||";
                            }
                            else if(smp.health > 0)
                            {
                                smp.health -= Convert.ToInt32(dmg * bonus_bers);
                                nameSum_damage += "||Шимп||";
                                Slezhka(ref smp.pBar, ref smp.health, ref smp.indikator, ref smp.shield, ref smp.berserk, ref smp.position, ref smp.name, ref smp.icon, ref smp.gun, ref smp.lava, ref smp.meteor,
                                    ref smp.shockwave, ref smp.storm, ref smp.heal, ref smp.labe);
                            }
                        }
                        else if (j == bb.indikator)
                        {
                            if (bb.shield > 0)
                            {
                                bb.shield -= Convert.ToInt32(dmg * bonus_bers);
                                nameSum_block += "||Бабуин||";
                            }
                            else if(bb.health > 0)
                            {
                                bb.health -= Convert.ToInt32(dmg * bonus_bers);
                                nameSum_damage += "||Бабуин||";
                                Slezhka(ref bb.pBar, ref bb.health, ref bb.indikator, ref bb.shield, ref bb.berserk, ref bb.position, ref bb.name, ref bb.icon, ref bb.gun, ref bb.lava, ref bb.meteor, ref bb.shockwave,
                                    ref bb.storm, ref bb.heal, ref bb.labe);
                            }
                        }
                    }
                }
                change_ind = ind + 1;
                jj = 1;
                maks = ((ind / 5) + 1) * 5;
            }
            //
            change_ind = ind - 5; jj = 5; maks = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = change_ind; j > maks; j -= jj)
                {
                    if (pb_mass[j].Image.Height == 50)
                    {
                        if (j == pl.indikator)
                        {
                            if (pl.shield > 0)
                            {
                                pl.shield -= Convert.ToInt32(dmg * bonus_bers);
                                nameSum_block += "||Игрок||";
                            }
                            else
                            {
                                pl.health -= Convert.ToInt32(dmg * bonus_bers);
                                nameSum_damage += "||Игрок||";
                                Slezhka(ref pl.pBar, ref pl.health, ref pl.indikator, ref pl.shield, ref pl.berserk, ref pl.position, ref pl.name, ref pl.icon, ref pl.gun, ref pl.lava, ref pl.meteor, ref pl.shockwave,
                                    ref pl.storm, ref pl.heal, ref pl.labe);
                            }
                        }
                        else if (j == gr.indikator)
                        {
                            if (gr.shield > 0)
                            {
                                gr.shield -= Convert.ToInt32(dmg * bonus_bers);
                                nameSum_block += "||Горилла||";
                            }
                            else if(gr.health > 0)
                            {
                                gr.health -= Convert.ToInt32(dmg * bonus_bers);
                                nameSum_damage += "||Горилла||";
                                Slezhka(ref gr.pBar, ref gr.health, ref gr.indikator, ref gr.shield, ref gr.berserk, ref gr.position, ref gr.name, ref gr.icon, ref gr.gun, ref gr.lava, ref gr.meteor, ref gr.shockwave,
                                    ref gr.storm, ref gr.heal, ref gr.labe);
                            }
                        }
                        else if (j == smp.indikator)
                        {
                            if (smp.shield > 0)
                            {
                                smp.shield -= Convert.ToInt32(dmg * bonus_bers);
                                nameSum_block += "||Шимп||";
                            }
                            else if(smp.health > 0)
                            {
                                smp.health -= Convert.ToInt32(dmg * bonus_bers);
                                nameSum_damage += "||Шимп||";
                                Slezhka(ref smp.pBar, ref smp.health, ref smp.indikator, ref smp.shield, ref smp.berserk, ref smp.position, ref smp.name, ref smp.icon, ref smp.gun, ref smp.lava, ref smp.meteor,
                                    ref smp.shockwave, ref smp.storm, ref smp.heal, ref smp.labe);
                            }
                        }
                        else if (j == bb.indikator)
                        {
                            if (bb.shield > 0)
                            {
                                bb.shield -= Convert.ToInt32(dmg * bonus_bers);
                                nameSum_block += "||Бабуин||";
                            }
                            else if(bb.health > 0)
                            {
                                bb.health -= Convert.ToInt32(dmg * bonus_bers);
                                nameSum_damage += "||Бабуин||";
                                Slezhka(ref bb.pBar, ref bb.health, ref bb.indikator, ref bb.shield, ref bb.berserk, ref bb.position, ref bb.name, ref bb.icon, ref bb.gun, ref bb.lava, ref bb.meteor, ref bb.shockwave,
                                    ref bb.storm, ref bb.heal, ref bb.labe);
                            }
                        }
                    }
                }
                change_ind = ind - 1;
                jj = 1;
                maks = ((ind / 5) * 5) - 1;
            }
            label.ForeColor = Color.Black;
            if (nameSum_block == "")
                nameSum_block = "Никто не";
            if (nameSum_damage == "")
                nameSum_damage = "Никто не";
            label.Text = name + " стреляет из ружья| " + nameSum_block + " заблокировал(и) урон, а " + nameSum_damage + " получил(и) " + dmg * bonus_bers + "урона";
            nameSum_damage = nameSum_block = "";
        }

        private void battle(ref int health, ref int shield, ref int bersek, ref bool gun, ref bool meteor, ref bool shockwave, ref bool storm, ref bool heal, ref bool lava, ref string name, ref Label label,
            ref double bonus_bers, ref int indikator, ref int first_hp, ref int second_hp, ref int third_hp, ref string name_1, ref string name_2, ref string name_3, ref int shield_1, ref int shield_2, ref int shield_3,
            ref int bers2, ref int bers3, ref int bers4, ref bool gun2, ref bool gun3, ref bool gun4, ref bool meteor2, ref bool meteor3, ref bool meteor4, ref bool shock2, ref bool shock3, ref bool shock4, ref bool storm2,
            ref bool storm3, ref bool storm4, ref bool heal2, ref bool heal3, ref bool heal4, ref bool lava2, ref bool lava3, ref bool lava4, ref int indikat2, ref int indikat3, ref int indikat4, ref ProgressBar pbar,
            ref ProgressBar pbar2, ref ProgressBar pbar3, ref ProgressBar pbar4, ref PictureBox position1, ref PictureBox position2, ref PictureBox position3, ref Image image1, ref Image image2, ref Image image3,
            ref bool shd, ref Label labe1, ref Label labe2, ref Label labe3, ref PictureBox position, ref Image image)
        {
            if (heal)
            {
                heell1 = new SoundPlayer("heell1.wav");
                heell1.Play();
                if (health > 60)
                    health = 100;
                else
                    health += 40;
                label.ForeColor = Color.Green;
                label.Text = name + " восстанавливает 40 здоровья";
                pbar.Value = health;
                heal = false;
            }
            if (shd)
            {
                label.ForeColor = Color.Black;
                label.Text = name + " подобрал щит";
                shield = 100;
                shd = false;
            }
            if (gun)
            {
                gunn = new SoundPlayer("gun.wav");
                gunn.Play();
                gun = false;
                gun_beat(indikator, label, name, bonus_bers);
            }
            if (meteor)
            {
                metteorr = new SoundPlayer("meteor.wav");
                metteorr.Play();
                meteor_Beat(ref first_hp, ref second_hp, ref third_hp, name_1, name_2, name_3, ref shield_1, ref shield_2, ref shield_3, bonus_bers, ref label, name, ref bers2, ref bers3, ref bers4, ref gun2, ref gun3,
                    ref gun4, ref meteor2, ref meteor3, ref meteor4, ref shock2, ref shock3, ref shock4, ref storm2, ref storm3, ref storm4, ref heal2, ref heal3, ref heal4, ref lava2, ref lava3, ref lava4, ref indikat2,
                    ref indikat3, ref indikat4, ref pbar, ref pbar2, ref pbar3, ref pbar4, ref position1, ref position2, ref position3, ref image1, ref image2, ref image3, ref labe1, ref labe2, ref labe3, ref indikator);
                meteor = false;
            }
            if (shockwave)
            {
                shock_Beat(indikator, name, label, bonus_bers);
                shockwave = false;
            }
            if (storm)
            {
                stormm = new SoundPlayer("storm.wav");
                stormm.Play();
                storm_Beat(ref first_hp, ref second_hp, ref third_hp, name_1, name_2, name_3, ref shield_1, ref shield_2, ref shield_3, bonus_bers, ref label, name, ref bers2, ref bers3, ref bers4, ref gun2, ref gun3,
                    ref gun4, ref meteor2, ref meteor3, ref meteor4, ref shock2, ref shock3, ref shock4, ref storm2, ref storm3, ref storm4, ref heal2, ref heal3, ref heal4, ref lava2, ref lava3, ref lava4, ref indikat2,
                    ref indikat3, ref indikat4, ref pbar, ref pbar2, ref pbar3, ref pbar4, ref position1, ref position2, ref position3, ref image1, ref image2, ref image3, ref labe1, ref labe2, ref labe3);
                storm = false;
            }
            if (lava)
            {
                lavva = new SoundPlayer("lava.wav");
                lavva.Play();
                label.ForeColor = Color.Red;
                label.Text = name + " попал в лаву и получает 20 урона";
                health -= 20;
                Slezhka(ref pbar, ref health, ref indikator, ref shield, ref bersek, ref position, ref name, ref image, ref gun, ref lava, ref meteor, ref shockwave, ref storm, ref heal, ref label);
                lava = false;
            }
            if (bersek == 3)
            {
                label.ForeColor = Color.Red;
                label.Text = name + " в ярости, урон увеличен на 30 %";
                bonus_bers = 1.3;
                bersek--;
            }
            else if (bersek == 2)
            {
                bersek--;
            }
            else if (bersek == 1)
            {
                bersek--;
                bonus_bers = 1;
            }
        }

        private void smechenie_nazad(PictureBox pBox, ref bool heal, ref int shield, ref int bersek, ref bool gun, ref bool meteor, ref bool shockwave, ref bool storm, ref bool lava, ref bool shd)
        {
            if (pBox.BackColor == Color.Green)
            {
                heal = false;
            }
            if (pBox.BackColor == Color.Red)
            {
                shield = 0;
                shd = false;
            }
            if (pBox.BackColor == Color.Blue)
            {
                storm = false;
            }
            if (pBox.BackColor == Color.Orange)
            {
                meteor = false;
            }
            if (pBox.BackColor == Color.WhiteSmoke)
            {
                shockwave = false;
            }
            if (pBox.BackColor == Color.Brown)
            {
                gun = false;
            }
            if (pBox.BackColor == Color.Tomato)
            {
                bersek = 0;
            }
            if (pBox.BackColor == Color.Aqua)
            {
                lava = false;
            }
        }

        private void smechenie(PictureBox pBox, ref bool heal, ref int shield, ref int bersek, ref bool gun, ref bool meteor, ref bool shockwave, ref bool storm, ref bool lava, ref bool shd)
        {
            if (pBox.BackColor == Color.Green)
            {
                heal = true;
            }
            if (pBox.BackColor == Color.Red)
            {
                shd = true;
            }
            if (pBox.BackColor == Color.Blue)
            {
                storm = true;
            }
            if (pBox.BackColor == Color.Orange)
            {
                meteor = true;
            }
            if (pBox.BackColor == Color.WhiteSmoke)
            {
                shockwave = true;
            }
            if (pBox.BackColor == Color.Brown)
            {
                gun = true;
            }
            if (pBox.BackColor == Color.Tomato)
            {
                bersek = 3;
            }
            if (pBox.BackColor == Color.Aqua)
            {
                lava = true;
            }
        }

        private void intro_spoR_4()
        {
            label1.ForeColor = Color.Black;
            switch (spor_rezult)
            {
                case 1:
                    label1.Text = pl.name + " отстоял поле " + indikat;
                    pb_mass[indikat].Image = pl.icon;
                    pl.position = pb_mass[indikat];
                    try
                    {
                        smechenie_nazad(pb_mass[indikat], ref gr.heal, ref gr.shield, ref gr.berserk, ref gr.gun, ref gr.meteor, ref gr.shockwave, ref gr.storm, ref gr.lava, ref gr.shd);
                        pb_mass[indikat + 1].Image = gr.icon;
                        gr.position = pb_mass[indikat + 1];
                        smechenie(pb_mass[indikat + 1], ref gr.heal, ref gr.shield, ref gr.berserk, ref gr.gun, ref gr.meteor, ref gr.shockwave, ref gr.storm, ref gr.lava, ref gr.shd);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        label4.ForeColor = Color.Red;
                        gr.health -= 100;
                        Slezhka(ref gr.pBar, ref gr.health, ref gr.indikator, ref gr.shield, ref gr.berserk, ref gr.position, ref gr.name, ref gr.icon, ref gr.gun, ref gr.lava, ref gr.meteor, ref gr.shockwave, ref gr.storm,
                            ref gr.heal, ref gr.labe);
                    }
                    try
                    {
                        smechenie_nazad(pb_mass[indikat], ref smp.heal, ref smp.shield, ref smp.berserk, ref smp.gun, ref smp.meteor, ref smp.shockwave, ref smp.storm, ref smp.lava, ref smp.shd);
                        pb_mass[indikat - 1].Image = smp.icon;
                        smp.position = pb_mass[indikat - 1];
                        smechenie(pb_mass[indikat - 1], ref smp.heal, ref smp.shield, ref smp.berserk, ref smp.gun, ref smp.meteor, ref smp.shockwave, ref smp.storm, ref smp.lava, ref smp.shd);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        label4.ForeColor = Color.Red;
                        smp.health -= 100;
                        Slezhka(ref smp.pBar, ref smp.health, ref smp.indikator, ref smp.shield, ref smp.berserk, ref smp.position, ref smp.name, ref smp.icon, ref smp.gun, ref smp.lava, ref smp.meteor, ref smp.shockwave,
                            ref smp.storm, ref smp.heal, ref smp.labe);
                    }
                    try
                    {
                        smechenie_nazad(pb_mass[indikat], ref bb.heal, ref bb.shield, ref bb.berserk, ref bb.gun, ref bb.meteor, ref bb.shockwave, ref bb.storm, ref bb.lava, ref bb.shd);
                        pb_mass[indikat - 5].Image = bb.icon;
                        bb.position = pb_mass[indikat - 5];
                        smechenie(pb_mass[indikat - 5], ref bb.heal, ref bb.shield, ref bb.berserk, ref bb.gun, ref bb.meteor, ref bb.shockwave, ref bb.storm, ref bb.lava, ref bb.shd);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        label4.ForeColor = Color.Red;
                        bb.health -= 100;
                        Slezhka(ref bb.pBar, ref bb.health, ref bb.indikator, ref bb.shield, ref bb.berserk, ref bb.position, ref bb.name, ref bb.icon, ref bb.gun, ref bb.lava, ref bb.meteor, ref bb.shockwave,
                            ref bb.storm, ref bb.heal, ref bb.labe);
                    }
                    gr.health -= 20;
                    smp.health -= 20;
                    bb.health -= 20;
                    label2.ForeColor = label3.ForeColor = label4.ForeColor = Color.Red;
                    label2.Text = gr.name + " получил 20 урона от " + pl.name;
                    label3.Text = smp.name + " получил 20 урона от " + pl.name;
                    label4.Text = bb.name + " получил 20 урона от " + pl.name;
                    Slezhka(ref gr.pBar, ref gr.health, ref gr.indikator, ref gr.shield, ref gr.berserk, ref gr.position, ref gr.name, ref gr.icon, ref gr.gun, ref gr.lava, ref gr.meteor, ref gr.shockwave, ref gr.storm,
                            ref gr.heal, ref gr.labe);
                    Slezhka(ref smp.pBar, ref smp.health, ref smp.indikator, ref smp.shield, ref smp.berserk, ref smp.position, ref smp.name, ref smp.icon, ref smp.gun, ref smp.lava, ref smp.meteor, ref smp.shockwave,
                            ref smp.storm, ref smp.heal, ref smp.labe);
                    Slezhka(ref bb.pBar, ref bb.health, ref bb.indikator, ref bb.shield, ref bb.berserk, ref bb.position, ref bb.name, ref bb.icon, ref bb.gun, ref bb.lava, ref bb.meteor, ref bb.shockwave,
                            ref bb.storm, ref bb.heal, ref bb.labe);
                    break;
                case 2:
                    label1.Text = gr.name + " отстоял поле " + indikat;
                    pb_mass[indikat].Image = gr.icon;
                    gr.position = pb_mass[indikat];
                    try
                    {
                        smechenie_nazad(pb_mass[indikat], ref pl.heal, ref pl.shield, ref pl.berserk, ref pl.gun, ref pl.meteor, ref pl.shockwave, ref pl.storm, ref pl.lava, ref pl.shd);
                        pb_mass[indikat + 1].Image = pl.icon;
                        pl.position = pb_mass[indikat + 1];
                        smechenie(pb_mass[indikat + 1], ref pl.heal, ref pl.shield, ref pl.berserk, ref pl.gun, ref pl.meteor, ref pl.shockwave, ref pl.storm, ref pl.lava, ref pl.shd);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        label4.ForeColor = Color.Red;
                        pl.health -= 100;
                        Slezhka(ref pl.pBar, ref pl.health, ref pl.indikator, ref pl.shield, ref pl.berserk, ref pl.position, ref pl.name, ref pl.icon, ref pl.gun, ref pl.lava, ref pl.meteor, ref pl.shockwave,
                            ref pl.storm, ref pl.heal, ref pl.labe);
                    }
                    try
                    {
                        smechenie_nazad(pb_mass[indikat], ref smp.heal, ref smp.shield, ref smp.berserk, ref smp.gun, ref smp.meteor, ref smp.shockwave, ref smp.storm, ref smp.lava, ref smp.shd);
                        pb_mass[indikat - 1].Image = smp.icon;
                        smp.position = pb_mass[indikat - 1];
                        smechenie(pb_mass[indikat - 1], ref smp.heal, ref smp.shield, ref smp.berserk, ref smp.gun, ref smp.meteor, ref smp.shockwave, ref smp.storm, ref smp.lava, ref smp.shd);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        label4.ForeColor = Color.Red;
                        smp.health -= 100;
                        Slezhka(ref smp.pBar, ref smp.health, ref smp.indikator, ref smp.shield, ref smp.berserk, ref smp.position, ref smp.name, ref smp.icon, ref smp.gun, ref smp.lava, ref smp.meteor, ref smp.shockwave,
                            ref smp.storm, ref smp.heal, ref smp.labe);
                    }
                    try
                    {
                        smechenie_nazad(pb_mass[indikat], ref bb.heal, ref bb.shield, ref bb.berserk, ref bb.gun, ref bb.meteor, ref bb.shockwave, ref bb.storm, ref bb.lava, ref bb.shd);
                        pb_mass[indikat - 5].Image = bb.icon;
                        bb.position = pb_mass[indikat - 5];
                        smechenie(pb_mass[indikat - 5], ref bb.heal, ref bb.shield, ref bb.berserk, ref bb.gun, ref bb.meteor, ref bb.shockwave, ref bb.storm, ref bb.lava, ref bb.shd);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        label4.ForeColor = Color.Red;
                        bb.health -= 100;
                        Slezhka(ref bb.pBar, ref bb.health, ref bb.indikator, ref bb.shield, ref bb.berserk, ref bb.position, ref bb.name, ref bb.icon, ref bb.gun, ref bb.lava, ref bb.meteor, ref bb.shockwave,
                            ref bb.storm, ref bb.heal, ref bb.labe);
                    }
                    pl.health -= 20;
                    smp.health -= 20;
                    bb.health -= 20;
                    label2.ForeColor = label3.ForeColor = label4.ForeColor = Color.Red;
                    label2.Text = pl.name + " получил 20 урона от " + gr.name;
                    label3.Text = smp.name + " получил 20 урона от " + gr.name;
                    label4.Text = bb.name + " получил 20 урона от " + gr.name;
                    Slezhka(ref pl.pBar, ref pl.health, ref pl.indikator, ref pl.shield, ref pl.berserk, ref pl.position, ref pl.name, ref pl.icon, ref pl.gun, ref pl.lava, ref pl.meteor, ref pl.shockwave,
                            ref pl.storm, ref pl.heal, ref pl.labe);
                    Slezhka(ref smp.pBar, ref smp.health, ref smp.indikator, ref smp.shield, ref smp.berserk, ref smp.position, ref smp.name, ref smp.icon, ref smp.gun, ref smp.lava, ref smp.meteor, ref smp.shockwave,
                            ref smp.storm, ref smp.heal, ref smp.labe);
                    Slezhka(ref bb.pBar, ref bb.health, ref bb.indikator, ref bb.shield, ref bb.berserk, ref bb.position, ref bb.name, ref bb.icon, ref bb.gun, ref bb.lava, ref bb.meteor, ref bb.shockwave,
                            ref bb.storm, ref bb.heal, ref bb.labe);
                    break;
                case 3:
                    label1.Text = smp.name + " отстоял поле " + indikat;
                    pb_mass[indikat].Image = smp.icon;
                    smp.position = pb_mass[indikat];
                    try
                    {
                        smechenie_nazad(pb_mass[indikat], ref pl.heal, ref pl.shield, ref pl.berserk, ref pl.gun, ref pl.meteor, ref pl.shockwave, ref pl.storm, ref pl.lava, ref pl.shd);
                        pb_mass[indikat + 1].Image = pl.icon;
                        pl.position = pb_mass[indikat + 1];
                        smechenie(pb_mass[indikat + 1], ref pl.heal, ref pl.shield, ref pl.berserk, ref pl.gun, ref pl.meteor, ref pl.shockwave, ref pl.storm, ref pl.lava, ref pl.shd);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        label4.ForeColor = Color.Red;
                        pl.health -= 100;
                        Slezhka(ref pl.pBar, ref pl.health, ref pl.indikator, ref pl.shield, ref pl.berserk, ref pl.position, ref pl.name, ref pl.icon, ref pl.gun, ref pl.lava, ref pl.meteor, ref pl.shockwave,
                            ref pl.storm, ref pl.heal, ref pl.labe);
                    }
                    try
                    {
                        smechenie_nazad(pb_mass[indikat], ref gr.heal, ref gr.shield, ref gr.berserk, ref gr.gun, ref gr.meteor, ref gr.shockwave, ref gr.storm, ref gr.lava, ref gr.shd);
                        pb_mass[indikat - 1].Image = gr.icon;
                        gr.position = pb_mass[indikat - 1];
                        smechenie(pb_mass[indikat - 1], ref gr.heal, ref gr.shield, ref gr.berserk, ref gr.gun, ref gr.meteor, ref gr.shockwave, ref gr.storm, ref gr.lava, ref gr.shd);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        label4.ForeColor = Color.Red;
                        gr.health -= 100;
                        Slezhka(ref gr.pBar, ref gr.health, ref gr.indikator, ref gr.shield, ref gr.berserk, ref gr.position, ref gr.name, ref gr.icon, ref gr.gun, ref gr.lava, ref gr.meteor, ref gr.shockwave, ref gr.storm,
                            ref gr.heal,ref gr.labe);
                    }
                    try
                    {
                        smechenie_nazad(pb_mass[indikat], ref bb.heal, ref bb.shield, ref bb.berserk, ref bb.gun, ref bb.meteor, ref bb.shockwave, ref bb.storm, ref bb.lava, ref bb.shd);
                        pb_mass[indikat - 5].Image = bb.icon;
                        bb.position = pb_mass[indikat - 5];
                        smechenie(pb_mass[indikat - 5], ref bb.heal, ref bb.shield, ref bb.berserk, ref bb.gun, ref bb.meteor, ref bb.shockwave, ref bb.storm, ref bb.lava, ref bb.shd);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        label4.ForeColor = Color.Red;
                        bb.health -= 100;
                        Slezhka(ref bb.pBar, ref bb.health, ref bb.indikator, ref bb.shield, ref bb.berserk, ref bb.position, ref bb.name, ref bb.icon, ref bb.gun, ref bb.lava, ref bb.meteor, ref bb.shockwave,
                            ref bb.storm, ref bb.heal,ref bb.labe);
                    }
                    pl.health -= 20;
                    gr.health -= 20;
                    bb.health -= 20;
                    label2.ForeColor = label3.ForeColor = label4.ForeColor = Color.Red;
                    label2.Text = pl.name + " получил 20 урона от " + smp.name;
                    label3.Text = gr.name + " получил 20 урона от " + smp.name;
                    label4.Text = bb.name + " получил 20 урона от " + smp.name;
                    Slezhka(ref pl.pBar, ref pl.health, ref pl.indikator, ref pl.shield, ref pl.berserk, ref pl.position, ref pl.name, ref pl.icon, ref pl.gun, ref pl.lava, ref pl.meteor, ref pl.shockwave,
                            ref pl.storm, ref pl.heal, ref pl.labe);
                    Slezhka(ref gr.pBar, ref gr.health, ref gr.indikator, ref gr.shield, ref gr.berserk, ref gr.position, ref gr.name, ref gr.icon, ref gr.gun, ref gr.lava, ref gr.meteor, ref gr.shockwave, ref gr.storm,
                            ref gr.heal, ref gr.labe);
                    Slezhka(ref bb.pBar, ref bb.health, ref bb.indikator, ref bb.shield, ref bb.berserk, ref bb.position, ref bb.name, ref bb.icon, ref bb.gun, ref bb.lava, ref bb.meteor, ref bb.shockwave,
                            ref bb.storm, ref bb.heal, ref bb.labe);
                    break;
                case 4:
                    label1.Text = bb.name + " отстоял поле " + indikat;
                    pb_mass[indikat].Image = bb.icon;
                    bb.position = pb_mass[indikat];
                    try
                    {
                        smechenie_nazad(pb_mass[indikat], ref pl.heal, ref pl.shield, ref pl.berserk, ref pl.gun, ref pl.meteor, ref pl.shockwave, ref pl.storm, ref pl.lava, ref pl.shd);
                        pb_mass[indikat + 1].Image = pl.icon;
                        pl.position = pb_mass[indikat + 1];
                        smechenie(pb_mass[indikat + 1], ref pl.heal, ref pl.shield, ref pl.berserk, ref pl.gun, ref pl.meteor, ref pl.shockwave, ref pl.storm, ref pl.lava, ref pl.shd);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        label4.ForeColor = Color.Red;
                        pl.health -= 100;
                        Slezhka(ref pl.pBar, ref pl.health, ref pl.indikator, ref pl.shield, ref pl.berserk, ref pl.position, ref pl.name, ref pl.icon, ref pl.gun, ref pl.lava, ref pl.meteor, ref pl.shockwave,
                            ref pl.storm, ref pl.heal, ref pl.labe);
                    }
                    try
                    {
                        smechenie_nazad(pb_mass[indikat], ref gr.heal, ref gr.shield, ref gr.berserk, ref gr.gun, ref gr.meteor, ref gr.shockwave, ref gr.storm, ref gr.lava, ref gr.shd);
                        pb_mass[indikat - 1].Image = gr.icon;
                        gr.position = pb_mass[indikat - 1];
                        smechenie(pb_mass[indikat - 1], ref gr.heal, ref gr.shield, ref gr.berserk, ref gr.gun, ref gr.meteor, ref gr.shockwave, ref gr.storm, ref gr.lava, ref gr.shd);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        label4.ForeColor = Color.Red;
                        gr.health -= 100;
                        Slezhka(ref gr.pBar, ref gr.health, ref gr.indikator, ref gr.shield, ref gr.berserk, ref gr.position, ref gr.name, ref gr.icon, ref gr.gun, ref gr.lava, ref gr.meteor, ref gr.shockwave, ref gr.storm,
                            ref gr.heal, ref gr.labe);
                    }
                    try
                    {
                        smechenie_nazad(pb_mass[indikat], ref smp.heal, ref smp.shield, ref smp.berserk, ref smp.gun, ref smp.meteor, ref smp.shockwave, ref smp.storm, ref smp.lava, ref smp.shd);
                        pb_mass[indikat - 5].Image = smp.icon;
                        smp.position = pb_mass[indikat - 5];
                        smechenie(pb_mass[indikat - 5], ref smp.heal, ref smp.shield, ref smp.berserk, ref smp.gun, ref smp.meteor, ref smp.shockwave, ref smp.storm, ref smp.lava, ref smp.shd);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        label4.ForeColor = Color.Red;
                        smp.health -= 100;
                        label4.Text = smp.name + " выбит";
                        Slezhka(ref smp.pBar, ref smp.health, ref smp.indikator, ref smp.shield, ref smp.berserk, ref smp.position, ref smp.name, ref smp.icon, ref smp.gun, ref smp.lava, ref smp.meteor, ref smp.shockwave,
                            ref smp.storm, ref smp.heal, ref smp.labe);
                    }
                    pl.health -= 20;
                    gr.health -= 20;
                    smp.health -= 20;
                    label2.ForeColor = label3.ForeColor = label4.ForeColor = Color.Red;
                    label2.Text = pl.name + " получил 20 урона от " + bb.name;
                    label3.Text = gr.name + " получил 20 урона от " + bb.name;
                    label4.Text = smp.name + " получил 20 урона от " + bb.name;
                    Slezhka(ref pl.pBar, ref pl.health, ref pl.indikator, ref pl.shield, ref pl.berserk, ref pl.position, ref pl.name, ref pl.icon, ref pl.gun, ref pl.lava, ref pl.meteor, ref pl.shockwave,
                            ref pl.storm, ref pl.heal, ref pl.labe);
                    Slezhka(ref gr.pBar, ref gr.health, ref gr.indikator, ref gr.shield, ref gr.berserk, ref gr.position, ref gr.name, ref gr.icon, ref gr.gun, ref gr.lava, ref gr.meteor, ref gr.shockwave, ref gr.storm,
                            ref gr.heal, ref gr.labe);
                    Slezhka(ref smp.pBar, ref smp.health, ref smp.indikator, ref smp.shield, ref smp.berserk, ref smp.position, ref smp.name, ref smp.icon, ref smp.gun, ref smp.lava, ref smp.meteor, ref smp.shockwave,
                            ref smp.storm, ref smp.heal, ref smp.labe);
                    break;
            }
        }

        private void pre_spor4()
        {
            do
            {
                spor1 = rnd.Next(1, 7);
                spor2 = rnd.Next(1, 7);
                spor3 = rnd.Next(1, 7);
                spor4 = rnd.Next(1, 7);
            } while (spor1 == spor2 && spor1 == spor3 && spor1 == spor4 && spor2 == spor3 && spor2 == spor4 && spor3 == spor4);
            label1.ForeColor = label2.ForeColor = label3.ForeColor = label4.ForeColor = Color.Black;
            label1.Text = name1 + " выбросил " + spor1;
            label2.Text = name2 + " выбросил " + spor2;
            label3.Text = name3 + " выбросил " + spor3;
            label4.Text = name4 + " выбросил " + spor4;
            if (spor1 > spor2 && spor1 > spor3 && spor1 > spor4)
                spor_rezult = 1;
            else if (spor2 > spor1 && spor2 > spor3 && spor2 > spor4)
                spor_rezult = 2;
            else if (spor3 > spor1 && spor3 > spor2 && spor3 > spor4)
                spor_rezult = 3;
            else
                spor_rezult = 4;
        }

        private void spoR_4()
        {
            if (pl.indikator == gr.indikator && pl.indikator == smp.indikator && pl.indikator == bb.indikator)
            {
                pl.position.Image = Image.FromFile("player_gorilla_shimp_baboon.jpg");
                indikator = pl.indikator;
                name1 = pl.name;
                name2 = gr.name;
                name3 = smp.name;
                name4 = bb.name;
            }
        }

        private void intro_spoR_3(ref int indikat, ref int indikator2, ref int indikator3, ref string name1, ref string name2, ref string name3, ref int health1, ref int health2, ref int health3, ref Image image1,
            ref Image image2, ref Image image3, ref PictureBox position1, ref PictureBox position2, ref PictureBox position3, ref bool heal1, ref bool heal2, ref bool heal3, ref int shielt1, ref int shielt2, ref int shielt3,
            ref int bers1, ref int bers2, ref int bers3, ref bool gun1, ref bool gun2, ref bool gun3, ref bool meteor1, ref bool meteor2, ref bool meteor3, ref bool shock1, ref bool shock2, ref bool shock3, ref bool storm1,
            ref bool storm2, ref bool storm3, ref bool lava1, ref bool lava2, ref bool lava3, ref ProgressBar pbar1, ref ProgressBar pbar2, ref ProgressBar pbar3, ref bool shd1, ref bool shd2, ref bool shd3, ref Label labe1,
            ref Label labe2, ref Label labe3)
        {
            label1.ForeColor = Color.Black;
            switch (spor_rezult)
            {
                case 1:
                    label1.Text = name1 + " отстоял поле " + indikat;
                    pb_mass[indikat].Image = image1;
                    position1 = pb_mass[indikat];
                    try
                    {
                        if (pb_mass[indikat + 1].Image.Height != 50)
                        {
                            smechenie_nazad(pb_mass[indikat], ref heal2, ref shielt2, ref bers2, ref gun2, ref meteor2, ref shock2, ref storm2, ref lava2, ref shd2);
                            pb_mass[indikat + 1].Image = image2;
                            position2 = pb_mass[indikat + 1];
                            smechenie(pb_mass[indikat + 1], ref heal2, ref shielt2, ref bers2, ref gun2, ref meteor2, ref shock2, ref storm2, ref lava2, ref shd2);
                        }
                        else
                        {
                            smechenie_nazad(pb_mass[indikat], ref heal2, ref shielt2, ref bers2, ref gun2, ref meteor2, ref shock2, ref storm2, ref lava2, ref shd2);
                            pb_mass[indikat - 1].Image = image2;
                            position2 = pb_mass[indikat - 1];
                            smechenie(pb_mass[indikat - 1], ref heal2, ref shielt2, ref bers2, ref gun2, ref meteor2, ref shock2, ref storm2, ref lava2, ref shd2);
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        label4.ForeColor = Color.Red;
                        health2 -= 100;
                        Slezhka(ref pbar2, ref health2, ref indikator2, ref shielt2, ref bers2, ref position2, ref name2, ref image2, ref gun2, ref lava2, ref meteor2, ref shock2, ref storm2, ref heal2, ref labe2);
                    }
                    try
                    {
                        if (pb_mass[indikat - 5].Image.Height != 50)
                        {
                            smechenie_nazad(pb_mass[indikat], ref heal3, ref shielt3, ref bers3, ref gun3, ref meteor3, ref shock3, ref storm3, ref lava3, ref shd3);
                            pb_mass[indikat - 5].Image = image3;
                            position3 = pb_mass[indikat - 5];
                            smechenie(pb_mass[indikat - 5], ref heal3, ref shielt3, ref bers3, ref gun3, ref meteor3, ref shock3, ref storm3, ref lava3, ref shd3);
                        }
                        else
                        {
                            smechenie_nazad(pb_mass[indikat], ref heal3, ref shielt3, ref bers3, ref gun3, ref meteor3, ref shock3, ref storm3, ref lava3, ref shd3);
                            pb_mass[indikat + 5].Image = image3;
                            position3 = pb_mass[indikat + 5];
                            smechenie(pb_mass[indikat + 5], ref heal3, ref shielt3, ref bers3, ref gun3, ref meteor3, ref shock3, ref storm3, ref lava3, ref shd3);
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        label4.ForeColor = Color.Red;
                        health3 -= 100;
                        Slezhka(ref pbar3, ref health3, ref indikator3, ref shielt3, ref bers3, ref position3, ref name3, ref image3, ref gun3, ref lava3, ref meteor3, ref shock3, ref storm3, ref heal3, ref labe3);
                    }
                    health2 -= 20;
                    health3 -= 20;
                    label2.ForeColor = label3.ForeColor = Color.Red;
                    label2.Text = name2 + " получил 20 урона от " + name1;
                    label3.Text = name3 + " получил 20 урона от " + name1;
                    label2.ForeColor = label3.ForeColor = Color.Black;
                    Slezhka(ref pbar2, ref health2, ref indikator2, ref shielt2, ref bers2, ref position2, ref name2, ref image2, ref gun2, ref lava2, ref meteor2, ref shock2, ref storm2, ref heal2, ref labe2);
                    Slezhka(ref pbar3, ref health3, ref indikator3, ref shielt3, ref bers3, ref position3, ref name3, ref image3, ref gun3, ref lava3, ref meteor3, ref shock3, ref storm3, ref heal3, ref labe3);
                    break;
                case 2:
                    label1.Text = name2 + " отстоял поле " + indikat;
                    pb_mass[indikat].Image = image2;
                    position2 = pb_mass[indikat];
                    try
                    {
                        if (pb_mass[indikat + 1].Image.Height != 50)
                        {
                            smechenie_nazad(pb_mass[indikat], ref heal1, ref shielt1, ref bers1, ref gun1, ref meteor1, ref shock1, ref storm1, ref lava1, ref shd1);
                            pb_mass[indikat + 1].Image = image1;
                            position1 = pb_mass[indikat + 1];
                            smechenie(pb_mass[indikat + 1], ref heal1, ref shielt1, ref bers1, ref gun1, ref meteor1, ref shock1, ref storm1, ref lava1, ref shd1);
                        }
                        else
                        {
                            smechenie_nazad(pb_mass[indikat], ref heal1, ref shielt1, ref bers1, ref gun1, ref meteor1, ref shock1, ref storm1, ref lava1, ref shd1);
                            pb_mass[indikat - 1].Image = image1;
                            position1 = pb_mass[indikat - 1];
                            smechenie(pb_mass[indikat - 1], ref heal1, ref shielt1, ref bers1, ref gun1, ref meteor1, ref shock1, ref storm1, ref lava1, ref shd1);
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        label4.ForeColor = Color.Red;
                        health1 -= 100;
                        Slezhka(ref pbar1, ref health1, ref indikat, ref shielt1, ref bers1, ref position1, ref name1, ref image1, ref gun1, ref lava1, ref meteor1, ref shock1, ref storm1, ref heal1, ref labe1);
                    }
                    try
                    {
                        if (pb_mass[indikat - 5].Image.Height != 50)
                        {
                            smechenie_nazad(pb_mass[indikat], ref heal3, ref shielt3, ref bers3, ref gun3, ref meteor3, ref shock3, ref storm3, ref lava3, ref shd3);
                            pb_mass[indikat - 5].Image = image3;
                            position3 = pb_mass[indikat - 5];
                            smechenie(pb_mass[indikat - 5], ref heal3, ref shielt3, ref bers3, ref gun3, ref meteor3, ref shock3, ref storm3, ref lava3, ref shd3);
                        }
                        else
                        {
                            smechenie_nazad(pb_mass[indikat], ref heal3, ref shielt3, ref bers3, ref gun3, ref meteor3, ref shock3, ref storm3, ref lava3, ref shd3);
                            pb_mass[indikat + 5].Image = image3;
                            position3 = pb_mass[indikat + 5];
                            smechenie(pb_mass[indikat + 5], ref heal3, ref shielt3, ref bers3, ref gun3, ref meteor3, ref shock3, ref storm3, ref lava3, ref shd3);
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        label4.ForeColor = Color.Red;
                        health3 -= 100;
                        Slezhka(ref pbar3, ref health3, ref indikator3, ref shielt3, ref bers3, ref position3, ref name3, ref image3, ref gun3, ref lava3, ref meteor3, ref shock3, ref storm3, ref heal3, ref labe3);
                    }
                    health1 -= 20;
                    health3 -= 20;
                    label2.ForeColor = label3.ForeColor = Color.Red;
                    label2.Text = name1 + " получил 20 урона от " + name2;
                    label3.Text = name3 + " получил 20 урона от " + name2;
                    label2.ForeColor = label3.ForeColor = Color.Black;
                    Slezhka(ref pbar1, ref health1, ref indikat, ref shielt1, ref bers1, ref position1, ref name1, ref image1, ref gun1, ref lava1, ref meteor1, ref shock1, ref storm1, ref heal1,ref labe1);
                    Slezhka(ref pbar3, ref health3, ref indikator3, ref shielt3, ref bers3, ref position3, ref name3, ref image3, ref gun3, ref lava3, ref meteor3, ref shock3, ref storm3, ref heal3,ref labe3);
                    break;
                case 3:
                    label1.Text = name3 + " отстоял поле " + indikat;
                    pb_mass[indikat].Image = image3;
                    position3 = pb_mass[indikat];
                    try
                    {
                        if (pb_mass[indikat + 1].Image.Height != 50)
                        {
                            smechenie_nazad(pb_mass[indikat], ref heal1, ref shielt1, ref bers1, ref gun1, ref meteor1, ref shock1, ref storm1, ref lava1, ref shd1);
                            pb_mass[indikat + 1].Image = image1;
                            position1 = pb_mass[indikat + 1];
                            smechenie(pb_mass[indikat + 1], ref heal1, ref shielt1, ref bers1, ref gun1, ref meteor1, ref shock1, ref storm1, ref lava1, ref shd1);
                        }
                        else
                        {
                            smechenie_nazad(pb_mass[indikat], ref heal1, ref shielt1, ref bers1, ref gun1, ref meteor1, ref shock1, ref storm1, ref lava1, ref shd1);
                            pb_mass[indikat - 1].Image = image1;
                            position1 = pb_mass[indikat - 1];
                            smechenie(pb_mass[indikat - 1], ref heal1, ref shielt1, ref bers1, ref gun1, ref meteor1, ref shock1, ref storm1, ref lava1, ref shd1);
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        label4.ForeColor = Color.Red;
                        health1 -= 100;
                        Slezhka(ref pbar1, ref health1, ref indikat, ref shielt1, ref bers1, ref position1, ref name1, ref image1, ref gun1, ref lava1, ref meteor1, ref shock1, ref storm1, ref heal1, ref labe1);
                    }
                    try
                    {
                        if (pb_mass[indikat - 5].Image.Height != 50)
                        {
                            smechenie_nazad(pb_mass[indikat], ref heal2, ref shielt2, ref bers2, ref gun2, ref meteor2, ref shock2, ref storm2, ref lava2, ref shd2);
                            pb_mass[indikat - 5].Image = image2;
                            position2 = pb_mass[indikat - 5];
                            smechenie(pb_mass[indikat - 5], ref heal2, ref shielt2, ref bers2, ref gun2, ref meteor2, ref shock2, ref storm2, ref lava2, ref shd2);
                        }
                        else
                        {
                            smechenie_nazad(pb_mass[indikat], ref heal2, ref shielt2, ref bers2, ref gun2, ref meteor2, ref shock2, ref storm2, ref lava2, ref shd2);
                            pb_mass[indikat + 5].Image = image2;
                            position2 = pb_mass[indikat + 5];
                            smechenie(pb_mass[indikat + 5], ref heal2, ref shielt2, ref bers2, ref gun2, ref meteor2, ref shock2, ref storm2, ref lava2, ref shd2);
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        label4.ForeColor = Color.Red;
                        health2 -= 100;
                        Slezhka(ref pbar2, ref health2, ref indikator2, ref shielt2, ref bers2, ref position2, ref name2, ref image2, ref gun2, ref lava2, ref meteor2, ref shock2, ref storm2, ref heal2, ref labe2);
                    }
                    health1 -= 20;
                    health2 -= 20;
                    label2.ForeColor = label3.ForeColor = Color.Red;
                    label2.Text = name1 + " получил 20 урона от " + name3;
                    label3.Text = name2 + " получил 20 урона от " + name3;
                    label2.ForeColor = label3.ForeColor = Color.Black;
                    Slezhka(ref pbar1, ref health1, ref indikat, ref shielt1, ref bers1, ref position1, ref name1, ref image1, ref gun1, ref lava1, ref meteor1, ref shock1, ref storm1, ref heal1, ref labe1);
                    Slezhka(ref pbar2, ref health2, ref indikator2, ref shielt2, ref bers2, ref position2, ref name2, ref image2, ref gun2, ref lava2, ref meteor2, ref shock2, ref storm2, ref heal2, ref labe2);
                    break;
            }
        }

        private void pre_spor3()
        {
            do
            {
                spor1 = rnd.Next(1, 7);
                spor2 = rnd.Next(1, 7);
                spor3 = rnd.Next(1, 7);
            } while (spor1 == spor2 && spor1 == spor3 && spor2 == spor3);
            label1.ForeColor = label2.ForeColor = label3.ForeColor = Color.Black;
            label1.Text = name1 + " выбросил " + spor1;
            label2.Text = name2 + " выбросил " + spor2;
            label3.Text = name3 + " выбросил " + spor3;
            if (spor1 > spor2 && spor1 > spor3)
                spor_rezult = 1;
            else if (spor2 > spor1 && spor2 > spor3)
                spor_rezult = 2;
            else
                spor_rezult = 3;
        }

        private void podSpor3(int spor_ind)
        {
            switch (spor_ind)
            {
                case 0:
                    intro_spoR_3(ref pl.indikator, ref gr.indikator, ref smp.indikator, ref pl.name, ref gr.name, ref smp.name, ref pl.health, ref gr.health, ref smp.health, ref pl.icon, ref gr.icon, ref smp.icon,
                        ref pl.position, ref gr.position, ref smp.position, ref pl.heal, ref gr.heal, ref smp.heal, ref pl.shield, ref gr.shield, ref smp.shield, ref pl.berserk, ref gr.berserk, ref smp.berserk, ref pl.gun,
                        ref gr.gun, ref smp.gun, ref pl.meteor, ref gr.meteor, ref smp.meteor, ref pl.shockwave, ref gr.shockwave, ref smp.shockwave, ref pl.storm, ref gr.storm, ref smp.storm, ref pl.lava, ref gr.lava,
                        ref smp.lava, ref pl.pBar, ref gr.pBar, ref smp.pBar, ref pl.shd, ref gr.shd, ref smp.shd,ref pl.labe,ref gr.labe,ref smp.labe);
                    break;
                case 1:
                    intro_spoR_3(ref pl.indikator, ref gr.indikator, ref bb.indikator, ref pl.name, ref gr.name, ref bb.name, ref pl.health, ref gr.health, ref bb.health, ref pl.icon, ref gr.icon, ref bb.icon,
                        ref pl.position, ref gr.position, ref bb.position, ref pl.heal, ref gr.heal, ref bb.heal, ref pl.shield, ref gr.shield, ref bb.shield, ref pl.berserk, ref gr.berserk, ref bb.berserk, ref pl.gun,
                        ref gr.gun, ref bb.gun, ref pl.meteor, ref gr.meteor, ref bb.meteor, ref pl.shockwave, ref gr.shockwave, ref bb.shockwave, ref pl.storm, ref gr.storm, ref bb.storm, ref pl.lava, ref gr.lava,
                        ref bb.lava, ref pl.pBar, ref gr.pBar, ref bb.pBar, ref pl.shd, ref gr.shd, ref bb.shd,ref pl.labe,ref gr.labe,ref bb.labe);
                    break;
                case 2:
                    intro_spoR_3(ref pl.indikator, ref smp.indikator, ref bb.indikator, ref pl.name, ref smp.name, ref bb.name, ref pl.health, ref smp.health, ref bb.health, ref pl.icon, ref smp.icon, ref bb.icon,
                        ref pl.position, ref smp.position, ref bb.position, ref pl.heal, ref smp.heal, ref bb.heal, ref pl.shield, ref smp.shield, ref bb.shield, ref pl.berserk, ref smp.berserk, ref bb.berserk, ref pl.gun,
                        ref smp.gun, ref bb.gun, ref pl.meteor, ref smp.meteor, ref bb.meteor, ref pl.shockwave, ref smp.shockwave, ref bb.shockwave, ref pl.storm, ref smp.storm, ref bb.storm, ref pl.lava, ref smp.lava,
                        ref bb.lava, ref pl.pBar, ref smp.pBar, ref bb.pBar, ref pl.shd, ref smp.shd, ref bb.shd, ref pl.labe,ref smp.labe, ref bb.labe);
                    break;
                case 3:
                    intro_spoR_3(ref gr.indikator, ref smp.indikator, ref bb.indikator, ref gr.name, ref smp.name, ref bb.name, ref gr.health, ref smp.health, ref bb.health, ref gr.icon, ref smp.icon, ref bb.icon,
                        ref gr.position, ref smp.position, ref bb.position, ref gr.heal, ref smp.heal, ref bb.heal, ref gr.shield, ref smp.shield, ref bb.shield, ref gr.berserk, ref smp.berserk, ref bb.berserk, ref gr.gun,
                        ref smp.gun, ref bb.gun, ref gr.meteor, ref smp.meteor, ref bb.meteor, ref gr.shockwave, ref smp.shockwave, ref bb.shockwave, ref gr.storm, ref smp.storm, ref bb.storm, ref gr.lava, ref smp.lava,
                        ref bb.lava, ref gr.pBar, ref smp.pBar, ref bb.pBar, ref gr.shd, ref smp.shd, ref bb.shd, ref gr.labe, ref smp.labe, ref bb.labe);
                    break;
            }
        }

        private void spoR_3()
        {
            if (pl.indikator == gr.indikator && pl.indikator == smp.indikator && pl.health > 0 && gr.health > 0 && smp.health > 0)
            {
                pl.position.Image = Image.FromFile("player_gorilla_shimp.jpg");
                indikator = pl.indikator;
                name1 = pl.name;
                name2 = gr.name;
                name3 = smp.name;
                spor_index = 0;
                return;
            }
            if (pl.indikator == gr.indikator && pl.indikator == bb.indikator && pl.health > 0 && gr.health > 0 && bb.health > 0)
            {
                pl.position.Image = Image.FromFile("player_gorilla_baboon.jpg");
                indikator = pl.indikator;
                name1 = pl.name;
                name2 = gr.name;
                name3 = bb.name;
                spor_index = 1;
                return;
            }
            if (pl.indikator == smp.indikator && pl.indikator == bb.indikator && pl.health > 0 && bb.health > 0 && smp.health > 0)
            {
                pl.position.Image = Image.FromFile("player_shimp_baboon.jpg");
                indikator = pl.indikator;
                name1 = pl.name;
                name2 = smp.name;
                name3 = bb.name;
                spor_index = 2;
                return;
            }
            if (gr.indikator == smp.indikator && gr.indikator == bb.indikator && bb.health > 0 && gr.health > 0 && smp.health > 0)
            {
                gr.position.Image = Image.FromFile("gorilla_shimp_baboon.jpg");
                indikator = gr.indikator;
                name1 = gr.name;
                name2 = smp.name;
                name3 = bb.name;
                spor_index = 3;
                return;
            }
        }

        private void intro_spoR(ref int indikat, ref int indikat2, ref string name1, ref string name2, ref int health1, ref int health2, int spor_rezul, ref Image image1, ref Image image2, ref PictureBox position1,
            ref PictureBox position2, ref bool heal1, ref bool heal2, ref int shielt1, ref int shielt2, ref int bers1, ref int bers2, ref bool gun1, ref bool gun2, ref bool meteor1, ref bool meteor2, ref bool shock1,
            ref bool shock2, ref bool storm1, ref bool storm2, ref bool lava1, ref bool lava2, ref ProgressBar pbar1, ref ProgressBar pbar2, ref bool shd1, ref bool shd2, ref Label labe1, ref Label labe2)
        {
            label1.ForeColor = Color.Black;
            switch (spor_rezul)
            {
                case 1:
                    try
                    {
                        label1.Text = name1 + " отстоял поле " + indikat;
                        pb_mass[indikat].Image = image1;
                        position1 = pb_mass[indikat];
                        if (pb_mass[indikat + 1].Image.Height != 50)
                        {
                            smechenie_nazad(pb_mass[indikat], ref heal2, ref shielt2, ref bers2, ref gun2, ref meteor2, ref shock2, ref storm2, ref lava2, ref shd2);
                            pb_mass[indikat + 1].Image = image2;
                            position2 = pb_mass[indikat + 1];
                            smechenie(pb_mass[indikat + 1], ref heal2, ref shielt2, ref bers2, ref gun2, ref meteor2, ref shock2, ref storm2, ref lava2, ref shd2);
                        }
                        else if (pb_mass[indikat - 1].Image.Height != 50)
                        {
                            smechenie_nazad(pb_mass[indikat], ref heal2, ref shielt2, ref bers2, ref gun2, ref meteor2, ref shock2, ref storm2, ref lava2, ref shd2);
                            pb_mass[indikat - 1].Image = image2;
                            position2 = pb_mass[indikat - 1];
                            smechenie(pb_mass[indikat - 1], ref heal2, ref shielt2, ref bers2, ref gun2, ref meteor2, ref shock2, ref storm2, ref lava2, ref shd2);
                        }
                        else
                        {
                            smechenie_nazad(pb_mass[indikat], ref heal2, ref shielt2, ref bers2, ref gun2, ref meteor2, ref shock2, ref storm2, ref lava2, ref shd2);
                            pb_mass[indikat + 5].Image = image2;
                            position2 = pb_mass[indikat + 5];
                            smechenie(pb_mass[indikat + 5], ref heal2, ref shielt2, ref bers2, ref gun2, ref meteor2, ref shock2, ref storm2, ref lava2, ref shd2);
                        }
                        health2 -= 20;
                        label2.ForeColor = Color.Red;
                        label2.Text = name2 + " получил 20 урона от " + name1;
                        Slezhka(ref pbar2, ref health2, ref indikat2, ref shielt2, ref bers2, ref position2, ref name2, ref image2, ref gun2, ref lava2, ref meteor2, ref shock2, ref storm2, ref heal2, ref labe2);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        label3.ForeColor = Color.Red;
                        health2 -= 100;
                        Slezhka(ref pbar2, ref health2, ref indikat2, ref shielt2, ref bers2, ref position2, ref name2, ref image2, ref gun2, ref lava2, ref meteor2, ref shock2, ref storm2, ref heal2, ref labe2);
                    }
                    break;
                case 2:
                    try
                    {
                        label1.Text = name2 + " отстоял поле " + indikat;
                        pb_mass[indikat].Image = image2;
                        position2 = pb_mass[indikat];
                        if (pb_mass[indikat + 1].Image.Height != 50)
                        {
                            smechenie_nazad(pb_mass[indikat], ref heal1, ref shielt1, ref bers1, ref gun1, ref meteor1, ref shock1, ref storm1, ref lava1, ref shd1);
                            pb_mass[indikat + 1].Image = image1;
                            position1 = pb_mass[indikat + 1];
                            smechenie(pb_mass[indikat + 1], ref heal1, ref shielt1, ref bers1, ref gun1, ref meteor1, ref shock1, ref storm1, ref lava1, ref shd1);
                        }
                        else if (pb_mass[indikat - 1].Image.Height != 50)
                        {
                            smechenie_nazad(pb_mass[indikat], ref heal1, ref shielt1, ref bers1, ref gun1, ref meteor1, ref shock1, ref storm1, ref lava1, ref shd1);
                            pb_mass[indikat - 1].Image = image1;
                            position1 = pb_mass[indikat - 1];
                            smechenie(pb_mass[indikat - 1], ref heal1, ref shielt1, ref bers1, ref gun1, ref meteor1, ref shock1, ref storm1, ref lava1, ref shd1);
                        }
                        else
                        {
                            smechenie_nazad(pb_mass[indikat], ref heal1, ref shielt1, ref bers1, ref gun1, ref meteor1, ref shock1, ref storm1, ref lava1, ref shd1);
                            pb_mass[indikat + 5].Image = image1;
                            position1 = pb_mass[indikat + 5];
                            smechenie(pb_mass[indikat + 5], ref heal1, ref shielt1, ref bers1, ref gun1, ref meteor1, ref shock1, ref storm1, ref lava1, ref shd1);
                        }
                        health1 -= 20;
                        label2.ForeColor = Color.Red;
                        label2.Text = name1 + " получил 20 урона от " + name2;
                        Slezhka(ref pbar1, ref health1, ref indikat, ref shielt1, ref bers1, ref position1, ref name1, ref image1, ref gun1, ref lava1, ref meteor1, ref shock1, ref storm1, ref heal1,ref labe1);
                    }

                    catch (IndexOutOfRangeException)
                    {
                        label3.ForeColor = Color.Red;
                        health1 -= 100;
                        Slezhka(ref pbar1, ref health1, ref indikat, ref shielt1, ref bers1, ref position1, ref name1, ref image1, ref gun1, ref lava1, ref meteor1, ref shock1, ref storm1, ref heal1, ref labe1);
                    }
                    break;
            }
        }

        private void pre_spor(string name1, string name2)
        {
            do
            {
                spor1 = rnd.Next(1, 7);
                spor2 = rnd.Next(1, 7);
            } while (spor1 == spor2);
            label1.ForeColor = label2.ForeColor = Color.Black;
            label1.Text = name1 + " выбросил " + spor1;
            label2.Text = name2 + " выбросил " + spor2;
            if (spor1 > spor2)
                spor_rezult = 1;
            else spor_rezult = 2;
        }

        private void podSpor(int spor_ind)
        {
            switch (spor_ind)
            {
                case 0:
                    intro_spoR(ref pl.indikator, ref gr.indikator, ref pl.name, ref gr.name, ref pl.health, ref gr.health, spor_rezult, ref pl.icon, ref gr.icon, ref pl.position, ref gr.position, ref pl.heal, ref gr.heal,
                        ref pl.shield, ref gr.shield, ref pl.berserk, ref gr.berserk, ref pl.gun, ref gr.gun, ref pl.meteor, ref gr.meteor, ref pl.shockwave, ref gr.shockwave, ref pl.storm, ref gr.storm, ref pl.lava,
                        ref gr.lava, ref pl.pBar, ref gr.pBar, ref pl.shd, ref gr.shd, ref pl.labe,ref gr.labe);
                    break;
                case 1:
                    intro_spoR(ref pl.indikator, ref smp.indikator, ref pl.name, ref smp.name, ref pl.health, ref smp.health, spor_rezult, ref pl.icon, ref smp.icon, ref pl.position, ref smp.position, ref pl.heal,
                        ref smp.heal, ref pl.shield, ref smp.shield, ref pl.berserk, ref smp.berserk, ref pl.gun, ref smp.gun, ref pl.meteor, ref smp.meteor, ref pl.shockwave, ref smp.shockwave, ref pl.storm, ref smp.storm,
                        ref pl.lava, ref smp.lava, ref pl.pBar, ref smp.pBar, ref pl.shd, ref smp.shd, ref pl.labe, ref smp.labe);
                    break;
                case 2:
                    intro_spoR(ref pl.indikator, ref bb.indikator, ref pl.name, ref bb.name, ref pl.health, ref bb.health, spor_rezult, ref pl.icon, ref bb.icon, ref pl.position, ref bb.position, ref pl.heal, ref bb.heal,
                        ref pl.shield, ref bb.shield, ref pl.berserk, ref bb.berserk, ref pl.gun, ref bb.gun, ref pl.meteor, ref bb.meteor, ref pl.shockwave, ref bb.shockwave, ref pl.storm, ref bb.storm, ref pl.lava,
                        ref bb.lava, ref pl.pBar, ref bb.pBar, ref pl.shd, ref bb.shd, ref pl.labe, ref bb.labe);
                    break;
                case 3:
                    intro_spoR(ref gr.indikator, ref smp.indikator, ref gr.name, ref smp.name, ref gr.health, ref smp.health, spor_rezult, ref gr.icon, ref smp.icon, ref gr.position, ref smp.position, ref gr.heal,
                        ref smp.heal, ref gr.shield, ref smp.shield, ref gr.berserk, ref smp.berserk, ref gr.gun, ref smp.gun, ref gr.meteor, ref smp.meteor, ref gr.shockwave, ref smp.shockwave, ref gr.storm, ref smp.storm,
                        ref gr.lava, ref smp.lava, ref gr.pBar, ref smp.pBar, ref gr.shd, ref smp.shd, ref gr.labe, ref smp.labe);
                    break;
                case 4:
                    intro_spoR(ref gr.indikator, ref bb.indikator, ref gr.name, ref bb.name, ref gr.health, ref bb.health, spor_rezult, ref gr.icon, ref bb.icon, ref gr.position, ref bb.position, ref gr.heal, ref bb.heal,
                        ref gr.shield, ref bb.shield, ref gr.berserk, ref bb.berserk, ref gr.gun, ref bb.gun, ref gr.meteor, ref bb.meteor, ref gr.shockwave, ref bb.shockwave, ref gr.storm, ref bb.storm, ref gr.lava,
                        ref bb.lava, ref gr.pBar, ref bb.pBar, ref gr.shd, ref bb.shd, ref gr.labe, ref bb.labe);
                    break;
                case 5:
                    intro_spoR(ref smp.indikator, ref bb.indikator, ref smp.name, ref bb.name, ref smp.health, ref bb.health, spor_rezult, ref smp.icon, ref bb.icon, ref smp.position, ref bb.position, ref smp.heal,
                        ref bb.heal, ref smp.shield, ref bb.shield, ref smp.berserk, ref bb.berserk, ref smp.gun, ref bb.gun, ref smp.meteor, ref bb.meteor, ref smp.shockwave, ref bb.shockwave, ref smp.storm, ref bb.storm,
                        ref smp.lava, ref bb.lava, ref smp.pBar, ref bb.pBar, ref smp.shd, ref bb.shd, ref smp.labe, ref bb.labe);
                    break;
            }
        }

        private void spoR(ref int indikator, ref int spor_ind, ref string name1, ref string name2)
        {
            if (pl.indikator == gr.indikator && !propusk && pl.health > 0 && gr.health > 0)
            {
                pl.position.Image = Image.FromFile("player_gorilla.jpg");
                indikator = pl.indikator;
                name1 = pl.name;
                name2 = gr.name;
                spor_ind = 0;
                propusk = true;
                return;
            }
            if (pl.indikator == smp.indikator && !propusk && pl.health > 0 && smp.health > 0)
            {
                pl.position.Image = Image.FromFile("player_shimp.jpg");
                indikator = pl.indikator;
                name1 = pl.name;
                name2 = smp.name;
                spor_ind = 1;
                propusk = true;
                return;
            }
            if (pl.indikator == bb.indikator && !propusk && pl.health > 0 && bb.health > 0)
            {
                pl.position.Image = Image.FromFile("player_baboon.jpg");
                indikator = pl.indikator;
                name1 = pl.name;
                name2 = bb.name;
                spor_ind = 2;
                propusk = true;
                return;
            }
            if (gr.indikator == smp.indikator && !propusk1 && smp.health > 0 && gr.health > 0)
            {
                gr.position.Image = Image.FromFile("gorilla_shimp.jpg");
                indikator = gr.indikator;
                name1 = gr.name;
                name2 = smp.name;
                spor_ind = 3;
                propusk1 = true;
                return;
            }
            if (gr.indikator == bb.indikator && !propusk1 && bb.health > 0 && gr.health > 0)
            {
                gr.position.Image = Image.FromFile("gorilla_baboon.jpg");
                indikator = gr.indikator;
                name1 = gr.name;
                name2 = bb.name;
                spor_ind = 4;
                propusk1 = true;
                return;
            }
            if (smp.indikator == bb.indikator && !propusk2 && smp.health > 0 && bb.health > 0)
            {
                smp.position.Image = Image.FromFile("shimp_baboon.jpg");
                indikator = smp.indikator;
                name1 = smp.name;
                name2 = bb.name;
                spor_ind = 5;
                propusk2 = true;
                return;
            }
        }

        private void dvizhenie(ref PictureBox picBox, int health, ref int indi, Image imagg, ref bool heal, ref int shield, ref int bersek, ref bool gun, ref bool meteor, ref bool shockwave, ref bool storm, ref bool shd)
        {
            for (int i = 0; i < 65; i++)
            {
                if (picBox.Name == pb_mass[i].Name)
                    polozh = (i / 5) * 5;
            }
            switch (polozh)
            {
                case 0:
                    minus = 0;
                    break;
                case 5:
                    minus = 5;
                    break;
                case 50:
                    minus1 = 1;
                    break;
                case 55:
                    minus1 = 6;
                    break;
                case 60:
                    minus1 = 11;
                    break;
            }
            for (int i = polozh - minus; i < polozh + 15 - minus1; i++)
            {
                if (i != 4 || i != 9 || i != 14 || i != 19 || i != 24 || i != 29 || i != 34 || i != 39 || i != 44 || i != 49 || i != 54 || i != 59 || i != 64)
                {
                    if (pb_mass[i].BackColor == Color.Green)
                    {
                        health_pb = pb_mass[i + 1];
                        health_ind = i + 1;
                    }
                    if (pb_mass[i].BackColor == Color.Red)
                    {
                        shield_pb = pb_mass[i + 1];
                        shield_ind = i + 1;
                    }
                    if (pb_mass[i].BackColor == Color.Blue)
                    {
                        storm_pb = pb_mass[i + 1];
                        storm_ind = i + 1;
                    }
                    if (pb_mass[i].BackColor == Color.Orange)
                    {
                        meteorite_pb = pb_mass[i + 1];
                        meteorite_ind = i + 1;
                    }
                    if (pb_mass[i].BackColor == Color.WhiteSmoke)
                    {
                        shockwave_pb = pb_mass[i + 1];
                        shockwave_ind = i + 1;
                    }
                    if (pb_mass[i].BackColor == Color.Brown)
                    {
                        gun_pb = pb_mass[i + 1];
                        gun_ind = i + 1;
                    }
                    if (pb_mass[i].BackColor == Color.Tomato)
                    {
                        bersek_pb = pb_mass[i + 1];
                        bersek_ind = i + 1;
                    }
                }
            }
            minus = 10; minus1 = 0;
            if (health != 100 && health_pb != null)
            {
                picBox.Image = plittkka;
                health_pb.Image = imagg;
                picBox = health_pb;
                indi = health_ind;
                heal = true;
                goto second_part;
            }
            if (storm_pb != null)
            {
                picBox.Image = plittkka;
                storm_pb.Image = imagg;
                picBox = storm_pb;
                indi = storm_ind;
                storm = true;
                goto second_part;
            }
            if (meteorite_pb != null)
            {
                picBox.Image = plittkka;
                meteorite_pb.Image = imagg;
                picBox = meteorite_pb;
                indi = meteorite_ind;
                meteor = true;
                goto second_part;
            }
            if (shield_pb != null && shield <= 20)
            {
                picBox.Image = plittkka;
                shield_pb.Image = imagg;
                picBox = shield_pb;
                indi = shield_ind;
                shd = true;
                goto second_part;
            }
            if (bersek_pb != null && bersek <= 1)
            {
                picBox.Image = plittkka;
                bersek_pb.Image = imagg;
                picBox = bersek_pb;
                indi = bersek_ind;
                bersek = 3;
                goto second_part;
            }
            if (shockwave_pb != null)
            {
                picBox.Image = plittkka;
                shockwave_pb.Image = imagg;
                picBox = shockwave_pb;
                indi = shockwave_ind;
                shockwave = true;
                goto second_part;
            }
            if (gun_pb != null)
            {
                picBox.Image = plittkka;
                gun_pb.Image = imagg;
                picBox = gun_pb;
                indi = gun_ind;
                gun = true;
                goto second_part;
            }
        second_part:
            health_pb = shield_pb = storm_pb = meteorite_pb = shockwave_pb = gun_pb = bersek_pb = null;
            health_ind = shield_ind = storm_ind = meteorite_ind = shockwave_ind = gun_ind = bersek_ind = 0;
        }

        private void prijok(PictureBox picaBox, int indikator)
        {
            for (int i = 0; i < 65; i++)
                pb_mass[i].Enabled = false;
            int vnt_indi;
            vnt_indi = (indikator / 5) * 5;
            switch (vnt_indi)
            {
                case 0:
                    minus = 0;
                    break;
                case 5:
                    minus = 5;
                    break;
                case 55:
                    minus1 = 5;
                    break;
                case 60:
                    minus1 = 10;
                    break;
            }
            for (int i = vnt_indi - minus; i < vnt_indi + 15 - minus1; i++)
                pb_mass[i].Enabled = true;
            minus = 10;
            minus1 = 0;
        }

        private void prokrutka()
        {
            PictureBox[] pb_mass = new PictureBox[] {picb0,
        pb0,pb1,pb2, pb3,pb4,picb1,pb5, pb6, pb7,pb8,pb9,picb2,pb10,pb11,pb12,
        pb13,pb14,picb3,pb15,pb16,pb17,pb18,pb19,picb4,pb20,pb21,pb22,pb23,pb24,picb5,pb25,
        pb26,pb27,pb28,pb29,picb6,pb30,pb31,pb32,pb33,pb34,picb7,pb35,pb36,pb37,pb38,
        pb39,picb8,pb40,pb41,pb42,pb43,pb44,picb9,pb45,pb46,pb47,pb48,pb49,picb10,pb50,pb51,
        pb52,pb53,pb54,picb11,pb55,pb56,pb57,pb58,pb59,picb12,pb60,pb61,pb62,pb63,pb64
        };
            for (int j = 0; j < 6; j++)
            {
                for (int i = prokr_strk; i > -1; i -= 6)
                {
                    if (pb_mass[i].Image.Height != 50)
                    {
                        if (pb_mass[i + 1].Image.Height != 50)
                        {
                            pb_mass[i + 1].Image = pb_mass[i].Image;
                            pb_mass[i + 1].BackColor = pb_mass[i].BackColor;
                        }
                    }
                }
                prokr_strk--;
            }
            prokr_strk = 76;
        }

        private void top_line()
        {
            PictureBox[] p_massive = new PictureBox[] { picb0, picb1, picb2, picb3, picb4, picb5, picb6, picb7, picb8, picb9, picb10, picb11, picb12 };
            for (int i = 0; i < 13; i++)
            {
                top_random = rnd.Next(rnd_number);
                p_massive[i].Image = Image.FromFile(skills[top_random]);
                p_massive[i].BackColor = colors[top_random];
                skills.RemoveAt(top_random);
                colors.RemoveAt(top_random);
                rnd_number--;
            }
            rnd_number = 18;
            skills.Clear();
            colors.Clear();
            for (int i = 0; i < 18; i++)
            {
                skills.Add(skills1[i]);
                colors.Add(colors1[i]);
            }
        }

        private void start_position()
        {
            List<ProgressBar> progress = new List<ProgressBar> { progressBar5, progressBar4, progressBar3, progressBar2 };
            List<PictureBox> pb_list = new List<PictureBox> { pb63, pb44, pb24, pb3 };
            List<PictureBox> dwd_pict = new List<PictureBox> { pictureBox4, pictureBox3, pictureBox2, pictureBox1 };
            List<Label> labes = new List<Label> { label8, label7, label6, label5 };
            int chart = rnd.Next(4);
            pb_list[chart].Image = pl.icon;
            dwd_pict[chart].Image = Image.FromFile("player_download.jpg");
            progress[chart].Value = pl.health;
            switch (chart)
            {
                case 0:
                    pl.indikator = 63;
                    player_up = pb62;
                    break;
                case 1:
                    pl.indikator = 44;
                    player_up = pb43;
                    break;
                case 2:
                    pl.indikator = 24;
                    player_up = pb23;
                    break;
                case 3:
                    pl.indikator = 3;
                    player_up = pb2;
                    break;
            }
            pl.position = pb_list[chart];
            pl.pBar = progress[chart];
            pl.labe = labes[chart];
            pb_list.RemoveAt(chart);
            dwd_pict.RemoveAt(chart);
            progress.RemoveAt(chart);
            labes.RemoveAt(chart);
            //
            chart = rnd.Next(3);
            pb_list[chart].Image = gr.icon;
            dwd_pict[chart].Image = Image.FromFile("gorilla_download.jpg");
            progress[chart].Value = gr.health;
            gr.position = pb_list[chart];
            gr.pBar = progress[chart];
            gr.labe = labes[chart];
            pb_list.RemoveAt(chart);
            dwd_pict.RemoveAt(chart);
            progress.RemoveAt(chart);
            labes.RemoveAt(chart);
            //
            chart = rnd.Next(2);
            pb_list[chart].Image = smp.icon;
            dwd_pict[chart].Image = Image.FromFile("shimp_download.jpg");
            progress[chart].Value = smp.health;
            smp.position = pb_list[chart];
            smp.pBar = progress[chart];
            smp.labe = labes[chart];
            pb_list.RemoveAt(chart);
            dwd_pict.RemoveAt(chart);
            progress.RemoveAt(chart);
            labes.RemoveAt(chart);
            //
            pb_list[0].Image = bb.icon;
            dwd_pict[0].Image = Image.FromFile("baboon_download.jpg");
            progress[0].Value = bb.health;
            bb.position = pb_list[0];
            bb.pBar = progress[0];
            bb.labe = labes[0];
        }

        private void mainScreen_Load(object sender, EventArgs e)
        {
            pb_mass = new PictureBox[]{pb0,pb1,pb2, pb3,pb4,pb5, pb6, pb7,pb8,pb9,pb10,pb11,pb12,
        pb13,pb14,pb15,pb16,pb17,pb18,pb19,pb20,pb21,pb22,pb23,pb24,pb25,
        pb26,pb27,pb28,pb29,pb30,pb31,pb32,pb33,pb34,pb35,pb36,pb37,pb38,
        pb39,pb40,pb41,pb42,pb43,pb44,pb45,pb46,pb47,pb48,pb49,pb50,pb51,
        pb52,pb53,pb54,pb55,pb56,pb57,pb58,pb59,pb60,pb61,pb62,pb63,pb64};
            top_line();
            pl.health = 100;
            gr.health = 100;
            smp.health = 100;
            bb.health = 100;
            pl.icon = Image.FromFile("player.jpg");
            gr.icon = Image.FromFile("gorilla.jpg");
            smp.icon = Image.FromFile("shimp.jpg");
            bb.icon = Image.FromFile("baboon.jpg");
            start_position();
            pl.name = "Игрок";
            gr.name = "Горилла";
            smp.name = "Шимп";
            bb.name = "Бабуин";
            pl.bonus_bers = gr.bonus_bers = smp.bonus_bers = bb.bonus_bers = 1;
            player = pl.position;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            prokrutka();
            top_line();
            timer1.Stop();
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (!krutka)
                prokrutka();
            top_line();
            timer2.Stop();
            timer3.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
        SoundPlayer drum;
        drum = new SoundPlayer("drum.wav");
            label1.Text = label2.Text = label3.Text = label4.Text = "";
            if (!scd_run)
            {
                drum.Play();
                progressBar1.Visible = true;
                prijok(pl.position, pl.indikator);
                pl.position.BorderStyle = BorderStyle.Fixed3D;
                scd_run = true;
            }
            progressBar1.Value = time;
            if (time != 100)
            {
                time++;
                schet++;
            }
            if (schet == 100)
            {
                progressBar1.Visible = false;
                for (int i = 0; i < 65; i++)
                    pb_mass[i].Enabled = false;
                time = 1;
                schet = 1;
                scd_run = false;
                drum.Stop();
                timer3.Stop();
                timer4.Start();
            }
        }

        private void all_Click(object sender, EventArgs e)
        {
            player = (PictureBox)sender;
            for (int i = 0; i < 65; i++)
            {
                pb_mass[i].BorderStyle = BorderStyle.None;
                if (pb_mass[i] == player)
                {
                    pl.indikator = i;
                    if (i != 0)
                        player_up = pb_mass[i - 1];
                    else
                        player_up = pb_mass[i];
                }
            }
            player.BorderStyle = BorderStyle.Fixed3D;
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (gr.health > 0)
                dvizhenie(ref gr.position, gr.health, ref gr.indikator, gr.icon, ref gr.heal, ref gr.shield, ref gr.berserk, ref gr.gun, ref gr.meteor, ref gr.shockwave, ref gr.storm, ref gr.shd);
            if (smp.health > 0)
                dvizhenie(ref smp.position, smp.health, ref smp.indikator, smp.icon, ref smp.heal, ref smp.shield, ref smp.berserk, ref smp.gun, ref smp.meteor, ref smp.shockwave, ref smp.storm, ref smp.shd);
            if (bb.health > 0)
                dvizhenie(ref bb.position, bb.health, ref bb.indikator, bb.icon, ref bb.heal, ref bb.shield, ref bb.berserk, ref bb.gun, ref bb.meteor, ref bb.shockwave, ref bb.storm, ref bb.shd);
            if (player != pl.position)
            {
                player.Image = pl.icon;
                pl.position.Image = Image.FromFile("plitka.jpg");
                player.BorderStyle = BorderStyle.None;
                pl.position = player;
                smechenie(player_up, ref pl.heal, ref pl.shield, ref pl.berserk, ref pl.gun, ref pl.meteor, ref pl.shockwave, ref pl.storm, ref pl.lava, ref pl.shd);
            }
            else
            {
                player.BorderStyle = BorderStyle.None;
                smechenie(player_up, ref pl.heal, ref pl.shield, ref pl.berserk, ref pl.gun, ref pl.meteor, ref pl.shockwave, ref pl.storm, ref pl.lava, ref pl.shd);
            }
            if (pl.health > 0 && gr.health > 0 && smp.health > 0 && bb.health > 0)
                spoR_4();
            if (indikator != 0)
            {
                krutka = true;
                timer4.Stop();
                timer7.Start();
                nomers = 4;
                timer5.Start();
                return;
            }
            spoR_3();
            if (indikator != 0)
            {
                krutka = true;
                timer4.Stop();
                timer7.Start();
                nomers = 3;
                timer5.Start();
                return;
            }
            spoR(ref indikator, ref spor_index, ref name1, ref name2);
            if (indikator != 0)
            {
                krutka = true;
                timer7.Start();
                spoR(ref indikat, ref spor_index1, ref nam1, ref nam2);
                timer4.Stop();
                nomers = 2;
                propusk = propusk1 = propusk2 = false;
                timer5.Start();
            }
            else
            {
                timer4.Stop();
                timer7.Start();
                krutka = true;
                timer9.Start();
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            switch (nomers)
            {
                case 2:
                    if (!indexator)
                    {
                        pre_spor(name1, name2);
                        indexator = true;
                    }
                    else
                    {
                        podSpor(spor_index);
                        timer5.Stop();
                        name1 = name2 = null;
                        indexator = false;
                        nomers = spor_index = indikator = 0;
                        if (indikat != 0)
                            timer6.Start();
                        else
                            timer9.Start();
                    }
                    break;
                case 3:
                    if (!indexator)
                    {
                        pre_spor3();
                        indexator = true;
                    }
                    else
                    {
                        podSpor3(spor_index);
                        timer5.Stop();
                        indikator = nomers = spor_index = 0;
                        name1 = name2 = name3 = null;
                        indexator = false;
                        timer9.Start();
                    }
                    break;
                case 4:
                    if (!indexator)
                    {
                        pre_spor4();
                        indexator = true;
                    }
                    else
                    {
                        intro_spoR_4();
                        timer5.Stop();
                        indikator = nomers = spor_index = 0;
                        name1 = name2 = name3 = name4 = null;
                        indexator = false;
                        timer9.Start();
                    }
                    break;
            }
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            if (!indexator)
            {
                pre_spor(nam1, nam2);
                indexator = true;
            }
            else
            {
                podSpor(spor_index1);
                timer6.Stop();
                indikat = spor_index1 = 0;
                nam1 = nam2 = null;
                indexator = false;
                timer9.Start();
            }
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            prokrutka();
            top_line();
            timer7.Stop();
        }

        private void timer9_Tick(object sender, EventArgs e)
        {
            if (!sterka)
            {
                label1.Text = label2.Text = label3.Text = label4.Text = "";
                sterka = true;
            }
            switch (timer_9scht)
            {
                case 0:
                    if (pl.health > 0)
                        battle(ref pl.health, ref pl.shield, ref pl.berserk, ref pl.gun, ref pl.meteor, ref pl.shockwave, ref pl.storm, ref pl.heal, ref pl.lava, ref pl.name, ref label1, ref pl.bonus_bers, ref pl.indikator,
                            ref gr.health, ref smp.health, ref bb.health, ref gr.name, ref smp.name, ref bb.name, ref gr.shield, ref smp.shield, ref bb.shield, ref gr.berserk, ref smp.berserk, ref bb.berserk, ref gr.gun,
                            ref smp.gun, ref bb.gun, ref gr.meteor, ref smp.meteor, ref bb.meteor, ref gr.shockwave, ref smp.shockwave, ref bb.shockwave, ref gr.storm, ref smp.storm, ref bb.storm, ref gr.heal, ref smp.heal,
                            ref bb.heal, ref gr.lava, ref smp.lava, ref bb.lava, ref gr.indikator, ref smp.indikator, ref bb.indikator, ref pl.pBar, ref gr.pBar, ref smp.pBar, ref bb.pBar, ref gr.position, ref smp.position,
                            ref bb.position, ref gr.icon, ref smp.icon, ref bb.icon, ref pl.shd, ref gr.labe, ref smp.labe, ref bb.labe, ref pl.position, ref pl.icon);
                    if (gr.health > 0)
                        timer_9scht++;
                    else if (smp.health > 0)
                        timer_9scht += 2;
                    else if (bb.health > 0)
                        timer_9scht += 3; 
                    break;
                case 1:
                    if (gr.health > 0)
                        Stopper();
                        battle(ref gr.health, ref gr.shield, ref gr.berserk, ref gr.gun, ref gr.meteor, ref gr.shockwave, ref gr.storm, ref gr.heal, ref gr.lava, ref gr.name, ref label2, ref gr.bonus_bers, ref gr.indikator,
                            ref pl.health, ref smp.health, ref bb.health, ref pl.name, ref smp.name, ref bb.name, ref pl.shield, ref smp.shield, ref bb.shield, ref pl.berserk, ref smp.berserk, ref bb.berserk, ref pl.gun,
                            ref smp.gun, ref bb.gun, ref pl.meteor, ref smp.meteor, ref bb.meteor, ref pl.shockwave, ref smp.shockwave, ref bb.shockwave, ref pl.storm, ref smp.storm, ref bb.storm, ref pl.heal, ref smp.heal,
                            ref bb.heal, ref pl.lava, ref smp.lava, ref bb.lava, ref pl.indikator, ref smp.indikator, ref bb.indikator, ref gr.pBar, ref pl.pBar, ref smp.pBar, ref bb.pBar, ref pl.position, ref smp.position,
                            ref bb.position, ref pl.icon, ref smp.icon, ref bb.icon, ref gr.shd, ref pl.labe, ref smp.labe, ref bb.labe, ref gr.position, ref gr.icon);
                        if (smp.health > 0)
                            timer_9scht++;
                        else if (bb.health > 0)
                            timer_9scht += 2;
                        else
                            timer_9scht += 3;
                    break;
                case 2:
                    if (smp.health > 0)
                        Stopper();
                        battle(ref smp.health, ref smp.shield, ref smp.berserk, ref smp.gun, ref smp.meteor, ref smp.shockwave, ref smp.storm, ref smp.heal, ref smp.lava, ref smp.name, ref label3, ref smp.bonus_bers,
                           ref smp.indikator, ref pl.health, ref gr.health, ref bb.health, ref pl.name, ref gr.name, ref bb.name, ref pl.shield, ref gr.shield, ref bb.shield, ref pl.berserk, ref gr.berserk, ref bb.berserk,
                           ref pl.gun, ref gr.gun, ref bb.gun, ref pl.meteor, ref gr.meteor, ref bb.meteor, ref pl.shockwave, ref gr.shockwave, ref bb.shockwave, ref pl.storm, ref gr.storm, ref bb.storm, ref pl.heal,
                           ref gr.heal, ref bb.heal, ref pl.lava, ref gr.lava, ref bb.lava, ref pl.indikator, ref gr.indikator, ref bb.indikator, ref smp.pBar, ref pl.pBar, ref gr.pBar, ref bb.pBar, ref pl.position,
                           ref gr.position, ref bb.position, ref pl.icon, ref gr.icon, ref bb.icon, ref smp.shd, ref pl.labe, ref gr.labe, ref bb.labe, ref smp.position, ref smp.icon);
                        if (bb.health > 0)
                            timer_9scht ++;
                        else
                            timer_9scht += 2;
                    break;
                case 3:
                    if (bb.health > 0)
                        Stopper();
                        battle(ref bb.health, ref bb.shield, ref bb.berserk, ref bb.gun, ref bb.meteor, ref bb.shockwave, ref bb.storm, ref bb.heal, ref bb.lava, ref bb.name, ref label4, ref bb.bonus_bers, ref bb.indikator,
                            ref pl.health, ref gr.health, ref smp.health, ref pl.name, ref gr.name, ref smp.name, ref pl.shield, ref gr.shield, ref smp.shield, ref pl.berserk, ref gr.berserk, ref smp.berserk,
                           ref pl.gun, ref gr.gun, ref smp.gun, ref pl.meteor, ref gr.meteor, ref smp.meteor, ref pl.shockwave, ref gr.shockwave, ref smp.shockwave, ref pl.storm, ref gr.storm, ref smp.storm, ref pl.heal,
                           ref gr.heal, ref smp.heal, ref pl.lava, ref gr.lava, ref smp.lava, ref pl.indikator, ref gr.indikator, ref smp.indikator, ref bb.pBar, ref pl.pBar, ref gr.pBar, ref smp.pBar, ref pl.position,
                           ref gr.position, ref smp.position, ref pl.icon, ref gr.icon, ref smp.icon, ref bb.shd, ref pl.labe, ref gr.labe, ref smp.labe, ref bb.position, ref bb.icon);
                    timer_9scht++;
                    break;
                case 4:
                    timer9.Stop();
                    timer_9scht = 0;
                    sterka = false;
                    timer2.Start();
                    return;
            }
        }
    }
}
