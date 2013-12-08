namespace KeyGen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Xml.Linq;
    using System.Xml;

    /// <summary>
    /// MainWindow.xaml code behinde
    /// </summary>
    public partial class MainWindow : Window
    {
        #region ' + MainWindow()

        /// <summary>
        /// Create and initialize MainWindow instance.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
            this.InitializeComboBoxDataSource();
        }

        #endregion
        #region ' - InitializeComboBoxDataSource() : void

        /// <summary>
        /// Initialize combobox contents.
        /// </summary>
        private void InitializeComboBoxDataSource()
        {
            // Set decryption type list.
            var decryptionComboBox = this.decryptList;
            decryptionComboBox.ItemsSource = Decription.DataSouce;
            decryptionComboBox.DisplayMemberPath = "DisplayName";
            decryptionComboBox.SelectedItem = (from decription in Decription.DataSouce
                                               where decription.IsDefault == true
                                               select decription).FirstOrDefault<Decription>();

            // Set validation type list.
            var validationComboBox = this.validateList;
            validationComboBox.ItemsSource = Validation.DataSource;
            validationComboBox.DisplayMemberPath = "DisplayName";
            validationComboBox.SelectedItem = (from validation in Validation.DataSource
                                               where validation.IsDefault == true
                                               select validation).FirstOrDefault<Validation>();
        }

        #endregion
        #region ' - generateButton_Click( object, RoutedEventArgs ) : void

        /// <summary>
        /// Call when generate button has been clicked.
        /// </summary>
        /// <param name="sender">Button object.</param>
        /// <param name="e">Event arguments.</param>
        private void generateButton_Click(object sender, RoutedEventArgs e)
        {
            // Get generate target.
            var decription = this.decryptList.SelectedItem as Decription;
            var validation = this.validateList.SelectedItem as Validation;
            
            // Calculate key value.
            var decryptionKey = Key.Generate((int)(decription.Bit / 8));
            var validationKey = Key.Generate((int)(validation.Bit / 8));

            // Create machineKey xml element.
            var xdoc = new XDocument(
                new XElement("machineKey",
                    new XAttribute("decryption", decription.TypeName),
                    new XAttribute("decryptionKey", decryptionKey),
                    new XAttribute("validation", validation.TypeName),
                    new XAttribute("validationKey", validationKey)));

            var output = new StringBuilder();
            var settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.NewLineOnAttributes = true;
            settings.Indent = true;
            using (var writer = XmlWriter.Create(output, settings))
            {
                xdoc.Save(writer);
            }

            // Display machineKey xml element.
            this.textBox.Text = output.ToString();
        }

        #endregion
        #region ' - copyButton_Click( object, RoutedEventArgs ) : void

        /// <summary>
        /// Call when copy button has been clicked.
        /// </summary>
        /// <param name="sender">Button object.</param>
        /// <param name="e">Event arguments.</param>
        private void copyButton_Click(object sender, RoutedEventArgs e)
        {
            var text = this.textBox.Text;

            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            Clipboard.SetText(text);
        }

        #endregion
        #region ' - closeButton_Click( object, RoutedEventArgs ) : void

        /// <summary>
        /// Call when close button has been clicked.
        /// </summary>
        /// <param name="sender">Button object.</param>
        /// <param name="e">Event arguments</param>
        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
