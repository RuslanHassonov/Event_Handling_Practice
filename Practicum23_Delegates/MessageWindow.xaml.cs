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
using System.Windows.Shapes;

namespace Practicum23_Delegates_Events
{
    public delegate void CommunicationEventHandler(object sender, CommunicationEventArgs args);
    /// <summary>
    /// Interaction logic for MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window
    {
        public event CommunicationEventHandler Comm;

        public MessageWindow(MainWindow w)
        {
            InitializeComponent();
            w.NewSender += SenderCreationOccured; // Connecting the event handler to the event from MainWindow(publisher)
            w.MessageExchange += MessagExchangeOccured; // Connecting all windows to the message exchanging event
            foreach (var sender in w.listBoxSenders.Items)
            {
                comboBox_Receiver.Items.Add(sender);
            }
        }

        public void MessagExchangeOccured(object sender, MessageEventArgs args) // Event Handler for message exchange
        {
            if (labelSender.Content.ToString() == args.Receiver)
            {
                listBox_ReceivedMessage.Items.Add(args.Message); 
            }
        }

        public void SenderCreationOccured(object sender, SenderCreationEventArgs args) // Event Handler for creating a new sender window
        {
            comboBox_Receiver.Items.Add(args.SenderId);
        }

        private void OnCommunication(CommunicationEventArgs args)
        {
            Comm?.Invoke(this, args);
        }

        private void buttonSend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string senderMessage = Convert.ToString(labelSender.Content);
                string receiverMessage = comboBox_Receiver.SelectedValue.ToString();
                string message = textBoxMessage.Text;
                OnCommunication(new CommunicationEventArgs(DateTime.Now, senderMessage, receiverMessage, message));
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Choose a receiver. " + ex.Message);
            }

        }


    }
}
