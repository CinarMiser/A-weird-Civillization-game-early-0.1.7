using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace a_weird_civilization
{
    public partial class Game : Form
    {
        //Çınar su takip sistemini düzelt bozuk hala
        //let me introduce you the ints and doubles what makes this game a game

        public double humans = 3;    //total human
        public int level = 1;        //civilization level
        public double years;         //game year
        public double stability = 70;       //civilization stability
        public double days = 0;             //game day
        public double weeks = 0;            //game weeks
        public double food = 1200;          //our tiny humans one of the most important needs
        public double water = 1550;         //our tiny humans one of the most important needs
        public double wood = 100;           //wood..just wood
        public int woodcutterwork = 1;      //if its 1 the lumberjack is not working but if its more than 1 its means lumberjack working
        public int workingperson = 0;       //total working person
        public int workingpersonlumber = 0;      //total working lumberjack 
        public int freeperson = 3;               //unemployed person counter
        public double woodincome = 30;           //wood income per human
        public double incomewood1;               //calculates wood income
        public double spears;                    //spear count
        public double incomefood1;               //calculates food income
        public double incomefood = 50;           //food income per human
        public int hunterwork = 1;               //if its 1 the hunter is not working but if its more than 1 its means hunter is working
        public int workinghunter;                //working hunter counter
        public int riverworker;                  //river worker count
        public int riverwork = 1;                //its controls river work
        public int waterincomeriver = 45;        //water income for level 1
        public double stabilityscout = 1;        //stability timer's scout
        public double randomeventnumber;         // random event number?
        public double kidspawnnumber;            //int for kid spawn
        public double woodenequipment;           //wooden equipment
        public double woodenpumpcount;           //wooden equipment count
        public double waterpumpincome = 55;      //water pump water income for level 1
        public double waterpumpincome1;          //waterpump work controller
        public double minerwork = 1;             //miner work controller
        public int workingminer;              //miner count
        public double stone;                  //stone count
        public double mineincome = 10;        //mine income for level 1
        public double mineincomecalc;         //mine income calculator
        public double homeless;               //homeless count
        public double home;                   //home count
        public double peoplehashomes;         //people who has a home
        public double openhomecount = 0;      //open home count
        public double openhomecountcalc;      //open home count calculator
        public double home1number = 5;        //number of open rooms for home level 1
        public int isreasopen = 1;



        public Game()
        {
            InitializeComponent();
        }


        //this code goes first

        private void Game_Load(object sender, EventArgs e)
        {
            foodcount.Text = food.ToString();
            watercount.Text = water.ToString();
            humancount.Text = humans.ToString();
            levelcount.Text = level.ToString();
            passedyear.Text = years.ToString();
            stabilitycount.Text = stability.ToString();
            homelesscounter.Text = homeless.ToString();
            GameTime.Start();
            stabilitytime.Start();
            homeless = freeperson;
            workingpersoncount.Text = workingperson.ToString();
            freepersoncounter.Text = freeperson.ToString();
            WoodCount.Text = wood.ToString();
            MessageBox.Show("The adventure just started!! Now you should keep your humans safe and make them not to starve");
            MessageBox.Show("if you want there is a tutorial button in the lower left corner good luck ;)");
        }


        //game time 

        private void GameTime_Tick(object sender, EventArgs e)
        {
            days++;
            workingperson = workingpersonlumber + workinghunter + riverworker + workingminer;
            humans = freeperson + workingperson;
            humancount.Text = humans.ToString();
            homelesscounter.Text = homeless.ToString();
            workingpersoncount.Text = workingperson.ToString();
            freepersoncounter.Text = freeperson.ToString();
            //day counter(makes days to weeks)
            if (days == 10)
            {
                weeks++;
                days = 0;
            }
            //week counter(makes weeks to years yeah in this game there is no months)
            if(weeks == 20)
            {
                years++;
                passedyear.Text = years.ToString();
                weeks = 0;
            }
            //humans important needs reduce counter
            if(days == 3 || days == 6)
            {
                food -= humans * 22;
                water -= humans * 25;
                foodcount.Text = food.ToString();
                watercount.Text = water.ToString();
            }
            //water quantity tracker
            if(water > -120)
            {
                if (water < 50)
                {
                    watertrack1.BackColor = Color.Maroon;
                    watertrack2.BackColor = Color.Maroon;
                    watertrack3.BackColor = Color.Maroon;
                }
                else if (water > 50 && water <= 400)
                {
                    watertrack1.BackColor = Color.DarkBlue;
                    watertrack2.BackColor = Color.Maroon;
                    watertrack3.BackColor = Color.Maroon;
                }
                else if (water > 400 && water <= 1100)
                {
                    watertrack1.BackColor = Color.DarkBlue;
                    watertrack2.BackColor = Color.DarkBlue;
                    watertrack3.BackColor = Color.Maroon;
                }
                else if (water > 1100)
                {
                    watertrack1.BackColor = Color.DarkBlue;
                    watertrack2.BackColor = Color.DarkBlue;
                    watertrack3.BackColor = Color.DarkBlue;
                }
            }
            //wood cutter income calculator
            if(woodcutterwork >= 1)
            {
                if(days == 2 || days == 4 || days == 6 || days == 8)
                {
                    incomewood1 = workingpersonlumber * woodincome;
                    wood += incomewood1;
                    WoodCount.Text = wood.ToString();
                    income1.Text = incomewood1.ToString();
                    food -= 50;
                    water -= 70;
                    foodcount.Text = food.ToString();
                    watercount.Text = water.ToString();
                    lumberjackpeople.Text = workingpersonlumber.ToString();
                }
            }
            //game endings
            if(food < -160)
            {
                GameTime.Stop();
                MessageBox.Show("Game Over your civilization starved to death try again");
                Close();
            }
            if(water < -120)
            {
                GameTime.Stop();
                MessageBox.Show("Game Over your civilization died of thirst try again");
                Close();
            }

            //hunter work
            if(hunterwork > 1)
            {
                spearusage();
                hunterpeople.Text = workinghunter.ToString();
            }

            //river work
            if(riverwork > 1)
            {
                water += waterincomeriver;
                food -= 5;
                foodcount.Text = food.ToString();
                watercount.Text = water.ToString();
            }

            //civillization grown code
            if(weeks > 4 || food > 800 || weeks < 17)
            {
                Random kidspawn = new Random();
                kidspawnnumber = kidspawn.Next(0, 180);
                if(kidspawnnumber == 5 || kidspawnnumber == 12 || kidspawnnumber == 27 || kidspawnnumber == 69)
                {
                    if(openhomecount > 0)
                    {
                        freeperson++;
                        food -= 200;
                        foodcount.Text = food.ToString();
                        freepersoncounter.Text = freeperson.ToString();
                        peoplehashomes++;
                        homepeoplecount.Text = peoplehashomes.ToString();
                        openhomecount--;
                        MessageBox.Show("A new baby has born our civillization is growing");
                    }
                    else if(openhomecount == 0)
                    {
                        freeperson++;
                        food -= 200;
                        foodcount.Text = food.ToString();
                        freepersoncounter.Text = freeperson.ToString();
                        homeless++;
                        homelesscounter.Text = homeless.ToString();
                        MessageBox.Show("A new baby has born our civillization is growing");
                    }
                }
            }

            if(woodenpumpcount > 0)
            {
                waterpumpincome1 = woodenpumpcount * waterpumpincome;
                water += waterpumpincome1;
                watercount.Text = water.ToString();
            }

            if(minerwork > 1)
            {
                minerincomef1();
                income3.Text = mineincomecalc.ToString();
            }
        }


        //this button opens the stats panel
        private void button1_Click(object sender, EventArgs e)
        {
            statspanel.Visible = true;
            statsvisiblefals.Visible = true;
            button1.Visible = false;
        }


        //this button close the stats panel
        private void statsvisiblefals_Click(object sender, EventArgs e)
        {
            statspanel.Visible = false;
            statsvisiblefals.Visible = false;
            button1.Visible = true;
        }

        //this button opens the work panel
        private void button3_Click(object sender, EventArgs e)
        {
            workspanel.Visible = true;
            worksvisiblefals.Visible = true;
            button3.Visible = false;
        }

        //this button close the work panel
        private void worksvisiblefals_Click(object sender, EventArgs e)
        {
            workspanel.Visible = false;
            worksvisiblefals.Visible = false;
            button3.Visible = true;
        }


        //wood cutters recruitment button
        private void work1_Click(object sender, EventArgs e)
        {
            if(freeperson > 0)
            {
                workingpersonlumber++;
                freeperson--;
                woodcutterwork++;
                workingpersoncount.Text = workingperson.ToString();
                freepersoncounter.Text = freeperson.ToString();
            }
            else if(freeperson == 0)
            {
                MessageBox.Show("There is no unemployed person to work in this facility");
            }
        }

        //wood cutters layoff button
        private void reducehuman1_Click(object sender, EventArgs e)
        {
            if (workingpersonlumber >= 1)
            {
                workingpersonlumber--;
                freeperson++;
                woodcutterwork--;
                workingpersoncount.Text = workingperson.ToString();
                freepersoncounter.Text = freeperson.ToString();
            }
            if (workingpersonlumber == 0)
            {
                MessageBox.Show("There is nobody working here?");
            }
        }

        //hunters recruitment button
        private void Work2_Click(object sender, EventArgs e)
        {
            if(spears == 0)
            {
                MessageBox.Show("You cant hunt without a spear");
            }
            else if(spears > 0 && freeperson > 0)
            {
                hunterwork++;
                workinghunter++;
                freeperson--;
                freepersoncounter.Text = freeperson.ToString();
            }
            else if(freeperson == 0)
            {
                MessageBox.Show("There is no unemployed person to work in this facility");
            }
        }

        //this button opens the crafting panel
        private void eyopenpanel_Click(object sender, EventArgs e)
        {
            craftingpanel.Visible = true;
            eyclosepanel.Visible = true;
            eyopenpanel.Visible = false;
        }

        //this buton closes the crafting panel
        private void eyclosepanel_Click(object sender, EventArgs e)
        {
            craftingpanel.Visible = false;
            eyclosepanel.Visible = false;
            eyopenpanel.Visible = true;
        }

        //spear crafting button
        private void craft1_Click(object sender, EventArgs e)
        {
            if(wood >= 25)
            {
                spears += 30;
                wood -= 25;
                WoodCount.Text = wood.ToString();
                spearcount.Text = spears.ToString();
            }
            if (wood < 25)
            {
                MessageBox.Show("You dont have enough wood ");
            }
        }

        //food income calculator
        public void spearusage()
        {
            if(days % 1 == 0 && spears > 0)
            {
                spears--;
                spearcount.Text = spears.ToString();
                incomefood1 = workinghunter * incomefood;
                food += incomefood1;
                foodcount.Text = food.ToString();
                income2.Text = incomefood1.ToString();
            }
            if(spears == 0)
            {
                MessageBox.Show("You dont have any spear");
                freeperson += workinghunter;
                workinghunter = 0;
                hunterwork = 1;
                freepersoncounter.Text = freeperson.ToString();
            }
        }

        private void reducehuman2_Click(object sender, EventArgs e)
        {
            if (workinghunter >= 1)
            {
                workinghunter--;
                freeperson++;
                hunterwork--;
                workingpersoncount.Text = workingperson.ToString();
                freepersoncounter.Text = freeperson.ToString();
                hunterpeople.Text = workinghunter.ToString();
                income2.Text = incomefood1.ToString();
            }
            if (workinghunter == 0)
            {

                MessageBox.Show("There is nobody working here?");
            }
        }

        private void waterpanelon_Click(object sender, EventArgs e)
        {
            waterpanel.Visible = true;
            waterpanelclose.Visible = true;
            waterpanelon.Visible = false;
        }

        private void waterpanelclose_Click(object sender, EventArgs e)
        {
            waterpanel.Visible = false;
            waterpanelclose.Visible = false;
            waterpanelon.Visible = true;
        }


        //river water dam worker button
        private void button2_Click(object sender, EventArgs e)
        {
            if(freeperson > 0 && wood >= 50 && riverworker < 1)
            {
                riverworker++;
                riverwork++;
                wood -= 50;
                freeperson--;
                WoodCount.Text = wood.ToString();
                riverworkertracker.Text = riverworker.ToString();
                freepersoncounter.Text = freeperson.ToString();
            }
            if(freeperson == 0)
            {
                MessageBox.Show("There is no unemployed person to work in this facility");
            }
            if(wood < 50)
            {
                MessageBox.Show("You dont 50 wood for build this dam");
            }
            if(riverworker == 1)
            {
                MessageBox.Show("You cant hire anymore human to this facility");
            }
        }


        //river water dam worker reduce button
        private void button5_Click(object sender, EventArgs e)
        {
            riverworker--;
            riverwork--;
            wood -= 50;
            freeperson++;
            riverworkertracker.Text = riverworker.ToString();
            freepersoncounter.Text = freeperson.ToString();
        }

        private void stabilitytime_Tick(object sender, EventArgs e)
        {
            stabilityscout++;
            if(stabilityscout == 70)
            {
                stabilityscout = 1;
                if (food <= 1000 && food > 500)
                {
                    stability -= 5;
                    stabilitycount.Text = stability.ToString();
                }
                if (food <= 500)
                {
                    stability -= 20;
                    stabilitycount.Text = stability.ToString();
                }
            }

            //random events for 1 level civillization
            if(level == 1)
            {
                if (stabilityscout % 1 == 0)
                {
                    Random randomevents1 = new Random();
                    randomeventnumber = randomevents1.Next(0, 140);
                    if (randomeventnumber == 2 || randomeventnumber == 5)
                    {
                        MessageBox.Show("One of your people get sick you spend 100 food for make him feel better");
                        food -= 100;
                        foodcount.Text = food.ToString();
                    }
                    if (randomeventnumber == 1 || randomeventnumber == 7)
                    {
                        MessageBox.Show("One of your people get sick you spend 100 food for make her feel better");
                        food -= 100;
                        foodcount.Text = food.ToString();
                    }
                    if (randomeventnumber == 12)
                    {
                        MessageBox.Show("You found 200 wood in forest yay");
                        wood += 200;
                        WoodCount.Text = wood.ToString();
                    }
                    if(randomeventnumber == 4 || randomeventnumber == 47)
                    {
                        MessageBox.Show("One of your people find 10 spear on floor");
                        spears += 10;
                        spearcount.Text = spears.ToString();
                    }
                }
            }
        }

        private void craft2_Click(object sender, EventArgs e)
        {
            if (wood >= 60)
            {
                wood -= 60;
                WoodCount.Text = wood.ToString();
                woodenequipment += 5;
                woodeneqcount.Text = woodenequipment.ToString();
            }
            else if(wood < 60)
            {
                MessageBox.Show("You dont have enough wood ");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(woodenequipment >= 40 && woodenpumpcount < 6)
            {
                woodenpumpcount++;
                woodenequipment -= 40;
                woodeneqcount.Text = woodenequipment.ToString();
                pumpcount.Text = woodenpumpcount.ToString();
            }
            else if(woodenequipment < 40)
            {
                MessageBox.Show("You dont have enough equipment");
            }
            else if(woodenpumpcount == 5)
            {
                MessageBox.Show("You cant build more river side pump");
            }
        }


        //miner hire button
        private void button6_Click(object sender, EventArgs e)
        {
            if(freeperson > 0)
            {
                minerwork++;
                workingminer++;
                freeperson--;
                Minerpeople.Text = workingminer.ToString();
                freepersoncounter.Text = freeperson.ToString();
            }
        }


        //stone income
        public void minerincomef1()
        {
            mineincomecalc = workingminer * mineincome;
            stone += mineincomecalc;
            StoneCount.Text = stone.ToString();
        }


        //miner reduce button
        private void button7_Click(object sender, EventArgs e)
        {
            if(workingminer > 0)
            {
                workingminer--;
                freeperson++;
                Minerpeople.Text = workingminer.ToString();
                freepersoncounter.Text = freeperson.ToString();
                mineincomecalc = workingminer * mineincome;
                income3.Text = mineincomecalc.ToString();
            }
        }


        //home panel open button
        private void shelterpanelopen_Click(object sender, EventArgs e)
        {
            ShelterPanel.Visible = true;
            shelterpanelclose.Visible = true;
            shelterpanelopen.Visible = false;
        }


        //home panel close button
        private void shelterpanelclose_Click(object sender, EventArgs e)
        {
            ShelterPanel.Visible = false;
            shelterpanelclose.Visible = false;
            shelterpanelopen.Visible = true;
        }


        //home panel button 1
        private void button8_Click(object sender, EventArgs e)
        {
            if(wood >= 100 && stone >= 50)
            {
                home++;
                Homecount.Text = home.ToString();
                wood -= 100;
                stone -= 50;
                WoodCount.Text = wood.ToString();
                StoneCount.Text = stone.ToString();
                if(homeless >= 5)
                {
                    homeless -= 5;
                    homelesscounter.Text = homeless.ToString();
                    peoplehashomes += home1number;
                    homepeoplecount.Text = peoplehashomes.ToString();
                }
                else if(homeless < 5)
                {
                    openhomecountcalc = home1number - homeless;
                    openhomecount = openhomecountcalc;
                    peoplehashomes += homeless;
                    homeless -= homeless;
                    homelesscounter.Text = homeless.ToString();
                    openhomecountcalc = 0;
                    homepeoplecount.Text = peoplehashomes.ToString();
                }
            }
        }

        private void research_Click(object sender, EventArgs e)
        {
            if(isreasopen > 1)
            {
                researchpanel.Visible = true;
                isreasopen--;
            }
            else if(isreasopen == 1)
            {
                researchpanel.Visible = false;
                isreasopen++;
            }
        }
    }
}
