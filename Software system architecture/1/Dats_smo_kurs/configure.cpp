#include "configure.h"
#include "ui_configure.h"

Configure::Configure(QWidget *parent) :
    QWidget(parent),
    ui(new Ui::Configure)
{
    ui->setupUi(this);
}

Configure::~Configure()
{
    delete ui;
}

void Configure::setAnalytics(Dats::Analytics *value)
{
    analytics = value;
}

void Configure::on_buttonConfigure_clicked()
{
    if (!ui->editAlpha->text().isEmpty() && !ui->editBeta->text().isEmpty() && !ui->editLambda->text().isEmpty() &&
        !ui->editNumSourc->text().isEmpty() && !ui->editNumBuff->text().isEmpty() && !ui->editNumDev->text().isEmpty() &&
        !ui->editNumReq->text().isEmpty()) {

        float alpha = ui->editAlpha->text().toFloat();
        float beta = ui->editBeta->text().toFloat();
        float lambda = ui->editLambda->text().toFloat();
        int numOfSourc = ui->editNumSourc->text().toInt();
        int numOfDev = ui->editNumDev->text().toInt();
        int numOfBuff = ui->editNumBuff->text().toInt();
        int numOfReq = ui->editNumReq->text().toInt();

        controller.setAlpha(alpha);
        controller.setBeta(beta);
        controller.setLambda(lambda);
        controller.setSourcesAmount(numOfSourc);
        controller.setBuffersAmount(numOfBuff);
        controller.setDevicesAmount(numOfDev);
        controller.setRequestsNumber(numOfReq);

        controller.modulateWork(*analytics);
    }
}
