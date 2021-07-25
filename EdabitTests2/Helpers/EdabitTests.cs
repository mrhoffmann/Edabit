using Edabit.Helpers;
using NUnit.Framework;
using System.Diagnostics;

namespace Edabit.Helpers.Tests
{
    [TestFixture]
    public class EdabitTests
    {
        [Test()]
        public void OwofiedTest()
        {
            Assert.That(Challenge.Owofy("I'm gonna ride 'til I can't no more"), Is.EqualTo("I'm gonna rwidwe 'twil I can't no morwe owo"));
        }

        [Test()]
        [TestCase("SheWalksToTheBeach", "She Walks To The Beach")]
        [TestCase("MarvinTalksTooMuch", "Marvin Talks Too Much")]
        [TestCase("TheGreatestUpsetInHistory", "The Greatest Upset In History")]
        public void WhiteSpaceTest(string p0, string p1)
        {
            Assert.That(Challenge.WhiteSpace(p0), Is.EqualTo(p1));
        }

        [Test()]
        [TestCase("There is a bomb")]
        [TestCase("Hey, did you think there is a bomb?")]
        public void BombTest(string p0)
        {
            Assert.That(Challenge.Bomb(p0), Is.EqualTo("Duck!!!"));
        }

        [Test()]
        [TestCase("This goes boom!!!")]
        public void FailBombTest(string p0)
        {
            Assert.That(Challenge.Bomb(p0), Is.EqualTo("There is no bomb, relax."));
        }

        [Test()]
        [TestCase("192.168.1.1")]
        [TestCase("1.1.1.1")]
        [TestCase("255.255.255.1")]
        [TestCase("1.1.1.1")]
        public void VerifyIPV4Test(string p0)
        {
            Assert.That(Challenge.IsValidIP(p0), Is.True);
        }

        [Test()]
        [TestCase("092.168.0.1")]
        [TestCase("192.068.0.1")]
        [TestCase("255.255.255.0.0")]
        [TestCase("192.068.1")]
        [TestCase("192.068.0.0")]
        [TestCase("192.068.0.256")]
        [TestCase("1.0.0.1")]
        [TestCase("0.0.0.1")]
        [TestCase("10.20.0.113")]
        public void FailVerifyIPV4Test(string p0)
        {
            Assert.That(Challenge.IsValidIP(p0), Is.False);
        }

        [Test()]
        public void LetterCounterTest()
        {
            var items = new string[5][] {
                new string[]{ "D", "E", "Y", "H", "A", "D" },
                new string[]{ "C", "B", "Z", "Y", "J", "K" },
                new string[]{ "D", "B", "C", "A", "M", "N" },
                new string[]{ "F", "G", "G", "R", "S", "R" },
                new string[]{ "V", "X", "H", "A", "S", "S" } };
            Assert.That(Challenge.LetterCounter(items, "D"), Is.EqualTo(3));

            /*var items = new string[5][] {
                new string[]{"D", "E", "Y", "H", "A", "D" },
                new string[]{"C", "B", "Z", "Y", "J", "K" },
                new string[]{"D", "B", "C", "A", "M", "N" },
                new string[]{"F", "G", "G", "R", "S", "R" },
                new string[]{"V", "X", "H", "A", "S", "S" } };
            Assert.That(StringHelpers.LetterCounter(items, "H"), Is.EqualTo(2));*/
        }

        [Test()]
        [TestCase(new int[] { 2, -1, 4, 8, 10 }, 25)]
        [TestCase(new int[] { -3, -4, -10, -2, -3 }, 22)]
        [TestCase(new int[] { 2, 4, 6, 8, 10 }, 30)]
        [TestCase(new int[] { -1 }, 1)]
        public void GetAbsValueTest(int[] haystack, int expect)
        {
            Assert.That(Challenge.GetAbsValue(haystack), Is.EqualTo(expect));
        }

        [Test()]
        public void SquarePatchEmptyTest()
        {
            Assert.That(Challenge.SquarePatch(0), Is.EqualTo(new int[] { }));
        }

        [Test()]
        public void SquarePatchTest()
        {
            Assert.That(Challenge.SquarePatch(1), Is.EqualTo(new int[] { 1 }));
        }

        [Test()]
        public void SquarePatchMultiDimensionalArrayWithTwosTest()
        {
            Assert.That(Challenge.SquarePatch(2), Is.EqualTo(new int[][] { new int[] { 2, 2 }, new int[] { 2, 2 } }));
        }

        [Test()]
        public void SquarePatchMultiDimensionalArrayWithFivesTest()
        {
            Assert.That(Challenge.SquarePatch(5), Is.EqualTo(
                new int[][] {
                new int[] { 5, 5, 5, 5, 5 },
                new int[] { 5, 5, 5, 5, 5 },
                new int[] { 5, 5, 5, 5, 5 },
                new int[] { 5, 5, 5, 5, 5 },
                new int[] { 5, 5, 5, 5, 5 } }));
        }

        [Test()]
        [TestCase("#08fc1d")]
        [TestCase("#08fc1d")]
        [TestCase("#917f04")]
        [TestCase("#917f04")]
        [TestCase("#1923f0")]
        [TestCase("#1923f0")]
        [TestCase("#76895c")]
        [TestCase("#76895c")]
        [TestCase("#d2f0ce")]
        [TestCase("#d2f0ce")]
        [TestCase("#c40377")]
        [TestCase("#c40377")]
        public void ValidHexCodeOfValidHexesTest(string p0)
        {
            Assert.That(Challenge.ValidHexCode(p0), Is.True);
        }

        [Test()]
        [TestCase("#08fu1d")]
        [TestCase("#08fp1d")]
        [TestCase("#91of04")]
        [TestCase("#9qjf04")]
        [TestCase("#1ö23f0")]
        [TestCase("#192ef0e")]
        [TestCase("#76ä95c")]
        [TestCase("#76w95c")]
        [TestCase("#d2h0ce")]
        [TestCase("#d2fhce")]
        [TestCase("#c40v77")]
        [TestCase("#c4y377")]
        public void ValidHexCodeOfInvalidHexesTest(string p0)
        {
            Assert.That(Challenge.ValidHexCode(p0), Is.False);
        }

        [Test()]
        [TestCase(43, 15, 87)]
        [TestCase(88, 37, 17)]
        public void CarsTest(int p0, int p1, int p2)
        {
            Assert.That(Challenge.Cars(p0, p1, p2), Is.GreaterThan(0));
        }

        [Test()]
        public void TicTacToeTest()
        {
            Assert.That(Challenge.TicTacToe(
                new char[][] {
                    new char[] { 'x', 'x', 'o' },
                    new char[] { 'o', 'x', 'x' },
                    new char[] { 'o', 'o', 'o' }
                }
            ), Is.EqualTo("Player 1 won"));

            Assert.That(Challenge.TicTacToe(
                new char[][] {
                    new char[] { 'x', 'x', 'x' },
                    new char[] { 'o', 'o', 'x' },
                    new char[] { 'o', 'x', 'o' }
                }
            ), Is.EqualTo("Player 2 won"));
        }

        [Test()]
        [TestCase("##########")]
        [TestCase("##")]
        [TestCase("###############")]
        public void BrokenBridgeTest(string p0)
        {
            Assert.That(Challenge.BrokenBridge(p0), Is.False);
        }

        [Test()]
        [TestCase("#### ######")]
        [TestCase("# #")]
        [TestCase("########### ####")]
        public void BrokenBridgeShouldFailTest(string p0)
        {
            Assert.That(Challenge.BrokenBridge(p0), Is.True);
        }

        [Test()]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 3, 6, 10 })]
        [TestCase(new int[] { 1, 5, 7 }, new int[] { 1, 6, 13 })]
        [TestCase(new int[] { 1, 0, 1, 0, 1 }, new int[] { 1, 1, 2, 2, 3 })]
        [TestCase(new int[] { }, new int[] { })]
        public void AccumulatingArrayTest(int[] p0, int[] p1)
        {
            Assert.That(Challenge.AccumulatingArray(p0), Is.EqualTo(p1));
        }

        [Test()]
        [TestCase("javascript")]
        [TestCase("i have spaces")]
        public void LettersOnlyTest(string p0)
        {
            Assert.That(Challenge.LettersOnly(p0), Is.True);
        }

        [Test()]
        [TestCase("JAVACRIPT")]
        [TestCase("12321313")]
        [TestCase("i have numbers(1-10)")]
        [TestCase("")]
        public void LettersOnlyThatShouldFailTest(string p0)
        {
            Assert.That(Challenge.LettersOnly(p0), Is.False);
        }

        [Test()]
        [TestCase("A4B5C2", "AAAABBBBBCC")]
        [TestCase("C2F1E5", "CCFEEEEE")]
        [TestCase("T4S2V2", "TTTTSSVV")]
        [TestCase("A1B2C3D4", "ABBCCCDDDD")]
        public void ReverseLetterTest(string p0, string p1)
        {
            Assert.That(Challenge.ReverseCodingChallengeNumber1(p0), Is.EqualTo(p1));
        }

        [Test()]
        [TestCase(9)]
        [TestCase(70)]
        public void LongBurpTest(int p0)
        {
            Assert.That(Challenge.LongBurp(p0).Length, Is.EqualTo(p0 + 3));
        }

        [Test()]
        [TestCase("Always-Look-on-the-Bright-Side-of-Life", 5, "Fqbfdx-Qttp-ts-ymj-Gwnlmy-Xnij-tk-Qnkj")]
        [TestCase("A friend in need is a friend indeed", 20, "U zlcyhx ch hyyx cm u zlcyhx chxyyx")]
        public void CaesarCipherTest(string p0, int p1, string p2)
        {
            Assert.That(Challenge.CaesarCipher(p0, p1), Is.EqualTo(p2));
        }

        [Test()]
        [TestCase("557 Farmer Rd Corner, MT 59105", new string[]{"557", "Farmer Rd", "Corner", "MT", "59105"})]
        [TestCase("3315 Vanity St Beverly Hills, CA 90210", new string[] { "3315", "Vanity St", "Beverly Hills", "CA", "90210" })]
        [TestCase("8919 Scarecrow Ct Idaho Falls, ID 80193", new string[] { "8919", "Scarecrow Ct", "Idaho Falls", "ID", "80193" })]
        public void DecomposeAddressTest(string p0, string[] p1)
        {
            Assert.That(Challenge.DecomposeAddress(p0), Is.EqualTo(p1));
        }

        [Test()]
        [TestCase("ABCD", "ABCD")]
        [TestCase("AB[3CD]", "ABCDCDCD")]
        [TestCase("AB[1C]", "ABC")]
        [TestCase("IF[2E]LG[5O]D", "IFEELGOOOOOD")]
        [TestCase("IF[50E]LG[5O]D", "IFEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEELGOOOOOD")]
        [TestCase("SH[2O]P DA W[2O]P", "SHOOP DA WOOP")]
        public void SpaceMessageTest(string p0, string p1)
        {
            Assert.That(Challenge.SpaceMessage(p0), Is.EqualTo(p1));
        }
    }
}