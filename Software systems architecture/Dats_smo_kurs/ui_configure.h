/********************************************************************************
** Form generated from reading UI file 'configure.ui'
**
** Created by: Qt User Interface Compiler version 5.15.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_CONFIGURE_H
#define UI_CONFIGURE_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QGridLayout>
#include <QtWidgets/QHBoxLayout>
#include <QtWidgets/QLabel>
#include <QtWidgets/QLineEdit>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QSpacerItem>
#include <QtWidgets/QVBoxLayout>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_Configure
{
public:
    QGridLayout *gridLayout;
    QVBoxLayout *verticalLayout_3;
    QHBoxLayout *horizontalLayout;
    QVBoxLayout *verticalLayout_2;
    QLabel *label;
    QLabel *label_2;
    QLabel *label_3;
    QLabel *label_4;
    QLabel *label_5;
    QLabel *label_6;
    QLabel *label_7;
    QVBoxLayout *verticalLayout;
    QLineEdit *editNumSourc;
    QLineEdit *editNumBuff;
    QLineEdit *editNumDev;
    QLineEdit *editNumReq;
    QLineEdit *editAlpha;
    QLineEdit *editBeta;
    QLineEdit *editLambda;
    QPushButton *buttonConfigure;
    QSpacerItem *horizontalSpacer;
    QSpacerItem *horizontalSpacer_2;
    QSpacerItem *verticalSpacer;

    void setupUi(QWidget *Configure)
    {
        if (Configure->objectName().isEmpty())
            Configure->setObjectName(QString::fromUtf8("Configure"));
        Configure->resize(662, 486);
        gridLayout = new QGridLayout(Configure);
        gridLayout->setObjectName(QString::fromUtf8("gridLayout"));
        verticalLayout_3 = new QVBoxLayout();
        verticalLayout_3->setObjectName(QString::fromUtf8("verticalLayout_3"));
        horizontalLayout = new QHBoxLayout();
        horizontalLayout->setObjectName(QString::fromUtf8("horizontalLayout"));
        verticalLayout_2 = new QVBoxLayout();
        verticalLayout_2->setObjectName(QString::fromUtf8("verticalLayout_2"));
        label = new QLabel(Configure);
        label->setObjectName(QString::fromUtf8("label"));

        verticalLayout_2->addWidget(label);

        label_2 = new QLabel(Configure);
        label_2->setObjectName(QString::fromUtf8("label_2"));

        verticalLayout_2->addWidget(label_2);

        label_3 = new QLabel(Configure);
        label_3->setObjectName(QString::fromUtf8("label_3"));

        verticalLayout_2->addWidget(label_3);

        label_4 = new QLabel(Configure);
        label_4->setObjectName(QString::fromUtf8("label_4"));

        verticalLayout_2->addWidget(label_4);

        label_5 = new QLabel(Configure);
        label_5->setObjectName(QString::fromUtf8("label_5"));

        verticalLayout_2->addWidget(label_5);

        label_6 = new QLabel(Configure);
        label_6->setObjectName(QString::fromUtf8("label_6"));

        verticalLayout_2->addWidget(label_6);

        label_7 = new QLabel(Configure);
        label_7->setObjectName(QString::fromUtf8("label_7"));

        verticalLayout_2->addWidget(label_7);


        horizontalLayout->addLayout(verticalLayout_2);

        verticalLayout = new QVBoxLayout();
        verticalLayout->setObjectName(QString::fromUtf8("verticalLayout"));
        editNumSourc = new QLineEdit(Configure);
        editNumSourc->setObjectName(QString::fromUtf8("editNumSourc"));

        verticalLayout->addWidget(editNumSourc);

        editNumBuff = new QLineEdit(Configure);
        editNumBuff->setObjectName(QString::fromUtf8("editNumBuff"));

        verticalLayout->addWidget(editNumBuff);

        editNumDev = new QLineEdit(Configure);
        editNumDev->setObjectName(QString::fromUtf8("editNumDev"));

        verticalLayout->addWidget(editNumDev);

        editNumReq = new QLineEdit(Configure);
        editNumReq->setObjectName(QString::fromUtf8("editNumReq"));

        verticalLayout->addWidget(editNumReq);

        editAlpha = new QLineEdit(Configure);
        editAlpha->setObjectName(QString::fromUtf8("editAlpha"));

        verticalLayout->addWidget(editAlpha);

        editBeta = new QLineEdit(Configure);
        editBeta->setObjectName(QString::fromUtf8("editBeta"));

        verticalLayout->addWidget(editBeta);

        editLambda = new QLineEdit(Configure);
        editLambda->setObjectName(QString::fromUtf8("editLambda"));

        verticalLayout->addWidget(editLambda);


        horizontalLayout->addLayout(verticalLayout);


        verticalLayout_3->addLayout(horizontalLayout);

        buttonConfigure = new QPushButton(Configure);
        buttonConfigure->setObjectName(QString::fromUtf8("buttonConfigure"));

        verticalLayout_3->addWidget(buttonConfigure);


        gridLayout->addLayout(verticalLayout_3, 0, 1, 1, 1);

        horizontalSpacer = new QSpacerItem(32, 20, QSizePolicy::Expanding, QSizePolicy::Minimum);

        gridLayout->addItem(horizontalSpacer, 0, 0, 1, 1);

        horizontalSpacer_2 = new QSpacerItem(40, 20, QSizePolicy::Expanding, QSizePolicy::Minimum);

        gridLayout->addItem(horizontalSpacer_2, 0, 2, 1, 1);

        verticalSpacer = new QSpacerItem(20, 40, QSizePolicy::Minimum, QSizePolicy::Expanding);

        gridLayout->addItem(verticalSpacer, 1, 1, 1, 1);


        retranslateUi(Configure);

        QMetaObject::connectSlotsByName(Configure);
    } // setupUi

    void retranslateUi(QWidget *Configure)
    {
        Configure->setWindowTitle(QCoreApplication::translate("Configure", "Form", nullptr));
        label->setText(QCoreApplication::translate("Configure", "Number of sources", nullptr));
        label_2->setText(QCoreApplication::translate("Configure", "Number of buffers", nullptr));
        label_3->setText(QCoreApplication::translate("Configure", "Number of devices", nullptr));
        label_4->setText(QCoreApplication::translate("Configure", "Number of requests", nullptr));
        label_5->setText(QCoreApplication::translate("Configure", "Alpha", nullptr));
        label_6->setText(QCoreApplication::translate("Configure", "Beta", nullptr));
        label_7->setText(QCoreApplication::translate("Configure", "Lambda", nullptr));
        buttonConfigure->setText(QCoreApplication::translate("Configure", "Configure", nullptr));
    } // retranslateUi

};

namespace Ui {
    class Configure: public Ui_Configure {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_CONFIGURE_H
