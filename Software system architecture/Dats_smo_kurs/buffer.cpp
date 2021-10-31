#include "buffer.h"

Dats::Buffer::Buffer()
{
    this->size = 0;
}

Dats::Buffer::Buffer(int size)
{
    this->size = size;
    for (int i = 0; i < size; i++) {
        buffers.push_back(nullptr);
    }
}

bool Dats::Buffer::isFreeBuff()
{
    bool res = false;
    for (int i = 0; i < buffers.size(); i++) {
        if (buffers.at(i) == nullptr)
            res = true;
    }
    return res;
}

bool Dats::Buffer::isEmptyBuff()
{
    bool res = true;
    for (int i = 0; i < buffers.size(); i++) {
        if (buffers.at(i) != nullptr)
            res = false;
    }
    return res;
}

int Dats::Buffer::addNewRequest(Dats::Request request)
{
    for (int i = 0; i < buffers.size(); i++) {
        if (cursor >= buffers.size() || cursor < 0) {
            cursor = 0;
        }
        if (buffers.at(cursor) == nullptr) {
            buffers.at(cursor) = new Request(request.getTimeOfWait(), request.getSourceId(), request.getRequestNumber());
            cursor++;
            return cursor-1;
        }
        cursor++;
    }

    return -1;
}

std::pair<Dats::Request, int> Dats::Buffer::deleteOldRequest()
{
    if (cursor >= buffers.size() || cursor < 0) {
        cursor = 0;
    }

    for (int i = 0; i < buffers.size(); i++) {
        if (i == cursor) {
            Request req = *buffers.at(i);
            buffers.at(i) = nullptr;
            return std::make_pair(req, i);
        }
    }

    return std::make_pair(Request(), -1);
}

std::pair<Dats::Request, int> Dats::Buffer::getRequest()
{
    std::size_t reqToGet = 0;
    bool isSelected = false;
    for (std::size_t i = 0; i < buffers.size(); i++) {
        if (buffers.at(i) != nullptr) {
            if (!isSelected) {
                reqToGet = i;
                isSelected = true;
            }

            if (buffers.at(i)->getSourceId() < buffers.at(reqToGet)->getSourceId()) {
                reqToGet = i;
            } else if (buffers.at(i)->getSourceId() == buffers.at(reqToGet)->getSourceId()) {
                if (buffers.at(i)->getRequestNumber() > buffers.at(reqToGet)->getRequestNumber()) {
                    reqToGet = i;
                }
            }
        }
        if (!isSelected) {
            reqToGet = i;
        }
    }

    Request req = *buffers.at(reqToGet);
    buffers.at(reqToGet) = nullptr;
    if (isSelected)
        return std::make_pair(req, reqToGet);
    else
        return std::make_pair(Dats::Request(), -1);
}
