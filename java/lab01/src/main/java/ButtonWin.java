import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyEvent;
import java.util.Random;
import java.util.Timer;
import java.util.TimerTask;




class AppSnakeWindow  extends JFrame {

    private JPanel panel1;
    private int screen_width;
    private int screen_height;
    private int available_height;
    private int available_width;
    private int random_h;
    private int random_w;
    private int current_x;
    private int current_y;




     AppSnakeWindow()
    {
       this.setSize(300,300);
       panel1.setSize(300,300);
       panel1.setVisible(true);
    }
//        button2.setVisible(false);
//        this.GetResolution();
//        this.setSize(200   ,400);
//        //this.setExtendedState(JFrame.MAXIMIZED_BOTH);
//        this.GetPossibleSizes(); // to fit in screen sizes
//        this.setContentPane(panel1);
//        this.setUndecorated(true);
//        this.setBackground(new Color(0,0,0,0));
//        this.GetRandomDestinationPoints(); // mamy tylko punkty
//        this.setLocation( random_w , random_h);

//
//        radombutton.addActionListener(new ActionListener() {
//            @Override
//            public void actionPerformed(ActionEvent e) {
//                GetRandomDestinationPoints(); // mamy losowe punkt
//                Timer myTimer = new Timer();
//                myTimer.scheduleAtFixedRate(new TimerTask() {
//                        @Override
//                        public void run() {
//                            if(current_x!= random_w && current_y!= random_h) { AnimatedButtonMove();
//                            radombutton.setEnabled(false);}
//                            else { myTimer.cancel();
//                            radombutton.setEnabled(true);}
//                            }
//                    }, 10,10);
//            }
//        });
//
//        // JAK MAMY PROSTA KLASE TO NIE RYSUJEMY KRESEK np. POINT 2D bęący w segment, snake
//        // musi byc kalsa ktora zagniezdza snake w main
//        // klasa przechwytujaca klawisze
//        // klasa do stanu gry
//        // modyfikacje stanu - > snake porusza sie, ginie, je
//        // glowna petla programu - > co jakis czas aktualizuej stan gry i rysuje
//        //});
//    }
//
//    private void GetRandomDestinationPoints()
//    {
//        Random rand = new Random();
//        random_h = rand.nextInt( available_height );
//        random_w = rand.nextInt( available_width );
//
//    }
//
//     private void GetResolution()
//     {
//         Dimension screen_resolution = Toolkit.getDefaultToolkit().getScreenSize();
//         screen_height = (int) screen_resolution.getHeight();
//         screen_width = (int) screen_resolution.getWidth();
//     }
//
//     private void GetPossibleSizes()
//     {
//         available_height = screen_height - 100;
//         available_width = screen_width-this.getWidth();
//     }
//
//    private void MoveUpLeft()
//    {
//        setLocation(current_x-1,current_y-1);
//       current_x = current_x-1;
//        current_y= current_y-1;
//    }
//    private void MoveDownLeft() {
//        setLocation(current_x - 1, current_y + 1);
//        current_x = current_x -1;
//        current_y = current_y + 1;
//    }
//
//    private void MoveUpRight()
//    {
//        setLocation(current_x+1,current_y-1);
//        current_x = current_x+1;
//        current_y = current_y-1;
//    }
//
//    private void MoveDownRight()
//    {
//        setLocation(current_x+1,current_y+1);
//        current_x= current_x+1;
//        current_y = current_y+1;
//
//    }
//
//    private void MoveLeft()
//    {
//        setLocation(current_x-1,current_y);
//        current_x= current_x-1;
//    }
//
//    private void MoveRight()
//    {
//        setLocation(current_x+1,current_y);
//        current_x= current_x+1;
//    }
//
//    private void MoveUp()
//    {
//        setLocation(current_x,current_y-1);
//        current_y= current_y-1;
//    }
//
//    private void MoveDown()
//    {
//        setLocation(current_x,current_y+1);
//        current_y= current_y+1;
//    }
//
//
//    private void AnimatedButtonMove()
//     {
//         current_x = this.getX();
//         current_y = this.getY();
//
//
//             if (current_x > random_w && current_y > random_h) {
//                 MoveUpLeft();
//             } else if (current_x < random_w && current_y > random_h) {
//                 MoveUpRight();
//             } else if (current_x > random_w && current_y < random_h) {
//                 MoveDownLeft();
//             } else if (current_x < random_w && current_y < random_h) {
//                 MoveDownRight();
//             } else if (current_x == random_w) {
//                 if (current_y < random_h) {
//                     MoveDown();
//                 } else if (current_y > random_h) {
//                     MoveUp();
//                 }
//             } else if (current_y == random_h) {
//                 if (current_x > random_w) {
//                     MoveLeft();
//                 } else if (current_x < random_w) {
//                     MoveRight();
//                 }
//             }
//     }


};
