using Syncfusion.XForms.Chat;
using Xamarin.Forms;

namespace GettingStarted
{
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
}
