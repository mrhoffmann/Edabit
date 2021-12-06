using NUnit.Framework;

namespace Edabit.Helpers.Tests
{
    [TestFixture]
    public class EdabitTests
    {
        [Test()]
        [TestCase("I'm gonna ride 'til I can't no more", ExpectedResult = "I'm gonna rwidwe 'twil I can't no morwe owo")]
        public string OwofiedTest(string p1) => Challenge.Owofy(p1);

        [Test()]
        [TestCase("SheWalksToTheBeach", ExpectedResult = "She Walks To The Beach")]
        [TestCase("MarvinTalksTooMuch", ExpectedResult = "Marvin Talks Too Much")]
        [TestCase("TheGreatestUpsetInHistory", ExpectedResult = "The Greatest Upset In History")]
        public string WhiteSpaceTest(string p0) => Challenge.WhiteSpace(p0);

        [Test()]
        [TestCase("There is a bomb", ExpectedResult = "Duck!!!")]
        [TestCase("Hey, did you think there is a bomb?", ExpectedResult = "Duck!!!")]
        [TestCase("I love that there is no b*mb", ExpectedResult = "There is no bomb, relax.")]
        public string BombTest(string p0) => Challenge.Bomb(p0);

        [Test()]
        [TestCase("192.168.1.1", ExpectedResult = true)]
        [TestCase("1.1.1.1", ExpectedResult = true)]
        [TestCase("092.168.0.1", ExpectedResult = false)]
        [TestCase("192.068.0.1", ExpectedResult = false)]
        [TestCase("255.255.255.0.0", ExpectedResult = false)]
        [TestCase("192.068.1", ExpectedResult = false)]
        [TestCase("192.068.0.0", ExpectedResult = false)]
        [TestCase("255.255.255.1", ExpectedResult = true)]
        [TestCase("192.068.0.256", ExpectedResult = false)]
        [TestCase("1.0.0.1", ExpectedResult = false)]
        [TestCase("0.0.0.1", ExpectedResult = false)]
        [TestCase("10.20.0.113", ExpectedResult = false)]
        [TestCase("1.1.1.1", ExpectedResult = true)]
        public bool VerifyIPV4Test(string p0) => Challenge.IsValidIP(p0);

        [Test()]
        [TestCase(ExpectedResult = 3)]
        public int LetterCounterTest() => Challenge.LetterCounter(new string[5][] {
                new string[]{ "D", "E", "Y", "H", "A", "D" },
                new string[]{ "C", "B", "Z", "Y", "J", "K" },
                new string[]{ "D", "B", "C", "A", "M", "N" },
                new string[]{ "F", "G", "G", "R", "S", "R" },
                new string[]{ "V", "X", "H", "A", "S", "S" } }, "D");

        [Test()]
        [TestCase(new int[] { 2, -1, 4, 8, 10 }, ExpectedResult = 25)]
        [TestCase(new int[] { -3, -4, -10, -2, -3 }, ExpectedResult = 22)]
        [TestCase(new int[] { 2, 4, 6, 8, 10 }, ExpectedResult = 30)]
        [TestCase(new int[] { -1 }, ExpectedResult = 1)]
        public int GetAbsValueTest(int[] haystack) => Challenge.GetAbsValue(haystack);

        [Test()]
        [TestCase(0, ExpectedResult = new int[] { })]
        [TestCase(1, ExpectedResult = new int[] { 1 })]
        public object SquarePatchEmptyTest(int p0) => Challenge.SquarePatch(p0);

        [Test()]
        public void SquarePatchMultiDimensionalArrayWithFivesTest()
        {
            Assert.AreEqual(Challenge.SquarePatch(5),
                new int[][] {
                new int[] { 5, 5, 5, 5, 5 },
                new int[] { 5, 5, 5, 5, 5 },
                new int[] { 5, 5, 5, 5, 5 },
                new int[] { 5, 5, 5, 5, 5 },
                new int[] { 5, 5, 5, 5, 5 } });
        }

        [Test()]
        [TestCase("#08fc1d", ExpectedResult = true)]
        [TestCase("#08fc1d", ExpectedResult = true)]
        [TestCase("#917f04", ExpectedResult = true)]
        [TestCase("#917f04", ExpectedResult = true)]
        [TestCase("#1923f0", ExpectedResult = true)]
        [TestCase("#1923f0", ExpectedResult = true)]
        [TestCase("#76895c", ExpectedResult = true)]
        [TestCase("#08fu1d", ExpectedResult = false)]
        [TestCase("#08fp1d", ExpectedResult = false)]
        [TestCase("#d2f0ce", ExpectedResult = true)]
        [TestCase("#91of04", ExpectedResult = false)]
        [TestCase("#c40377", ExpectedResult = true)]
        [TestCase("#c40377", ExpectedResult = true)]
        [TestCase("#9qjf04", ExpectedResult = false)]
        [TestCase("#1ö23f0", ExpectedResult = false)]
        [TestCase("#192ef0e", ExpectedResult = false)]
        [TestCase("#76ä95c", ExpectedResult = false)]
        [TestCase("#d2f0ce", ExpectedResult = true)]
        [TestCase("#76w95c", ExpectedResult = false)]
        [TestCase("#d2h0ce", ExpectedResult = false)]
        [TestCase("#d2fhce", ExpectedResult = false)]
        [TestCase("#c40v77", ExpectedResult = false)]
        [TestCase("#c4y377", ExpectedResult = false)]
        [TestCase("#76895c", ExpectedResult = true)]
        public bool ValidHexCodeOfValidHexesTest(string p0) => Challenge.ValidHexCode(p0);

        [Test()]
        [TestCase(43, 15, 87, ExpectedResult = true)]
        [TestCase(88, 37, 17, ExpectedResult = true)]
        public bool CarsTest(int p0, int p1, int p2) => Challenge.Cars(p0, p1, p2) > 0;

        [Test()]
        public void TicTacToeTest()
        {
            Assert.AreEqual(Challenge.TicTacToe(
                new char[][] {
                    new char[] { 'x', 'x', 'o' },
                    new char[] { 'o', 'x', 'x' },
                    new char[] { 'o', 'o', 'o' }
                }
            ), "Player 1 won");

            Assert.AreEqual(Challenge.TicTacToe(
                new char[][] {
                    new char[] { 'x', 'x', 'x' },
                    new char[] { 'o', 'o', 'x' },
                    new char[] { 'o', 'x', 'o' }
                }
            ), "Player 2 won");
        }

        [Test()]
        [TestCase("##########",         ExpectedResult = false)]
        [TestCase("# #",                ExpectedResult = true)]
        [TestCase("##",                 ExpectedResult = false)]
        [TestCase("#### ######",        ExpectedResult = true)]
        [TestCase("########### ####",   ExpectedResult = true)]
        [TestCase("###############",    ExpectedResult = false)]
        public bool BrokenBridgeTest(string p0) => Challenge.BrokenBridge(p0);

        [Test()]
        [TestCase(new int[] { 1, 2, 3, 4 }, ExpectedResult = new int[] { 1, 3, 6, 10 })]
        [TestCase(new int[] { 1, 5, 7 }, ExpectedResult = new int[] { 1, 6, 13 })]
        [TestCase(new int[] { 1, 0, 1, 0, 1 }, ExpectedResult = new int[] { 1, 1, 2, 2, 3 })]
        [TestCase(new int[] { }, ExpectedResult = new int[] { })]
        public int[] AccumulatingArrayTest(int[] p0) => Challenge.AccumulatingArray(p0);

        [Test()]
        [TestCase("javascript", ExpectedResult = true)]
        [TestCase("JAVACRIPT", ExpectedResult = false)]
        [TestCase("12321313", ExpectedResult = false)]
        [TestCase("", ExpectedResult = false)]
        [TestCase("i have spaces", ExpectedResult = true)]
        [TestCase("i have numbers(1-10)", ExpectedResult = false)]
        public bool LettersOnlyTest(string p0) => Challenge.LettersOnly(p0);

        [Test()]
        [TestCase("A4B5C2", ExpectedResult = "AAAABBBBBCC")]
        [TestCase("C2F1E5", ExpectedResult = "CCFEEEEE")]
        [TestCase("T4S2V2", ExpectedResult = "TTTTSSVV")]
        [TestCase("A1B2C3D4", ExpectedResult = "ABBCCCDDDD")]
        public string ReverseLetterTest(string p0) => Challenge.ReverseCodingChallengeNumber1(p0);

        [Test()]
        [TestCase(9, ExpectedResult = "Burrrrrrrrrp")]
        [TestCase(73, ExpectedResult = "Burrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrp")]
        public string LongBurpTest(int p0) => Challenge.LongBurp(p0);

        [Test()]
        [TestCase("Always-Look-on-the-Bright-Side-of-Life", 5, ExpectedResult = "Fqbfdx-Qttp-ts-ymj-Gwnlmy-Xnij-tk-Qnkj")]
        [TestCase("A friend in need is a friend indeed", 20, ExpectedResult = "U zlcyhx ch hyyx cm u zlcyhx chxyyx")]
        public string CaesarCipherTest(string p0, int p1) => Challenge.CaesarCipher(p0, p1);

        [Test()]
        [TestCase("ABCD", ExpectedResult = "ABCD")]
        [TestCase("AB[3CD]", ExpectedResult = "ABCDCDCD")]
        [TestCase("AB[1C]", ExpectedResult = "ABC")]
        [TestCase("IF[2E]LG[5O]D", ExpectedResult = "IFEELGOOOOOD")]
        [TestCase("IF[50E]LG[5O]D", ExpectedResult = "IFEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEELGOOOOOD")]
        [TestCase("SH[2O]P DA W[2O]P", ExpectedResult = "SHOOP DA WOOP")]
        public string SpaceMessageTest(string p0) => Challenge.SpaceMessage(p0);

        [Test()]
        [TestCase(1, ExpectedResult = "January")]
        [TestCase(2, ExpectedResult = "February")]
        [TestCase(3, ExpectedResult = "March")]
        [TestCase(4, ExpectedResult = "April")]
        [TestCase(5, ExpectedResult = "May")]
        [TestCase(6, ExpectedResult = "June")]
        [TestCase(7, ExpectedResult = "July")]
        [TestCase(8, ExpectedResult = "August")]
        [TestCase(9, ExpectedResult = "September")]
        [TestCase(10, ExpectedResult = "October")]
        [TestCase(11, ExpectedResult = "November")]
        [TestCase(12, ExpectedResult = "December")]
        public string MonthNameTest(int p0) => Challenge.MonthName(p0-1);

        [Test()]
        [TestCase(22, 15, ExpectedResult = true)]
        [TestCase(83, 34, ExpectedResult = false)]
        [TestCase(3, 77, ExpectedResult = true)]
        public bool LessThan100Test(int p0, int p1) => Challenge.LessThan100(p0, p1);

        [Test()]
        [TestCase(1, 3, ExpectedResult = 1)]
        [TestCase(3, 4, ExpectedResult = 3)]
        [TestCase(-9, 45, ExpectedResult = -9)]
        [TestCase(5, 5, ExpectedResult = 0)]
        public int RemainderTest(int p0, int p1) => Challenge.Remainder(p0, p1);

        [Test()]
        [TestCase(7, 5, ExpectedResult = new int[] { 7, 14, 21, 28, 35 })]
        [TestCase(12, 10, ExpectedResult = new int[] { 12, 24, 36, 48, 60, 72, 84, 96, 108, 120 })]
        [TestCase(17, 6, ExpectedResult = new int[] { 17, 34, 51, 68, 85, 102 })]
        public int[] ArrayOfMultiplesTest(int p0, int p1) => Challenge.ArrayOfMultiples(p0, p1);

        [Test()]
        [TestCase(new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, -11, -12, -13, -14, -15}, ExpectedResult = new int[] { 10, -65 })]
        [TestCase(new double[] { 92, 6, 73, -77, 81, -90, 99, 8, -85, 34 }, ExpectedResult = new int[] { 7, -252 })]
        [TestCase(new double[] { 91, -4, 80, -73, -28 }, ExpectedResult = new int[] { 2, -105 })]
        [TestCase(new double[] { }, ExpectedResult = new int[] { })]
        public int[] CountPosSumNeg(double[] p0) => Challenge.CountPosSumNeg(p0);

        [Test()]
        public void FindLargestTest()
        {
            Assert.AreEqual(new double[] { 7, 90, 2 }, Challenge.FindLargest(new double[][] { new double[] { 4, 2, 7, 1 }, new double[] { 20, 70, 40, 90 }, new double[] { 1, 2, 0 } }));
            Assert.AreEqual(new double[] { 0.7634, 9.32, 9 }, Challenge.FindLargest(new double[][] { new double[] { 0.4321, 0.7634, 0.652 }, new double[] { 1.324, 9.32, 2.5423 }, new double[] { 9, 3, 6, 3 } }));
            Assert.AreEqual(new double[] { -34, -2, 7 }, Challenge.FindLargest(new double[][] { new double[] { -34, -54, -74 }, new double[] { -32, -2, -65 }, new double[] { -54, 7, -43 } }));
            Assert.AreEqual(new double[] { 1.34, -1.762, 65 }, Challenge.FindLargest(new double[][] { new double[] { 0.34, -5, 1.34 }, new double[] { -6.432, -1.762, -1.99 }, new double[] { 32, 65, -6 } }));
            Assert.AreEqual(new double[] { 0, 3, -2 }, Challenge.FindLargest(new double[][] { new double[] { 0, 0, 0, 0 }, new double[] { 3, 3, 3, 3 }, new double[] { -2, -2 } }));
        }

        [Test()]
        [TestCase(2, ExpectedResult = 3)]
        [TestCase(-9,ExpectedResult = -8)]
        [TestCase(0, ExpectedResult = 1)]
        [TestCase(100, ExpectedResult = 101)]
        [TestCase(999, ExpectedResult = 1000)]
        [TestCase(73, ExpectedResult = 74)]
        public int AdditionTest(int num) => Challenge.Addition(num);

        [Test()]
        [TestCase(2, ExpectedResult = 1)]
        [TestCase(3, ExpectedResult = 7)]
        [TestCase(10, ExpectedResult = 6)]
        [TestCase(6, ExpectedResult = 8)]
        [TestCase(345, ExpectedResult = 125)]
        [TestCase(72, ExpectedResult = 22)]
        public int FixedTest(int num) => Challenge.Collatz(num);

        [Test()]
        [TestCase(2, 3, ExpectedResult = 5)]
        [TestCase(-3, -6, ExpectedResult = -9)]
        [TestCase(7, 3, ExpectedResult = 10)]
        public int AdditionsTest(int p0, int p1) => Challenge.Addition(p0, p1);

        [Test()]
        [TestCase("1/2", ExpectedResult = false)]
        [TestCase("7/4", ExpectedResult = true)]
        [TestCase("10/10", ExpectedResult = false)]
        [TestCase("12/30", ExpectedResult = false)]
        [TestCase("28/3", ExpectedResult = true)]
        [TestCase("35/31", ExpectedResult = true)]
        [TestCase("11/27", ExpectedResult = false)]
        [TestCase("42/32", ExpectedResult = true)]
        [TestCase("34/15", ExpectedResult = true)]
        [TestCase("16/16", ExpectedResult = false)]
        [TestCase("38/41", ExpectedResult = false)]
        [TestCase("45/43", ExpectedResult = true)]
        [TestCase("13/38", ExpectedResult = false)]
        [TestCase("43/2", ExpectedResult = true)]
        [TestCase("16/31", ExpectedResult = false)]
        [TestCase("41/15", ExpectedResult = true)]
        [TestCase("2/38", ExpectedResult = false)]
        [TestCase("37/21", ExpectedResult = true)]
        public bool GreaterThanOneTest(string a) => Challenge.GreaterThanOne(a);

        [Test()]
        [TestCase("Happy Birthday", ExpectedResult = "hAPPY bIRTHDAY")]
        [TestCase("MANY THANKS", ExpectedResult = "many thanks")]
        [TestCase("sPoNtAnEoUs", ExpectedResult = "SpOnTaNeOuS")]
        [TestCase("eXCELLENT, yOuR mAJESTY", ExpectedResult = "Excellent, YoUr Majesty")]
        public string ReverseCase(string str) => Challenge.ReverseCase(str);

        [Test()]
        [TestCase("4 5 29 54 4 0 -214 542 -64 1 -3 6 -6", ExpectedResult = "542 -214")]
        [TestCase("1 -1", ExpectedResult = "1 -1")]
        [TestCase("-1 -1", ExpectedResult = "-1 -1")]
        [TestCase("1 -1 0", ExpectedResult = "1 -1")]
        [TestCase("1 1 0", ExpectedResult = "1 0")]
        [TestCase("-1 -1 0", ExpectedResult = "0 -1")]
        [TestCase("42", ExpectedResult = "42 42")]
        [TestCase("1 1", ExpectedResult = "1 1")]
        public string FixedTest(string str) => Challenge.HighLow(str);

        [Test()]
        [TestCase(23, ExpectedResult = false)]
        [TestCase(9562, ExpectedResult = false)]
        [TestCase(10019, ExpectedResult = false)]
        [TestCase(1, ExpectedResult = true)]
        [TestCase(3223, ExpectedResult = true)]
        [TestCase(95559, ExpectedResult = true)]
        [TestCase(66566, ExpectedResult = true)]
        public bool IsSymmetricalTest(int num) => Challenge.IsSymmetrical(num);

        [Test()]
        public void ParseArrayTest()
        {
            Assert.AreEqual(new string[] { "1", "2", "a", "b" }, Challenge.ParseArray(new object[] { 1, 2, "a", "b" }));
            Assert.AreEqual(new string[] { "a", "b", "10", "115" }, Challenge.ParseArray(new object[] { "a", "b", 10, 115 }));
            Assert.AreEqual(new string[] { }, Challenge.ParseArray(new object[] { }));
            Assert.AreEqual(new string[] { "-4", "k", "0" }, Challenge.ParseArray(new object[] { -4, "k", 0 }));
            Assert.AreEqual(new string[] { "Hell000!", "5" }, Challenge.ParseArray(new object[] { "Hell000!", 5 }));
        }

        [Test()]
        [TestCase("1234", ExpectedResult = true)]
        [TestCase("12345", ExpectedResult = false)]
        [TestCase("a234", ExpectedResult = false)]
        [TestCase("", ExpectedResult = false)]
        [TestCase("%234", ExpectedResult = false)]
        [TestCase("`234", ExpectedResult = false)]
        [TestCase("@234", ExpectedResult = false)]
        [TestCase("#234", ExpectedResult = false)]
        [TestCase("$234", ExpectedResult = false)]
        [TestCase("*234", ExpectedResult = false)]
        [TestCase("5678", ExpectedResult = true)]
        [TestCase("^234", ExpectedResult = false)]
        [TestCase("(234", ExpectedResult = false)]
        [TestCase(")234", ExpectedResult = false)]
        [TestCase("123456", ExpectedResult = true)]
        [TestCase("-234", ExpectedResult = false)]
        [TestCase("_234", ExpectedResult = false)]
        [TestCase("+234", ExpectedResult = false)]
        [TestCase("=234", ExpectedResult = false)]
        [TestCase("?234", ExpectedResult = false)]
        public bool ValidatePINTest(string pin) => Challenge.ValidatePIN(pin);

        [Test()]
        [TestCase(838, ExpectedResult = true)]
        [TestCase(77, ExpectedResult = true)]
        [TestCase(95159, ExpectedResult = true)]
        [TestCase(839, ExpectedResult = false)]
        [TestCase(4234, ExpectedResult = false)]
        [TestCase(13, ExpectedResult = false)]
        public bool IsPalindromeTest(int num) => Challenge.IsPalindrome(num);

        [Test]
        [TestCase("4556364607935616", ExpectedResult = "############5616")]
        [TestCase("64607935616", ExpectedResult = "#######5616")]
        [TestCase("1", ExpectedResult = "1")]
        [TestCase("", ExpectedResult = "")]
        [TestCase("tBy>L/cMe+?<j:6n;C~H", ExpectedResult = "################;C~H")]
        [TestCase("12", ExpectedResult = "12")]
        [TestCase("8Ikhlf6yoxPOwi5cB014eWbRumj7vJ", ExpectedResult = "##########################j7vJ")]
        [TestCase("123", ExpectedResult = "123")]
        [TestCase(")E$aCU=e\"_", ExpectedResult = "######=e\"_")]
        [TestCase("2673951408", ExpectedResult = "######1408")]
        [TestCase("1234", ExpectedResult = "1234")]
        public string MaskifyTest(string str) => Challenge.Maskify(str);

        [Test()]
        [TestCase(new int[] { 2, 6, 7, 9, 3 }, ExpectedResult = "Boom!")]
        [TestCase(new int[] { 33, 68, 400, 5 }, ExpectedResult = "there is no 7 in the array")]
        [TestCase(new int[] { 86, 48, 100, 66 }, ExpectedResult = "there is no 7 in the array")]
        [TestCase(new int[] { 76, 55, 44, 32 }, ExpectedResult = "Boom!")]
        [TestCase(new int[] { 35, 4, 9, 37 }, ExpectedResult = "Boom!")]
        public string Seven_Boom(int[] arr) => Challenge.SevenBoom(arr);

        [Test()]
        [TestCase(new int[] { 5, 1, 4, 3, 2 }, ExpectedResult = true)]
        [TestCase(new int[] { 55, 59, 58, 56, 57 }, ExpectedResult = true)]
        [TestCase(new int[] { -3, -2, -1, 1, 0 }, ExpectedResult = true)]
        [TestCase(new int[] { 5, 1, 4, 3, 2, 8 }, ExpectedResult = false)]
        [TestCase(new int[] { 5, 6, 7, 8, 9, 9 }, ExpectedResult = false)]
        [TestCase(new int[] { 5, 3 }, ExpectedResult = false)]
        public bool Cons(int[] arr)
        {
            return Challenge.ConsecutiveNumbers(arr);
        }
    }
}