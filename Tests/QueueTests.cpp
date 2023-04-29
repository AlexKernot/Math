#include <iostream>
#include "../Queue.h"

void QueueTests()
{
    Queue myQueue = Queue();

    // Enqueue some values
    int value1 = 1;
    int value2 = 2;
    int value3 = 3;

    myQueue.Enqueue(&value1);
    myQueue.Enqueue(&value2);
    myQueue.Enqueue(&value3);

    // Dequeue and print the values
    std::cout << "Dequeueing values from the queue: " << std::endl;

    int* dequeuedValue1 = (int*)myQueue.Dequeue();
    std::cout << "Dequeued value 1: " << *dequeuedValue1 << std::endl;

    int* dequeuedValue2 = (int*)myQueue.Dequeue();
    std::cout << "Dequeued value 2: " << *dequeuedValue2 << std::endl;

    int* dequeuedValue3 = (int*)myQueue.Dequeue();
    std::cout << "Dequeued value 3: " << *dequeuedValue3 << std::endl;

    // Test if the queue is empty
    if (myQueue.Dequeue() != nullptr) {
        std::cout << "!! - The queue is not empty. - !!" << std::endl;
    }
}

int main()
{
    QueueTests();
    return 0;
}