#ifndef STEPMODE_H
#define STEPMODE_H

#include <QWidget>
#include <analytics.h>
#include <QGraphicsScene>
#include <QGraphicsRectItem>
#include <QGraphicsTextItem>

namespace Ui {
class StepMode;
}

class StepMode : public QWidget
{
    Q_OBJECT

public:
    explicit StepMode(QWidget *parent = nullptr);
    ~StepMode();

    void setAnalytics(Dats::Analytics *value);

private slots:
    void on_buttonRefresh_clicked();

    void on_buttonNext_clicked();

private:
    void refreshScene();
    void prepareScene();

    Ui::StepMode *ui;

    Dats::Analytics *analytics;

    int currentStep;
    float leftTime;
    float rightTime;

    int scaleY = 50;
    int scaleX = 50*5;
    int dashHeight = 15;

    QGraphicsScene *scene;
};

#endif // STEPMODE_H
