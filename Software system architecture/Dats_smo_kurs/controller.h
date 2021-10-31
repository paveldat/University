#ifndef CONTROLLER_H
#define CONTROLLER_H

#include <list>
#include <string>
#include "analytics.h"

namespace Dats {
class Controller
{
public:
    Controller();

    std::list<std::string> modulateWork(Analytics &analytics);

    void setAlpha(float value);
    void setBeta(float value);
    void setLambda(float value);

    void setSourcesAmount(int value);
    void setBuffersAmount(int value);
    void setDevicesAmount(int value);

    void setRequestsNumber(int value);

private:
    float alpha;
    float beta;
    float lambda;

    int sourcesAmount;
    int buffersAmount;
    int devicesAmount;

    int requestsNumber;
};
}

#endif // CONTROLLER_H
