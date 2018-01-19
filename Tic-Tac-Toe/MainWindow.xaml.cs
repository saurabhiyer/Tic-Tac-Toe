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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string currentPlayer;//Track Current Player
        string CurrentPlayer//wrapper
        {
            get { return this.currentPlayer; }
            set { this.currentPlayer = value; }
        }
        Button[] cells;//Track List of Cells
        public MainWindow()
        {
            InitializeComponent();
            this.cells = new Button[] { this.cell00, this.cell01, this.cell02, this.cell10,this.cell11,this.cell12,this.cell20,this.cell21,this.cell22,this.cell22};
            foreach (Button cell in cells)
            {
                cell.Click += Cell_Click;
            }
            NewGame();
        }

        void NewGame()
        {
            foreach (Button cell in this.cells)
            {
                cell.ClearValue(Button.ContentProperty);
            }
            CurrentPlayer = "X";
        }
        bool HasWon(Button cell)
        {
            bool ret = false;
            string ordinal1 = (string)((Button)this.cell00).Content;
            string ordinal2 = (string)((Button)this.cell11).Content;
            string ordinal3 = (string)((Button)this.cell22).Content;
            string ordinal1a = (string)((Button)this.cell02).Content;
            string ordinal3a = (string)((Button)this.cell20).Content;
            if ((this.cell01.Content!= null && (string)this.cell01.Content == ordinal1 && this.cell02.Content != null && (string)this.cell02.Content == ordinal1) ||
                (this.cell10.Content != null && (string)this.cell10.Content == ordinal1 && this.cell20.Content != null && (string)this.cell20.Content == ordinal1))
                ret = true;
            if ((this.cell10.Content != null && (string)this.cell10.Content == ordinal2 && this.cell12.Content != null && (string)this.cell12.Content == ordinal2) ||
                (this.cell01.Content != null && (string)this.cell01.Content == ordinal2 && this.cell21.Content != null && (string)this.cell21.Content == ordinal2))
                ret = true;
            if ((this.cell20.Content != null && (string)this.cell20.Content == ordinal3 && this.cell21.Content != null && (string)this.cell21.Content == ordinal3) ||
                (this.cell02.Content != null && (string)this.cell02.Content == ordinal3 && this.cell12.Content != null && (string)this.cell12.Content == ordinal3))
                ret = true;
            if ((ordinal1!=null && ordinal2 != null) && (ordinal1 == ordinal2) && (ordinal3 != null && ordinal2 != null) && (ordinal2 == ordinal3))
                ret = true;
            if ((ordinal1a != null && ordinal2 != null) && (ordinal1a == ordinal2) && (ordinal3a != null && ordinal2 != null) && (ordinal2 == ordinal3a))
                ret = true;
            return ret;
        }
        bool TieGame()
        {
            bool ret = true; ;
            foreach (Button cell in this.cells)
            {
                if (cell.Content == null)
                    ret = false;
            }
            return ret;
        }
        
        private void Cell_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button.Content != null) { return; }

            button.Content = CurrentPlayer;

            if (this.CurrentPlayer == "X")
                button.Style = (Style)FindResource("XStyle");
            else
            {
                button.Style = (Style)FindResource("OStyle");
            }


            if (HasWon(button))
            {
                MessageBox.Show(CurrentPlayer+" - You Win!", "Game Over");
                NewGame();
                return;
            }
            else if (TieGame())
            {
                MessageBox.Show("Tie !","Game Over");
                NewGame();
                return;
            }
            if (CurrentPlayer == "X")
                CurrentPlayer = "O";
            else if (CurrentPlayer == "O")
                CurrentPlayer = "X";
        }
    }
}
