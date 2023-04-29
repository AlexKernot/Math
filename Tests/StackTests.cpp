#include <iostream>
#include "../Stack.h"
#include "../LinkedList.h"

class CustomObject
{
    int number;

public:
    CustomObject(int number) {this->number = number;}
    int get_number() {return number;}
};

int main() {
    Stack stack;

    // Test 1: Push integers onto the stack
    int num1 = 10;
    int num2 = 20;
    stack.Push(&num1);
    stack.Push(&num2);
    std::cout << "Pushed " << num1 << " and " << num2 << " onto the stack." << std::endl;

    // Test 2: Pop elements from the stack
    int* poppedNum1 = static_cast<int*>(stack.Pop());
    int* poppedNum2 = static_cast<int*>(stack.Pop());
    std::cout << "Popped " << *poppedNum1 << " and " << *poppedNum2 << " from the stack." << std::endl;

    // Test 3: Push and pop null pointer
    void* nullPtr = nullptr;
    stack.Push(nullPtr);
    void* poppedNullPtr = stack.Pop();
    if (poppedNullPtr == nullptr) {
        std::cout << "Pushed and popped a null pointer successfully." << std::endl;
    } else {
        std::cout << "Failed to push and pop a null pointer." << std::endl;
    }

    // Test 4: Push and pop custom objects
    int num3 = 42;
    CustomObject obj1(num1);
    CustomObject obj2(num2);
    CustomObject obj3(num3);
    stack.Push(&obj1);
    stack.Push(&obj2);
    stack.Push(&obj3);
    std::cout << "Pushed custom objects: " << obj1.get_number() << ", " << obj2.get_number() << ", " << obj3.get_number() << std::endl;
    CustomObject* poppedObj1 = static_cast<CustomObject*>(stack.Pop());
    CustomObject* poppedObj2 = static_cast<CustomObject*>(stack.Pop());
    CustomObject* poppedObj3 = static_cast<CustomObject*>(stack.Pop());
    std::cout << "Popped custom objects: " << poppedObj1->get_number() << ", " << poppedObj2->get_number() << ", " << poppedObj3->get_number() << std::endl;

    return 0;
}