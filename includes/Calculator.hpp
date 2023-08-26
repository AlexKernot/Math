#ifndef CALCULATOR_HPP
#define CALCULATOR_HPP

#include "Display.hpp"
#include "Tokenizer.hpp"

class Calculator {
private:
  Display &display;
  bool displayUserProvided;
  Tokenizer &tokenizer;
  bool tokenizerUserProvided;

public:
  Calculator(Display &_display);
  Calculator(Tokenizer &_tokenizer);
  Calculator(Display &_display, Tokenizer &_tokenizer);
  Calculator();
  void run(void);
  ~Calculator();
};

#endif // CALCULATOR_HPP