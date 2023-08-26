#ifndef CONSOLE_HPP
#define CONSOLE_HPP

#include "Display.hpp"

class Console : public Display {
public:
  std::string sendInput(void);
  void displayOutput(std::string output);
};

#endif // CONSOLE_HPP
