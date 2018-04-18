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

namespace Practicum23_Delegates_Events
{
    public delegate void SenderCreationEventHandler(object sender, SenderCreationEventArgs args); // Delegate for sender creation definition
    public delegate void MessageExchangeEventHandler(object sender, MessageEventArgs args); // Delegate for message exchange
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public event SenderCreationEventHandler NewSender; // Making an event from delegate
        public event MessageExchangeEventHandler MessageExchange; // Message exchange event
        private List<Sender> listSenders = new List<Sender>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnMessageExchange(MessageEventArgs args)
        {
            MessageExchange?.Invoke(this, args);
        }

        public void CommunicationOccured(object sender, CommunicationEventArgs args)
        {
            listBoxCommunicatie.Items.Add(args.DateTimeLog.ToString() + " From: " + args.Sender + " To: " + args.Receiver);
            foreach (var receiver in listSenders)
            {
                if (args.Receiver == receiver.Id)
                {
                    OnMessageExchange(new MessageEventArgs(args.Message, receiver.Id)); // Firing the message exchange event to MessageWindow
                }
            }
        }

        private void OnSenderCreation(SenderCreationEventArgs args) // What happens when the event is fired
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
                OnSenderCreation(new SenderCreationEventArgs(textBoxSenderId.Text)); // Firing the event to MessageWindow(subscriber)
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
