using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Gcs
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.

            Start();
        }


        Gcs Gcs;
        Button[] SelectedCategory;
        Button[] EyeButtons, VerbalButtons, MotorButtons;

        private void Start()
        {
            EyeButtons = new Button[4] { E1, E2, E3, E4 };
            VerbalButtons = new Button[5] { V1, V2, V3, V4, V5 };
            MotorButtons = new Button[6] { M1, M2, M3, M4, M5, M6 };

            Gcs = new Gcs();


            foreach (var button in EyeButtons)
            {
                button.Background = new SolidColorBrush();
            }
            foreach (var button in VerbalButtons)
            {
                button.Background = new SolidColorBrush();
            }
            foreach (var button in MotorButtons)
            {
                button.Background = new SolidColorBrush();
            }


            SelectedCategory = new Button[3];
            Eyes.Text = Gcs.EyesString;
            Verbal.Text = Gcs.VerbalString;
            Motor.Text = Gcs.MotorString;

            GcsScore.Foreground = new SolidColorBrush(Colors.White);
            GcsScore.Text = "0";
        }

        private void Eye_Click(object sender, RoutedEventArgs e)
        {
            GcsButton((Button)sender, 0);

        }
        private void Verbal_Click(object sender, RoutedEventArgs e)
        {
            GcsButton((Button)sender, 1);

        }
        private void Motor_Click(object sender, RoutedEventArgs e)
        {
            GcsButton((Button)sender, 2);

        }

        private void GcsButton(Button button, int category)
        {            
            if (Gcs.Finished())
            {
                return;
            }

            var value = int.Parse(button.Content.ToString());

            if (SelectedCategory[category] != null)
            {
                SelectedCategory[category].Background = new SolidColorBrush();
            }

            if (value == Gcs.SelectedCategory[category])
            {
                Gcs.SelectedCategory[category] = 0;
                GcsScore.Text = Gcs.SelectedScore().ToString();
                return;
            }

            SelectedCategory[category] = button;
            Gcs.SelectedCategory[category] = value;

            button.Background = new SolidColorBrush(Colors.Blue);

            GcsScore.Text = Gcs.SelectedScore().ToString();

            if (SelectedCategory.All(x => x != null))
            {
                AssessmentComplete();
            }
        }

        private void AssessmentComplete()
        {
            EyeButtons[Gcs.Category[0] - 1].Background = new SolidColorBrush(Colors.Green);
            VerbalButtons[Gcs.Category[1] - 1].Background = new SolidColorBrush(Colors.Green);
            MotorButtons[Gcs.Category[2] - 1].Background = new SolidColorBrush(Colors.Green);

            if (Gcs.Category[0] != Gcs.SelectedCategory[0])
            {
                EyeButtons[Gcs.SelectedCategory[0] - 1].Background = new SolidColorBrush(Colors.Red);
            }
            if (Gcs.Category[1] != Gcs.SelectedCategory[1])
            {
                VerbalButtons[Gcs.SelectedCategory[1] - 1].Background = new SolidColorBrush(Colors.Red);
            }
            if (Gcs.Category[2] != Gcs.SelectedCategory[2])
            {
                MotorButtons[Gcs.SelectedCategory[2] - 1].Background = new SolidColorBrush(Colors.Red);
            }

            if (Gcs.Correct())
            {
                GcsScore.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                GcsScore.Text = string.Format("{0} (You had {1})", Gcs.CorrectScore(), Gcs.SelectedScore());
                GcsScore.Foreground = new SolidColorBrush(Colors.Red);
            }

            NewAttempt.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            NewAttempt.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            Start();
        }
    }
}
