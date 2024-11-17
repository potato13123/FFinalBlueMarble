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
    public partial class GameRuleScreen : Form
    {
        public GameRuleScreen()
        {
            InitializeComponent();
        }

        private void GameRuleScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
                Application.Exit(); // 강제 종료될 때 hide된 된 폼 제거
        }
        private void RuleBack_Btn_Click(object sender, EventArgs e) // 다시 초기 화면으로 돌아가는 버튼
        {
            GameStartScreen GSS_Form = new GameStartScreen(); // 초기 게임화면 객체 생성

            GSS_Form.Show(); // 초기 화면 보여주기
            this.Hide(); // 룰 화면은 숨기기
        }
    }
}
