#ifndef DEVICE_H
#define DEVICE_H

#include <list>
#include <vector>
#include <utility>
#include "request.h"

namespace Dats{
class Device
{
public:
    Device();
    Device(int size, float lambda);

    bool isFreeDevice();

    int addNewRequest(float currentTime, Request request);
    std::list<std::pair<Request, int>> freeDoneDevices(float currentTime);
private:
    int size;
    float lambda;

    std::vector<std::pair<float, Request> *> devices;

    int cursor = 0;
};
}

#endif // DEVICE_H
