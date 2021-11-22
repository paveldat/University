#include "automode.h"
#include "ui_automode.h"

AutoMode::AutoMode(QWidget *parent) :
    QWidget(parent),
    ui(new Ui::AutoMode)
{
    ui->setupUi(this);
}

AutoMode::~AutoMode()
{
    delete ui;
}

void AutoMode::setAnalytics(Dats::Analytics *value)
{
    analytics = value;
}

void AutoMode::showAnalytics()
{
    const int columnAmountSrc = 8;
    ui->tableSources->setRowCount(analytics->getReq_proc().size());
    ui->tableSources->setColumnCount(columnAmountSrc);

    ui->tableSources->setHorizontalHeaderLabels(QStringList() << "Req.Proc"<< "Req.Fail."<< "TIS"<< "TOW"<< "TOP"<< "Disp. TOW"<< "Disp. TOP"<< "Prob. of fail");

    for (int i=0; i < ui->tableSources->rowCount(); i++) {
        ui->tableSources->setVerticalHeaderItem(i, new QTableWidgetItem(("Source " + std::to_string(i+1)).c_str()));

        ui->tableSources->setItem(i, 0, new QTableWidgetItem((std::to_string(analytics->getReq_proc().at(i))).c_str()));
        ui->tableSources->setItem(i, 1, new QTableWidgetItem((std::to_string(analytics->getReq_fail().at(i))).c_str()));
        ui->tableSources->setItem(i, 2, new QTableWidgetItem((std::to_string(analytics->getTime_in_system().at(i))).c_str()));
        ui->tableSources->setItem(i, 3, new QTableWidgetItem((std::to_string(analytics->getTime_of_wait().at(i))).c_str()));
        ui->tableSources->setItem(i, 4, new QTableWidgetItem((std::to_string(analytics->getTime_of_process().at(i))).c_str()));
        ui->tableSources->setItem(i, 5, new QTableWidgetItem((std::to_string(analytics->getDisp_tow().at(i))).c_str()));
        ui->tableSources->setItem(i, 6, new QTableWidgetItem((std::to_string(analytics->getDisp_top().at(i))).c_str()));
        ui->tableSources->setItem(i, 7, new QTableWidgetItem((std::to_string(analytics->getProb_of_fail().at(i)) + "%").c_str()));
    }

    const int columnAmountDev = 1;
    ui->tableDevices->setRowCount(analytics->getDeviceLoad().size());
    ui->tableDevices->setColumnCount(columnAmountDev);

    ui->tableDevices->setHorizontalHeaderLabels(QStringList() << "Coefficient");

    for (int i=0; i < ui->tableDevices->rowCount(); i++) {
        ui->tableDevices->setVerticalHeaderItem(i, new QTableWidgetItem(("Device " + std::to_string(i+1)).c_str()));
        ui->tableDevices->setItem(i, 0, new QTableWidgetItem((std::to_string(analytics->getDeviceLoad().at(i)) + "%").c_str()));
    }
}

void AutoMode::on_buttonRefresh_clicked()
{
    showAnalytics();
}
