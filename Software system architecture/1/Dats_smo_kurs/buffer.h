#ifndef BUFFER_H
#define BUFFER_H

#include "request.h"
#include <vector>

namespace Dats {
class Buffer
{
public:
    Buffer();
    Buffer(int size);

    bool isFreeBuff();
    bool isEmptyBuff();

    int addNewRequest(Request request);
    std::pair<Request, int> deleteOldRequest();
    std::pair<Request, int> getRequest();
private:
    int size;

    std::vector<Request *> buffers;

    int cursor = 0;
};
}

#endif // BUFFER_H
