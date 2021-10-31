#include "request.h"

Dats::Request::Request()
{
    this->timeOfWait = 0.0;
    this->sourceId = 0;
    this->requestNumber = 0;
}

Dats::Request::Request(float timeOfWait, int sourceId, int requestNumber)
{
    this->timeOfWait = timeOfWait;
    this->sourceId = sourceId;
    this->requestNumber = requestNumber;
}

float Dats::Request::getTimeOfWait() const
{
    return timeOfWait;
}

int Dats::Request::getSourceId() const
{
    return sourceId;
}

int Dats::Request::getRequestNumber() const
{
    return requestNumber;
}

void Dats::Request::setTimeOfWait(float value)
{
    timeOfWait = value;
}
