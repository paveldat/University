/********************************************************************************
** Form generated from reading UI file 'stepmode.ui'
**
** Created by: Qt User Interface Compiler version 5.15.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_STEPMODE_H
#define UI_STEPMODE_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QGraphicsView>
#include <QtWidgets/QGridLayout>
#include <QtWidgets/QHBoxLayout>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QSpacerItem>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_StepMode
{
public:
    QGridLayout *gridLayout;
    QGraphicsView *graphicsStep;
    QHBoxLayout *horizontalLayout;
    QPushButton *buttonNext;
    QSpacerItem *horizontalSpacer;
    QPushButton *buttonRefresh;

    void setupUi(QWidget *StepMode)
    {
        if (StepMode->objectName().isEmpty())
            StepMode->setObjectName(QString::fromUtf8("StepMode"));
        StepMode->resize(603, 376);
        gridLayout = new QGridLayout(StepMode);
        gridLayout->setObjectName(QString::fromUtf8("gridLayout"));
        graphicsStep = new QGraphicsView(StepMode);
        graphicsStep->setObjectName(QString::fromUtf8("graphicsStep"));

        gridLayout->addWidget(graphicsStep, 0, 0, 1, 1);

        horizontalLayout = new QHBoxLayout();
        horizontalLayout->setObjectName(QString::fromUtf8("horizontalLayout"));
        buttonNext = new QPushButton(StepMode);
        buttonNext->setObjectName(QString::fromUtf8("buttonNext"));

        horizontalLayout->addWidget(buttonNext);

        horizontalSpacer = new QSpacerItem(40, 20, QSizePolicy::Expanding, QSizePolicy::Minimum);

        horizontalLayout->addItem(horizontalSpacer);

        buttonRefresh = new QPushButton(StepMode);
        buttonRefresh->setObjectName(QString::fromUtf8("buttonRefresh"));

        horizontalLayout->addWidget(buttonRefresh);


        gridLayout->addLayout(horizontalLayout, 1, 0, 1, 1);


        retranslateUi(StepMode);

        QMetaObject::connectSlotsByName(StepMode);
    } // setupUi

    void retranslateUi(QWidget *StepMode)
    {
        StepMode->setWindowTitle(QCoreApplication::translate("StepMode", "Form", nullptr));
        buttonNext->setText(QCoreApplication::translate("StepMode", "next", nullptr));
        buttonRefresh->setText(QCoreApplication::translate("StepMode", "Refresh", nullptr));
    } // retranslateUi

};

namespace Ui {
    class StepMode: public Ui_StepMode {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_STEPMODE_H
