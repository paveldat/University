#ifndef CONFIGURE_H
#define CONFIGURE_H

#include <QWidget>
#include <controller.h>

namespace Ui {
class Configure;
}

class Configure : public QWidget
{
    Q_OBJECT

public:
    explicit Configure(QWidget *parent = nullptr);
    ~Configure();

    void setAnalytics(Dats::Analytics *value);

private slots:
    void on_buttonConfigure_clicked();

private:
    Ui::Configure *ui;

    Dats::Controller controller;
    Dats::Analytics *analytics;
};

#endif // CONFIGURE_H
