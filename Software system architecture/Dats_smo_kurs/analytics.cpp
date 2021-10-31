#include "analytics.h"
#include <map>

const std::string Dats::Analytics::StepModel::EMPTY = "null";

Dats::Analytics::Analytics()
{

}

void Dats::Analytics::newRequestGenerate(Dats::Request request)
{
    analytics.push_back(std::make_pair(std::make_pair(request, -1), NEW_REQ));
}

void Dats::Analytics::addRequestToBuff(Dats::Request request, int buff)
{
    analytics.push_back(std::make_pair(std::make_pair(request, buff), ADD_TO_BUFF));
}

void Dats::Analytics::removeRequestFromBuff(Dats::Request request, int buff)
{
    analytics.push_back(std::make_pair(std::make_pair(request, buff), REMOVE_FROM_BUFF));
}

void Dats::Analytics::getRequestFromBuff(Dats::Request request, int buff)
{
    analytics.push_back(std::make_pair(std::make_pair(request, buff), GET_FROM_BUFF));
}

void Dats::Analytics::addRequestToDevice(Dats::Request request, int device)
{
    analytics.push_back(std::make_pair(std::make_pair(request, device), ADD_TO_DEVICE));
}

void Dats::Analytics::removeRequestFromDevice(Dats::Request request, int device)
{
    analytics.push_back(std::make_pair(std::make_pair(request, device), REMOVE_FROM_DEVICE));
}

void Dats::Analytics::beginTransaction()
{
    sourcesAmount = 0;
    buffersAmount = 0;
    devicesAmount = 0;
    analytics.clear();
    req_proc.clear();
    req_fail.clear();
    time_in_system.clear();
    time_of_wait.clear();
    time_of_process.clear();
    disp_tow.clear();
    disp_top.clear();
    prob_of_fail.clear();
    deviceLoad.clear();
    steps.clear();
}

bool Dats::Analytics::config(int sourcesAmount, int buffersAmount, int devicesAmount)
{
    if (sourcesAmount > 0 && buffersAmount > 0 && devicesAmount > 0) {
        this->sourcesAmount = sourcesAmount;
        this->buffersAmount = buffersAmount;
        this->devicesAmount = devicesAmount;

        for (int i = 0; i < sourcesAmount; i++) {
            req_proc.push_back(0);
            req_fail.push_back(0);
            time_in_system.push_back(0);
            time_of_wait.push_back(0);
            time_of_process.push_back(0);
            disp_tow.push_back(0);
            disp_top.push_back(0);
            prob_of_fail.push_back(0);
        }

        for (int i = 0; i < devicesAmount; i++) {
            deviceLoad.push_back(0);
        }

        return true;
    } else {
        return false;
    }
}

void Dats::Analytics::commit(float allWorkTime)
{
    std::map<std::string, std::pair<float, float>> tmpTimeOfWait;
    std::map<std::string, std::pair<float, float>> tmpTimeOfProcess;

    std::map<std::string, std::pair<float, float>> tmpTimeOfDeviceWork;

    std::vector<std::pair<int, std::string>> dataVec;

    steps.push_back(StepModel(dataVec, 0));

    for (auto it = analytics.begin(); it!= analytics.end(); ++it) {
        std::pair<Request, int> reqPair = (*it).first;

        switch ((*it).second) {
        case NEW_REQ:
        {
            dataVec.push_back(std::make_pair(
                                             (reqPair.first.getSourceId() - 1),
                                             std::to_string(reqPair.first.getSourceId()) +
                                             "." +
                                             std::to_string(reqPair.first.getRequestNumber())
                                             ));
        }break;
        case ADD_TO_BUFF:
        {
            std::string tmpKey = std::to_string(reqPair.first.getSourceId()) +
                                 "." +
                                 std::to_string(reqPair.first.getRequestNumber());
            tmpTimeOfWait.insert(std::make_pair(tmpKey, std::make_pair(reqPair.first.getTimeOfWait(), 0)));

            dataVec.push_back(std::make_pair(
                                             (reqPair.second) + sourcesAmount,
                                             std::to_string(reqPair.first.getSourceId()) +
                                             "." +
                                             std::to_string(reqPair.first.getRequestNumber())
                                             ));
            steps.push_back(StepModel(dataVec, reqPair.first.getTimeOfWait()));
            dataVec.clear();
        }break;
        case REMOVE_FROM_BUFF:
        {
            std::string tmpKey = std::to_string(reqPair.first.getSourceId()) +
                                 "." +
                                 std::to_string(reqPair.first.getRequestNumber());
            auto tmpIt = tmpTimeOfWait.find(tmpKey);
            if (tmpIt != tmpTimeOfWait.end()) {
                tmpIt->second.second = reqPair.first.getTimeOfWait();
            }

            *(req_fail.begin() + reqPair.first.getSourceId() - 1) = (*(req_fail.begin() + reqPair.first.getSourceId() - 1)) + 1;

            dataVec.push_back(std::make_pair(
                                             sourcesAmount + buffersAmount + devicesAmount,
                                             std::to_string(reqPair.first.getSourceId()) +
                                             "." +
                                             std::to_string(reqPair.first.getRequestNumber())
                                             ));
            steps.push_back(StepModel(dataVec, reqPair.first.getTimeOfWait()));
            dataVec.clear();
        }break;
        case GET_FROM_BUFF:
        {
            std::string tmpKey = std::to_string(reqPair.first.getSourceId()) +
                                 "." +
                                 std::to_string(reqPair.first.getRequestNumber());
            auto tmpIt = tmpTimeOfWait.find(tmpKey);
            if (tmpIt != tmpTimeOfWait.end()) {
                tmpIt->second.second = reqPair.first.getTimeOfWait();
            }
        }break;
        case ADD_TO_DEVICE:
        {
            std::string tmpKey = std::to_string(reqPair.first.getSourceId()) +
                                 "." +
                                 std::to_string(reqPair.first.getRequestNumber());

            tmpTimeOfDeviceWork.insert(std::make_pair(
                                           std::to_string(reqPair.second) + '.' + tmpKey,
                                           std::make_pair(reqPair.first.getTimeOfWait(), 0)
                                           ));

            tmpTimeOfProcess.insert(std::make_pair(
                                        tmpKey,
                                        std::make_pair(reqPair.first.getTimeOfWait(), 0)
                                        ));

            *(req_proc.begin() + reqPair.first.getSourceId() - 1) = (*(req_proc.begin() + reqPair.first.getSourceId() - 1)) + 1;

            dataVec.push_back(std::make_pair(
                                             (reqPair.second - 1) + sourcesAmount + buffersAmount,
                                             std::to_string(reqPair.first.getSourceId()) +
                                             "." +
                                             std::to_string(reqPair.first.getRequestNumber())
                                             ));
            steps.push_back(StepModel(dataVec, reqPair.first.getTimeOfWait()));
            dataVec.clear();
        }break;
        case REMOVE_FROM_DEVICE:
        {
            std::string tmpKey = std::to_string(reqPair.first.getSourceId()) +
                                 "." +
                                 std::to_string(reqPair.first.getRequestNumber());

            auto tmpIt = tmpTimeOfDeviceWork.find(std::to_string(reqPair.second) + '.' + tmpKey);
            if (tmpIt != tmpTimeOfDeviceWork.end()) {
                tmpIt->second.second = reqPair.first.getTimeOfWait();
            }

            auto tmpIt2 = tmpTimeOfProcess.find(tmpKey);
            if (tmpIt2 != tmpTimeOfProcess.end()) {
                tmpIt2->second.second = reqPair.first.getTimeOfWait();
            }
        }break;
        }
    }

    // count times
    std::vector<float> totalTOW;
    std::vector<float> totalTOP;
    std::vector<float> totalDevWork;

    for (int i = 0; i < sourcesAmount; i++) {
        totalTOW.push_back(0);
        totalTOP.push_back(0);
    }

    for (int i = 0; i < devicesAmount; i++) {
        totalDevWork.push_back(0);
    }

    for (auto it = tmpTimeOfDeviceWork.begin(); it != tmpTimeOfDeviceWork.end(); ++it) {
        std::string indexStr = "";
        for (char ch : it->first) {
            if (ch == '.') {
                break;
            } else {
                indexStr.push_back(ch);
            }
        }
        int index = std::stoi(indexStr);

        std::pair<float, float> pairDevWork = it->second;

        if (pairDevWork.second == 0)
            continue;

        totalDevWork.at(index - 1) += std::max(pairDevWork.first, pairDevWork.second) - std::min(pairDevWork.first, pairDevWork.second);
    }

    for (auto it = tmpTimeOfWait.begin(); it != tmpTimeOfWait.end(); ++it) {
        std::string indexStr = "";
        for (char ch : it->first) {
            if (ch == '.') {
                break;
            } else {
                indexStr.push_back(ch);
            }
        }
        int index = std::stoi(indexStr);

        std::pair<float, float> pairTOW = it->second;

        if (pairTOW.second == 0)
            continue;

        totalTOW.at(index - 1) += std::max(pairTOW.first, pairTOW.second) - std::min(pairTOW.first, pairTOW.second);
    }

    for (auto it = tmpTimeOfWait.begin(); it != tmpTimeOfWait.end(); ++it) {
        std::string indexStr = "";
        for (char ch : it->first) {
            if (ch == '.') {
                break;
            } else {
                indexStr.push_back(ch);
            }
        }
        int index = std::stoi(indexStr);

        std::pair<float, float> pairTOP = it->second;

        if (pairTOP.second == 0)
            continue;

        totalTOP.at(index - 1) += std::max(pairTOP.first, pairTOP.second) - std::min(pairTOP.first, pairTOP.second);
    }

    for (int i =0; i < deviceLoad.size(); i++) {
        deviceLoad.at(i) = (totalDevWork.at(i)/allWorkTime)*100;
    }

    for (int i =0; i < time_of_wait.size(); i++) {
        time_of_wait.at(i) = totalTOW.at(i)/tmpTimeOfWait.size();
    }

    for (int i =0; i < time_of_process.size(); i++) {
        time_of_process.at(i) = totalTOP.at(i)/tmpTimeOfProcess.size();
    }

    for (int i = 0; i < time_in_system.size(); i++) {
        time_in_system.at(i) = time_of_wait.at(i) + time_of_process.at(i);
    }

    for (int i = 0; i < prob_of_fail.size(); i++) {
        float a = req_fail.at(i);
        float b = req_proc.at(i);
        prob_of_fail.at(i) = (a/(a + b))*100;
    }

    for (int i = 0; i < disp_top.size(); i++) {
        disp_top.at(i) = (time_of_process.at(i)/time_in_system.at(i));
    }

    for (int i = 0; i < disp_tow.size(); i++) {
        disp_tow.at(i) = (time_of_wait.at(i)/time_in_system.at(i));
    }
}

std::vector<Dats::Analytics::StepModel> Dats::Analytics::getSteps() const
{
    return steps;
}

int Dats::Analytics::getLinesAmount() const
{
    return sourcesAmount + buffersAmount + devicesAmount;
}

int Dats::Analytics::getDevicesAmount() const
{
    return devicesAmount;
}

int Dats::Analytics::getBuffersAmount() const
{
    return buffersAmount;
}

int Dats::Analytics::getSourcesAmount() const
{
    return sourcesAmount;
}

std::vector<float> Dats::Analytics::getDeviceLoad() const
{
    return deviceLoad;
}

std::vector<float> Dats::Analytics::getProb_of_fail() const
{
    return prob_of_fail;
}

std::vector<float> Dats::Analytics::getDisp_top() const
{
    return disp_top;
}

std::vector<float> Dats::Analytics::getDisp_tow() const
{
    return disp_tow;
}

std::vector<float> Dats::Analytics::getTime_of_process() const
{
    return time_of_process;
}

std::vector<float> Dats::Analytics::getTime_of_wait() const
{
    return time_of_wait;
}

std::vector<float> Dats::Analytics::getTime_in_system() const
{
    return time_in_system;
}

std::vector<int> Dats::Analytics::getReq_fail() const
{
    return req_fail;
}

std::vector<int> Dats::Analytics::getReq_proc() const
{
    return req_proc;
}
