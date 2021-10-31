#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <configure.h>
#include <automode.h>
#include <stepmode.h>

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = nullptr);
    ~MainWindow();

private:
    Ui::MainWindow *ui;

    Configure *configue;
    AutoMode *autoMode;
    StepMode *stepMode;
};

#endif // MAINWINDOW_H
