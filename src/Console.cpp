#include "Console.hpp"

#include <iostream>

using std::cin;
using std::cout;
using std::endl;
using std::string;

std::string Console::sendInput(void) {
  string input;
  cin >> input;
  return (input);
}

void Console::displayOutput(std::string output) { cout << output << endl; }