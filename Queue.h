#include "LinkedList.h"

#ifndef QUEUE_H
#define QUEUE_H
class Queue
{
    LinkedList *data;
    int length = 0;

public:
    Queue() {data = new LinkedList();}
    bool Enqueue(void *content);
    void *Dequeue();
    ~Queue();
};
#endif