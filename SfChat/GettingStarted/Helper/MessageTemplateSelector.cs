using Syncfusion.XForms.Chat;
using Xamarin.Forms;

namespace GettingStarted
{
    public class MessageTemplateSelector : ChatMessageTemplateSelector
    {
        private readonly DataTemplate ratingDataTemplate;

        internal SfChat Chat
        {
            get;
            set;
        }

        public MessageTemplateSelector(SfChat sfChat):base(sfChat)
        {
            this.Chat = sfChat;
            this.ratingDataTemplate = new DataTemplate(typeof(RatingTemplate));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var message = item as IMessage;
            if (message == null)
                return null;

            if (item as ITextMessage != null)
            {
                if ((item as ITextMessage).Text == "How would you rate your interaction with our travel bot?")
                {
                    return ratingDataTemplate;
                }
                else
                {
                    return base.OnSelectTemplate(item,container);
                }
            }
            else
            {
                return null;
            }
        }
    }
}
