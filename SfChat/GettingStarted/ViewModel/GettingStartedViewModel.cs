using System;
using System.Collections.ObjectModel;
using Syncfusion.XForms.Chat;
using System.ComponentModel;

namespace GettingStarted
{
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
        /// Gets or sets the current author.
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
}
