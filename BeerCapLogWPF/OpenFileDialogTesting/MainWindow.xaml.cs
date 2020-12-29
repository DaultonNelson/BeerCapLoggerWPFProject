using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using MessageBox = System.Windows.MessageBox;

namespace OpenFileDialogTesting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //The content of the file selected
            //var fileContent = string.Empty;
            //The path of the selected file
            //var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //Where the Open File Dialog starts
                openFileDialog.InitialDirectory = "c:\\";
                //Filters on what files can be picked, * is anything
                openFileDialog.Filter = "PNG Files (*.png)|*.png";
                //The filter index the Dialog starts on
                openFileDialog.FilterIndex = 0;
                //Resets to the initial directory once the Dialog has closed.
                openFileDialog.RestoreDirectory = true;
                //The title of the Dialog window.
                openFileDialog.Title = "Open Image";

                //If the user pressed OK on the Dialog box
                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //Get the path of specified file
                    //filePath = openFileDialog.FileName;

                    #region C# Documentation Example
                    //Read the contents of the file into a Stream
                    //Stream - An abstract class that provides standard methods to transfer bytes (like reading or writing)
                    //OpenFile() returns a Stream
                    //Stream fileStream = openFileDialog.OpenFile();

                    //StreamReader - a helper class for reading characters from a Stream by converting bytes into characters
                    //using (StreamReader reader  = new StreamReader(fileStream))
                    //{
                    //    //ReadToEnd() returns a string
                    //    fileContent = reader.ReadToEnd();
                    //} 
                    #endregion

                    string imagePath = @"D:\Side Projects\BottleCapCollection\BeerCapLoggerWPFProject\BeerCapImages\SavedBrandCaps\" + openFileDialog.SafeFileName;

                    if (File.Exists(imagePath))
                    {
                        if(MessageBox.Show("A file similar to this already exists.  Overwrite it?", "Already Existing File", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                        {
                            var fileStream = File.Create(imagePath);
                            var openedStream = openFileDialog.OpenFile();
                            openedStream.Seek(0, SeekOrigin.Begin);
                            openedStream.CopyTo(fileStream);
                            fileStream.Close();

                            return;
                        }
                    }
                    else
                    {
                        var fileStream = File.Create(imagePath);
                        var openedStream = openFileDialog.OpenFile();
                        openedStream.Seek(0, SeekOrigin.Begin);
                        openedStream.CopyTo(fileStream);
                        fileStream.Close();
                    }

                    //.InputStream
                    //.InputStream

                    //MessageBox.Show(fileContent, $"File Content at path: {filePath}", MessageBoxButton.OK);
                }
            }
        }
    }
}