# Chat-Message-Template-Xamarin.Forms

## About the sample

This repository contains sample that demonstrates how to show chat messages in user defined templates

```c#

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

//Template selector 

public class ChatMessageTemplateSelector : DataTemplateSelector
{
    private readonly DataTemplate incomingDataTemplate;
    private readonly DataTemplate outgoingDataTemplate;
    private readonly DataTemplate ratingDataTemplate;

    internal SfChat Chat
    {
        get;
        set;
    }

    public ChatMessageTemplateSelector()
    {
        this.incomingDataTemplate = new DataTemplate(typeof(IncomingTemplate));
        this.outgoingDataTemplate = new DataTemplate(typeof(OutgoingTemplate));
        this.ratingDataTemplate = new DataTemplate(typeof(RatingTemplate));
    }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        var message = item as IMessage;
        if (message == null)
            return null;


        if (message.Author == Chat.CurrentUser)
        {
            return outgoingDataTemplate;
        }
        else
        {
            if (item as ITextMessage != null)
            {
                if ((item as ITextMessage).Text == "How would you rate your interaction with our travel bot?")
                {
                    return ratingDataTemplate;
                }
                else
                {
                    return incomingDataTemplate;
                }
            }
            else
            {
                return null;
            }
        }
    }
}

// View Model

public class GettingStartedViewModel : INotifyPropertyChanged
{
    /// <summary>
    /// Collection of messages or conversation.
    /// </summary>
    private ObservableCollection<object> messages;

    /// <summary>
    /// current user of chat.
    /// </summary>
    private Author currentUser;

    public GettingStartedViewModel()
    {
        this.messages = new ObservableCollection<object>();
        this.currentUser = new Author() { Name = "Nancy", Avatar = "People_Circle16.png" };
        this.GenerateMessages();
    }

    /// <summary>
    /// Gets or sets the group message conversation.
    /// </summary>
    public ObservableCollection<object> Messages
    {
        get
        {
            return this.messages;
        }

        set
        {
            this.messages = value;
        }
    }

    /// <summary>
    /// Gets or sets the current user.
    /// </summary>
    public Author CurrentUser
    {
        get
        {
            return this.currentUser;
        }
        set
        {
            this.currentUser = value;
            RaisePropertyChanged("CurrentUser");
        }
    }

    /// <summary>
    /// Property changed handler.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// Occurs when property is changed.
    /// </summary>
    /// <param name="propName">changed property name</param>
    public void RaisePropertyChanged(string propName)
    {
        if (this.PropertyChanged != null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }

    private void GenerateMessages()
    {
        this.messages.Add(new TextMessage()
        {
            Author = new Author() { Name = "Travel Bot", Avatar = "Aeroplane.png" },
            Text = "Select your preferred airline company.",
            ShowAvatar = true,
        });

        this.messages.Add(new TextMessage()
        {
            Author = currentUser,
            Text = "Air Canada $2700",
            ShowAvatar = true,
        });

        this.messages.Add(new TextMessage()
        {
            Author = new Author() { Name = "Travel Bot", Avatar = "Aeroplane.png" },
            Text = "Congratulations ! Your booking has been conformed. A conformation along with your ticket has been sent to your email",
            ShowAvatar = true,
        });

        this.messages.Add(new TextMessage()
        {
            Author = new Author() { Name = "Travel Bot", Avatar = "Aeroplane.png" },
            Text = "Bon Voyage",
            ShowAvatar = true,
        });

        this.messages.Add(new TextMessage()
        {
            Author = currentUser,
            Text = "Thank you",
            ShowAvatar = true,
        });

        this.messages.Add(new TextMessage()
        {
            Author = new Author() { Name = "Travel Bot", Avatar = "Aeroplane.png" },
            Text = "How would you rate your interaction with our travel bot?",
            ShowAvatar = true,
        });
    }
}

```

## <a name="requirements-to-run-the-demo"></a>Requirements to run the demo ##

* [Visual Studio 2017](https://visualstudio.microsoft.com/downloads/) or [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/).
* Xamarin add-ons for Visual Studio (available via the Visual Studio installer).

## <a name="troubleshooting"></a>Troubleshooting ##
### Path too long exception
If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.
