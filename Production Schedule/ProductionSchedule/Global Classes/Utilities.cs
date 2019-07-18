using System;

namespace ProductionSchedule.Globals
{
    /*
     * A class to dump useful functions that can be shared throughout the project      
     */
    /// <summary>
    /// A collection of general functions that may be useful throughout the project
    /// </summary>
    public class Utilities
    {
        // A simplified method to display an Error MessageBox, specifically for files without 
        // Systems.Windows.Forms, typically in a try/catch response in database classes.
        ///<summary>
        /// A simplified method to display an Error <c>MessageBox</c> without having to include 
        /// Systems.Windows.Forms in the file.
        ///</summary>
        /// <param name="message"> The message to be displayed in the <c>MessageBox</c></param>
        /// <param name="caption"> The message to be displayed in the <c>MessageBox</c></param>
        public static void ShowError(string message, string caption)
        {
            System.Windows.Forms.MessageBox.Show($"Exception Error: {message}", caption,
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Error);
        }


        // A simplified method to display an OK MessageBox, specifically for files without 
        // Systems.Windows.Forms, typically in a try/catch response in database classes.
        ///<summary>
        /// A simplified method to display an OK <c>MessageBox</c> without having to include 
        /// Systems.Windows.Forms in the file.
        ///</summary>
        /// <param name="message"> The message to be displayed in the <c>MessageBox</c></param>
        /// <param name="caption"> The message to be displayed in the <c>MessageBox</c></param>
        public static void ShowMessage(string message, string caption)
        {
            System.Windows.Forms.MessageBox.Show(message, caption,
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Exclamation);
        }

        // Takes a reference to a combo box and tries to set the SelectedIndex value.
        /// <summary>
        /// Set the provided combo box control SelectedIndex value to the provided string if a match is found.
        /// </summary>
        /// <param name="cbx">A Windows.Forms combo box control.</param>
        /// <param name="select">The value to search for in the combo box and set to the SelectedIndex if found.</param>
        public static void SetComboBoxSelectedIndex(ref System.Windows.Forms.ComboBox cbx, string select)
        {
            for (int i = 0; i < cbx.Items.Count; i++)
            {
                if (cbx.Items[i].ToString() == select)
                {
                    cbx.SelectedIndex = i;
                    break;
                }
            }
        }
    }
}
