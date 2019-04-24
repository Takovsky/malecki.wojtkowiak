import javax.swing.*;
import javax.swing.table.DefaultTableModel;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

class MainWindow extends JFrame {
    private JTable tablePeople;
    private JTextField textFieldSurname;
    private JTextField textFieldAge;
    private JPanel panelMain;
    private JButton buttonAddNewPerson;
    private JTextField textFieldName;

    MainWindow() {
        this.setSize(600, 500);
        this.setTitle("Platformy programistyczne .Net i Java, labolatorium, Java, lab01");
        this.setContentPane(panelMain);
        buttonAddNewPerson.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                try{
                    Person person = new Person();
                    person.setName(textFieldName.getText());
                    person.setSurname(textFieldSurname.getText());
                    person.setAge(Integer.parseInt(textFieldAge.getText()));
                    addPersonToList(person);
                } catch(NumberFormatException ex) {
                    JOptionPane.showMessageDialog(panelMain, "Wrong age passed.");
                }
            }
        });
    }

    private void addPersonToList(Person person){
        DefaultTableModel tableModel = (DefaultTableModel)tablePeople.getModel();
        tableModel.addRow(new Object[] {
                person.getName(),
                person.getSurname(),
                person.getAge()
        });
    }

    private void createUIComponents() {
        Object[] columnNames = {
                "Name",
                "Surname",
                "Age"
        };
        tablePeople = new JTable(new DefaultTableModel(columnNames, 0));
    }
}
