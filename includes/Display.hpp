#ifndef DISPLAY_HPP
#define DISPLAY_HPP

#include <string>

class Display {
public:
  virtual std::string sendInput(void) = 0;
  virtual void displayOutput(std::string) = 0;
};

#endif // DISPLAY_HPP
