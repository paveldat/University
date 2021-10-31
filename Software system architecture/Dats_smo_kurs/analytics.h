#ifndef ANALYTICS_H
#define ANALYTICS_H

#include "request.h"
#include <vector>
#include <string>
#include <set>

namespace Dats{
class Analytics
{
public:
    class StepModel{
    public:
        StepModel(std::vector<std::pair<int, std::string>> data,
        float currentTime) {
            this->data = data;
            this->currentTime = currentTime;
        }

        std::vector<std::pair<int, std::string>> data;
        float currentTime;

        static const std::string EMPTY;
    };

    Analytics();

    // Make analytics
    void newRequestGenerate(Request request);
    void addRequestToBuff(Request request, int buff);
    void removeRequestFromBuff(Request request, int buff);
    void getRequestFromBuff(Request request, int buff);
    void addRequestToDevice(Request request, int device);
    void removeRequestFromDevice(Request request, int device);

    void beginTransaction();
    bool config(int sourcesAmount, int buffersAmount, int devicesAmount);
    void commit(float allWorkTime);

    // Get analytics

    // Auto mode
    std::vector<int>    getReq_proc() const;
    std::vector<int>    getReq_fail() const;
    std::vector<float>  getTime_in_system() const;
    std::vector<float>  getTime_of_wait() const;
    std::vector<float>  getTime_of_process() const;
    std::vector<float>  getDisp_tow() const;
    std::vector<float>  getDisp_top() const;
    std::vector<float>  getProb_of_fail() const;
    std::vector<float>  getDeviceLoad() const;

    // Step mode
    std::vector<StepModel> getSteps() const;
    int getLinesAmount() const;
    static const int NUM_OF_DISPLAY_AREAS = 4;

    int getSourcesAmount() const;
    int getBuffersAmount() const;
    int getDevicesAmount() const;

private:
    enum Act
    {
        NEW_REQ,
        ADD_TO_BUFF,
        REMOVE_FROM_BUFF,
        GET_FROM_BUFF,
        ADD_TO_DEVICE,
        REMOVE_FROM_DEVICE
    };
    std::vector<std::pair<std::pair<Request, int>, Act>> analytics;

    // Auto mode
    std::vector<int>    req_proc;
    std::vector<int>    req_fail;
    std::vector<float>  time_in_system;
    std::vector<float>  time_of_wait;
    std::vector<float>  time_of_process;
    std::vector<float>  disp_tow;
    std::vector<float>  disp_top;
    std::vector<float>  prob_of_fail;
    std::vector<float>  deviceLoad;

    // Step mode
    std::vector<StepModel> steps;

    // Configurations
    int sourcesAmount;
    int buffersAmount;
    int devicesAmount;
};
}

#endif // ANALYTICS_H
