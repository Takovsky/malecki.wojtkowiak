import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.Random;


class ButtonWin extends JFrame {

    private JPanel panel1;
    private JButton radombutton;
    private JButton button2; // just to ensure that we can add any other component and make it invisible
    private int screen_width;
    private int screen_height;
    private int available_height;
    private int available_width;
    private int random_h;
    private int random_w;

     ButtonWin()
    {
        button2.setVisible(false);
        this.GetResolution();
        this.setSize(200   ,400);
        //this.setExtendedState(JFrame.MAXIMIZED_BOTH);
        this.GetPossibleSizes(); // to fit in screen sizes
        this.setContentPane(panel1);
        this.setUndecorated(true);
        this.setBackground(new Color(0,0,0,0));
        this.GetRandomPointsAndSetPosition();
        this.setLocation( random_w , random_h);

        radombutton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                GetRandomPointsAndSetPosition();
                //auto location = getLocation();
                //while(location.x != random_x)
                setLocation( random_w , random_h);
            }
        });
    }

    private void GetRandomPointsAndSetPosition()
    {
        Random rand = new Random();
        random_h = rand.nextInt( available_height );
        random_w = rand.nextInt( available_width );
    }

     private void GetResolution()
     {
         Dimension screen_resolution = Toolkit.getDefaultToolkit().getScreenSize();
         screen_height = (int) screen_resolution.getHeight();
         screen_width = (int) screen_resolution.getWidth();
     }

     private void GetPossibleSizes()
     {
         available_height = screen_height - 100;
         available_width = screen_width-this.getWidth();
     }


}
