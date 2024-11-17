using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueMarbleProject
{
    public struct AreaInfomation // 각 지역별 필요한 정보 모음
    {
        public string AreaName; // 지역의 이름
        public int[] BuildPrice; // 건물 가격
        public int[] TollPrice; // 통행료 가격
        public int[] SellPrice; // 처분 가격
        public int GiveToSocial; // 사회 복지 기부금 가격
        public int Owner; // 현재 땅의 주인이 누구인지?

        public AreaInfomation(string AreaName, int[] BuildPrice, int[] TollPrice, int[] SellPrice, int GiveToSocial, int Owner) // 정보값 가져오기
        {
            this.AreaName = AreaName;
            this.BuildPrice = BuildPrice;
            this.TollPrice = TollPrice;
            this.SellPrice = SellPrice;
            this.GiveToSocial = GiveToSocial;
            this.Owner = Owner;   
        }
    }

    public struct PlayerInfomation
    {
        public int Money; // 현재 보유 금액
        public int Location; // 플레이어 현재 위치
        public int EscapeIslandCnt; // 무인도를 나가기 위한 남은 턴의 숫자(0 ~ 3턴)
        public int AngelCard; // 천사카드(우대권) 개수
        public int EscapeIslandCard; // 무인도 탈출권 개수
        public int WorldTourCheck; // 세계여행중인지 아닌지 여부
        public List<int> AreaIndex; // 소유한 지역의 위치 인덱스
        public List<string> BuildName; // 소유한 지역 건물 이름
    }
    public partial class MainBoard : Form
    {
        private PictureBox[] Area = new PictureBox[35]; // 픽쳐박스로 만든 각 지역을 지칭하는 배열 선언, 35 = 총 36칸
        public static PictureBox[] Landmark = new PictureBox[0]; // 랜드마크 사진을 넣을
        private PictureBox[] P1 = new PictureBox[35]; // 1플레이어를 나타내는 픽쳐박스
        private PictureBox[] P2 = new PictureBox[35]; // 2플레이어를 나타내는 픽쳐박스
        private PictureBox[] P3 = new PictureBox[35]; // 3플레이어를 나타내는 픽쳐박스
        private PictureBox[] P4 = new PictureBox[35]; // 4플레이어를 나타내는 픽쳐박스

        public static AreaInfomation[] AreaInfo = new AreaInfomation[35]; // 각 지역 정보 가져오기

        public static PlayerInfomation[] PlayerInfo = new PlayerInfomation[5]; // 1-4P, 눈에 익기 쉽게 0 인덱스는 사용x, 팀 설정에 따라 바뀜

        public MainBoard(bool P2BtnClicked, bool P3BtnClicked, bool P4BtnClicked, bool Team_BtnClicked, bool Solo_BtnClicked)
        {
            InitializeComponent();
            GameSetting(P2BtnClicked, P3BtnClicked, P4BtnClicked, Team_BtnClicked, Solo_BtnClicked);
        }

        private void MainBoard_FormClosing(object sender, FormClosingEventArgs e) // hide
        {
            Application.Exit();
        }
        public void GameSetting(bool P2BtnClicked, bool P3BtnClicked, bool P4BtnClicked, bool Team_BtnClicked, bool Solo_BtnClicked) // 게임 세팅
        {

            Area = new PictureBox[] // 지역 초기화
            {
                Area1,Area2,Area3,Area4,Area5,Area6,Area7,Area8,Area9,Area10,
                Area11,Area12,Area13,Area14,Area15,Area16,Area17,Area18,Area19,Area20,
                Area21,Area22,Area23,Area24,Area25,Area26,Area27,Area28,Area29,Area30,
                Area31,Area32,Area33,Area34,Area35,Area36
            };

            PlayerInfo[1].Money = 5000000; // 1 플레이어의 초기 자금 설정
            PlayerInfo[1].AreaIndex = new List<int>(); // 1 플레이어의 위치값
            PlayerInfo[1].BuildName = new List<string>(); // 1플레이어의 소유 건물

            PlayerInfo[2].Money = 0; // 2 플레이어의 초기 자금 설정
            PlayerInfo[2].AreaIndex = new List<int>(); // 2 플레이어의 위치값
            PlayerInfo[2].BuildName = new List<string>(); // 2플레이어의 소유 건물
            if (P3BtnClicked || P4BtnClicked) // 만약 3이나 4인으로 체크했다면
            {
                PlayerInfo[3].Money = 0; // 3 플레이어의 초기 자금 설정
                PlayerInfo[3].AreaIndex = new List<int>(); // 3 플레이어의 위치값
                PlayerInfo[3].BuildName = new List<string>(); // 3 플레이어의 소유 건물
            }
            if (P4BtnClicked) // 만약 4인으로 체크했다면
            {
                PlayerInfo[4].Money = 0; // 4 플레이어의 초기 자금 설정
                PlayerInfo[4].AreaIndex = new List<int>(); // 4 플레이어의 위치값
                PlayerInfo[4].BuildName = new List<string>(); // 4 플레이어의 소유 건물
            }
        }
    }
}
