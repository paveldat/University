/********************************************************************************
** Form generated from reading UI file 'automode.ui'
**
** Created by: Qt User Interface Compiler version 5.15.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_AUTOMODE_H
#define UI_AUTOMODE_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QGridLayout>
#include <QtWidgets/QHBoxLayout>
#include <QtWidgets/QHeaderView>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QSpacerItem>
#include <QtWidgets/QTableWidget>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_AutoMode
{
public:
    QGridLayout *gridLayout;
    QTableWidget *tableSources;
    QTableWidget *tableDevices;
    QHBoxLayout *horizontalLayout;
    QSpacerItem *horizontalSpacer;
    QPushButton *buttonRefresh;

    void setupUi(QWidget *AutoMode)
    {
        if (AutoMode->objectName().isEmpty())
            AutoMode->setObjectName(QString::fromUtf8("AutoMode"));
        AutoMode->resize(847, 582);
        gridLayout = new QGridLayout(AutoMode);
        gridLayout->setObjectName(QString::fromUtf8("gridLayout"));
        tableSources = new QTableWidget(AutoMode);
        tableSources->setObjectName(QString::fromUtf8("tableSources"));

        gridLayout->addWidget(tableSources, 0, 0, 1, 1);

        tableDevices = new QTableWidget(AutoMode);
        tableDevices->setObjectName(QString::fromUtf8("tableDevices"));

        gridLayout->addWidget(tableDevices, 1, 0, 1, 1);

        horizontalLayout = new QHBoxLayout();
        horizontalLayout->setObjectName(QString::fromUtf8("horizontalLayout"));
        horizontalSpacer = new QSpacerItem(40, 20, QSizePolicy::Expanding, QSizePolicy::Minimum);

        horizontalLayout->addItem(horizontalSpacer);

        buttonRefresh = new QPushButton(AutoMode);
        buttonRefresh->setObjectName(QString::fromUtf8("buttonRefresh"));

        horizontalLayout->addWidget(buttonRefresh);


        gridLayout->addLayout(horizontalLayout, 3, 0, 1, 1);


        retranslateUi(AutoMode);

        QMetaObject::connectSlotsByName(AutoMode);
    } // setupUi

    void retranslateUi(QWidget *AutoMode)
    {
        AutoMode->setWindowTitle(QCoreApplication::translate("AutoMode", "Form", nullptr));
        buttonRefresh->setText(QCoreApplication::translate("AutoMode", "Refresh", nullptr));
    } // retranslateUi

};

namespace Ui {
    class AutoMode: public Ui_AutoMode {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_AUTOMODE_H
