using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TenTimesOne
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button_StartTesting_Click(object sender, EventArgs e)
        {
            TestsResultsRepository.OneTime10Results.Clear();
            TestsResultsRepository.TenTimes1Results.Clear();

            StartTestingAndSaveToRepo();

            ShowResultsOnListBoxes();

            SumResultsFromTestsAndShowThemOnLabels();

            
        }

        private void SumResultsFromTestsAndShowThemOnLabels()
        {
            int OneTime10Total = 0;

            int TenTimes1Total = 0;

            foreach (var item in TestsResultsRepository.OneTime10Results)
            {
                OneTime10Total += item;
            }

            foreach (var item in TestsResultsRepository.TenTimes1Results)
            {
                TenTimes1Total += item;
            }

            label_1Time10Total.Text = OneTime10Total.ToString();
            label_10Times1Total.Text = TenTimes1Total.ToString();
        }

        private void ShowResultsOnListBoxes()
        {
            listBox_1Time10Results.Items.Clear();
            listBox_10Times1Results.Items.Clear();

            foreach (var item in TestsResultsRepository.OneTime10Results)
            {
                listBox_1Time10Results.Items.Add("La jugada ganó " + item + " vez/veces");
            }

            foreach (var item in TestsResultsRepository.TenTimes1Results)
            {
                listBox_10Times1Results.Items.Add("La jugada ganó " + item + " vez/veces");
            }
        }

        private void StartTestingAndSaveToRepo()
        {
            ChanceTester tester = new ChanceTester();

            for (int i = 0; i < int.Parse(textBox_TestQuantity.Text); i++)
            {
                bool result1 = tester.Test1Time10();
                if (result1 == true)
                {
                    TestsResultsRepository.OneTime10Results.Add(1);
                }
                else
                {
                    TestsResultsRepository.OneTime10Results.Add(0);
                }

                int result2 = tester.Test10Times1();
                TestsResultsRepository.TenTimes1Results.Add(result2);
            }
        }
    }
}
