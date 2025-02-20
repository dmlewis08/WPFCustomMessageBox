using System.Drawing;
using System.Windows;

namespace WPFCustomMessageBox
{
    /// <summary>
    /// Interaction logic for CustomMessageBoxWindow.xaml
    /// </summary>
    internal partial class CustomMessageBoxWindow : Window
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomMessageBoxWindow"/> class with the specified message,
        /// caption, button(s), and image.
        /// </summary>
        /// <param name="message">The message to display in the window.</param>
        /// <param name="caption">The caption (title) to display in the window.</param>
        /// <param name="button">The button(s) to display in the window.</param>
        /// <param name="image">The image to display as the icon for the window.</param>
        internal CustomMessageBoxWindow(string message, string caption, MessageBoxButton button, MessageBoxImage image)
        {
            this.InitializeComponent();

            this.Message = message;
            this.Caption = caption;
            this.Image_MessageBox.Visibility = Visibility.Collapsed;

            this.DisplayImage(image);
            this.DisplayButtons(button);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the caption (title) for this window.
        /// </summary>
        internal string Caption
        {
            get
            {
                return this.Title;
            }
            set
            {
                this.Title = value;
            }
        }

        /// <summary>
        /// Gets or sets the message text for this window.
        /// </summary>
        internal string Message
        {
            get
            {
                return this.TextBlock_Message.Text;
            }
            set
            {
                this.TextBlock_Message.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the text displayed on the "OK" button.
        /// </summary>
        internal string OkButtonText
        {
            get
            {
                return this.Label_Ok.Content.ToString();
            }
            set
            {
                this.Label_Ok.Content = value.TryAddKeyboardAccellerator();
            }
        }

        /// <summary>
        /// Gets or sets the text displayed on the "Cancel" button.
        /// </summary>
        internal string CancelButtonText
        {
            get
            {
                return this.Label_Cancel.Content.ToString();
            }
            set
            {
                this.Label_Cancel.Content = value.TryAddKeyboardAccellerator();
            }
        }

        /// <summary>
        /// Gets or sets the text displayed on the "Yes" button.
        /// </summary>
        internal string YesButtonText
        {
            get
            {
                return this.Label_Yes.Content.ToString();
            }
            set
            {
                this.Label_Yes.Content = value.TryAddKeyboardAccellerator();
            }
        }

        /// <summary>
        /// Gets or sets the text displayed on the "No" button.
        /// </summary>
        internal string NoButtonText
        {
            get
            {
                return this.Label_No.Content.ToString();
            }
            set
            {
                this.Label_No.Content = value.TryAddKeyboardAccellerator();
            }
        }

        /// <summary>
        /// Gets or sets the result returned by this dialog.
        /// </summary>
        public MessageBoxResult Result { get; set; }
        #endregion


        #region Methods
        private void DisplayButtons(MessageBoxButton button)
        {
            switch (button)
            {
                case MessageBoxButton.OKCancel:
                    // Hide all but OK, Cancel
                    this.Button_OK.Visibility = System.Windows.Visibility.Visible;
                    this.Button_OK.Focus();
                    this.Button_Cancel.Visibility = System.Windows.Visibility.Visible;

                    this.Button_Yes.Visibility = System.Windows.Visibility.Collapsed;
                    this.Button_No.Visibility = System.Windows.Visibility.Collapsed;
                    break;

                case MessageBoxButton.YesNo:
                    // Hide all but Yes, No
                    this.Button_Yes.Visibility = System.Windows.Visibility.Visible;
                    this.Button_Yes.Focus();
                    this.Button_No.Visibility = System.Windows.Visibility.Visible;

                    this.Button_OK.Visibility = System.Windows.Visibility.Collapsed;
                    this.Button_Cancel.Visibility = System.Windows.Visibility.Collapsed;
                    break;

                case MessageBoxButton.YesNoCancel:
                    // Hide only OK
                    this.Button_Yes.Visibility = System.Windows.Visibility.Visible;
                    this.Button_Yes.Focus();
                    this.Button_No.Visibility = System.Windows.Visibility.Visible;
                    this.Button_Cancel.Visibility = System.Windows.Visibility.Visible;

                    this.Button_OK.Visibility = System.Windows.Visibility.Collapsed;
                    break;

                default:
                    // Hide all but OK
                    this.Button_OK.Visibility = System.Windows.Visibility.Visible;
                    this.Button_OK.Focus();

                    this.Button_Yes.Visibility = System.Windows.Visibility.Collapsed;
                    this.Button_No.Visibility = System.Windows.Visibility.Collapsed;
                    this.Button_Cancel.Visibility = System.Windows.Visibility.Collapsed;
                    break;
            }
        }

        private void DisplayImage(MessageBoxImage image)
        {
            Icon icon;

            switch (image)
            {
                case MessageBoxImage.None:
                    return;

                case MessageBoxImage.Exclamation:       // Enumeration value 48 - also covers "Warning"
                    icon = SystemIcons.Exclamation;
                    break;

                case MessageBoxImage.Error:             // Enumeration value 16, also covers "Hand" and "Stop"
                    icon = SystemIcons.Hand;
                    break;

                case MessageBoxImage.Information:       // Enumeration value 64 - also covers "Asterisk"
                    icon = SystemIcons.Information;
                    break;

                case MessageBoxImage.Question:
                    icon = SystemIcons.Question;
                    break;

                default:
                    icon = SystemIcons.Information;
                    break;
            }

            this.Image_MessageBox.Source = icon.ToImageSource();
            this.Image_MessageBox.Visibility = Visibility.Visible;
        }

        private void Button_OK_Click(object sender, RoutedEventArgs e)
        {
            this.Result = MessageBoxResult.OK;
            this.Close();
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Result = MessageBoxResult.Cancel;
            this.Close();
        }

        private void Button_Yes_Click(object sender, RoutedEventArgs e)
        {
            this.Result = MessageBoxResult.Yes;
            this.Close();
        }

        private void Button_No_Click(object sender, RoutedEventArgs e)
        {
            this.Result = MessageBoxResult.No;
            this.Close();
        }

        #endregion
    }
}
