#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);

    Dats::Analytics *analytics = new Dats::Analytics();

    configue = new Configure();
    configue->setAnalytics(analytics);
    autoMode = new AutoMode();
    autoMode->setAnalytics(analytics);
    stepMode = new StepMode();
    stepMode->setAnalytics(analytics);

    ui->tabWidget->addTab(configue->topLevelWidget(), "Configure");
    ui->tabWidget->addTab(autoMode->topLevelWidget(), "Auto mode");
    ui->tabWidget->addTab(stepMode->topLevelWidget(), "Step mode");
}

MainWindow::~MainWindow()
{
    delete ui;
}
