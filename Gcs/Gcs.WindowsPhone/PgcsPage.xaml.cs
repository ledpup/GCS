using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Gcs
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PgcsPage : Page
    {
        public PgcsPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Start();
        }


        Pgcs Pgcs;
        Button[] SelectedCategory;
        Button[] EyeButtons, VerbalButtons, MotorButtons;

        private void Start()
        {
            EyeButtons = new Button[4] { E1, E2, E3, E4 };
            VerbalButtons = new Button[5] { V1, V2, V3, V4, V5 };
            MotorButtons = new Button[6] { M1, M2, M3, M4, M5, M6 };

            Pgcs = new Pgcs();


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
            Eyes.Text = Pgcs.EyesString;
            Verbal.Text = Pgcs.VerbalString;
            Motor.Text = Pgcs.MotorString;

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
            if (Pgcs.Finished())
            {
                return;
            }

            var value = int.Parse(button.Content.ToString());

            if (SelectedCategory[category] != null)
            {
                SelectedCategory[category].Background = new SolidColorBrush();
            }

            if (button == SelectedCategory[category])
            {
                SelectedCategory[category] = null;
                Pgcs.SelectedCategory[category] = 0;
                GcsScore.Text = Pgcs.SelectedScore().ToString();
                return;
            }

            SelectedCategory[category] = button;
            Pgcs.SelectedCategory[category] = value;

            button.Background = new SolidColorBrush(Colors.Blue);

            GcsScore.Text = Pgcs.SelectedScore().ToString();

            if (SelectedCategory.All(x => x != null))
            {
                AssessmentComplete();
            }
        }

        private void AssessmentComplete()
        {
            EyeButtons[Pgcs.Category[0] - 1].Background = new SolidColorBrush(Colors.Green);
            VerbalButtons[Pgcs.Category[1] - 1].Background = new SolidColorBrush(Colors.Green);
            MotorButtons[Pgcs.Category[2] - 1].Background = new SolidColorBrush(Colors.Green);

            if (Pgcs.Category[0] != Pgcs.SelectedCategory[0])
            {
                EyeButtons[Pgcs.SelectedCategory[0] - 1].Background = new SolidColorBrush(Colors.Red);
            }
            if (Pgcs.Category[1] != Pgcs.SelectedCategory[1])
            {
                VerbalButtons[Pgcs.SelectedCategory[1] - 1].Background = new SolidColorBrush(Colors.Red);
            }
            if (Pgcs.Category[2] != Pgcs.SelectedCategory[2])
            {
                MotorButtons[Pgcs.SelectedCategory[2] - 1].Background = new SolidColorBrush(Colors.Red);
            }

            if (Pgcs.Correct())
            {
                GcsScore.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                GcsScore.Text = string.Format("{0} (You had {1})", Pgcs.CorrectScore(), Pgcs.SelectedScore());
                GcsScore.Foreground = new SolidColorBrush(Colors.Red);
            }

            NewAttempt.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            NewAttempt.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            Start();
        }
        void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame != null && rootFrame.CanGoBack)
            {
                rootFrame.GoBack();
                e.Handled = true;
            }
        }
    }
}
