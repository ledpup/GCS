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
    public sealed partial class ApgarPage : Page
    {
        public ApgarPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Start();
        }


        Apgar Apgar;
        Button[] SelectedCategory;
        Button[] AppearanceButtons, PulseButtons, GrimaceButtons, MuscleActivityButtons, RespiratoryButtons;

        private void Start()
        {
            AppearanceButtons = new[] { A0, A1, A2 };
            PulseButtons = new[] { P0, P1, P2 };
            GrimaceButtons = new[] { G0, G1, G2 };
            MuscleActivityButtons = new[] { M0, M1, M2 };
            RespiratoryButtons = new[] { R0, R1, R2 };


            Apgar = new Apgar();


            foreach (var button in AppearanceButtons)
            {
                button.Background = new SolidColorBrush();
            }
            foreach (var button in PulseButtons)
            {
                button.Background = new SolidColorBrush();
            }
            foreach (var button in GrimaceButtons)
            {
                button.Background = new SolidColorBrush();
            }
            foreach (var button in MuscleActivityButtons)
            {
                button.Background = new SolidColorBrush();
            }
            foreach (var button in RespiratoryButtons)
            {
                button.Background = new SolidColorBrush();
            }


            SelectedCategory = new Button[5];
            Appearance.Text = Apgar.AppearanceString;
            Pulse.Text = Apgar.PulseString;
            Grimace.Text = Apgar.GrimaceString;
            MuscleActivity.Text = Apgar.MuscleActivityString;
            RespiratoryRate.Text = Apgar.RespirationString;

            GcsScore.Foreground = new SolidColorBrush(Colors.White);
            GcsScore.Text = "0";
        }

        private void Appearance_Click(object sender, RoutedEventArgs e)
        {
            Button((Button)sender, 0);

        }
        private void Pulse_Click(object sender, RoutedEventArgs e)
        {
            Button((Button)sender, 1);

        }
        private void Grimace_Click(object sender, RoutedEventArgs e)
        {
            Button((Button)sender, 2);
        }

        private void MuscleActivity_Click(object sender, RoutedEventArgs e)
        {
            Button((Button)sender, 3);
        }

        private void Respiratory_Click(object sender, RoutedEventArgs e)
        {
            Button((Button)sender, 4);
        }

        private void Button(Button button, int category)
        {
            if (Apgar.Finished())
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
                Apgar.SelectedCategory[category] = 0;
                GcsScore.Text = Apgar.SelectedScore().ToString();
                return;
            }

            SelectedCategory[category] = button;
            Apgar.SelectedCategory[category] = value;

            button.Background = new SolidColorBrush(Colors.Blue);

            GcsScore.Text = Apgar.SelectedScore().ToString();

            if (SelectedCategory.All(x => x != null))
            {
                AssessmentComplete();
            }
        }

        private void AssessmentComplete()
        {
            CorrectButtons(AppearanceButtons, 0);
            CorrectButtons(PulseButtons, 1);
            CorrectButtons(GrimaceButtons, 2);
            CorrectButtons(MuscleActivityButtons, 3);
            CorrectButtons(RespiratoryButtons, 4);


            if (Apgar.Correct())
            {
                GcsScore.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                GcsScore.Text = string.Format("{0} (You had {1})", Apgar.CorrectScore(), Apgar.SelectedScore());
                GcsScore.Foreground = new SolidColorBrush(Colors.Red);
            }

            NewAttempt.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }

        private void CorrectButtons(Button[] buttons, int p)
        {
            buttons[Apgar.Category[p]].Background = new SolidColorBrush(Colors.Green);

            if (Apgar.Category[p] != Apgar.SelectedCategory[p])
            {
                buttons[Apgar.SelectedCategory[p]].Background = new SolidColorBrush(Colors.Red);
            }
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
