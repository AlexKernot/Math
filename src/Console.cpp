#include "Console.hpp"

#include <iostream>

using std::string;
using std::cin;
using std::cout;
using std::endl;

std::string Console::sendInput(void) {
    string input;
    cin >> input;
    return (input);
}

void Console::displayOutput(std::string output) {
    cout << output << endl;
}