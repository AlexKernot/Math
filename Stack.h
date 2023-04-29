#include "LinkedList.h"

class Stack
{
    LinkedList *data;
    int length = 0;

public:
    Stack()
    {
        data = new LinkedList();
    }
    void *Pop();
    void Push(void *content);
    t_node *GetHeadNode();
    ~Stack()
    {
        delete data;
    }
};