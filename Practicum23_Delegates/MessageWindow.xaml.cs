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

namespace Practicum23_Delegates_Strings
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
            w.NewSender += SenderCreationOccured;
            foreach (var sender in w.listBoxSenders.Items)
            {
                comboBox_Receiver.Items.Add(sender);
            }
        }

        public void SenderCreationOccured(object sender, SenderCreationEventArgs args)
        {
            comboBox_Receiver.Items.Add(args.SenderId);
        }

        private void OnCommunication(CommunicationEventArgs args)
        {
            Comm?.Invoke(this, args);
        }
        
        private void buttonSend_Click(object sender, RoutedEventArgs e)
        {
            string senderMessage = Convert.ToString(labelSender.Content);
            string receiverMessage = comboBox_Receiver.SelectedValue.ToString();
            OnCommunication(new CommunicationEventArgs(DateTime.Now, senderMessage, receiverMessage));            
        }
    }
}
