import sun.applet.Main;

import java.awt.EventQueue;

public class App{

    public static void main(String[] args){
        EventQueue.invokeLater(new Runnable(){
            public void run() {

                MainWindow frame = new MainWindow();

            }
        });
    }
}