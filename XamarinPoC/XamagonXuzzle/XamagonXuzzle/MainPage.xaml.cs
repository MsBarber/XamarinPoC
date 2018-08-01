using NBitcoin;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamagonXuzzle
{
    public partial class MainPage : ContentPage
    {

        Key privKey = null;

        public MainPage()
        {
            InitializeComponent();

        }

        void GenerateNewMnemonic(object sender, EventArgs args)
        {

            Mnemonic mnemo = new Mnemonic(Wordlist.English);
            ExtKey hdRoot = mnemo.DeriveExtKey("my password");
            message.Text = mnemo.ToString();
        }

        void GeneratePrivateKey(object sender, EventArgs args)
        {
            privKey = new Key();

            priv.Text = privKey.GetBitcoinSecret(Network.Main).ToString();
        }


        void GenerateAddress(object sender, EventArgs args)
        {
            if (privKey == null)
            {
                addy.Text = "Please generate a private key first.";
                return;
            }

            addy.Text = privKey.PubKey.GetAddress(Network.Main).ToString();
        }
       
    }
}