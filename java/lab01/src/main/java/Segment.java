import javax.swing.*;
import java.awt.*;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

public class Segment extends JPanel  {

    int x=0;
    int y=0;
    int segment_size=35;

    Segment()
    {
        setSize(segment_size,segment_size);
        setBackground(Color.ORANGE);
        setFocusable(true);

        addKeyListener(new KeyListener(){
            @Override
            public void keyTyped(KeyEvent e) {

            }

            @Override
            public void keyPressed(KeyEvent e) {

                int keyCode = e.getKeyCode();
                if (e.getKeyCode() == KeyEvent.VK_RIGHT) {
                    setLocation(getX() + 35, getY() + 0);
                }
                if (e.getKeyCode() == KeyEvent.VK_LEFT) {
                    setLocation(getX() - 35, getY() + 0);
                }
                if (e.getKeyCode() == KeyEvent.VK_UP) {
                    setLocation(getX() + 0, getY() - 35);
                }
                if (e.getKeyCode() == KeyEvent.VK_DOWN) {
                    setLocation(getX() + 0, getY() + 35);
                }



            }

            @Override
            public void keyReleased(KeyEvent e) {

            }
        });




    }




   public int GetSegmentX()
   {
       return x;
   }
    public int GetSegmentY()
    {
        return y;
    }
}
