using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
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

    public struct GoldKey // 골드 키의 정보를 담는 구조체 선언
    {
        public string cardName; // 무슨 카드인지?
        public string cardExplain; // 카드 효과가 무엇인지?
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
        private PictureBox[] Build = new PictureBox[20]; // 각 건물을 지을 위치를 저장하는 픽쳐박스
        private PictureBox[] P1 = new PictureBox[35]; // 1플레이어를 나타내는 픽쳐박스
        private PictureBox[] P2 = new PictureBox[35]; // 2플레이어를 나타내는 픽쳐박스
        private PictureBox[] P3 = new PictureBox[35]; // 3플레이어를 나타내는 픽쳐박스
        private PictureBox[] P4 = new PictureBox[35]; // 4플레이어를 나타내는 픽쳐박스

        public static AreaInfomation[] AreaInfo = new AreaInfomation[35]; // 각 지역 정보 가져오기

        public GoldKey[] goldKeys = new GoldKey[8];

        public static PlayerInfomation[] PlayerInfo = new PlayerInfomation[5]; // 1-4P, 눈에 익기 쉽게 0 인덱스는 사용x, 팀 설정에 따라 바뀜

        public static int areaIndex = 0; // 해당 플레이어가 어느 지역에 위치해 있는지
        public static int diceTurn = 1; // 1-4까지 돌아가는 턴을 지정하는 변수
        public int diceSum = 0; // 주사위의 합
        public int doubleNum = 0; // 더블의 횟수를 카운트하는 변수 3번 나오면 무인도

        public int playerLastLocation; // 주사위를 던진 후 가게될 위치
        public int playerNowLocation; // 주사위를 던지기 전 현재 있는 위치

        public int diceRoll1 = 0; // 왼쪽 주사위의 값
        public int diceRoll2 = 0; // 오른쪽 주사위의 값
        public int goldKeyIndex = 0; // 열쇠 효과의 고유 번호
        public int cnt = 0; // 턴마다 주사위의 숫자를 초기화 할 변수
        public int payFundCoin = 0; // 사회복지기금의 모금된 액수를 저장하는 변수
        public static int showAreaTurn = 0; // 보유 현황 확인 플레이어 번호


        public MainBoard(bool P2BtnClicked, bool P3BtnClicked, bool P4BtnClicked, bool Team_BtnClicked, bool Solo_BtnClicked)
        {
            InitializeComponent();
            GameSetting(P2BtnClicked, P3BtnClicked, P4BtnClicked, Team_BtnClicked, Solo_BtnClicked);
            GoldKeySet();
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

            P1 = new PictureBox[] // P1 위치 초기화
            {
                P1_Location_1, P1_Location_2, P1_Location_3, P1_Location_4, P1_Location_5, P1_Location_6, P1_Location_7, P1_Location_8, P1_Location_9
            };
            P2 = new PictureBox[] // P2 위치 초기화
            {
                P2_Location_1, P2_Location_2
            };
            P3 = new PictureBox[] // P3 위치 초기화
            {
                P3_Location_1, P3_Location_2
            };
            P4 = new PictureBox[] // P4 위치 초기화
            {
                P4_Location_1, P4_Location_2
            };
            Build = new PictureBox[] // 건물 위치 초기화
            {
                BuildArea1, BuildArea2, BuildArea3, BuildArea4, BuildArea5, BuildArea6, BuildArea7, BuildArea8, BuildArea9, BuildArea10,
                BuildArea11, BuildArea12, BuildArea13, BuildArea14, BuildArea15, BuildArea16, BuildArea17, BuildArea18, BuildArea19, BuildArea20,
                BuildArea21
            };

            P1[0].Visible = true; // 시작 지점의 1플레이어 보이게 하기
            P2[0].Visible = true; // 시작 지점의 2플레이어 보이게 하기

            PlayerInfo[1].Money = 5000000; // 1 플레이어의 초기 자금 설정
            PlayerInfo[1].AreaIndex = new List<int>(); // 1 플레이어의 위치값
            PlayerInfo[1].BuildName = new List<string>(); // 1플레이어의 소유 건물

            PlayerInfo[2].Money = 5000000; // 2 플레이어의 초기 자금 설정
            PlayerInfo[2].AreaIndex = new List<int>(); // 2 플레이어의 위치값
            PlayerInfo[2].BuildName = new List<string>(); // 2플레이어의 소유 건물
            if (P3BtnClicked || P4BtnClicked) // 만약 3이나 4인으로 체크했다면
            {
                P3[0].Visible = true; // 시작 지점의 3플레이어 보이게 하기
                PlayerInfo[3].Money = 5000000; // 3 플레이어의 초기 자금 설정
                PlayerInfo[3].AreaIndex = new List<int>(); // 3 플레이어의 위치값
                PlayerInfo[3].BuildName = new List<string>(); // 3 플레이어의 소유 건물
            }
            if (P4BtnClicked) // 만약 4인으로 체크했다면
            {
                P4[0].Visible = true; // 시작 지점의 4플레이어 보이게 하기
                PlayerInfo[4].Money = 5000000; // 4 플레이어의 초기 자금 설정
                PlayerInfo[4].AreaIndex = new List<int>(); // 4 플레이어의 위치값
                PlayerInfo[4].BuildName = new List<string>(); // 4 플레이어의 소유 건물
            }
        }

        public void GoldKeySet() // 황금 열쇠 정보 초기화
        {
            goldKeys[0].cardName = "무인도 탈출";
            goldKeys[0].cardExplain = "특수 무전기 - (무인도에 갇혀 있을 때 사용할 수 있습니다, 1회 사용 후 반납합니다.)";
            goldKeys[1].cardName = "무인도";
            goldKeys[1].cardExplain = "폭풍을 만났습니다. 무인도로 곧장 가세요. - (출발지를 지나더라도 월급을 받을 수 없습니다.)";
            goldKeys[2].cardName = "관광여행";
            goldKeys[2].cardExplain = "제주도로 가세요 - (제주도 소유주에게 통행료를 지불합니다. 출발지를 지나갈 경우, 월급을 받습니다.)";
            goldKeys[3].cardName = "고속도로";
            goldKeys[3].cardExplain = "출발지까지 곧바로 가세요. - (출발지에서 월급을 받습니다.)";
            goldKeys[4].cardName = "우대권";
            goldKeys[4].cardExplain = "상대방이 소유한 장소에 통행료 없이 머무를 수 있습니다. (1회 사용후, 황금 열쇠함에 반납합니다. 중요한 순간에 쓰세요.)";
            goldKeys[5].cardName = "관광여행";
            goldKeys[5].cardExplain = "(가장비싼도시-부산)으로 가세요. - (부산을 상대방이 가지고 있는 경우, 통행료를 지불합니다)";
            goldKeys[6].cardName = "세계여행 초청장";
            goldKeys[6].cardExplain = "세계여행 초청장이 왔습니다. 세계여행 칸으로 이동하시오. (세계여행은 무료이므로 탑승료를 지불하지 않습니다, 출발지를 지나갈 경우 월급을 받습니다.)";
            goldKeys[7].cardName = "사회복지기금 접수처";
            goldKeys[7].cardExplain = "사회복지기금 기부칸으로 가세요.- (출발지를 지나갈 경우, 월급을 받습니다.)";
        }

        public void GoldKeyAction() // 황금 열쇠 이벤트 처리
        {
            playerNowLocation = PlayerInfo[diceTurn].Location; // diceturn에 해당되는 턴의 유저의 위치를 현재 위치를 나타내는 변수에 집어넣기 

            if (goldKeyIndex == 0) // 무인도 탈출권 이벤트
            {
                MessageBox.Show(string.Format(goldKeys[0].cardName + "\n" + goldKeys[0].cardExplain)); // 카드명과 카드 설명을 메세지 박스로 띄움
                PlayerInfo[diceTurn].EscapeIslandCard++; // 현재 턴의 플레이어에게 무인도 탈출권 하나를 지급
            }
            else if (goldKeyIndex == 1) // 무인도로 이동
            {
                MessageBox.Show(string.Format(goldKeys[1].cardName + "\n" + goldKeys[1].cardExplain));
                playerNowLocation = PlayerInfo[diceTurn].Location; // 현위치 부터
                PlayerInfo[diceTurn].Location = 9; // 무인도 인덱스로 이동
                playerLastLocation = PlayerInfo[diceTurn].Location; // 무인도까지 이동
                diceSum = 0; // 주사위로 이동 못하게
                doubleNum = 0; // 더블 횟수 초기화
                timer2.Start();
            }
            else if (goldKeyIndex == 2) // 제주도 관광 여행
            {
                MessageBox.Show(string.Format(goldKeys[2].cardName + "\n" + goldKeys[2].cardExplain));
                playerNowLocation = PlayerInfo[diceTurn].Location; // 현위치부터
                PlayerInfo[diceTurn].Location = 4; // 제주도 인덱스로 이동
                playerLastLocation = PlayerInfo[diceTurn].Location; //제주도까지 이동
                diceSum = 0; // 이동 금지
                timer2.Start();
            }
            else if (goldKeyIndex == 3) // 출발지로 이동
            {
                MessageBox.Show(string.Format(goldKeys[3].cardName + "\n" + goldKeys[3].cardExplain));
                playerNowLocation = PlayerInfo[diceTurn].Location; // 현위치에서
                PlayerInfo[diceTurn].Location = 0;
                playerLastLocation = PlayerInfo[diceTurn].Location;
                diceSum = 0;
                timer2.Start();
            }
            else if (goldKeyIndex == 4) // 천사카드
            {
                MessageBox.Show(string.Format(goldKeys[4].cardName + "\n" + goldKeys[4].cardExplain));
                PlayerInfo[diceTurn].AngelCard++; // 천사카드 지급 
            }
            else if (goldKeyIndex == 5) // 부산으로 이동
            {
                MessageBox.Show(string.Format(goldKeys[5].cardName + "\n" + goldKeys[5].cardExplain));
                playerNowLocation = PlayerInfo[diceTurn].Location;
                PlayerInfo[diceTurn].Location = 22;
                playerLastLocation = PlayerInfo[diceTurn].Location;
                diceSum = 0;
                timer2.Start();
            }
            else if (goldKeyIndex == 6) // 세계여행칸 이동
            {
                MessageBox.Show(string.Format(goldKeys[6].cardName + "\n" + goldKeys[6].cardExplain));
                playerNowLocation = PlayerInfo[diceTurn].Location;
                PlayerInfo[diceTurn].Location = 27;
                playerLastLocation = PlayerInfo[diceTurn].Location;
                diceSum = 0;
                doubleNum = 0;
                timer2.Start();
            }
            else if (goldKeyIndex == 7) // 사회복지 기금 납부
            {
                MessageBox.Show(string.Format(goldKeys[7].cardName + "\n" + goldKeys[7].cardExplain));
                playerNowLocation = PlayerInfo[diceTurn].Location;
                PlayerInfo[diceTurn].Location = 34;
                playerLastLocation= PlayerInfo[diceTurn].Location;
                diceSum = 0;
                timer2.Start();
            }
        }

        public void WorldTour() // 세계여행 로직
        {
            playerNowLocation = PlayerInfo[diceTurn].Location;
            playerLastLocation = areaIndex;
            Dice_Btn.Enabled = false; // 세계 여행 중 주사위 비활성화
            Dice_Btn.BackColor = Color.Purple; // 버튼 비활성화 색깔 표시
            diceSum = 0; // 주사위 초기화
            timer2.Start();
            PlayerInfo[diceTurn].Location = areaIndex; // 선택한 도시로 이동
            Dice_Btn.Enabled = true; // 다시 주사위 켜기
            Dice_Btn.BackColor = Color.Magenta;
            timer1.Start();
        }


        public void WelFareFund() // 사회 복지 기금 수령 로직
        {
            MessageBox.Show(string.Format("{0:N0}를 받습니다.", AreaInfo[18].GiveToSocial)); // 사회복지 기금에 기부된 액수만큼 받는 메시지 박스 출력
            PlayerInfo[diceTurn].Money += AreaInfo[18].GiveToSocial; // 해당 턴의 유저에게 기부금의 액수만큼 더해줌
            AreaInfo[18].GiveToSocial = 0; // 기부금은 0으로 초기화
            payFundCoin = 0;
        }

        public void PayFund() // 사회 복지 기금 기부 로직
        {
            MessageBox.Show("150,000원을 기부합니다.");

            PlayerInfo[diceTurn].Money -= 1500000; // 150000원 탈취
            AreaInfo[18].GiveToSocial += 150000; // 수령칸에 빼앗은 돈 만큼 저장 액수증가
            
            /* 
             * 매각 로직
             */
        }

        public bool ToolgateCheck() // 통행 가능한지? 불가능하면 매각 or 파산
        {
            return true;
        }

        public bool TakeOverCheck() // 인수 가능한지 여부 체크
        {
            return true;
        }

        public void AreaSpot() // 현재 무슨 건물이 지어져있는지에 따라 각기 다른 건물을 구매할 수 있는 함수
        {

        }

        public void playerMove() // 이동 함수
        {
            PlayerInfo[diceTurn].Location += diceSum; // 주사위의 합만큼 이동
            PlayerInfo[diceTurn].Location %= 36; // 주사위를 던져 36칸을 넘어가게 될 경우 다시 1부터 시작할 수 있게 함
            
            if (doubleNum == 3) // 더블이 세번 나올 경우
            {
                PlayerInfo[diceTurn].Location = 9; // 무인도로 이동
                doubleNum = 0; // 더블 횟수 초기화
            }

            if (PlayerInfo[diceTurn].Location == 0) // 출발점에 도착할 경우 
            {
                return; // 일단 이 함수를 빠져 나와서 월급주는 함수로 이동
            }
            else if (PlayerInfo[diceTurn].Location == 6 || PlayerInfo[diceTurn].Location == 16 || PlayerInfo[diceTurn].Location == 20 || PlayerInfo[diceTurn].Location == 31)
            {
                Random rand = new Random(); // 난수 생성
                goldKeyIndex = rand.Next(0, 8); // 0부터 7까지 숫자를 뽑음
                GoldKeyAction(); // 랜덤 수에 나온대로 황금 열쇠 이벤트 발생
            }
            else if (PlayerInfo[diceTurn].Location == 9) // 무인도
            {
                PlayerInfo[diceTurn].EscapeIslandCnt = 3; // 무인도에 도착 할 경우 3턴 동안 갇힘
            }
            else if (PlayerInfo[diceTurn].Location == 18) // 기금 수령 칸
            {
                WelFareFund(); // 그에 맞는 로직 수행
            }
            else if (PlayerInfo[diceTurn].Location == 34) // 기금 지불 칸
            {
                PayFund(); // 위와 같음
            }
            else if (PlayerInfo[diceTurn].Location == 27) // 세계 여행 칸
            {
                PlayerInfo[diceTurn].WorldTourCheck++; // 세계 여행 카운트
                timer1.Stop();
                MessageBox.Show("다음 턴에 세계 여행을 이용할 수 있습니다.");
                timer1.Start();
            }
            else // 일반 지역에 걸렸을 때
            {
                areaIndex = PlayerInfo[diceTurn].Location;
                AreaSpot();
            }
            P1_CurMoney.Text = string.Format("Player1 : {0:N0}원", PlayerInfo[1].Money); // 칸을 지나고 난 뒤 플레이어의 액수 변화 저장
            P2_CurMoney.Text = string.Format("Player2 : {0:N0}원", PlayerInfo[2].Money);
            P3_CurMoney.Text = string.Format("Player3 : {0:N0}원", PlayerInfo[3].Money);
            P4_CurMoney.Text = string.Format("Player4 : {0:N0}원", PlayerInfo[4].Money);
        }

        public void UnislandCheck() // 무인도 탈출권 여부 확인
        {
            if (PlayerInfo[diceTurn].EscapeIslandCard > 0 && PlayerInfo[diceTurn].EscapeIslandCnt > 0) // 만약 탈출권이 있고 무인도에 묶인 턴 수가 1이상일 경우
            {
                MessageBox.Show("무인도 탈출권을 사용하시겠습니까?", "", MessageBoxButtons.YesNo); // yesno 버튼을 가진 메세지 박스 생성
                if (DialogResult == DialogResult.Yes)
                {
                    PlayerInfo[diceTurn].EscapeIslandCard--; // 만약 yes를 답하면 무인도 탈출권 사용
                    PlayerInfo[diceTurn].EscapeIslandCnt = 0; // 묶인 턴 0으로 초기화
                    MessageBox.Show(string.Format("무인도 탈출 카드를 사용합니다.\n현재 남은 카드의 개수는" + PlayerInfo[diceTurn].EscapeIslandCard + "개 입니다.")); // 남은 카드 수를 알려주는 메세지 박스 생성
                }
                else return; // 거부하면 사용 x
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void Dice_Btn_Click(object sender, EventArgs e)
        {
            Dice_Btn.Enabled = false; // 버튼 클릭 후 비활성화 (중복 클릭 방지)
            Dice_Btn.BackColor = Color.Purple; // 눌림 표시

            Random rand = new Random(); // 난수 생성
            diceRoll1 = rand.Next(1, 7); // 1-6까지 랜덤수 생성
            diceRoll2 = rand.Next(1, 7);

            diceSum = diceRoll1 + diceRoll2;

            lbdice1.Text = diceRoll1.ToString(); // 나온 주사위 값을 스트링 형으로 나타냄
            lbdice2.Text = diceRoll2.ToString();

            playerNowLocation = PlayerInfo[diceTurn].Location; // 현재 위치 초기화
            playerLastLocation = (PlayerInfo[diceTurn].Location + diceSum) % 36; // 최종 위치 초기화 (현재 위치 + 주사위의 합 % 전체칸)
            cnt = 0;

            if (PlayerInfo[diceTurn].EscapeIslandCnt > 0) // 아직 무인도에 남아있을 경우
            {
                PlayerInfo[diceTurn].EscapeIslandCnt--; // 묶인 턴수 차감
                cnt = 0;
                timer3.Start();
                cnt = 0;
            }
            else // 무인도가 아닐 경우
            {
                if (diceRoll1 == diceRoll2) // 같은 수가 나올 경우
                {
                    doubleNum++; // 더블 횟수 증가
                    if (doubleNum != 3) // 더블이 3번이 아닐경우
                    {
                        timer3.Start();
                        cnt = 0;
                    }
                    else // 무인도로 이동 (더블 3회)
                    {
                        diceSum = 0; // 이동 금지
                        timer3.Start();
                        cnt = 0;
                    }
                }
                else // 더블이 아닐 경우
                {
                    timer3.Start();
                    cnt = 0;
                    doubleNum = 0; // 더블 값 초기화
                }
            }
            // 누구 턴인지 알려주는 라벨 변경
            if (diceTurn == 1) CurDiceTurn.ForeColor = Color.Red; // 1p 턴일 경우 빨간 색으로 변경
            else if (diceTurn == 2) CurDiceTurn.ForeColor = Color.Blue;
            else if (diceTurn == 3) CurDiceTurn.ForeColor= Color.Yellow;
            else if (diceTurn == 4) CurDiceTurn.ForeColor = Color.Green;
            CurDiceTurn.Text = ($"현재 턴: Player {diceTurn}");
            Dice_Btn.Enabled = true; // 주사위 다시 활성화
            Dice_Btn.BackColor = Color.Magenta; // 활성화 색깔
        }
        // 세계여행간 각 지역 클릭 시 이동되는 함수들

        private void timer1_Tick(object sender, EventArgs e)
        {
            WorldTour(); // 세계 여행 이동 시 사용
            UnislandCheck(); // 무인도에 있고 무인도 탈출 카드가 있는지 체크 
        }

        private void timer2_Tick(object sender, EventArgs e) // 이동 애니메이션 구현
        {
            Dice_Btn.Enabled = false; // 주사위 비활
            Dice_Btn.BackColor = Color.Purple;
            if (playerNowLocation == playerLastLocation) // 아직 이동하지 않았다면
            {
                timer2.Stop();
                int locationTemp = PlayerInfo[diceTurn].Location; // 현 위치값 임시 저장
                playerMove(); // 이동 함수
                if (doubleNum > 0) // 더블일 경우
                {
                    if (PlayerInfo[diceTurn].Location == 27 || PlayerInfo[diceTurn].Location == 10 || locationTemp == 10) // 세계 여행, 무인도 같이 더블이 나와도 한 번 더 던질 수 없는 경우, 혹은 무인도에서 탈출하여 한 번더 못 던질 경우
                    { // 2-4인용 시 수정 필요
                        if (diceTurn == 1) diceTurn = 2; // 1p 턴일 경우 2p 턴으로 변경.
                        else if (diceTurn == 2) diceTurn = 3;
                        else if (diceTurn == 3) diceTurn = 4;
                        else if (diceTurn == 4) diceTurn = 1;
                        doubleNum = 0;
                    }
                }
                else // 더블이 아닐 경우
                {
                    if (goldKeyIndex == 0 || goldKeyIndex == 4) // 탈출권 혹은 우대권?
                    { // 2-4인용 시 수정 필요
                        if (diceTurn == 1) diceTurn = 2;
                        else if (diceTurn == 2) diceTurn = 3;
                        else if (diceTurn == 3) diceTurn = 4;
                        else if (diceTurn == 4) diceTurn = 1;
                    }
                }
                goldKeyIndex = 0; // 황금 열쇠 값 초기화
                if (diceTurn == 1) CurDiceTurn.ForeColor = Color.Red;
                else if (diceTurn == 2) CurDiceTurn.ForeColor = Color.Blue;
                else if (diceTurn == 3) CurDiceTurn.ForeColor = Color.Yellow;
                else CurDiceTurn.ForeColor = Color.Green;
                CurDiceTurn.Text = ($"현재 턴: Player {diceTurn}");

                int gameOverCheck = 0; // 초기값 0
                if (diceTurn == 1) gameOverCheck = 2; // 각 턴마다 게임 오버를 체크함
                else if (diceTurn == 2) gameOverCheck = 3;
                else if (diceTurn == 3) gameOverCheck = 4;
                else if (diceTurn == 4) gameOverCheck = 1;
                if (PlayerInfo[gameOverCheck].Money < 0) // 만약 게임 오버를 체크 했는데 가진 돈이 없을 경우
                    return; // 게임 오버

                Dice_Btn.Enabled = true; // 주사위 활성화
                Dice_Btn.BackColor = Color.Magenta;
            }

            if (diceTurn == 1) P1[playerNowLocation].Visible = false; // 1p 턴일 경우 현재 위치를 숨김
            else if (diceTurn == 2) P2[playerNowLocation].Visible = false; // 2p 턴일 경우 현재 위치를 숨김
            else if (diceTurn == 3) P3[playerNowLocation].Visible = false; // 3p 턴일 경우 현재 위치를 숨김
            else P4[playerNowLocation].Visible = false; // 4p 턴일 경우 현재 위치를 숨김

            playerNowLocation = (playerNowLocation + 1) % 36; // 말 이동 후 현재 위치

            if (diceTurn == 1) P1[playerNowLocation].Visible = true;
            else if (diceTurn == 2) P2[playerNowLocation].Visible = true;
            else if (diceTurn == 3) P3[playerNowLocation].Visible = true;
            else P4[playerNowLocation].Visible = true;


            if (playerNowLocation == 0) // 출발지점에 도착할 경우
            {
                PlayerInfo[diceTurn].Money += 300000;
                P1_CurMoney.Text = string.Format("Player1 : {0:N0}원", PlayerInfo[1].Money);
                P2_CurMoney.Text = string.Format("Player2 : {0:N0}원", PlayerInfo[2].Money);
                P3_CurMoney.Text = string.Format("Player3 : {0:N0}원", PlayerInfo[3].Money);
                P4_CurMoney.Text = string.Format("Player4 : {0:N0}원", PlayerInfo[4].Money);
                MessageBox.Show("월급 30만원을 지급합니다.");
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            Dice_Btn.Enabled = false;
            Dice_Btn.BackColor = Color.Purple;
            if (cnt < 6) // 6번 굴려서 랜덤하게 나오는 것처럼 애니메이션 효과를 줌
            {
                Left_Dice.BackgroundImage = imageList1.Images[cnt];
                Right_Dice.BackgroundImage = imageList1.Images[cnt];
            }
            cnt++;

            if (cnt == 6)
            {
                Left_Dice.BackgroundImage = imageList1.Images[int.Parse(lbdice1.Text) - 1]; // 스트링 형으로 저장된 주사위 값을 인트형으로 변환 후 이미지 리스트의 배열 값에 맞게 -1을 하여 시각적으로 표현
                Right_Dice.BackgroundImage = imageList1.Images[int.Parse(lbdice2.Text) - 1];

                playerNowLocation = PlayerInfo[diceTurn].Location; // 현재 위치 초기화
                playerLastLocation = (PlayerInfo[diceTurn].Location + diceSum) % 36; // 주사위 굴린 후 최종 위치 초기화
            
                if (doubleNum == 3)
                {
                    MessageBox.Show("더블 3번 연속으로 무인도로 이동");

                    playerLastLocation = 9;
                }

                if (PlayerInfo[diceTurn].EscapeIslandCnt > 0) // 무인도에 있을 때
                {
                    if (diceRoll2 == diceRoll1) // 더블이 뜨면
                    {
                        MessageBox.Show("더블! 무인도를 탈출합니다.");
                        timer2.Start(); // 이동
                        PlayerInfo[diceTurn].EscapeIslandCnt = 0; // 무인도 턴 수 초기화
                        doubleNum = 0; // 더블 횟수 초기화
                        if (diceTurn == 1) CurDiceTurn.ForeColor = Color.Red;
                        else if (diceTurn == 2) CurDiceTurn.ForeColor = Color.Blue;
                        else if (diceTurn == 3) CurDiceTurn.ForeColor = Color.Yellow;
                        else CurDiceTurn.ForeColor = Color.Green;
                        CurDiceTurn.Text = ($"현재 턴 : Player {diceTurn}");
                        timer3.Stop();
                        return;
                    }
                    else // 더블 x 탈출 실패
                    { // 턴 넘기기
                        if (diceTurn == 1) diceTurn = 2;
                        else if (diceTurn == 2) diceTurn = 3;
                        else if (diceTurn == 3) diceTurn = 4;
                        else diceTurn = 1;

                        if (diceTurn == 1) CurDiceTurn.ForeColor = Color.Red;
                        else if (diceTurn == 2) CurDiceTurn.ForeColor = Color.Blue;
                        else if (diceTurn == 3) CurDiceTurn.ForeColor = Color.Yellow;
                        else CurDiceTurn.ForeColor = Color.Green;
                        CurDiceTurn.Text = ($"현재 턴 : Player {diceTurn}");
                        MessageBox.Show("탈출 실패!");
                        Dice_Btn.Enabled = true; // 주사위 활성화
                        Dice_Btn.BackColor = Color.Magenta;
                    }
                }
                else // 무인도가 아닐 경우
                {
                    timer2.Start();
                } 
                timer3.Stop();
                cnt = 0;
            }


        }


        // 각 플레이어의 자산 보유 현황을 띄우는 버튼 2-4인 따라 수정 필요
        private void P1_CurAsset_Click(object sender, EventArgs e)
        {
            showAreaTurn = 1;
        }

        private void P2_CurAsset_Click(object sender, EventArgs e)
        {
            showAreaTurn = 2;
        }

        private void P3_CurAsset_Click(object sender, EventArgs e)
        {
            showAreaTurn = 3;
        }

        private void P4_CurAsset_Click(object sender, EventArgs e)
        {
            showAreaTurn = 4;
        }
    }
}
