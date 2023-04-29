#include "LinkedList.h"

// Find the first occurance of content in the list.
t_node *LinkedList::Find(void *content)
{
    for (t_node *node = head_node; node != 0; node = node->next)
        if (node->content == content)
            return (node);
    return (0);
}

void *LinkedList::GetContent(int index)
{
    t_node *node = head_node;

    for (int i = 0; i < index; i++)
    {
        if (node == 0)
            return (0);
        node = node->next;
    }
    if (node == 0)
        return (0);
    return (node->content);
}

bool LinkedList::SetContent(int index, void *content)
{
    t_node *node = head_node;

    for (int i = 0; i < index; i++)
    {
        if (node == 0)
            return (false);
        node = node->next;
    }
    node->content = content;
    return (true);
}

// Set index to -1 to add to end of list
bool LinkedList::AddNode(int index, void *content)
{
    if (index == 0 || (index == -1 && head_node == nullptr))
    {
        t_node *temp = new t_node;
        temp->content = content;
        temp->next = head_node;
        head_node = temp;
        return (true);
    }
    t_node *node = head_node;
    for (int i = 0; i < index - 1|| index == -1; i++)
    {
        if (node == 0)
            return (false);
        if (node->next == 0 && index == -1)
            break;
        node = node->next;
    }
    node->next = new t_node;
    node->next->content = content;
    node->next->next = 0;
    return (true);
}

bool LinkedList::DeleteNode(int index)
{
    t_node *node = head_node;
    if (index == 0)
    {
        t_node *nextNode = node->next;
        delete node;
        head_node = nextNode;
        return true;
    }

    for (int i = 0; i < index - 1; ++i)
    {
        if (node == 0)
            return (false);
        node = node->next;
    }
    if (node == nullptr || node->next == nullptr)
        return (false);
    t_node *nextNode = node->next;
    node->next = nextNode->next;
    delete nextNode;
    return (true);
}

LinkedList::~LinkedList()
{
    t_node *node = head_node;
    t_node *tempnode;
    while (true)
    {
        if (node == 0)
            return;
        tempnode = node->next;
        delete node;
        node = tempnode;
    }
}