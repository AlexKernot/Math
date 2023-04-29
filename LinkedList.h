#ifndef MATH_LINKEDLIST_H
#define MATH_LINKEDLIST_H

typedef struct s_node
{
    void *content;
    s_node *next;
} t_node;

class LinkedList
{
    t_node *head_node;
public:
    LinkedList(void *content) 
    {
        head_node = new t_node;
        head_node->content = content;
        head_node->next=0;
    }
    LinkedList() {head_node = nullptr;}
    t_node *Find(void *content);
    void *GetContent(int index);
    bool  SetContent(int index, void *content);
    bool  AddNode(int index, void *content);
    bool  DeleteNode(int index);
    ~LinkedList();
};
#endif