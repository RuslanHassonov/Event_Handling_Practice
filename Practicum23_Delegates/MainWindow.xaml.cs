using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practicum23_Delegates_Strings
{
    public delegate void SenderCreationEventHandler(object sender, SenderCreationEventArgs args);
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public event SenderCreationEventHandler NewSender;
        private List<Sender> listSenders = new List<Sender>();

        public MainWindow()
        {
            InitializeComponent();
        }

        public void CommunicationOccured(object sender, CommunicationEventArgs args)
        {
            listBoxCommunicatie.Items.Add(args.DateTimeLog.ToString() + " From: " + args.Sender + " To: " + args.Receiver);
        }

        private void OnSenderCreation(SenderCreationEventArgs args)
        {
            NewSender?.Invoke(this, args);
        }

        private void buttonCreateSender_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxSenderId.Text != string.Empty)
            {
                var window = new MessageWindow(this);
                window.Show();
                window.labelSender.Content = textBoxSenderId.Text;
                window.Comm += new CommunicationEventHandler(CommunicationOccured);
                OnSenderCreation(new SenderCreationEventArgs(textBoxSenderId.Text));
                listSenders.Add(new Sender(textBoxSenderId.Text));
                listBoxSenders.Items.Add(textBoxSenderId.Text);
                textBoxSenderId.Clear();
            }
            else
            {
                MessageBox.Show("Please provide a sender.");
            }
        }
    }
}
