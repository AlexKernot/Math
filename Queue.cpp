#include "Queue.h"

bool Queue::Enqueue(void *content)
{
    bool result = data->AddNode(length, content);
    ++length;
    return (result);
}

void *Queue::Dequeue()
{
    --length;
    void *content = data->GetContent(length);
    data->DeleteNode(length);
    return (content);
}

Queue::~Queue()
{
    delete data;
}