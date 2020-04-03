using System.Windows.Forms;

namespace Terminal
{
    public class Flow
    {
        public RichTextBox Input;
        public RichTextBox Output;

        public Flow(object input, object output)
        {
            Input = (RichTextBox)input;
            Output = (RichTextBox)output;
        }
    }
}
