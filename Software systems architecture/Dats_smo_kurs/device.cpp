#include "device.h"
#include <algorithm>
#include <QApplication>
#include <math.h>

Dats::Device::Device()
{
    this->size = 0;
    this->lambda = 0;
}

Dats::Device::Device(int size, float lambda)
{
    this->size = size;
    this->lambda = lambda;
    for (int i = 0; i < size; i++) {
        devices.push_back(nullptr);
    }
}

bool Dats::Device::isFreeDevice()
{
    bool res = false;
    for (int i = 0; i < devices.size(); i++) {
        if (devices.at(i) == nullptr)
            res = true;
    }
    return res;
}

int Dats::Device::addNewRequest(float currentTime, Dats::Request request)
{
    float timeToDo = currentTime + ((log(1 - ((float)qrand()/(float)RAND_MAX)))*(-1/this->lambda));

    for (int i = 0; i < devices.size(); i++) {
        if (cursor >= devices.size() || cursor < 0) {
            cursor = 0;
        }
        if (devices.at(cursor) == nullptr) {
            devices.at(cursor) = new std::pair<float, Request>(timeToDo, Request(request.getTimeOfWait(), request.getSourceId(), request.getRequestNumber()));
            cursor++;
            return cursor;
        }
        cursor++;
    }

    return -1;
}

std::list<std::pair<Dats::Request, int> > Dats::Device::freeDoneDevices(float currentTime)
{
    std::list<std::pair<Request, int>> tmpList;
    std::vector<std::pair<float, Request> *> devicesTmp;

    for (int i = 0; i < devices.size(); i++) {
        if (devices.at(i) != nullptr) {
            if ((*devices.at(i)).first < currentTime) {
                tmpList.push_back(std::make_pair(
                                      Request(
                                          (*devices.at(i)).first,
                                          (*devices.at(i)).second.getSourceId(),
                                          (*devices.at(i)).second.getRequestNumber()
                                          ),
                                      i + 1));
                devicesTmp.push_back(nullptr);
            } else {
                devicesTmp.push_back(devices.at(i));
            }
        } else {
            devicesTmp.push_back(nullptr);
        }
    }

    devices = devicesTmp;

    return tmpList;
}
