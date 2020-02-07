using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vending_Machine.Model;

namespace Vending_Machine
{
    public partial class Form1 : Form
    {

        List<Item> items { get; set; } = new List<Item>();
        bool isSelected = false;
        bool isPaid = false;
        bool isSuccess = false;
        bool isWater = false;

        double _amount = 0;
       
        
        SoundPlayer rainSound = new SoundPlayer(Properties.Resources.rainy);
        SoundPlayer drinkingSound = new SoundPlayer(Properties.Resources.drinkingWater);
        SoundPlayer droppedSound = new SoundPlayer(Properties.Resources.droppedCoin);


        public Form1()
        {
            InitializeComponent();

        }

        private void Money_Click(object sender, EventArgs e)
        {
            if (!isSelected)
            {
                var unit = sender as PictureBox;
               
                switch (unit.Name)
                {

                    case "tenc":
                        {
                            coinentering.Image = Properties.Resources._10cent;
                            coinentering.Visible = true;
                            cointimer.Enabled = true;
                            cointimer.Tick += Cointimer_Tick;
                            _amount += 0.10;
                            _money.Text = _amount.ToString();
                            droppedSound.Play();
                            Thread.Sleep(3000);
                            break;
                        }
                    case "twentyc":
                        {
                            coinentering.Image = Properties.Resources._20cent;
                            coinentering.Visible = true;
                            cointimer.Enabled = true;
                            cointimer.Tick += Cointimer_Tick;
                            _amount += 0.20;
                            _money.Text = _amount.ToString();
                            droppedSound.Play();
                            Thread.Sleep(3000);
                            break;
                        }
                    case "fiftyc":
                        {
                            coinentering.Image = Properties.Resources._50cent;
                            coinentering.Visible = true;
                            cointimer.Enabled = true;
                            cointimer.Tick += Cointimer_Tick;
                            _amount += 0.50;
                            _money.Text = _amount.ToString();
                            droppedSound.Play();
                            Thread.Sleep(3000);
                            break;
                        }
                    case "one":
                        {
                            enterance.Image = Properties.Resources._1dv;
                            enterance.Visible = true;
                            _money.Text = "1.0";

                            timer.Enabled = true;
                            timer.Tick += Timer_Tick;
                            _amount += 1.0;
                            _money.Text = _amount.ToString();
                            break;
                        }
                    case "five":
                        {
                            enterance.Image = Properties.Resources._5dv;
                            enterance.Visible = true;
                            _money.Text = "5.0";

                            timer.Enabled = true;
                            timer.Tick += Timer_Tick;
                            _amount += 5.0;
                            _money.Text = _amount.ToString();
                            break;
                        }
                    case "ten":
                        {
                            enterance.Image = Properties.Resources._10dv;
                            enterance.Visible = true;
                            _money.Text = "10.0";

                            timer.Enabled = true;
                            timer.Tick += Timer_Tick;

                            _amount += 10.0;
                            _money.Text = _amount.ToString();
                            break;
                        }
                }
                isPaid = true;
            }
            
            rainSound.Play();
        }

        private void Cointimer_Tick(object sender, EventArgs e)
        {
            if (coinentering.Top > 295)
            {
                coinentering.Top -= 5;
            }
            else
            {
                coinentering.Top = 308;
                coinentering.Visible = false;
                cointimer.Enabled = false;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (enterance.Top > 219)
            {
                enterance.Top -= 5;
            }
            else
            {
                enterance.Top = 261;
                enterance.Visible = false;
                timer.Enabled = false;
            }
        }

        private void Item_Click(object sender, EventArgs e)
        {
            var item = sender as PictureBox;

            dropeditem.Visible = true;


            if (isPaid)
            {

                if (!isSelected)
                {
                    switch (item.Name)
                    {
                        case "cola":
                            {
                                if (_amount >= items[0].Price)
                                {
                                    items[0].Count--;
                                    dropeditem.Image = Properties.Resources.cola;
                                    isSuccess = true;
                                    isSelected = true;


                                    if (_amount != items[0].Price)
                                    {
                                        amountmoney.Text = (_amount - items[0].Price).ToString();
                                    }
                                    dropitemtimer.Enabled = true;
                                    dropitemtimer.Tick += Dropitemtimer_Tick;
                                   




                                }
                                else
                                {
                                    isSuccess = false;
                                }
                                isWater = true;
                                break;
                            }
                        case "pepsi":
                            {
                                if (_amount >= items[1].Price)
                                {
                                    items[1].Count--;
                                    dropeditem.Image = Properties.Resources.pepsi;
                                    isSuccess = true;
                                    isSelected = true;
                                    if (_amount != items[1].Price)
                                    {
                                        amountmoney.Text = (_amount - items[1].Price).ToString();
                                    }
                                    dropitemtimer.Enabled = true;
                                    dropitemtimer.Tick += Dropitemtimer_Tick;
                                }
                                else
                                {
                                    isSuccess = false;
                                }
                                isWater = true;
                                break;
                            }
                        case "sevenup":
                            {
                                if (_amount >= items[2].Price)
                                {
                                    items[2].Count--;
                                    dropeditem.Image = Properties.Resources.sevenup;
                                    isSuccess = true;
                                    isSelected = true;
                                    if (_amount != items[2].Price)
                                    {
                                        amountmoney.Text = (_amount - items[2].Price).ToString();
                                    }
                                    dropitemtimer.Enabled = true;
                                    dropitemtimer.Tick += Dropitemtimer_Tick;
                                }
                                else
                                {
                                    isSuccess = false;
                                }
                                isWater = true;
                                break;
                            }
                        case "nescafe":
                            {
                                if (_amount >= items[3].Price)
                                {
                                    items[3].Count--;
                                    dropeditem.Image = Properties.Resources.necafe;
                                    isSuccess = true;
                                    isSelected = true;
                                    if (_amount != items[3].Price)
                                    {
                                        amountmoney.Text = (_amount - items[3].Price).ToString();
                                    }
                                    dropitemtimer.Enabled = true;
                                    dropitemtimer.Tick += Dropitemtimer_Tick;
                                }
                                else
                                {
                                    isSuccess = false;
                                }
                                isWater = true;
                                break;
                            }
                        case "lipton":
                            {
                                if (_amount >= items[4].Price)
                                {
                                    items[4].Count--;
                                    dropeditem.Image = Properties.Resources.lipton;
                                    isSuccess = true;
                                    isSelected = true;
                                    if (_amount != items[4].Price)
                                    {
                                        amountmoney.Text = (_amount - items[4].Price).ToString();
                                    }
                                    dropitemtimer.Enabled = true;
                                    dropitemtimer.Tick += Dropitemtimer_Tick;
                                }
                                else
                                {
                                    isSuccess = false;
                                }
                                isWater = true;
                                break;
                            }
                        case "snickers":
                            {
                                if (_amount >= items[5].Price)
                                {
                                    items[5].Count--;
                                    dropeditem.Image = Properties.Resources.snickers;
                                    isSuccess = true;
                                    isSelected = true;
                                    if (_amount != items[5].Price)
                                    {
                                        amountmoney.Text = (_amount - items[5].Price).ToString();
                                    }
                                    dropitemtimer.Enabled = true;
                                    dropitemtimer.Tick += Dropitemtimer_Tick;
                                }
                                else
                                {
                                    isSuccess = false;
                                }


                                break;

                            }
                        case "mandms":
                            {
                                if (_amount >= items[6].Price)
                                {
                                    items[6].Count--;
                                    dropeditem.Image = Properties.Resources.mandms;
                                    isSuccess = true;
                                    isSelected = true;
                                    if (_amount != items[6].Price)
                                    {
                                        amountmoney.Text = (_amount - items[6].Price).ToString();
                                    }
                                    dropitemtimer.Enabled = true;
                                    dropitemtimer.Tick += Dropitemtimer_Tick;
                                }
                                else
                                {
                                    isSuccess = false;
                                }


                                break;
                            }
                        case "fanta":
                            {
                                if (_amount >= items[7].Price)
                                {
                                    items[7].Count--;
                                    dropeditem.Image = Properties.Resources.fanta1;
                                    isSuccess = true;
                                    isSelected = true;
                                    if (_amount != items[7].Price)
                                    {
                                        amountmoney.Text = (_amount - items[7].Price).ToString();
                                    }
                                    dropitemtimer.Enabled = true;
                                    dropitemtimer.Tick += Dropitemtimer_Tick;
                                }
                                else
                                {
                                    isSuccess = false;
                                }
                                isWater = true;
                                break;
                            }
                        case "mountaindew":
                            {
                                if (_amount >= items[8].Price)
                                {
                                    items[8].Count--;
                                    dropeditem.Image = Properties.Resources.mountaindew;
                                    isSuccess = true;
                                    isSelected = true;
                                    if (_amount != items[8].Price)
                                    {
                                        amountmoney.Text = (_amount - items[8].Price).ToString();
                                    }
                                    dropitemtimer.Enabled = true;
                                    dropitemtimer.Tick += Dropitemtimer_Tick;
                                }
                                else
                                {
                                    isSuccess = false;
                                }
                                isWater = true;
                                break;
                            }
                        case "redbull":
                            {
                                if (_amount >= items[9].Price)
                                {
                                    items[9].Count--;
                                    dropeditem.Image = Properties.Resources.redbul;
                                    isSuccess = true;
                                    isSelected = true;
                                    if (_amount != items[9].Price)
                                    {
                                        amountmoney.Text = (_amount - items[9].Price).ToString();
                                    }

                                    dropitemtimer.Enabled = true;
                                    dropitemtimer.Tick += Dropitemtimer_Tick;
                                }
                                else
                                {
                                    isSuccess = false;
                                }
                                isWater = true;
                                break;
                            }
                    }
                    var json = JsonConvert.SerializeObject(items);
                    File.WriteAllText("items.json", json);
                }

            }

            InitializeDetail();

        }


        private void Dropitemtimer_Tick(object sender, EventArgs e)
        {
            if (dropeditem.Top < 360)
            {
                dropeditem.Top += 5;
            }
            else
            {
                dropitemtimer.Enabled = false;
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            Blender.BlendPictures(this.background, this.vendingmachine);
            Blender.BlendPictures(this.background, this.wallet);

            // this.Cursor = Properties.Resources.hand;
            var url = Properties.Resources.hand;
            //Cursor.Current = new Cursor(url.ToString());
            //this.Cursor = new Cursor(;
            try
            {
                rainSound = new SoundPlayer(Properties.Resources.rainy);

                rainSound.Play();
            }
            catch (Exception)
            {
               
            } 

            var str = File.ReadAllText("items.json");
            items = JsonConvert.DeserializeObject<List<Item>>(str); 

            InitializeDetail();

        }

        private void InitializeDetail()
        {
            colaprice.Text = items[0].Price.ToString();
            colacount.Text = items[0].Count.ToString();

            pepsiprice.Text = items[1].Price.ToString();
            pepsicount.Text = items[1].Count.ToString();

            sevenupprice.Text = items[2].Price.ToString();
            sevenupcount.Text = items[2].Count.ToString();

            nescafeprice.Text = items[3].Price.ToString();
            nescafecount.Text = items[3].Count.ToString();

            liptonprice.Text = items[4].Price.ToString();
            liptoncount.Text = items[4].Count.ToString();

            snickersprice.Text = items[5].Price.ToString();
            snickerscount.Text = items[5].Count.ToString();

            mandmsprice.Text = items[6].Price.ToString();
            mandmscount.Text = items[6].Count.ToString();

            fantaprice.Text = items[7].Price.ToString();
            fantacount.Text = items[7].Count.ToString();

            mountaindewprice.Text = items[8].Price.ToString();
            mountaindewcount.Text = items[8].Count.ToString();

            redbullprice.Text = items[9].Price.ToString();
            redbullcouunt.Text = items[9].Count.ToString();
        }
        private void dropeditem_Click_1(object sender, EventArgs e)
        { 

            if (isWater)
            {

                drinkingSound.Play();
                Thread.Sleep(8000);
            }
            _amount = 0;
            _money.Text = "0";
            amountmoney.Text = "0";
            dropeditem.Top = 334;
            isSelected = false;
            isPaid = false;
            isWater = false;
            rainSound.Play();
        }  
    }
}
