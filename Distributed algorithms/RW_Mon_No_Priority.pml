#define nWriters 3
#define nReaders 3

//LTL formuls
#define mutex1 {[]((crR >= 1 -> crW == 0) && (crW <= 1) && (crW == 1 -> crR == 0))}
#define mutex2 {[]((RW.readers >= 1 -> RW.writers == 0) && (RW.writers <= 1) && (RW.writers == 1 -> RW.readers == 0))}
#define mutex3 {[]((RW.writers == 1 && RW.readers == 0) || (RW.writers == 0 && RW.readers == 1))}
#define starvR {[](wantR[0] -> <>critR[0]) && [](wantR[1] -> <>critR[1]) && [](wantR[2] -> <>critR[2])}
#define starvW {[](wantW[0] -> <>critW[0]) && [](wantW[1] -> <>critW[1]) && [](wantW[2] -> <>critW[2])}

#define emptyC(C) (C.waiting == 0)

typedef Condition {
    bool gate;
    int waiting;
}

typedef Monitor {
    int readers;
    int writers;
    Condition OKtoRead;
    Condition OKtoWrite;
}

inline initMon(M, r, w) {
    M.readers = r;
    M.writers = w;
}

inline enterMon(){
atomic{
    !lock;
    lock = true;
}
}

inline leaveMon(){
    lock = false;
}

inline waitC(C){
atomic {
    C.waiting++;
    lock = false;
    C.gate;
    C.gate = false;
    C.waiting--;
}
}

inline signalC(C) {
atomic {
    if
    ::(C.waiting > 0) ->
        C.gate = true; 
        !lock; 
        lock = true; 
    ::else;
    fi;
}
}

Monitor RW;
bool lock = false;
bool wantR[nReaders], wantW[nWriters], critR[nReaders], critW[nWriters];
int crR = 0, crW = 0;


inline StartRead() {
    enterMon();
    atomic{
        if 
        :: (RW.writers != 0 || !emptyC(RW.OKtoWrite)) -> waitC(RW.OKtoRead);
        ::else;
        fi;
    }
    RW.readers++;
    signalC(RW.OKtoRead);
    leaveMon();
}

inline StartWrite() {
    enterMon();
    atomic{
    if 
    :: (RW.writers != 0 || RW.readers != 0) -> waitC(RW.OKtoWrite);
    :: else;
    fi;
    }
    RW.writers++;
    leaveMon();
}

inline EndRead() {
    enterMon();
    RW.readers--;
    atomic{
    if
    :: (RW.readers == 0) -> signalC(RW.OKtoWrite);
    :: else;
    fi;
    }
    leaveMon();
}

inline EndWrite() {
    enterMon();
    RW.writers--;
    atomic{
        if
        :: (emptyC(RW.OKtoRead)) -> signalC(RW.OKtoWrite);
        :: else ->  signalC(RW.OKtoRead);
        fi;
    }
    leaveMon();
}

proctype reader (int i){
do
    ::
    wantR[i] = true;
    StartRead();
    critR[i] = true;
    crR++;
    crR--;
    critR[i] = false;
    EndRead();
    wantR[i] = false;
od;
}

proctype writer (int i){
do
    ::
    wantW[i] = true;
    StartWrite();
    critW[i] = true;
    crW++;
    crW--;
    critW[i] = false;
    EndWrite();
    wantW[i] = false;
od;
}


init {
atomic {
    lock = false;
    initMon(RW, 0, 0);
    int i;
    for (i : 0..2){
        run writer (i);
        run reader (i);
    }
}
}
