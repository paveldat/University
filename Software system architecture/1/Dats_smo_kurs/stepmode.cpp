#include "stepmode.h"
#include "ui_stepmode.h"

StepMode::StepMode(QWidget *parent) :
    QWidget(parent),
    ui(new Ui::StepMode)
{
    ui->setupUi(this);

    scene = new QGraphicsScene(this);
    ui->graphicsStep->setScene(scene);
}

StepMode::~StepMode()
{
    delete ui;
}

void StepMode::setAnalytics(Dats::Analytics *value)
{
    analytics = value;
}

void StepMode::refreshScene()
{
    scene->clear();
    currentStep = 0;
    leftTime = 0;
    rightTime = 0;
}

void StepMode::prepareScene()
{
    float xShift = -0.25;
    int lineIndex = 0;
    for (int i=0; i <analytics->getSourcesAmount(); i++) {
        QGraphicsTextItem *textTmp = scene->addText(("Source"+std::to_string(i+1)).c_str());
        textTmp->setX(xShift*scaleX);
        textTmp->setY(lineIndex*scaleY);
        lineIndex++;
    }
    for (int i=0; i <analytics->getBuffersAmount(); i++) {
        QGraphicsTextItem *textTmp = scene->addText(("Buffers"+std::to_string(i+1)).c_str());
        textTmp->setX(xShift*scaleX);
        textTmp->setY(lineIndex*scaleY);
        lineIndex++;
    }
    for (int i=0; i <analytics->getDevicesAmount(); i++) {
        QGraphicsTextItem *textTmp = scene->addText(("Devices"+std::to_string(i+1)).c_str());
        textTmp->setX(xShift*scaleX);
        textTmp->setY(lineIndex*scaleY);
        lineIndex++;
    }
    QGraphicsTextItem *cancel = scene->addText("Cancel:");
    cancel->setX(xShift*scaleX);
    cancel->setY(lineIndex*scaleY);
}

void StepMode::on_buttonRefresh_clicked()
{
    refreshScene();
    prepareScene();
}

void StepMode::on_buttonNext_clicked()
{
    if (analytics->getSteps().size() <= 0)
        return;
    if (currentStep + 1 >= analytics->getSteps().size())
        return;
    if (currentStep < 0){
        currentStep++;
        return;
    }

    currentStep++;

    QBrush whiteBrush(Qt::white);
    QPen blackPen(Qt::black);
    blackPen.setWidth(2);

    Dats::Analytics::StepModel stepModel = analytics->getSteps().at(currentStep);
    leftTime = rightTime;
    rightTime = stepModel.currentTime;

    for (int i=0; i <= analytics->getLinesAmount(); i++) {
        scene->addLine(
                        QLineF(leftTime*scaleX, i*scaleY, rightTime*scaleX, i*scaleY),
                        blackPen
                    );
        for (auto item : stepModel.data) {
            if (item.first == i) {
                scene->addLine(
                            QLineF(rightTime*scaleX, i*scaleY, rightTime*scaleX, i*scaleY - dashHeight),
                            blackPen
                            );
                QGraphicsTextItem *textTmp = scene->addText(item.second.c_str());
                textTmp->setX(rightTime*scaleX);
                textTmp->setY(i*scaleY);
            }
        }
    }
}
