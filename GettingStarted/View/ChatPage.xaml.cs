using Syncfusion.XForms.Chat;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GettingStarted
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : ContentPage
    {
        SfChat sfChat;
        GettingStartedViewModel viewModel;
        public ChatPage()
        {
            InitializeComponent();
            sfChat = new SfChat();
            viewModel = new GettingStartedViewModel();
            this.sfChat.Messages = viewModel.Messages;
            this.sfChat.CurrentUser = viewModel.CurrentUser;
            this.sfChat.MessageTemplate = new ChatMessageTemplateSelector() { Chat = this.sfChat };
            this.Content = sfChat;
        }
    }
}