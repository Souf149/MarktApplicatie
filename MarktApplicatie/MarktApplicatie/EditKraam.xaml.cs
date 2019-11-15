using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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


namespace MarktApplicatie
{
    
    public partial class EditKraam : Window
    {
        Boolean mouseDown = false;
        Boolean plankEditMode = true;

        List<string> fruitNames = new List<string>();

        
        

        const int GRID_SIZE = 48;

        Plank selectedPlank = new Plank();

        List<Plank> planks = new List<Plank>();

        SolidColorBrush currentFill = new SolidColorBrush(Colors.Red);
        int selectedFruit = -1;

        

        public TextBlock txtBlock(String t, String code)
        {
            return new TextBlock
            {
                Text = t,
                Background = SoufTools.GetColor(code)
            };
        }

        

        private void SetColor(string code)
        {
            currentFill = SoufTools.GetColor(code);
        }

        private Rectangle Rect(double x, double y, double w, double h)
        {


            Rectangle r = new Rectangle
            {
                Width = w,
                Height = h,
                Fill = currentFill
            };
            
            Canvas.SetLeft(r, x);
            Canvas.SetTop(r, y);

            canvas.Children.Add(r);
            return r;
        }

        // window initializer
        public EditKraam()
        {
            // initialize window
            InitializeComponent();

            // TODO: ADD FROM FILE
            TextBlock txt = txtBlock("Test123", "#FF00FF");
            listView.Items.Add(txt);

            // make list of all current fruit TODO: ADD FROM FILE
            fruitNames.Add("appel");
            fruitNames.Add("banaan");
            fruitNames.Add("citroen");
            fruitNames.Add("limoen");

            Fruit.c = canvas;
            Plank.c = canvas;
            




        }

        private void go_home(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            this.Close();
        }

        private void Go_bus(object sender, MouseButtonEventArgs e)
        {
            editbus editBus = new editbus();
            editBus.Show();
            this.Close();
        }

        private void ListView_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            selectedFruit = listView.SelectedIndex;
            debugText.Text = selectedFruit.ToString();
        }

        private void Create_plank(object sender, MouseButtonEventArgs e)
        {
            plank_popup dialog = new plank_popup();
            int width, height;
            if(dialog.ShowDialog() == true)
            {
                debugText.Text = planks.Count.ToString();
                width = Convert.ToInt16(dialog.Inp_width);
                height = Convert.ToInt16(dialog.Inp_height);



                SetColor("#654321");

                Plank p = new Plank(
                    planks.Count,
                    Rect(0, 0, width * GRID_SIZE, height * GRID_SIZE)
                    );

                planks.Add(p);
                selectedPlank = p;
                Plank.selectedPlank = planks.Count() - 1;

                CheckPlanks();

            }
            
        }


        private void Canvas_onclick(object sender, MouseButtonEventArgs e) {

            Point p = e.GetPosition(this);
            mouseDown = true;
            positionText.Text = $"X: {p.X.ToString()}, \nY: {p.Y.ToString()}";

            if (plankEditMode) {
                for (int i = 0; i < planks.Count; i++) {
                    Rectangle r = planks[i].r;
                    double x = Canvas.GetLeft(r);
                    double y = Canvas.GetTop(r);


                    if (p.X > x && p.X < x + r.Width &&
                        p.Y > y && p.Y < y + r.Height) {
                        Plank.selectedPlank = i;
                        selectedPlank = planks[i];
                        CheckPlanks();
                        return;
                    }
                }

                // als niks gedrukt is dan moet hij deselecteren
                selectedPlank = new Plank();
                Plank.selectedPlank = -1;
                CheckPlanks();
            }
            else {

                foreach(Plank plank in planks) {
                    Rectangle r = plank.r;
                    double plank_x = Canvas.GetLeft(r);
                    double plank_y = Canvas.GetTop(r);

                    if (p.X > plank_x && p.X < plank_x + r.Width &&
                        p.Y > plank_y && p.Y < plank_y + r.Height) {

                        double x = p.X - Canvas.GetLeft(plank.r);
                        double y = p.Y - Canvas.GetTop(plank.r);
                        plank.OnClick(selectedFruit, x, y);
                    }
                    
                }
            }
            


            




        }

        void CheckPlanks() {
            // Make it get green stroke, if its currently selected.
            for(int i = 0; i < planks.Count; i++) {
                planks[i].Check();
             }
            
            
            

        }

        private void Canvas_onrelease(object sender, MouseButtonEventArgs e) {
            Point p = e.GetPosition(this);
            mouseDown = false;


        }

        private void Canvas_PreviewMouseMove(object sender, MouseEventArgs e) {
            Point p = e.GetPosition(this);
            // if the mouse is held down while moving
            if (mouseDown) {
                positionText.Text = $"X: {p.X.ToString()}, \nY: {p.Y.ToString()}";

                // if you want to move the current selected plank
                if (plankEditMode) {
                    if (Plank.selectedPlank == -1)
                        return;
                    // TODO: remove Moveshape method
                    planks[Plank.selectedPlank].Move(p.X, p.Y);
                }


             }
        }

        private void Switch_editmode_onclick(object sender, MouseButtonEventArgs e) {

            if (plankEditMode) {
                plankEditMode = false;
                btn_switch_editmode.Content = "Switch to\nplank edit";
                canvas.Background = SoufTools.GetColor("#22AA22");
            }
            else {
                plankEditMode = true;
                btn_switch_editmode.Content = "Switch to\nadd fruit";
                canvas.Background = SoufTools.GetColor("#555555");
            }
        }

        private void Verander_grootte(object sender, MouseButtonEventArgs e) {
            if (Plank.selectedPlank == -1) { 
                MessageBox.Show("Selecteer een plank");
                return;
            }

            plank_popup dialog = new plank_popup();
            int width, height;
            if (dialog.ShowDialog() == true) {
                debugText.Text = planks.Count.ToString();
                width = Convert.ToInt16(dialog.Inp_width);
                height = Convert.ToInt16(dialog.Inp_height);

                selectedPlank.Resize(width * GRID_SIZE, height * GRID_SIZE);
            }

        }
    }
}
