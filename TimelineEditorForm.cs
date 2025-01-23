using System.Windows.Forms;

public class TimelineEditorForm : UserControl
{
    private TimelineEditor editor;
    private TimelineEditorDesigner designer;

    public TimelineEditorForm(TimelineCanvasForm canvas, TimelineSettings settings)
    {
        this.Dock = DockStyle.Left;
        this.Width = 200;
        this.BackColor = SystemColors.Control;

        editor = new TimelineEditor(canvas);
        designer = new TimelineEditorDesigner(settings);

        this.Controls.Add(editor);
        this.Controls.Add(designer);
    }
}


