using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace PoligonsDB.FORMULARIS
{
    public partial class FrmAdd : Form
    {
        public FrmAdd()
        {
            InitializeComponent();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            Random r = new Random();

            if (tbNom.Text.Trim().Length == 0)
            {
                MessageBox.Show("Cal introduir el nom", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if (chkSi.Checked == true || chkNo.Checked == true)
            {
                MessageBox.Show("Cal introduir si es vol color de fons o no ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                //switch (grup)
                //{
                //    case "Balrogs":
                //        ClBalrog bal = new ClBalrog(bd, tbNom.Text, strength, intelligence, grup, R.Next(0, 101), 1, R.Next(0, 51), R.Next(0, 101));
                //        break;
                //    case "Elfs":
                //        ClElf elf = new ClElf(bd, tbNom.Text, strength, intelligence, grup, R.Next(1200, 10000), 1, R.Next(1000, 100000) / 100, llColorsCabell[R.Next(0, llColorsCabell.Count)], R.Next(0, 101));
                //        break;
                //    case "Hobbits":
                //        ClHobbit hob = new ClHobbit(bd, tbNom.Text, strength, intelligence, grup, R.Next(90, 121), R.Next(20, 101), 1, "La Comarca", R.Next(0, 101));
                //        break;
                //    case "Humans":
                //        ClHuma hum = new ClHuma(bd, tbNom.Text, strength, intelligence, grup, R.Next(90, 121), llCaracterístiques[R.Next(0, llCaracterístiques.Count)], 1, R.Next(0, 101), llTerresHumans[R.Next(0, llTerresHumans.Count)]);
                //        break;
                //    case "Mags":
                //        ClMag mag = new ClMag(bd, tbNom.Text, strength, intelligence, grup, R.Next(0, 101), R.Next(1500, 5001), 1, llColorsCapa[R.Next(0, llColorsCapa.Count)], R.Next(0, 101));
                //        break;
                //    case "Nans":
                //        ClNan nan = new ClNan(bd, tbNom.Text, strength, intelligence, grup, R.Next(100, 501), R.Next(0, 101), 1, llClansNans[R.Next(0, llClansNans.Count)]);
                //        break;
                //    case "Nazguls":
                //        ClNazgul naz = new ClNazgul(bd, tbNom.Text, strength, intelligence, grup, R.Next(0, 101), R.Next(0, 2), R.Next(0, 101), llMunturaNazguls[R.Next(0, llMunturaNazguls.Count)], R.Next(0, 101));
                //        break;
                //    case "Orcs":
                //        ClOrc orc = new ClOrc(bd, tbNom.Text, strength, intelligence, grup, R.Next(0, 2), R.Next(0, 101), llColorsPellOrcs[R.Next(0, llColorsPellOrcs.Count)], R.Next(0, 101));
                //        break;
                //    case "Trolls":
                //        ClTroll tro = new ClTroll(bd, tbNom.Text, strength, intelligence, grup, R.Next(1, 4), 1, llPellsTrolls[R.Next(0, llPellsTrolls.Count)]);
                //        break;
                //    case "Uruk Hais":
                //        ClUrukHai uru = new ClUrukHai(bd, tbNom.Text, strength, intelligence, grup.Replace(" ", ""), 1, R.Next(0, 101), llArmesUrukHai[R.Next(0, llArmesUrukHai.Count)], R.Next(190, 261));
                //        break;
                //}
            }

        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
