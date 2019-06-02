import javax.swing.*;
import java.awt.*;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

class Board extends JPanel {

    Board()
    {
        setPreferredSize(new Dimension(800,800));
        setLayout(null);

        Segment head = new Segment();
        add(head);
        head.setLocation(head.GetSegmentX(),head.GetSegmentY());


    }




}