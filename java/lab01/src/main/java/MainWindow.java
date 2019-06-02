import javax.swing.*;
import java.awt.*;
import java.awt.event.KeyEvent;

public class MainWindow extends JFrame{



    MainWindow()
    {
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setTitle("snake game");
        setResizable(false);
        setLayout(new GridLayout(1,1,0,0));


        Board tablica = new Board();
        add(tablica);
        pack();

        setLocationRelativeTo(null);
        setVisible(true);



    }


}
