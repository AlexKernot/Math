#include "Stack.h"
#include "LinkedList.h"

void    Stack::Push(void *content) {
    data->AddNode(0, content);
    ++length;
}

void    *Stack::Pop()
{
    void *content = data->GetContent(0);
    data->DeleteNode(0);
    --length;
    return (content);
}