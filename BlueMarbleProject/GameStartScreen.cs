using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueMarbleProject
{
    public partial class GameStartScreen : Form
    {

        public GameStartScreen()
        {
            InitializeComponent();
        }

        private void Exit_Btn_Click(object sender, EventArgs e) // 나가기 버튼 클릭 시 
        {
            if (MessageBox.Show("종료하시겠습니까?", "게임 종료", MessageBoxButtons.OKCancel) == DialogResult.OK) // OKCancel창이 뜨고
                this.Close(); // Cancel은 복구, OK는 종료
        }

        private void GameRule_Btn_Click(object sender, EventArgs e)
        {

        }
    }
}
