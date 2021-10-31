#ifndef REQUEST_H
#define REQUEST_H

namespace Dats {
class Request
{
public:
    Request();
    Request(float timeOfWait, int sourceId, int requestNumber);

    float getTimeOfWait() const;
    int getSourceId() const;
    int getRequestNumber() const;

    void setTimeOfWait(float value);

private:
    float timeOfWait;
    int sourceId;
    int requestNumber;
};
}

#endif // REQUEST_H
