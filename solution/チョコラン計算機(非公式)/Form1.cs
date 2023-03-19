using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.IO;


namespace チョコラン計算機_非公式_
{
    public partial class Form1 : Form
    {
        struct StatusStructure
        {
            public int charaStatus;
            public int bitaStatus;
            public int allBitaStatus;
            public int cardStatus;
            public int makiStatus;
            public int kanUpStatus;
            public int kanDownStatus;
            public int eruUp;
            public int inputStatus;
            public int bradScraper;
            public int totalStatus;
        }

        struct PureStatusStructure
        {
            public int outputStatus;
            public int inputStatus;
            public int makiStatus;
            public int eruUp;
            public int upStatus;
            public Boolean intGreater;
        }

        StatusStructure HPStructure;
        StatusStructure SPStructure;
        StatusStructure powStructure;
        StatusStructure intStructure;
        StatusStructure vitStructure;
        StatusStructure spdStructure;
        StatusStructure luckStructure;
        PureStatusStructure atkStructure;
        PureStatusStructure defStructure;
        PureStatusStructure matStructure;
        PureStatusStructure mdfStructure;

        public Form1()
        {
            InitializeComponent();
        }

        private void displayStatus()
        {
            HPOutputLabel.Text = HPStructure.totalStatus.ToString();
            SPOutputLabel.Text = SPStructure.totalStatus.ToString();
            powOutput.Text = powStructure.totalStatus.ToString();
            intOutput.Text = intStructure.totalStatus.ToString();
            vitOutput.Text = vitStructure.totalStatus.ToString();
            spdOutput.Text = spdStructure.totalStatus.ToString();
            luckOutput.Text = luckStructure.totalStatus.ToString();
            atkOutput.Text = atkStructure.outputStatus.ToString() + "(上昇値 : " + atkStructure.upStatus.ToString() + ")";
            defOutput.Text = defStructure.outputStatus.ToString() + "(上昇値 : " + defStructure.upStatus.ToString() + ")";
            matOutput.Text = matStructure.outputStatus.ToString() + "(上昇値 : " + matStructure.upStatus.ToString() + ")";
            mdfOutput.Text = mdfStructure.outputStatus.ToString() + "(上昇値 : " + mdfStructure.upStatus.ToString() + ")";
        }

        private void calcStatus()
        {
            powStructure.cardStatus = int.Parse(powBreakText.Text);
            intStructure.cardStatus = int.Parse(intBreakText.Text);
            vitStructure.cardStatus = int.Parse(vitBreakText.Text);
            spdStructure.cardStatus = int.Parse(spdBreakText.Text);
            luckStructure.cardStatus = int.Parse(luckBreakText.Text);
            HPStructure.totalStatus = HPStructure.inputStatus + HPStructure.makiStatus + HPStructure.eruUp;
            SPStructure.totalStatus = SPStructure.inputStatus + SPStructure.makiStatus + SPStructure.eruUp;
            powStructure.totalStatus = powStructure.inputStatus + powStructure.cardStatus + powStructure.bitaStatus + powStructure.allBitaStatus + powStructure.kanUpStatus - powStructure.kanDownStatus + powStructure.makiStatus + powStructure.eruUp + powStructure.bradScraper;
            intStructure.totalStatus = intStructure.inputStatus + intStructure.cardStatus + intStructure.bitaStatus + intStructure.allBitaStatus + intStructure.kanUpStatus - intStructure.kanDownStatus + intStructure.makiStatus + intStructure.eruUp;
            vitStructure.totalStatus = vitStructure.inputStatus + vitStructure.cardStatus + vitStructure.bitaStatus + vitStructure.allBitaStatus + vitStructure.kanUpStatus - vitStructure.kanDownStatus + vitStructure.makiStatus + vitStructure.eruUp;
            spdStructure.totalStatus = spdStructure.inputStatus + spdStructure.cardStatus + spdStructure.bitaStatus + spdStructure.allBitaStatus + spdStructure.kanUpStatus - spdStructure.kanDownStatus + spdStructure.makiStatus + spdStructure.eruUp;
            luckStructure.totalStatus = luckStructure.inputStatus + luckStructure.cardStatus + luckStructure.bitaStatus + luckStructure.allBitaStatus + luckStructure.kanUpStatus - luckStructure.kanDownStatus + luckStructure.makiStatus + luckStructure.eruUp;
        }

        private void calcPureStatus()
        {
            atkStructure.outputStatus = atkStructure.eruUp + atkStructure.upStatus + atkStructure.inputStatus + atkStructure.makiStatus + (powStructure.totalStatus - powStructure.inputStatus) * 3;
            defStructure.outputStatus = defStructure.eruUp + defStructure.upStatus + defStructure.inputStatus + defStructure.makiStatus + (vitStructure.totalStatus - vitStructure.inputStatus) * 2;
            matStructure.outputStatus = matStructure.eruUp + matStructure.upStatus + matStructure.inputStatus + matStructure.makiStatus + (intStructure.totalStatus - intStructure.inputStatus) * 2;
            mdfStructure.outputStatus = mdfStructure.eruUp + mdfStructure.upStatus + mdfStructure.inputStatus + mdfStructure.makiStatus + (intStructure.totalStatus - intStructure.inputStatus) * 15;
        }

        private void textBox2inputStatus()
        {
            if (HPInputText.Text != null && HPInputText.Text != "")
            {
                var HPFormura = SimpleCalc.Calc.Analyze(HPInputText.Text);
                HPStructure.inputStatus = (int)HPFormura.Calc(null);
            }
            if (SPInputText.Text != null && SPInputText.Text != "")
            {
                var SPFormura = SimpleCalc.Calc.Analyze(SPInputText.Text);
                SPStructure.inputStatus = (int)SPFormura.Calc(null);
            }

            if (atkInputText.Text != null && atkInputText.Text != "")
            {
                var atkFormura = SimpleCalc.Calc.Analyze(atkInputText.Text);
                atkStructure.inputStatus = (int)atkFormura.Calc(null);
            }

            if (defInputText.Text != null && defInputText.Text != "")
            {
                var defFormura = SimpleCalc.Calc.Analyze(defInputText.Text);
                defStructure.inputStatus = (int)defFormura.Calc(null);
            }

            if (matInputText.Text != null && matInputText.Text != "")
            {
                var matFormura = SimpleCalc.Calc.Analyze(matInputText.Text);
                matStructure.inputStatus = (int)matFormura.Calc(null);
            }

            if (mdfInputText.Text != null && mdfInputText.Text != "")
            {
                var mdfFormura = SimpleCalc.Calc.Analyze(mdfInputText.Text);
                mdfStructure.inputStatus = (int)mdfFormura.Calc(null);
            }

            if (powTotalText.Text != null && powTotalText.Text != "")
            {
                var powFormura = SimpleCalc.Calc.Analyze(powTotalText.Text);
                powStructure.inputStatus = (int)powFormura.Calc(null);
            }

            if (intTotalText.Text != null && intTotalText.Text != "")
            {
                var intFormura = SimpleCalc.Calc.Analyze(intTotalText.Text);
                intStructure.inputStatus = (int)intFormura.Calc(null);
            }
            if (vitTotalText.Text != null && vitTotalText.Text != "")
            {
                var vitFormura = SimpleCalc.Calc.Analyze(vitTotalText.Text);
                vitStructure.inputStatus = (int)vitFormura.Calc(null);
            }

            if (spdTotalText.Text != null && spdTotalText.Text != "")
            {
                var spdFormura = SimpleCalc.Calc.Analyze(spdTotalText.Text);
                spdStructure.inputStatus = (int)spdFormura.Calc(null);
            }

            if (luckTotalText.Text != null && luckTotalText.Text != "")
            {
                var luckFormura = SimpleCalc.Calc.Analyze(luckTotalText.Text);
                luckStructure.inputStatus = (int)luckFormura.Calc(null);
            }
        }

        private void manekinSave(String filename)
        {
            String writeContents = "level:" + levelInputText.Text + "\r\n";
            writeContents += "HP:" + HPInputText.Text + "\r\n";
            writeContents += "SP:" + SPInputText.Text + "\r\n";
            writeContents += "charaPow:" + powCharaText.Text + "\r\n";
            writeContents += "charaInt:" + intCharaText.Text + "\r\n";
            writeContents += "charaSpd:" + spdCharaText.Text + "\r\n";
            writeContents += "charaVit:" + vitCharaText.Text + "\r\n";
            writeContents += "charaLuck:" + luckCharaText.Text + "\r\n";
            writeContents += "cardPow:" + powBreakText.Text + "\r\n";
            writeContents += "cardInt:" + intBreakText.Text + "\r\n";
            writeContents += "cardSpd:" + spdBreakText.Text + "\r\n";
            writeContents += "cardVit:" + vitBreakText.Text + "\r\n";
            writeContents += "cardLuck:" + luckBreakText.Text + "\r\n";
            writeContents += "totalPow:" + powTotalText.Text + "\r\n";
            writeContents += "totalInt:" + intTotalText.Text + "\r\n";
            writeContents += "totalSpd:" + spdTotalText.Text + "\r\n";
            writeContents += "totalVit:" + vitTotalText.Text + "\r\n";
            writeContents += "totalLuck:" + luckTotalText.Text + "\r\n";
            writeContents += "inputAtk:" + atkInputText.Text + "\r\n";
            writeContents += "inputDef:" + defInputText.Text + "\r\n";
            writeContents += "inputMat:" + matInputText.Text + "\r\n";
            writeContents += "inputMdf:" + mdfInputText.Text;
            File.WriteAllText(filename, writeContents);
            MessageBox.Show(filename.Split("/")[1].Split(".")[0] + "を保存しました");
        }

        private void manekinCall(String filename)
        {
            var tempArray = File.ReadAllLines(filename);
            int index;
            String[] temp;

            for (index = 0; index < tempArray.Length; index++)
            {
                temp = tempArray[index].Split(":");
                switch (temp[0])
                {
                    case ("level"):
                        levelInputText.Text = temp[1];
                        break;
                    case ("HP"):
                        HPInputText.Text = temp[1];
                        break;
                    case ("SP"):
                        SPInputText.Text = temp[1];
                        break;
                    case ("charaPow"):
                        powCharaText.Text = temp[1];
                        break;
                    case ("charaInt"):
                        intCharaText.Text = temp[1];
                        break;
                    case ("charaSpd"):
                        spdCharaText.Text = temp[1];
                        break;
                    case ("charaVit"):
                        vitCharaText.Text = temp[1];
                        break;
                    case ("charaLuck"):
                        luckCharaText.Text = temp[1];
                        break;
                    case ("cardPow"):
                        powBreakText.Text = temp[1];
                        break;
                    case ("cardInt"):
                        intBreakText.Text = temp[1];
                        break;
                    case ("cardSpd"):
                        spdBreakText.Text = temp[1];
                        break;
                    case ("cardVit"):
                        vitBreakText.Text = temp[1];
                        break;
                    case ("cardLuck"):
                        luckBreakText.Text = temp[1];
                        break;
                    case ("totalPow"):
                        powTotalText.Text = temp[1];
                        break;
                    case ("totalInt"):
                        intTotalText.Text = temp[1];
                        break;
                    case ("totalSpd"):
                        spdTotalText.Text = temp[1];
                        break;
                    case ("totalVit"):
                        vitTotalText.Text = temp[1];
                        break;
                    case ("totalLuck"):
                        luckTotalText.Text = temp[1];
                        break;
                    case ("inputAtk"):
                        atkInputText.Text = temp[1];
                        break;
                    case ("inputDef"):
                        defInputText.Text = temp[1];
                        break;
                    case ("inputMat"):
                        matInputText.Text = temp[1];
                        break;
                    case ("inputMdf"):
                        mdfInputText.Text = temp[1];
                        break;

                }
            }
            MessageBox.Show("読み込みが完了しました");
        }

        private Boolean specialSkillCheck()
        {
            if (HPStructure.eruUp != 0)
            {
                MessageBox.Show("大天使の加護の効果が残っています");
                return true;
            }
            if (SPStructure.eruUp != 0)
            {
                MessageBox.Show("大天使の加護の効果が残っています");
                return true;
            }
            if (powStructure.eruUp != 0)
            {
                MessageBox.Show("大天使の加護の効果が残っています");
                return true;
            }
            if (intStructure.eruUp != 0)
            {
                MessageBox.Show("大天使の加護の効果が残っています");
                return true;
            }
            if (vitStructure.eruUp != 0)
            {
                MessageBox.Show("大天使の加護の効果が残っています");
                return true;
            }
            if (spdStructure.eruUp != 0)
            {
                MessageBox.Show("大天使の加護の効果が残っています");
                return true;
            }
            if (luckStructure.eruUp != 0)
            {
                MessageBox.Show("大天使の加護もしくは邪神の呪詛の効果が残っています");
                return true;
            }
            if (atkStructure.eruUp != 0)
            {
                MessageBox.Show("大天使の加護の効果が残っています");
                return true;
            }
            if (defStructure.eruUp != 0)
            {
                MessageBox.Show("大天使の加護の効果が残っています");
                return true;
            }
            if (matStructure.eruUp != 0)
            {
                MessageBox.Show("大天使の加護の効果が残っています");
                return true;
            }
            if (mdfStructure.eruUp != 0)
            {
                MessageBox.Show("大天使の加護の効果が残っています");
                return true;
            }

            return false;
        }

        private Boolean eruWingCheck()
        {
            String errorMessage = "未入力欄があります\n";
            Boolean checkRes = false;

            if (HPInputText.Text == null || HPInputText.Text == "")
            {
                errorMessage += "・HP\n";
                checkRes = true;
            }
            if (SPInputText.Text == null || SPInputText.Text == "")
            {
                errorMessage += "・SP\n";
                checkRes = true;
            }
            if (powTotalText.Text == null || powTotalText.Text == "")
            {
                errorMessage += "・合計のPOW\n";
                checkRes = true;
            }
            if (intTotalText.Text == null || intTotalText.Text == "")
            {
                errorMessage += "・合計のINT\n";
                checkRes = true;
            }
            if (vitTotalText.Text == null || vitTotalText.Text == "")
            {
                errorMessage += "・合計のVIT\n";
                checkRes = true;
            }
            if (spdTotalText.Text == null || spdTotalText.Text == "")
            {
                errorMessage += "・合計のSPD\n";
                checkRes = true;
            }
            if (luckTotalText.Text == null || luckTotalText.Text == "")
            {
                errorMessage += "・合計のLUK\n";
                checkRes = true;
            }
            if (atkInputText.Text == null || atkInputText.Text == "")
            {
                errorMessage += "・表示ATK\n";
                checkRes = true;
            }
            if (defInputText.Text == null || defInputText.Text == "")
            {
                errorMessage += "・表示DEF\n";
                checkRes = true;
            }
            if (matInputText.Text == null || matInputText.Text == "")
            {
                errorMessage += "・表示MAT\n";
                checkRes = true;
            }
            if (mdfInputText.Text == null || mdfInputText.Text == "")
            {
                errorMessage += "・表示MDF\n";
                checkRes = true;
            }

            if (checkRes)
            {
                MessageBox.Show(errorMessage);
            }
            return checkRes;
        }

        private Boolean fisCurseCheck()
        {
            String errorMessage = "未入力欄があります\n";
            Boolean checkRes = false;


            if (luckTotalText.Text == null || luckTotalText.Text == "")
            {
                errorMessage += "・合計のLUK\n";
                checkRes = true;
            }

            if (checkRes)
            {
                MessageBox.Show(errorMessage);
            }
            return checkRes;
        }

        private void initEruStatus()
        {
            HPStructure.eruUp = 0;
            SPStructure.eruUp = 0;

            powStructure.eruUp = 0;
            intStructure.eruUp = 0;
            vitStructure.eruUp = 0;
            spdStructure.eruUp = 0;
            luckStructure.eruUp = 0;

            atkStructure.eruUp = 0;
            matStructure.eruUp = 0;
            defStructure.eruUp = 0;
            mdfStructure.eruUp = 0;
        }

        private Boolean atarikiCheck()
        {
            String errorMessage = "未入力欄があります\n";
            Boolean checkRes = false;
            if (levelInputText.Text == null || levelInputText.Text == "")
            {
                errorMessage += "・キャラレベル\n";
                checkRes = true;
            }
            if (powTotalText.Text == null || powTotalText.Text == "")
            {
                errorMessage += "・合計のPOW\n";
                checkRes = true;
            }
            if (atkInputText.Text == null || atkInputText.Text == "")
            {
                errorMessage += "・表示ATK\n";
                checkRes = true;
            }
            if (powBreakText.Text == null || powBreakText.Text == "")
            {
                errorMessage += "・カードのPOW\n";
                checkRes = true;
            }

            if (checkRes)
            {
                MessageBox.Show(errorMessage);
            }

            return checkRes;
        }

        private Boolean mamorikiCheck()
        {
            String errorMessage = "未入力欄があります\n";
            Boolean checkRes = false;
            if (levelInputText.Text == null || levelInputText.Text == "")
            {
                errorMessage += "・キャラレベル\n";
                checkRes = true;
            }
            if (vitTotalText.Text == null || vitTotalText.Text == "")
            {
                errorMessage += "・合計のVIT\n";
                checkRes = true;
            }
            if (defInputText.Text == null || defInputText.Text == "")
            {
                errorMessage += "・表示DEF\n";
                checkRes = true;
            }
            if (vitBreakText.Text == null || vitBreakText.Text == "")
            {
                errorMessage += "・カードのDEF\n";
                checkRes = true;
            }

            if (checkRes)
            {
                MessageBox.Show(errorMessage);
            }

            return checkRes;
        }

        private Boolean mahoataCheck()
        {
            String errorMessage = "未入力欄があります\n";
            Boolean checkRes = false;
            if (levelInputText.Text == null || levelInputText.Text == "")
            {
                errorMessage += "・キャラレベル\n";
                checkRes = true;
            }
            if (intTotalText.Text == null || intTotalText.Text == "")
            {
                errorMessage += "・合計のINT\n";
                checkRes = true;
            }
            if (matInputText.Text == null || matInputText.Text == "")
            {
                errorMessage += "・表示MAT\n";
                checkRes = true;
            }
            if (intBreakText.Text == null || intBreakText.Text == "")
            {
                errorMessage += "・カードのINT\n";
                checkRes = true;
            }

            if (checkRes)
            {
                MessageBox.Show(errorMessage);
            }

            return checkRes;
        }

        private Boolean mahomamoCheck()
        {
            String errorMessage = "未入力欄があります\n";
            Boolean checkRes = false;
            if (levelInputText.Text == null || levelInputText.Text == "")
            {
                errorMessage += "・キャラレベル\n";
                checkRes = true;
            }
            if (intTotalText.Text == null || intTotalText.Text == "")
            {
                errorMessage += "・合計のINT\n";
                checkRes = true;
            }
            if (vitTotalText.Text == null || vitTotalText.Text == "")
            {
                errorMessage += "・合計のVIT\n";
                checkRes = true;
            }
            if (mdfInputText.Text == null || mdfInputText.Text == "")
            {
                errorMessage += "・表示MDF\n";
                checkRes = true;
            }
            if (intBreakText.Text == null || intBreakText.Text == "")
            {
                errorMessage += "・カードのINT\n";
                checkRes = true;
            }
            if (vitBreakText.Text == null || vitBreakText.Text == "")
            {
                errorMessage += "・カードのVIT\n";
                checkRes = true;
            }

            if (checkRes)
            {
                MessageBox.Show(errorMessage);
            }

            return checkRes;
        }

        private Boolean powBitaCheck()
        {
            String errorMessage = "未入力欄があります\n";
            Boolean checkRes = false;

            if (powCharaText.Text == null || powCharaText.Text == "")
            {
                errorMessage += "・ステ振りのPOW\n";
                checkRes = true;
            }
            if (atkInputText.Text == null || atkInputText.Text == "")
            {
                errorMessage += "・表示ATK\n";
                checkRes = true;
            }
            if (checkRes)
            {
                MessageBox.Show(errorMessage);
            }

            return checkRes;
        }

        private Boolean intBitaCheck()
        {
            String errorMessage = "未入力欄があります\n";
            Boolean checkRes = false;

            if (intCharaText.Text == null || intCharaText.Text == "")
            {
                errorMessage += "・ステ振りのINT\n";
                checkRes = true;
            }
            if (matInputText.Text == null || matInputText.Text == "")
            {
                errorMessage += "・表示MAT\n";
                checkRes = true;
            }
            if (mdfInputText.Text == null || mdfInputText.Text == "")
            {
                errorMessage += "・表示MDF\n";
                checkRes = true;
            }
            if (checkRes)
            {
                MessageBox.Show(errorMessage);
            }

            return checkRes;
        }

        private Boolean vitBitaCheck()
        {
            String errorMessage = "未入力欄があります\n";
            Boolean checkRes = false;

            if (vitCharaText.Text == null || vitCharaText.Text == "")
            {
                errorMessage += "・ステ振りのVIT\n";
                checkRes = true;
            }
            if (defInputText.Text == null || defInputText.Text == "")
            {
                errorMessage += "・表示DEF\n";
                checkRes = true;
            }
            if (checkRes)
            {
                MessageBox.Show(errorMessage);
            }

            return checkRes;
        }

        private Boolean spdBitaCheck()
        {
            String errorMessage = "未入力欄があります\n";
            Boolean checkRes = false;

            if (spdCharaText.Text == null || spdCharaText.Text == "")
            {
                errorMessage += "・ステ振りのSPD\n";
                checkRes = true;
            }
            if (checkRes)
            {
                MessageBox.Show(errorMessage);
            }

            return checkRes;
        }

        private Boolean luckBitaCheck()
        {
            String errorMessage = "未入力欄があります\n";
            Boolean checkRes = false;

            if (luckCharaText.Text == null || luckCharaText.Text == "")
            {
                errorMessage += "・ステ振りのLUK\n";
                checkRes = true;
            }
            if (checkRes)
            {
                MessageBox.Show(errorMessage);
            }

            return checkRes;
        }

        private Boolean allBitaCheck()
        {
            String errorMessage = "未入力欄があります\n";
            Boolean checkRes = false;

            if (powCharaText.Text == null || powCharaText.Text == "")
            {
                errorMessage += "・ステ振りのPOW\n";
                checkRes = true;
            }
            if (intCharaText.Text == null || intCharaText.Text == "")
            {
                errorMessage += "・ステ振りのINT\n";
                checkRes = true;
            }
            if (vitCharaText.Text == null || vitCharaText.Text == "")
            {
                errorMessage += "・ステ振りのVIT\n";
                checkRes = true;
            }
            if (spdCharaText.Text == null || spdCharaText.Text == "")
            {
                errorMessage += "・ステ振りのSPD\n";
                checkRes = true;
            }
            if (luckCharaText.Text == null || luckCharaText.Text == "")
            {
                errorMessage += "・ステ振りのLUK\n";
                checkRes = true;
            }
            if (atkInputText.Text == null || atkInputText.Text == "")
            {
                errorMessage += "・表示ATK\n";
                checkRes = true;
            }
            if (defInputText.Text == null || defInputText.Text == "")
            {
                errorMessage += "・表示DEF\n";
                checkRes = true;
            }
            if (matInputText.Text == null || matInputText.Text == "")
            {
                errorMessage += "・表示MAT\n";
                checkRes = true;
            }
            if (mdfInputText.Text == null || mdfInputText.Text == "")
            {
                errorMessage += "・表示MDF\n";
                checkRes = true;
            }
            if (checkRes)
            {
                MessageBox.Show(errorMessage);
            }

            return checkRes;
        }

        private Boolean manekinCheck()
        {
            String errorMessage = "未入力欄があります\n";
            Boolean checkRes = false;

            if (powCharaText.Text == null || powCharaText.Text == "")
            {
                errorMessage += "・ステ振りのPOW\n";
                checkRes = true;
            }
            if (intCharaText.Text == null || intCharaText.Text == "")
            {
                errorMessage += "・ステ振りのINT\n";
                checkRes = true;
            }
            if (vitCharaText.Text == null || vitCharaText.Text == "")
            {
                errorMessage += "・ステ振りのVIT\n";
                checkRes = true;
            }
            if (spdCharaText.Text == null || spdCharaText.Text == "")
            {
                errorMessage += "・ステ振りのSPD\n";
                checkRes = true;
            }
            if (luckCharaText.Text == null || luckCharaText.Text == "")
            {
                errorMessage += "・ステ振りのLUK\n";
                checkRes = true;
            }
            if (powBreakText.Text == null || powBreakText.Text == "")
            {
                errorMessage += "・カードのPOW\n";
                checkRes = true;
            }
            if (intBreakText.Text == null || intBreakText.Text == "")
            {
                errorMessage += "・カードのINT\n";
                checkRes = true;
            }
            if (vitBreakText.Text == null || vitBreakText.Text == "")
            {
                errorMessage += "・カードのVIT\n";
                checkRes = true;
            }
            if (spdBreakText.Text == null || spdBreakText.Text == "")
            {
                errorMessage += "・カードのSPD\n";
                checkRes = true;
            }
            if (luckBreakText.Text == null || luckBreakText.Text == "")
            {
                errorMessage += "・カードのLUK\n";
                checkRes = true;
            }
            if (powTotalText.Text == null || powTotalText.Text == "")
            {
                errorMessage += "・合計のPOW\n";
                checkRes = true;
            }
            if (intTotalText.Text == null || intTotalText.Text == "")
            {
                errorMessage += "・合計のINT\n";
                checkRes = true;
            }
            if (vitTotalText.Text == null || vitTotalText.Text == "")
            {
                errorMessage += "・合計のVIT\n";
                checkRes = true;
            }
            if (spdTotalText.Text == null || spdTotalText.Text == "")
            {
                errorMessage += "・合計のSPD\n";
                checkRes = true;
            }
            if (luckTotalText.Text == null || luckTotalText.Text == "")
            {
                errorMessage += "・合計のLUK\n";
                checkRes = true;
            }
            if (atkInputText.Text == null || atkInputText.Text == "")
            {
                errorMessage += "・表示ATK\n";
                checkRes = true;
            }
            if (defInputText.Text == null || defInputText.Text == "")
            {
                errorMessage += "・表示DEF\n";
                checkRes = true;
            }
            if (matInputText.Text == null || matInputText.Text == "")
            {
                errorMessage += "・表示MAT\n";
                checkRes = true;
            }
            if (mdfInputText.Text == null || mdfInputText.Text == "")
            {
                errorMessage += "・表示MDF\n";
                checkRes = true;
            }
            if (checkRes)
            {
                MessageBox.Show(errorMessage);
            }

            return checkRes;
        }


        private void intBita_Click(object sender, EventArgs e)
        {
            if (!intBitaCheck())
            {
                intStructure.charaStatus = int.Parse(intCharaText.Text);
                intStructure.bitaStatus = (int)((double)intStructure.charaStatus * 0.2);
                if ((int)((double)intStructure.charaStatus * 0.2) == 0)
                {
                    intStructure.bitaStatus = 1;
                }

                textBox2inputStatus();
                calcStatus();
                calcPureStatus();
                displayStatus();
            }
        }

        private void powBita_Click(object sender, EventArgs e)
        {
            if (!powBitaCheck())
            {
                powStructure.charaStatus = int.Parse(powCharaText.Text);
                powStructure.bitaStatus = (int)(powStructure.charaStatus * 0.2);
                if ((int)(powStructure.charaStatus * 0.2) == 0)
                {
                    powStructure.bitaStatus = 1;
                }
                textBox2inputStatus();
                calcStatus();
                calcPureStatus();
                displayStatus();
            }
        }

        private void vitBita_Click(object sender, EventArgs e)
        {
            if (!vitBitaCheck())
            {
                vitStructure.charaStatus = int.Parse(vitCharaText.Text);
                vitStructure.bitaStatus = (int)((double)vitStructure.charaStatus * 0.2);
                if ((int)((double)vitStructure.charaStatus * 0.2) == 0)
                {
                    vitStructure.bitaStatus = 1;
                }
                textBox2inputStatus();
                calcStatus();
                calcPureStatus();
                displayStatus();

            }
        }

        private void spdBita_Click(object sender, EventArgs e)
        {
            if (!spdBitaCheck())
            {
                spdStructure.charaStatus = int.Parse(spdCharaText.Text);
                spdStructure.bitaStatus = (int)((double)spdStructure.charaStatus * 0.2);
                if ((int)((double)spdStructure.charaStatus * 0.2) == 0)
                {
                    spdStructure.bitaStatus = 1;
                }
                textBox2inputStatus();
                calcStatus();
                calcPureStatus();
                displayStatus();
            }
        }

        private void luckBita_Click(object sender, EventArgs e)
        {
            if (!luckBitaCheck())
            {
                luckStructure.charaStatus = int.Parse(luckCharaText.Text);
                luckStructure.bitaStatus = (int)((double)luckStructure.charaStatus * 0.2);
                if ((int)((double)luckStructure.charaStatus * 0.2) == 0)
                {
                    luckStructure.bitaStatus = 1;
                }

                textBox2inputStatus();
                calcStatus();
                calcPureStatus();
                displayStatus();

            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void allBita_Click(object sender, EventArgs e)
        {
            if (!allBitaCheck())
            {
                powStructure.charaStatus = int.Parse(powCharaText.Text);
                powStructure.allBitaStatus = (int)((double)powStructure.charaStatus * 0.1);
                if ((int)((double)powStructure.charaStatus * 0.1) == 0)
                {
                    powStructure.allBitaStatus = 1;
                }


                intStructure.charaStatus = int.Parse(intCharaText.Text);
                intStructure.allBitaStatus = (int)((double)intStructure.charaStatus * 0.1);
                if ((int)((double)intStructure.charaStatus * 0.1) == 0)
                {
                    intStructure.allBitaStatus = 1;
                }


                vitStructure.charaStatus = int.Parse(vitCharaText.Text);
                vitStructure.allBitaStatus = (int)((double)vitStructure.charaStatus * 0.1);
                if ((int)((double)vitStructure.charaStatus * 0.1) == 0)
                {
                    vitStructure.allBitaStatus = 1;
                }

                spdStructure.charaStatus = int.Parse(spdCharaText.Text);
                spdStructure.allBitaStatus = (int)((double)spdStructure.charaStatus * 0.1);
                if ((int)((double)spdStructure.charaStatus * 0.1) == 0)
                {
                    spdStructure.allBitaStatus = 1;
                }
                luckStructure.charaStatus = int.Parse(luckCharaText.Text);
                luckStructure.allBitaStatus = (int)((double)luckStructure.charaStatus * 0.1);
                if ((int)((double)luckStructure.charaStatus * 0.1) == 0)
                {
                    luckStructure.allBitaStatus = 1;
                }

                textBox2inputStatus();
                calcStatus();
                calcPureStatus();
                displayStatus();
            }
        }

        private void bitaReset_Click(object sender, EventArgs e)
        {

            textBox2inputStatus();
            powStructure.bitaStatus = 0;
            powStructure.allBitaStatus = 0;
            intStructure.bitaStatus = 0;
            intStructure.allBitaStatus = 0;
            vitStructure.bitaStatus = 0;
            vitStructure.allBitaStatus = 0;
            spdStructure.bitaStatus = 0;
            spdStructure.allBitaStatus = 0;
            luckStructure.bitaStatus = 0;
            luckStructure.allBitaStatus = 0;
            calcStatus();
            calcPureStatus();
            displayStatus();
        }

        private void kanReset_Click(object sender, EventArgs e)
        {

            textBox2inputStatus();
            powStructure.kanUpStatus = 0;
            powStructure.kanDownStatus = 0;
            intStructure.kanUpStatus = 0;
            intStructure.kanDownStatus = 0;
            vitStructure.kanUpStatus = 0;
            vitStructure.kanDownStatus = 0;
            spdStructure.kanUpStatus = 0;
            spdStructure.kanDownStatus = 0;
            luckStructure.kanUpStatus = 0;
            luckStructure.kanDownStatus = 0;
            calcStatus();
            calcPureStatus();
            displayStatus();
        }

        private void allReset_Click(object sender, EventArgs e)
        {

            textBox2inputStatus();
            HPStructure.makiStatus = 0;
            HPStructure.eruUp = 0;
            SPStructure.makiStatus = 0;
            SPStructure.eruUp = 0;

            powStructure.bitaStatus = 0;
            powStructure.allBitaStatus = 0;
            intStructure.bitaStatus = 0;
            intStructure.allBitaStatus = 0;
            vitStructure.bitaStatus = 0;
            vitStructure.allBitaStatus = 0;
            spdStructure.bitaStatus = 0;
            spdStructure.allBitaStatus = 0;
            luckStructure.bitaStatus = 0;
            luckStructure.allBitaStatus = 0;

            powStructure.kanUpStatus = 0;
            powStructure.kanDownStatus = 0;
            intStructure.kanUpStatus = 0;
            intStructure.kanDownStatus = 0;
            vitStructure.kanUpStatus = 0;
            vitStructure.kanDownStatus = 0;
            spdStructure.kanUpStatus = 0;
            spdStructure.kanDownStatus = 0;
            luckStructure.kanUpStatus = 0;
            luckStructure.kanDownStatus = 0;

            powStructure.eruUp = 0;
            intStructure.eruUp = 0;
            vitStructure.eruUp = 0;
            spdStructure.eruUp = 0;
            luckStructure.eruUp = 0;
            atkStructure.eruUp = 0;
            defStructure.eruUp = 0;
            matStructure.eruUp = 0;
            mdfStructure.eruUp = 0;

            atkStructure.upStatus = 0;
            defStructure.upStatus = 0;
            matStructure.upStatus = 0;
            mdfStructure.upStatus = 0;

            powStructure.bradScraper = 0;

            powStructure.makiStatus = 0;
            intStructure.makiStatus = 0;
            vitStructure.makiStatus = 0;
            spdStructure.makiStatus = 0;
            luckStructure.makiStatus = 0;
            atkStructure.makiStatus = 0;
            defStructure.makiStatus = 0;
            matStructure.makiStatus = 0;
            mdfStructure.makiStatus = 0;

            atkMakiBox.Text = "ATK巻物";
            matMakiBox.Text = "MAT巻物";
            defMakiBox.Text = "DEF巻物";
            mdfMakiBox.Text = "MDF巻物";
            powMakiBox.Text = "POW巻物";
            intMakiBox.Text = "INT巻物";
            vitMakiBox.Text = "VIT巻物";
            spdMakiBox.Text = "SPD巻物";
            luckMakiBox.Text = "LUK巻物";
            HPMakiBox.Text = "HP巻物";
            SPMakiBox.Text = "SP巻物";

            calcStatus();
            calcPureStatus();
            displayStatus();
        }

        private void kanA_Click(object sender, EventArgs e)
        {

            textBox2inputStatus();

            powStructure.kanUpStatus = 10;
            powStructure.kanDownStatus = 0;
            intStructure.kanUpStatus = 0;
            intStructure.kanDownStatus = 10;
            vitStructure.kanUpStatus = 0;
            vitStructure.kanDownStatus = 0;
            spdStructure.kanUpStatus = 0;
            spdStructure.kanDownStatus = 0;
            luckStructure.kanUpStatus = 0;
            luckStructure.kanDownStatus = 0;

            calcStatus();
            calcPureStatus();
            displayStatus();
        }

        private void kanB_Click(object sender, EventArgs e)
        {

            textBox2inputStatus();

            powStructure.kanUpStatus = 0;
            powStructure.kanDownStatus = 0;
            intStructure.kanUpStatus = 10;
            intStructure.kanDownStatus = 0;
            vitStructure.kanUpStatus = 0;
            vitStructure.kanDownStatus = 10;
            spdStructure.kanUpStatus = 0;
            spdStructure.kanDownStatus = 0;
            luckStructure.kanUpStatus = 0;
            luckStructure.kanDownStatus = 0;

            calcStatus();
            calcPureStatus();
            displayStatus();
        }

        private void powMakiBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2inputStatus();
            HPStructure.makiStatus = 0;
            SPStructure.makiStatus = 0;
            powStructure.makiStatus = int.Parse(powMakiBox.SelectedItem.ToString());
            intStructure.makiStatus = 0;
            vitStructure.makiStatus = 0;
            spdStructure.makiStatus = 0;
            luckStructure.makiStatus = 0;
            atkStructure.makiStatus = 0;
            defStructure.makiStatus = 0;
            matStructure.makiStatus = 0;
            mdfStructure.makiStatus = 0;
            calcStatus();
            calcPureStatus();
            displayStatus();
        }

        private void intMakiBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2inputStatus();
            HPStructure.makiStatus = 0;
            SPStructure.makiStatus = 0;

            powStructure.makiStatus = 0;
            intStructure.makiStatus = int.Parse(intMakiBox.SelectedItem.ToString());
            vitStructure.makiStatus = 0;
            spdStructure.makiStatus = 0;
            luckStructure.makiStatus = 0;
            atkStructure.makiStatus = 0;
            defStructure.makiStatus = 0;
            matStructure.makiStatus = 0;
            mdfStructure.makiStatus = 0;
            calcStatus();
            calcPureStatus();
            displayStatus();
        }

        private void vitMakiBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2inputStatus();
            HPStructure.makiStatus = 0;
            SPStructure.makiStatus = 0;

            powStructure.makiStatus = 0;
            intStructure.makiStatus = 0;
            vitStructure.makiStatus = int.Parse(vitMakiBox.SelectedItem.ToString());
            spdStructure.makiStatus = 0;
            luckStructure.makiStatus = 0;
            atkStructure.makiStatus = 0;
            defStructure.makiStatus = 0;
            matStructure.makiStatus = 0;
            mdfStructure.makiStatus = 0;
            calcStatus();
            calcPureStatus();
            displayStatus();
        }

        private void spdMakiBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2inputStatus();
            HPStructure.makiStatus = 0;
            SPStructure.makiStatus = 0;

            powStructure.makiStatus = 0;
            intStructure.makiStatus = 0;
            vitStructure.makiStatus = 0;
            spdStructure.makiStatus = int.Parse(spdMakiBox.SelectedItem.ToString());
            luckStructure.makiStatus = 0;
            atkStructure.makiStatus = 0;
            defStructure.makiStatus = 0;
            matStructure.makiStatus = 0;
            mdfStructure.makiStatus = 0;
            calcStatus();
            calcPureStatus();
            displayStatus();
        }

        private void luckMakiBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2inputStatus();
            HPStructure.makiStatus = 0;
            SPStructure.makiStatus = 0;

            powStructure.makiStatus = 0;
            intStructure.makiStatus = 0;
            vitStructure.makiStatus = 0;
            spdStructure.makiStatus = 0;
            luckStructure.makiStatus = int.Parse(luckMakiBox.SelectedItem.ToString());
            atkStructure.makiStatus = 0;
            defStructure.makiStatus = 0;
            matStructure.makiStatus = 0;
            mdfStructure.makiStatus = 0;
            calcStatus();
            calcPureStatus();
            displayStatus();
        }

        private void atkMakiBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2inputStatus();
            HPStructure.makiStatus = 0;
            SPStructure.makiStatus = 0;

            powStructure.makiStatus = 0;
            intStructure.makiStatus = 0;
            vitStructure.makiStatus = 0;
            spdStructure.makiStatus = 0;
            luckStructure.makiStatus = 0;
            atkStructure.makiStatus = int.Parse(atkMakiBox.SelectedItem.ToString());
            defStructure.makiStatus = 0;
            matStructure.makiStatus = 0;
            mdfStructure.makiStatus = 0;
            calcStatus();
            calcPureStatus();
            displayStatus();
        }

        private void defMakiBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2inputStatus();
            HPStructure.makiStatus = 0;
            SPStructure.makiStatus = 0;

            powStructure.makiStatus = 0;
            intStructure.makiStatus = 0;
            vitStructure.makiStatus = 0;
            spdStructure.makiStatus = 0;
            luckStructure.makiStatus = 0;
            atkStructure.makiStatus = 0;
            defStructure.makiStatus = int.Parse(defMakiBox.SelectedItem.ToString());
            matStructure.makiStatus = 0;
            mdfStructure.makiStatus = 0;
            calcStatus();
            calcPureStatus();
            displayStatus();
        }

        private void matMakiBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2inputStatus();
            HPStructure.makiStatus = 0;
            SPStructure.makiStatus = 0;

            powStructure.makiStatus = 0;
            intStructure.makiStatus = 0;
            vitStructure.makiStatus = 0;
            spdStructure.makiStatus = 0;
            luckStructure.makiStatus = 0;
            atkStructure.makiStatus = 0;
            defStructure.makiStatus = 0;
            matStructure.makiStatus = int.Parse(matMakiBox.SelectedItem.ToString());
            mdfStructure.makiStatus = 0;
            calcStatus();
            calcPureStatus();
            displayStatus();
        }

        private void mdfMakiBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2inputStatus();
            HPStructure.makiStatus = 0;
            SPStructure.makiStatus = 0;

            powStructure.makiStatus = 0;
            intStructure.makiStatus = 0;
            vitStructure.makiStatus = 0;
            spdStructure.makiStatus = 0;
            luckStructure.makiStatus = 0;
            atkStructure.makiStatus = 0;
            defStructure.makiStatus = 0;
            matStructure.makiStatus = 0;
            mdfStructure.makiStatus = int.Parse(mdfMakiBox.SelectedItem.ToString());
            calcStatus();
            calcPureStatus();
            displayStatus();
        }

        private void powSeal_Click(object sender, EventArgs e)
        {
            textBox2inputStatus();
            powStructure.kanUpStatus = 15;
            powStructure.kanDownStatus = 0;
            intStructure.kanUpStatus = 0;
            intStructure.kanDownStatus = 15;
            vitStructure.kanUpStatus = 0;
            vitStructure.kanDownStatus = 0;
            spdStructure.kanUpStatus = 0;
            spdStructure.kanDownStatus = 0;
            luckStructure.kanUpStatus = 0;
            luckStructure.kanDownStatus = 0;

            calcStatus();
            calcPureStatus();
            displayStatus();
        }

        private void intSeal_Click(object sender, EventArgs e)
        {
            textBox2inputStatus();
            powStructure.kanUpStatus = 0;
            powStructure.kanDownStatus = 15;
            intStructure.kanUpStatus = 15;
            intStructure.kanDownStatus = 0;
            vitStructure.kanUpStatus = 0;
            vitStructure.kanDownStatus = 0;
            spdStructure.kanUpStatus = 0;
            spdStructure.kanDownStatus = 0;
            luckStructure.kanUpStatus = 0;
            luckStructure.kanDownStatus = 0;
            calcStatus();
            calcPureStatus();
            displayStatus();
        }

        private void spdSeal_Click(object sender, EventArgs e)
        {
            textBox2inputStatus();
            powStructure.kanUpStatus = 0;
            powStructure.kanDownStatus = 0;
            intStructure.kanUpStatus = 0;
            intStructure.kanDownStatus = 0;
            vitStructure.kanUpStatus = 0;
            vitStructure.kanDownStatus = 0;
            spdStructure.kanUpStatus = 15;
            spdStructure.kanDownStatus = 0;
            luckStructure.kanUpStatus = 0;
            luckStructure.kanDownStatus = 15;
            calcStatus();
            calcPureStatus();
            displayStatus();
        }

        private void vitSeal_Click(object sender, EventArgs e)
        {
            textBox2inputStatus();
            powStructure.kanUpStatus = 0;
            powStructure.kanDownStatus = 0;
            intStructure.kanUpStatus = 0;
            intStructure.kanDownStatus = 0;
            vitStructure.kanUpStatus = 15;
            vitStructure.kanDownStatus = 0;
            spdStructure.kanUpStatus = 0;
            spdStructure.kanDownStatus = 15;
            luckStructure.kanUpStatus = 0;
            luckStructure.kanDownStatus = 0;

            calcStatus();
            calcPureStatus();
            displayStatus();
        }

        private void luckSeal_Click(object sender, EventArgs e)
        {

            textBox2inputStatus();
            powStructure.kanUpStatus = 0;
            powStructure.kanDownStatus = 0;
            intStructure.kanUpStatus = 0;
            intStructure.kanDownStatus = 0;
            vitStructure.kanUpStatus = 0;
            vitStructure.kanDownStatus = 15;
            spdStructure.kanUpStatus = 0;
            spdStructure.kanDownStatus = 0;
            luckStructure.kanUpStatus = 15;
            luckStructure.kanDownStatus = 0;

            calcStatus();
            calcPureStatus();
            displayStatus();
        }

        /**
         * ブラッドスクレイパー
         */
        private void bradScraper_Click(object sender, EventArgs e)
        {
            textBox2inputStatus();
            powStructure.bradScraper = 9;
            calcStatus();
            calcPureStatus();
            displayStatus();
        }

        /**
         * 大天使の加護
         */
        private void eruWing_Click(object sender, EventArgs e)
        {
            if (!eruWingCheck())
            {
                int selectStatus;

                initEruStatus();

                textBox2inputStatus();
                calcStatus();
                HPStructure.eruUp = HPStructure.totalStatus * 4;
                SPStructure.eruUp = SPStructure.totalStatus * 4;

                powStructure.eruUp = (int)(powStructure.totalStatus * 0.2);
                intStructure.eruUp = (int)(intStructure.totalStatus * 0.2);
                vitStructure.eruUp = (int)(vitStructure.totalStatus * 0.2);
                spdStructure.eruUp = (int)(spdStructure.totalStatus * 0.2);
                luckStructure.eruUp = (int)(luckStructure.totalStatus * 0.2);

                atkStructure.eruUp = (int)((atkStructure.inputStatus - powStructure.inputStatus + atkStructure.makiStatus + (powStructure.totalStatus - powStructure.inputStatus + powStructure.eruUp) * 2) * 0.2);
                matStructure.eruUp = (int)((matStructure.inputStatus + matStructure.makiStatus + (intStructure.totalStatus - intStructure.inputStatus + intStructure.eruUp) * 2) * 0.2);
                defStructure.eruUp = (int)((defStructure.inputStatus + defStructure.makiStatus + (vitStructure.totalStatus - vitStructure.inputStatus + vitStructure.eruUp) * 2) * 0.2);

                if (intStructure.totalStatus + intStructure.eruUp > vitStructure.totalStatus + vitStructure.eruUp)
                {
                    mdfStructure.intGreater = true;
                    selectStatus = intStructure.totalStatus + intStructure.eruUp;
                }
                else
                {
                    mdfStructure.intGreater = false;
                    selectStatus = vitStructure.totalStatus + vitStructure.eruUp;
                }
                mdfStructure.eruUp = (int)((mdfStructure.inputStatus - intStructure.inputStatus * 15 + mdfStructure.makiStatus + selectStatus * 2) * 0.2);

                calcStatus();
                calcPureStatus();
                displayStatus();
            }
        }

        /**
         * 邪神の呪詛
         */
        private void fisCurse_Click(object sender, EventArgs e)
        {
            if (!eruWingCheck())
            {
                initEruStatus();

                textBox2inputStatus();
                calcStatus();
                HPStructure.eruUp = 0;
                SPStructure.eruUp = 0;

                powStructure.eruUp = 0;
                intStructure.eruUp = 0;
                vitStructure.eruUp = 0;
                spdStructure.eruUp = 0;
                luckStructure.eruUp = (int)(luckStructure.totalStatus * 0.3);

                atkStructure.eruUp = 0;
                matStructure.eruUp = 0;
                defStructure.eruUp = 0;
                mdfStructure.eruUp = 0;

                calcStatus();
                calcPureStatus();
                displayStatus();
            }
        }

        /**
         * 祝福の蒼盾
         */
        private void beneWing_Click(object sender, EventArgs e)
        {
            if (!eruWingCheck())
            {
                initEruStatus();

                textBox2inputStatus();
                calcStatus();
                HPStructure.eruUp = 0;
                SPStructure.eruUp = 0;

                powStructure.eruUp = 0;
                intStructure.eruUp = 0;
                vitStructure.eruUp = (int)(vitStructure.totalStatus * 0.3);
                spdStructure.eruUp = 0;
                luckStructure.eruUp = 0;

                atkStructure.eruUp = 0;
                matStructure.eruUp = 0;
                defStructure.eruUp = 0;
                mdfStructure.eruUp = 0;

                calcStatus();
                calcPureStatus();
                displayStatus();
            }
        }

        /**
         * 妖精王の祝福(物理)
         */
        private void fairyPhy_Click(object sender, EventArgs e)
        {
            if (!eruWingCheck())
            {
                initEruStatus();

                textBox2inputStatus();
                calcStatus();
                HPStructure.eruUp = 0;
                SPStructure.eruUp = 0;

                powStructure.eruUp = (int)(powStructure.totalStatus * 0.3);
                intStructure.eruUp = 0;
                vitStructure.eruUp = 0;
                spdStructure.eruUp = 0;
                luckStructure.eruUp =0;

                atkStructure.eruUp = (int)((atkStructure.inputStatus - powStructure.inputStatus + atkStructure.makiStatus + (powStructure.totalStatus - powStructure.inputStatus + powStructure.eruUp) * 2) * 0.3);
                matStructure.eruUp = 0;
                defStructure.eruUp = 0;
                mdfStructure.eruUp = 0;

                calcStatus();
                calcPureStatus();
                displayStatus();
            }
        }

        /**
         * 妖精王の祝福(魔法)
         */
        private void fairyMag_Click(object sender, EventArgs e)
        {
            if (!eruWingCheck())
            {
                initEruStatus();

                textBox2inputStatus();
                calcStatus();
                HPStructure.eruUp = 0;
                SPStructure.eruUp = 0;

                powStructure.eruUp = 0;
                intStructure.eruUp = (int)(intStructure.totalStatus * 0.3);
                vitStructure.eruUp = 0;
                spdStructure.eruUp = 0;
                luckStructure.eruUp = 0;

                atkStructure.eruUp = 0;
                matStructure.eruUp = (int)((matStructure.inputStatus + matStructure.makiStatus + (intStructure.totalStatus - intStructure.inputStatus + intStructure.eruUp) * 2) * 0.3);
                defStructure.eruUp = 0;
                mdfStructure.eruUp = 0;

                calcStatus();
                calcPureStatus();
                displayStatus();
            }
        }

        private void specialSkillReset_Click(object sender, EventArgs e)
        {
            HPStructure.eruUp = 0;
            SPStructure.eruUp = 0;
            powStructure.eruUp = 0;
            intStructure.eruUp = 0;
            vitStructure.eruUp = 0;
            spdStructure.eruUp = 0;
            luckStructure.eruUp = 0;
            atkStructure.eruUp = 0;
            defStructure.eruUp = 0;
            matStructure.eruUp = 0;
            mdfStructure.eruUp = 0;
            calcStatus();
            calcPureStatus();
            displayStatus();
        }

        private void scraperReset_Click(object sender, EventArgs e)
        {
            powStructure.bradScraper = 0;
            calcStatus();
            calcPureStatus();
            displayStatus();
        }

        private void atariki_Click(object sender, EventArgs e)
        {
            if (!atarikiCheck())
            {
                textBox2inputStatus();
                calcStatus();

                int magnified = atkStructure.inputStatus + atkStructure.makiStatus - powStructure.inputStatus * 3 + powStructure.totalStatus * 2;
                int charaLevel = int.Parse(levelInputText.Text);
                double magnif = (powStructure.totalStatus + charaLevel - 100) / 100.0;

                atkStructure.upStatus = (int)(magnified * magnif);
                calcStatus();
                calcPureStatus();
                displayStatus();
            }
        }

        private void mamoriki_Click(object sender, EventArgs e)
        {
            if (!mamorikiCheck())
            {
                textBox2inputStatus();
                calcStatus();

                int magnified = defStructure.inputStatus + defStructure.makiStatus - vitStructure.inputStatus * 2 + vitStructure.totalStatus * 2;
                int charaLevel = int.Parse(levelInputText.Text);
                double magnif = ((vitStructure.totalStatus + charaLevel - 100) / 100.0);

                defStructure.upStatus = (int)(magnified * magnif);
                calcStatus();
                calcPureStatus();
                displayStatus();
            }
        }

        private void mahoata_Click(object sender, EventArgs e)
        {
            if (!mahoataCheck())
            {
                textBox2inputStatus();
                calcStatus();

                int magnified = matStructure.inputStatus + matStructure.makiStatus - intStructure.inputStatus * 2 + intStructure.totalStatus * 2;
                int charaLevel = int.Parse(levelInputText.Text);
                double magnif = (intStructure.totalStatus + charaLevel - 100) / 100.0;

                matStructure.upStatus = (int)(magnified * magnif);
                calcStatus();
                calcPureStatus();
                displayStatus();
            }
        }

        private void mahomamo_Click(object sender, EventArgs e)
        {
            if (!mahomamoCheck())
            {
                textBox2inputStatus();
                calcStatus();

                int magnified;
                int charaLevel = int.Parse(levelInputText.Text);
                double magnifINT = (intStructure.totalStatus + charaLevel - 100) / 100.0;
                double magnifVIT = (vitStructure.totalStatus + charaLevel - 100) / 100.0;

                if (magnifINT >= magnifVIT)
                {
                    magnified = mdfStructure.inputStatus + mdfStructure.makiStatus - intStructure.inputStatus * 15 + intStructure.totalStatus * 2;
                    mdfStructure.upStatus = (int)(magnified * magnifINT);
                }
                else
                {
                    magnified = mdfStructure.inputStatus + mdfStructure.makiStatus - intStructure.inputStatus * 15 + vitStructure.totalStatus * 2;
                    mdfStructure.upStatus = (int)(magnified * magnifVIT);
                }

                calcStatus();
                calcPureStatus();
                displayStatus();
            }
        }

        private void makiReset_Click(object sender, EventArgs e)
        {
            textBox2inputStatus();
            HPStructure.makiStatus = 0;
            SPStructure.makiStatus = 0;
            powStructure.makiStatus = 0;
            intStructure.makiStatus = 0;
            vitStructure.makiStatus = 0;
            spdStructure.makiStatus = 0;
            luckStructure.makiStatus = 0;
            atkStructure.makiStatus = 0;
            defStructure.makiStatus = 0;
            matStructure.makiStatus = 0;
            mdfStructure.makiStatus = 0;

            HPMakiBox.Text = "HP巻物";
            SPMakiBox.Text = "SP巻物";
            atkMakiBox.Text = "ATK巻物";
            matMakiBox.Text = "MAT巻物";
            defMakiBox.Text = "DEF巻物";
            mdfMakiBox.Text = "MDF巻物";
            powMakiBox.Text = "POW巻物";
            intMakiBox.Text = "INT巻物";
            vitMakiBox.Text = "VIT巻物";
            spdMakiBox.Text = "SPD巻物";
            luckMakiBox.Text = "LUK巻物";

            calcStatus();
            calcPureStatus();
            displayStatus();
        }

        private void dpGroup_Enter(object sender, EventArgs e)
        {

        }

        private void liquidReset_Click(object sender, EventArgs e)
        {
            atkStructure.upStatus = 0;
            defStructure.upStatus = 0;
            matStructure.upStatus = 0;
            mdfStructure.upStatus = 0;
            textBox2inputStatus();
            calcStatus();
            calcPureStatus();
            displayStatus();
        }

        private void vitTotalText_TextChanged(object sender, EventArgs e)
        {

        }

        private void spdTotalText_TextChanged(object sender, EventArgs e)
        {

        }

        private void inputLoad_Click(object sender, EventArgs e)
        {
            textBox2inputStatus();
            calcStatus();
            calcPureStatus();
            displayStatus();
        }

        private void manekinShow_Click(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(@"manekins/", "*");
            int index = 0;

            manekinShowLabel.Text = "";
            foreach (string str in files)
            {
                if (index % 2 == 0)
                {
                    manekinShowLabel.Text += str.Split("/")[1].Split(".")[0] + ",    ";
                }
                else
                {
                    manekinShowLabel.Text += str.Split("/")[1].Split(".")[0] + "\r\n";
                }
                index++;
            }
        }

        private void manekinRegister1_Click(object sender, EventArgs e)
        {
            if (!manekinCheck())
            {
                var filename = @"manekins/" + manekinName1.Text + ".txt";
                manekinSave(filename);
            }
        }

        private void manekinInput1_Click(object sender, EventArgs e)
        {
            if (manekinName1.Text != null && manekinName1.Text != "")
            {
                var filename = @"manekins/" + manekinName1.Text + ".txt";
                string[] files = Directory.GetFiles(@"manekins/", "*");
                Boolean fileOpenCheck = false;
                foreach (var item in files)
                {
                    if (filename.Equals(item))
                    {
                        fileOpenCheck = true;
                        break;
                    }
                }

                if (!fileOpenCheck)
                {
                    MessageBox.Show("マネキン名を確認してください");
                }
                else
                {
                    manekinCall(filename);
                }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void manekinRegister2_Click(object sender, EventArgs e)
        {
            if (!manekinCheck())
            {
                var filename = @"manekins/" + manekinName2.Text + ".txt";
                manekinSave(filename);
            }
        }

        private void manekinRegister3_Click(object sender, EventArgs e)
        {
            if (!manekinCheck())
            {
                var filename = @"manekins/" + manekinName3.Text + ".txt";
                manekinSave(filename);
            }
        }

        private void manekinRegister4_Click(object sender, EventArgs e)
        {
            if (!manekinCheck())
            {
                var filename = @"manekins/" + manekinName4.Text + ".txt";
                manekinSave(filename);
            }
        }

        private void manekinRegister5_Click(object sender, EventArgs e)
        {
            if (!manekinCheck())
            {
                var filename = @"manekins/" + manekinName5.Text + ".txt";
                manekinSave(filename);
            }
        }

        private void manekinRegister6_Click(object sender, EventArgs e)
        {
            if (!manekinCheck())
            {
                var filename = @"manekins/" + manekinName6.Text + ".txt";
                manekinSave(filename);
            }
        }

        private void manekinRegister7_Click(object sender, EventArgs e)
        {
            if (!manekinCheck())
            {
                var filename = @"manekins/" + manekinName7.Text + ".txt";
                manekinSave(filename);
            }
        }

        private void manekinRegister8_Click(object sender, EventArgs e)
        {
            if (!manekinCheck())
            {
                var filename = @"manekins/" + manekinName8.Text + ".txt";
                manekinSave(filename);
            }
        }

        private void manekinInput2_Click(object sender, EventArgs e)
        {
            if (manekinName2.Text != null && manekinName2.Text != "")
            {
                var filename = @"manekins/" + manekinName2.Text + ".txt";
                string[] files = Directory.GetFiles(@"manekins/", "*");
                Boolean fileOpenCheck = false;
                foreach (var item in files)
                {
                    if (filename.Equals(item))
                    {
                        fileOpenCheck = true;
                        break;
                    }
                }

                if (!fileOpenCheck)
                {
                    MessageBox.Show("マネキン名を確認してください");
                }
                else
                {
                    manekinCall(filename);
                }

            }
        }

        private void manekinInput3_Click(object sender, EventArgs e)
        {
            if (manekinName3.Text != null && manekinName3.Text != "")
            {
                var filename = @"manekins/" + manekinName3.Text + ".txt";
                string[] files = Directory.GetFiles(@"manekins/", "*");
                Boolean fileOpenCheck = false;
                foreach (var item in files)
                {
                    if (filename.Equals(item))
                    {
                        fileOpenCheck = true;
                        break;
                    }
                }

                if (!fileOpenCheck)
                {
                    MessageBox.Show("マネキン名を確認してください");
                }
                else
                {
                    manekinCall(filename);
                }
            }
        }

        private void manekinInput4_Click(object sender, EventArgs e)
        {
            if (manekinName4.Text != null && manekinName4.Text != "")
            {
                var filename = @"manekins/" + manekinName4.Text + ".txt";
                string[] files = Directory.GetFiles(@"manekins/", "*");
                Boolean fileOpenCheck = false;
                foreach (var item in files)
                {
                    if (filename.Equals(item))
                    {
                        fileOpenCheck = true;
                        break;
                    }
                }

                if (!fileOpenCheck)
                {
                    MessageBox.Show("マネキン名を確認してください");
                }
                else
                {
                    manekinCall(filename);
                }
            }
        }

        private void manekinInput5_Click(object sender, EventArgs e)
        {
            if (manekinName5.Text != null && manekinName5.Text != "")
            {
                var filename = @"manekins/" + manekinName5.Text + ".txt";
                string[] files = Directory.GetFiles(@"manekins/", "*");
                Boolean fileOpenCheck = false;
                foreach (var item in files)
                {
                    if (filename.Equals(item))
                    {
                        fileOpenCheck = true;
                        break;
                    }
                }

                if (!fileOpenCheck)
                {
                    MessageBox.Show("マネキン名を確認してください");
                }
                else
                {
                    manekinCall(filename);
                }
            }
        }

        private void manekinGroup_Enter(object sender, EventArgs e)
        {

        }

        private void manekinInput6_Click(object sender, EventArgs e)
        {
            if (manekinName6.Text != null && manekinName6.Text != "")
            {
                var filename = @"manekins/" + manekinName6.Text + ".txt";
                string[] files = Directory.GetFiles(@"manekins/", "*");
                Boolean fileOpenCheck = false;
                foreach (var item in files)
                {
                    if (filename.Equals(item))
                    {
                        fileOpenCheck = true;
                        break;
                    }
                }

                if (!fileOpenCheck)
                {
                    MessageBox.Show("マネキン名を確認してください");
                }
                else
                {
                    manekinCall(filename);
                }
            }
        }

        private void manekinInput7_Click(object sender, EventArgs e)
        {
            if (manekinName7.Text != null && manekinName7.Text != "")
            {
                var filename = @"manekins/" + manekinName7.Text + ".txt";
                string[] files = Directory.GetFiles(@"manekins/", "*");
                Boolean fileOpenCheck = false;
                foreach (var item in files)
                {
                    if (filename.Equals(item))
                    {
                        fileOpenCheck = true;
                        break;
                    }
                }

                if (!fileOpenCheck)
                {
                    MessageBox.Show("マネキン名を確認してください");
                }
                else
                {
                    manekinCall(filename);
                }
            }
        }

        private void manekinInput8_Click(object sender, EventArgs e)
        {
            if (manekinName8.Text != null && manekinName8.Text != "")
            {
                var filename = @"manekins/" + manekinName8.Text + ".txt";
                string[] files = Directory.GetFiles(@"manekins/", "*");
                Boolean fileOpenCheck = false;
                foreach (var item in files)
                {
                    if (filename.Equals(item))
                    {
                        fileOpenCheck = true;
                        break;
                    }
                }

                if (!fileOpenCheck)
                {
                    MessageBox.Show("マネキン名を確認してください");
                }
                else
                {
                    manekinCall(filename);
                }
            }
        }

        private void HPMakiBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2inputStatus();
            HPStructure.makiStatus = int.Parse(HPMakiBox.SelectedItem.ToString());
            SPStructure.makiStatus = 0;

            powStructure.makiStatus = 0;
            intStructure.makiStatus = 0;
            vitStructure.makiStatus = 0;
            spdStructure.makiStatus = 0;
            luckStructure.makiStatus = 0;
            atkStructure.makiStatus = 0;
            defStructure.makiStatus = 0;
            matStructure.makiStatus = 0;
            mdfStructure.makiStatus = 0;
            calcStatus();
            calcPureStatus();
            displayStatus();
        }

        private void SPMakiBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2inputStatus();
            HPStructure.makiStatus = 0;
            SPStructure.makiStatus = int.Parse(SPMakiBox.SelectedItem.ToString());

            powStructure.makiStatus = 0;
            intStructure.makiStatus = 0;
            vitStructure.makiStatus = 0;
            spdStructure.makiStatus = 0;
            luckStructure.makiStatus = 0;
            atkStructure.makiStatus = 0;
            defStructure.makiStatus = 0;
            matStructure.makiStatus = 0;
            mdfStructure.makiStatus = 0;
            calcStatus();
            calcPureStatus();
            displayStatus();
        }
    }
}



namespace SimpleCalc
{
    using System;
    using System.Collections.Generic;

    static class Calc
    {
        enum Operator
        {
            Unknown,
            Number,
            Alphabet,
            Plus,
            Minus,
            Multi,
            Divide,
            Mod,
            LParen,
            RParen,
            Camma,
            Space,
        }

        class Lexical
        {
            public Operator op;
            public string str;

            public override string ToString() { return $"op={op}, str={str}"; }
        }

        public interface NodeBase
        {
            float Calc(Func<string, List<float>, float> func);
            bool IsCalcable { get; }
            void TabString(List<(int tab, string str)> slist, int tab);
        }

        class NodeNumber : NodeBase
        {
            float value;

            public bool IsCalcable => true;

            public float Calc(Func<string, List<float>, float> func)
            {
                return value;
            }

            public NodeNumber(float value)
            {
                this.value = value;
            }

            public void TabString(List<(int tab, string str)> slist, int tab)
            {
                slist.Add((tab, $"Number:{value}"));
            }
        }

        class NodeNegative : NodeBase
        {
            NodeBase node;
            public bool IsCalcable => node.IsCalcable;

            public float Calc(Func<string, List<float>, float> func)
            {
                return -node.Calc(func);
            }

            public NodeNegative(NodeBase node)
            {
                this.node = node;
            }

            public void TabString(List<(int tab, string str)> slist, int tab)
            {
                slist.Add((tab, "Negative:"));
                node.TabString(slist, tab + 1);
            }
        }

        class NodeFunction : NodeBase
        {
            string funcname;
            List<NodeBase> nodearg = new List<NodeBase>();

            public NodeFunction(string func, List<NodeBase> nodearg)
            {
                this.funcname = func;
                this.nodearg = nodearg;
            }

            public float Calc(Func<string, List<float>, float> func)
            {
                List<float> numberarg = new List<float>();

                if (nodearg != null)
                {
                    foreach (var item in nodearg)
                    {
                        numberarg.Add(item.Calc(func));
                    }
                }

                return func(funcname, numberarg);
            }
            public bool IsCalcable => false;

            public void TabString(List<(int tab, string str)> slist, int tab)
            {
                slist.Add((tab, $"Function: {funcname}"));
                foreach (var node in nodearg)
                {
                    node.TabString(slist, tab + 1);
                }
            }
        }

        class NodeTree : NodeBase
        {
            private Operator op;
            private NodeBase term1;
            private NodeBase term2;

            public NodeTree(Operator op, Calc.NodeBase term1, Calc.NodeBase term2)
            {
                this.op = op;
                this.term1 = term1;
                this.term2 = term2;
            }

            public bool IsCalcable => (term1 == null ? term1.IsCalcable : true) && (term2 == null ? term2.IsCalcable : true);

            public float Calc(Func<string, List<float>, float> func)
            {
                switch (op)
                {
                    case Operator.Plus:
                        return term1.Calc(func) + term2.Calc(func);
                    case Operator.Minus:
                        return term1.Calc(func) - term2.Calc(func);
                    case Operator.Multi:
                        return term1.Calc(func) * term2.Calc(func);
                    case Operator.Divide:
                        return term1.Calc(func) / term2.Calc(func);
                    case Operator.Mod:
                        return term1.Calc(func) % term2.Calc(func);
                }
                return 0;
            }
            public void TabString(List<(int tab, string str)> slist, int tab)
            {
                slist.Add((tab, $"Tree: {op}"));
                term1.TabString(slist, tab + 1);
                term2.TabString(slist, tab + 1);
            }
        }


        class Analyzer
        {
            List<Lexical> unitlist = new List<Lexical>();
            int current = 0;

            public void LexicalAnalysis(string formula)
            {
                unitlist.Clear();

                for (int idx = 0; idx < formula.Length; idx++)
                {
                    char c = formula[idx];
                    Operator op = GetOperator(c);

                    if (op == Operator.Space) continue;
                    if (op == Operator.Unknown) throw new Exception($"unknown letter: {c}");

                    if (op == Operator.Number)
                    {
                        var str = GetContinuity(formula, n => n == Operator.Number, ref idx);
                        unitlist.Add(new Lexical() { op = op, str = str });
                    }
                    else if (op == Operator.Alphabet)
                    {
                        var str = GetContinuity(formula, n => n == Operator.Number || n == Operator.Alphabet, ref idx);
                        unitlist.Add(new Lexical() { op = op, str = str });

                    }
                    else
                    {
                        unitlist.Add(new Lexical() { op = op });
                    }

                }
            }

            private string GetContinuity(string formula, Func<Operator, bool> compare, ref int idx)
            {
                int start = idx;
                for (int i = idx + 1; i < formula.Length; i++)
                {
                    if (!compare(GetOperator(formula[i])))
                    {
                        idx = i - 1;
                        return formula.Substring(start, i - start);
                    }
                }
                idx = formula.Length - 1;
                return formula.Substring(start);
            }

            private Operator GetOperator(char c)
            {
                switch (c)
                {
                    case '+': return Operator.Plus;
                    case '-': return Operator.Minus;
                    case '*': return Operator.Multi;
                    case '/': return Operator.Divide;
                    case '%': return Operator.Mod;
                    case '(': return Operator.LParen;
                    case ')': return Operator.RParen;
                    case ',': return Operator.Camma;
                    case ' ': return Operator.Space;
                    case '\t': return Operator.Space;
                    case '.': return Operator.Number;
                }

                if (Char.IsNumber(c)) return Operator.Number;
                if (Char.IsLetter(c)) return Operator.Alphabet;

                return Operator.Unknown;
            }

            public NodeBase GetExpr()
            {
                var term1 = GetTerm();

                for (; ; )
                {
                    var next = GetNext();
                    if (next == null) return term1;
                    if (next.op == Operator.Plus || next.op == Operator.Minus)
                    {
                        var term2 = GetTerm();
                        term1 = new NodeTree(next.op, term1, term2);
                    }
                    else
                    {
                        break;
                    }
                }
                Unget();
                return term1;
            }

            NodeBase GetTerm()
            {
                var term1 = GetFactor();

                for (; ; )
                {
                    var next = GetNext();
                    if (next == null) return term1;
                    if (next.op == Operator.Multi || next.op == Operator.Divide || next.op == Operator.Mod)
                    {
                        var term2 = GetFactor();
                        term1 = new NodeTree(next.op, term1, term2);
                    }
                    else
                    {
                        break;
                    }
                }
                Unget();
                return term1;
            }

            NodeBase GetFactor()
            {
                var lparen = GetNext();
                if (lparen == null)
                {
                    throw new Exception("式の終端に達しました");
                }

                switch (lparen.op)
                {
                    case Operator.LParen:
                        {
                            var expr = GetExpr();
                            var rparen = GetNext();
                            if (rparen == null || rparen.op == Operator.RParen) return expr;
                            Unget();
                            break;
                        }
                    default:
                        Unget();
                        return GetNumber();
                }
                {
                    throw new Exception("式の終端に達しました");
                }
            }

            NodeBase GetNumber()
            {
                var unit = GetNext();

                switch (unit.op)
                {
                    case Operator.Number:
                        return new NodeNumber(float.Parse(unit.str));
                    case Operator.Alphabet:
                        Unget();
                        return GetFunction();
                    case Operator.Plus:
                        return GetNumber();
                    case Operator.Minus:
                        {
                            var minus = GetNumber();
                            return minus != null ? new NodeNegative(minus) : null;
                        }
                }
                return null;
            }

            private NodeBase GetFunction()
            {
                var funcname = GetNext();
                if (funcname == null || funcname.op != Operator.Alphabet)
                {
                    throw new Exception("関数名がありません");
                }

                var lparen = GetNext();
                if (lparen == null || lparen.op != Operator.LParen)
                {
                    if (lparen != null) Unget();
                    return new NodeFunction(funcname.str, null);
                }

                var arg = new List<NodeBase>();
                for (; ; )
                {
                    var node = GetExpr();
                    if (node == null) return new NodeFunction(funcname.str, arg);
                    arg.Add(node);

                    var end = GetNext();

                    if (end == null || end.op == Operator.RParen)
                    {
                        return new NodeFunction(funcname.str, arg);
                    }
                    if (end.op != Operator.Camma)
                    {
                        throw new Exception("関数内の区切りがカンマではありません");
                    }
                }

            }

            Lexical GetNext()
            {
                if (current < unitlist.Count)
                {
                    return unitlist[current++];
                }
                return null;
            }

            void Unget()
            {
                current--;
            }

        }

        static public NodeBase Analyze(string formula)
        {
            Analyzer analyzer = new Analyzer();

            analyzer.LexicalAnalysis(formula);

            return analyzer.GetExpr();
        }

    }

}
