#include <cassert>
#include <iostream>

#include "../LinkedList.h"

using std::cout;

void testLinkedList() {
    // Create a linked list with an initial node containing the number 42
    int num = 42;
    LinkedList list(&num);

    // Test GetContent()
    void *content = list.GetContent(0);
    assert(content == &num);

    // Test SetContent()
    int newNum = 24;
    bool success = list.SetContent(0, &newNum);
    assert(success);
    content = list.GetContent(0);
    assert(content == &newNum);

    // Test AddNode()
    int otherNum = 123;
    list.AddNode(1, &otherNum);
    list.AddNode(-1, &num);
    assert(list.GetContent(0) == &newNum);
    assert(list.GetContent(1) == &otherNum);
    assert(list.GetContent(2) == &num);

    // Test Find()
    t_node node = *(list.Find(&num));
    assert(node.content == &num);

    // Test DeleteNode()
    bool deleteSuccess = list.DeleteNode(1);
    assert(deleteSuccess);
    assert(list.GetContent(0) == &newNum);
    assert(list.GetContent(1) == &num);
    assert(list.GetContent(2) == nullptr); // Expected content to be nullptr after deletion

    deleteSuccess = list.DeleteNode(2); // Attempt to delete invalid index
    assert(!deleteSuccess); // Expected deletion to fail
}

int main() {
    testLinkedList();
    return 0;
}